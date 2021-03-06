/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr005_04a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO ANULA VENTA
	(anula venta, suma existencia, borra kardex, 
	costea reingreso de los productos, )
AUTOR:	CREARSIS(chl)
FECHA:	01-05-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_04a_p01
GO

CREATE PROCEDURE cmr005_04a_p01 @ar_ide_vta	VARCHAR(20),--Identificador de la venta (XXX|000-00000/2018)
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

@va_cot_act		DECIMAL(14,2),	-- Valor Costo total del producto antes de la anulacion
@va_cot_itm		DECIMAL(14,2),	-- Valor costo total del item 
@va_nvo_cos		DECIMAL(14,2),	-- Valor Nuevo costo promedio para el item
@va_tip_cam		DECIMAL(14,2),	-- Tipo de cambio 

@va_sal_can		DECIMAL(14,2)

BEGIN TRAN TR_CMR005
BEGIN TRY   
  		
SELECT @va_est_ado = va_est_ado,
       @va_cod_bod = va_cod_bod,
       @va_ges_tio = va_ges_vta
  FROM cmr005
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
	
	
-- Obtiene el tipo de cambio a la fecha
SET @va_tip_cam = 1
	

	
	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_itm_vta, va_cod_pro, va_can_uni
FROM cmr006
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
	
	SET @va_nvo_cos = 0
	
	IF @va_tip_fam = 'D'
	BEGIN
	
		-- Obtien saldo actual de inventario
		SELECT @va_sal_can = va_sal_can,
			   @va_cot_act = va_sal_can * va_cos_ubs
		FROM inv099
		WHERE va_cod_pro = @va_cod_pro
		  AND va_cod_bod = @va_cod_bod
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_sal_can = 0
			SET @va_cot_act = 0
		END
		
		--** Verifica que saldo existencia sea mayor que la cantidad de la venta
		IF @va_can_uni > @va_sal_can 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_itm_vta AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +')  NO tiene la existencia suficiente'
			RAISERROR (@msg,16,1)
			RETURN
		END
		
		-- Obtiene costo total de la operacion, del producto
		SELECT @va_cot_itm = va_cos_toB
		FROM inv100 WHERE va_ide_doc = @ar_ide_vta
					     AND va_cod_pro = @va_cod_pro
					     AND va_ges_tio = @va_ges_tio
		
		-- costea reingreso del producto
		-- Total valorado / total cantidad
		SET @va_nvo_cos = (@va_cot_act + @va_cot_itm) / (@va_sal_can + @va_can_uni)
		
		
		
		
		
		-- si es al contado - anula Recibo de Ingreso por venta
		
		-- si es al credito - anula Registro CxC (si aun no tiene pagos reslizados)
		
		
		--SI ES FACTURA (ELIMINA REGISTRO DEBITO FISCAL)
	END
	
	--** Actualiza saldo valorado existencia
	UPDATE inv099 SET va_sal_can = (va_sal_can + @va_can_uni),
					  va_cos_ubs = @va_nvo_cos , 
					  va_cos_uus = (@va_nvo_cos * @va_tip_cam)
	WHERE va_cod_pro = @va_cod_pro 
	  AND va_cod_bod = @va_cod_bod
		   
	--** elimina registro del kardex
	DELETE FROM inv100 WHERE va_ide_doc = @ar_ide_vta
					     AND va_cod_pro = @va_cod_pro
					     AND va_ges_tio = @va_ges_tio
    
 
FETCH NEXT FROM vc_det_vta 
INTO @va_itm_vta, @va_cod_pro, @va_can_uni
END
--** cambia estado encabezado venta
UPDATE cmr005 SET va_est_ado = 'N', 
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