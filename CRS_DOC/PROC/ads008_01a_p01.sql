/*****************************************************************/
/*	ARCHIVO: ads008_01a_p01.sql                                  */
/*	PROCEDIMIENTO: APLICACIONES AUTORIZADAS AL USUARIO           */
/*  PARAMETROS:   @ar_ide_usr  VARCHAR(15)  ID. Usuario          */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/08/2021             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads008_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads008_01a_p01
GO

CREATE PROCEDURE ads008_01a_p01		@ag_ide_usr VARCHAR(15) WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(15),   --** ID. Usuario
            @va_ide_apl  VARCHAR(06),   --** ID. Aplicación			
			@va_mod_act  INT,           --** Módulo Activado Cifrado
			@va_mod_ads  CHAR(01),      --** Módulo de Administrador
			@va_mod_inv  CHAR(01),      --** Módulo de Inventario
			@va_mod_cmr  CHAR(01),      --** Módulo de Comercializacion
			@va_mod_ctb  CHAR(01),      --** Módulo de Contabilidad
			@va_mod_tes  CHAR(01),      --** Módulo de Tesoreria
			@va_mod_res  CHAR(01)       --** Módulo de Restaurant

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable 
SET @va_mod_ads = 'N'
SET @va_mod_inv = 'N'
SET @va_mod_cmr = 'N'
SET @va_mod_ctb = 'N'
SET @va_mod_tes = 'N'
SET @va_mod_res = 'N'

--** Crea la tabla temporal
CREATE TABLE #tm_apl_aut(
	va_ide_usr  VARCHAR(15),
	va_ide_apl  VARCHAR(06)
)

--** Obtiene SI tiene licencia sobre el Modulo de Administrador
SET @va_mod_act = 0
SELECT @va_mod_act = va_glo_ent
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 310

IF (@@ROWCOUNT != 0 AND @va_mod_act = 2170)
	SET @va_mod_ads = 'S'
ELSE
	SET @va_mod_ads = 'N'

--** Obtiene SI tiene licencia sobre el Modulo de Inventario
SET @va_mod_act = 0
SELECT @va_mod_act = va_glo_ent
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 311

IF (@@ROWCOUNT != 0 AND @va_mod_act = 2177)
	SET @va_mod_inv = 'S'
ELSE
	SET @va_mod_inv = 'N'	

--** Obtiene SI tiene licencia sobre el Modulo de Comercialización
SET @va_mod_act = 0
SELECT @va_mod_act = va_glo_ent
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 312

IF (@@ROWCOUNT != 0 AND @va_mod_act = 2184)
	SET @va_mod_cmr = 'S'
ELSE
	SET @va_mod_cmr = 'N'

--** Obtiene SI tiene licencia sobre el Modulo de Contabilidad
SET @va_mod_act = 0
SELECT @va_mod_act = va_glo_ent
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 313

IF (@@ROWCOUNT != 0 AND @va_mod_act = 2191)
	SET @va_mod_ctb = 'S'
ELSE
	SET @va_mod_ctb = 'N'

--** Obtiene SI tiene licencia sobre el Modulo de Tesoreria
SET @va_mod_act = 0
SELECT @va_mod_act = va_glo_ent
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 314

IF (@@ROWCOUNT != 0 AND @va_mod_act = 2198)
	SET @va_mod_tes = 'S'
ELSE
	SET @va_mod_tes = 'N'

--** Obtiene SI tiene licencia sobre el Modulo de Restaurant
SET @va_mod_act = 0
SELECT @va_mod_act = va_glo_ent
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 315

IF (@@ROWCOUNT != 0 AND @va_mod_act = 2205)
	SET @va_mod_res = 'S'
ELSE
	SET @va_mod_res = 'N'

--** Lee las aplicaciones autorazadas al ausuario
DECLARE cv_ite_ped CURSOR LOCAL FOR 
SELECT RTRIM(va_ide_usr), RTRIM(va_ide_uno)
  FROM ads008
 WHERE va_ide_usr = @ag_ide_usr 
   AND va_ide_tab = 'ads002'

--** Abre cursor
OPEN cv_ite_ped

--** Lee primer registro
FETCH NEXT FROM cv_ite_ped INTO @va_ide_usr, @va_ide_apl
                                  
WHILE (@@FETCH_STATUS = 0) 
BEGIN
	--** Aplicación: Administrador
	IF (@va_ide_apl = 'ads200' AND 
	    @va_mod_ads = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)		
	END

	--** Aplicación: Inventario
	IF (@va_ide_apl = 'inv200' AND 
	    @va_mod_inv = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)
	END

	--** Aplicación: Comercialización
	IF (@va_ide_apl = 'cmr200' AND 
	    @va_mod_cmr = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)
	END

	--** Aplicación: Contabilidad
	IF (@va_ide_apl = 'ctb200' AND 
	    @va_mod_cmr = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)
	END

	--** Aplicación: Tesoreria
	IF (@va_ide_apl = 'tes200' AND 
	    @va_mod_cmr = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)
	END

	--** Aplicación: Restaurant
	IF (@va_ide_apl = 'res200' AND 
	    @va_mod_res = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)
	END

	--** Lee siguiente registro
   FETCH NEXT FROM cv_ite_ped INTO @va_ide_usr, @va_ide_apl
END

--** Cierra y destruye cursor
CLOSE cv_ite_ped
DEALLOCATE cv_ite_ped

--** Retorna los datos
SELECT va_ide_usr, va_ide_apl
 FROM #tm_apl_aut
