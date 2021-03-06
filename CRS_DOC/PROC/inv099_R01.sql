/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv099_R01.sql
PROCEDIMIENTO: REPORTE KARDEX DE UN PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	24-04-2019
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv099_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv099_R01
GO

CREATE PROCEDURE inv099_R01		@ar_cod_bod		INT,			-- Almacen
								@ar_cod_pro		VARCHAR(15),	-- Producto
								@ar_fec_ini		DATE,			-- Fecha inicial
								@ar_fec_fin		DATE			-- Fecha final
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_fec_doc	DATE,
@va_ges_tio	INT,
@va_cod_doc	CHAR(03),
@va_nro_tal	INT,
@va_nro_doc	INT,
@va_ide_doc	VARCHAR(25),
@va_nro_itm	INT,
@va_ref_doc	VARCHAR(20),
@va_mon_eda	CHAR(01),
@va_glo_doc	NVARCHAR(100),
@va_cod_pro	VARCHAR(15)		,					--** Codigo del producto 
@va_nom_pro	VARCHAR(80)		,					--** Nombre del producto
@va_und_inv	CHAR(03),
@va_und_cmp	CHAR(03),
@va_und_vta	CHAR(03),
@va_eqv_cmp	DECIMAL(6,2),
@va_eqv_vta	DECIMAL(6,2),
@va_cod_fam	VARCHAR(6)		,					--** Codigo de la familia de producto
@va_can_ing	DECIMAL(14,4),
@va_can_egr	DECIMAL(14,4),
@va_cod_bod	INT				,					--Codigo de la bodega (inv002)
@va_nom_bod VARCHAR(50),
@va_cod_usr  NVARCHAR(15),
@va_fec_ant	DATE,
@va_sal_ant	DECIMAL(16,4),
@va_sal_ope DECIMAL(16,4)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv100(
	va_fec_ant	DATE,
	va_sal_ant	DECIMAL(16,4),
	va_sal_ope	DECIMAL(16,4),
	va_fec_ini	DATE,
	va_fec_fin  DATE,
	va_fec_doc	DATE,
	va_ges_tio	INT,
	va_cod_doc	CHAR(03),
	va_nro_tal	INT,
	va_nro_doc	INT,
	va_ide_doc	VARCHAR(25),
	va_nro_itm	INT,
	va_ref_doc	VARCHAR(20),
	va_mon_eda	CHAR(01),
	va_glo_doc	NVARCHAR(100),
	va_cod_pro	VARCHAR(15)		NOT NULL,					--** Codigo del producto 
	va_nom_pro	VARCHAR(80)		NOT NULL,						--** Nombre del producto
	va_und_inv	CHAR(03),
	va_und_cmp	CHAR(03),
	va_und_vta	CHAR(03),
	va_eqv_cmp	DECIMAL(6,2),
	va_eqv_vta	DECIMAL(6,2),
	va_cod_fam	VARCHAR(6)		NOT NULL,					--** Codigo de la familia de producto
	va_can_ing	DECIMAL(14,4),
	va_can_egr	DECIMAL(14,4),
	va_cod_bod	INT				NOT NULL,	--Codigo de la bodega (inv002)
	va_nom_bod  VARCHAR(50),
	va_cod_usr  NVARCHAR(15)
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
	
		
	--// Cursor sobre tabla kardex
	DECLARE vc_inv100 CURSOR LOCAL FOR
	SELECT va_fec_doc,va_ges_tio,va_cod_doc,va_nro_tal,va_nro_doc, va_ide_doc,va_nro_itm,va_ref_doc,va_mon_eda,va_glo_doc,
		   va_cod_pro,va_can_ing,va_can_egr,va_cod_bod,va_cod_usr
	FROM inv100 
	WHERE  va_cod_pro = @ar_cod_pro and
		   va_cod_bod = @ar_cod_bod	AND
		   (va_fec_doc BETWEEN @ar_fec_ini AND @ar_fec_fin)
	ORDER BY va_fec_doc asc , va_ide_doc asc		   

	--** Abre cursor			@va_nom_pro,@va_und_inv,@va_und_cmp,@va_und_vta	,@va_eqv_cmp,va_eqv_vta,@va_cod_fam,	  
	OPEN vc_inv100   
	FETCH NEXT FROM vc_inv100 INTO @va_fec_doc,@va_ges_tio,@va_cod_doc,@va_nro_tal,@va_nro_doc,@va_ide_doc,@va_nro_itm,@va_ref_doc,
								   @va_mon_eda,@va_glo_doc,@va_cod_pro,@va_can_ing,@va_can_egr,@va_cod_bod,@va_cod_usr 
		
		
	-- Inicializa fecha para saldo anterior
	SET @va_fec_ant = DATEADD(DAY,-1,@ar_fec_ini)
	
	
	 
	-- Obtiene saldo de stock anterior
	SET @va_sal_ant = 0
	EXECUTE inv100_01a_p02 @ar_cod_bod, @ar_cod_pro, @va_fec_ant, @va_sal_ant OUTPUT
	 
	IF (@va_sal_ant IS NULL)
		SET @va_sal_ant = 0
	
	-- Inicializa saldo de operacion
	SET @va_sal_ope = @va_sal_ant
		
		
	-- Obtiene Datos de producto
	SELECT @va_nom_pro=va_nom_pro ,@va_und_inv= va_cod_umd,@va_und_cmp=va_und_cmp ,@va_und_vta=va_und_vta,
		   @va_eqv_cmp=va_eqv_cmp ,@va_eqv_vta=va_eqv_vta ,@va_cod_fam=va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @ar_cod_pro 
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_nom_pro = ''
	END
	
	-- Obtiene nombre de la bodega
	SELECT @va_nom_bod=va_nom_bod 
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod 
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_nom_bod = ''
	END
	
	 
	IF(@@FETCH_STATUS <> 0 AND @va_sal_ant <> 0)	
	BEGIN
		INSERT INTO #tm_inv100 VALUES ( DATEADD(DAY,-1,@ar_fec_ini)	,
										@va_sal_ant ,
										@va_sal_ant ,
										@ar_fec_ini ,
										@ar_fec_fin ,
										@va_fec_doc	,
										@va_ges_tio	,
										@va_cod_doc	,
										@va_nro_tal	,
										@va_nro_doc	,
										@va_ide_doc ,
										@va_nro_itm	,
										@va_ref_doc	,
										@va_mon_eda	,
										@va_glo_doc	,
										@ar_cod_pro	,					--** Codigo del producto 
										@va_nom_pro	,					--** Nombre del producto
										@va_und_inv	,
										@va_und_cmp	,
										@va_und_vta	,
										@va_eqv_cmp	,
										@va_eqv_vta	,
										@va_cod_fam	,					--** Codigo de la familia de producto
										@va_can_ing	,
									  - @va_can_egr	,
										@ar_cod_bod	,					--Codigo de la bodega (inv002)
										@va_nom_bod ,
										@va_cod_usr
										)
	END	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		-- Obtiene saldo de la operacion
		IF(@va_can_ing <> 0 )
			SET @va_sal_ope = @va_sal_ope + @va_can_ing
		
		IF(@va_can_egr <> 0)
			SET @va_sal_ope = @va_sal_ope - @va_can_egr
		
		PRINT @va_sal_ope
		
		INSERT INTO #tm_inv100 VALUES ( DATEADD(DAY,-1,@ar_fec_ini)	,
										@va_sal_ant ,
										@va_sal_ope ,
										@ar_fec_ini ,
										@ar_fec_fin ,
										@va_fec_doc	,
										@va_ges_tio	,
										@va_cod_doc	,
										@va_nro_tal	,
										@va_nro_doc	,
										@va_ide_doc ,
										@va_nro_itm	,
										@va_ref_doc	,
										@va_mon_eda	,
										@va_glo_doc	,
										@va_cod_pro	,					--** Codigo del producto 
										@va_nom_pro	,					--** Nombre del producto
										@va_und_inv	,
										@va_und_cmp	,
										@va_und_vta	,
										@va_eqv_cmp	,
										@va_eqv_vta	,
										@va_cod_fam	,					--** Codigo de la familia de producto
										@va_can_ing	,
										- @va_can_egr	,
										@va_cod_bod	,					--Codigo de la bodega (inv002)
										@va_nom_bod ,
										@va_cod_usr
										)
										
				IF(@va_fec_ant < @ar_fec_ini)
					SET @va_fec_ant = @ar_fec_ini
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de kardex de productos',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_inv100 INTO @va_fec_doc,@va_ges_tio,@va_cod_doc,@va_nro_tal,@va_nro_doc,@va_ide_doc,@va_nro_itm,@va_ref_doc,
								   @va_mon_eda,@va_glo_doc,@va_cod_pro,@va_can_ing,@va_can_egr,@va_cod_bod,@va_cod_usr 
	END	
	
CLOSE vc_inv100
DEALLOCATE vc_inv100


	SELECT * FROM #tm_inv100
	ORDER BY va_fec_doc ASC--, va_sal_ope asc


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO