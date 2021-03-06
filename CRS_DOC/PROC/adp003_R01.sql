/*****************************************************************/
/*	ARCHIVO: adp003_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME TIPO DE ATRIBUTOS                     */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 13/07/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp003_R01') and sysstat & 0xf = 4)
	drop procedure dbo.adp003_R01
GO

CREATE PROCEDURE adp003_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

DECLARE		@va_ide_tip	 INT,			--** ID. Tipo Atributo
            @va_nom_tip  VARCHAR(30),	--** Nombre Tipo
			@va_atr_def  INT,			--** ID. Atributo p/Defecto
			@va_nom_atr  VARCHAR(30),	--** Nombre Atributo
			@va_est_tip  CHAR(01), 	    --** Estado (H=Habilitado; N=Deshabilitado)
			@va_est_ado  VARCHAR(15)    --** Estado (Habilitado; Deshabilitado)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_tip_atr
(
	va_ide_tip	INT,
    va_nom_tip  VARCHAR(30),
	va_atr_def  INT,
	va_nom_atr  VARCHAR(30),
	va_est_ado  VARCHAR(15)
)

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene los datos del tipo de atributo
DECLARE vc_tip_atr CURSOR LOCAL FOR
 SELECT va_ide_tip, va_nom_tip, va_atr_def, 
        va_est_ado
   FROM adp003
  WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)

--** Abre Cursor
OPEN vc_tip_atr
--** Lee el primer registro
FETCH NEXT FROM vc_tip_atr INTO @va_ide_tip, @va_nom_tip, @va_atr_def, @va_est_tip
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene nombre del atributo
	SET @va_nom_atr = ''
	SELECT @va_nom_atr = va_nom_atr
	  FROM adp004
	 WHERE va_ide_tip = @va_ide_tip
	   AND va_ide_atr = @va_atr_def
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_atr = ''

	SET @va_est_ado = ''
	IF (@va_est_tip = 'H')
		SET @va_est_ado = 'Habilitado'
	IF (@va_est_tip = 'N')
		SET @va_est_ado = 'Deshabilitado'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_tip_atr VALUES (@va_ide_tip, @va_nom_tip, @va_atr_def, 
	                                @va_nom_atr, @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_tip_atr INTO @va_ide_tip, @va_nom_tip, @va_atr_def, @va_est_tip
END	

CLOSE vc_tip_atr
DEALLOCATE vc_tip_atr


--** Retorna los datos
SELECT va_ide_tip, va_nom_tip, va_atr_def, 
	   va_nom_atr, va_est_ado
  FROM #tm_tip_atr
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_ide_tip END ASC,
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_tip END ASC
