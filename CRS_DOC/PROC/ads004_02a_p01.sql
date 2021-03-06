/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads004_02a_p01.sql
PROCEDIMIENTO: REGISTRA TALONARIO Y NUMERACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	17-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_02a_p01
GO

CREATE PROCEDURE ads004_02a_p01
							@ar_ges_tio	INT			,	-- Gestion año
							@ar_anu_mes	INT			,	-- (0=Anual ; 1=Mensual)
							@ar_ide_doc	CHAR(03)	,	-- Ide Documento
							@ar_nro_tal	INT			,	-- Nro talonario
							@ar_nom_tal	VARCHAR(60)	,	-- Nombre del talonario
							@ar_tip_tal	INT			,	-- Correlativo (0=Manual ; 1=Automatico)
							@ar_nro_aut	BIGINT		,	-- Nro de autorizacion/Dosificacion de facturas
							@ar_for_mat	INT			,	-- Nro de formato para impresión del documento
							@ar_nro_cop	INT			,	-- Nro de copias por defecto que imprimira
							@ar_fir_ma1	VARCHAR(15)	,	-- Firma 1 para el documento
							@ar_fir_ma2	VARCHAR(15)	,	-- Firma 2 para el documento
							@ar_fir_ma3	VARCHAR(15)	,	-- Firma 3 para el documento
							@ar_fir_ma4	VARCHAR(15)	,	-- Firma 4 para el documento
							@ar_for_log	INT				/* Formato de logo que se imprimira	
															0=Razon social de empresa; 
															1=Logotipo1
															2=Logotipo2 
															3=Logotipo3	*/
							
							
							
						
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar

@va_ges_tio		INT			,	-- Gestion
@va_mes_per		INT			,	-- Mes periodo
@va_nom_per		VARCHAR(10)	,	-- Nombre de periodo
@va_pri_dia		DATE		,	-- Primer dia del mes
@va_ult_dia		DATE		,	-- Ultimo dia del mes
@va_ide_doc		CHAR(03)	,	-- Ide del docuento
@va_nro_tal		INT			,	-- Numero del talonario
@va_nom_tal		VARCHAR(60)	,	-- Nombre del talonario
@va_con_tad		INT			,	-- Contador de periodos

@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ads005
BEGIN TRY   
	
	CREATE TABLE #MES
	(
		va_ide_mes		INT,
		va_nom_mes		VARCHAR(10)
	)
	INSERT INTO #MES VALUES (1,'Enero')
	INSERT INTO #MES VALUES (2,'Febrero')
	INSERT INTO #MES VALUES (3,'Marzo')
	INSERT INTO #MES VALUES (4,'Abril')
	INSERT INTO #MES VALUES (5,'Mayo')
	INSERT INTO #MES VALUES (6,'Junio')
	INSERT INTO #MES VALUES (7,'Julio')
	INSERT INTO #MES VALUES (8,'Agosto')
	INSERT INTO #MES VALUES (9,'Septiembre')
	INSERT INTO #MES VALUES (10,'Octubre')
	INSERT INTO #MES VALUES (11,'Noviembre')
	INSERT INTO #MES VALUES (12,'Diciembre')
	

	SET @va_ges_tio = @ar_ges_tio
	SET @va_ide_doc = @ar_ide_doc
	SET @va_nro_tal = @ar_nro_tal
	
	
	--/ Verifica que la Gestión se encuentre creada
	SET @cout = 0
	SELECT @cout = COUNT(*)
	  FROM ads016
	 WHERE va_ges_tio = @ar_ges_tio
	 
	 IF(@cout = 0)
	 BEGIN
		--SET @msg = 'La Gestión proporsionada no se encuentra registrada. ' +  CONVERT(NVARCHAR(255), @cout)  
		--		 + ' Argumento gestion = ' + CONVERT(NVARCHAR(255),@ar_ges_tio)
		RAISERROR ('La Gestión proporsionada no se encuentra registrada. ',16,1)
		ROLLBACK TRAN TR_ads005
		RETURN
	 END
	
	--/ Obtiene mes inicial de la gestion
	SELECT @va_mes_per = va_ges_per 
	FROM ads016
	WHERE va_ges_tio = @ar_ges_tio
	ORDER BY va_ges_per DESC
	
	--/ En caso de ser Talonario Anual
	IF(@ar_anu_mes = 0)
	BEGIN
		--/ Créa Talonario Anual
		INSERT INTO ads004 VALUES	(@va_ide_doc, @va_nro_tal, @ar_nom_tal, @ar_tip_tal, @ar_nro_aut,
									@ar_for_mat, @ar_nro_cop, @ar_fir_ma1, @ar_fir_ma2, @ar_fir_ma3,
									@ar_fir_ma4, @ar_for_log, 'H')
		
		--/ Obtiene primer y ultimo dia de la Gestión
		SELECT @va_pri_dia = MIN(va_fec_ini) , 
			   @va_ult_dia = MAX(va_fec_fin)  
		  FROM ads016
		 WHERE va_ges_tio = @ar_ges_tio
		 
		--/ Créa Numeración Anual			  
		INSERT INTO ads005 VALUES (@va_ide_doc, @va_nro_tal, @ar_ges_tio, @va_pri_dia,@va_ult_dia, 0, 999999,0)
		
	
	END
	
	--/ En caso de ser Talonario Mensual, segun Gestión
	IF(@ar_anu_mes = 1)
	BEGIN
		SET @va_con_tad = 1
	
		WHILE (@va_con_tad <= 12)
		BEGIN
			
			--/ Obtiene datos del periodo
			SELECT @va_nom_per = va_nom_per,
				   @va_pri_dia = va_fec_ini,
				   @va_ult_dia = va_fec_fin
			  FROM ads016
			 WHERE va_ges_tio = @ar_ges_tio
			   AND va_ges_per = @va_con_tad
			
			--/ Compone nombre de talonario + nombre del mes correspondiente
			SET @va_nom_tal = @ar_nom_tal + ' - ' + @va_nom_per
			
			--/ Verifica que el Talonario a crear en el mes, aun no este creado
			SELECT *
			  FROM ads004
			 WHERE va_ide_doc = @va_ide_doc
			   AND va_nro_tal = @va_nro_tal
			IF @@ROWCOUNT <> 0
			BEGIN
				SET @msg = 'No se puede crear un Talonario duplicado, el talonario: ' +  CONVERT(NVARCHAR(255),@va_nro_tal) 
						 + ' para el Documento ' + @va_ide_doc + ' ya se encuentra registrado'
				
				RAISERROR (@msg ,16,1)
				Rollback TRAN TR_ads005
				RETURN
			END
			
			--/ Créa Talonario por Mes
			INSERT INTO ads004 VALUES (@va_ide_doc, @va_nro_tal, @va_nom_tal, @ar_tip_tal, @ar_nro_aut,
									   @ar_for_mat, @ar_nro_cop, @ar_fir_ma1, @ar_fir_ma2, @ar_fir_ma3,
									   @ar_fir_ma4, @ar_for_log, 'H')
									   
			--/ Créa Numeración por Mes
			INSERT INTO ads005 VALUES (@va_ide_doc, @va_nro_tal, @ar_ges_tio, @va_pri_dia,@va_ult_dia, 0, 999999,0)
			
			--/ Incrementa contadores
			SET @va_con_tad = @va_con_tad + 1
			SET @va_nro_tal = @va_nro_tal + 1
			
		END
	
	
	END
	

	
COMMIT TRAN TR_ads005
RETURN
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads005
	RETURN
END CATCH	

GO