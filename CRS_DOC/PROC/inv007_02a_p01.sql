/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv007_02a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO REGISTRA COMPRA
	(compra, suma existencia, kardex, 
	registra movimiento efectivo/CxC )
AUTOR:	CREARSIS(chl)
FECHA:	12-10-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_02a_p01
GO

CREATE PROCEDURE inv007_02a_p01 @ar_cod_usr NVARCHAR(15),	-- Usuario registro
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal  
							@ar_ide_doc	 NVARCHAR(03),	-- Codigo del documento
							@ar_nro_tal INT,			-- Numero del talonario												
							@ar_ges_tio INT,			-- GESTION 0=TODAS
							@ar_cod_bod INT,			-- bodega
							@ar_pro_vee INT,			-- codigo Proveedor
							@ar_mon_cmp CHAR(01),		-- Moneda de compra (B=Bs ; U=Us )
							@ar_fec_cmp DATE,			-- Fecha de compra
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_cod_caj INT,			-- Codigo de caja
							@ar_lin_cxp INT,			-- Linea Cta. x Pag (codigo de libro)
							@ar_tip_cmp INT,			-- Tipo de Compra [0=Sin Fac. ; 1=Con Fac.]
							@ar_ban_fac	INT,			-- Bandera Factura [0=NO  ; 1=SI hay  ; 2= Por Recuperar]
							@ar_lib_cpr	INT,			-- Libreta Credito Fiscal por Recuperar (en caso que va_ban_fac=2) (5 numeros)
							@ar_tip_cam	DECIMAL(7,5),	-- Tipo de cambio
							@ar_des_cue DECIMAL(10,2),	-- Descuento
							@ar_obs_cmp NVARCHAR(200),   -- Observacion
							@ar_ref_cmp NVARCHAR(20)	-- Referecia del documento
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_nro_doc		INT, 
@va_ide_cmp		VARCHAR(20),	--Identificador de la compra (XXX|000-00000/2018)
@va_nro_reg		INT,
@va_nro_tal		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 
@va_und_cmp		char(3),		-- UNIDAD DE MEDIDA DE COMPRA ****************************
@va_can_cmp		DECIMAL(14,4),	--Cantidad de producto
@va_can_uiv		DECIMAL(14,4),	--Cantidad inventario de producto
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario en la moneda del documento
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_tip_fam		CHAR(01),
@va_und_umd		CHAR(03),		-- UNIDAD DE MEDIDA DE INVENTARIO DEL PRODUCTO
@va_eqv_cmp		DECIMAL(7,3),
@va_nro_cmp		INT,
@va_raz_soc		NVARCHAR(60),
@va_tot_bBs		DECIMAL(16,2),
@va_tot_bUs		DECIMAL(16,2),
@va_des_cBs		DECIMAL(16,2),
@va_des_cUs		DECIMAL(16,2),
@va_tot_nBs		DECIMAL(16,2),
@va_tot_nUs		DECIMAL(16,2),
@va_pre_uBs		DECIMAL(16,2),
@va_pre_uUs		DECIMAL(16,2),
@va_pre_tBs		DECIMAL(16,2),
@va_pre_tUs		DECIMAL(16,2),

@va_cos_uoB		DECIMAL(16,2),		-- COSTO UNITARIO DE LA OPERACION Bs
@va_cos_uoU		DECIMAL(16,2),


@va_con_tad		INT,
@va_por_cen		DECIMAL(16,5),
@va_des_uni		DECIMAL(16,2),
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),

-- VARIABLES PARA CALCULO DE COSTOS
@va_sal_can		DECIMAL(14,2),
@va_cos_ubs		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Bs)
@va_cos_uus		DECIMAL(14,6),

@va_sal_acu		DECIMAL(14,2),	-- Saldo cantidad acumulada
@va_cos_taB		DECIMAL(14,6),	--Costo total acumulado (promedio ponderado en Bs)
@va_cos_taU		DECIMAL(14,6),	--Costo total acumulado (promedio ponderado en Us)

