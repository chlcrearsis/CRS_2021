/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: res001_04a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO ANULA VENTA
	(anula venta, suma existencia, borra kardex, 
	costea reingreso de los productos, )
AUTOR:	CREARSIS(chl)
FECHA:	01-05-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res001_04a_p01
GO

CREATE PROCEDURE res001_04a_p01 @ar_ide_vta	VARCHAR(20),--Identificador de la venta (XXX|000-00000/2018)
							 @ar_ges_vta	INT --,		--Gestion de la venta							
							 --@ar_ide_usr	VARCHAR(15)	--Codigo del usuario que anula
							  WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_nro_doc		INT, 
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_itm_vta		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_can_uni		DECIMAL(14,4),	--Cantidad inventario de producto
@va_cod_fam		VARCHAR(6),					--** Codigo de la familia de producto
@va_tip_fam		CHAR(1),		--Tipo de la cuenta (M=Matriz ; D=DETALLE ; S=Servicio C=Combo)
@va_cod_bod		INT,	        --Codigo del almacen (7 numeros)
@va_ges_tio		INT,			--Gestion de la venta

@va_sal_can		DECIMAL(14,2)

BEGIN TRAN TR_CMR005
BEGIN TRY   
  		
SELECT @va_est_ado = va_est_ado,
       @va_cod_bod = va_cod_bod,
       @va_ges_tio = va_ges_vta
  FROM res001
WHERE va_ide_vta = @ar_ide_vta	AND
	  va_ges_vta = @ar_ges_vta
	  
IF @@ROWCOUNT = 0
BEGIN
	RAISERROR ('LA VENTA NO SE ENCUENTRA REGISTRADA',16,1)
	RETURN
END
IF @va_est_ado = 'N'
BEGIN
	RAISERROR ('LA VENTA YA SE ENCUENTRA ANULADA',16,1)
	RETURN
END
	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_itm_vta, va_cod_pro, va_can_uni
FROM res002
WHERE va_ide_vta = @ar_ide_vta	AND
	  va_ges_vta = @ar_ges_vta

	
--** Abre cursor		  
OPEN vc_det_vta    
	 
FETCH NEXT FROM vc_det_vta 
INTO @va_itm_vta, @va_cod_pro, @va_can_uni

WHILE (@@FETCH_STATUS = 0)
BEGIN
	
	-- Obtiene el codigo de familia
	SELECT @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_cod_fam = ''
	END
	
	-- Obtiene el tipo de familia
	SELECT @va_tip_fam = va_tip_fam
	FROM inv003
	WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_tip_fam = ''
	END
	
	IF @va_tip_fam = 'D'
	BEGIN
		---- Obtien saldo actual de inventario
		--SELECT @va_sal_can = va_sal_can
		--FROM inv101
		--WHERE va_cod_pro = @va_cod_pro
		--  AND va_cod_bod = @va_cod_bod
		
		--IF @@ROWCOUNT = 0
		--BEGIN
		--	SET @va_sal_can = 0
		--END
		
		----** Verifica que saldo existencia sea mayor que la cantidad de la venta
		--IF @va_can_uni > @va_sal_can 
		--BEGIN
		--	SET @msg = 'Item: ' + CAST(@va_itm_vta AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +')  NO tiene existencia suficiente'
		--	RAISERROR (@msg,16,1)
		--	RETURN
		--END
		--** resta saldo existencia
		UPDATE inv099 SET va_sal_can = va_sal_can + @va_can_uni
		 WHERE va_cod_pro = @va_cod_pro 
		   AND va_cod_bod = @va_cod_bod
		   
		-- costea reingreso del producto
		
		-- si es al contado - anula Recibo de Ingreso por venta
		
		-- si es al credito - anula Registro CxC (si aun no tiene pagos reslizados)
		
		
		--SI ES FACTURA (ELIMINA REGISTRO DEBITO FISCAL)
	END
	
	--** elimina registro del kardex
	DELETE FROM inv100 WHERE va_ide_doc = @ar_ide_vta
					     AND va_cod_pro = @va_cod_pro
					     AND va_ges_tio = @va_ges_tio
   
 
FETCH NEXT FROM vc_det_vta 
INTO @va_itm_vta, @va_cod_pro, @va_can_uni
END
--** cambia estado encabezado venta
UPDATE res001 SET va_est_ado = 'N', 
				  va_usr_anu = SYSTEM_USER, -- @ar_ide_usr,
				  va_fec_anu = GETDATE()
 WHERE va_ide_vta = @ar_ide_vta	AND
	   va_ges_vta = @ar_ges_vta

CLOSE vc_det_vta
DEALLOCATE vc_det_vta


COMMIT TRAN TR_CMR005

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1) 
	Rollback TRAN TR_CMR005   
	RETURN
END CATCH	

RETURN (0)

GO