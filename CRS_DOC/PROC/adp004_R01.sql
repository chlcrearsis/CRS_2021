/*****************************************************************/
/*	ARCHIVO: adp004_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME DEFINICIONES DE ATRIBUTOS             */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_tip_ini  INT       Tipo Atributo Inicial   */
/*                @ar_tip_fin  INT       Tipo Atributo Final     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 13/07/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp004_R01') and sysstat & 0xf = 4)
	drop procedure dbo.adp004_R01
GO

CREATE PROCEDURE adp004_R01		@ar_est_ado  CHAR(01),
                                @ar_tip_ini  INT,
								@ar_tip_fin  INT WITH ENCRYPTION AS

DECLARE		@va_ide_tip	 INT,			--** ID. Tipo Atributo
            @va_nom_tip  VARCHAR(30),	--** Nombre Tipo
			@va_ide_atr  INT,			--** ID. Atributo
			@va_nom_atr  VARCHAR(30),	--** Nombre Atributo
			@va_est_atr  CHAR(01), 	    --** Estado (H=Habilitado; N=Deshabilitado)
			@va_est_ado  VARCHAR(15)    --** Estado (Habilitado; Deshabilitado)
		
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_def_atr
(
	va_ide_tip	INT,
    va_nom_tip  VARCHAR(30),
	va_ide_atr  INT,
	va_nom_atr  VARCHAR(30),
	va_est_ado  VARCHAR(15)
)

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene los datos del tipo de atributo
DECLARE vc_def_atr CURSOR LOCAL FOR
 SELECT va_ide_tip, va_ide_atr, va_nom_atr,
        va_est_ado
   FROM adp004
  WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
    AND va_ide_tip >= @ar_tip_ini
	AND va_ide_tip <= @ar_tip_fin

--** Abre Cursor
OPEN vc_def_atr
--** Lee el primer registro
FETCH NEXT FROM vc_def_atr INTO @va_ide_tip, @va_ide_atr, @va_nom_atr, @va_est_atr
														
WHILE (@@FETCH_STATUS = 0)
BEGIN

	--** Obtiene nombre del tipo de atributo
	SET @va_nom_tip = ''
	SELECT @va_nom_tip = va_nom_tip
	  FROM adp003
	 WHERE va_ide_tip = @va_ide_tip
	
	IF (@@ROWCOUNT = 0)
		SET @va_nom_tip = ''

	SET @va_est_ado = ''
	IF (@va_est_atr = 'H')
		SET @va_est_ado = 'Habilitado'
	IF (@va_est_atr = 'N')
		SET @va_est_ado = 'Deshabilitado'

	--** Inserta en la tabla temporal
	INSERT INTO #tm_def_atr VALUES (@va_ide_tip, @va_nom_tip, @va_ide_atr, 
	                                @va_nom_atr, @va_est_ado)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_def_atr INTO @va_ide_tip, @va_ide_atr, @va_nom_atr, @va_est_atr
END	

CLOSE vc_def_atr
DEALLOCATE vc_def_atr


--** Retorna los datos
SELECT va_ide_tip, va_nom_tip, va_ide_atr, 
	   va_nom_atr, va_est_ado
  FROM #tm_def_atr