@va_cos_uaB		DECIMAL(14,6),	--Costo unitario actual (promedio ponderado en Bs)
@va_cos_uaU		DECIMAL(14,6),	--Costo unitario actual (promedio ponderado en Us)
@va_nro_cmp_tmp	INT


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_INV007(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_und_cmp		char(3)			null,		--Codigo de la Unidad de Medida
	va_can_cmp		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
   )
   
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_INV007
BEGIN TRY   
  
   -- Carga temporal de compra
   INSERT INTO #tm_INV007
	SELECT * FROM inv007tmp
	WHERE va_cod_tmp = @ar_cod_tmp
	
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('No hay ningun item para la compra',16,1)
		RETURN
	END

	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @ar_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado
	 FROM ads004
	WHERE va_ide_doc = @ar_ide_doc AND 
		  va_nro_tal = @ar_nro_tal
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	--// Verifica la Gestion
	SELECT @va_nro_reg = COUNT(*)
	FROM ads016
	WHERE va_ges_tio = @ar_ges_tio
	IF(@va_nro_reg = 0)
	BEGIN
		RAISERROR ('La gestion no se encuentra definida',16,1)
		RETURN
	END
	
--// Verifica Numeracion
	SELECT @va_nro_cmp = va_con_tad
	FROM ads005
	WHERE va_ide_doc = @ar_ide_doc AND 
		  va_nro_tal = @ar_nro_tal AND
		  va_ges_tio = @ar_ges_tio
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario NO dispone de numeracion',16,1)
		RETURN
	END
	
	--// Verifica bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El bodega no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El bodega se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	--// Verifica Proveedor
	
	SELECT @va_est_ado = va_est_ado,
		   @va_raz_soc = va_raz_soc
	FROM cmr013
	WHERE va_cod_per = @ar_pro_vee
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Proveedor no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Proveedor se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Caja si es al contado
	--IF @ar_for_pag = 0
	--BEGIN
		--SELECT @va_est_ado = va_est_ado
		--FROM tes001
		--WHERE va_cod_cjb = @ar_cod_caj
		--IF @@ROWCOUNT = 0
		--BEGIN
		--	RAISERROR ('La Caja no se encuentra registrada',16,1)
		--	RETURN
		--END
		--IF @va_est_ado = 'N'
		--BEGIN
		--	RAISERROR ('La Caja se encuentra Deshabilitada',16,1)
		--	RETURN
		--END
	--END
	
	----// Verifica Linea de credito si es al credito
	--IF @ar_for_pag = 1
	--BEGIN
	--	SELECT @va_est_ado = va_est_ado
	--	FROM ecp007
	--	WHERE va_cod_per = @ar_pro_vee AND
	--		  va_cod_lib = @ar_lin_cxp
	--	IF @@ROWCOUNT = 0
	--	BEGIN
	--		RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
	--		RETURN
	--	END
	--	IF @va_est_ado = 'N'
	--	BEGIN
	--		RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
	--		RETURN
	--	END
	--END
	
	
	----// Verifica Credito Fis x Recuperar 
	--IF (@ar_tip_cmp = 1 and @ar_ban_fac = 2)
	--BEGIN
	--	SELECT @va_est_ado = va_est_ado
	--	FROM ecp007
	--	WHERE va_cod_per = @ar_pro_vee AND
	--		  va_cod_lib = @ar_lib_cpr
	--	IF @@ROWCOUNT = 0
	--	BEGIN
	--		RAISERROR ('La persona no tiene la libreta de Cred. Fis. x Recuperar espesificada',16,1)
	--		RETURN
	--	END
	--	IF @va_est_ado = 'N'
	--	BEGIN
	--		RAISERROR ('La persona no tiene habilitada la libreta de Cred. Fis. x Recuperar espesificada',16,1)
	--		RETURN
	--	END
	--END
	
	--Suma en uno el contador de compra
	SET @va_nro_cmp = @va_nro_cmp + 1
	
	
	SET @va_nro_tal = 1000 + @ar_nro_tal
	SET @va_nro_cmp_tmp = 1000000 + @va_nro_cmp
	
	--Prepara identificador de la compra
	SET @va_ide_cmp = @ar_ide_doc + '-' + SUBSTRING(CAST (@va_nro_tal AS VARCHAR(4)),2,3) + '-' + SUBSTRING(CAST(@va_nro_cmp_tmp AS VARCHAR(7)),2,7)
	
	
	
	
	
	
	IF @ar_mon_cmp ='B'
	BEGIN
		SELECT @va_tot_bBs = SUM(va_imp_tot) 
		FROM #tm_inv007
		
		SET @va_tot_bUs = @va_tot_bBs / @ar_tip_cam
		
		SET @va_des_cBs = @ar_des_cue
		SET @va_des_cUs = @ar_des_cue / @ar_tip_cam
		
		SET @va_tot_nBs = @va_tot_bBs - @va_des_cBs
		SET @va_tot_nUs = @va_tot_nBs / @ar_tip_cam
	END
	ELSE
	BEGIN
		SELECT @va_tot_bUs = SUM(va_imp_tot) 
		FROM #tm_INV007
		
		SET @va_tot_bBs = @va_tot_bUs * @ar_tip_cam
		
		SET @va_des_cUs = @ar_des_cue
		SET @va_des_cBs = @va_des_cUs * @ar_tip_cam
		
		SET @va_tot_nUs = @va_tot_bUs - @va_des_cUs
		SET @va_tot_nBs = @va_tot_nUs * @ar_tip_cam
	END
	
		
	-- REGISTRA ENCABEZADO COMPRA
	INSERT INTO INV007 VALUES(@ar_ide_doc, @ar_nro_tal, @va_nro_cmp, @ar_ges_tio, @va_ide_cmp, @ar_pro_vee,
							  @va_raz_soc,@ar_fec_cmp, @ar_tip_cam,@ar_mon_cmp,@ar_for_pag,@ar_cod_caj,@ar_lin_cxp,@ar_ref_cmp,
							  @ar_cod_bod,@ar_tip_cmp,@ar_ban_fac,@ar_lib_cpr, GETDATE(), 
							  @va_tot_bBs,@va_tot_bUs, @va_des_cBs, @va_des_cUs, @va_tot_nBs,@va_tot_nUs, @ar_obs_cmp, 
							  0,0,'',0,'',0,0,0,0,0,0,0,@ar_cod_usr, GETDATE(),'','01/01/1900','01/01/1900', 'V' )
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Ocurrio un error al ingresar el encabezado de compra',16,1)
		RETURN
	END
		
	
