/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv007_05a_p01.sql
PROCEDIMIENTO: CONSULTA COMPRA
	(Formato = 0 ; en Undidad de Compra)
AUTOR:	CREARSIS(chl)
FECHA:	26-12-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_05a_p01
GO

CREATE PROCEDURE inv007_05a_p01 @ar_ide_cmp	NVARCHAR(20),	-- Identificador de la compra
								@ar_ges_cmp	INT	-- gestion de la compra
							 WITH ENCRYPTION AS
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_fec_cmp		DATETIME,
@va_cod_doc		CHAR(03),
@va_nro_cmp		INT,
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(50),			-- Numero de del documento
@va_for_pag		INT,	--Identificador de la venta (XXX|000-00000/2018)
@va_tip_cam		DECIMAL(4,2),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(80),
@va_mon_cmp		CHAR(01),
@va_tot_bBs		DECIMAL(16,5),
@va_tot_bUs		DECIMAL(16,5),
@va_tot_bru		DECIMAL(16,5),
@va_des_cBs		DECIMAL(16,5),
@va_des_cUs		DECIMAL(16,5),
@va_des_cue		DECIMAL(16,5),
@va_tot_nBs		DECIMAL(16,5),
@va_tot_nUs		DECIMAL(16,5),
@va_tot_net		DECIMAL(16,5),
@va_obs_cmp		VARCHAR(200),
@va_est_ado		CHAR(01),
@va_usr_reg		VARCHAR(15),
@va_fec_reg		DATETIME,
@va_nro_itm		INT,
@va_cod_pro		VARCHAR(15),
@va_des_pro		varchar(120)	,	--Descripcion del Producto 
@va_can_tid		DECIMAL(14,4),				--Cantidad de producto
@va_und_inv		CHAR(03)		,	--Numero de item 
@va_pre_uBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tot		DECIMAL(16,2),
@va_fir_ma1		VARCHAR(30)	,
@va_fir_ma2		VARCHAR(30)	,
@va_fir_ma3		VARCHAR(30)	,
@va_fir_ma4		VARCHAR(30)	


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv007(
	va_fec_cmp		DATETIME		NOT NULL,	--Codigo del usuario
	va_ide_cmp		VARCHAR(20)		NOT NULL,	--Codigo temporal (fecha y hora)
	va_ges_cmp		INT				not null,	--Numero de item 
	va_nro_cmp		INT				NOT NULL,	--Codigo Producto
	va_cod_bod		INT				not null,	--Numero de item 
	va_nom_bod		VARCHAR(50)		not null,	--Numero de item
	va_for_pag		INT				NOT NULL,	-- Forma de Pago **
	va_tip_cam		DECIMAL(4,2)	NOT NULL,	--Tipo de cambio **
	va_cod_per		INT				not null,	--Numero de item 
	va_raz_soc		VARCHAR(80)		not null,	--Numero de item 
	va_mon_cmp		CHAR(01)		not null,	--Numero de item 
	va_tot_bru		DECIMAL(16,5)	not null,	--Numero de item 
	va_des_cue		DECIMAL(16,5)	not null,	--Numero de item 
	va_tot_net		DECIMAL(16,5)	not null,	--Numero de item 
	va_obs_cmp		VARCHAR(200)	not null,	--Numero de item 
	va_est_ado		CHAR(01)		not null,	--Numero de item 
	va_usr_reg		VARCHAR(15)		NOT NULL,	--Usuario registro
	va_fec_reg		DATETIME		NOT NULL,	--Fecha de registro
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		not null,	--Numero de item 
	va_des_pro		varchar(120)	not null,	--Descripcion del Producto 
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_und_inv		CHAR(03)		not null,	--Numero de item 
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_fir_ma1		VARCHAR(30)	,
	va_fir_ma2		VARCHAR(30)	,
	va_fir_ma3		VARCHAR(30)	,
	va_fir_ma4		VARCHAR(30)	,

   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv007
BEGIN TRY

	-- Obtiene datos del encabezado
	SELECT @va_fec_cmp = va_fec_cmp, @va_nro_cmp = va_nro_cmp,
		   @va_cod_doc = va_doc_doc,
		   @va_cod_per = va_cod_per, @va_raz_soc = va_raz_soc,
		   @va_tot_bBs = va_tot_bBs, @va_tot_bUs = va_tot_bUs,
		   @va_des_cBs = va_des_cBs, @va_des_cUs = va_des_cUs,
		   @va_tot_nBs = va_tot_nBs, @va_tot_nUs = va_tot_nUs,
		   @va_cod_bod = va_cod_bod, @va_tip_cam = va_tip_cam,
		   @va_mon_cmp = va_mon_cmp, @va_for_pag = va_for_pag,
		   @va_usr_reg = va_usr_reg, @va_fec_reg = va_fec_reg,
		   @va_obs_cmp = va_obs_cmp, @va_est_ado = va_est_ado
	FROM inv007
	WHERE va_ide_cmp = @ar_ide_cmp	AND
		  va_ges_cmp = @ar_ges_cmp
	
	-- Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	FROM inv002
	WHERE va_cod_bod = @va_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_nom_bod = '';
	END
	
	-- Obtiene firmas del documento
	SELECT @va_fir_ma1 = va_fir_ma1,
		   @va_fir_ma2 = va_fir_ma2,
		   @va_fir_ma3 = va_fir_ma3,
		   @va_fir_ma4 = va_fir_ma4
	 FROM ads004
	WHERE va_ide_doc = @va_cod_doc
	
	--Obtiene Totales segun moneda de la compra
	IF (@va_mon_cmp = 'B')
	BEGIN
		SET @va_tot_bru = @va_tot_bBs
		SET @va_des_cue = @va_des_cBs
		SET @va_tot_net = @va_tot_nBs
	END
	IF (@va_mon_cmp = 'U')
	BEGIN
		SET @va_tot_bru = @va_tot_bUs
		SET @va_des_cue = @va_des_cUs
		SET @va_tot_net = @va_tot_nUs
	END
		
		
	--// Cursor sobre temporal
	DECLARE vc_inv008 CURSOR LOCAL FOR
	SELECT va_nro_itm, va_cod_pro, va_des_pro, va_can_uiv, va_cod_uni,
		   va_pre_uBs, va_pre_uUs, va_imp_tBs, va_imp_tUs 
	FROM inv008	
	WHERE va_ide_cmp = @ar_ide_cmp	AND
		  va_ges_cmp = @ar_ges_cmp
	
	--** Abre cursor		  
	OPEN vc_inv008    
		 
	FETCH NEXT FROM vc_inv008 INTO @va_nro_itm, @va_cod_pro, @va_des_pro, @va_can_tid, @va_und_inv,
								   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	
	
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@va_mon_cmp = 'B')
		BEGIN
			SET @va_pre_uni = @va_pre_uBs
			SET @va_pre_tot = @va_pre_tBs
		END
		IF (@va_mon_cmp = 'U')
		BEGIN
			SET @va_pre_uni = @va_pre_uUs
			SET @va_pre_tot = @va_pre_tUs
		END
		
	
		INSERT INTO #tm_inv007 VALUES ( @va_fec_cmp		,
										@ar_ide_cmp		,
										@ar_ges_cmp		,
										@va_nro_cmp		,
										@va_cod_bod		,
										@va_nom_bod		,
										@va_for_pag		,
										@va_tip_cam		,
										@va_cod_per		,
										@va_raz_soc		,
										@va_mon_cmp		,
										@va_tot_bru		,
										@va_des_cue		,
										@va_tot_net		,
										@va_obs_cmp		,
										@va_est_ado		,
										@va_usr_reg		,
										@va_fec_reg		,
										@va_nro_itm		,
										@va_cod_pro		,
										@va_des_pro		,
										@va_can_tid		,
										@va_und_inv		,
										@va_pre_uni		,
										@va_pre_tot		,  
										@va_fir_ma1		,
										@va_fir_ma2		,
										@va_fir_ma3		,
										@va_fir_ma4 )
			
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de items en tabla temporal',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_inv008 INTO @va_nro_itm, @va_cod_pro, @va_des_pro, @va_can_tid,@va_und_inv,
									   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	END	
CLOSE vc_inv008
DEALLOCATE vc_inv008

SELECT * FROM #tm_inv007
	

	COMMIT TRAN TR_inv007
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv007
	RETURN
END CATCH	   

GO