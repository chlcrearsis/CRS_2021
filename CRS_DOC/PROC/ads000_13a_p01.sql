/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads000_13a_p01.sql
PROCEDIMIENTO: OBTIENE LA LICENCIA DEL SISTEMA
	Y LOS MODULOS ATORIZADOS
AUTOR:	CREARSIS(JEJR)
FECHA:	16-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads000_13a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads000_13a_p01
GO

CREATE PROCEDURE ads000_13a_p01		WITH ENCRYPTION AS

DECLARE		@va_nom_ser  NVARCHAR(120), --** Nombre del Servidor
            @va_ser_nom  NVARCHAR(120), --** Nombre del Servidor
			@va_nom_bda  CHAR(80),      --** Nombre de la Base de Datos
			@va_bda_nom  CHAR(80),      --** Nombre de la Base de Datos
            @va_fec_act  DATETIME,      --** Fecha actual
			@va_fec_str  CHAR(10),      --** Fecha String
			@va_nro_usr  INT,           --** Nro. Usuario,
			@va_fch_exp  CHAR(08),      --** Fecha de Expiración Cifrada
			@va_fec_exp  CHAR(10),      --** Fecha de Expiración,
			@va_mod_act  INT,           --** Módulo Activado Cifrado
			@va_mod_adm  CHAR(01),      --** Módulo de Administrador
			@va_mod_inv  CHAR(01),      --** Módulo de Inventario
			@va_mod_com  CHAR(01),      --** Módulo de Comercializacion
			@va_mod_res  CHAR(01)       --** Módulo de Restaurant


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable
SET @va_nom_ser = ''
SET @va_ser_nom = ''
SET @va_bda_nom = ''
SET @va_nom_bda = ''
SET @va_nro_usr = 0
SET @va_fch_exp = ''
SET @va_fec_exp = ''
SET @va_mod_adm = 'N'
SET @va_mod_inv = 'N'
SET @va_mod_com = 'N'
SET @va_mod_res = 'N'

--** Obtiene la fecha actual en formato dd/MM/yyyy
SET @va_fec_act = GETDATE()
SET @va_fec_str = CONVERT(CHAR(10), @va_fec_act, 103)

--** Obtiene el nombre del servidor
SELECT @va_nom_ser = @@SERVERNAME

--** Obtiene el nombre de la Base de Datos
SELECT @va_nom_bda = DB_NAME()

--** Obtiene el Nombre del Servidor Licenciado
SELECT @va_ser_nom = va_glo_car
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 300

--** Obtiene el Nombre del Servidor Licenciado
SELECT @va_bda_nom = va_glo_car
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 301

IF (@va_nom_ser = @va_ser_nom AND 
    @va_nom_bda = @va_bda_nom)
BEGIN
	--** Obtiene el Nro. de Usuario Concurrente
	SELECT @va_nro_usr = va_glo_ent
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 302

	IF (@va_nro_usr > 0)
		SET @va_nro_usr = @va_nro_usr / 1024

	--** Obtiene la fecha de Caducidad
	SELECT @va_fch_exp = va_glo_car
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 303

	IF (@va_fch_exp <> '')
	BEGIN
		SET @va_fec_exp = SUBSTRING(@va_fch_exp, 2, 1) +
						  SUBSTRING(@va_fch_exp, 4, 1) + '/' +
						  SUBSTRING(@va_fch_exp, 6, 1) +
						  SUBSTRING(@va_fch_exp, 8, 1) + '/' +
						  SUBSTRING(@va_fch_exp, 7, 1) +
						  SUBSTRING(@va_fch_exp, 5, 1) +
						  SUBSTRING(@va_fch_exp, 3, 1) +
						  SUBSTRING(@va_fch_exp, 1, 1)
	END

	--** Obtiene SI tiene licencia sobre el Modulo de Administrador
	SET @va_mod_act = 0
	SELECT @va_mod_act = va_glo_ent
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 310

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 2170)
		SET @va_mod_adm = 'S'
	ELSE
		SET @va_mod_adm = 'N'

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
		SET @va_mod_com = 'S'
	ELSE
		SET @va_mod_com = 'N'

	--** Obtiene SI tiene licencia sobre el Modulo de Restaurant
	SET @va_mod_act = 0
	SELECT @va_mod_act = va_glo_ent
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 313

	IF (@@ROWCOUNT != 0 AND @va_mod_act = 2191)
		SET @va_mod_res = 'S'
	ELSE
		SET @va_mod_res = 'N'
END

/* Devuelve Datos de la licencia */
SELECT @va_nom_ser AS va_nom_ser,
       @va_nom_bda AS va_nom_bda,
       @va_nro_usr AS va_nro_usr,
       @va_fec_exp AS va_fec_exp,
	   @va_mod_adm AS va_mod_adm,
	   @va_mod_inv AS va_mod_inv,
	   @va_mod_com AS va_mod_com,
	   @va_mod_res AS va_mod_res

GO