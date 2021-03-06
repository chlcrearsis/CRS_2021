/*****************************************************************/
/*	ARCHIVO: adp008_01a_p01.sql                                  */
/*	PROCEDIMIENTO: OBTIENE RUTEO P/PERSONA                       */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 21/10/2021             */
/*   NOTA: En caso de error devuelve del 101 as 118              */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp008_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp008_01a_p01
GO

CREATE PROCEDURE adp008_01a_p01		@ar_cod_per  INT	--** Código de Persona
									WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		   --** Nro de Registro
            @va_ide_rut	 INT,  		   --** ID. Ruta
			@va_nom_rut	 VARCHAR(30),  --** Nombre de la ruta
			@va_nom_cor	 VARCHAR(15),  --** Nombre corto
			@va_per_mis  CHAR(01)      --** Permiso (S=Si; N=No)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_rut_per
(
	va_ide_rut	INT,
	va_nom_rut	VARCHAR(30),
	va_nom_cor	VARCHAR(15),
	va_per_mis  CHAR(01)
)

--** Obtiene La lista de Rutas
DECLARE vc_rut_per CURSOR LOCAL FOR
SELECT va_ide_rut, va_nom_rut, va_nom_cor 
  FROM adp007
 WHERE va_est_ado = 'H'

--** Abre cursor
OPEN vc_rut_per

--** Lee primer registro
FETCH NEXT FROM vc_rut_per INTO @va_ide_rut, @va_nom_rut, @va_nom_cor  

WHILE (@@FETCH_STATUS = 0)
BEGIN	
    --** Verifica si el usuario tiene habilitado al vendedor
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT (*)
	  FROM adp008
	 WHERE va_cod_per = @ar_cod_per
	   AND va_ide_rut = @va_ide_rut

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'


	--** Graba el atributo de persona
	INSERT INTO #tm_rut_per VALUES (@va_ide_rut, @va_nom_rut, @va_nom_cor, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_rut_per INTO @va_ide_rut, @va_nom_rut, @va_nom_cor   
END

--** Cierre y destruya cursor
CLOSE vc_rut_per
DEALLOCATE vc_rut_per

--** Devuelve datos
SELECT va_ide_rut, va_nom_rut, va_nom_cor, va_per_mis 
  FROM #tm_rut_per


