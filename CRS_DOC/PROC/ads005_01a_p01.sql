/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads005_01a_p01.sql
PROCEDIMIENTO: BUSCA NUMERACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	28-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads005_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads005_01a_p01
GO

CREATE PROCEDURE ads005_01a_p01		@ar_ide_mod		INT,			-- Ide del modulo
									@ar_ges_tio		INT,			-- Gestion
									@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT				-- Criterio (0 = ide doc , 1=Nombre Doc, 2=Nombre Talonario)
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
@va_con_tad		INT

CREATE TABLE #resultado
(
va_ide_doc		CHAR(03),
va_nom_doc		VARCHAR(30),
va_nro_tal		INT,
va_nom_tal		VARCHAR(60),
va_ges_tio		INT,
va_con_tad		INT
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
-- Crea cursor para busqueda
--Set @comando = ''
--Set @comando = 'CREATE vc_num_era CURSOR LOCAL FOR 
-- SELECT *'
DECLARE vc_num_era CURSOR LOCAL FOR
SELECT ads003.va_ide_doc, ads003.va_nom_doc, ads005.va_nro_tal, ads005.va_ges_tio, ads005.va_con_tad
FROM ads005, ads003
WHERE (ads003.va_ide_doc = ads005.va_ide_doc)
  AND (ads003.va_ide_mod = @ar_ide_mod)
  AND (ads005.va_ges_tio = @ar_ges_tio)
  
OPEN vc_num_era
FETCH NEXT FROM vc_num_era INTO @va_ide_doc, @va_nom_doc,@va_nro_tal,@va_ges_tio,@va_con_tad



WHILE (@@FETCH_STATUS = 0)
BEGIN
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
									@va_con_tad		
									)
	FETCH NEXT FROM vc_num_era INTO @va_ide_doc, @va_nom_doc,@va_nro_tal,@va_ges_tio,@va_con_tad
END	

CLOSE vc_num_era
DEALLOCATE vc_num_era

IF(@ar_cri_bus = 0)	
BEGIN
	SELECT * 
	FROM #resultado
	WHERE va_ide_doc LIKE @ar_tex_bus + '%'
END

IF(@ar_cri_bus = 1)	
BEGIN
	SELECT * 
	FROM #resultado
	WHERE va_nom_doc LIKE @ar_tex_bus + '%'
END

IF(@ar_cri_bus = 2)	
BEGIN
	SELECT * 
	FROM #resultado
	WHERE va_nom_tal LIKE @ar_tex_bus + '%'
END


RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


