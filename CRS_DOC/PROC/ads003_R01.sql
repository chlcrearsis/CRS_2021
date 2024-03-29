/*****************************************************************/
/*	ARCHIVO: ads003_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME DEFINICIÓN DE DOCUMENTOS              */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_mod_ini  INT       Módulo Inicial          */
/*                @ar_mod_fin  INT       Módulo Final            */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/08/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_R01
GO

CREATE PROCEDURE ads003_R01		@ar_est_ado  CHAR(01),
                                @ar_mod_ini  INT,
								@ar_mod_fin  INT WITH ENCRYPTION AS

DECLARE		@va_ide_mod	 INT,			--** ID. Módulo
            @va_nom_mod  VARCHAR(30),	--** Nombre Módulo
			@va_ide_doc  CHAR(03),	    --** ID. Documento
			@va_nom_doc  VARCHAR(30),	--** Nombre Documento
			@va_des_doc  VARCHAR(120),	--** Nombre Documento
			@va_est_doc  CHAR(01), 	    --** Estado (H=Habilitado; N=Deshabilitado)
			@va_est_ado  VARCHAR(15)    --** Estado (Habilitado; Deshabilitado)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_doc_int
(
	va_ide_mod	INT,
	va_nom_mod  VARCHAR(30),
    va_ide_doc  CHAR(03),
	va_nom_doc  VARCHAR(30),
	va_des_doc  VARCHAR(120),
	va_est_ado  VARCHAR(15)
)

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene los datos de las aplicaciones del sistema
DECLARE vc_apl_sis CURSOR LOCAL FOR
 SELECT va_ide_mod, va_ide_doc, va_nom_doc,
        va_des_doc, va_est_ado
   FROM ads003
  WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
    AND va_ide_mod >= @ar_mod_ini
	AND va_ide_mod <= @ar_mod_fin

--** Abre Cursor
OPEN vc_apl_sis
--** Lee el primer registro
FETCH NEXT FROM vc_apl_sis INTO @va_ide_mod, @va_ide_doc, @va_nom_doc, @va_des_doc, @va_est_doc
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene nombre del tipo de atributo
	SET @va_nom_mod = ''
	SELECT @va_nom_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @va_ide_mod
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_mod = ''

	SET @va_est_ado = ''
	IF (@va_est_doc = 'H')
		SET @va_est_ado = 'Habilitado'
	IF (@va_est_doc = 'N')
		SET @va_est_ado = 'Deshabilitado'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_doc_int VALUES (@va_ide_mod, @va_nom_mod, @va_ide_doc, 
	                                @va_nom_doc, @va_des_doc, @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_apl_sis INTO @va_ide_mod, @va_ide_doc, @va_nom_doc, @va_des_doc, @va_est_doc
END	

CLOSE vc_apl_sis
DEALLOCATE vc_apl_sis


--** Retorna los datos
SELECT va_ide_mod, va_nom_mod, va_ide_doc, 
	   va_nom_doc, va_des_doc, va_est_ado
  FROM #tm_doc_int