--// Cursor sobre temporal
DECLARE vc_det_cmp CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_und_cmp,va_can_cmp,va_pre_uni,va_imp_tot,va_tip_fam
FROM #tm_INV007	
	
--** Abre cursor		  
OPEN vc_det_cmp    
	 
SET @va_con_tad = 0

FETCH NEXT FROM vc_det_cmp 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_und_cmp,@va_can_cmp,@va_pre_uni,@va_imp_tot,@va_tip_fam

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_eqv_cmp = va_eqv_cmp
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	-- CANTIDADES SEGUN UNIDADES DE MEDIDA
	--	si la unidad de compra es igual a la unidad de medida
	IF (@va_und_cmp = @va_und_umd ) 
	BEGIN
		SET @va_can_uiv = @va_can_cmp
	END
	ELSE
	BEGIN
		SET @va_can_uiv = @va_can_cmp * @va_eqv_cmp
	END
	
	-- Calcula Precios unitarios
	IF @ar_mon_cmp = 'B' 
	BEGIN
		IF (@va_und_cmp = @va_und_umd )
		BEGIN
			SET @va_pre_uBs = @va_pre_uni
			SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
		END
		IF (@va_und_cmp <> @va_und_umd  )
		BEGIN
			SET @va_pre_uni = @va_pre_uni / @va_eqv_cmp
			SET @va_pre_uBs = @va_pre_uni
			SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
		END
	END
	
	IF @ar_mon_cmp = 'U' 
	BEGIN
		IF (@va_und_cmp = @va_und_umd )
		BEGIN
			SET @va_pre_uUs = @va_pre_uni
			SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
		END
		IF (@va_und_cmp <> @va_und_umd )
		BEGIN
			SET @va_pre_uni = @va_pre_uni / @va_eqv_cmp
			SET @va_pre_uUs = @va_pre_uni
			SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
		END
	END
	
	
	
	-- Calcula Precios Totales 
	IF @ar_mon_cmp = 'B'
	BEGIN
		SET @va_pre_tBs = @va_imp_tot
		SET @va_pre_tUs = @va_imp_tot / @ar_tip_cam
	END
	IF @ar_mon_cmp = 'U'
	BEGIN
		SET @va_pre_tUs = @va_imp_tot
		SET @va_pre_tBs = @va_imp_tot * @ar_tip_cam
	END
	
	-- PRORATEA DESCUENTOS POR ITEM EN MONEDA DEL DOCUMENTO
	IF @ar_mon_cmp ='B'
		SET @va_por_cen = (@va_imp_tot * 100) / @va_tot_bBs
	ELSE
		SET @va_por_cen = (@va_imp_tot * 100) / @va_tot_bUs
	
	
	SET @va_des_uni = (@va_por_cen * @ar_des_cue) / 100
	SET @va_des_acu = @va_des_acu + @va_des_uni
	
	IF @@CURSOR_ROWS = @va_con_tad
	BEGIN
		IF @va_des_acu <> @ar_des_cue
			SET @va_des_uni = @va_des_uni + (@ar_des_cue - @va_des_acu)
	END
	
	-- OBTIENE DESCUENTOS UNITARIOS EN BS Y US PARA CALCULOS
	IF @ar_mon_cmp ='B'
	BEGIN
		SET @va_des_unB = @va_des_uni
		SET @va_des_unU = @va_des_uni / @ar_tip_cam
	END
	ELSE
	BEGIN
		SET @va_des_unU = @va_des_uni
		SET @va_des_unB = @va_des_uni * @ar_tip_cam
	END
	
	-- REGISTRA DETALLE DE COMPRA
	INSERT INTO inv008 VALUES(@ar_ide_doc, @ar_nro_tal, @va_nro_cmp, @ar_ges_tio, @va_ide_cmp, @va_nro_itm,
							  @va_cod_pro,@va_des_pro, 0,@va_und_umd,@va_und_cmp,@va_can_uiv,@va_can_cmp,
							  @va_pre_uBs,@va_pre_uUs,@va_pre_tBs,@va_pre_tUs, @va_des_uni,'','' )
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al ingresar item del detalle',16,1)
		RETURN
	END
	  --//OBTIENE COSTO UNITARIO NETO DE LA COMPRA SIN IVA (en unidad de inventario)
	SET @va_cos_uoB = (@va_pre_tBs - @va_des_unB) / @va_can_uiv
	SET @va_cos_uoU = (@va_pre_tUs - @va_des_unU) / @va_can_uiv
	
	
	
	--IF (@va_und_cmp <> @va_und_umd)
	--BEGIN
	--	SET @va_cos_uoB = @va_cos_uoB / @va_eqv_cmp
	--	SET @va_cos_uoU = @va_cos_uoU / @va_eqv_cmp
	--END
	
