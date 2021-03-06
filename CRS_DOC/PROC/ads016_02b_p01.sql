/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads016_02b_p01.sql
PROCEDIMIENTO: REGISTRA GESTION PERIODO por primera vez
	
AUTOR:	CREARSIS(CHL)
FECHA:	23-03-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_02b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_02b_p01
GO

CREATE PROCEDURE ads016_02b_p01
							@ag_ges_tio	INT			
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ges_tio		INT			,	-- Gestion
@va_ges_per		INT			,	-- Periodo de la gestion
@va_nom_per		VARCHAR(10)	,	-- Nombre de periodo
@va_fec_ini		DATE		,	-- Primer dia del mes
@va_fec_fin		DATE		,	-- Ultimo dia del mes
@va_ide_doc		CHAR(03)	,	-- Ide del docuento
@va_nro_tal		INT			,	-- Numero del talonario

@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ads016
BEGIN TRY   

	--Crea cursor de la gestion anterior a la que se esta creando
	DECLARE vc_ges_tio CURSOR LOCAL FOR
	SELECT va_ges_tio, va_ges_per, va_nom_per, va_fec_ini, va_fec_fin 
	FROM ads016
	WHERE va_ges_tio = @ag_ges_tio -1
	
	--** Abre cursor		  
	OPEN vc_ges_tio    
		 
	FETCH NEXT FROM vc_ges_tio INTO @va_ges_tio, @va_ges_per, @va_nom_per, @va_fec_ini , @va_fec_fin

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		--** incrementa un año a las fechas y gestion de los numeradores
		SET @va_fec_ini = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_ini),101) 
		SET @va_fec_fin = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_fin),101) 
		  
		INSERT INTO ads016 VALUES (@ag_ges_tio,@va_ges_per,@va_nom_per,@va_fec_ini,@va_fec_fin)
		
		-- Pasa al siguiente registro
		FETCH NEXT FROM vc_ges_tio INTO @va_ges_tio, @va_ges_per, @va_nom_per, @va_fec_ini , @va_fec_fin
	END	
	
	CLOSE vc_ges_tio
	DEALLOCATE vc_ges_tio
	
	--******************************************************************************************
	
	--Crea cursor con los Numeradores de la gestion anterior a la que se esta creando
	DECLARE vc_tal_num CURSOR LOCAL FOR
	SELECT va_ide_doc, va_nro_tal, va_ges_tio,va_fec_ini, va_fec_fin
	FROM ads005
	WHERE va_ges_tio = @ag_ges_tio -1
	ORDER BY va_ide_doc ,va_nro_tal asc
	
	--** Abre cursor		  
	OPEN vc_tal_num    
		 
	FETCH NEXT FROM vc_tal_num INTO @va_ide_doc, @va_nro_tal, @va_ges_tio,@va_fec_ini , @va_fec_fin

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		--** incrementa un año a las fechas y gestion de los numeradores
		SET @va_fec_ini = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_ini),101) 
		SET @va_fec_fin = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_fin),101) 
		  
		INSERT INTO ads005 VALUES (@va_ide_doc,@va_nro_tal,@ag_ges_tio,@va_fec_ini,@va_fec_fin,0,999999,0)
		
		-- Pasa al siguiente registro del numerador
		FETCH NEXT FROM vc_tal_num INTO @va_ide_doc, @va_nro_tal, @va_ges_tio,@va_fec_ini , @va_fec_fin
	END	
	
CLOSE vc_tal_num
DEALLOCATE vc_tal_num


	
COMMIT TRAN TR_ads016
RETURN
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads016
	RETURN
END CATCH	

GO