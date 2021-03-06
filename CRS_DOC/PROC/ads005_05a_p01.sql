/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads005_05a_p01.sql
PROCEDIMIENTO: CONSULTA NUMERACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	28-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads005_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads005_05a_p01
GO

CREATE PROCEDURE ads005_05a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT,		
								@ar_ges_tio		INT
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@comando		NVARCHAR(200),
@va_ide_doc		CHAR(03),
@va_nom_doc		VARCHAR(60),
@va_nro_tal		INT,
@va_nom_tal		VARCHAR(60),
@va_ges_tio		INT,
@va_fec_ini		DATETIME,
@va_fec_fin		DATETIME,
@va_nro_ini		INT,
@va_nro_fin		INT,
@va_con_tad		INT


CREATE TABLE #resultado
(
va_ide_doc		CHAR(03),
va_nom_doc		VARCHAR(30),
va_nro_tal		INT,
va_nom_tal		VARCHAR(60),
va_ges_tio		INT,
va_fec_ini		DATETIME,
va_fec_fin		DATETIME,
va_nro_ini		INT,
va_nro_fin		INT,
va_con_tad		INT
)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

	SELECT  @va_ide_doc=ads003.va_ide_doc, 
			@va_nom_doc=ads003.va_nom_doc, 
			@va_nro_tal=ads005.va_nro_tal, 
			@va_ges_tio=ads005.va_ges_tio,
			@va_fec_ini=ads005.va_fec_ini,
			@va_fec_fin=ads005.va_fec_fin,
			@va_nro_ini=ads005.va_nro_ini,
			@va_nro_fin=ads005.va_nro_fin,
			@va_con_tad=ads005.va_con_tad
	FROM ads005, ads003
	WHERE (ads003.va_ide_doc = ads005.va_ide_doc)
	  AND (ads005.va_ges_tio = @ar_ges_tio)
	  AND (ads005.va_ide_doc = @ar_ide_doc)
	  AND (ads005.va_nro_tal = @ar_nro_tal)
	  
	-- Obtiene nombre del Taolonario
	SELECT @va_nom_tal = va_nom_tal
	  FROM ads004
	 WHERE va_ide_doc = @va_ide_doc
	   AND va_nro_tal = @va_nro_tal
	 
	 INSERT INTO #resultado VALUES (@va_ide_doc		,
									@va_nom_doc		,
									@va_nro_tal		,
									@va_nom_tal		,
									@va_ges_tio		,
									@va_fec_ini		,
									@va_fec_fin		,
									@va_nro_ini		,
									@va_nro_fin		,
									@va_con_tad		
									)
	
	SELECT * FROM #resultado

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO