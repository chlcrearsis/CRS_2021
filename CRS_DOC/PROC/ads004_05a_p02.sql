/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads004_05a_p02.sql
PROCEDIMIENTO: CONSULTA TALONARIO CON PERMISOS DE USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_05a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_05a_p02
GO

CREATE PROCEDURE ads004_05a_p02		@ar_ide_doc		CHAR(03),	-- Texto a ser buscado
									@ar_nro_tal		INT		-- ID del documento
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar

@va_ide_doc		CHAR(03),
@va_nom_doc		NVARCHAR(30),
@va_nro_tal		INT,
@va_nom_tal		NVARCHAR(60),
@va_est_ado		CHAR(01)

CREATE TABLE #resultado
(
va_ide_doc		CHAR(03),
va_nom_doc		NVARCHAR(30),
va_nro_tal		INT,
va_nom_tal		NVARCHAR(60),
va_est_ado		CHAR(01)
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

   DECLARE vc_tal_ona CURSOR LOCAL FOR
	SELECT va_ide_doc, va_nro_tal, va_nom_tal,va_est_ado
	  FROM ads004
	 WHERE va_nro_tal = @ar_nro_tal	AND
		   va_ide_doc = @ar_ide_doc	AND
		   va_est_ado = 'T'
		   
OPEN vc_tal_ona
FETCH NEXT FROM vc_tal_ona INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN

	-- Verifica que usuario tenga permiso sobre el talonario
	SELECT @cout = COUNT(*)
	  FROM ads008
	 WHERE	va_ide_usr = SYSTEM_USER	AND
			va_ide_tab = 'ads004'		AND
			va_ide_uno = @va_ide_doc	AND
			va_ide_dos = @va_nro_tal
	IF @cout <> 0
	BEGIN 
	
	-- Obtiene nombre del documento
	SELECT @va_nom_doc = va_nom_doc
	  FROM ads003
	 WHERE va_ide_doc = @va_ide_doc
	 
	 INSERT INTO #resultado VALUES (@va_ide_doc		,
									@va_nom_doc		,
									@va_nro_tal		,
									@va_nom_tal		,
									@va_est_ado	
									)
	END
	
	FETCH NEXT FROM vc_tal_ona INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_est_ado
END	

SELECT * FROM #resultado

CLOSE vc_tal_ona
DEALLOCATE vc_tal_ona
	
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	   

GO