/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: res001_05a_p01.sql
PROCEDIMIENTO: CONSULTA NOTA DE VENTA RESTAURANT
	(Formato = 0 ; en Undidad de Compra)
AUTOR:	CREARSIS(chl)
FECHA:	26-12-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.res001_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res001_05a_p01
GO

CREATE PROCEDURE res001_05a_p01 @ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
								@ar_ges_vta	INT	-- gestion de la compra
							 WITH ENCRYPTION AS
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
--@ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
--@ar_ges_vta	INT	,-- gestion de la compra
@msg			nvarchar(200),
@va_fec_vta		DATETIME,
@va_nro_vta		INT,
@va_cod_bod		CHAR(06),
@va_nom_bod		VARCHAR(50),			-- Numero de del documento
@va_for_pag		INT,	--Identificador de la venta (XXX|000-00000/2018)
@va_tip_cam		DECIMAL(4,2),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(80),
@va_mon_vta		CHAR(01),
@va_sub_toB		DECIMAL(16,5),
@va_sub_toU		DECIMAL(16,5),
@va_tot_bru		DECIMAL(16,5),
@va_dto_vtB		DECIMAL(16,5),
@va_dto_vtU		DECIMAL(16,5),
@va_des_cue		DECIMAL(16,5),
@va_tot_vtB		DECIMAL(16,5),
@va_tot_vtU		DECIMAL(16,5),
@va_tot_net		DECIMAL(16,5),
@va_obs_vta		VARCHAR(200),
@va_vta_par		CHAR(01)	,
@va_est_ado		CHAR(01),
@va_usr_reg		VARCHAR(15),
@va_fec_reg		DATETIME,
@va_itm_vta		INT,
@va_cod_pro		VARCHAR(15),
@va_des_pro		varchar(120)	,			--Descripcion del Producto 
@va_can_tid		DECIMAL(14,4),				--Cantidad de producto
@va_und_inv		CHAR(03)		,			--Numero de item 
@va_pre_uBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tot		DECIMAL(16,2),

@va_doc_vta     CHAR(03),					-- Documento de la operacion
@va_nro_tal     INT,						-- Nro de talonario de la operacion
@va_fir_ma1		VARCHAR(20),				--Firma del talonario 1
@va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
@va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
@va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
--@va_log_emp		VARBINARY(max),				--Logo de la empresa
@va_log_emp		NVARCHAR(100),				--Logo de la empresa
@va_for_log		TINYINT, 					--Formato de logo
											-- 0=Nombre de la empresa
											-- 1=logo 1
@va_for_mat		INT,						-- Formato de impresión

											
@va_cod_del		int,
@va_nom_del		varchar(30),
@va_cod_ven		INT,						--Codigo Vendedor
@va_nom_ven		VARCHAR(50),				--Nombre vendedor

