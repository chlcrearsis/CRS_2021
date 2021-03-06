/*****************************************************************/
/*	ARCHIVO: adp007_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME DEFINICIÓN DE RUTAS                   */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 13/07/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp007_R01') and sysstat & 0xf = 4)
	drop procedure dbo.adp007_R01
GO

CREATE PROCEDURE adp007_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

DECLARE		@va_ide_rut	 INT,			--** ID. Ruta
            @va_nom_rut  VARCHAR(30),	--** Nombre Ruta
			@va_nom_cor  VARCHAR(30),	--** Nombre Corto
			@va_est_rut  CHAR(01), 	    --** Estado (H=Habilitado; N=Deshabilitado)
			@va_est_ado  VARCHAR(15)    --** Estado (Habilitado; Deshabilitado)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Crea la tabla temporal
CREATE TABLE #tm_def_rut
(
	va_ide_rut	INT,
    va_nom_rut  VARCHAR(30),
	va_nom_cor  VARCHAR(15),
	va_est_ado  VARCHAR(15)
)

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene los datos del tipo de atributo
DECLARE vc_def_rut CURSOR LOCAL FOR
 SELECT va_ide_rut, va_nom_rut, va_nom_cor, 
        va_est_ado
   FROM adp007
  WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)

--** Abre Cursor
OPEN vc_def_rut
--** Lee el primer registro
FETCH NEXT FROM vc_def_rut INTO @va_ide_rut, @va_nom_rut, @va_nom_cor, @va_est_rut
														
WHILE (@@FETCH_STATUS = 0)
BEGIN	

	SET @va_est_ado = ''
	IF (@va_est_rut = 'H')
		SET @va_est_ado = 'Habilitado'
	IF (@va_est_rut = 'N')
		SET @va_est_ado = 'Deshabilitado'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_def_rut VALUES (@va_ide_rut, @va_nom_rut, @va_nom_cor, 
	                                @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_def_rut INTO @va_ide_rut, @va_nom_rut, @va_nom_cor, @va_est_rut
END	

CLOSE vc_def_rut
DEALLOCATE vc_def_rut


--** Retorna los datos
SELECT va_ide_rut, va_nom_rut, va_nom_cor, 
	   va_est_ado
  FROM #tm_def_rut
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_ide_rut END ASC,
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_rut END ASC