--print @va_cos_uoB
--	print @va_cos_uoU
--	print @va_eqv_cmp
--	print '----------------------'
--	print '   '

	--// CALCULO DE COSTO DEL PRODUCTO
		--Obtiene cantidad y costo actual 
		SELECT @va_sal_can = va_sal_can,
			   @va_cos_ubs = va_cos_ubs,
			   @va_cos_uus = va_cos_uus
		  FROM inv099
		 WHERE va_cod_pro = @va_cod_pro	AND
			   va_cod_bod = @ar_cod_bod
			   
		IF @@ROWCOUNT = 0
		BEGIN
			INSERT INTO inv099 VALUES (@ar_cod_bod, @va_cod_pro, 0, 0, 0)
		
			SET @va_sal_can = 0
			SET @va_cos_ubs = 0
			SET @va_cos_uus = 0
		END
		
		
		-- costo total actual (no incluye esta compra)
		SET @va_cos_taB = @va_cos_ubs * @va_sal_can
		SET @va_cos_taU = @va_cos_uus * @va_sal_can
		
		-- cantidad stock actualizado (incluye esta compra)  [Saldo actual + cantidad unidad inventario de compra]
		SET @va_sal_acu = @va_sal_can + @va_can_uiv
		
		IF @ar_tip_cmp = 1	-- SIN FACTURA costea sobre el 100%
		BEGIN
			-- costo total actualizado (incluye esta compra)
			SET @va_cos_taB = @va_cos_taB + (@va_pre_tBs - @va_des_cBs)
			SET @va_cos_taU = @va_cos_taU + (@va_pre_tUs - @va_des_cUs)
		END
		
		
			
		IF (@ar_tip_cmp = 0) OR (@ar_tip_cmp = 2)  	-- CON FACTURA
		BEGIN
		
			IF @ar_ban_fac = 0	--no hay factura, costea sobre el  100%
			BEGIN
				-- costo total actualizado (incluye esta compra)
				SET @va_cos_taB = @va_cos_taB + (@va_pre_tBs - @va_des_cBs)
				SET @va_cos_taU = @va_cos_taU + (@va_pre_tUs - @va_des_cUs)
			END
			IF @ar_ban_fac <> 0	-- si hay/x recuperar, costea sobre el 87%
			BEGIN
				-- costo total actualizado (incluye esta compra)
				SET @va_cos_taB = @va_cos_taB + ((@va_pre_tBs - @va_des_unB) * 0.87)
				SET @va_cos_taU = @va_cos_taU + ((@va_pre_tUs - @va_des_unU) * 0.87)
				
				--Costo unitario de la operacion CON IVA
				SET @va_cos_uoB = (@va_cos_uoB * 0.87)
				SET @va_cos_uoU = (@va_cos_uoU * 0.87)
			END
		END	
		
		-- calcula costo unitario PROMEDIADO actualizado (incluye esta compra)
		SET @va_cos_uaB = @va_cos_taB / @va_sal_acu
		SET @va_cos_uaU = @va_cos_taU / @va_sal_acu
		
		--IF @va_und_umd <> @va_und_cmp
		--BEGIN
		--	SET @va_cos_uaB = @va_cos_uaB / @va_eqv_cmp
		--	SET @va_cos_uaU = @va_cos_uaU / @va_eqv_cmp
		--END
		
	--//ACTUALIZA EXISTENCIA
	 UPDATE inv099 -- ... @va_sal_acu
	    SET va_sal_can= va_sal_can + @va_can_uiv , va_cos_ubs = @va_cos_uaB , va_cos_uus = @va_cos_uaU
	  WHERE va_cod_bod = @ar_cod_bod AND va_cod_pro = @va_cod_pro
  	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al actualizar saldos de stock',16,1)
		RETURN
	END
	  
	--//REGISTRA KARDEX
	INSERT INTO inv100 VALUES (@ar_ges_tio,@ar_ide_doc,@ar_nro_tal,@va_nro_cmp,@va_ide_cmp, @va_nro_itm,
							   @ar_fec_cmp, GETDATE(), @ar_ref_cmp, @ar_mon_cmp,@ar_obs_cmp, @va_cod_pro,
							   @va_can_uiv,0,@va_cos_uoB,@va_cos_uoU,(@va_cos_uoB * @va_can_uiv),(@va_cos_uoU * @va_can_uiv), 
							   @va_cos_uaB,@va_cos_uaU, @ar_cod_bod, 'Lote: ', @ar_tip_cam, @ar_cod_usr)
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al registrar el kardex',16,1)
		RETURN
   END
   
 
	FETCH NEXT FROM vc_det_cmp 
	INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_und_cmp,@va_can_cmp,@va_pre_uni,@va_imp_tot,@va_tip_fam
END

--// ACTUALIZA CONTADOR
UPDATE ads005 SET va_con_tad = @va_nro_cmp
WHERE va_ide_doc = @ar_ide_doc AND 
	  va_nro_tal = @ar_nro_tal AND
	  va_ges_tio = @ar_ges_tio

CLOSE vc_det_cmp
DEALLOCATE vc_det_cmp

-- Borra temporal
DELETE INV007tmp
WHERE va_cod_tmp = @ar_cod_tmp AND
	  va_cod_usr = @ar_cod_usr
	  
	  
select * from  INV007
WHERE va_doc_doc = @ar_ide_doc	AND
	  va_nro_tal = @ar_nro_tal	AND
	  va_nro_cmp = @va_nro_cmp	AND
	  va_ges_cmp = @ar_ges_tio 
	
	COMMIT TRAN TR_INV007
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_INV007
	RETURN
END CATCH	

GO