@va_cod_plv		INT,						-- Plantilla de venta											
@va_tip_vta		INT,						-- Tipo de venta (1=factura ; 2=nota de venta)
@va_ref_vta		VARCHAR(20)

	

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_res001(
	va_fec_vta		DATETIME		NOT NULL,	--Codigo del usuario
	va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador compuesto para la venta
	va_ges_vta		INT				not null,	--Gestion de la venta 
	va_nro_vta		INT				NOT NULL,	--Nro venta
	va_cod_bod		char(06)		not null,	--Almacen
	va_nom_bod		VARCHAR(50)		not null,	--Nombre almacen
	va_for_pag		INT				NOT NULL,	-- Forma de Pago **
	va_tip_cam		DECIMAL(4,2)	NOT NULL,	--Tipo de cambio **
	va_cod_per		INT				not null,	--Codigo persona
	va_raz_soc		VARCHAR(80)		not null,	--Razon social
	va_mon_vta		CHAR(01)		not null,	--Numero de item 
	va_tot_bru		DECIMAL(16,5)	not null,	--Numero de item 
	va_des_cue		DECIMAL(16,5)	not null,	--Numero de item 
	va_tot_net		DECIMAL(16,5)	not null,	--Numero de item 
	va_obs_vta		VARCHAR(200)	not null,	--Numero de item 
	va_vta_par		CHAR(01)		not null,	--Venta para (M=Mesa; L=Llevar ; D=Delivery)
	
	
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
    va_fir_ma1		VARCHAR(20),    		    --Firma del talonario 1
	va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
	va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
	va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
	va_for_log		TINYINT, 	                --Formato de logo
												-- 0=Nombre de la empresa
												-- 1=logo 1
	--va_log_emp		VARBINARY(max),				--Logo de la empresa
	va_cod_del		INT,
	va_nom_del		VARCHAR(30),
	va_cod_ven		INT,						--Codigo Vendedor
	va_nom_ven		VARCHAR(50),				--Nombre vendedor
	va_cod_plv		INT,						--Codigo plantilla de venta
	va_log_emp		NVARCHAR(100),				--Logo de la empresa
	va_ref_vta		VARCHAR(20),				--Referencia de la venta
	va_tip_vta		INT	,						--Tipo de venta (1=Factura ; 2=Nota de venta)
	va_for_mat		INT							--Formato de impresión
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_res001
BEGIN TRY
--SET @ar_ide_vta = 'VRS-000-000007'
--SET @ar_ges_vta = 2020
	-- Obtiene datos del encabezado
	SELECT @va_fec_vta = va_fec_vta, @va_nro_vta = va_nro_vta,
		   @va_cod_per = va_cod_per, @va_raz_soc = va_raz_soc,
		   @va_sub_toB = va_sub_toB, @va_sub_toU = va_sub_toU,
		   @va_dto_vtB = va_dto_vtB, @va_dto_vtU = va_dto_vtU,
		   @va_tot_vtB = va_tot_vtB, @va_tot_vtU = va_tot_vtU,
		   @va_cod_bod = va_cod_bod, @va_tip_cam = va_tip_cam,
		   @va_vta_par = va_vta_par,
		   @va_mon_vta = va_mon_vta, @va_for_pag = va_for_pag,
		   @va_usr_reg = va_usr_reg, @va_fec_reg = va_fec_reg,
		   @va_obs_vta = va_obs_vta, @va_est_ado = va_est_ado,
		   @va_doc_vta = va_doc_vta, @va_nro_tal = va_nro_tal,
		   @va_ref_vta = va_ref_vta, @va_cod_del = va_cod_del,
		   @va_cod_ven = va_cod_ven, @va_cod_plv = va_cod_plv,
		   @va_tip_vta = va_tip_vta
	FROM res001
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
	
	
	
	-- Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	FROM inv002
	WHERE va_cod_bod = @va_cod_bod
	
	
	-- Obtiene nombre del Delivery
	SELECT @va_nom_del = va_nom_del
	FROM cmr015
	WHERE va_cod_del = @va_cod_del
	
	-- Obtiene nombre del Vendedor
	SELECT @va_nom_ven = va_nom_bre
	FROM cmr014
	WHERE va_cod_ide = @va_cod_ven	AND
		  va_ide_tip = 1
	
	
	--Obtiene Totales segun moneda de la venta
	IF (@va_mon_vta = 'B')
	BEGIN
		SET @va_tot_bru = @va_sub_toB
		SET @va_des_cue = @va_dto_vtB
		SET @va_tot_net = @va_tot_vtB
	END
	IF (@va_mon_vta = 'U')
	BEGIN
		SET @va_tot_bru = @va_sub_toU
		SET @va_des_cue = @va_dto_vtU
		SET @va_tot_net = @va_tot_vtU
	END
	
	--// obtiene datos de Talonario
	SELECT @va_for_log = va_for_log,
		   @va_for_mat = va_for_mat,
		   @va_fir_ma1 = va_fir_ma1,
		   @va_fir_ma2 = va_fir_ma2,
		   @va_fir_ma3 = va_fir_ma3,
		   @va_fir_ma4 = va_fir_ma4
	 FROM ads004
	WHERE va_ide_doc = @va_doc_vta AND 
		  va_nro_tal = @va_nro_tal
	 IF @@ROWCOUNT = 0
	 BEGIN
		SET @va_for_log = 0
		SET @va_fir_ma1 = ''
		SET @va_fir_ma2 = ''
		SET @va_fir_ma3 = ''
		SET @va_fir_ma4 = ''
	 END
	 
	 IF @va_for_log = 1
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 12
	 END
	 IF @va_for_log = 2
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 13
	 END	
	 IF @va_for_log = 3
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 14
	 END	
	 IF @va_for_log = 4
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 15
	 END	
	 
	--// Cursor sobre Detalle
	DECLARE vc_res001 CURSOR LOCAL FOR
	SELECT va_itm_vta, va_cod_pro, va_des_pro, va_can_uni, va_und_inv,
		   (va_mto_brB - va_val_dtB), (va_mto_brU - va_val_dtU), va_mto_neB, va_mto_neU 
	 FROM res002 --WHERE va_ide_vta = 'VRS-000-000008'	
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
		
	--** Abre cursor		  
	OPEN vc_res001    
		 
	FETCH NEXT FROM vc_res001 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid, @va_und_inv,
								   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@va_mon_vta = 'B')
		BEGIN
			SET @va_pre_uni = @va_pre_uBs
			SET @va_pre_tot = @va_pre_tBs
		END
		IF (@va_mon_vta = 'U')
		BEGIN
			SET @va_pre_uni = @va_pre_uUs
			SET @va_pre_tot = @va_pre_tUs
		END
		
		
		--//** Obtiene nombre del producto de la tabla producto
		SELECT @va_des_pro = va_nom_pro
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro
		 
	----//** Obtiene nombre del delivery
	--	SELECT @va_nom_del = va_nom_del
	--	  FROM cmr010
	--	 WHERE va_cod_del = @va_cod_del
	
		INSERT INTO #tm_res001 VALUES ( @va_fec_vta		,
										@ar_ide_vta		,
										@ar_ges_vta		,
										@va_nro_vta		,
										@va_cod_bod		,
										@va_nom_bod		,
										@va_for_pag		,
										@va_tip_cam		,
										@va_cod_per		,
										@va_raz_soc		,
										@va_mon_vta		,
										@va_tot_bru		,
										@va_des_cue		,
										@va_tot_net		,
										@va_obs_vta		,
										@va_vta_par		,
										@va_est_ado		,
										@va_usr_reg		,
										@va_fec_reg		,
										@va_itm_vta		,
										@va_cod_pro		,
										@va_des_pro		,
										@va_can_tid		,
										@va_und_inv		,
										@va_pre_uni		,
										@va_pre_tot		,
										@va_fir_ma1		,
										@va_fir_ma2		,
										@va_fir_ma3		,
										@va_fir_ma4		,
										@va_for_log		,
										
										@va_cod_del		,
										@va_nom_del		,
										@va_cod_ven		,
										@va_nom_ven		,
										@va_cod_plv		,
										@va_log_emp		,
										@va_ref_vta		,
										@va_tip_vta		,
										@va_for_mat		)
												
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de items en tabla temporal',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_res001 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid,@va_und_inv,
									   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	END	
CLOSE vc_res001
DEALLOCATE vc_res001

SELECT * FROM #tm_res001

COMMIT TRAN TR_res001
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_res001
	RETURN
END CATCH	   

GO