/*****************************************************************/
/*	ARCHIVO: adp006_01a_p01.sql                                  */
/*	PROCEDIMIENTO: OBTIENE LISTA DE IMAGENES P/PERSONA           */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 27/10/2021             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp006_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp006_01a_p01
GO

CREATE PROCEDURE adp006_01a_p01		@ar_cod_per  INT	--** Código de Persona
									WITH ENCRYPTION AS

DECLARE		@va_ide_tip	 CHAR(02),	   --** ID. Tipo de Imagen
			@va_nom_tip	 VARCHAR(20),  --** Nombre Tipo de Documento
			@va_ext_arc	 CHAR(05),	   --** Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)
			@va_tam_arc	 VARCHAR(10),  --** Tamaño del archivo
			@va_ima_per  CHAR(01)      --** Tiene Imagen Persona (S=Si; N=No)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_ima_per
(
	va_ide_tip	CHAR(02),
	va_nom_tip	VARCHAR(20),
	va_ext_arc	CHAR(05),
	va_tam_arc	VARCHAR(10),
	va_ima_per  CHAR(01)
)

--** Obtiene La lista de Tipo de Imagen
DECLARE vc_ima_per CURSOR LOCAL FOR
SELECT va_ide_tip, va_nom_tip
  FROM ads010
 WHERE va_est_ado = 'H'
   AND va_ide_tab = 'adp002'

--** Abre cursor
OPEN vc_ima_per

--** Lee primer registro
FETCH NEXT FROM vc_ima_per INTO @va_ide_tip, @va_nom_tip

WHILE (@@FETCH_STATUS = 0)
BEGIN	
    --** Verifica si la persona tiene registrado la imagen	
	SELECT @va_ext_arc = va_ext_arc,
	       @va_tam_arc = va_tam_arc
	  FROM adp006
	 WHERE va_cod_per = @ar_cod_per
	   AND va_ide_tip = @va_ide_tip

	IF (@@ROWCOUNT = 0)
	BEGIN
		SET @va_ima_per = 'N'
		SET @va_ext_arc = ''
		SET @va_tam_arc = 0.0
	END
	ELSE
		SET @va_ima_per = 'S'

	--** Graba la imagen por persona
	INSERT INTO #tm_ima_per VALUES (@va_ide_tip, @va_nom_tip, @va_ext_arc, @va_tam_arc, @va_ima_per)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_ima_per INTO @va_ide_tip, @va_nom_tip 
END

--** Cierre y destruya cursor
CLOSE vc_ima_per
DEALLOCATE vc_ima_per

--** Devuelve datos
SELECT va_ide_tip, va_nom_tip, va_ext_arc, 
       va_tam_arc, va_ima_per
  FROM #tm_ima_per


