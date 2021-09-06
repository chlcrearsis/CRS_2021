/*
ARCHIVO: res001_R03.sql
PROCEDIMIENTO: REPORTE LISTADO DE DOCUMENTOS
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_05a_p01
GO

CREATE PROCEDURE cmr005_05a_p01	WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN

   select * from inv099	   

GO  
/*
ARCHIVO: adp002_01a_p01.sql
PROCEDIMIENTO: BUSCA PERSONA
	
AUTOR:	CREARSIS(CHL)
FECHA:	18-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_01a_p01
GO

CREATE PROCEDURE adp002_01a_p01		@ar_cod_gru		INT,			-- Ide del modulo
									@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT	,			-- 0=cod per , 1=Razon Social
																	-- 2=Nombre Comercial, 3=Nit, 4=CI, 
									@ar_est_ado		CHAR(01)		-- Estado
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_gru		INT,
@va_nom_gru		VARCHAR(50),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(120),
@va_nom_com		VARCHAR(100),
@va_nit_per		BIGINT,
@va_car_net		BIGINT,
@va_dir_per		VARCHAR(80),
@va_tel_per		VARCHAR(15),
@va_cel_per		VARCHAR(15),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_gru		INT,
va_nom_gru		VARCHAR(50),
va_cod_per		INT,
va_raz_soc		VARCHAR(120),
va_nom_com		VARCHAR(100),
va_nit_per		BIGINT,
va_car_net		BIGINT,
va_dir_per		VARCHAR(80),
va_tel_per		VARCHAR(15),
va_cel_per		VARCHAR(15),
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

IF(@ar_est_ado ='T')
	SET @ar_est_ado = '%'

-- Crea cursor para busqueda
IF(@ar_cri_bus = 0)  -- Codigo Persona
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM adp002 
	WHERE (va_cod_per LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 1)  -- Razon Social
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM adp002 
	WHERE (va_raz_soc LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 2)  -- Nombre Comercial
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM adp002 
	WHERE (va_nom_com LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 3)  -- Nit
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM adp002 
	WHERE (va_nit_per LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 4)  -- CI
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM adp002 
	WHERE (va_car_net LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END


IF(@ar_cri_bus = 5)  -- Celular
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM adp002 
	WHERE (va_cel_per LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END


OPEN vc_per_son
FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, @va_car_net, @va_dir_per, @va_tel_per, @va_cel_per, @va_est_ado
									
					
WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del Grupo
	SELECT @va_nom_gru = va_nom_gru
	  FROM adp001
	 WHERE va_cod_gru = @va_cod_gru
 

  
 
	 INSERT INTO #resultado VALUES (@va_cod_gru,
									@va_nom_gru		,
									@va_cod_per		,
									@va_raz_soc		,
									@va_nom_com		,
									@va_nit_per		,
									@va_car_net		,
									@va_dir_per		,
									@va_tel_per		,
									@va_cel_per		,
									@va_est_ado		
									)

	FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, @va_car_net, @va_dir_per, @va_tel_per, @va_cel_per, @va_est_ado
END	

CLOSE vc_per_son
DEALLOCATE vc_per_son

IF(@ar_cod_gru = 0)	
BEGIN
	SELECT * 
	FROM #resultado
END
IF(@ar_cod_gru <> 0)	
BEGIN
	SELECT * 
	FROM #resultado
	WHERE va_cod_gru = @ar_cod_gru
END

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: adp002_01a_p02.sql
PROCEDIMIENTO: OBTIENE ULTIMO NUMERO DE PERSONA
			   EN EL GRUPO ESPESIFICADO
	
AUTOR:	CREARSIS(CHL)
FECHA:	19-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_01a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_01a_p02
GO

CREATE PROCEDURE adp002_01a_p02		@ar_cod_gru		INT			-- Codigo de grupo
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE
		@nro	INT 
 
SELECT @nro = MAX(va_cod_per) from adp002
WHERE va_cod_gru = @ar_cod_gru

SET @ar_cod_gru = @ar_cod_gru * 10000

SET @nro = @nro - @ar_cod_gru

IF(@nro IS nulL)
	SET @nro = 0

SELECT @nro AS va_ult_nro
IF @@ERROR <> 0
   RETURN
 
GO


  
/*
ARCHIVO: adp002_05a_p01.sql
PROCEDIMIENTO: BUSCA PERSONA
	
AUTOR:	CREARSIS(CHL)
FECHA:	20-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_05a_p01
GO

CREATE PROCEDURE adp002_05a_p01		@ar_cod_per		INT	
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_gru		INT,
@va_nom_gru		VARCHAR(50),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(120),
@va_nom_com		VARCHAR(100),
@va_nit_per		BIGINT,
@va_car_net		BIGINT,
@va_dir_per		VARCHAR(80),
@va_tel_per		VARCHAR(15),
@va_cel_per		VARCHAR(15),
@va_ema_per		VARCHAR(30), 
@va_ubi_gps		GEOGRAPHY,
@va_cod_lpr		INT,
@va_cod_ven		INT,
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_gru		INT,
va_nom_gru		VARCHAR(50),
va_cod_per		INT,
va_raz_soc		VARCHAR(120),
va_nom_com		VARCHAR(100),
va_nit_per		BIGINT,
va_car_net		BIGINT,
va_dir_per		VARCHAR(80),
va_tel_per		VARCHAR(15),
va_cel_per		VARCHAR(15),
va_ema_per		VARCHAR(30), 
va_ubi_gps		GEOGRAPHY,
va_cod_lpr		INT,
va_cod_ven		INT,
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	-- Crea cursor para busqueda
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per,va_ema_per,  va_ubi_gps,va_cod_lpr, va_cod_ven, va_est_ado
	FROM adp002 
	WHERE (va_cod_per = @ar_cod_per  )


OPEN vc_per_son
FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, 
								@va_car_net, @va_dir_per, @va_tel_per, @va_cel_per,@va_ema_per,  
								@va_ubi_gps, @va_cod_lpr, @va_cod_ven, @va_est_ado
									
WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del Grupo
	SELECT @va_nom_gru = va_nom_gru
	  FROM adp001
	 WHERE va_cod_gru = @va_cod_gru
 
	 INSERT INTO #resultado VALUES (@va_cod_gru,
									@va_nom_gru		,
									@va_cod_per		,
									@va_raz_soc		,
									@va_nom_com		,
									@va_nit_per		,
									@va_car_net		,
									@va_dir_per		,
									@va_tel_per		,
									@va_cel_per		,
									@va_ema_per		, 
									@va_ubi_gps		,
									@va_cod_lpr		,
									@va_cod_ven		,
									@va_est_ado		
									)

			FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, 
								@va_car_net, @va_dir_per, @va_tel_per, @va_cel_per,@va_ema_per,  
								@va_ubi_gps, @va_cod_lpr, @va_cod_ven, @va_est_ado
END	

CLOSE vc_per_son
DEALLOCATE vc_per_son
 
	SELECT * 
	FROM #resultado
 
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: ads000_01a_p01.sql
PROCEDIMIENTO: VERIFICA USUARIO EN EL SISTEMA
	CON PERMISOS PARA EL USUARIO
AUTOR:	CREARSIS(JEJR)
FECHA:	07-08-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads000_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads000_01a_p01
GO

CREATE PROCEDURE ads000_01a_p01		@ar_ide_usr	 CHAR(15),	-- ID. Usuario
									@ar_pas_usr	 CHAR(30)	-- Contrase¤a
									WITH ENCRYPTION AS

DECLARE		@va_per_rol  INT,			--** Permiso sobre Rol
			@va_est_ado  CHAR(01),		--** Estado (H=Habilitado; N=Deshabilitado)
			@va_cod_err  INT,			--** C¢digo de Error
			@va_msn_err  NVARCHAR(100)	--** Mensaje de Error


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
SET @va_cod_err = 0
SET @va_msn_err = 'OK'
       
--** Verifica que exista el usuario en Seguridad > Inicio de Sesion
IF NOT EXISTS
  (SELECT name  
     FROM master.sys.server_principals
     WHERE name = @ar_ide_usr)
BEGIN	
	SET @va_msn_err = 'NO existe ning£n Inicio de Sesion con ese nombre en el Servidor.'
	SET @va_cod_err = 100
END

--** Verifica que exista el usuario en la {Base de Datos}{Seguridad}{Usuarios}
IF (@va_cod_err = 0)
BEGIN
	IF NOT EXISTS
	  (SELECT name  
		 FROM master.sys.server_principals
		 WHERE name = @ar_ide_usr)
	BEGIN
		SET @va_msn_err = 'NO Existe ning£n Inicio de Sesion con ese nombre en la Base de Datos.'
		SET @va_cod_err = 101
	END
END

--** Verifica si tiene adicionado el rol 'dbcreator'
SET @va_per_rol = 0
SET @va_per_rol = IS_SRVROLEMEMBER('dbcreator', RTRIM(@ar_ide_usr))
IF (@va_cod_err = 0)
BEGIN
	IF (@va_per_rol = 0)
	BEGIN
		SET @va_msn_err = 'El Inicio de Sesion NO tiene permiso sobre el rol (dbcreator). Consulte con su Administrador'
		SET @va_cod_err = 102
	END
END

--** Verifica si tiene adicionado el rol 'sysadmin'
SET @va_per_rol = 0
SET @va_per_rol = IS_SRVROLEMEMBER('sysadmin', RTRIM(@ar_ide_usr))
IF (@va_cod_err = 0)
BEGIN
	IF (@va_per_rol = 0)
	BEGIN
	    SET @va_msn_err = 'El Inicio de Sesion NO tiene permiso sobre el rol (sysadmin). Consulte con su Administrador'
		SET @va_cod_err = 103
	END
END

--** Verifica si tiene adicionado el rol 'serveradmin'
SET @va_per_rol = 0
SET @va_per_rol = IS_SRVROLEMEMBER('serveradmin', RTRIM(@ar_ide_usr))
IF (@va_cod_err = 0)
BEGIN
	IF (@va_per_rol = 0)
	BEGIN
	    SET @va_msn_err = 'El Inicio de Sesion NO tiene permiso sobre el rol (serveradmin). Consulte con su Administrador'
		SET @va_cod_err = 104		
	END
END

--** Verificar si existe el usuario creado en la tabla ads007
SET @va_est_ado = ''
SELECT @va_est_ado = va_est_ado 
  FROM ads007
 WHERE va_ide_usr = RTRIM(@ar_ide_usr)

IF (@va_cod_err = 0)
BEGIN
    SET @va_est_ado = ''
	SELECT @va_est_ado = va_est_ado 
	  FROM ads007
	 WHERE va_ide_usr = RTRIM(@ar_ide_usr)
	IF (@@ROWCOUNT = 0)
	BEGIN
	    SET @va_msn_err = 'NO Existe ning£n Usuario con ese nombre en el Sistema.'
		SET @va_cod_err = 105
	END

	IF (@va_est_ado = 'N' AND @va_cod_err = 0)
	BEGIN
	    SET @va_msn_err = 'El Usuario NO est  habilitado para ingresar al Sistema.'
		SET @va_cod_err = 106
	END
END



/* Devuelve Datos del Usuario */
SELECT @va_cod_err AS va_cod_err,
       @va_msn_err AS va_msn_err

GO  
/*
ARCHIVO: ads000_13a_p01.sql
PROCEDIMIENTO: OBTIENE LA LICENCIA DEL SISTEMA
	Y LOS MODULOS ATORIZADOS
AUTOR:	CREARSIS(JEJR)
FECHA:	16-08-2021 
--*/

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
			@va_fch_exp  CHAR(08),      --** Fecha de Expiraci¢n Cifrada
			@va_fec_exp  CHAR(10),      --** Fecha de Expiraci¢n,
			@va_mod_act  INT,           --** M¢dulo Activado Cifrado
			@va_mod_adm  CHAR(01),      --** M¢dulo de Administrador
			@va_mod_inv  CHAR(01),      --** M¢dulo de Inventario
			@va_mod_com  CHAR(01),      --** M¢dulo de Comercializacion
			@va_mod_res  CHAR(01)       --** M¢dulo de Restaurant


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

	--** Obtiene SI tiene licencia sobre el Modulo de Comercializaci¢n
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
/*
ARCHIVO: ads000_13b_p01.sql
PROCEDIMIENTO: OBTIENE LA LICENCIA DEL SISTEMA
	Y LOS MODULOS ATORIZADOS
AUTOR:	CREARSIS(JEJR)
FECHA:	16-08-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads000_13b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads000_13b_p01
GO

CREATE PROCEDURE ads000_13b_p01		@ag_nro_usr	 INT,
                                    @ag_fec_exp  CHAR(10),
									@ag_mod_adm  CHAR(01),
									@ag_mod_inv  CHAR(01),
									@ag_mod_com  CHAR(01),
									@ag_mod_res  CHAR(01)  WITH ENCRYPTION AS

DECLARE		@va_nom_ser  NVARCHAR(120), --** Nombre del Servidor
			@va_nom_bda  CHAR(80),      --** Nombre de la Base de Datos
			@va_nro_usr  INT,           --** Nro. Usuario
			@va_fec_exp  CHAR(08),      --** Fecha de Expiraci¢n		
			@va_nro_reg  INT            --** Nro de Registro


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable
SET @va_nom_ser = ''
SET @va_nom_bda = ''
SET @va_nro_usr = 0
SET @va_fec_exp = ''

--** Obtiene el nombre del servidor
SELECT @va_nom_ser = @@SERVERNAME

--** Inserta en la Global el nombre del servidor
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*)
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 300

IF (@va_nro_reg = 0)
BEGIN
	INSERT INTO ads013 VALUES (1, 300, 'NAME_SRV', 1, @va_nom_ser, 0, 0.0)
END
ELSE
BEGIN
	UPDATE ads013 SET va_nom_glo = 'NAME_SRV',
	                  va_tip_glo = 1,
					  va_glo_car = @va_nom_ser,
					  va_glo_ent = 0,
					  va_glo_dec = 0.00
				WHERE va_ide_mod = 1 AND va_ide_glo = 300
END

--** Obtiene el nombre de la Base de Datos
SELECT @va_nom_bda = DB_NAME()

--** Inserta en la Global el nombre de la Base de Datos
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*)
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 301

IF (@va_nro_reg = 0)
BEGIN
	INSERT INTO ads013 VALUES (1, 301, 'NAME_BDA', 1, @va_nom_bda, 0, 0.0)
END
ELSE
BEGIN
	UPDATE ads013 SET va_nom_glo = 'NAME_BDA',
	                  va_tip_glo = 1,
					  va_glo_car = @va_nom_bda,
					  va_glo_ent = 0,
					  va_glo_dec = 0.00
				WHERE va_ide_mod = 1 AND va_ide_glo = 301
END

--** Inserta el nro de usuario concurrentes
IF (@ag_nro_usr > 0)
BEGIN
	SET @va_nro_usr = @ag_nro_usr * 1024

	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 302

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 302, 'NUMBER_USR', 2, '', @va_nro_usr, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'NUMBER_USR',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = @va_nro_usr,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 302
	END
END

--** Inserta la fecha de expiraci¢n de la licencia

IF (@ag_fec_exp <> '')
BEGIN
	SET @va_fec_exp = SUBSTRING(@ag_fec_exp, 10, 1) +
					  SUBSTRING(@ag_fec_exp, 1, 1) + 
					  SUBSTRING(@ag_fec_exp, 9, 1) +
					  SUBSTRING(@ag_fec_exp, 2, 1) + 
					  SUBSTRING(@ag_fec_exp, 8, 1) +
					  SUBSTRING(@ag_fec_exp, 4, 1) +
					  SUBSTRING(@ag_fec_exp, 7, 1) +
					  SUBSTRING(@ag_fec_exp, 5, 1)

	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 303

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 303, 'DATE_VALUE', 1, @va_fec_exp, 0, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'DATE_VALUE',
						  va_tip_glo = 1,
						  va_glo_car = @va_fec_exp,
						  va_glo_ent = 0,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 303
	END					  
END

--** Verifica e Inserta el Modulo de Administrador
IF (@ag_mod_adm = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 310

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 310, 'MOD_ADM', 2, '', 2170, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_ADM',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2170,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 310
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 310
END

--** Verifica e Inserta el Modulo de Inventario
IF (@ag_mod_inv = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 311

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 311, 'MOD_INV', 2, '', 2177, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_ADM',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2177,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 311
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 311
END


--** Verifica e Inserta el Modulo de Comercializaci¢n
IF (@ag_mod_com = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 312

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 312, 'MOD_COM', 2, '', 2184, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_COM',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2184,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 312
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 312
END


--** Verifica e Inserta el Modulo de Restaurant
IF (@ag_mod_res = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 313

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 313, 'MOD_RES', 2, '', 2191, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_RES',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2191,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 313
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 313
END

RETURN

GO  
/*
ARCHIVO: ads001_04a_p01.sql
PROCEDIMIENTO: DESHABILITA MODULO
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-07-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads001_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads001_04a_p01
GO

CREATE PROCEDURE ads001_04a_p01	@ar_ide_mod		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene Aplicaciones Habilitadas ligados al documento que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	   FROM ads002 
	  WHERE (va_ide_mod = @ar_ide_mod)
		AND (va_est_ado = 'H')

	--/ Procede a deshabilitar el Modulo
	IF(@va_can_tid = 0)
	BEGIN
		UPDATE ads001 SET va_est_ado = 'N'
		WHERE va_ide_mod = @ar_ide_mod
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Deshabilitar, Existen Aplicaciones Habilitadas relacionadas con el Modulo' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads001_06a_p01.sql
PROCEDIMIENTO: ELIMINA MODULO
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-07-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads001_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads001_06a_p01
GO

CREATE PROCEDURE ads001_06a_p01	@ar_ide_mod		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene Aplicaciones ligadas al documento que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	   FROM ads002 
	  WHERE (va_ide_mod = @ar_ide_mod)

	--/ Procede a Eliminar el Modulo
	IF(@va_can_tid = 0)
	BEGIN
		DELETE ads001 
		WHERE va_ide_mod = @ar_ide_mod
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Eliminar el M¢dulo, Existen Aplicaciones relacionadas con el mismo' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads002_04a_p01.sql
PROCEDIMIENTO: HABILITA aplicacion
	
AUTOR:	CREARSIS(CHL)
FECHA:	06-08-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads002_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads002_04a_p01
GO

CREATE PROCEDURE ads002_04a_p01	@ar_ide_mod		INT ,
								@ar_ide_apl		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@va_est_mod			CHAR(01)	    --** Estado del modulo



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del modulo
	 SELECT @va_est_mod = va_est_ado
	  FROM ads001 
	 WHERE (va_ide_mod = @ar_ide_mod)
		

	--/ Si el modulo esta Deshabilitado, no se puede habilitar la aplicacion
	IF(@va_est_mod = 'N')
	BEGIN
		RAISERROR ('No puede Habilitar la aplicacion si el modulo esta Deshabilitado' ,16,1)
		RETURN
	END
	
	IF(@va_est_mod = 'H')
	BEGIN
		UPDATE ads002 SET va_est_ado = 'H'
		WHERE va_ide_mod = @ar_ide_mod AND va_ide_apl = @ar_ide_apl
		-- Registrar bitacora
		--INSERT INTO
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads002_05a_p01.sql
PROCEDIMIENTO: CONSULTA APLICACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-07-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads002_05a_p01
GO

CREATE PROCEDURE ads002_05a_p01	@ar_ide_apl		CHAR(06)	
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_ide_mod		INT


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 -- Obtiene modulo de la aplicacion
	 SELECT @va_ide_mod = va_ide_mod
	   FROM ads002
	  WHERE va_ide_apl = @ar_ide_apl
	  
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl, 
			ads002.va_nom_apl, ads002.va_est_ado
	  FROM ads002, ads001
	 WHERE (ADS001.va_ide_mod = ads001.va_ide_mod)
	   AND (ads001.va_ide_mod = @va_ide_mod)
	   AND (ads002.va_ide_apl = @ar_ide_apl)

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads002_06a_p01.sql
PROCEDIMIENTO: ELIMINAR aplicacion
	
AUTOR:	CREARSIS(CHL)
FECHA:	06-08-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads002_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads002_06a_p01
GO

CREATE PROCEDURE ads002_06a_p01	@ar_ide_mod		CHAR(03),
								@ar_ide_apl		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@count				INT



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del modulo
	 SELECT @count = COUNT(*)
	  FROM ads002
	 WHERE (va_ide_mod = @ar_ide_mod)
	   AND (va_ide_apl = @ar_ide_apl)
		

	--/ Si la aplicacion esta habilitada, no se puede eliminar 
	IF(@count > 0)
	BEGIN
		RAISERROR ('No puede Elminiar la aplicacion, debe de estar Deshabilitada primero.' ,16,1)
		RETURN
	END
	
	IF(@count = 0)
	BEGIN
		DELETE ads002
		WHERE va_ide_mod = @ar_ide_mod AND va_ide_apl = @ar_ide_apl
		
		-- Registrar bitacora
		--INSERT INTO
		
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads003_04a_p1.sql
PROCEDIMIENTO: DESHABILITA DOCUMENTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_04a_p01
GO

CREATE PROCEDURE ads003_04a_p01	@ar_ide_doc		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene talonarios Habilitados ligados al documento que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	  FROM ads004 
	 WHERE (va_ide_doc = @ar_ide_doc)
		AND (va_est_ado = 'H')

	--/ Procede a anular el documento
	IF(@va_can_tid = 0)
	BEGIN
		UPDATE ads003 SET va_est_ado = 'N'
		WHERE va_ide_doc = @ar_ide_doc
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Deshabilitar, Existen Talonarios Habilitados relacionados con el documento' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads003_05a_p01.sql
PROCEDIMIENTO: CONSULTA DOCUMENTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_05a_p01
GO

CREATE PROCEDURE ads003_05a_p01	@ar_ide_doc		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,
            ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado
	  FROM	ads003 , ads001
	 WHERE (ads003.va_ide_doc = @ar_ide_doc)
	   AND (ads003.va_ide_mod = ads001.va_ide_mod)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads003_06a_p01.sql
PROCEDIMIENTO: ELIMINA DOCUMENTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_06a_p01
GO

CREATE PROCEDURE ads003_06a_p01	@ar_ide_doc		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene talonarios ligados al documento que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	  FROM ads004 
	 WHERE (va_ide_doc = @ar_ide_doc)

	--/ Procede a anular el documento
	IF(@va_can_tid = 0)
	BEGIN
		DELETE ads003
		WHERE va_ide_doc = @ar_ide_doc
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede eliminar, Existen Talonarios relacionados con el documento' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads003_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE DOCUMENTOS
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_R01
GO

CREATE PROCEDURE ads003_R01	@ar_ide_mod		INT,
							@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	IF(@ar_est_ado = 'T')
		SET @va_est_ado = '%'
	IF(@ar_est_ado <> 'T')
		SET @va_est_ado = @ar_est_ado
		
		PRINT @ar_est_ado
		PRINT @va_est_ado
		
		
		 
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,
            ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado
	  FROM	ads003 , ads001
	 WHERE (ads003.va_ide_mod = ads001.va_ide_mod)
	   AND (ads001.va_ide_mod = @ar_ide_mod)
	   AND (ads003.va_est_ado LIKE @va_est_ado)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads004_01b_p01.sql
PROCEDIMIENTO: BUSCA TALONARIOS
	CON PERMISOS PARA EL USUARIO
AUTOR:	CREARSIS(CHL)
FECHA:	28-10-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_01b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_01b_p01
GO

CREATE PROCEDURE ads004_01b_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_ide_doc		CHAR(03)		-- ID del documento
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
	 WHERE va_ide_doc LIKE @ar_tex_bus + '%'	AND
		   va_ide_doc LIKE @ar_ide_doc	AND
		   va_est_ado = 'H'
		   
OPEN vc_tal_ona
FETCH NEXT FROM vc_tal_ona INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN

	-- Verifica que usuario tenga permiso sobre el talonario
	SELECT @cout = COUNT(*)
	  FROM ads008
	 WHERE	va_ide_usr = SYSTEM_USER		AND
			va_ide_tab = 'ads004'			AND
			RTRIM(va_ide_uno) = @va_ide_doc	AND
			RTRIM(va_ide_dos) = @va_nro_tal
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
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads004_02a_p01.sql
PROCEDIMIENTO: REGISTRA TALONARIO Y NUMERACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	17-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_02a_p01
GO

CREATE PROCEDURE ads004_02a_p01
							@ar_ges_tio	INT			,	-- Gestion a¤o
							@ar_anu_mes	INT			,	-- (0=Anual ; 1=Mensual)
							@ar_ide_doc	CHAR(03)	,	-- Ide Documento
							@ar_nro_tal	INT			,	-- Nro talonario
							@ar_nom_tal	VARCHAR(60)	,	-- Nombre del talonario
							@ar_tip_tal	INT			,	-- Correlativo (0=Manual ; 1=Automatico)
							@ar_nro_aut	BIGINT		,	-- Nro de autorizacion/Dosificacion de facturas
							@ar_for_mat	INT			,	-- Nro de formato para impresi¢n del documento
							@ar_nro_cop	INT			,	-- Nro de copias por defecto que imprimira
							@ar_fir_ma1	VARCHAR(15)	,	-- Firma 1 para el documento
							@ar_fir_ma2	VARCHAR(15)	,	-- Firma 2 para el documento
							@ar_fir_ma3	VARCHAR(15)	,	-- Firma 3 para el documento
							@ar_fir_ma4	VARCHAR(15)	,	-- Firma 4 para el documento
							@ar_for_log	INT				/* Formato de logo que se imprimira	
															0=Razon social de empresa; 
															1=Logotipo1
															2=Logotipo2 
															3=Logotipo3	*/
							
							
							
						
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar

@va_ges_tio		INT			,	-- Gestion
@va_mes_per		INT			,	-- Mes periodo
@va_nom_per		VARCHAR(10)	,	-- Nombre de periodo
@va_pri_dia		DATE		,	-- Primer dia del mes
@va_ult_dia		DATE		,	-- Ultimo dia del mes
@va_ide_doc		CHAR(03)	,	-- Ide del docuento
@va_nro_tal		INT			,	-- Numero del talonario
@va_nom_tal		VARCHAR(60)	,	-- Nombre del talonario
@va_con_tad		INT			,	-- Contador de periodos

@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ads005
BEGIN TRY   
	
	CREATE TABLE #MES
	(
		va_ide_mes		INT,
		va_nom_mes		VARCHAR(10)
	)
	INSERT INTO #MES VALUES (1,'Enero')
	INSERT INTO #MES VALUES (2,'Febrero')
	INSERT INTO #MES VALUES (3,'Marzo')
	INSERT INTO #MES VALUES (4,'Abril')
	INSERT INTO #MES VALUES (5,'Mayo')
	INSERT INTO #MES VALUES (6,'Junio')
	INSERT INTO #MES VALUES (7,'Julio')
	INSERT INTO #MES VALUES (8,'Agosto')
	INSERT INTO #MES VALUES (9,'Septiembre')
	INSERT INTO #MES VALUES (10,'Octubre')
	INSERT INTO #MES VALUES (11,'Noviembre')
	INSERT INTO #MES VALUES (12,'Diciembre')
	

	SET @va_ges_tio = @ar_ges_tio
	SET @va_ide_doc = @ar_ide_doc
	SET @va_nro_tal = @ar_nro_tal
	
	
	--/ Verifica que la Gesti¢n se encuentre creada
	SET @cout = 0
	SELECT @cout = COUNT(*)
	  FROM ads016
	 WHERE va_ges_tio = @ar_ges_tio
	 
	 IF(@cout = 0)
	 BEGIN
		--SET @msg = 'La Gesti¢n proporsionada no se encuentra registrada. ' +  CONVERT(NVARCHAR(255), @cout)  
		--		 + ' Argumento gestion = ' + CONVERT(NVARCHAR(255),@ar_ges_tio)
		RAISERROR ('La Gesti¢n proporsionada no se encuentra registrada. ',16,1)
		ROLLBACK TRAN TR_ads005
		RETURN
	 END
	
	--/ Obtiene mes inicial de la gestion
	SELECT @va_mes_per = va_ges_per 
	FROM ads016
	WHERE va_ges_tio = @ar_ges_tio
	ORDER BY va_ges_per DESC
	
	--/ En caso de ser Talonario Anual
	IF(@ar_anu_mes = 0)
	BEGIN
		--/ Cr‚a Talonario Anual
		INSERT INTO ads004 VALUES	(@va_ide_doc, @va_nro_tal, @ar_nom_tal, @ar_tip_tal, @ar_nro_aut,
									@ar_for_mat, @ar_nro_cop, @ar_fir_ma1, @ar_fir_ma2, @ar_fir_ma3,
									@ar_fir_ma4, @ar_for_log, 'H')
		
		--/ Obtiene primer y ultimo dia de la Gesti¢n
		SELECT @va_pri_dia = MIN(va_fec_ini) , 
			   @va_ult_dia = MAX(va_fec_fin)  
		  FROM ads016
		 WHERE va_ges_tio = @ar_ges_tio
		 
		--/ Cr‚a Numeraci¢n Anual			  
		INSERT INTO ads005 VALUES (@va_ide_doc, @va_nro_tal, @ar_ges_tio, @va_pri_dia,@va_ult_dia, 0, 999999,0)
		
	
	END
	
	--/ En caso de ser Talonario Mensual, segun Gesti¢n
	IF(@ar_anu_mes = 1)
	BEGIN
		SET @va_con_tad = 1
	
		WHILE (@va_con_tad <= 12)
		BEGIN
			
			--/ Obtiene datos del periodo
			SELECT @va_nom_per = va_nom_per,
				   @va_pri_dia = va_fec_ini,
				   @va_ult_dia = va_fec_fin
			  FROM ads016
			 WHERE va_ges_tio = @ar_ges_tio
			   AND va_ges_per = @va_con_tad
			
			--/ Compone nombre de talonario + nombre del mes correspondiente
			SET @va_nom_tal = @ar_nom_tal + ' - ' + @va_nom_per
			
			--/ Verifica que el Talonario a crear en el mes, aun no este creado
			SELECT *
			  FROM ads004
			 WHERE va_ide_doc = @va_ide_doc
			   AND va_nro_tal = @va_nro_tal
			IF @@ROWCOUNT <> 0
			BEGIN
				SET @msg = 'No se puede crear un Talonario duplicado, el talonario: ' +  CONVERT(NVARCHAR(255),@va_nro_tal) 
						 + ' para el Documento ' + @va_ide_doc + ' ya se encuentra registrado'
				
				RAISERROR (@msg ,16,1)
				Rollback TRAN TR_ads005
				RETURN
			END
			
			--/ Cr‚a Talonario por Mes
			INSERT INTO ads004 VALUES (@va_ide_doc, @va_nro_tal, @va_nom_tal, @ar_tip_tal, @ar_nro_aut,
									   @ar_for_mat, @ar_nro_cop, @ar_fir_ma1, @ar_fir_ma2, @ar_fir_ma3,
									   @ar_fir_ma4, @ar_for_log, 'H')
									   
			--/ Cr‚a Numeraci¢n por Mes
			INSERT INTO ads005 VALUES (@va_ide_doc, @va_nro_tal, @ar_ges_tio, @va_pri_dia,@va_ult_dia, 0, 999999,0)
			
			--/ Incrementa contadores
			SET @va_con_tad = @va_con_tad + 1
			SET @va_nro_tal = @va_nro_tal + 1
			
		END
	
	
	END
	

	
COMMIT TRAN TR_ads005
RETURN
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads005
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads004_04a_p01.sql
PROCEDIMIENTO: HABILITA TALONARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_04a_p01
GO

CREATE PROCEDURE ads004_04a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@va_est_doc			CHAR(01)	    --** Estado del documento



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del documento
	 SELECT @va_est_doc = va_est_ado
	  FROM ads003 
	 WHERE (va_ide_doc = @ar_ide_doc)
		

	--/ Si el documento esta Deshabilitado, no se puede habilitar el talonario
	IF(@va_est_doc = 'N')
	BEGIN
		RAISERROR ('No puede Habilitar el talonario si el Documento esta Deshabilitado' ,16,1)
		RETURN
	END
	
	IF(@va_est_doc = 'H')
	BEGIN
		UPDATE ads004 SET va_est_ado = 'H'
		WHERE va_ide_doc = @ar_ide_doc AND va_nro_tal = @ar_nro_tal
		-- Registrar bitacora
		--INSERT INTO
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads004_04a_p02.sql
PROCEDIMIENTO: DESHABILITA TALONARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_04a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_04a_p02
GO

CREATE PROCEDURE ads004_04a_p02	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	
	UPDATE ads004 SET va_est_ado = 'N'
	WHERE va_ide_doc = @ar_ide_doc AND va_nro_tal = @ar_nro_tal

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads004_05a_p01.sql
PROCEDIMIENTO: CONSULTA TALONARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_05a_p01
GO

CREATE PROCEDURE ads004_05a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Pregunta si tiene talonarios Habilitados ligados al documento que se quiere Deshabilitar
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads004.va_ide_doc, ads003.va_nom_doc,
			ads004.va_nro_tal, ads004.va_nom_tal, ads004.va_tip_tal, ads004.va_nro_aut,
			ads004.va_for_mat, ads004.va_nro_cop, ads004.va_fir_ma1, ads004.va_fir_ma2,
			ads004.va_fir_ma3, ads004.va_fir_ma4, ads004.va_for_log, ads004.va_est_ado
	  FROM ads004, ads003, ads001
	 WHERE (ADS001.va_ide_mod = ADS003.va_ide_mod)
	   AND (ADS003.va_ide_doc = ADS004.va_ide_doc)
	   AND (ads004.va_ide_doc = @ar_ide_doc)
	   AND (ads004.va_nro_tal = @ar_nro_tal)

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads004_05a_p02.sql
PROCEDIMIENTO: CONSULTA TALONARIO CON PERMISOS DE USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--*/

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
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads004_06a_p01.sql
PROCEDIMIENTO: ELIMINAR TALONARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	19-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_06a_p01
GO

CREATE PROCEDURE ads004_06a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@count				INT,
@va_est_doc			CHAR(01)	    --** Estado del documento



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del documento
	 SELECT @count = COUNT(*)
	  FROM ads005
	 WHERE (va_ide_doc = @ar_ide_doc)
	   AND (va_nro_tal = @ar_nro_tal)
		
	--/ revisa si tiene documentos registrados en el historial
	--
	--
	
	
	IF(@count > 0)
	BEGIN
		RAISERROR ('No puede Elminiar el talonario, Revise la numeracion' ,16,1)
		RETURN
	END
	
	IF(@count = 0)
	BEGIN
		DELETE ads004
		WHERE va_ide_doc = @ar_ide_doc AND va_nro_tal = @ar_nro_tal
		
		DELETE ads005
		WHERE va_ide_doc = @ar_ide_doc AND va_nro_tal = @ar_nro_tal
		-- Registrar bitacora
		--INSERT INTO
		
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads004_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE DOCUMENTOS
	
AUTOR:	CREARSIS(CHL)
FECHA:	25-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_R01
GO

CREATE PROCEDURE ads004_R01	@ar_ide_mod		INT,
							@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01),
@va_ide_doc		CHAR(03),	--Ide Documento
@va_nro_tal		INT,						--Nro de Talonario
@va_nom_tal		VARCHAR(60),	--Nombre Talonario
@va_tip_tal		INT						,	--Tipo de talonario  
@va_nro_aut		DECIMAL(15,0)	,	-- Numero de autorizacion
@va_for_mat		INT				,	-- Formato de impresion
@va_nro_cop		INT				,	-- Nro de copias a imprimir
@va_fir_ma1		VARCHAR(30)		,	-- Firma nro 1
@va_fir_ma2		VARCHAR(30)		,	-- Firma nro 1
@va_fir_ma3		VARCHAR(30)		,	-- Firma nro 1
@va_fir_ma4		VARCHAR(30)		,	-- Firma nro 1
@va_for_log		INT,
@va_nom_mod		VARCHAR(30)				


CREATE TABLE #ADS004
(
va_ide_mod		INT,
va_nom_mod		VARCHAR(30),
va_ide_doc		CHAR(03),	--Ide Documento
va_nro_tal		INT,						--Nro de Talonario
va_nom_tal		VARCHAR(60),	--Nombre Talonario
va_tip_tal		INT						,	--Tipo de talonario  
va_nro_aut		DECIMAL(15,0)	,	-- Numero de autorizacion
va_for_mat		INT				,	-- Formato de impresion
va_nro_cop		INT				,	-- Nro de copias a imprimir
va_fir_ma1		VARCHAR(30)		,	-- Firma nro 1
va_fir_ma2		VARCHAR(30)		,	-- Firma nro 1
va_fir_ma3		VARCHAR(30)		,	-- Firma nro 1
va_fir_ma4		VARCHAR(30)		,	-- Firma nro 1
va_for_log		INT,
va_est_ado		CHAR(01)				
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 




--/ Inicializa variable contador de registro
IF(@ar_est_ado = 'T')
	SET @va_est_ado = '%'
IF(@ar_est_ado <> 'T')
	SET @va_est_ado = @ar_est_ado
	
	
DECLARE vc_tal_ona CURSOR LOCAL FOR
SELECT ads004.va_ide_doc, ads004.va_nro_tal, ads004.va_nom_tal, ads004.va_tip_tal, ads004.va_nro_aut,
	   ads004.va_for_mat, ads004.va_nro_cop, ads004.va_fir_ma1 , ads004.va_fir_ma2, ads004.va_fir_ma3,
	   ads004.va_fir_ma4, ads004.va_for_log, ads004.va_est_ado
FROM ads004, ads003
WHERE (ads004. va_ide_doc = ads003.va_ide_doc)
  AND (ads003.va_ide_mod = @ar_ide_mod)
  AND (ads004.va_est_ado like @va_est_ado )
	
--** Abre cursor		  
OPEN vc_tal_ona    
	 
FETCH NEXT FROM vc_tal_ona INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_tip_tal , @va_nro_aut, @va_for_mat,@va_nro_cop,
								@va_fir_ma1, @va_fir_ma2, @va_fir_ma3,@va_fir_ma4,@va_for_log,@va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del modulo
	SELECT @va_nom_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @ar_ide_mod
	 
	 INSERT INTO #ADS004 VALUES (@ar_ide_mod, @va_nom_mod,@va_ide_doc,@va_nro_tal,@va_nom_tal,
								 @va_tip_tal,@va_nro_aut,@va_for_mat,@va_nro_cop,
								 @va_fir_ma1,@va_fir_ma2,@va_fir_ma3,@va_fir_ma4,@va_for_log,@va_est_ado)
	


	FETCH NEXT FROM vc_tal_ona INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_tip_tal , @va_nro_aut, @va_for_mat,@va_nro_cop,
								@va_fir_ma1, @va_fir_ma2, @va_fir_ma3,@va_fir_ma4,@va_for_log,@va_est_ado	
END	

CLOSE vc_tal_ona
DEALLOCATE vc_tal_ona

SELECT *
FROM #ADS004

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads005_01a_p01.sql
PROCEDIMIENTO: BUSCA NUMERACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	28-05-2020 
--*/

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
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: ads005_05a_p01.sql
PROCEDIMIENTO: CONSULTA NUMERACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	28-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads005_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads005_05a_p01
GO

CREATE PROCEDURE ads005_05a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT,		
								@ar_ges_tio		INT
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
@va_fec_ini		DATETIME,
@va_fec_fin		DATETIME,
@va_nro_ini		INT,
@va_nro_fin		INT,
@va_con_tad		INT


CREATE TABLE #resultado
(
va_ide_doc		CHAR(03),
va_nom_doc		VARCHAR(30),
va_nro_tal		INT,
va_nom_tal		VARCHAR(60),
va_ges_tio		INT,
va_fec_ini		DATETIME,
va_fec_fin		DATETIME,
va_nro_ini		INT,
va_nro_fin		INT,
va_con_tad		INT
)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

	SELECT  @va_ide_doc=ads003.va_ide_doc, 
			@va_nom_doc=ads003.va_nom_doc, 
			@va_nro_tal=ads005.va_nro_tal, 
			@va_ges_tio=ads005.va_ges_tio,
			@va_fec_ini=ads005.va_fec_ini,
			@va_fec_fin=ads005.va_fec_fin,
			@va_nro_ini=ads005.va_nro_ini,
			@va_nro_fin=ads005.va_nro_fin,
			@va_con_tad=ads005.va_con_tad
	FROM ads005, ads003
	WHERE (ads003.va_ide_doc = ads005.va_ide_doc)
	  AND (ads005.va_ges_tio = @ar_ges_tio)
	  AND (ads005.va_ide_doc = @ar_ide_doc)
	  AND (ads005.va_nro_tal = @ar_nro_tal)
	  
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
									@va_fec_ini		,
									@va_fec_fin		,
									@va_nro_ini		,
									@va_nro_fin		,
									@va_con_tad		
									)
	
	SELECT * FROM #resultado

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads006_04a_p01.sql
PROCEDIMIENTO: DESHABILITA TIPO DE USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads006_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads006_04a_p01
GO

CREATE PROCEDURE ads006_04a_p01	@ar_ide_tus		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene USUARIOS Habilitados ligados al TIPO DE USUARIO que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	   FROM ads007 
	  WHERE (va_tip_usr = @ar_ide_tus)
		AND (va_est_ado = 'H')

	--/ Procede a deshabilitar el Tipo de Usuario
	IF(@va_can_tid = 0)
	BEGIN
		UPDATE ads006 SET va_est_ado = 'N'
		WHERE va_ide_tus = @ar_ide_tus
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Deshabilitar, Existen Usuarios Habilitados relacionados con el Tipo de usuario' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads006_06a_p01.sql
PROCEDIMIENTO: ELIMINA TIPO DE USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-07-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads006_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads006_06a_p01
GO

CREATE PROCEDURE ads006_06a_p01	@ar_ide_tus		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene Usuarios ligados al Tipo de Usuario que se quiere Eliminar
	 SELECT @va_can_tid = COUNT(*)
	   FROM ads007 
	  WHERE (va_tip_usr = @ar_ide_tus)

	--/ Procede a Eliminar el Tipo de usuario
	IF(@va_can_tid = 0)
	BEGIN
		DELETE ads006 
		WHERE va_ide_tus = @ar_ide_tus
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Eliminar el Tipo de usuario, Existen Usuarios relacionados con el mismo' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: ads007_01a_p02.sql
PROCEDIMIENTO: VERIFICA CONCURRENCIA USUARIO
			   PARA EDITAR INFORMACION
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_01a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_01a_p02
GO

CREATE PROCEDURE ads007_01a_p02
							@ag_ide_usr NVARCHAR(15)	-- Usuario registro
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_est_ado CHAR(01)		-- Estado del usuario
 
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_ads007
BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr,
		   @va_est_ado = va_est_ado
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('el usuario no se encuentra registrado en la BD.',16,1)
		RETURN
	END
	
	IF(@va_est_ado = 'N')
	BEGIN
		RAISERROR ('el usuario se encuentra Deshabilitado.',16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_01a_p03.sql
PROCEDIMIENTO: VERIFICA CONCURRENCIA USUARIO
			   PARA HABILITAR/DESHABILITAR
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_01a_p03') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_01a_p03
GO

CREATE PROCEDURE ads007_01a_p03
							@ag_ide_usr NVARCHAR(15)	-- Usuario registro
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_est_ado CHAR(01)		-- Estado del usuario
 
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_ads007
BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr,
		   @va_est_ado = va_est_ado
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('el usuario no se encuentra registrado en la BD.',16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_01a_p04.sql
PROCEDIMIENTO: VERIFICA CONCURRENCIA USUARIO
			   PARA CONSULTAR
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_01a_p04') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_01a_p04
GO

CREATE PROCEDURE ads007_01a_p04
							@ag_ide_usr NVARCHAR(15)	-- Usuario registro
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_est_ado CHAR(01)		-- Estado del usuario
 
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_ads007
BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr,
		   @va_est_ado = va_est_ado
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('el usuario no se encuentra registrado en la BD.',16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_01a_p05.sql
PROCEDIMIENTO: VERIFICA CONCURRENCIA USUARIO
			   PARA ELIMINAR
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_01a_p05') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_01a_p05
GO

CREATE PROCEDURE ads007_01a_p05
							@ag_ide_usr NVARCHAR(15)	-- Usuario registro
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_est_ado CHAR(01)		-- Estado del usuario
 
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_ads007
BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr,
		   @va_est_ado = va_est_ado
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El usuario no se encuentra registrado en la BD.',16,1)
		RETURN
	END
	
	IF(@va_est_ado = 'H')
	BEGIN
		RAISERROR ('El usuario esta Habilitado, NO puede ser eliminado.',16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_02a_p01.sql
PROCEDIMIENTO: REGISTRA USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	13-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_02a_p01
GO

CREATE PROCEDURE ads007_02a_p01
							@ag_ide_usr NVARCHAR(15),	-- Usuario registro
							@ag_nom_usr	NVARCHAR(30),	-- Nombre de usuario
							
							@ag_tel_usr	NVARCHAR(15),	-- Telefono usuario
							@ag_car_usr	NVARCHAR(30),	-- Cargo usuario
							@ag_dir_ect	NVARCHAR(30),	-- Directorio de trabajo
													
							@ag_ema_usr NVARCHAR(30),	-- Email usuario
							@ag_win_max INT,			-- Nro ventanas abiertas permitidas al usuario
							@ag_ide_per INT,			-- Codigo persona relacionada con el usuario
							@ag_tip_usr INT,			-- Tipo de usuario (ads006)
							@ag_usr_new	INT				-- 1 = Usuario nuevo ; 0 = usuario creado antes en el motor
						
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg		nvarchar(200),
@contador	INT,
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_nom_usr	NVARCHAR(30),	-- Nombre de usuario
@va_psw_usr	NVARCHAR(30),	-- Contrase¤a por defecto

@va_tel_usr	NVARCHAR(15),	-- Telefono usuario
@va_car_usr	NVARCHAR(30),	-- Cargo usuario
						
@va_ema_usr NVARCHAR(30),	-- Email usuario
@va_win_max INT,			-- Nro ventanas abiertas permitidas al usuario
@va_ide_per INT,			-- Codigo persona relacionada con el usuario
@va_est_ado CHAR(01),		-- Estado usuario (V=habilitado ; N=Deshabilitado)

@va_bas_dto	NVARCHAR(20),	-- Nombre de base de datos

@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_ads007
BEGIN TRY   

	-- Obtiene nombre de base de datos
	SELECT @va_bas_dto = DB_NAME() 
	-- Inicializa contador de registros en 0
	SET @contador = 0

	--Obtiene contrase¤a por defecto de la global (1-1)
	SELECT @va_psw_usr = va_glo_car
	FROM ads013
	WHERE va_ide_mod = 1 AND va_ide_glo = 1
	--Si la global se encuentra vacia, inicializa con una fija
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_psw_usr ='Contra123.' 
	END

	IF (@ag_usr_new = 1 )
	BEGIN 
		 --** Obtiene usuario registrados en el motor
         SELECT @contador = COUNT(*)
           FROM sys.sql_logins
          WHERE name = @ag_ide_usr
      
         IF @contador = 0
         BEGIN      
			--** CREA UN NUEVO LOGIN     
			--** Prepare para Crear Usuario en SLQ2005/SQL2008 cuando no se especifica
			--** la Directiva de Seguridad por defecto esta en 'ON'
			SET @comando = 'CREATE LOGIN [' + RTRIM(@ag_ide_usr) + '] WITH PASSWORD = ''' +   RTRIM(@va_psw_usr) +
								''', DEFAULT_DATABASE = ' + RTRIM(@va_bas_dto)  + 
								 ', DEFAULT_LANGUAGE = spanish , CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF'

			  --** Ejecuta Prepare de Creacion de Login
			EXEC sp_executesql @comando
         END
	END
	
	
	--** CREA USUARIO EN LA BASE DE DATOS
    --** Genera el comando para crear usuario en la base de datos
    SET @comando = 'CREATE USER [' + RTRIM(@ag_ide_usr) + '] FOR LOGIN [' + RTRIM(@ag_ide_usr) + ']'

    --** Ejecuta comando
    EXEC sp_executesql @comando
     
    --** Adiciona al usuario dentro de la funcion de CRS (no hay)
    --EXEC sp_addrolemember 'CRS_usr', @ag_ide_usr
    
	---- Adiciona inicio de sesion a roles del servidor
	EXEC sp_addsrvrolemember  @ag_ide_usr, dbcreator
	EXEC sp_addsrvrolemember  @ag_ide_usr, sysadmin
	EXEC sp_addsrvrolemember  @ag_ide_usr, serveradmin
	
	
	
	
	
	-- Graba en la tabla del sistema (ads007)
	SELECT @va_ide_usr = va_ide_usr
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO ads007 values(	@ag_ide_usr, @ag_nom_usr,
									@ag_tel_usr, @ag_car_usr,
									@ag_dir_ect, @ag_ema_usr,
									@ag_win_max, @ag_ide_per,
									@ag_tip_usr, 'H')
		IF @@ERROR <> 0
		BEGIN
			RAISERROR ('Error al registrar usuario en la tabla.',16,1)
			RETURN
		END
	END
	ELSE
	BEGIN
		RAISERROR ('Ya existe el Usuario que desea crear en la BD.',16,1)
		RETURN
	END
	
	
	
	
--COMMIT TRAN TR_ads007
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_03a_p01.sql
PROCEDIMIENTO: EDITA USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_03a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_03a_p01
GO

CREATE PROCEDURE ads007_03a_p01
							@ag_ide_usr NVARCHAR(15),	-- Usuario registro
							@ag_nom_usr	NVARCHAR(30),	-- Nombre de usuario
							
							@ag_tel_usr	NVARCHAR(15),	-- Telefono usuario
							@ag_car_usr	NVARCHAR(30),	-- Cargo usuario
													
							@ag_dir_ect NVARCHAR(30),	-- Directorio de trabajo
							@ag_ema_usr NVARCHAR(30),	-- Email usuario
							@ag_win_max INT,			-- Nro ventanas abiertas permitidas al usuario
							@ag_ide_per INT				-- Codigo persona relacionada con el usuario
						
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_nom_usr	NVARCHAR(30),	-- Nombre de usuario
@va_psw_usr	NVARCHAR(30),	-- Contrase¤a por defecto

@va_tel_usr	NVARCHAR(15),	-- Telefono usuario
@va_car_usr	NVARCHAR(30),	-- Cargo usuario
						
@va_ema_usr NVARCHAR(30),	-- Email usuario
@va_win_max INT,			-- Nro ventanas abiertas permitidas al usuario
@va_ide_per INT,			-- Codigo persona relacionada con el usuario
@va_est_ado CHAR(01),		-- Estado usuario (V=habilitado ; N=Deshabilitado)
@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_ads007
BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr,
		   @va_est_ado = va_est_ado
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('Error, el usuario no se encuentra registrado en la BD.',16,1)
		RETURN
	END
	
	IF(@va_est_ado = 'N')
	BEGIN
		RAISERROR ('el usuario se encuentra Deshabilitado.',16,1)
		RETURN
	END
	-- Edita cambios en la tabla usuario (ads007)
	UPDATE ads007 SET va_nom_usr = @ag_nom_usr, va_tel_usr = @ag_tel_usr ,
					  va_car_usr = @ag_car_usr, va_dir_ect = @ag_dir_ect,
					  va_ema_usr = @ag_ema_usr,va_win_max = @ag_win_max ,
					  va_ide_per = @ag_ide_per 
	WHERE va_ide_usr = @ag_ide_usr 
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Error al editar el usuario en la tabla.',16,1)
		RETURN
	END
	
	
	
--COMMIT TRAN TR_ads007
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_03b_p01.sql
PROCEDIMIENTO: EDITA CONTRASE¥A USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_03b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_03b_p01
GO

CREATE PROCEDURE ads007_03b_p01
							@ag_ide_usr NVARCHAR(15),	-- Usuario registro
							@ag_new_pss	NVARCHAR(30)	-- Nueva contrase¤a
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_est_ado CHAR(01),		-- Estado usuario (V=habilitado ; N=Deshabilitado)
@va_est_com	CHAR(01),		-- Estado de la ejecucion del comando
@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRY   

	SET @comando = 'ALTER LOGIN [' + RTRIM(@ag_ide_usr) + '] WITH PASSWORD = ''' + RTRIM(@ag_new_pss) + ''''    
      
	--** Ejecuta Prepare de Cambia Pasword
	EXEC @va_est_com = sp_executesql @comando

	IF @va_est_com <> 0
		RAISERROR('No pudo ser cambiada la contrase¤a.', 16, 1)

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_03c_p01.sql
PROCEDIMIENTO: IICIALIZA CONTRASE¥A POR DEFECTO A USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_03c_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_03c_p01
GO

CREATE PROCEDURE ads007_03c_p01
							@ag_ide_usr NVARCHAR(15)	-- Usuario registro
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_est_ado CHAR(01),		-- Estado usuario (V=habilitado ; N=Deshabilitado)
@va_psw_def	VARCHAR(15),		-- Contrase¤a por defecto
@va_est_com	CHAR(01),		-- Estado de la ejecucion del comando
@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRY   

	--Obtiene contrase¤a por defecto de la global (1-1)
	SELECT @va_psw_def = va_glo_car
	FROM ads013
	WHERE va_ide_mod = 1 AND va_ide_glo = 1
	--Si la global se encuentra vacia, inicializa con una fija
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_psw_def ='Contra123.' 
	END


	SET @comando = 'ALTER LOGIN [' + RTRIM(@ag_ide_usr) + '] WITH PASSWORD = ''' + RTRIM(@va_psw_def) + ''''    
      
	--** Ejecuta Prepare de Cambia Pasword
	EXEC @va_est_com = sp_executesql @comando

	IF @va_est_com <> 0
		RAISERROR('La contrase¤a no pudo ser inicializada.', 16, 1)

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_03d_p01.sql
PROCEDIMIENTO: CAMBIA TIPO DE USUARIO AL USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_03d_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_03d_p01
GO

CREATE PROCEDURE ads007_03d_p01
							@ag_ide_usr NVARCHAR(15),	-- Usuario registro
							@ag_ide_tus	NVARCHAR(30)	-- Nuevo tipo de usuario a cambiar
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr NVARCHAR(15),	-- Usuario registro
@va_ide_tus INT,			-- Nuevo tipo de usuario a cambiar
@va_ide_tab NVARCHAR(06),	-- ID. tabla permiso
@va_ide_uno NVARCHAR(15),	-- ID. uno
@va_ide_dos NVARCHAR(15),	-- ID. dos
@va_ide_tre NVARCHAR(15),	-- ID. tres
@va_ide_int INT,			-- ID. numerico
@va_est_ado CHAR(01),		-- Estado usuario (H=habilitado ; N=Deshabilitado)
@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ads008
BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr,
		   @va_est_ado = va_est_ado
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('Error, el usuario no se encuentra registrado en la BD.',16,1)
		RETURN
	END
	
	IF(@va_est_ado = 'N')
	BEGIN
		RAISERROR ('el usuario se encuentra Deshabilitado.',16,1)
		RETURN
	END
	-- Edita cambios en la tabla usuario (ads007)
	UPDATE ads007 SET va_tip_usr = @ag_ide_tus
	WHERE va_ide_usr = @ag_ide_usr 
	
	-- Copia los permisos del tipo de usuario al usuario
	DELETE ads008 
	WHERE va_ide_usr = @ag_ide_usr
	
	--INSERT INTO ads008
	--SELECT * FROM ads009
	--WHERE va_ide_usr = 
	
	DECLARE vc_per_mis CURSOR LOCAL FOR
	SELECT va_ide_tab, va_ide_uno, va_ide_dos, va_ide_tre, va_ide_int FROM ads009
	WHERE va_ide_tus = @ag_ide_tus

	--** Abre cursor		  
	OPEN vc_per_mis
	
	FETCH NEXT FROM vc_per_mis 
	INTO @va_ide_tab,@va_ide_uno,@va_ide_dos,@va_ide_tre,@va_ide_int  
	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		INSERT INTO ads008 VALUES(@ag_ide_usr,@va_ide_tab,@va_ide_uno,@va_ide_dos,@va_ide_tre,@va_ide_int )
		IF @@ERROR <> 0
		BEGIN
			RAISERROR ('Error al copiar los permisos al usuario.',16,1)
			RETURN
		END
		
		FETCH NEXT FROM vc_per_mis 
		INTO @va_ide_tab,@va_ide_uno,@va_ide_dos,@va_ide_tre,@va_ide_int 
		
	END
	
	CLOSE vc_per_mis
	DEALLOCATE vc_per_mis
	
COMMIT TRAN TR_ads008
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads008
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_04a_p01.sql
PROCEDIMIENTO: HABILITA/DESHABILITA USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_04a_p01
GO

CREATE PROCEDURE ads007_04a_p01
							@ag_ide_usr NVARCHAR(15),	-- Usuario registro
							@ag_est_ado	CHAR(01)		-- Estado
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ide_usr		NVARCHAR(15),	-- Usuario registro
@va_ide_tus		INT,			-- ID tipo de usuario
@va_con_reg		INT,
@va_est_ado		CHAR(01)
  
IF @@ERROR <> 0
   RETURN

BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr,
		   @va_ide_tus = va_tip_usr
	FROM ads007
	WHERE va_ide_usr = @ag_ide_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('Error, el usuario no se encuentra registrado en la BD.',16,1)
		RETURN
	END

	-- Edita cambios en la tabla usuario (ads007)
	IF(@ag_est_ado = 'N')
	BEGIN
		-- pregunta si el tipo de usuario esta valido
		SELECT @va_con_reg = COUNT(*),
			   @va_est_ado = va_est_ado
		  FROM ads006
		 WHERE va_ide_tus = @va_ide_tus
		group by va_est_ado
		
		IF(@va_con_reg = 0)
		BEGIN
			RAISERROR ('El tipo de usuario ya no se encuetra registrado.',16,1)
			RETURN
		END
		IF(@va_est_ado  = 'N')
		BEGIN
			RAISERROR ('No puede habilitar al usuario por que el tipo de usuario se encuetra Deshabilitado',16,1)
			RETURN
		END
	
		UPDATE ads007 SET va_est_ado = 'H' 
		WHERE va_ide_usr = @ag_ide_usr 
	END	
	ELSE IF (@ag_est_ado = 'H')
	BEGIN
		UPDATE ads007 SET va_est_ado = 'N' 
		WHERE va_ide_usr = @ag_ide_usr 
	END
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Error al editar el usuario en la tabla.',16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads007_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE USUARIOS
AUTOR:	CREARSIS(chl)
FECHA:	07-04-2020
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_R01
GO

CREATE PROCEDURE ads007_R01 @ag_est_ado CHAR(01)		-- Estado (T=todos ; H=Habilitado ; N=Deshabilitado)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)

IF @@ERROR <> 0
   RETURN


BEGIN TRY	 

IF (@ag_est_ado = 'T')
	SET @ag_est_ado = '%'


	 SELECT *
	   FROM ads007
	  WHERE va_est_ado LIKE @ag_est_ado  

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads008_01a_p01.sql
PROCEDIMIENTO: OBTIENE LAS APLICACIONES AUTORIZADAS
	AL USUARIO
AUTOR:	CREARSIS(JEJR)
FECHA:	20-08-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads008_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads008_01a_p01
GO

CREATE PROCEDURE ads008_01a_p01		@ag_ide_usr VARCHAR(15) WITH ENCRYPTION AS

DECLARE		@va_ide_usr  VARCHAR(15),   --** ID. Usuario
            @va_ide_apl  VARCHAR(06),   --** ID. Aplicaci¢n			
			@va_mod_act  INT,           --** M¢dulo Activado Cifrado
			@va_mod_adm  CHAR(01),      --** M¢dulo de Administrador
			@va_mod_inv  CHAR(01),      --** M¢dulo de Inventario
			@va_mod_com  CHAR(01),      --** M¢dulo de Comercializacion
			@va_mod_res  CHAR(01)       --** M¢dulo de Restaurant


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable 
SET @va_mod_adm = 'N'
SET @va_mod_inv = 'N'
SET @va_mod_com = 'N'
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

--** Obtiene SI tiene licencia sobre el Modulo de Comercializaci¢n
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
	--** Aplicaci¢n: Administrador
	IF (@va_ide_apl = 'ads200' AND 
	    @va_mod_adm = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)		
	END

	--** Aplicaci¢n: Inventario
	IF (@va_ide_apl = 'inv200' AND 
	    @va_mod_inv = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)
	END

	--** Aplicaci¢n: Comercializaci¢n
	IF (@va_ide_apl = 'cmr200' AND 
	    @va_mod_com = 'S')
	BEGIN
		INSERT INTO #tm_apl_aut VALUES (@va_ide_usr, @va_ide_apl)
	END

	--** Aplicaci¢n: Restaurant
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
  
/*
ARCHIVO: ads016_02a_p01.sql
PROCEDIMIENTO: REGISTRA GESTION PERIODO por primera vez
	
AUTOR:	CREARSIS(CHL)
FECHA:	23-03-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_02a_p01
GO

CREATE PROCEDURE ads016_02a_p01
							@ag_ges_tio	INT			,	-- Gestion a¤o
							@ag_per_ini	INT				-- Periodo en el que empezara la gestion
							
							
						
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ges_tio		INT			,	-- Gestion
@va_mes_per		INT			,	-- Mes periodo
@va_con_tad		INT			,	-- Contador de periodos
@va_nom_per		VARCHAR(10)	,	-- Nombre de periodo
@va_pri_dia		DATE		,	-- Primer dia del mes
@va_ult_dia		DATE		,	-- Ultimo dia del mes
@va_fec_aux		DATE		,	-- Fecha auxiliar
@va_ide_doc		CHAR(03)	,	-- Ide del docuento
@va_nro_tal		INT			,	-- Numero del talonario

@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ads016
BEGIN TRY   
	
	CREATE TABLE #MES
	(
		va_ide_mes		INT,
		va_nom_mes		VARCHAR(10)
	)
	INSERT INTO #MES VALUES (1,'Enero')
	INSERT INTO #MES VALUES (2,'Febrero')
	INSERT INTO #MES VALUES (3,'Marzo')
	INSERT INTO #MES VALUES (4,'Abril')
	INSERT INTO #MES VALUES (5,'Mayo')
	INSERT INTO #MES VALUES (6,'Junio')
	INSERT INTO #MES VALUES (7,'Julio')
	INSERT INTO #MES VALUES (8,'Agosto')
	INSERT INTO #MES VALUES (9,'Septiembre')
	INSERT INTO #MES VALUES (10,'Octubre')
	INSERT INTO #MES VALUES (11,'Noviembre')
	INSERT INTO #MES VALUES (12,'Diciembre')
	

	SET @va_ges_tio = @ag_ges_tio
	SET @va_mes_per = @ag_per_ini
	
	--Verifica que sea la primer gestion que se cr‚e
	SELECT *
	FROM ads016
	IF @@ROWCOUNT <> 0
	BEGIN
		RAISERROR ('Esta opcion es solo para crear la gestion por primera vez, ya hay gestion creada',16,1)
		Rollback TRAN TR_ads016
		RETURN
	END


	
	--Obtiene el mes (periodo) en el que iniciara la gestion
	SET @va_con_tad = 1
	
	WHILE (@va_con_tad <= 12)
	BEGIN
		--Obtiene el primer dia del mes
		SET @va_pri_dia = '01/' + CONVERT(VARCHAR(02),@va_mes_per)+'/' + CONVERT(VARCHAR(04),@va_ges_tio) --CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@mydate)-1),@mydate),101)
		
		--Obtiene Ultimo Dia
		if (@va_mes_per <> 12)
		BEGIN
			SET @va_fec_aux = '01/'+ CONVERT(VARCHAR(02),@va_mes_per + 1)+ '/' + CONVERT(VARCHAR(04),@va_ges_tio)
			SET @va_ult_dia = CONVERT(DATE,DATEADD(DAY,-1,@va_fec_aux),101)
		END
		
		if (@va_mes_per = 12)
		BEGIN
			
			SET @va_fec_aux = '01/'+ CONVERT(VARCHAR(02),1)+ '/' + CONVERT(VARCHAR(04),@va_ges_tio + 1)
			SET @va_ult_dia = CONVERT(DATE,DATEADD(DAY,-1,@va_fec_aux),101) 
		END
		
		--Obtiene nombre del periodo
		SELECT @va_nom_per = va_nom_mes
		FROM #MES
		WHERE va_ide_mes = @va_mes_per
		
		--** Registra la Gestion/Periodo
		INSERT INTO ads016 VALUES (@ag_ges_tio,@va_con_tad,@va_nom_per,@va_pri_dia , @va_ult_dia)
		
		
		--Incrementa contadores
		if (@va_mes_per <> 12)
		BEGIN
			SET @va_mes_per = @va_mes_per + 1
		END
		ELSE IF (@va_mes_per = 12)
		BEGIN
			SET @va_mes_per = 1
			SET @va_ges_tio = @va_ges_tio + 1
		END
			
		SET @va_con_tad = @va_con_tad + 1
	END
	
	
		--Crea cursor para los talonarios
	DECLARE vc_tal_doc CURSOR LOCAL FOR
	SELECT va_ide_doc, va_nro_tal
	FROM ads004
	ORDER BY va_ide_doc ,va_nro_tal asc
	
	--** Abre cursor		  
	OPEN vc_tal_doc    
		 
	FETCH NEXT FROM vc_tal_doc INTO @va_ide_doc, @va_nro_tal

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF (@va_nro_tal = 0)
		BEGIN
			--** Registra los numeradores de los talonarios para la gestion 
			
			SELECT @va_pri_dia = MIN(va_fec_ini) , 
				   @va_ult_dia = MAX(va_fec_fin)  
			  FROM ads016
			  
			INSERT INTO ads005 VALUES (@va_ide_doc,@va_nro_tal,@ag_ges_tio,@va_pri_dia,@va_ult_dia,0,999999,0)
			
		END 
		
		IF (@va_nro_tal <> 0)
		BEGIN
			SELECT @va_pri_dia = MIN(va_fec_ini) , 
				   @va_ult_dia = MAX(va_fec_fin)  
			  FROM ads016
			 WHERE va_ges_per = @va_nro_tal
			 
			INSERT INTO ads005 VALUES (@va_ide_doc,@va_nro_tal,@ag_ges_tio,@va_pri_dia,@va_ult_dia,0,999999,0)
		END
		
		-- Pasa al siguiente registro del talonario
		FETCH NEXT FROM vc_tal_doc INTO @va_ide_doc, @va_nro_tal
		
	END	
	
CLOSE vc_tal_doc
DEALLOCATE vc_tal_doc
	
COMMIT TRAN TR_ads016
RETURN
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads016
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads016_02b_p01.sql
PROCEDIMIENTO: REGISTRA GESTION PERIODO por primera vez
	
AUTOR:	CREARSIS(CHL)
FECHA:	23-03-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_02b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_02b_p01
GO

CREATE PROCEDURE ads016_02b_p01
							@ag_ges_tio	INT			
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_ges_tio		INT			,	-- Gestion
@va_ges_per		INT			,	-- Periodo de la gestion
@va_nom_per		VARCHAR(10)	,	-- Nombre de periodo
@va_fec_ini		DATE		,	-- Primer dia del mes
@va_fec_fin		DATE		,	-- Ultimo dia del mes
@va_ide_doc		CHAR(03)	,	-- Ide del docuento
@va_nro_tal		INT			,	-- Numero del talonario

@comando	NVARCHAR(200)	-- Comando para ejecutar sentencia sql
  
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ads016
BEGIN TRY   

	--Crea cursor de la gestion anterior a la que se esta creando
	DECLARE vc_ges_tio CURSOR LOCAL FOR
	SELECT va_ges_tio, va_ges_per, va_nom_per, va_fec_ini, va_fec_fin 
	FROM ads016
	WHERE va_ges_tio = @ag_ges_tio -1
	
	--** Abre cursor		  
	OPEN vc_ges_tio    
		 
	FETCH NEXT FROM vc_ges_tio INTO @va_ges_tio, @va_ges_per, @va_nom_per, @va_fec_ini , @va_fec_fin

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		--** incrementa un a¤o a las fechas y gestion de los numeradores
		SET @va_fec_ini = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_ini),101) 
		SET @va_fec_fin = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_fin),101) 
		  
		INSERT INTO ads016 VALUES (@ag_ges_tio,@va_ges_per,@va_nom_per,@va_fec_ini,@va_fec_fin)
		
		-- Pasa al siguiente registro
		FETCH NEXT FROM vc_ges_tio INTO @va_ges_tio, @va_ges_per, @va_nom_per, @va_fec_ini , @va_fec_fin
	END	
	
	CLOSE vc_ges_tio
	DEALLOCATE vc_ges_tio
	
	--******************************************************************************************
	
	--Crea cursor con los Numeradores de la gestion anterior a la que se esta creando
	DECLARE vc_tal_num CURSOR LOCAL FOR
	SELECT va_ide_doc, va_nro_tal, va_ges_tio,va_fec_ini, va_fec_fin
	FROM ads005
	WHERE va_ges_tio = @ag_ges_tio -1
	ORDER BY va_ide_doc ,va_nro_tal asc
	
	--** Abre cursor		  
	OPEN vc_tal_num    
		 
	FETCH NEXT FROM vc_tal_num INTO @va_ide_doc, @va_nro_tal, @va_ges_tio,@va_fec_ini , @va_fec_fin

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		--** incrementa un a¤o a las fechas y gestion de los numeradores
		SET @va_fec_ini = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_ini),101) 
		SET @va_fec_fin = CONVERT(DATE,DATEADD(YEAR,1,@va_fec_fin),101) 
		  
		INSERT INTO ads005 VALUES (@va_ide_doc,@va_nro_tal,@ag_ges_tio,@va_fec_ini,@va_fec_fin,0,999999,0)
		
		-- Pasa al siguiente registro del numerador
		FETCH NEXT FROM vc_tal_num INTO @va_ide_doc, @va_nro_tal, @va_ges_tio,@va_fec_ini , @va_fec_fin
	END	
	
CLOSE vc_tal_num
DEALLOCATE vc_tal_num


	
COMMIT TRAN TR_ads016
RETURN
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + 
	ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads016
	RETURN
END CATCH	

GO  
/*
ARCHIVO: ads016_R01.sql
PROCEDIMIENTO: PERIODOS DE UNA GESTION
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-03-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_R01
GO

CREATE PROCEDURE ads016_R01
							@ag_ges_tio	INT			
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

	SELECT *
	FROM ads016
	WHERE va_ges_tio = @ag_ges_tio
	
GO
	  
/*
ARCHIVO: ads016_R02.sql
PROCEDIMIENTO: LISTA DE GESTIONES
	
AUTOR:	CREARSIS(CHL)
FECHA:	02-04-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_R02') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_R02
GO

CREATE PROCEDURE ads016_R02		
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

	SELECT *
	FROM ads016
	
GO
	  
/*
ARCHIVO: cmr001_01a_p01.sql
PROCEDIMIENTO: BUSCA LSITA DE PRECIOS PERMITIDAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	19-02-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr001_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr001_01a_p01
GO

CREATE PROCEDURE cmr001_01a_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = ide doc , 1=Nombre Doc, 2=Nombre Talonario)
									@ar_est_ado		CHAR(01)		-- Estado (H= Habilitado; N= deshabilitado
									 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

-- Prepara criterio estado
IF @ar_est_ado = 'T'
	SET @va_est_ado = '%'
ELSE
	SET @va_est_ado = @ar_est_ado


IF(@ar_cri_bus = 0)	-- busca por codigo
BEGIN
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_fec_ini, 
		   cmr001.va_fec_fin, cmr001.va_mon_lis, cmr001.va_est_ado
	FROM cmr001
	WHERE (cmr001.va_cod_lis LIKE @ar_tex_bus + '%')
	AND	  (cmr001.va_est_ado LIKE @va_est_ado)
END

IF(@ar_cri_bus = 1)	-- busca por nombre
BEGIN
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_fec_ini, 
		   cmr001.va_fec_fin, cmr001.va_mon_lis, cmr001.va_est_ado
	FROM cmr001
	WHERE (cmr001.va_nom_lis LIKE @ar_tex_bus + '%' )
	AND	  (cmr001.va_est_ado LIKE @va_est_ado)
END

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: cmr001_01b_p01.sql
PROCEDIMIENTO: BUSCA LSITA DE PRECIOS PERMITIDAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	19-02-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr001_01b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr001_01b_p01
GO

CREATE PROCEDURE cmr001_01b_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = ide doc , 1=Nombre Doc, 2=Nombre Talonario)
									@ar_est_ado		CHAR(01)		-- Estado (H= Habilitado; N= deshabilitado
									 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

-- Prepara criterio estado
IF @ar_est_ado = 'T'
	SET @va_est_ado = '%'
ELSE
	SET @va_est_ado = @ar_est_ado


IF(@ar_cri_bus = 0)	-- busca por codigo
BEGIN
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_fec_ini, 
		   cmr001.va_fec_fin, cmr001.va_mon_lis, cmr001.va_est_ado
	FROM cmr001, ads008
	WHERE (cmr001.va_cod_lis = RTRIM(ads008.va_ide_uno))
	AND	  (ads008.va_ide_tab = 'cmr001')
	AND   (ads008.va_ide_usr = SYSTEM_USER)
	AND	  (cmr001.va_cod_lis LIKE @ar_tex_bus + '%')
	AND	  (cmr001.va_est_ado LIKE @va_est_ado)
END

IF(@ar_cri_bus = 1)	-- busca por nombre
BEGIN
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_fec_ini, 
		   cmr001.va_fec_fin, cmr001.va_mon_lis, cmr001.va_est_ado
	FROM cmr001, ads008
	WHERE (cmr001.va_cod_lis = RTRIM(ads008.va_ide_uno))
	AND   (ads008.va_ide_usr = SYSTEM_USER)
	AND	  (ads008.va_ide_tab = 'cmr001')
	AND	  (cmr001.va_nom_lis LIKE @ar_tex_bus + '%' )
	AND	  (cmr001.va_est_ado LIKE @va_est_ado)
END

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: cmr002_01a_p01.sql
PROCEDIMIENTO: BUSCA LSITA DE PRECIOS PERMITIDAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	20-02-2021 
*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr002_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr002_01a_p01
GO

CREATE PROCEDURE cmr002_01a_p01		@ar_cod_pro		VARCHAR(15),	-- Texto a ser buscado
									@ar_lis_ini		INT,			-- Criterio (0 = ide doc , 1=Nombre Doc, 2=Nombre Talonario)
									@ar_lis_fin		INT				-- Estado (H= Habilitado; N= deshabilitado
									 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01),
@va_cod_lis		INT,
@va_nom_lis		VARCHAR(30),
@va_mon_lis		CHAR(01),
@va_pre_cio		DECIMAL(10,5),
@va_pmx_des		DECIMAL(4,2),
@va_pmx_inc		DECIMAL(4,2),
@va_nro_dec		INT

CREATE TABLE #RESULTADO
(
va_cod_lis		INT,
va_nom_lis		VARCHAR(30),
va_mon_lis		CHAR(01),
va_pre_cio		DECIMAL(10,5),
va_pmx_des		DECIMAL(4,2),
va_pmx_inc		DECIMAL(4,2),
va_nro_dec		INT
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 


DECLARE vc_pre_cio CURSOR LOCAL FOR
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_mon_lis, cmr001.va_nro_dec
	FROM cmr001, ads019
	WHERE (cmr001.va_cod_lis = ads019.va_cod_lis)
	AND   (cmr001.va_cod_lis BETWEEN @ar_lis_ini AND @ar_lis_fin)
	AND   (ads019.va_ide_usr = SYSTEM_USER)
	AND	  (cmr001.va_est_ado = 'H')

OPEN vc_pre_cio
FETCH NEXT FROM vc_pre_cio INTO @va_cod_lis, @va_nom_lis,@va_mon_lis, @va_nro_dec

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_pre_cio = 0
	SET @va_pmx_des = 0
	SET @va_pmx_inc = 0

	-- Obtiene precio del producto
	SELECT @va_pre_cio = va_pre_cio,
		   @va_pmx_des = va_pmx_des,
		   @va_pmx_inc = va_pmx_inc
	  FROM cmr002
	 WHERE va_cod_pro = @ar_cod_pro
	   AND va_cod_lis = @va_cod_lis
	   
	--IF(@@ERROR <> 0)
	--BEGIN
	--	SET @va_pre_cio = 0
	--	SET @va_pmx_des = 0
	--	SET @va_pmx_inc = 0
	--END   
	   
	 
	INSERT INTO #resultado VALUES (@va_cod_lis		,
									@va_nom_lis		,
									@va_mon_lis		,
									@va_pre_cio		,
									@va_pmx_des		,
									@va_pmx_inc		,
									@va_nro_dec
									)
	FETCH NEXT FROM vc_pre_cio INTO @va_cod_lis, @va_nom_lis,@va_mon_lis, @va_nro_dec
END	

CLOSE vc_pre_cio
DEALLOCATE vc_pre_cio

SELECT *
  FROM #RESULTADO



RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: cmr002_05b_p01.sql
PROCEDIMIENTO: CONSULTA PRECIO EN VARIAS LISTAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	21-01-2021 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr002_05b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr002_05b_p01
GO

CREATE PROCEDURE cmr002_05b_p01	@ar_cod_pro		VARCHAR(15),
								@ar_lis_ini		INT,
								@ar_lis_fin		INT WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)	,	-- Mensaje
@va_cod_pro		VARCHAR(15)		,	-- Codigo producto
@va_nom_pro		VARCHAR(80)		,	-- Nombre producto
@va_cod_umd		CHAR(03)		,	-- Unidad de medida
@va_und_vta		CHAR(03)		,	-- Unidad de medida de venta
@va_cod_lis		INT				,	-- Codigo/Numero de lista de precio  
@va_nom_lis		VARCHAR(30)		,	-- Nombre de lista de precio
@va_mon_lis		CHAR(01)		,	-- Moneda de lista de precio
@va_pre_cio		DECIMAL(10,5)	,	-- Precio
@va_pmx_des		DECIMAL(4,2)	,	-- Porcentaje maximo de descuento
@va_pmx_inc		DECIMAL(4,2)		-- Porcentaje maximo de incremento

CREATE TABLE #CMR002
(
va_cod_pro		VARCHAR(15)		,	-- Codigo de producto
va_nom_pro		VARCHAR(80)		,	-- Nombre de producto
va_cod_umd		CHAR(03)		,	-- Unidad de medida
va_und_vta		CHAR(03)		,	-- Unidad de venta
va_cod_lis		INT				,	-- Numero de lista de precio
va_nom_lis		VARCHAR(30)		,	-- Nombre de lista de precio				
va_mon_lis		VARCHAR(30)		,	-- Moneda de lista de precio
va_pre_cio		DECIMAL(10,5)	,	-- Precio
va_pmx_des		DECIMAL(10,5)	,	-- Porcentaje maximo de descuento
va_pmx_inc		DECIMAL(10,5)		-- Porcentaje maximo de incremento				
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

DECLARE vc_pre_cio CURSOR LOCAL FOR
select inv004.va_cod_pro, inv004.va_nom_pro, inv004.va_cod_umd, inv004.va_und_vta,
	   cmr002.va_cod_lis, cmr002.va_pre_cio, cmr002.va_pmx_des, cmr002.va_pmx_inc
	from inv004 , cmr002
	where (inv004.va_cod_pro = cmr002.va_cod_pro)	AND
		  (inv004.va_cod_pro = @ar_cod_pro)			AND
		  (cmr002.va_cod_lis BETWEEN @ar_lis_ini AND @ar_lis_fin)	
		  	
--** Abre cursor		  
OPEN vc_pre_cio    
	 
FETCH NEXT FROM vc_pre_cio INTO @va_cod_pro, @va_nom_pro, @va_cod_umd, @va_und_vta,
								@va_cod_lis, @va_pre_cio, @va_pmx_des, @va_pmx_inc

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre de lista de precio
	SELECT @va_nom_lis = va_nom_lis, @va_mon_lis = va_mon_lis
	  FROM cmr001
	 WHERE va_cod_lis = @va_cod_lis
	 
	 INSERT INTO #CMR002 VALUES (@va_cod_pro, @va_nom_pro, @va_cod_umd, @va_und_vta,
								@va_cod_lis,@va_nom_lis,@va_mon_lis, @va_pre_cio, @va_pmx_des, @va_pmx_inc)
	


	FETCH NEXT FROM vc_pre_cio INTO @va_cod_pro, @va_nom_pro, @va_cod_umd, @va_und_vta,
									@va_cod_lis, @va_pre_cio, @va_pmx_des, @va_pmx_inc	
END	

CLOSE vc_pre_cio
DEALLOCATE vc_pre_cio

SELECT *
FROM #CMR002

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: cmr004_01a_p01.sql
PROCEDIMIENTO: BUSCA PLANTILLA DE VENTA
	
AUTOR:	CREARSIS(CHL)
FECHA:	28-10-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr004_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr004_01a_p01
GO

CREATE PROCEDURE cmr004_01a_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01)		-- Estado (H = Habilitado, N=Deshabilitado)
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_plv		INT,
@va_nom_plv		NVARCHAR(30),
@va_des_plv		NVARCHAR(120),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_plv		INT,
va_nom_plv		NVARCHAR(30),
va_des_plv		NVARCHAR(120),
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'

IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM cmr004
	WHERE va_cod_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM cmr004
	WHERE va_nom_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM cmr004
	WHERE va_des_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
  
OPEN vc_pla_vta
FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	
	 INSERT INTO #resultado VALUES (@va_cod_plv		,
									@va_nom_plv		,
									@va_des_plv		,
									@va_est_ado	
									)
	
	
	FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado
END	

SELECT * FROM #resultado

CLOSE vc_pla_vta
DEALLOCATE vc_pla_vta

	
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: cmr004_01b_p01.sql
PROCEDIMIENTO: BUSCA PRODUCTO ABM
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr004_01b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr004_01b_p01
GO

CREATE PROCEDURE cmr004_01b_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01)		-- Estado (H = Habilitado, N=Deshabilitado)
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_plv		INT,
@va_nom_plv		NVARCHAR(30),
@va_des_plv		NVARCHAR(120),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_plv		INT,
va_nom_plv		NVARCHAR(30),
va_des_plv		NVARCHAR(120),
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'

IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM cmr004
	WHERE va_cod_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
		  
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM cmr004
	WHERE va_nom_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
		 
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM cmr004
	WHERE va_des_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
  
OPEN vc_pla_vta
FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado
WHILE (@@FETCH_STATUS = 0)
BEGIN

	 --// plantilla de ventas permitidas al usuario
	 SELECT @cout = COUNT(*)
	 FROM	ads008
	 WHERE	va_ide_usr = SYSTEM_USER	AND
		    va_ide_tab = 'cmr004' AND 
			RTRIM(va_ide_uno) = @va_cod_plv

	IF @cout <> 0
	BEGIN 
	 INSERT INTO #resultado VALUES (@va_cod_plv		,
									@va_nom_plv		,
									@va_des_plv		,
									@va_est_ado	
									)
	END
	
	FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado
END	

SELECT * FROM #resultado

CLOSE vc_pla_vta
DEALLOCATE vc_pla_vta

	
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: cmr005_01a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO BUSCA VENTAS
AUTOR:	CREARSIS(chl)
FECHA:	19-01-2019
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_01a_p01
GO

CREATE PROCEDURE cmr005_01a_p01 @ar_cod_cli INT,			-- codigo cliente
							@ar_cod_bod CHAR(06),			-- Almacen
							@ar_fec_ini DATE,				-- Fecha de inicial
							@ar_fec_fin DATE,				-- Fecha de final
							@ar_tex_bus NVARCHAR(200),		-- Texto a buscar
							@ar_par_bus INT,				-- parametro Busqueda (0=Razon Social venta; 1 = Observaciones)
							@ar_est_ado CHAR(01),			-- Estado (T=todos ; H=valido ; N=anulado)
							@ar_tip_doc CHAR(01)			-- Tipo documento (V=Venta; C=Cotizacion; F=Factura)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_cli_ini		INT,
@va_cli_fin		INT,
@va_bod_ini		CHAR(06),
@va_bod_fin		CHAR(06)

IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
 
 PRINT @ar_cod_bod
IF (@ar_cod_bod = '0')
BEGIN	
	SET @va_bod_ini = '0'
	SET @va_bod_fin = '99-999'
END
IF (@ar_cod_bod <> '0')
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
END


IF (@ar_cod_cli = 0)
BEGIN	

	SET @va_cli_ini = 0
	SET @va_cli_fin = 9999999
END
IF (@ar_cod_cli <> 0)
BEGIN	
	SET @va_cli_ini = @ar_cod_cli
	SET @va_cli_fin = @ar_cod_cli
END



IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'

IF @ar_tip_doc = 'F'
BEGIN
	IF(@ar_par_bus = 0)	 -- Busca por Razon Social venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM cmr005
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 1) AND
			   va_raz_soc  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	IF(@ar_par_bus = 1)	 -- Busca por Observacion venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM cmr005
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 1) AND
			   va_obs_vta  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	
END

IF @ar_tip_doc = 'V'
BEGIN
IF(@ar_par_bus = 0)	 -- Busca por Razon Social venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM cmr005
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 2) AND
			   va_raz_soc  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	IF(@ar_par_bus = 1)	 -- Busca por Observacion venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM cmr005
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 2) AND
			   va_obs_vta  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END 
END

--IF @ar_tip_doc = 'C'
--BEGIN
	-- SELECT va_fec_cot AS va_fec_vta, va_ide_cot AS va_ide_vta, va_nro_cot AS va_nro_vta, 
	--		va_cod_per, va_raz_soc, va_mon_cot AS va_mon_vta, va_tot_vtB, va_tot_vtU, 
	--		va_est_ado, va_obs_cot AS va_obs_vta, va_ges_cot AS va_ges_vta
	-- FROM cmr007
	--WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
	--	  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
	--	  (va_fec_cot BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	--	   va_obs_cot  LIKE @ar_tex_bus + '%'	AND
	--	   va_est_ado LIKE @ar_est_ado  
--END


	

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: cmr005_02a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO REGISTRA VENTA
	(venta, suma existencia, kardex, 
	registra movimiento efectivo/CxC )
AUTOR:	CREARSIS(chl)
FECHA:	12-10-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_02a_p01
GO

CREATE PROCEDURE cmr005_02a_p01 --@ar_cod_usr NVARCHAR(15),	-- Usuario registro
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal
							
							@ar_pla_vta	INT,			-- Plantilla de Venta
							@ar_tip_vta	INT,			-- Tipo de operacion 
													-- ( 1=Factura; 2=Nota de Venta;  
							@ar_cod_bod CHAR(06),		-- Bodega
							@ar_cod_cli INT,			-- codigo Cliente
							@ar_nit_cli	NVARCHAR(20),	-- Nit del cliente
							@ar_raz_soc	NVARCHAR(100),	-- Razon Social del cliente
							@ar_mon_vta CHAR(01),		-- Moneda de venta (B=Bs ; U=Us )
							@ar_fec_vta DATE,			-- Fecha de venta
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_ven_ded	INT,			-- Vendedor de la venta
							@ar_lis_pre	INT,			-- Lista de precio usada en la venta
							@ar_cod_caj INT,			-- Codigo de caja
							@ar_lin_cxc INT,			-- Linea Cta. x Cob. (codigo de libro)
							
							@ar_tip_cam	DECIMAL(7,5),	-- Tipo de cambio
							@ar_des_cue DECIMAL(10,2),	-- Descuento General
							@ar_obs_vta NVARCHAR(200),  -- Observacion
							@ar_vta_par CHAR(01)	,	-- Venta para (M=Mesa; L=Llevar; D=Delivery)
							@ar_cod_del	INT			,	-- Codigo Delivery
							
							@ar_ref_vta NVARCHAR(20),	-- Referecia del documento
							@ar_mto_efe DECIMAL(16,5),	-- Monto cancelado en la moneda del documento
							@ar_cam_bio	DECIMAL(16,5),	-- Cambio en la moneda del documento
							@ar_nro_aut	VARCHAR(20)		-- Numero de autorizacion/Dosificacion 
														
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),

@va_ide_doc		CHAR(03),
@va_nro_tal		INT,
@va_nro_tal_tmp	INT,			-- Numero de talonario temporal para obtener formato

@va_nro_vta		INT,			-- Numero de del documento
@va_nro_vta_tmp INT,
@va_ide_vta		VARCHAR(20),	--Identificador de la venta (XXX|000-00000)
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 

@va_opc_und		INT,			--Opcion de unidad de medida seleccionado
@va_und_umd		CHAR(03),		--Unidad de medida inventario del producto
@va_und_vta		CHAR(03),		--Unidad de medida de venta del producto
@va_can_uin		DECIMAL(14,4),	--Cantidad inventario de producto
@va_can_vta		DECIMAL(14,4),	--Cantidad de producto
@va_eqv_vta		DECIMAL(7,3),	-- Equivalencia entre @va_und_vta y @va_und_umd
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario de item en la moneda del documento
@va_pre_tot		DECIMAL(16,2),	--Precio Total de item en la moneda del documento
@va_des_cue		DECIMAL(16,2),	--Descuento del item en moneda de la venta
@va_pre_lis		DECIMAL(16,2),	--Precio de la lista de precio del item en moneda de la venta
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_cod_fam		VARCHAR(15),	-- Codigo de familida a la que pertenece el producto
@va_tip_fam		CHAR(01),		-- Tipo de familia 

@va_tot_bBs		DECIMAL(16,2),	-- Total bruto del documento en Bs
@va_tot_bUs		DECIMAL(16,2),	-- Total bruto del documento en Us
@va_des_cBs		DECIMAL(16,2),	-- Descuento global al documento en Bs.
@va_des_cUs		DECIMAL(16,2),	-- Descuento global al documento en Us.
@va_tot_nBs		DECIMAL(16,2),	-- Total neto del documento en Bs.
@va_tot_nUs		DECIMAL(16,2),	-- total neto del documento en Us.

@va_pre_uBs		DECIMAL(16,2),	-- Precio unitario en Bs
@va_pre_uUs		DECIMAL(16,2),	-- Precio unitario en Us.
@va_pre_tBs		DECIMAL(16,2),	-- Precio total en Bs.
@va_pre_tUs		DECIMAL(16,2),	-- precio total en Us.
@va_dto_uBs		DECIMAL(16,2),	-- Descueto lineal unitario en Bs.
@va_dto_uUs		DECIMAL(16,2),	-- Descueto lineal unitario en Us.
@va_por_ite		DECIMAL(16,2),	-- Porcentaje lineal unitario

@va_con_tad		INT,			-- Contador para validar

--// Valores para prorratear descuento global del documento sobre los items
@va_por_cen		DECIMAL(16,5),	-- Porcentaje de descuento unitario
@va_des_uni		DECIMAL(16,2),	-- Valor de descuento unitario
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),	-- Descuento acumulado para calculo
@va_pmx_des		DECIMAL(16,2),	-- Porcentaje Descuento permitido segun lista de precio
@va_pmx_inc		DECIMAL(16,2),	-- Porcentaje Incremento permitido segun lista de precio

-- VARIABLES PARA CALCULO DE COSTOS
@va_sal_can		DECIMAL(14,2),	--Saldo stock actual EN UNIDAD DE MEDIDA INVENTARIO
@va_cos_ubs		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Bs)
@va_cos_uus		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Us)

@va_iva_uBs		DECIMAL(14,6),	--Iva unitario por item en Bs
@va_iva_uUs		DECIMAL(14,6),	--Iva unitario por item en Us
@va_itr_uBs		DECIMAL(14,6),	--ITr unitario por item en Bs
@va_itr_uUs		DECIMAL(14,6),	--ITr unitario por item en Us


-- variables para gestion
@va_ges_vta		INT,
@va_ges_tio		INT,
@va_ges_per		INT,
@va_fec_ini		DATE, 
@va_fec_fin		DATE,

@va_fec_exp		DATE,			-- Fecha de expiracion de la libreta de  la persona
@va_sal_act		DECIMAL(16,2),	-- Saldo actual de la libreta de la persona
@va_mto_lim		DECIMAL(16,2),	-- monto limite autorizado en la libreta de la persona

@va_sal_aut		DECIMAL(16,2),	-- Saldo autorizado de credito (@va_mto_lim - @va_sal_act)
@va_mon_lib		CHAR(01),		-- Moneda de la libreta

@va_stk_act		DECIMAL(16,4),	-- ESTOCK ACTUAL DEL PRODUCTO OBTENIDO DEL PROCEDIMIENTO (inv100_01p2)
@va_prd_vta		INT			 ,	-- Periodo de la venta
@va_cod_bod		INT			 ,	-- Codigo de bodega en  INT
@va_por_del		DECIMAL (3,1)	-- Porcentaje correspondiente al delivery

		
	
--** CREA TABLA TEMPORAL
CREATE TABLE #tm_vta001(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_pre_lis		DECIMAL(16,2),				--Precio de lista en la moneda del documento
	va_des_cue		DECIMAL(16,2),				--Descuento en la moneda del documento
	va_por_cen		DECIMAL(16,2) 				--Pocentaje de descuento
	
   )
   
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_vta001
BEGIN TRY     
  
  SET @va_cod_usr = SYSTEM_USER
  
   -- Carga temporal de venta
   INSERT INTO #tm_vta001
	SELECT * FROM cmr006tmp
	WHERE va_cod_tmp = @ar_cod_tmp AND
		  va_cod_usr = @va_cod_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('No hay ningun item para la venta',16,1)
		RETURN
	END

	
	-- Verifica plantilla de venta
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	FROM cmr004
	WHERE va_cod_plv = @ar_pla_vta
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Plantilla de Venta no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Plantilla de Venta se encuentra Deshabilitada',16,1)
		RETURN
	END	
	
	--// Obtiene documento de venta de la plantilla
	IF(@ar_tip_vta = 1) --FACTURA
	BEGIN
		SELECT @va_ide_doc = va_doc_fac,
			   @va_nro_tal = va_tal_fac
		 FROM cmr004
		WHERE (va_cod_plv = @ar_pla_vta)
	END
	IF(@ar_tip_vta = 2) --NOTA DE VENTA
	BEGIN
		SELECT @va_ide_doc = va_doc_ntv,
			   @va_nro_tal = va_tal_ntv
		 FROM cmr004
		WHERE (va_cod_plv = @ar_pla_vta)
	END
	
	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @va_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado
	 FROM ads004
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal
		   
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	
		SELECT	--@va_est_ado = va_est_ado,
				@va_ges_vta = va_ges_tio,
				@va_prd_vta = va_ges_per,
				@va_fec_ini = va_fec_ini,
				@va_fec_fin = va_fec_fin
		  FROM	ads016
		 WHERE	(@ar_fec_vta BETWEEN va_fec_ini AND va_fec_fin)
		 
		  
		
 IF (@va_ges_vta = 0)
 BEGIN
	RAISERROR ('la fecha del documento no se encuentra dentro de una gestion definida',16,1)
	RETURN
 END
/*
 IF (@va_est_ado = 'C')
 BEGIN
	RAISERROR ('la fecha del documento se encuentra dentro de un periodo cerrado',16,1)
	RETURN
 END
*/
		
--// Verifica Numeracion / inicialilza fechas iniciales para numeracion
	SET @va_fec_ini = '01.01.1990'
	SET @va_fec_fin = '01.01.1990'
	
	SELECT @va_nro_vta = va_con_tad,
		   @va_fec_ini = va_fec_ini,
		   @va_fec_fin = va_fec_fin
	FROM ads005
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal AND
		  va_ges_tio = @va_ges_vta
	IF @@ROWCOUNT = 0
	BEGIN
		
	    SET @msg = 'El Talonario NO dispone de numeracion para la gestion ' + CAST (@va_ges_vta AS VARCHAR(3))
		RAISERROR ( @msg ,16,1)
		RETURN
	END
	
	IF NOT (@ar_fec_vta > @va_fec_ini AND @ar_fec_vta < @va_fec_fin)
	BEGIN
		RAISERROR ('La fecha del documento no esta dentro del rango permitido en la numeracion para la gestion',16,1)
		RETURN
	END	
	
	--// Verifica Bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Bodega no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Bodega se encuentra Deshabilitada',16,1)
		RETURN
	END
	
	
	--// Verifica CLIENTE
	SELECT @va_est_ado = va_est_ado
	FROM cmr013
	WHERE va_cod_per = @ar_cod_cli
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Cliente no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Cliente se encuentra Deshabilitado',16,1)
		RETURN
	END

	/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	--// Verifica LISTA DE PRECIO
	SELECT @va_est_ado = va_est_ado
	FROM cmr001
	WHERE va_cod_lis = @ar_lis_pre
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Lista de Precio no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Lista de Precio se encuentra Deshabilitada',16,1)
		RETURN
	END

/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	
	--Suma en uno el contador de venta
	SET @va_nro_vta = @va_nro_vta + 1
	
	
	SET @va_nro_tal_tmp = 1000 + @va_nro_tal
	SET @va_nro_vta_tmp = 1000000 + @va_nro_vta
	
	--Prepara identificador de la venta XXX-000-00000
	SET @va_ide_vta = @va_ide_doc + '-' + SUBSTRING(CAST (@va_nro_tal_tmp AS VARCHAR(4)),2,3) + '-' + SUBSTRING(CAST(@va_nro_vta_tmp AS VARCHAR(7)),2,7)
	
	
	IF @ar_mon_vta ='B'
	BEGIN
		SELECT @va_tot_bBs = SUM(va_pre_tot) 
		FROM #tm_vta001
		
		SET @va_tot_bUs = @va_tot_bBs / @ar_tip_cam
		
		SET @va_des_cBs = @ar_des_cue
		SET @va_des_cUs = @ar_des_cue / @ar_tip_cam
		
		SET @va_tot_nBs = @va_tot_bBs - @va_des_cBs
		SET @va_tot_nUs = @va_tot_nBs / @ar_tip_cam
	END
	ELSE
	BEGIN
		SELECT @va_tot_bUs = SUM(va_pre_tot) 
		FROM #tm_vta001
		
		SET @va_tot_bBs = @va_tot_bUs * @ar_tip_cam
		
		SET @va_des_cUs = @ar_des_cue
		SET @va_des_cBs = @va_des_cUs * @ar_tip_cam
		
		SET @va_tot_nUs = @va_tot_bUs - @va_des_cUs
		SET @va_tot_nBs = @va_tot_nUs * @ar_tip_cam
	END
	
	/*
	--// Verifica Linea de credito si es al credito
	IF @ar_for_pag = 1
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM ecp007
		WHERE va_cod_per = @ar_cod_cli AND
			  va_cod_lib = @ar_lin_cxc
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
			RETURN
		END
		
		IF( @ar_fec_vta > @va_fec_exp)
		BEGIN
			RAISERROR ('La linea de credito de la persona a expirado',16,1)
			RETURN
		END
		
		SELECT @va_mon_lib = va_mon_lib
		  FROM ecp006
		WHERE  va_cod_lib = @ar_lin_cxc
		
		SET @va_sal_aut = @va_mto_lim - @va_sal_act
		
		IF (@va_mon_lib = 'B')
		BEGIN
			IF (@va_tot_nBs > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		ELSE
		BEGIN
			IF (@va_tot_nus > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		
	END
	*/
	
	
	-- Obtiene Porcentaje Delivery
	SET @va_por_del = 0
	IF(@ar_vta_par ='D')
	BEGIN
		SELECT @va_por_del = va_por_del 
		  FROM cmr015
		 WHERE va_cod_del = @ar_cod_del
	END
	ELSE
	BEGIN
		SET @ar_cod_del = 0
		SET @va_por_del = 0
	END
		
	-- REGISTRA ENCABEZADO venta select * from cmr005
	INSERT INTO cmr005 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_vta, @va_ges_vta, @va_ide_vta, @ar_tip_vta, @ar_cod_cli,
							  @ar_raz_soc,@ar_nit_cli, @ar_fec_vta, @ar_tip_cam, @ar_pla_vta, @ar_ven_ded, @ar_mon_vta,
							  @ar_for_pag,@ar_cod_caj,@ar_lin_cxc,@ar_ref_vta,
							  @ar_cod_bod, @ar_lis_pre, @ar_vta_par,@ar_cod_del, @va_por_del,  
							  @va_tot_bBs, @va_tot_bUs,@va_des_cBs, @va_des_cUs,@va_tot_nBs, @va_tot_nUs, 
							  @ar_obs_vta, @va_cod_usr, GETDATE(), '', '01/01/1900','V')
				 		 
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Ocurrio un error al ingresar el encabezado de venta',16,1)
		RETURN
	END
		
	/*	
	--// Si es factura 
	if (@ar_tip_vta = 1)
	BEGIN
	
	
	--//graba debito fiscal
	INSERT INTO ctb008 VALUES (@va_ges_vta,@va_prd_vta,@va_ide_vta,@va_nro_vta,@ar_nro_aut,@ar_nit_cli,@ar_raz_soc,@va_tot_bBs,
								@va_des_cBs,@va_tot_nBs, (@va_tot_nBs * 0.13), '' , @ar_fec_vta,GETDATE(),null)
	
		
	END	
	*/		
--//OBTIENE IMPORTE TOTAL DEL DOCUMENTO
SELECT @va_imp_tot = sum(va_pre_tot)
FROM #tm_vta001
	/*
	--// SI ES EFECTIVO-GRABA RECIBO DE INGRESO A CAJA
	IF (@ar_for_pag = 0 ) --Contado
	BEGIN
	 --select * from tes002
		INSERT INTO TES002 VALUES (@ar_cod_caj,@ar_ide_doc,@ar_nro_tal,@va_nro_vta,@va_ges_vta,@va_ide_vta,@ar_cod_cli,@ar_raz_soc,0,
									@ar_mon_vta,@va_imp_tot,@ar_mto_efe, @ar_cam_bio, @ar_obs_vta,'V')
	END
	ELSE -- SI ES AL CREDITO GRABA EXIGIBLE X COBRAR
	BEGIN
	
	
	END
	*/
	

	
	
	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_opc_und, va_can_tid,va_pre_uni,
	   va_pre_tot, va_pre_lis, va_des_cue, va_por_cen
FROM #tm_vta001	
	
--** Abre cursor		  
OPEN vc_det_vta    
	 
SET @va_con_tad = 0
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_und_vta = va_und_vta,
		   @va_eqv_vta = va_eqv_vta,
		   @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	--//VERIFICA TIPO DE FAMILIA (SERVICIO/DETALLE/...)
	SELECT @va_est_ado = va_est_ado,
		   @va_tip_fam = va_tip_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +') no se encuentra registrada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +')  se encuentra deshabilitada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	-- Calcula cantidades segun unidades de medida
	SET @va_can_uin = @va_can_vta
	
	IF (@va_tip_fam <> 'S')
	BEGIN
		IF (@va_und_umd <> @va_und_vta) 
		BEGIN
			IF(@va_opc_und = 0)
				SET @va_can_uin = @va_can_vta * @va_eqv_vta
		END
	END
	
	SET @va_cod_bod = @ar_cod_bod
		
	-- VERIFICA EXISTENCIA
	IF (@va_tip_fam <> 'S' AND @va_tip_fam <> 'C' )
	BEGIN
		SET @va_stk_act = 0
		
		
		EXECUTE inv100_01a_p02 @va_cod_bod, @va_cod_pro, @ar_fec_vta, @va_stk_act OUTPUT
		
		IF (@va_stk_act IS NULL)
			SET @va_stk_act = 0
			
		IF (@va_stk_act = 0) OR (@va_can_uin > @va_stk_act)	
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : 
El producto ('+ @va_cod_pro +') NO cuenta con existencia suficiente  
Saldo a la fecha: (' + CAST(@va_stk_act AS VARCHAR(16)) + ')   '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	/*
	IF(@va_tip_fam = 'C')
	BEGIN
		-- OBTIENE PRODUCTOS QUE COMPONEN EL COMBO
	
	END
	*/
	
	-- Calcula Precios unitarios
	IF @ar_mon_vta = 'B' AND (@va_und_umd = @va_und_vta)
	BEGIN
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'B' AND (@va_und_umd <> @va_und_vta)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA VENTA FUE "UNIDAD DE VENTA" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_vta
			
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'U' AND (@va_und_umd = @va_und_vta)
	BEGIN
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'U' AND (@va_und_umd <> @va_und_vta)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA VENTA FUE "UNIDAD DE VENTA" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_vta
			
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
	END
	
	-- Calcula Precios y descuento unitarios Totales 
	IF @ar_mon_vta = 'B'
	BEGIN
		SET @va_pre_tBs = @va_pre_tot
		SET @va_pre_tUs = @va_pre_tot / @ar_tip_cam
		
		SET @va_dto_uBs = @va_des_cue
		SET @va_dto_uUs = @va_des_cue / @ar_tip_cam
	END
	IF @ar_mon_vta = 'U'
	BEGIN
		SET @va_pre_tUs = @va_pre_tot
		SET @va_pre_tBs = @va_pre_tot * @ar_tip_cam
		
		SET @va_dto_uUs = @va_des_cue
		SET @va_dto_uBs = @va_des_cue * @ar_tip_cam
	END
	
	
	SET @va_sal_can = 0
	SET @va_cos_ubs = 0
	SET @va_cos_uUs = 0
	
	IF (@va_tip_fam = 'D')
	BEGIN
		--//VERIFICA EXISTENCIA EN Bodega Y OBTIENE COSTO
		SELECT @va_sal_can = va_sal_can,
			   @va_cos_ubs = va_cos_ubs,
			   @va_cos_uUs = va_cos_uUs
		  FROM inv099
		WHERE va_cod_bod = @ar_cod_bod	AND
			  va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') jamas tuvo movimiento en el Bodega'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_can_uin > @va_sal_can 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con stock suficiente ('+ CAST(@va_sal_can AS NVARCHAR(10)) +')  '
			RAISERROR (@msg,16,1)
			RETURN
		END
		
		--//VERIFICA LIMITES DE DESCUENTO SEGUN LISTA DE PRECIO
		SELECT @va_pmx_des = va_pmx_des,
			   @va_pmx_inc = va_pmx_inc
		FROM cmr002
		 WHERE va_cod_lis = @ar_lis_pre AND
			   va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con precio definido en la lista de precio ('+ CAST(@ar_lis_pre AS NVARCHAR(10))  +')'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_por_ite > @va_pmx_des 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El descuento para el producto ('+ @va_cod_pro +'), supera el permitido (Desc. Max.: '+ CAST(@va_pmx_des AS NVARCHAR(10)) +' %)  '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	
	-- PRORATEA DESCUENTO GENERAL DOCUMENTO A LOS ITEM, EN MONEDA DEL DOCUMENTO
	SET @va_por_cen = (@va_pre_tot * 100) / @va_imp_tot
	
	SET @va_des_uni = (@va_por_cen * @ar_des_cue) / 100
	SET @va_des_acu = @va_des_acu + @va_des_uni
	
	IF @@CURSOR_ROWS = @va_con_tad
	BEGIN
		IF @va_des_acu <> @ar_des_cue
			SET @va_des_uni = @va_des_uni + (@ar_des_cue - @va_des_acu)
	END
	
	-- OBTIENE DESCUENTO GLOBAL UNITARIOS PRORATEADOS EN BS Y US PARA CALCULOS
	IF @ar_mon_vta ='B'
	BEGIN
		SET @va_des_unB = @va_des_uni
		SET @va_des_unU = @va_des_uni / @ar_tip_cam
	END
	ELSE
	BEGIN
		SET @va_des_unU = @va_des_uni
		SET @va_des_unB = @va_des_uni * @ar_tip_cam
	END
	
	--// CALCULA VALORES IMPOSITIVOS
	--IVA
	SET @va_iva_uBs = (@va_pre_tBs - @va_des_unU) * 0.13
	SET @va_iva_uUs = (@va_pre_tUs - @va_des_unB) * 0.13

	--ITR
	SET @va_itr_uBs = (@va_pre_tBs - @va_des_unU)  * 0.03
	SET @va_itr_uUs = (@va_pre_tUs - @va_des_unB) * 0.03
		
		
	
	-- REGISTRA DETALLE DE venta select * from cmr006
	INSERT INTO cmr006 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_vta, @va_ges_vta, @va_ide_vta, @va_nro_itm,
							  @va_cod_pro,@va_des_pro, @va_opc_und,@va_und_vta,@va_und_umd,@va_eqv_vta,@va_can_vta,@va_can_uin,
							  @va_pre_lis, (@va_pre_uBs + @va_dto_uBs), (@va_pre_uUs + @va_dto_uUs), 
							  @va_dto_uBs, @va_dto_uUs,@va_por_ite, @va_pre_tBs,@va_pre_tUs,
							  @va_cos_uBs, @va_cos_uUs, @va_iva_uBs, @va_iva_uUs, @va_itr_uBs, @va_itr_uUs )
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al ingresar item del detalle',16,1)
		RETURN
	END

	--//ACTUALIZA EXISTENCIA
	 UPDATE inv099 
	    SET va_sal_can = va_sal_can - @va_can_uin
	  WHERE va_cod_bod = @ar_cod_bod AND va_cod_pro = @va_cod_pro
  	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al actualizar saldos de stock',16,1)
		RETURN
	END
  
	--//REGISTRA KARDEX
	INSERT INTO inv100 VALUES (@va_ges_vta,@va_ide_doc,@va_nro_tal,@va_nro_vta,@va_ide_vta, @va_nro_itm,
							   @ar_fec_vta, GETDATE(), @ar_ref_vta, @ar_mon_vta,@ar_obs_vta, @va_cod_pro,
							   0,@va_can_uin,@va_cos_ubs,@va_cos_uus,(@va_cos_ubs * @va_can_vta),(@va_cos_uus * @va_can_vta), 
							   @va_cos_ubs,@va_cos_uus, @va_cod_bod, 'Lote: ', @ar_tip_cam, @va_cod_usr)
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al registrar el kardex',16,1)
		RETURN
   END
   
 
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite
END


--// GRABA CXC 

--// GRABA INGRESO EFECTIVO


--// ACTUALIZA CONTADOR
UPDATE ads005 SET va_con_tad = @va_nro_vta
WHERE va_ide_doc = @va_ide_doc AND 
	  va_nro_tal = @va_nro_tal AND
	  va_ges_tio = @va_ges_vta

CLOSE vc_det_vta
DEALLOCATE vc_det_vta

-- Borra temporal
DELETE cmr006tmp
WHERE va_cod_tmp = @ar_cod_tmp AND
	  va_cod_usr = @va_cod_usr

SELECT * FROM  cmr005
WHERE va_doc_vta = @va_ide_doc	AND
	  va_nro_tal = @va_nro_tal	AND
	  va_nro_vta = @va_nro_vta	AND
	  va_ges_vta = @va_ges_vta 
	
	COMMIT TRAN TR_vta001
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_vta001
	RETURN
END CATCH	

GO  
/*
ARCHIVO: cmr005_02a_p02.sql
PROCEDIMIENTO: PROCEDIMIENTO VERIFICA ANTES DE GRABAR VENTA
AUTOR:	CREARSIS(chl)
FECHA:	21-04-2021
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_02a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_02a_p02
GO

CREATE PROCEDURE cmr005_02a_p02 
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal
							@ar_tip_vta INT,		-- Tipo de venta (1= FAC, 2 = NOTA DE VENTA)
							@ar_pla_vta	INT,			-- Plantilla de venta 
							@ar_cod_bod INT,			-- Bodega
							@ar_cod_cli INT,			-- codigo Cliente
							@ar_fec_vta DATE,			-- Fecha de venta
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_lis_pre	INT			-- Lista de precio usada en la venta
							
														
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),

@va_ide_doc		CHAR(03),
@va_nro_tal		INT,

@va_nro_vta		INT,			-- Numero de del documento
@va_nro_vta_tmp INT,
@va_ide_vta		VARCHAR(20),	--Identificador de la venta (XXX|000-00000)
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 

@va_opc_und		INT,			--Opcion de unidad de medida seleccionado
@va_und_umd		CHAR(03),		--Unidad de medida inventario del producto
@va_und_vta		CHAR(03),		--Unidad de medida de venta del producto
@va_can_uin		DECIMAL(14,4),	--Cantidad inventario de producto
@va_can_vta		DECIMAL(14,4),	--Cantidad de producto
@va_eqv_vta		DECIMAL(7,3),	-- Equivalencia entre @va_und_vta y @va_und_umd
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario de item en la moneda del documento
@va_pre_tot		DECIMAL(16,2),	--Precio Total de item en la moneda del documento
@va_des_cue		DECIMAL(16,2),	--Descuento del item en moneda de la venta
@va_pre_lis		DECIMAL(16,2),	--Precio de la lista de precio del item en moneda de la venta
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_cod_fam		VARCHAR(15),	-- Codigo de familida a la que pertenece el producto
@va_tip_fam		CHAR(01),		-- Tipo de familia 

@va_tot_bBs		DECIMAL(16,2),	-- Total bruto del documento en Bs
@va_tot_bUs		DECIMAL(16,2),	-- Total bruto del documento en Us
@va_des_cBs		DECIMAL(16,2),	-- Descuento global al documento en Bs.
@va_des_cUs		DECIMAL(16,2),	-- Descuento global al documento en Us.
@va_tot_nBs		DECIMAL(16,2),	-- Total neto del documento en Bs.
@va_tot_nUs		DECIMAL(16,2),	-- total neto del documento en Us.

@va_pre_uBs		DECIMAL(16,2),	-- Precio unitario en Bs
@va_pre_uUs		DECIMAL(16,2),	-- Precio unitario en Us.
@va_pre_tBs		DECIMAL(16,2),	-- Precio total en Bs.
@va_pre_tUs		DECIMAL(16,2),	-- precio total en Us.
@va_dto_uBs		DECIMAL(16,2),	-- Descueto lineal unitario en Bs.
@va_dto_uUs		DECIMAL(16,2),	-- Descueto lineal unitario en Us.
@va_por_ite		DECIMAL(16,2),	-- Porcentaje lineal unitario

@va_con_tad		INT,			-- Contador para validar

--// Valores para prorratear descuento global del documento sobre los items
@va_por_cen		DECIMAL(16,5),	-- Porcentaje de descuento unitario
@va_des_uni		DECIMAL(16,2),	-- Valor de descuento unitario
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),	-- Descuento acumulado para calculo
@va_pmx_des		DECIMAL(16,2),	-- Porcentaje Descuento permitido segun lista de precio
@va_pmx_inc		DECIMAL(16,2),	-- Porcentaje Incremento permitido segun lista de precio

-- variables para gestion
@va_ges_vta		INT,
@va_ges_tio		INT,
@va_ges_per		INT,
@va_fec_ini		DATE, 
@va_fec_fin		DATE,

@va_fec_exp		DATE,			-- Fecha de expiracion de la libreta de  la persona

@va_fec_fin_lis		DATE,			-- Fecha de fin de la lista de precio
@va_fec_ini_lis		DATE,			-- Fecha de inicio de la lista de precio

@va_sal_act		DECIMAL(16,2),	-- Saldo actual de la libreta de la persona
@va_mto_lim		DECIMAL(16,2),	-- monto limite autorizado en la libreta de la persona

@va_sal_aut		DECIMAL(16,2),	-- Saldo autorizado de credito (@va_mto_lim - @va_sal_act)
@va_mon_lib		CHAR(01),		-- Moneda de la libreta

@va_tip_cam		DECIMAL(7,5),	-- TIPO DE CAMBIO

@va_stk_act		DECIMAL(16,4),	-- ESTOCK ACTUAL DEL PRODUCTO OBTENIDO DEL PROCEDIMIENTO (inv100_01p2)
@va_prd_vta		INT			 ,	-- Periodo de la venta
@va_cod_bod		INT			 ,	-- Codigo de bodega en  INT
@va_por_del		DECIMAL (3,1)	-- Porcentaje correspondiente al delivery
			
	
--** CREA TABLA TEMPORAL
CREATE TABLE #tm_vta001(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_pre_lis		DECIMAL(16,2),				--Precio de lista en la moneda del documento
	va_des_cue		DECIMAL(16,2),				--Descuento en la moneda del documento
	va_por_cen		DECIMAL(16,2) 				--Pocentaje de descuento
	
   )
   
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_vta001
BEGIN TRY     
  
	
  SET @va_tip_cam = 1
  SET @va_cod_usr = SYSTEM_USER
  
  
   -- Carga temporal de venta
   INSERT INTO #tm_vta001
	SELECT * FROM cmr006tmp
	WHERE va_cod_tmp = @ar_cod_tmp AND
		  va_cod_usr = @va_cod_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('No hay ningun item para la venta',16,1)
		RETURN
	END

	
	-- Verifica plantilla de venta
	SET @va_est_ado = 'N'
	IF(@ar_tip_vta = 1) -- FACTURA
	BEGIN
		SELECT @va_est_ado = va_est_ado,
			   @va_ide_doc = va_doc_fac,
			   @va_nro_tal = va_tal_fac
		FROM cmr004
		WHERE va_cod_plv = @ar_pla_vta
	END	  
	IF(@ar_tip_vta = 2) -- NOTA DE VENTA
	BEGIN
		SELECT @va_est_ado = va_est_ado,
			   @va_ide_doc = va_doc_ntv,
			   @va_nro_tal = va_tal_ntv
		FROM cmr004
		WHERE va_cod_plv = @ar_pla_vta
	END	 	 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Plantilla de venta no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Plantilla de venta se encuentra Deshabilitada',16,1)
		RETURN
	END	
	
	
	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @va_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado
	 FROM ads004
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal
		   
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	
		SELECT	--@va_est_ado = va_est_ado,
				@va_ges_vta = va_ges_tio,
				@va_prd_vta = va_ges_per,
				@va_fec_ini = va_fec_ini,
				@va_fec_fin = va_fec_fin
		  FROM	ads016
		 WHERE	(@ar_fec_vta BETWEEN va_fec_ini AND va_fec_fin)
		 
		  
		
 IF (@va_ges_vta = 0)
 BEGIN
	RAISERROR ('la fecha del documento no se encuentra dentro de una gestion definida',16,1)
	RETURN
 END
/*
 IF (@va_est_ado = 'C')
 BEGIN
	RAISERROR ('la fecha del documento se encuentra dentro de un periodo cerrado',16,1)
	RETURN
 END
*/
		
--// Verifica Numeracion / inicialilza fechas iniciales para numeracion
	SET @va_fec_ini = '01.01.1990'
	SET @va_fec_fin = '01.01.1990'
	
	SELECT @va_nro_vta = va_con_tad,
		   @va_fec_ini = va_fec_ini,
		   @va_fec_fin = va_fec_fin
	FROM ads005
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal AND
		  va_ges_tio = @va_ges_vta
	IF @@ROWCOUNT = 0
	BEGIN
		
	    SET @msg = 'El Talonario NO dispone de numeracion para la gestion ' + CAST (@va_ges_vta AS VARCHAR(3))
		RAISERROR ( @msg ,16,1)
		RETURN
	END
	
	IF NOT (@ar_fec_vta > @va_fec_ini AND @ar_fec_vta < @va_fec_fin)
	BEGIN
		RAISERROR ('La fecha del documento no esta dentro del rango permitido en la numeracion para la gestion',16,1)
		RETURN
	END	
	
	--// Verifica Bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Bodega no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Bodega se encuentra Deshabilitada',16,1)
		RETURN
	END
	
	
	--// Verifica CLIENTE
	SELECT @va_est_ado = va_est_ado
	FROM cmr013
	WHERE va_cod_per = @ar_cod_cli
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Cliente no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Cliente se encuentra Deshabilitado',16,1)
		RETURN
	END

	/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	--// Verifica LISTA DE PRECIO
	SELECT @va_est_ado = va_est_ado,
			@va_fec_fin_lis = va_fec_fin,
			@va_fec_ini_lis = va_fec_ini
	FROM cmr001
	WHERE va_cod_lis = @ar_lis_pre
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Lista de Precio no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Lista de Precio se encuentra Deshabilitada',16,1)
		RETURN
	END

	-- Verifica que la fecha de la venta este dentro del rango de fechas de la lista de precios
	IF( @ar_fec_vta > @va_fec_fin_lis or @ar_fec_vta < @va_fec_ini_lis)
	BEGIN
		RAISERROR ('La Lista de Precio NO puede ser usada para la fecha del documento',16,1)
		RETURN
	END




/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	
	/*
	--// Verifica Linea de credito si es al credito
	IF @ar_for_pag = 1
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM ecp007
		WHERE va_cod_per = @ar_cod_cli AND
			  va_cod_lib = @ar_lin_cxc
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
			RETURN
		END
		
		IF( @ar_fec_vta > @va_fec_exp)
		BEGIN
			RAISERROR ('La linea de credito de la persona a expirado',16,1)
			RETURN
		END
		
		SELECT @va_mon_lib = va_mon_lib
		  FROM ecp006
		WHERE  va_cod_lib = @ar_lin_cxc
		
		SET @va_sal_aut = @va_mto_lim - @va_sal_act
		
		IF (@va_mon_lib = 'B')
		BEGIN
			IF (@va_tot_nBs > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		ELSE
		BEGIN
			IF (@va_tot_nus > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		
	END
	*/

	/*
	--// SI ES EFECTIVO-GRABA RECIBO DE INGRESO A CAJA
	IF (@ar_for_pag = 0 ) --Contado
	BEGIN
	 --select * from tes002
		INSERT INTO TES002 VALUES (@ar_cod_caj,@va_ide_doc,@va_nro_tal,@va_nro_vta,@va_ges_vta,@va_ide_vta,@ar_cod_cli,@ar_raz_soc,0,
									@ar_mon_vta,@va_imp_tot,@ar_mto_efe, @ar_cam_bio, @ar_obs_vta,'V')
	END
	ELSE -- SI ES AL CREDITO GRABA EXIGIBLE X COBRAR
	BEGIN
	
	
	END
	*/
	

	
	
	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_opc_und, va_can_tid,va_pre_uni,
	   va_pre_tot, va_pre_lis, va_des_cue, va_por_cen
FROM #tm_vta001	
	
--** Abre cursor		  
OPEN vc_det_vta    
	 
SET @va_con_tad = 0
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_und_vta = va_und_vta,
		   @va_eqv_vta = va_eqv_vta,
		   @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	--//VERIFICA TIPO DE FAMILIA (SERVICIO/DETALLE/...)
	SELECT @va_est_ado = va_est_ado,
		   @va_tip_fam = va_tip_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +') no se encuentra registrada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +')  se encuentra deshabilitada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	-- Calcula cantidades segun unidades de medida
	SET @va_can_uin = @va_can_vta
	
	IF (@va_tip_fam <> 'S')
	BEGIN
		IF (@va_und_umd <> @va_und_vta) 
		BEGIN
			IF(@va_opc_und = 0)
				SET @va_can_uin = @va_can_vta * @va_eqv_vta
		END
	END
	
	SET @va_cod_bod = @ar_cod_bod
		
--	-- VERIFICA EXISTENCIA
--	IF (@va_tip_fam <> 'S' AND @va_tip_fam <> 'C' )
--	BEGIN
--		SET @va_stk_act = 0
		
		
--		EXECUTE inv100_01a_p02 @va_cod_bod, @va_cod_pro, @ar_fec_vta, @va_stk_act OUTPUT
		
--		IF (@va_stk_act IS NULL)
--			SET @va_stk_act = 0
			
--		IF (@va_stk_act = 0) OR (@va_can_uin > @va_stk_act)	
--		BEGIN
--			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : 
--El producto ('+ @va_cod_pro +') NO cuenta con existencia suficiente  
--Saldo a la fecha: (' + CAST(@va_stk_act AS VARCHAR(16)) + ')   '
--			RAISERROR (@msg,16,1)
--			RETURN
--		END
--	END
	
	
	/*
	IF(@va_tip_fam = 'C')
	BEGIN
		-- OBTIENE PRODUCTOS QUE COMPONEN EL COMBO
	
	END
	*/
	
	
	
	
	IF (@va_tip_fam = 'D')
	BEGIN
		
		--//VERIFICA LIMITES DE DESCUENTO SEGUN LISTA DE PRECIO
		SELECT @va_pmx_des = va_pmx_des,
			   @va_pmx_inc = va_pmx_inc
		FROM cmr002
		 WHERE va_cod_lis = @ar_lis_pre AND
			   va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con precio definido en la lista de precio ('+ CAST(@ar_lis_pre AS NVARCHAR(10))  +')'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_por_ite > @va_pmx_des 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El descuento para el producto ('+ @va_cod_pro +'), supera el permitido (Desc. Max.: '+ CAST(@va_pmx_des AS NVARCHAR(10)) +' %)  '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	
	
   
 
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite
END


CLOSE vc_det_vta
DEALLOCATE vc_det_vta
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_vta001
	RETURN
END CATCH	

GO  
/*
ARCHIVO: cmr005_04a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO ANULA VENTA
	(anula venta, suma existencia, borra kardex, 
	costea reingreso de los productos, )
AUTOR:	CREARSIS(chl)
FECHA:	01-05-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_04a_p01
GO

CREATE PROCEDURE cmr005_04a_p01 @ar_ide_vta	VARCHAR(20),--Identificador de la venta (XXX|000-00000/2018)
							 @ar_ges_vta	INT --,		--Gestion de la venta							
							 --@ar_ide_usr	VARCHAR(15)	--Codigo del usuario que anula
							  WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_nro_doc		INT, 
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_itm_vta		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_can_uni		DECIMAL(14,4),	--Cantidad inventario de producto
@va_cod_fam		VARCHAR(6),					--** Codigo de la familia de producto
@va_tip_fam		CHAR(1),		--Tipo de la cuenta (M=Matriz ; D=DETALLE ; S=Servicio C=Combo)
@va_cod_bod		INT,	        --Codigo del almacen (7 numeros)
@va_ges_tio		INT,			--Gestion de la venta

@va_cot_act		DECIMAL(14,2),	-- Valor Costo total del producto antes de la anulacion
@va_cot_itm		DECIMAL(14,2),	-- Valor costo total del item 
@va_nvo_cos		DECIMAL(14,2),	-- Valor Nuevo costo promedio para el item
@va_tip_cam		DECIMAL(14,2),	-- Tipo de cambio 

@va_sal_can		DECIMAL(14,2)

BEGIN TRAN TR_CMR005
BEGIN TRY   
  		
SELECT @va_est_ado = va_est_ado,
       @va_cod_bod = va_cod_bod,
       @va_ges_tio = va_ges_vta
  FROM cmr005
WHERE va_ide_vta = @ar_ide_vta	AND
	  va_ges_vta = @ar_ges_vta
	  
IF @@ROWCOUNT = 0
BEGIN
	RAISERROR ('LA VENTA NO SE ENCUENTRA REGISTRADA',16,1)
	RETURN
END
IF @va_est_ado = 'N'
BEGIN
	RAISERROR ('LA VENTA YA SE ENCUENTRA ANULADA',16,1)
	RETURN
END
	
	
-- Obtiene el tipo de cambio a la fecha
SET @va_tip_cam = 1
	

	
	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_itm_vta, va_cod_pro, va_can_uni
FROM cmr006
WHERE va_ide_vta = @ar_ide_vta	AND
	  va_ges_vta = @ar_ges_vta

	
--** Abre cursor		  
OPEN vc_det_vta    
	 
FETCH NEXT FROM vc_det_vta 
INTO @va_itm_vta, @va_cod_pro, @va_can_uni

WHILE (@@FETCH_STATUS = 0)
BEGIN
	
	-- Obtiene el codigo de familia
	SELECT @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_cod_fam = ''
	END
	
	-- Obtiene el tipo de familia
	SELECT @va_tip_fam = va_tip_fam
	FROM inv003
	WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_tip_fam = ''
	END
	
	SET @va_nvo_cos = 0
	
	IF @va_tip_fam = 'D'
	BEGIN
	
		-- Obtien saldo actual de inventario
		SELECT @va_sal_can = va_sal_can,
			   @va_cot_act = va_sal_can * va_cos_ubs
		FROM inv099
		WHERE va_cod_pro = @va_cod_pro
		  AND va_cod_bod = @va_cod_bod
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_sal_can = 0
			SET @va_cot_act = 0
		END
		
		--** Verifica que saldo existencia sea mayor que la cantidad de la venta
		IF @va_can_uni > @va_sal_can 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_itm_vta AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +')  NO tiene la existencia suficiente'
			RAISERROR (@msg,16,1)
			RETURN
		END
		
		-- Obtiene costo total de la operacion, del producto
		SELECT @va_cot_itm = va_cos_toB
		FROM inv100 WHERE va_ide_doc = @ar_ide_vta
					     AND va_cod_pro = @va_cod_pro
					     AND va_ges_tio = @va_ges_tio
		
		-- costea reingreso del producto
		-- Total valorado / total cantidad
		SET @va_nvo_cos = (@va_cot_act + @va_cot_itm) / (@va_sal_can + @va_can_uni)
		
		
		
		
		
		-- si es al contado - anula Recibo de Ingreso por venta
		
		-- si es al credito - anula Registro CxC (si aun no tiene pagos reslizados)
		
		
		--SI ES FACTURA (ELIMINA REGISTRO DEBITO FISCAL)
	END
	
	--** Actualiza saldo valorado existencia
	UPDATE inv099 SET va_sal_can = (va_sal_can + @va_can_uni),
					  va_cos_ubs = @va_nvo_cos , 
					  va_cos_uus = (@va_nvo_cos * @va_tip_cam)
	WHERE va_cod_pro = @va_cod_pro 
	  AND va_cod_bod = @va_cod_bod
		   
	--** elimina registro del kardex
	DELETE FROM inv100 WHERE va_ide_doc = @ar_ide_vta
					     AND va_cod_pro = @va_cod_pro
					     AND va_ges_tio = @va_ges_tio
    
 
FETCH NEXT FROM vc_det_vta 
INTO @va_itm_vta, @va_cod_pro, @va_can_uni
END
--** cambia estado encabezado venta
UPDATE cmr005 SET va_est_ado = 'N', 
				  va_usr_anu = SYSTEM_USER, -- @ar_ide_usr,
				  va_fec_anu = GETDATE()
 WHERE va_ide_vta = @ar_ide_vta	AND
	   va_ges_vta = @ar_ges_vta

CLOSE vc_det_vta
DEALLOCATE vc_det_vta


COMMIT TRAN TR_CMR005

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1) 
	Rollback TRAN TR_CMR005   
	RETURN
END CATCH	

RETURN (0)

GO  
/*
ARCHIVO: cmr005_05a_p01.sql
PROCEDIMIENTO: CONSULTA NOTA DE VENTA 
	(Formato = 0 ; en Undidad de Compra)
AUTOR:	CREARSIS(chl)
FECHA:	26-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.cmr005_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_05a_p01
GO

CREATE PROCEDURE cmr005_05a_p01 @ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
								@ar_ges_vta	INT	-- gestion de la compra
							 WITH ENCRYPTION AS
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
--@ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
--@ar_ges_vta	INT	,-- gestion de la compra
@msg			nvarchar(200),
@va_fec_vta		DATETIME,
@va_nro_vta		INT,
@va_cod_bod		CHAR(06),
@va_nom_bod		VARCHAR(50),			-- Numero de del documento
@va_for_pag		INT,	--Identificador de la venta (XXX|000-00000/2018)
@va_tip_cam		DECIMAL(4,2),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(80),
@va_mon_vta		CHAR(01),
@va_sub_toB		DECIMAL(16,5),
@va_sub_toU		DECIMAL(16,5),
@va_tot_bru		DECIMAL(16,5),
@va_dto_vtB		DECIMAL(16,5),
@va_dto_vtU		DECIMAL(16,5),
@va_des_cue		DECIMAL(16,5),
@va_tot_vtB		DECIMAL(16,5),
@va_tot_vtU		DECIMAL(16,5),
@va_tot_net		DECIMAL(16,5),
@va_obs_vta		VARCHAR(200),
@va_vta_par		CHAR(01)	,
@va_est_ado		CHAR(01),
@va_usr_reg		VARCHAR(15),
@va_fec_reg		DATETIME,
@va_itm_vta		INT,
@va_cod_pro		VARCHAR(15),
@va_des_pro		varchar(120)	,			--Descripcion del Producto 
@va_can_tid		DECIMAL(14,4),				--Cantidad de producto
@va_und_inv		CHAR(03)		,			--Numero de item 
@va_pre_uBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tot		DECIMAL(16,2),

@va_doc_vta     CHAR(03),					-- Documento de la operacion
@va_nro_tal     INT,						-- Nro de talonario de la operacion
@va_fir_ma1		VARCHAR(20),				--Firma del talonario 1
@va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
@va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
@va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
--@va_log_emp		VARBINARY(max),				--Logo de la empresa
@va_log_emp		NVARCHAR(100),				--Logo de la empresa
@va_for_log		TINYINT, 					--Formato de logo
											-- 0=Nombre de la empresa
											-- 1=logo 1
@va_cod_del		int,
@va_nom_del		varchar(20),
@va_cod_ven		INT,						--Codigo Vendedor
@va_nom_ven		VARCHAR(50),				--Nombre vendedor

@va_cod_plv		INT,						-- Plantilla de venta											
											
@va_ref_vta		VARCHAR(20)

	

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_cmr005(
	va_fec_vta		DATETIME		NOT NULL,	--Codigo del usuario
	va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador compuesto para la venta
	va_ges_vta		INT				not null,	--Gestion de la venta 
	va_nro_vta		INT				NOT NULL,	--Nro venta
	va_cod_bod		char(06)		not null,	--Almacen
	va_nom_bod		VARCHAR(50)		not null,	--Nombre almacen
	va_for_pag		INT				NOT NULL,	-- Forma de Pago **
	va_tip_cam		DECIMAL(4,2)	NOT NULL,	--Tipo de cambio **
	va_cod_per		INT				not null,	--Codigo persona
	va_raz_soc		VARCHAR(80)		not null,	--Razon social
	va_mon_vta		CHAR(01)		not null,	--Numero de item 
	va_tot_bru		DECIMAL(16,5)	not null,	--Numero de item 
	va_des_cue		DECIMAL(16,5)	not null,	--Numero de item 
	va_tot_net		DECIMAL(16,5)	not null,	--Numero de item 
	va_obs_vta		VARCHAR(200)	not null,	--Numero de item 
	va_vta_par		CHAR(01)		not null,	--Venta para (M=Mesa; L=Llevar ; D=Delivery)
	
	va_est_ado		CHAR(01)		not null,	--Numero de item 
	va_usr_reg		VARCHAR(15)		NOT NULL,	--Usuario registro
	va_fec_reg		DATETIME		NOT NULL,	--Fecha de registro
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		not null,	--Numero de item 
	va_des_pro		varchar(120)	not null,	--Descripcion del Producto 
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_und_inv		CHAR(03)		not null,	--Numero de item 
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
    va_fir_ma1		VARCHAR(20),    		    --Firma del talonario 1
	va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
	va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
	va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
	va_for_log		TINYINT, 	                --Formato de logo
												-- 0=Nombre de la empresa
												-- 1=logo 1
	--va_log_emp		VARBINARY(max),				--Logo de la empresa
	va_cod_del		INT,
	va_nom_del		VARCHAR(20),
	va_cod_ven		INT,						--Codigo Vendedor
	va_nom_ven		VARCHAR(50),				--Nombre vendedor
	va_cod_plv		INT,						--Codigo plantilla de venta
	va_log_emp		NVARCHAR(100),				--Logo de la empresa
	va_ref_vta		VARCHAR(20)					--Referencia de la venta
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_cmr005
BEGIN TRY
--SET @ar_ide_vta = 'VRS-000-000007'
--SET @ar_ges_vta = 2020
	-- Obtiene datos del encabezado
	SELECT @va_fec_vta = va_fec_vta, @va_nro_vta = va_nro_vta,
		   @va_cod_per = va_cod_per, @va_raz_soc = va_raz_soc,
		   @va_sub_toB = va_sub_toB, @va_sub_toU = va_sub_toU,
		   @va_dto_vtB = va_dto_vtB, @va_dto_vtU = va_dto_vtU,
		   @va_tot_vtB = va_tot_vtB, @va_tot_vtU = va_tot_vtU,
		   @va_cod_bod = va_cod_bod, @va_tip_cam = va_tip_cam,
		   @va_vta_par = va_vta_par,
		   @va_mon_vta = va_mon_vta, @va_for_pag = va_for_pag,
		   @va_usr_reg = va_usr_reg, @va_fec_reg = va_fec_reg,
		   @va_obs_vta = va_obs_vta, @va_est_ado = va_est_ado,
		   @va_doc_vta = va_doc_vta, @va_nro_tal = va_nro_tal,
		   @va_ref_vta = va_ref_vta, @va_cod_del = va_cod_del,
		   @va_cod_ven = va_cod_ven, @va_cod_plv = va_cod_plv
	FROM cmr005
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
	
	
	
	-- Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	FROM inv002
	WHERE va_cod_bod = @va_cod_bod
	
	
	-- Obtiene nombre del Delivery
	SELECT @va_nom_del = va_nom_del
	FROM cmr015
	WHERE va_cod_del = @va_cod_del
	
	-- Obtiene nombre del Vendedor
	SELECT @va_nom_ven = va_nom_ven
	FROM cmr014
	WHERE va_cod_ven = @va_cod_ven
	
	--Obtiene Totales segun moneda de la venta
	IF (@va_mon_vta = 'B')
	BEGIN
		SET @va_tot_bru = @va_sub_toB
		SET @va_des_cue = @va_dto_vtB
		SET @va_tot_net = @va_tot_vtB
	END
	IF (@va_mon_vta = 'U')
	BEGIN
		SET @va_tot_bru = @va_sub_toU
		SET @va_des_cue = @va_dto_vtU
		SET @va_tot_net = @va_tot_vtU
	END
	
	--// obtiene datos de Talonario
	SELECT @va_for_log = va_for_log,
		   @va_fir_ma1 = va_fir_ma1,
		   @va_fir_ma2 = va_fir_ma2,
		   @va_fir_ma3 = va_fir_ma3,
		   @va_fir_ma4 = va_fir_ma4
	 FROM ads004
	WHERE va_ide_doc = @va_doc_vta AND 
		  va_nro_tal = @va_nro_tal
	 IF @@ROWCOUNT = 0
	 BEGIN
		SET @va_for_log = 0
		SET @va_fir_ma1 = ''
		SET @va_fir_ma2 = ''
		SET @va_fir_ma3 = ''
		SET @va_fir_ma4 = ''
	 END
	 
	 IF @va_for_log = 1
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 12
	 END
	 IF @va_for_log = 2
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 13
	 END	
	 IF @va_for_log = 3
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 14
	 END	
	 IF @va_for_log = 4
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 15
	 END	
	 
	--// Cursor sobre Detalle
	DECLARE vc_cmr005 CURSOR LOCAL FOR
	SELECT va_itm_vta, va_cod_pro, va_des_pro, va_can_uni, va_und_inv,
		   (va_mto_brB - va_val_dtB), (va_mto_brU - va_val_dtU), va_mto_neB, va_mto_neU 
	 FROM cmr006 --WHERE va_ide_vta = 'VRS-000-000008'	
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
		  
		  
		
	--** Abre cursor		  
	OPEN vc_cmr005    
		 
	FETCH NEXT FROM vc_cmr005 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid, @va_und_inv,
								   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@va_mon_vta = 'B')
		BEGIN
			SET @va_pre_uni = @va_pre_uBs
			SET @va_pre_tot = @va_pre_tBs
		END
		IF (@va_mon_vta = 'U')
		BEGIN
			SET @va_pre_uni = @va_pre_uUs
			SET @va_pre_tot = @va_pre_tUs
		END
		
		
		--//** Obtiene nombre del producto de la tabla producto
		SELECT @va_des_pro = va_nom_pro
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro
		 
	----//** Obtiene nombre del delivery
	--	SELECT @va_nom_del = va_nom_del
	--	  FROM cmr010
	--	 WHERE va_cod_del = @va_cod_del
	
		INSERT INTO #tm_cmr005 VALUES ( @va_fec_vta		,
										@ar_ide_vta		,
										@ar_ges_vta		,
										@va_nro_vta		,
										@va_cod_bod		,
										@va_nom_bod		,
										@va_for_pag		,
										@va_tip_cam		,
										@va_cod_per		,
										@va_raz_soc		,
										@va_mon_vta		,
										@va_tot_bru		,
										@va_des_cue		,
										@va_tot_net		,
										@va_obs_vta		,
										@va_vta_par		,
										@va_est_ado		,
										@va_usr_reg		,
										@va_fec_reg		,
										@va_itm_vta		,
										@va_cod_pro		,
										@va_des_pro		,
										@va_can_tid		,
										@va_und_inv		,
										@va_pre_uni		,
										@va_pre_tot		,
										@va_fir_ma1		,
										@va_fir_ma2		,
										@va_fir_ma3		,
										@va_fir_ma4		,
										@va_for_log		,
										
										@va_cod_del		,
										@va_nom_del		,
										@va_cod_ven		,
										@va_nom_ven		,
										@va_cod_plv		,
										@va_log_emp		,
										@va_ref_vta		)
												
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de items en tabla temporal',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_cmr005 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid,@va_und_inv,
									   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	END	
CLOSE vc_cmr005
DEALLOCATE vc_cmr005

SELECT * FROM #tm_cmr005

COMMIT TRAN TR_cmr005
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_cmr005
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: cmr005_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE VENTAS
AUTOR:	CREARSIS(chl)
FECHA:	27-01-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_R01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_R01
GO

CREATE PROCEDURE cmr005_R01 @ar_cod_bod INT,			-- Almacen
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_est_ado CHAR(01),		-- Estado (T=todos ; H=valido ; N=anulado)
							@ar_tip_doc	INT				-- Tipo de documento (0=Ambos; 1=Factura; 2=Nota de Venta)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_cli_ini		INT,
@va_cli_fin		INT,
@va_bod_ini		INT,
@va_bod_fin		INT,
@va_nom_bod		VARCHAR(50)
--** CREA TABLA TEMPORAL
--CREATE TABLE #tm_vta005(
--	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
--	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
--	va_nro_itm		INT				not null,	--Numero de item 
--	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
--	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
--	va_und_vta		char(3)			null,		--Codigo de la Unidad de Medida
--	va_can_vta		DECIMAL(14,4),				--Cantidad de producto
--	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
--	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
--	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
--   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
SET @va_nom_bod = 'Todos';

IF (@ar_cod_bod = 0)
BEGIN	
	SET @va_bod_ini = 0
	SET @va_bod_fin = 9999999
END
IF (@ar_cod_bod <> 0)
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
	
	--Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @ar_cod_bod 
	
END

IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'



IF (@ar_tip_doc = 0)
BEGIN 
 SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, 
		@ar_cod_bod as va_cod_bod, @va_nom_bod as va_nom_bod, va_obs_vta
 FROM cmr005
 WHERE (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
  	   (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	    va_est_ado LIKE @ar_est_ado  
END
IF (@ar_tip_doc <> 0)
BEGIN 
 SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, 
		@ar_cod_bod as va_cod_bod, @va_nom_bod as va_nom_bod, va_obs_vta
 FROM cmr005
 WHERE (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
  	   (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	   (va_tip_vta = @ar_tip_doc) AND
	    va_est_ado LIKE @ar_est_ado  
END
	
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: cmr007_01a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO BUSCA PEDIDOS
AUTOR:	CREARSIS(chl)
FECHA:	19-01-2019
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr007_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr007_01a_p01
GO

CREATE PROCEDURE cmr007_01a_p01 @ar_cod_cli INT,			-- codigo cliente
							@ar_cod_bod CHAR(06),			-- Almacen
							@ar_fec_ini DATE,				-- Fecha de inicial
							@ar_fec_fin DATE,				-- Fecha de final
							@ar_tex_bus NVARCHAR(200),		-- Texto a buscar
							@ar_par_bus INT,				-- parametro Busqueda (0=Razon Social pedido; 1 = Observaciones)
							@ar_est_ado CHAR(01)			-- Estado (T=todos ; H=valido ; N=anulado)
							--@ar_tip_doc CHAR(01)			-- Tipo documento (V=pedido; C=Cotizacion; F=Factura)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_cli_ini		INT,
@va_cli_fin		INT,
@va_bod_ini		CHAR(06),
@va_bod_fin		CHAR(06)

IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
 
 PRINT @ar_cod_bod
IF (@ar_cod_bod = '0')
BEGIN	
	SET @va_bod_ini = '0'
	SET @va_bod_fin = '99-999'
END
IF (@ar_cod_bod <> '0')
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
END


IF (@ar_cod_cli = 0)
BEGIN	

	SET @va_cli_ini = 0
	SET @va_cli_fin = 9999999
END
IF (@ar_cod_cli <> 0)
BEGIN	
	SET @va_cli_ini = @ar_cod_cli
	SET @va_cli_fin = @ar_cod_cli
END



IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'


	IF(@ar_par_bus = 0)	 -- Busca por Razon Social pedido
	BEGIN
		 SELECT va_fec_ped,va_doc_ped, va_ide_ped, va_nro_ped, va_cod_per, va_raz_soc, 
				va_mon_ped, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_ped, va_ges_ped
		 FROM cmr007
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_ped BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			   va_raz_soc  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	IF(@ar_par_bus = 1)	 -- Busca por Observacion pedido
	BEGIN
		 SELECT va_fec_ped,va_doc_ped, va_ide_ped, va_nro_ped, va_cod_per, va_raz_soc, 
				va_mon_ped, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_ped, va_ges_ped
		 FROM cmr007
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_ped BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			   va_obs_ped  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	


END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: cmr007_02a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO REGISTRA PEDIDO
AUTOR:	CREARSIS(chl)
FECHA:	13-03-2021
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr007_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr007_02a_p01
GO

CREATE PROCEDURE cmr007_02a_p01 @ar_cod_usr NVARCHAR(15),	-- Usuario registro
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal
							
							@ar_pla_ped	INT,			-- Plantilla de pedido 
							--@va_ide_doc CHAR(03),		-- Documento de la operacion			/OBTENER DE LA PLANTILLA
							--@va_nro_tal INT,			-- Nro de talonario de la operacion		/OBTENER DE LA PLANTILLA
							@ar_cod_bod CHAR(06),		-- Bodega
							@ar_cod_cli INT,			-- codigo Cliente
							@ar_nit_cli	NVARCHAR(20),	-- Nit del cliente
							@ar_raz_soc	NVARCHAR(100),	-- Razon Social del cliente
							@ar_mon_ped CHAR(01),		-- Moneda de pedido (B=Bs ; U=Us )
							@ar_fec_ped DATE,			-- Fecha de pedido
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_ven_ded	INT,			-- Vendedor de la pedido
							@ar_lis_pre	INT,			-- Lista de precio usada en la pedido
							@ar_cod_caj INT,			-- Codigo de caja
							@ar_lin_cxc INT,			-- Linea Cta. x Cob. (codigo de libro)
							
							--@va_tip_cam	DECIMAL(7,5),	-- Tipo de cambio
							@ar_des_cue DECIMAL(10,2),	-- Descuento General
							@ar_obs_ped NVARCHAR(200),  -- Observacion
							@ar_ped_par CHAR(01)	,	-- pedido para (M=Mesa; L=Llevar; D=Delivery)
							@ar_cod_del	INT			,	-- Codigo Delivery
							
							@ar_ref_ped NVARCHAR(20)	-- Referecia del documento
								
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),

@va_ide_doc		CHAR(03),
@va_nro_tal		INT,
@va_nro_tal_tmp		INT,

@va_nro_ped		INT,			-- Numero de del documento
@va_nro_ped_tmp INT,
@va_ide_ped		VARCHAR(20),	--Identificador de la pedido (XXX|000-00000)
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 

@va_opc_und		INT,			--Opcion de unidad de medida seleccionado
@va_und_umd		CHAR(03),		--Unidad de medida inventario del producto
@va_und_ped		CHAR(03),		--Unidad de medida de pedido del producto
@va_can_uin		DECIMAL(14,4),	--Cantidad inventario de producto
@va_can_ped		DECIMAL(14,4),	--Cantidad de producto
@va_eqv_ped		DECIMAL(7,3),	-- Equivalencia entre @va_und_ped y @va_und_umd
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario de item en la moneda del documento
@va_pre_tot		DECIMAL(16,2),	--Precio Total de item en la moneda del documento
@va_des_cue		DECIMAL(16,2),	--Descuento del item en moneda de la pedido
@va_pre_lis		DECIMAL(16,2),	--Precio de la lista de precio del item en moneda de la pedido
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_cod_fam		VARCHAR(15),	-- Codigo de familida a la que pertenece el producto
@va_tip_fam		CHAR(01),		-- Tipo de familia 

@va_tot_bBs		DECIMAL(16,2),	-- Total bruto del documento en Bs
@va_tot_bUs		DECIMAL(16,2),	-- Total bruto del documento en Us
@va_des_cBs		DECIMAL(16,2),	-- Descuento global al documento en Bs.
@va_des_cUs		DECIMAL(16,2),	-- Descuento global al documento en Us.
@va_tot_nBs		DECIMAL(16,2),	-- Total neto del documento en Bs.
@va_tot_nUs		DECIMAL(16,2),	-- total neto del documento en Us.

@va_pre_uBs		DECIMAL(16,2),	-- Precio unitario en Bs
@va_pre_uUs		DECIMAL(16,2),	-- Precio unitario en Us.
@va_pre_tBs		DECIMAL(16,2),	-- Precio total en Bs.
@va_pre_tUs		DECIMAL(16,2),	-- precio total en Us.
@va_dto_uBs		DECIMAL(16,2),	-- Descueto lineal unitario en Bs.
@va_dto_uUs		DECIMAL(16,2),	-- Descueto lineal unitario en Us.
@va_por_ite		DECIMAL(16,2),	-- Porcentaje lineal unitario

@va_con_tad		INT,			-- Contador para validar

--// Valores para prorratear descuento global del documento sobre los items
@va_por_cen		DECIMAL(16,5),	-- Porcentaje de descuento unitario
@va_des_uni		DECIMAL(16,2),	-- Valor de descuento unitario
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),	-- Descuento acumulado para calculo
@va_pmx_des		DECIMAL(16,2),	-- Porcentaje Descuento permitido segun lista de precio
@va_pmx_inc		DECIMAL(16,2),	-- Porcentaje Incremento permitido segun lista de precio

-- variables para gestion
@va_ges_ped		INT,
@va_ges_tio		INT,
@va_ges_per		INT,
@va_fec_ini		DATE, 
@va_fec_fin		DATE,

@va_fec_exp		DATE,			-- Fecha de expiracion de la libreta de  la persona
@va_sal_act		DECIMAL(16,2),	-- Saldo actual de la libreta de la persona
@va_mto_lim		DECIMAL(16,2),	-- monto limite autorizado en la libreta de la persona

@va_sal_aut		DECIMAL(16,2),	-- Saldo autorizado de credito (@va_mto_lim - @va_sal_act)
@va_mon_lib		CHAR(01),		-- Moneda de la libreta

@va_tip_cam		DECIMAL(7,5),	-- TIPO DE CAMBIO

@va_stk_act		DECIMAL(16,4),	-- ESTOCK ACTUAL DEL PRODUCTO OBTENIDO DEL PROCEDIMIENTO (inv100_01p2)
@va_prd_ped		INT			 ,	-- Periodo de la pedido
@va_cod_bod		INT			 ,	-- Codigo de bodega en  INT
@va_por_del		DECIMAL (3,1)	-- Porcentaje correspondiente al delivery

		
	
--** CREA TABLA TEMPORAL
CREATE TABLE #tm_ped001(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_pre_lis		DECIMAL(16,2),				--Precio de lista en la moneda del documento
	va_des_cue		DECIMAL(16,2),				--Descuento en la moneda del documento
	va_por_cen		DECIMAL(16,2) 				--Pocentaje de descuento
	
   )
   
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_ped001
BEGIN TRY     
  
  SET @va_tip_cam = 1
  
   -- Carga temporal de pedido
   INSERT INTO #tm_ped001
	SELECT * FROM cmr006tmp
	WHERE va_cod_tmp = @ar_cod_tmp AND
		  va_cod_usr = @ar_cod_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('No hay ningun item para la pedido',16,1)
		RETURN
	END

	
	-- Verifica plantilla de pedido
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado,
		   @va_ide_doc = va_doc_ped,
		   @va_nro_tal = va_tal_ped
	FROM cmr004
	WHERE va_cod_plv = @ar_pla_ped
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Plantilla de pedido no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Plantilla de pedido se encuentra Deshabilitada',16,1)
		RETURN
	END	
	
	
	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @va_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado
	 FROM ads004
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal
		   
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	
		SELECT	--@va_est_ado = va_est_ado,
				@va_ges_ped = va_ges_tio,
				@va_prd_ped = va_ges_per,
				@va_fec_ini = va_fec_ini,
				@va_fec_fin = va_fec_fin
		  FROM	ads016
		 WHERE	(@ar_fec_ped BETWEEN va_fec_ini AND va_fec_fin)
		 
		  
		
 IF (@va_ges_ped = 0)
 BEGIN
	RAISERROR ('la fecha del documento no se encuentra dentro de una gestion definida',16,1)
	RETURN
 END
/*
 IF (@va_est_ado = 'C')
 BEGIN
	RAISERROR ('la fecha del documento se encuentra dentro de un periodo cerrado',16,1)
	RETURN
 END
*/
		
--// Verifica Numeracion / inicialilza fechas iniciales para numeracion
	SET @va_fec_ini = '01.01.1990'
	SET @va_fec_fin = '01.01.1990'
	
	SELECT @va_nro_ped = va_con_tad,
		   @va_fec_ini = va_fec_ini,
		   @va_fec_fin = va_fec_fin
	FROM ads005
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal AND
		  va_ges_tio = @va_ges_ped
	IF @@ROWCOUNT = 0
	BEGIN
		
	    SET @msg = 'El Talonario NO dispone de numeracion para la gestion ' + CAST (@va_ges_ped AS VARCHAR(3))
		RAISERROR ( @msg ,16,1)
		RETURN
	END
	
	IF NOT (@ar_fec_ped > @va_fec_ini AND @ar_fec_ped < @va_fec_fin)
	BEGIN
		RAISERROR ('La fecha del documento no esta dentro del rango permitido en la numeracion para la gestion',16,1)
		RETURN
	END	
	
	--// Verifica Bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Bodega no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Bodega se encuentra Deshabilitada',16,1)
		RETURN
	END
	
	
	--// Verifica CLIENTE
	SELECT @va_est_ado = va_est_ado
	FROM cmr013
	WHERE va_cod_per = @ar_cod_cli
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Cliente no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Cliente se encuentra Deshabilitado',16,1)
		RETURN
	END

	/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	--// Verifica LISTA DE PRECIO
	SELECT @va_est_ado = va_est_ado
	FROM cmr001
	WHERE va_cod_lis = @ar_lis_pre
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Lista de Precio no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Lista de Precio se encuentra Deshabilitada',16,1)
		RETURN
	END

/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	
	--Suma en uno el contador de pedido
	SET @va_nro_ped = @va_nro_ped + 1
	
	
	SET @va_nro_tal_tmp = 1000 + @va_nro_tal
	SET @va_nro_ped_tmp = 1000000 + @va_nro_ped
	
	--Prepara identificador de la pedido XXX-000-00000
	SET @va_ide_ped = @va_ide_doc + '-' + SUBSTRING(CAST (@va_nro_tal_tmp AS VARCHAR(4)),2,3) + '-' + SUBSTRING(CAST(@va_nro_ped_tmp AS VARCHAR(7)),2,7)
	
	
	IF @ar_mon_ped ='B'
	BEGIN
		SELECT @va_tot_bBs = SUM(va_pre_tot) 
		FROM #tm_ped001
		
		SET @va_tot_bUs = @va_tot_bBs / @va_tip_cam
		
		SET @va_des_cBs = @ar_des_cue
		SET @va_des_cUs = @ar_des_cue / @va_tip_cam
		
		SET @va_tot_nBs = @va_tot_bBs - @va_des_cBs
		SET @va_tot_nUs = @va_tot_nBs / @va_tip_cam
	END
	ELSE
	BEGIN
		SELECT @va_tot_bUs = SUM(va_pre_tot) 
		FROM #tm_ped001
		
		SET @va_tot_bBs = @va_tot_bUs * @va_tip_cam
		
		SET @va_des_cUs = @ar_des_cue
		SET @va_des_cBs = @va_des_cUs * @va_tip_cam
		
		SET @va_tot_nUs = @va_tot_bUs - @va_des_cUs
		SET @va_tot_nBs = @va_tot_nUs * @va_tip_cam
	END
	
	/*
	--// Verifica Linea de credito si es al credito
	IF @ar_for_pag = 1
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM ecp007
		WHERE va_cod_per = @ar_cod_cli AND
			  va_cod_lib = @ar_lin_cxc
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
			RETURN
		END
		
		IF( @ar_fec_ped > @va_fec_exp)
		BEGIN
			RAISERROR ('La linea de credito de la persona a expirado',16,1)
			RETURN
		END
		
		SELECT @va_mon_lib = va_mon_lib
		  FROM ecp006
		WHERE  va_cod_lib = @ar_lin_cxc
		
		SET @va_sal_aut = @va_mto_lim - @va_sal_act
		
		IF (@va_mon_lib = 'B')
		BEGIN
			IF (@va_tot_nBs > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la pedido supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		ELSE
		BEGIN
			IF (@va_tot_nus > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la pedido supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		
	END
	*/
	
	
	-- Obtiene Porcentaje Delivery
	SET @va_por_del = 0
	IF(@ar_ped_par ='D')
	BEGIN
		SELECT @va_por_del = va_por_del 
		  FROM cmr015
		 WHERE va_cod_del = @ar_cod_del
	END
	ELSE
	BEGIN
		SET @ar_cod_del = 0
		SET @va_por_del = 0
	END
		
	-- REGISTRA ENCABEZADO pedido select * from cmr005
	INSERT INTO cmr007 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_ped, @va_ges_ped, @va_ide_ped,  @ar_cod_cli,
							  @ar_raz_soc,@ar_nit_cli, @ar_fec_ped, @va_tip_cam, @ar_pla_ped, @ar_ven_ded, @ar_mon_ped,
							  @ar_for_pag,@ar_cod_caj,@ar_lin_cxc,@ar_ref_ped,
							  @ar_cod_bod, @ar_lis_pre, @ar_ped_par,@ar_cod_del, @va_por_del,  
							  @va_tot_bBs, @va_tot_bUs,@va_des_cBs, @va_des_cUs,@va_tot_nBs, @va_tot_nUs, 
							  @ar_obs_ped, @ar_cod_usr, GETDATE(), '', '01/01/1900','V')
				 		 
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Ocurrio un error al ingresar el encabezado de pedido',16,1)
		RETURN
	END
		
	/*	
	--// Si es factura 
	if (@ar_tip_ped = 1)
	BEGIN
	
	
	--//graba debito fiscal
	INSERT INTO ctb008 VALUES (@va_ges_ped,@va_prd_ped,@va_ide_ped,@va_nro_ped,@ar_nro_aut,@ar_nit_cli,@ar_raz_soc,@va_tot_bBs,
								@va_des_cBs,@va_tot_nBs, (@va_tot_nBs * 0.13), '' , @ar_fec_ped,GETDATE(),null)
	
		
	END	
	*/		
--//OBTIENE IMPORTE TOTAL DEL DOCUMENTO
SELECT @va_imp_tot = sum(va_pre_tot)
FROM #tm_ped001

	
	
--// Cursor sobre temporal
DECLARE vc_det_ped CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_opc_und, va_can_tid,va_pre_uni,
	   va_pre_tot, va_pre_lis, va_des_cue, va_por_cen
FROM #tm_ped001	
	
--** Abre cursor		  
OPEN vc_det_ped    
	 
SET @va_con_tad = 0
FETCH NEXT FROM vc_det_ped 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_ped,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_und_ped = va_und_vta,
		   @va_eqv_ped = va_eqv_vta,
		   @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	--//VERIFICA TIPO DE FAMILIA (SERVICIO/DETALLE/...)
	SELECT @va_est_ado = va_est_ado,
		   @va_tip_fam = va_tip_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +') no se encuentra registrada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +')  se encuentra deshabilitada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	-- Calcula cantidades segun unidades de medida
	SET @va_can_uin = @va_can_ped
	
	IF (@va_tip_fam <> 'S')
	BEGIN
		IF (@va_und_umd <> @va_und_ped) 
		BEGIN
			IF(@va_opc_und = 0)
				SET @va_can_uin = @va_can_ped * @va_eqv_ped
		END
	END
	
	SET @va_cod_bod = @ar_cod_bod
		
--	-- VERIFICA EXISTENCIA
--	IF (@va_tip_fam <> 'S' AND @va_tip_fam <> 'C' )
--	BEGIN
--		SET @va_stk_act = 0
		
		
--		EXECUTE inv100_01a_p02 @va_cod_bod, @va_cod_pro, @ar_fec_ped, @va_stk_act OUTPUT
		
--		IF (@va_stk_act IS NULL)
--			SET @va_stk_act = 0
			
--		IF (@va_stk_act = 0) OR (@va_can_uin > @va_stk_act)	
--		BEGIN
--			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : 
--El producto ('+ @va_cod_pro +') NO cuenta con existencia suficiente  
--Saldo a la fecha: (' + CAST(@va_stk_act AS VARCHAR(16)) + ')   '
--			RAISERROR (@msg,16,1)
--			RETURN
--		END
--	END
	
	
	/*
	IF(@va_tip_fam = 'C')
	BEGIN
		-- OBTIENE PRODUCTOS QUE COMPONEN EL COMBO
	
	END
	*/
	
	-- Calcula Precios unitarios
	IF @ar_mon_ped = 'B' AND (@va_und_umd = @va_und_ped)
	BEGIN
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @va_tip_cam
	END
	
	IF @ar_mon_ped = 'B' AND (@va_und_umd <> @va_und_ped)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA pedido FUE "UNIDAD DE pedido" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_ped
			
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @va_tip_cam
	END
	
	IF @ar_mon_ped = 'U' AND (@va_und_umd = @va_und_ped)
	BEGIN
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @va_tip_cam
	END
	
	IF @ar_mon_ped = 'U' AND (@va_und_umd <> @va_und_ped)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA pedido FUE "UNIDAD DE pedido" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_ped
			
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @va_tip_cam
	END
	
	-- Calcula Precios y descuento unitarios Totales 
	IF @ar_mon_ped = 'B'
	BEGIN
		SET @va_pre_tBs = @va_pre_tot
		SET @va_pre_tUs = @va_pre_tot / @va_tip_cam
		
		SET @va_dto_uBs = @va_des_cue
		SET @va_dto_uUs = @va_des_cue / @va_tip_cam
	END
	IF @ar_mon_ped = 'U'
	BEGIN
		SET @va_pre_tUs = @va_pre_tot
		SET @va_pre_tBs = @va_pre_tot * @va_tip_cam
		
		SET @va_dto_uUs = @va_des_cue
		SET @va_dto_uBs = @va_des_cue * @va_tip_cam
	END
	
	
	
	IF (@va_tip_fam = 'D')
	BEGIN
		
		--//VERIFICA LIMITES DE DESCUENTO SEGUN LISTA DE PRECIO
		SELECT @va_pmx_des = va_pmx_des,
			   @va_pmx_inc = va_pmx_inc
		FROM cmr002
		 WHERE va_cod_lis = @ar_lis_pre AND
			   va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con precio definido en la lista de precio ('+ CAST(@ar_lis_pre AS NVARCHAR(10))  +')'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_por_ite > @va_pmx_des 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El descuento para el producto ('+ @va_cod_pro +'), supera el permitido (Desc. Max.: '+ CAST(@va_pmx_des AS NVARCHAR(10)) +' %)  '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	
	-- PRORATEA DESCUENTO GENERAL DOCUMENTO A LOS ITEM, EN MONEDA DEL DOCUMENTO
	SET @va_por_cen = (@va_pre_tot * 100) / @va_imp_tot
	
	SET @va_des_uni = (@va_por_cen * @ar_des_cue) / 100
	SET @va_des_acu = @va_des_acu + @va_des_uni
	
	IF @@CURSOR_ROWS = @va_con_tad
	BEGIN
		IF @va_des_acu <> @ar_des_cue
			SET @va_des_uni = @va_des_uni + (@ar_des_cue - @va_des_acu)
	END
	
	-- OBTIENE DESCUENTO GLOBAL UNITARIOS PRORATEADOS EN BS Y US PARA CALCULOS
	IF @ar_mon_ped ='B'
	BEGIN
		SET @va_des_unB = @va_des_uni
		SET @va_des_unU = @va_des_uni / @va_tip_cam
	END
	ELSE
	BEGIN
		SET @va_des_unU = @va_des_uni
		SET @va_des_unB = @va_des_uni * @va_tip_cam
	END
	
	
	
	-- REGISTRA DETALLE DE pedido select * from cmr006
	INSERT INTO cmr008 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_ped, @va_ges_ped, @va_ide_ped, @va_nro_itm,
							  @va_cod_pro,@va_des_pro, @va_opc_und,@va_und_ped,@va_und_umd,@va_eqv_ped,@va_can_ped,@va_can_uin,
							  @va_pre_lis, (@va_pre_uBs + @va_dto_uBs), (@va_pre_uUs + @va_dto_uUs), 
							  @va_dto_uBs, @va_dto_uUs,@va_por_ite, @va_pre_tBs,@va_pre_tUs )
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al ingresar item del detalle',16,1)
		RETURN
	END

   
 
FETCH NEXT FROM vc_det_ped 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_ped,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite
END


--// GRABA CXC 

--// GRABA INGRESO EFECTIVO


--// ACTUALIZA CONTADOR
UPDATE ads005 SET va_con_tad = @va_nro_ped
WHERE va_ide_doc = @va_ide_doc AND 
	  va_nro_tal = @va_nro_tal AND
	  va_ges_tio = @va_ges_ped

CLOSE vc_det_ped
DEALLOCATE vc_det_ped

-- Borra temporal
DELETE cmr006tmp
WHERE va_cod_tmp = @ar_cod_tmp AND
	  va_cod_usr = @ar_cod_usr

SELECT * FROM  cmr007
WHERE va_doc_ped = @va_ide_doc	AND
	  va_nro_tal = @va_nro_tal	AND
	  va_nro_ped = @va_nro_ped	AND
	  va_ges_ped = @va_ges_ped 
	
	COMMIT TRAN TR_ped001
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ped001
	RETURN
END CATCH	

GO  
/*
ARCHIVO: cmr007_02a_p02.sql
PROCEDIMIENTO: PROCEDIMIENTO VERIFICA ANTES DE GRABAR PEDIDO
AUTOR:	CREARSIS(chl)
FECHA:	21-04-2021
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr007_02a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.cmr007_02a_p02
GO

CREATE PROCEDURE cmr007_02a_p02 
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal
							
							@ar_pla_ped	INT,			-- Plantilla de pedido 
							@ar_cod_bod INT,		-- Bodega
							@ar_cod_cli INT,			-- codigo Cliente
							@ar_fec_ped DATE,			-- Fecha de pedido
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_lis_pre	INT			-- Lista de precio usada en la pedido
							
														
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),

@va_ide_doc		CHAR(03),
@va_nro_tal		INT,

@va_nro_ped		INT,			-- Numero de del documento
@va_nro_ped_tmp INT,
@va_ide_ped		VARCHAR(20),	--Identificador de la pedido (XXX|000-00000)
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 

@va_opc_und		INT,			--Opcion de unidad de medida seleccionado
@va_und_umd		CHAR(03),		--Unidad de medida inventario del producto
@va_und_ped		CHAR(03),		--Unidad de medida de pedido del producto
@va_can_uin		DECIMAL(14,4),	--Cantidad inventario de producto
@va_can_ped		DECIMAL(14,4),	--Cantidad de producto
@va_eqv_ped		DECIMAL(7,3),	-- Equivalencia entre @va_und_ped y @va_und_umd
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario de item en la moneda del documento
@va_pre_tot		DECIMAL(16,2),	--Precio Total de item en la moneda del documento
@va_des_cue		DECIMAL(16,2),	--Descuento del item en moneda de la pedido
@va_pre_lis		DECIMAL(16,2),	--Precio de la lista de precio del item en moneda de la pedido
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_cod_fam		VARCHAR(15),	-- Codigo de familida a la que pertenece el producto
@va_tip_fam		CHAR(01),		-- Tipo de familia 

@va_tot_bBs		DECIMAL(16,2),	-- Total bruto del documento en Bs
@va_tot_bUs		DECIMAL(16,2),	-- Total bruto del documento en Us
@va_des_cBs		DECIMAL(16,2),	-- Descuento global al documento en Bs.
@va_des_cUs		DECIMAL(16,2),	-- Descuento global al documento en Us.
@va_tot_nBs		DECIMAL(16,2),	-- Total neto del documento en Bs.
@va_tot_nUs		DECIMAL(16,2),	-- total neto del documento en Us.

@va_pre_uBs		DECIMAL(16,2),	-- Precio unitario en Bs
@va_pre_uUs		DECIMAL(16,2),	-- Precio unitario en Us.
@va_pre_tBs		DECIMAL(16,2),	-- Precio total en Bs.
@va_pre_tUs		DECIMAL(16,2),	-- precio total en Us.
@va_dto_uBs		DECIMAL(16,2),	-- Descueto lineal unitario en Bs.
@va_dto_uUs		DECIMAL(16,2),	-- Descueto lineal unitario en Us.
@va_por_ite		DECIMAL(16,2),	-- Porcentaje lineal unitario

@va_con_tad		INT,			-- Contador para validar

--// Valores para prorratear descuento global del documento sobre los items
@va_por_cen		DECIMAL(16,5),	-- Porcentaje de descuento unitario
@va_des_uni		DECIMAL(16,2),	-- Valor de descuento unitario
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),	-- Descuento acumulado para calculo
@va_pmx_des		DECIMAL(16,2),	-- Porcentaje Descuento permitido segun lista de precio
@va_pmx_inc		DECIMAL(16,2),	-- Porcentaje Incremento permitido segun lista de precio

-- variables para gestion
@va_ges_ped		INT,
@va_ges_tio		INT,
@va_ges_per		INT,
@va_fec_ini		DATE, 
@va_fec_fin		DATE,

@va_fec_exp		DATE,			-- Fecha de expiracion de la libreta de  la persona

@va_fec_fin_lis		DATE,			-- Fecha de fin de la lista de precio
@va_fec_ini_lis		DATE,			-- Fecha de inicio de la lista de precio

@va_sal_act		DECIMAL(16,2),	-- Saldo actual de la libreta de la persona
@va_mto_lim		DECIMAL(16,2),	-- monto limite autorizado en la libreta de la persona

@va_sal_aut		DECIMAL(16,2),	-- Saldo autorizado de credito (@va_mto_lim - @va_sal_act)
@va_mon_lib		CHAR(01),		-- Moneda de la libreta

@va_tip_cam		DECIMAL(7,5),	-- TIPO DE CAMBIO

@va_stk_act		DECIMAL(16,4),	-- ESTOCK ACTUAL DEL PRODUCTO OBTENIDO DEL PROCEDIMIENTO (inv100_01p2)
@va_prd_ped		INT			 ,	-- Periodo de la pedido
@va_cod_bod		INT			 ,	-- Codigo de bodega en  INT
@va_por_del		DECIMAL (3,1)	-- Porcentaje correspondiente al delivery

		
	
--** CREA TABLA TEMPORAL
CREATE TABLE #tm_ped001(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_pre_lis		DECIMAL(16,2),				--Precio de lista en la moneda del documento
	va_des_cue		DECIMAL(16,2),				--Descuento en la moneda del documento
	va_por_cen		DECIMAL(16,2) 				--Pocentaje de descuento
	
   )
   
IF @@ERROR <> 0
   RETURN

--BEGIN TRAN TR_ped001
BEGIN TRY     
  
  SET @va_tip_cam = 1
  SET @va_cod_usr = SYSTEM_USER
  
   -- Carga temporal de pedido
   INSERT INTO #tm_ped001
	SELECT * FROM cmr006tmp
	WHERE va_cod_tmp = @ar_cod_tmp AND
		  va_cod_usr = @va_cod_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('No hay ningun item para la pedido',16,1)
		RETURN
	END

	
	-- Verifica plantilla de pedido
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado,
		   @va_ide_doc = va_doc_ped,
		   @va_nro_tal = va_tal_ped
	FROM cmr004
	WHERE va_cod_plv = @ar_pla_ped
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Plantilla de pedido no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Plantilla de pedido se encuentra Deshabilitada',16,1)
		RETURN
	END	
	
	
	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @va_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado
	 FROM ads004
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal
		   
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	
		SELECT	--@va_est_ado = va_est_ado,
				@va_ges_ped = va_ges_tio,
				@va_prd_ped = va_ges_per,
				@va_fec_ini = va_fec_ini,
				@va_fec_fin = va_fec_fin
		  FROM	ads016
		 WHERE	(@ar_fec_ped BETWEEN va_fec_ini AND va_fec_fin)
		 
		  
		
 IF (@va_ges_ped = 0)
 BEGIN
	RAISERROR ('la fecha del documento no se encuentra dentro de una gestion definida',16,1)
	RETURN
 END
/*
 IF (@va_est_ado = 'C')
 BEGIN
	RAISERROR ('la fecha del documento se encuentra dentro de un periodo cerrado',16,1)
	RETURN
 END
*/
		
--// Verifica Numeracion / inicialilza fechas iniciales para numeracion
	SET @va_fec_ini = '01.01.1990'
	SET @va_fec_fin = '01.01.1990'
	
	SELECT @va_nro_ped = va_con_tad,
		   @va_fec_ini = va_fec_ini,
		   @va_fec_fin = va_fec_fin
	FROM ads005
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal AND
		  va_ges_tio = @va_ges_ped
	IF @@ROWCOUNT = 0
	BEGIN
		
	    SET @msg = 'El Talonario NO dispone de numeracion para la gestion ' + CAST (@va_ges_ped AS VARCHAR(3))
		RAISERROR ( @msg ,16,1)
		RETURN
	END
	
	IF NOT (@ar_fec_ped > @va_fec_ini AND @ar_fec_ped < @va_fec_fin)
	BEGIN
		RAISERROR ('La fecha del documento no esta dentro del rango permitido en la numeracion para la gestion',16,1)
		RETURN
	END	
	
	--// Verifica Bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Bodega no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Bodega se encuentra Deshabilitada',16,1)
		RETURN
	END
	
	
	--// Verifica CLIENTE
	SELECT @va_est_ado = va_est_ado
	FROM cmr013
	WHERE va_cod_per = @ar_cod_cli
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Cliente no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Cliente se encuentra Deshabilitado',16,1)
		RETURN
	END

	/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	--// Verifica LISTA DE PRECIO
	SELECT @va_est_ado = va_est_ado,
			@va_fec_fin_lis = va_fec_fin,
			@va_fec_ini_lis = va_fec_ini
	FROM cmr001
	WHERE va_cod_lis = @ar_lis_pre
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Lista de Precio no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Lista de Precio se encuentra Deshabilitada',16,1)
		RETURN
	END

	-- Verifica que la fecha de la venta este dentro del rango de fechas de la lista de precios
	IF( @ar_fec_ped > @va_fec_fin_lis or @ar_fec_ped < @va_fec_ini_lis)
	BEGIN
		RAISERROR ('La Lista de Precio NO puede ser usada para la fecha del documento',16,1)
		RETURN
	END


/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	
	/*
	--// Verifica Linea de credito si es al credito
	IF @ar_for_pag = 1
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM ecp007
		WHERE va_cod_per = @ar_cod_cli AND
			  va_cod_lib = @ar_lin_cxc
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
			RETURN
		END
		
		IF( @ar_fec_ped > @va_fec_exp)
		BEGIN
			RAISERROR ('La linea de credito de la persona a expirado',16,1)
			RETURN
		END
		
		SELECT @va_mon_lib = va_mon_lib
		  FROM ecp006
		WHERE  va_cod_lib = @ar_lin_cxc
		
		SET @va_sal_aut = @va_mto_lim - @va_sal_act
		
		IF (@va_mon_lib = 'B')
		BEGIN
			IF (@va_tot_nBs > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la pedido supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		ELSE
		BEGIN
			IF (@va_tot_nus > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la pedido supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		
	END
	*/

	/*
	--// SI ES EFECTIVO-GRABA RECIBO DE INGRESO A CAJA
	IF (@ar_for_pag = 0 ) --Contado
	BEGIN
	 --select * from tes002
		INSERT INTO TES002 VALUES (@ar_cod_caj,@va_ide_doc,@va_nro_tal,@va_nro_ped,@va_ges_ped,@va_ide_ped,@ar_cod_cli,@ar_raz_soc,0,
									@ar_mon_ped,@va_imp_tot,@ar_mto_efe, @ar_cam_bio, @ar_obs_ped,'V')
	END
	ELSE -- SI ES AL CREDITO GRABA EXIGIBLE X COBRAR
	BEGIN
	
	
	END
	*/
	

	
	
	
--// Cursor sobre temporal
DECLARE vc_det_ped CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_opc_und, va_can_tid,va_pre_uni,
	   va_pre_tot, va_pre_lis, va_des_cue, va_por_cen
FROM #tm_ped001	
	
--** Abre cursor		  
OPEN vc_det_ped    
	 
SET @va_con_tad = 0
FETCH NEXT FROM vc_det_ped 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_ped,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_und_ped = va_und_vta,
		   @va_eqv_ped = va_eqv_vta,
		   @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	--//VERIFICA TIPO DE FAMILIA (SERVICIO/DETALLE/...)
	SELECT @va_est_ado = va_est_ado,
		   @va_tip_fam = va_tip_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +') no se encuentra registrada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +')  se encuentra deshabilitada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	-- Calcula cantidades segun unidades de medida
	SET @va_can_uin = @va_can_ped
	
	IF (@va_tip_fam <> 'S')
	BEGIN
		IF (@va_und_umd <> @va_und_ped) 
		BEGIN
			IF(@va_opc_und = 0)
				SET @va_can_uin = @va_can_ped * @va_eqv_ped
		END
	END
	
	SET @va_cod_bod = @ar_cod_bod
		
--	-- VERIFICA EXISTENCIA
--	IF (@va_tip_fam <> 'S' AND @va_tip_fam <> 'C' )
--	BEGIN
--		SET @va_stk_act = 0
		
		
--		EXECUTE inv100_01a_p02 @va_cod_bod, @va_cod_pro, @ar_fec_ped, @va_stk_act OUTPUT
		
--		IF (@va_stk_act IS NULL)
--			SET @va_stk_act = 0
			
--		IF (@va_stk_act = 0) OR (@va_can_uin > @va_stk_act)	
--		BEGIN
--			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : 
--El producto ('+ @va_cod_pro +') NO cuenta con existencia suficiente  
--Saldo a la fecha: (' + CAST(@va_stk_act AS VARCHAR(16)) + ')   '
--			RAISERROR (@msg,16,1)
--			RETURN
--		END
--	END
	
	
	/*
	IF(@va_tip_fam = 'C')
	BEGIN
		-- OBTIENE PRODUCTOS QUE COMPONEN EL COMBO
	
	END
	*/
	
	
	
	
	IF (@va_tip_fam = 'D')
	BEGIN
		
		--//VERIFICA LIMITES DE DESCUENTO SEGUN LISTA DE PRECIO
		SELECT @va_pmx_des = va_pmx_des,
			   @va_pmx_inc = va_pmx_inc
		FROM cmr002
		 WHERE va_cod_lis = @ar_lis_pre AND
			   va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con precio definido en la lista de precio ('+ CAST(@ar_lis_pre AS NVARCHAR(10))  +')'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_por_ite > @va_pmx_des 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El descuento para el producto ('+ @va_cod_pro +'), supera el permitido (Desc. Max.: '+ CAST(@va_pmx_des AS NVARCHAR(10)) +' %)  '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	
	
   
 
FETCH NEXT FROM vc_det_ped 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_ped,@va_pre_uni,
	 @va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite
END


CLOSE vc_det_ped
DEALLOCATE vc_det_ped
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ped001
	RETURN
END CATCH	

GO  
/*
ARCHIVO: cmr007_05a_p01.sql
PROCEDIMIENTO: CONSULTA PEDIDO 
	(Formato = 0 ; en Undidad de Compra)
AUTOR:	CREARSIS(chl)
FECHA:	26-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.cmr007_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr007_05a_p01
GO

CREATE PROCEDURE cmr007_05a_p01 @ar_ide_ped	NVARCHAR(20),	-- Identificador de la compra
								@ar_ges_ped	INT	-- gestion de la compra
							 WITH ENCRYPTION AS
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
--@ar_ide_ped	NVARCHAR(20),	-- Identificador de la compra
--@ar_ges_ped	INT	,-- gestion de la compra
@msg			nvarchar(200),
@va_fec_ped		DATETIME,
@va_nro_ped		INT,
@va_cod_bod		CHAR(06),
@va_nom_bod		VARCHAR(50),			-- Numero de del documento
@va_for_pag		INT,	--Identificador de la venta (XXX|000-00000/2018)
@va_tip_cam		DECIMAL(4,2),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(80),
@va_mon_ped		CHAR(01),
@va_sub_toB		DECIMAL(16,5),
@va_sub_toU		DECIMAL(16,5),
@va_tot_bru		DECIMAL(16,5),
@va_dto_vtB		DECIMAL(16,5),
@va_dto_vtU		DECIMAL(16,5),
@va_des_cue		DECIMAL(16,5),
@va_tot_vtB		DECIMAL(16,5),
@va_tot_vtU		DECIMAL(16,5),
@va_tot_net		DECIMAL(16,5),
@va_obs_ped		VARCHAR(200),
@va_ped_par		CHAR(01)	,
@va_est_ado		CHAR(01),
@va_usr_reg		VARCHAR(15),
@va_fec_reg		DATETIME,
@va_itm_ped		INT,
@va_cod_pro		VARCHAR(15),
@va_des_pro		varchar(120)	,			--Descripcion del Producto 
@va_can_tid		DECIMAL(14,4),				--Cantidad de producto
@va_und_inv		CHAR(03)		,			--Numero de item 
@va_pre_uBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tot		DECIMAL(16,2),

@va_doc_ped     CHAR(03),					-- Documento de la operacion
@va_nro_tal     INT,						-- Nro de talonario de la operacion
@va_fir_ma1		VARCHAR(20),				--Firma del talonario 1
@va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
@va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
@va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
--@va_log_emp		VARBINARY(max),				--Logo de la empresa
@va_log_emp		NVARCHAR(100),				--Logo de la empresa
@va_for_log		TINYINT, 					--Formato de logo
											-- 0=Nombre de la empresa
											-- 1=logo 1
@va_cod_del		int,
@va_nom_del		varchar(20),
@va_cod_ven		INT,						--Codigo Vendedor
@va_nom_ven		VARCHAR(50),				--Nombre vendedor

@va_cod_plv		INT,						-- Plantilla de venta											
											
@va_ref_ped		VARCHAR(20)

	

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_cmr007(
	va_fec_ped		DATETIME		NOT NULL,	--Codigo del usuario
	va_ide_ped		VARCHAR(20)		NOT NULL,	--Identificador compuesto para la venta
	va_ges_ped		INT				not null,	--Gestion de la venta 
	va_nro_ped		INT				NOT NULL,	--Nro venta
	va_cod_bod		char(06)		not null,	--Almacen
	va_nom_bod		VARCHAR(50)		not null,	--Nombre almacen
	va_for_pag		INT				NOT NULL,	-- Forma de Pago **
	va_tip_cam		DECIMAL(4,2)	NOT NULL,	--Tipo de cambio **
	va_cod_per		INT				not null,	--Codigo persona
	va_raz_soc		VARCHAR(80)		not null,	--Razon social
	va_mon_ped		CHAR(01)		not null,	--Numero de item 
	va_tot_bru		DECIMAL(16,5)	not null,	--Numero de item 
	va_des_cue		DECIMAL(16,5)	not null,	--Numero de item 
	va_tot_net		DECIMAL(16,5)	not null,	--Numero de item 
	va_obs_ped		VARCHAR(200)	not null,	--Numero de item 
	va_ped_par		CHAR(01)		not null,	--Venta para (M=Mesa; L=Llevar ; D=Delivery)
	
	va_est_ado		CHAR(01)		not null,	--Numero de item 
	va_usr_reg		VARCHAR(15)		NOT NULL,	--Usuario registro
	va_fec_reg		DATETIME		NOT NULL,	--Fecha de registro
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		not null,	--Numero de item 
	va_des_pro		varchar(120)	not null,	--Descripcion del Producto 
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_und_inv		CHAR(03)		not null,	--Numero de item 
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
    va_fir_ma1		VARCHAR(20),    		    --Firma del talonario 1
	va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
	va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
	va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
	va_for_log		TINYINT, 	                --Formato de logo
												-- 0=Nombre de la empresa
												-- 1=logo 1
	--va_log_emp		VARBINARY(max),				--Logo de la empresa
	va_cod_del		INT,
	va_nom_del		VARCHAR(20),
	va_cod_ven		INT,						--Codigo Vendedor
	va_nom_ven		VARCHAR(50),				--Nombre vendedor
	va_cod_plv		INT,						--Codigo plantilla de venta
	va_log_emp		NVARCHAR(100),				--Logo de la empresa
	va_ref_ped		VARCHAR(20)					--Referencia de la venta
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_cmr007
BEGIN TRY
--SET @ar_ide_ped = 'VRS-000-000007'
--SET @ar_ges_ped = 2020
	-- Obtiene datos del encabezado
	SELECT @va_fec_ped = va_fec_ped, @va_nro_ped = va_nro_ped,
		   @va_cod_per = va_cod_per, @va_raz_soc = va_raz_soc,
		   @va_sub_toB = va_sub_toB, @va_sub_toU = va_sub_toU,
		   @va_dto_vtB = va_dto_vtB, @va_dto_vtU = va_dto_vtU,
		   @va_tot_vtB = va_tot_vtB, @va_tot_vtU = va_tot_vtU,
		   @va_cod_bod = va_cod_bod, @va_tip_cam = va_tip_cam,
		   @va_ped_par = va_ped_par,
		   @va_mon_ped = va_mon_ped, @va_for_pag = va_for_pag,
		   @va_usr_reg = va_usr_reg, @va_fec_reg = va_fec_reg,
		   @va_obs_ped = va_obs_ped, @va_est_ado = va_est_ado,
		   @va_doc_ped = va_doc_ped, @va_nro_tal = va_nro_tal,
		   @va_ref_ped = va_ref_ped, @va_cod_del = va_cod_del,
		   @va_cod_ven = va_cod_ven, @va_cod_plv = va_cod_plv
	FROM cmr007
	WHERE va_ide_ped = @ar_ide_ped	AND
		  va_ges_ped = @ar_ges_ped
	
	
	
	-- Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	FROM inv002
	WHERE va_cod_bod = @va_cod_bod
	
	
	-- Obtiene nombre del Delivery
	SELECT @va_nom_del = va_nom_del
	FROM cmr015
	WHERE va_cod_del = @va_cod_del
	
	-- Obtiene nombre del Vendedor
	SELECT @va_nom_ven = va_nom_ven
	FROM cmr014
	WHERE va_cod_ven = @va_cod_ven
	
	--Obtiene Totales segun moneda de la venta
	IF (@va_mon_ped = 'B')
	BEGIN
		SET @va_tot_bru = @va_sub_toB
		SET @va_des_cue = @va_dto_vtB
		SET @va_tot_net = @va_tot_vtB
	END
	IF (@va_mon_ped = 'U')
	BEGIN
		SET @va_tot_bru = @va_sub_toU
		SET @va_des_cue = @va_dto_vtU
		SET @va_tot_net = @va_tot_vtU
	END
	
	--// obtiene datos de Talonario
	SELECT @va_for_log = va_for_log,
		   @va_fir_ma1 = va_fir_ma1,
		   @va_fir_ma2 = va_fir_ma2,
		   @va_fir_ma3 = va_fir_ma3,
		   @va_fir_ma4 = va_fir_ma4
	 FROM ads004
	WHERE va_ide_doc = @va_doc_ped AND 
		  va_nro_tal = @va_nro_tal
	 IF @@ROWCOUNT = 0
	 BEGIN
		SET @va_for_log = 0
		SET @va_fir_ma1 = ''
		SET @va_fir_ma2 = ''
		SET @va_fir_ma3 = ''
		SET @va_fir_ma4 = ''
	 END
	 
	 IF @va_for_log = 1
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 12
	 END
	 IF @va_for_log = 2
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 13
	 END	
	 IF @va_for_log = 3
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 14
	 END	
	 IF @va_for_log = 4
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 15
	 END	
	 
	--// Cursor sobre Detalle
	DECLARE vc_cmr007 CURSOR LOCAL FOR
	SELECT va_itm_ped, va_cod_pro, va_des_pro, va_can_uni, va_und_inv,
		   (va_mto_brB - va_val_dtB), (va_mto_brU - va_val_dtU), va_mto_neB, va_mto_neU 
	 FROM cmr008 --WHERE va_ide_ped = 'VRS-000-000008'	
	WHERE va_ide_ped = @ar_ide_ped	AND
		  va_ges_ped = @ar_ges_ped
		  
		  
		
	--** Abre cursor		  
	OPEN vc_cmr007    
		 
	FETCH NEXT FROM vc_cmr007 INTO @va_itm_ped, @va_cod_pro, @va_des_pro, @va_can_tid, @va_und_inv,
								   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@va_mon_ped = 'B')
		BEGIN
			SET @va_pre_uni = @va_pre_uBs
			SET @va_pre_tot = @va_pre_tBs
		END
		IF (@va_mon_ped = 'U')
		BEGIN
			SET @va_pre_uni = @va_pre_uUs
			SET @va_pre_tot = @va_pre_tUs
		END
		
		
		--//** Obtiene nombre del producto de la tabla producto
		SELECT @va_des_pro = va_nom_pro
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro
		 
	----//** Obtiene nombre del delivery
	--	SELECT @va_nom_del = va_nom_del
	--	  FROM cmr010
	--	 WHERE va_cod_del = @va_cod_del
	
		INSERT INTO #tm_cmr007 VALUES ( @va_fec_ped		,
										@ar_ide_ped		,
										@ar_ges_ped		,
										@va_nro_ped		,
										@va_cod_bod		,
										@va_nom_bod		,
										@va_for_pag		,
										@va_tip_cam		,
										@va_cod_per		,
										@va_raz_soc		,
										@va_mon_ped		,
										@va_tot_bru		,
										@va_des_cue		,
										@va_tot_net		,
										@va_obs_ped		,
										@va_ped_par		,
										@va_est_ado		,
										@va_usr_reg		,
										@va_fec_reg		,
										@va_itm_ped		,
										@va_cod_pro		,
										@va_des_pro		,
										@va_can_tid		,
										@va_und_inv		,
										@va_pre_uni		,
										@va_pre_tot		,
										@va_fir_ma1		,
										@va_fir_ma2		,
										@va_fir_ma3		,
										@va_fir_ma4		,
										@va_for_log		,
										
										@va_cod_del		,
										@va_nom_del		,
										@va_cod_ven		,
										@va_nom_ven		,
										@va_cod_plv		,
										@va_log_emp		,
										@va_ref_ped		)
												
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de items en tabla temporal',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_cmr007 INTO @va_itm_ped, @va_cod_pro, @va_des_pro, @va_can_tid,@va_und_inv,
									   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	END	
CLOSE vc_cmr007
DEALLOCATE vc_cmr007

SELECT * FROM #tm_cmr007

COMMIT TRAN TR_cmr007
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_cmr007
	RETURN
END CATCH	   

GO  
/*????????????????????????????????????????????????
ARCHIVO: inv002_05a_p01.sql
PROCEDIMIENTO: CONSULTA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--????????????????????????????????????????????????*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_05a_p01
GO

CREATE PROCEDURE inv002_05a_p01	@ar_ide_bod		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Pregunta si tiene talonarios Habilitados ligados al documento que se quiere Deshabilitar
	 SELECT inv001.va_ide_gru, inv001.va_nom_gru, inv002.va_ide_bod, ads003.va_nom_doc,
			inv002.va_nro_tal, inv002.va_nom_tal, inv002.va_tip_tal, inv002.va_nro_aut,
			inv002.va_for_mat, inv002.va_nro_cop, inv002.va_fir_ma1, inv002.va_fir_ma2,
			inv002.va_fir_ma3, inv002.va_fir_ma4, inv002.va_for_log, inv002.va_est_ado
	  FROM inv002, ads003, inv001
	 WHERE (inv001.va_ide_gru = ADS003.va_ide_gru)
	   AND (ADS003.va_ide_bod = inv002.va_ide_bod)
	   AND (inv002.va_ide_bod = @ar_ide_bod)
	   AND (inv002.va_nro_tal = @ar_nro_tal)

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv001_04a_p1.sql
PROCEDIMIENTO: DESHABILITA GRUPO DE BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-07-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv001_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv001_04a_p01
GO

CREATE PROCEDURE inv001_04a_p01	@ar_ide_gru		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene talonarios Habilitados ligados al Grupo de Bodega que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	  FROM inv002 
	 WHERE (va_ide_gru = @ar_ide_gru)
		AND (va_est_ado = 'H')

	--/ Procede a anular el Grupo de Bodega
	IF(@va_can_tid = 0)
	BEGIN
		UPDATE inv001 SET va_est_ado = 'N'
		WHERE va_ide_gru = @ar_ide_gru
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Deshabilitar, Existen Bodegas Habilitadas relacionados con el Grupo de Bodega' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv001_05a_p01.sql
PROCEDIMIENTO: CONSULTA GRUPO DE BODEGAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv001_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv001_05a_p01
GO

CREATE PROCEDURE inv001_05a_p01	@ar_ide_gru		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT inv001.va_ide_gru,
            inv001.va_nom_gru, inv001.va_des_gru, inv001.va_est_ado
	  FROM	inv001 
	 WHERE (inv001.va_ide_gru = @ar_ide_gru)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv001_06a_p01.sql
PROCEDIMIENTO: ELIMINA GRUPO DE BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-07-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv001_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv001_06a_p01
GO

CREATE PROCEDURE inv001_06a_p01	@ar_ide_gru		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene Bodegas ligados al Grupo de Bodega que se quiere Deshabilitar
	 --SELECT @va_can_tid = COUNT(*)
	 -- FROM inv002 
	 --WHERE (va_ide_gru = @ar_ide_gru)

	--/ Procede a anular el Grupo de Bodega
	IF(@va_can_tid = 0)
	BEGIN
		DELETE inv001
		WHERE va_ide_gru = @ar_ide_gru
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede eliminar, Existen Bodegas relacionadas con el Grupo de Bodega' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv001_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE GRUPO DE BODEGAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-07-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv001_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv001_R01
GO

CREATE PROCEDURE inv001_R01	@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	IF(@ar_est_ado = 'T')
		SET @va_est_ado = '%'
	IF(@ar_est_ado <> 'T')
		SET @va_est_ado = @ar_est_ado
			
		 
	 SELECT inv001.va_ide_gru,
            inv001.va_nom_gru, inv001.va_des_gru, inv001.va_est_ado
	  FROM	inv001 , ads001
	 WHERE (inv001.va_est_ado LIKE @va_est_ado)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv002_04a_p01.sql
PROCEDIMIENTO: HABILITA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_04a_p01
GO

CREATE PROCEDURE inv002_04a_p01	@ar_ide_gru		INT	,
								@ar_cod_bod		INT
									
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@va_est_gru			CHAR(01)	    --** Estado del Grupo



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del Grupo
	 SELECT @va_est_gru = va_est_ado
	  FROM inv001 
	 WHERE (va_ide_gru = @ar_ide_gru)
		

	--/ Si el Grupo esta Deshabilitado, no se puede habilitar la bodega
	IF(@va_est_gru = 'N')
	BEGIN
		RAISERROR ('No puede Habilitar la bodega si el Grupo esta Deshabilitado' ,16,1)
		RETURN
	END
	
	IF(@va_est_gru = 'H')
	BEGIN
		UPDATE inv002 SET va_est_ado = 'H'
		WHERE va_cod_bod = @ar_cod_bod AND va_ide_gru = @ar_ide_gru
		-- Registrar bitacora
		--INSERT INTO
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv002_04a_p02.sql
PROCEDIMIENTO: DESHABILITA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_04a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_04a_p02
GO

CREATE PROCEDURE inv002_04a_p02	@ar_ide_gru		INT	,
								@ar_cod_bod		INT
										
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	
	UPDATE inv002 SET va_est_ado = 'N'
	WHERE va_cod_bod = @ar_cod_bod AND va_ide_gru = @ar_ide_gru

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv002_05a_p01.sql
PROCEDIMIENTO: CONSULTA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_05a_p01
GO

CREATE PROCEDURE inv002_05a_p01	@ar_cod_bod		INT	
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Pregunta si tiene talonarios Habilitados ligados al documento que se quiere Deshabilitar
	 SELECT inv001.va_ide_gru, inv001.va_nom_gru, inv002.va_cod_bod, inv002.va_nom_bod,
			inv002.va_des_bod, inv002.va_dir_bod, inv002.va_fec_ctr, inv002.va_mon_inv,
			inv002.va_mtd_cto, inv002.va_nom_ecg, inv002.va_tlf_ecg, inv002.va_dir_ecg,inv002.va_est_ado
	  FROM inv002, inv001
	 WHERE (inv001.va_ide_gru = inv002.va_ide_gru)
		   AND (inv002.va_cod_bod = @ar_cod_bod)

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv002_06a_p01.sql
PROCEDIMIENTO: ELIMINAR BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	01-08-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_06a_p01
GO

CREATE PROCEDURE inv002_06a_p01	@ar_ide_gru		INT,
								@ar_cod_bod		INT
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@count				INT,
@va_est_ado			CHAR(01)	    --** Estado del Grupo



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT @va_est_ado = va_est_ado
	  FROM inv002 
	 WHERE (va_cod_bod = @ar_cod_bod)
	  
		IF (@va_est_ado = 'V')
		BEGIN
			RAISERROR ('No puede Elminiar la bodega, se encuentra habilitada' ,16,1)
			RETURN
		END
		IF (@va_est_ado = 'N')
		BEGIN
		
			-- Verifica que no haya movimientos en el kardex correspondiente al almacen a eliminar
			SET @count = 0
			SELECT @count = COUNT(*)
			  FROM inv100
			 WHERE va_cod_bod = @ar_cod_bod
			IF(@count = 0)
			BEGIN
				-- Elimina almacen
				DELETE inv002
				WHERE va_ide_gru = @ar_ide_gru AND va_cod_bod = @ar_cod_bod
				
				-- Registrar bitacora por operacion
				--INSERT INTO
			END
			ELSE
			BEGIN
				RAISERROR ('No puede Elminiar la bodega por que ya cuenta con movimientos' ,16,1)
				RETURN
			END
			
			
		END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv002_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE BODEGAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	25-05-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_R01
GO

CREATE PROCEDURE inv002_R01	@ar_ide_gr1	INT,
							@ar_ide_gr2	INT,
							@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),

@va_ide_gru		INT,				-- Ide Documento
@va_nom_gru		CHAR(30),			-- Nombre de grupo
@va_cod_bod		CHAR(06),			-- Codigo Bodega
@va_nom_bod		VARCHAR(40),		-- Nombre Talonario
@va_des_bod		VARCHAR(160),		-- Nombre Talonario
@va_dir_bod		VARCHAR(200),		-- Nombre Talonario
@va_fec_ctr		DATETIME		,	-- Fecha de Control
@va_mon_inv		CHAR(01)	,	-- Numero de autorizacion

@va_mtd_cto		CHAR(01),/* Metodo de costeo 
												P=Promedio Ponderado (Solo usaremos este inicialmente) 
												C=UEPS (Ultimos en Entrar, Primeros en Salir)
												A=PEPS (Primeros en Entrar Primeros en Salir)*/
	 
@va_nom_ecg		VARCHAR(120)	,--Nombre del encargado del almacen
@va_tlf_ecg		VARCHAR(10),				--Telefono del encargado
@va_dir_ecg		VARCHAR(200),				--Direccion del encargado
@va_est_ado		CHAR(01)		--Estado del almacen
			

CREATE TABLE #inv002
(
va_ide_gru		INT,				-- Ide Documento
va_nom_gru		CHAR(30),			-- Nombre de grupo
va_cod_bod		CHAR(06),			-- Codigo Bodega
va_nom_bod		VARCHAR(40),		-- Nombre Talonario
va_des_bod		VARCHAR(160),		-- Nombre Talonario
va_dir_bod		VARCHAR(200),		-- Nombre Talonario
va_fec_ctr		DATETIME		,	-- Fecha de Control
va_mon_inv		CHAR(01)	,	-- Numero de autorizacion

va_mtd_cto		CHAR(01)		NOT NULL,	/* Metodo de costeo 
												P=Promedio Ponderado (Solo usaremos este inicialmente) 
												C=UEPS (Ultimos en Entrar, Primeros en Salir)
												A=PEPS (Primeros en Entrar Primeros en Salir)*/

	 
va_nom_ecg		VARCHAR(120)	NOT NULL,	--Nombre del encargado del almacen
va_tlf_ecg		VARCHAR(10),				--Telefono del encargado
va_dir_ecg		VARCHAR(200),				--Direccion del encargado
va_est_ado		CHAR(01)		NOT NULL	--Estado del almacen
				
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 


--/ Inicializa variable contador de registro
IF(@ar_est_ado = 'T')
	SET @va_est_ado = '%'
IF(@ar_est_ado <> 'T')
	SET @va_est_ado = @ar_est_ado
	
	
DECLARE vc_bod_ega CURSOR LOCAL FOR
SELECT inv002.va_ide_gru, inv002.va_cod_bod, inv002.va_nom_bod, inv002.va_des_bod, inv002.va_dir_bod,
	   inv002.va_fec_ctr,inv002.va_mon_inv, inv002.va_mtd_cto, inv002.va_nom_ecg , inv002.va_tlf_ecg, inv002.va_dir_ecg,
	   inv002.va_est_ado
FROM inv002, inv001
WHERE (inv002. va_ide_gru = inv001.va_ide_gru)
  AND (inv001.va_ide_gru BETWEEN @ar_ide_gr1 and @ar_ide_gr2)
  AND (inv002.va_est_ado like @va_est_ado )
	
--** Abre cursor		  
OPEN vc_bod_ega    
	 
FETCH NEXT FROM vc_bod_ega INTO @va_ide_gru, @va_cod_bod, @va_nom_bod, @va_des_bod, @va_dir_bod,
	   @va_fec_ctr,@va_mon_inv, @va_mtd_cto, @va_nom_ecg , @va_tlf_ecg, @va_dir_ecg,@va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del nom_gru 1
	SELECT @va_nom_gru = va_nom_gru
	  FROM inv001
	 WHERE va_ide_gru = @va_ide_gru
	 
	 INSERT INTO #inv002 VALUES (@va_ide_gru,@va_nom_gru, @va_cod_bod, @va_nom_bod, @va_des_bod, @va_dir_bod,
						   @va_fec_ctr,@va_mon_inv, @va_mtd_cto, @va_nom_ecg , @va_tlf_ecg, @va_dir_ecg,
						   @va_est_ado)
	


		FETCH NEXT FROM vc_bod_ega INTO @va_ide_gru, @va_cod_bod, @va_nom_bod, @va_des_bod, @va_dir_bod,
		   @va_fec_ctr,@va_mon_inv, @va_mtd_cto, @va_nom_ecg , @va_tlf_ecg, @va_dir_ecg,
	   @va_est_ado
END	

CLOSE vc_bod_ega
DEALLOCATE vc_bod_ega

SELECT *
FROM #inv002

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv003_04a_p01.sql
PROCEDIMIENTO: DESHABILITA FAMILIA
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-07-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv003_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv003_04a_p01
GO

CREATE PROCEDURE inv003_04a_p01	@ar_cod_fam		CHAR(06)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT,	--** Cantidad de registros encontrados
@va_niv_fam			INT,
@va_cod_fam			CHAR(06)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 -- Inicializa variables
	 SET @va_can_tid = -1;
	 SET @va_niv_fam = 0;
	 SET @va_cod_fam = @ar_cod_fam
	 
	 -- obtiene nivel de la familia
	IF(SUBSTRING(@ar_cod_fam,1,2)<> '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@ar_cod_fam,1,2)
		SET @va_niv_fam = 1
	END
	IF(SUBSTRING(@ar_cod_fam,3,2)<> '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@ar_cod_fam,1,4)
		SET @va_niv_fam = 2
	END
	IF(SUBSTRING(@ar_cod_fam,5,2)<> '00')
	BEGIN
		SET @va_niv_fam = 3
	END
		
	 IF(@va_niv_fam <> 3) -- Si la familia no es del 3er nivel, entonces pregunta por sus familias dependientes
	 BEGIN
		
		 SELECT @va_can_tid = COUNT(*)
		  FROM inv003 
		 WHERE (va_cod_fam <> @ar_cod_fam)
			AND (va_cod_fam LIKE RTRIM(@va_cod_fam) + '%')
			AND (va_est_ado = 'H')
			 
			
	END
	ELSE
		SET @va_can_tid = 0
	
	
	IF(@va_can_tid = -1)
	BEGIN
		RAISERROR ('La familia de producto no se encuentra registrada' ,16,1)
		RETURN
	END
	 
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('La familia No puede ser Deshabilitada, Existen otras familias relacionados a ella que estan Habilitadas, revise por favor ' ,16,1)
		RETURN
	END
	
	IF(@va_can_tid = 0 AND @va_niv_fam <> 3)--Si no hay otras familas dependientes y el nivel es distinto de 3, 
											--procede a deshabilitar
	BEGIN
		UPDATE inv003 SET va_est_ado = 'N'
		WHERE va_cod_fam = @ar_cod_fam
	END
	
	IF(@va_can_tid = 0 AND @va_niv_fam = 3) -- Si no hay otras familias dependientes y el nivel es igual a 3, pregunta
											-- si tiene productos dependientes que esten habilitados  
	BEGIN
		-- Verifica que no tenga productos relacionados que esten habilitados
		SELECT @va_can_tid = COUNT(*)
		  FROM inv004 
		 WHERE (va_cod_fam = @ar_cod_fam)
			AND (va_est_ado = 'H')
		
		IF(@va_can_tid > 0)-- Si hay registros, no podra deshabilitar
		BEGIN
			RAISERROR ('La familia no puede ser Deshabilitada, Existen Productos relacionados que estan Habilitados, revise por favor. ' ,16,1)
			RETURN
		END
		IF(@va_can_tid = 0) -- Si no hay registros, deshabilita familia
		BEGIN
			UPDATE inv003 SET va_est_ado = 'N'
			WHERE va_cod_fam = @ar_cod_fam
		END
		
	END
	 
	
	
	
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv003_05a_p01.sql
PROCEDIMIENTO: CONSULTA FAMILIA PRODUCTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	08-08-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv003_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv003_05a_p01
GO

CREATE PROCEDURE inv003_05a_p01	@ar_cod_fam		CHAR(06)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT va_cod_fam,va_nom_fam, va_tip_fam, va_est_ado
	  FROM	inv003 
	 WHERE (va_cod_fam = @ar_cod_fam)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv003_06a_p01.sql
PROCEDIMIENTO: ELIMINA FAMILIA
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-08-2021
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv003_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv003_06a_p01
GO

CREATE PROCEDURE inv003_06a_p01	@ar_cod_fam		CHAR(06)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT,	--** Cantidad de registros encontrados
@va_niv_fam			INT,
@va_cod_fam			CHAR(06)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 -- Inicializa variables
	 SET @va_can_tid = -1;
	 SET @va_niv_fam = 0;
	 SET @va_cod_fam = @ar_cod_fam
	 
	 -- obtiene nivel de la familia
	IF(SUBSTRING(@ar_cod_fam,1,2)<> '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@ar_cod_fam,1,2)
		SET @va_niv_fam = 1
	END
	IF(SUBSTRING(@ar_cod_fam,3,2)<> '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@ar_cod_fam,1,4)
		SET @va_niv_fam = 2
	END
	IF(SUBSTRING(@ar_cod_fam,5,2)<> '00')
	BEGIN
		SET @va_niv_fam = 3
	END
		
	IF(@va_niv_fam <> 3) -- Si la familia no es del 3er nivel, entonces pregunta por sus familias dependientes
	BEGIN
		
		 SELECT @va_can_tid = COUNT(*)
		  FROM inv003 
		 WHERE (va_cod_fam <> @ar_cod_fam)
			AND (va_cod_fam LIKE RTRIM(@va_cod_fam) + '%')
	END
	ELSE
		SET @va_can_tid = 0
	
	IF(@va_can_tid = -1)
	BEGIN
		RAISERROR ('La familia de producto no se encuentra registrada' ,16,1)
		RETURN
	END
	 
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('La familia No puede ser ELIMINADA, Existen otras familias relacionados a ella, revise por favor ' ,16,1)
		RETURN
	END
	
	IF(@va_can_tid = 0 AND @va_niv_fam <> 3)--Si no hay otras familas dependientes y el nivel es distinto de 3, 
											--procede a ELIMINAr
	BEGIN
		DELETE inv003
		WHERE va_cod_fam = @ar_cod_fam
	END
	
	IF(@va_can_tid = 0 AND @va_niv_fam = 3) -- Si no hay otras familias dependientes y el nivel es igual a 3, pregunta
											-- si tiene productos dependientes  
	BEGIN
		-- Verifica que no tenga productos relacionados 
		SELECT @va_can_tid = COUNT(*)
		  FROM inv004 
		 WHERE (va_cod_fam = @ar_cod_fam)
		
		IF(@va_can_tid > 0)-- Si hay registros, no podra ELIMINAr
		BEGIN
			RAISERROR ('La familia no puede ser ELIMINADA, Existen Productos relacionados, revise por favor. ' ,16,1)
			RETURN
		END
		IF(@va_can_tid = 0) -- Si no hay registros, ELIMINA familia
		BEGIN
			DELETE inv003
			WHERE va_cod_fam = @ar_cod_fam
		END
		
	END
	 
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv004_01a_p01.sql
PROCEDIMIENTO: BUSCA PRODUCTO ABM
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_01a_p01
GO

CREATE PROCEDURE inv004_01a_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01),		-- Estado (H = Habilitado, N=Deshabilitado)
									@ar_cod_fam		VARCHAR(06)		-- Codigo familia
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_pro		VARCHAR(15),
@va_nom_pro		NVARCHAR(80),
@va_des_pro		NVARCHAR(200),
@va_cod_umd		CHAR(03),
@va_und_cmp		CHAR(03),
@va_und_vta		CHAR(03),
@va_cod_mar		INT,
@va_nom_mar		VARCHAR(20),
@va_eqv_cmp		DECIMAL(6,2),
@va_eqv_vta		DECIMAL(6,2),
@va_cod_fam		VARCHAR(06),
@va_nom_fam		VARCHAR(60),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_pro		VARCHAR(15),
va_nom_pro		NVARCHAR(80),
va_des_pro		NVARCHAR(200),
va_cod_umd		CHAR(03),
va_und_cmp		CHAR(03),
va_und_vta		CHAR(03),
va_cod_mar		INT,
va_nom_mar		VARCHAR(20),
va_eqv_cmp		DECIMAL(6,2),
va_eqv_vta		DECIMAL(6,2),
va_cod_fam		VARCHAR(06),
va_nom_fam		VARCHAR(60),
va_est_ado		CHAR(01)

)



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 


IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'


IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_cod_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_nom_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_des_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END

IF (@ar_cri_bus = 3) -- Busca por Cod. Barra
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_cod_bar LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
  
OPEN vc_pro_duc
FETCH NEXT FROM vc_pro_duc INTO @va_cod_pro, @va_nom_pro, @va_des_pro, @va_cod_umd, @va_und_cmp,@va_und_vta,@va_cod_mar,@va_eqv_cmp,@va_eqv_vta,@va_cod_fam, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del Marca
	SELECT @va_nom_mar = va_nom_mar
	  FROM inv006
	 WHERE va_cod_mar = @va_cod_mar
	 
	-- Obtiene nombre de la familia
	SELECT @va_nom_fam = va_nom_fam
	  FROM inv003
	 WHERE va_cod_fam LIKE @va_cod_fam + '%'
	 
	
	 INSERT INTO #resultado VALUES (@va_cod_pro		,
									@va_nom_pro		,
									@va_des_pro		,
									@va_cod_umd		,
									@va_und_cmp		,
									@va_und_vta		,
									@va_cod_mar		,
									@va_nom_mar		,
									@va_eqv_cmp		,
									@va_eqv_vta		,
									@va_cod_fam		,
									@va_nom_fam		,
									@va_est_ado	
									)
	FETCH NEXT FROM vc_pro_duc INTO @va_cod_pro, @va_nom_pro, @va_des_pro, @va_cod_umd, @va_und_cmp,@va_und_vta,@va_cod_mar,@va_eqv_cmp,@va_eqv_vta,@va_cod_fam, @va_est_ado
END	

CLOSE vc_pro_duc
DEALLOCATE vc_pro_duc

IF(@ar_cod_fam = '000000')	
BEGIN
	SELECT * 
	FROM #resultado
END

IF (@ar_cod_fam <> '000000')	
BEGIN
	SET @va_cod_fam = @ar_cod_fam


	IF (RIGHT(@va_cod_fam,4) = '0000')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@va_cod_fam, 1, 2)
		SET @va_cod_fam = @va_cod_fam + '____'
		
		
	END	
	IF (RIGHT(@va_cod_fam,2) = '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@va_cod_fam, 1, 4)
		SET @va_cod_fam = @va_cod_fam + '__'
	END
	
	


	
	SELECT * 
	FROM #resultado
	WHERE va_cod_fam LIKE @va_cod_fam
			
END


RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: inv004_01b_p01.sql
PROCEDIMIENTO: BUSCA PRODUCTO CON EXISTENCIA Y PRECIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_01b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_01b_p01
GO

CREATE PROCEDURE inv004_01b_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01),		-- Estado (H = Habilitado, N=Deshabilitado)
									@ar_cod_lis		INT,
									@ar_cod_bod		INT,
									@ar_cod_fam		VARCHAR(06)		-- Codigo familia
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_pro		VARCHAR(15),
@va_nom_pro		NVARCHAR(80),
@va_des_pro		NVARCHAR(200),
@va_cod_umd		CHAR(03),
@va_und_vta		CHAR(03),
@va_pre_cio		DECIMAL(10,5),
@va_sal_can		DECIMAL(14,2),
@va_sal_vta		DECIMAL(14,2),
@va_cod_mar		INT,
@va_nom_mar		VARCHAR(20),
@va_eqv_vta		DECIMAL(6,2),
@va_cod_fam		VARCHAR(06),
@va_nom_fam		VARCHAR(60),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_pro		VARCHAR(15),
va_nom_pro		NVARCHAR(80),
va_des_pro		NVARCHAR(200),
va_cod_umd		CHAR(03),
va_und_vta		CHAR(03),
va_sal_can		DECIMAL(14,2),
va_sal_vta		DECIMAL(14,2),
va_pre_vta		DECIMAL(10,5),
va_cod_mar		INT,
va_nom_mar		VARCHAR(20),
va_eqv_vta		DECIMAL(6,2),
va_cod_fam		VARCHAR(06),
va_nom_fam		VARCHAR(60),
va_est_ado		CHAR(01)

)



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 


IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'


IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_vta,va_cod_mar,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_cod_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd,va_und_vta,va_cod_mar,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_nom_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_vta,va_cod_mar,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_des_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END

IF (@ar_cri_bus = 3) -- Busca por Cod. Barra
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd,va_und_vta,va_cod_mar,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_cod_bar LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
   
OPEN vc_pro_duc
FETCH NEXT FROM vc_pro_duc INTO @va_cod_pro, @va_nom_pro, @va_des_pro, @va_cod_umd, @va_und_vta,@va_cod_mar,@va_eqv_vta,@va_cod_fam, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del Marca
	SELECT @va_nom_mar = va_nom_mar
	  FROM inv006
	 WHERE va_cod_mar = @va_cod_mar
	 
	-- Obtiene nombre de la familia
	SELECT @va_nom_fam = va_nom_fam
	  FROM inv003
	 WHERE va_cod_fam LIKE @va_cod_fam + '%'
	 
	-- Obtiene precio
	SELECT @va_pre_cio = va_pre_cio
	  FROM cmr002
	 WHERE va_cod_pro = @va_cod_pro 
	  IF(@@ROWCOUNT = 0)
		SET @va_pre_cio = 0
		
	-- Obtiene existencia
	SELECT @va_sal_can = ISNULL(va_sal_can,0)
	  FROM inv099
	 WHERE va_cod_pro = @va_cod_pro 
	   AND va_cod_bod = @ar_cod_bod
	 IF(@@ROWCOUNT = 0)
		SET @va_sal_can = 0
	 
	 -- Calcula existencia en unidad de medida Venta
	 SET @va_sal_vta = (@va_sal_can * @va_eqv_vta) 
	 
	 INSERT INTO #resultado VALUES (@va_cod_pro		,
									@va_nom_pro		,
									@va_des_pro		,
									@va_cod_umd		,
									@va_und_vta		,
									@va_sal_can		,
									@va_sal_vta		,
									@va_pre_cio		,
									@va_cod_mar		,
									@va_nom_mar		,
									@va_eqv_vta		,
									@va_cod_fam		,
									@va_nom_fam		,
									@va_est_ado	
									)
									
	FETCH NEXT FROM vc_pro_duc INTO @va_cod_pro, @va_nom_pro, @va_des_pro, @va_cod_umd, @va_und_vta,@va_cod_mar,@va_eqv_vta,@va_cod_fam, @va_est_ado
END	

CLOSE vc_pro_duc
DEALLOCATE vc_pro_duc

IF(@ar_cod_fam = '000000')	
BEGIN
	SELECT * 
	FROM #resultado
END

IF (@ar_cod_fam <> '000000')	
BEGIN
	SET @va_cod_fam = @ar_cod_fam


	IF (RIGHT(@va_cod_fam,4) = '0000')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@va_cod_fam, 1, 2)
		SET @va_cod_fam = @va_cod_fam + '____'
		
		
	END	
	IF (RIGHT(@va_cod_fam,2) = '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@va_cod_fam, 1, 4)
		SET @va_cod_fam = @va_cod_fam + '__'
	END
	
	


	
	SELECT * 
	FROM #resultado
	WHERE va_cod_fam LIKE @va_cod_fam
			
END


RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: inv004_02a_p03.sql
PROCEDIMIENTO: CODIFICACION AUTOMATICA DE PRODUCTO CON 3 DIGITOS
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_02a_p03') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_02a_p03
GO

CREATE PROCEDURE inv004_02a_p03		@ar_cod_fam		VARCHAR(15)	-- Codigo familia
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_pro		VARCHAR(15),
@va_cod_fam		VARCHAR(06),
@va_ult_cod		VARCHAR(15),
@va_cod_aux		VARCHAR(15),
@va_cod_num		INT,

@va_est_ado		CHAR(01)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	SET @va_cod_pro = ''
	
	SELECT @va_cod_pro = ISNULL(MAX(va_cod_pro),'')
	FROM inv004
	WHERE va_cod_fam = @ar_cod_fam AND
		  va_cod_pro LIKE @ar_cod_fam + '%'
	
	--IF(@va_cod_pro IS NULL)		
	--	SET @va_cod_pro = ''
		
	IF @va_cod_pro = ''	-- Si no hay 
	BEGIN
		SET @va_ult_cod = @ar_cod_fam + '.001'
	END
	ELSE
	BEGIN
		print @va_cod_pro
		
		SET @va_cod_num = CAST (SUBSTRING(@va_cod_pro,8,3) AS INT )
		SET @va_cod_num = @va_cod_num  + 1
		SET @va_cod_num = 1000 + @va_cod_num
		SET @va_cod_aux = CAST(@va_cod_num AS VARCHAR(15))
		
		SET @va_cod_aux = SUBSTRING(@va_cod_aux,2,3) 
		
		SET @va_ult_cod = @ar_cod_fam + '.' + @va_cod_aux
	END
	
	SELECT @va_ult_cod AS va_cod_pro
  		
	RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: inv004_05a_p01.sql
PROCEDIMIENTO: BUSCA PRODUCTO ABM
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_05a_p01
GO

CREATE PROCEDURE inv004_05a_p01		@ar_cod_pro		VARCHAR(15)	-- Codigo Producto
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_pro		VARCHAR(15),
@va_nom_pro		NVARCHAR(80),
@va_des_pro		NVARCHAR(200),
@va_cod_umd		CHAR(03),
@va_und_cmp		CHAR(03),
@va_und_vta		CHAR(03),
@va_cod_mar		INT,
@va_nom_mar		VARCHAR(20),
@va_eqv_cmp		DECIMAL(6,2),
@va_eqv_vta		DECIMAL(6,2),
@va_nro_dec		INT,
@va_ban_ser		INT,
@va_ban_lot		INT,
@va_cod_fam		VARCHAR(06),
@va_nom_fam		VARCHAR(60),
@va_cod_bar		VARCHAR(15),
@va_fab_ric		VARCHAR(50),


@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_pro		VARCHAR(15),
va_nom_pro		NVARCHAR(80),
va_des_pro		NVARCHAR(200),
va_cod_umd		CHAR(03),
va_und_cmp		CHAR(03),
va_und_vta		CHAR(03),
va_cod_mar		INT,
va_nom_mar		VARCHAR(20),
va_cod_bar		VARCHAR(15),
va_fab_ric		VARCHAR(50),
va_eqv_cmp		DECIMAL(6,2),
va_eqv_vta		DECIMAL(6,2),
va_nro_dec		INT,
va_ban_ser		INT,
va_ban_lot		INT,
va_cod_fam		VARCHAR(06),
va_nom_fam		VARCHAR(60),
va_est_ado		CHAR(01)

)



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

	SELECT @va_cod_pro = va_cod_pro, 
		   @va_nom_pro = va_nom_pro,
		   @va_des_pro = va_des_pro, 
		   @va_cod_umd = va_cod_umd, 
		   @va_und_cmp = va_und_cmp,
		   @va_und_vta = va_und_vta,
		   @va_cod_mar = va_cod_mar,
		   @va_cod_bar = va_cod_bar,
		   @va_fab_ric = va_fab_ric,
		   @va_eqv_cmp = va_eqv_cmp,
		   @va_eqv_vta = va_eqv_vta,
		   @va_nro_dec = va_nro_dec,
		   @va_ban_ser = va_ban_ser,
		   @va_ban_lot = va_ban_ser,
		   @va_cod_fam = va_cod_fam,
		   @va_est_ado = va_est_ado
	FROM inv004
	WHERE va_cod_pro = @ar_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SELECT * FROM #resultado
		RETURN
		--DELETE #resultado
	END

	-- Obtiene nombre del Marca
	SELECT @va_nom_mar = va_nom_mar
	  FROM inv006
	 WHERE va_cod_mar = @va_cod_mar
	 
	-- Obtiene nombre de la familia
	SELECT @va_nom_fam = va_nom_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam 
	 

	 INSERT INTO #resultado VALUES (@va_cod_pro		,
									@va_nom_pro		,
									@va_des_pro		,
									@va_cod_umd		,
									@va_und_cmp		,
									@va_und_vta		,
									@va_cod_mar		,
									@va_nom_mar		,
									@va_cod_bar		,
									@va_fab_ric		,								
									@va_eqv_cmp		,
									@va_eqv_vta		,
									@va_nro_dec		,
									@va_ban_ser		,
									@va_ban_lot		,
									@va_cod_fam		,
									@va_nom_fam		,
									@va_est_ado	
									)

	SELECT * FROM #resultado    		
	RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


  
/*
ARCHIVO: inv004_06a_p01.sql
PROCEDIMIENTO: ELIMINAR PRODUCTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	01-08-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_06a_p01
GO

CREATE PROCEDURE inv004_06a_p01	@ar_cod_pro		NVARCHAR(15)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@count				INT,
@va_est_ado			CHAR(01)	    --** Estado del Grupo



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	-- Inicializa contador de registros en 0  
	SET @count = 0
	  
	SELECT @count = COUNT(*)
	  FROM inv004 
	 WHERE (va_cod_pro = @ar_cod_pro)
	  
	
	IF (@count = 0)
	BEGIN
		RAISERROR ('El producto que desea elimina, no se encuentra registrado' ,16,1)
		RETURN
	END

	-- Verifica que no haya movimientos en el kardex correspondiente al producto a eliminar
	SET @count = 0
	SELECT @count = COUNT(*)
	  FROM inv100
	 WHERE va_cod_pro = @ar_cod_pro
	IF(@count = 0)
	BEGIN
		-- Elimina almacen
		DELETE inv004
		WHERE va_cod_pro = @ar_cod_pro
		
		-- Registrar bitacora por operacion
		--INSERT INTO
	END
	ELSE
	BEGIN
		RAISERROR ('No puede Elminiar el producto por que ya cuenta con movimientos' ,16,1)
		RETURN
	END

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv007_01a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO BUSCA COMPRA
AUTOR:	CREARSIS(chl)
FECHA:	20-09-20120
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_01a_p01
GO

CREATE PROCEDURE inv007_01a_p01 @ar_cod_prv INT,		-- codigo Proveedor
							@ar_cod_bod INT,			-- Almacen
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_obs_cmp NVARCHAR(200),  -- Observacion
							@ar_est_ado CHAR(01)		-- Estado (T=todos ; H=valido ; N=anulado)
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_prv_ini		INT,
@va_prv_fin		INT,
@va_bod_ini		INT,
@va_bod_fin		INT

--** CREA TABLA TEMPORAL
--CREATE TABLE #tm_inv007(
--	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
--	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
--	va_nro_itm		INT				not null,	--Numero de item 
--	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
--	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
--	va_und_cmp		char(3)			null,		--Codigo de la Unidad de Medida
--	va_can_cmp		DECIMAL(14,4),				--Cantidad de producto
--	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
--	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
--	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
--   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
 
IF (@ar_cod_bod = 0)
BEGIN	
	SET @va_bod_ini = 0
	SET @va_bod_fin = 99999
END
IF (@ar_cod_bod <> 0)
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
END
PRINT @ar_cod_bod

IF (@ar_cod_prv = 0)
BEGIN	

	SET @va_prv_ini = 0
	SET @va_prv_fin = 999999
END
IF (@ar_cod_prv <> 0)
BEGIN	

	SET @va_prv_ini = @ar_cod_prv
	SET @va_prv_fin = @ar_cod_prv
END
PRINT @ar_cod_prv

IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'



 SELECT va_fec_cmp, va_ide_cmp, va_nro_cmp, va_cod_per, va_raz_soc, 
		va_mon_cmp, va_tot_nBs, va_tot_nUs, va_est_ado, va_obs_cmp, va_ges_cmp
 FROM inv007
WHERE (va_cod_per BETWEEN @va_prv_ini AND @va_prv_fin) AND
	  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
	  (va_fec_cmp BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	   va_obs_cmp  LIKE @ar_obs_cmp + '%'	AND
	   va_est_ado LIKE @ar_est_ado  
	

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: inv007_02a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO REGISTRA COMPRA
	(compra, suma existencia, kardex, 
	registra movimiento efectivo/CxC )
AUTOR:	CREARSIS(chl)
FECHA:	12-10-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_02a_p01
GO

CREATE PROCEDURE inv007_02a_p01 @ar_cod_usr NVARCHAR(15),	-- Usuario registro
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal  
							@ar_ide_doc	 NVARCHAR(03),	-- Codigo del documento
							@ar_nro_tal INT,			-- Numero del talonario												
							@ar_ges_tio INT,			-- GESTION 0=TODAS
							@ar_cod_bod INT,			-- bodega
							@ar_pro_vee INT,			-- codigo Proveedor
							@ar_mon_cmp CHAR(01),		-- Moneda de compra (B=Bs ; U=Us )
							@ar_fec_cmp DATE,			-- Fecha de compra
							@ar_for_pag INT,			-- Forma de pago (0=Contado; 1=Credito)
							@ar_cod_caj INT,			-- Codigo de caja
							@ar_lin_cxp INT,			-- Linea Cta. x Pag (codigo de libro)
							@ar_tip_cmp INT,			-- Tipo de Compra [0=Sin Fac. ; 1=Con Fac.]
							@ar_ban_fac	INT,			-- Bandera Factura [0=NO  ; 1=SI hay  ; 2= Por Recuperar]
							@ar_lib_cpr	INT,			-- Libreta Credito Fiscal por Recuperar (en caso que va_ban_fac=2) (5 numeros)
							@ar_tip_cam	DECIMAL(7,5),	-- Tipo de cambio
							@ar_des_cue DECIMAL(10,2),	-- Descuento
							@ar_obs_cmp NVARCHAR(200),   -- Observacion
							@ar_ref_cmp NVARCHAR(20)	-- Referecia del documento
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_nro_doc		INT, 
@va_ide_cmp		VARCHAR(20),	--Identificador de la compra (XXX|000-00000/2018)
@va_nro_reg		INT,
@va_nro_tal		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 
@va_und_cmp		char(3),		-- UNIDAD DE MEDIDA DE COMPRA ****************************
@va_can_cmp		DECIMAL(14,4),	--Cantidad de producto
@va_can_uiv		DECIMAL(14,4),	--Cantidad inventario de producto
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario en la moneda del documento
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_tip_fam		CHAR(01),
@va_und_umd		CHAR(03),		-- UNIDAD DE MEDIDA DE INVENTARIO DEL PRODUCTO
@va_eqv_cmp		DECIMAL(7,3),
@va_nro_cmp		INT,
@va_raz_soc		NVARCHAR(60),
@va_tot_bBs		DECIMAL(16,2),
@va_tot_bUs		DECIMAL(16,2),
@va_des_cBs		DECIMAL(16,2),
@va_des_cUs		DECIMAL(16,2),
@va_tot_nBs		DECIMAL(16,2),
@va_tot_nUs		DECIMAL(16,2),
@va_pre_uBs		DECIMAL(16,2),
@va_pre_uUs		DECIMAL(16,2),
@va_pre_tBs		DECIMAL(16,2),
@va_pre_tUs		DECIMAL(16,2),

@va_cos_uoB		DECIMAL(16,2),		-- COSTO UNITARIO DE LA OPERACION Bs
@va_cos_uoU		DECIMAL(16,2),


@va_con_tad		INT,
@va_por_cen		DECIMAL(16,5),
@va_des_uni		DECIMAL(16,2),
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),

-- VARIABLES PARA CALCULO DE COSTOS
@va_sal_can		DECIMAL(14,2),
@va_cos_ubs		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Bs)
@va_cos_uus		DECIMAL(14,6),

@va_sal_acu		DECIMAL(14,2),	-- Saldo cantidad acumulada
@va_cos_taB		DECIMAL(14,6),	--Costo total acumulado (promedio ponderado en Bs)
@va_cos_taU		DECIMAL(14,6),	--Costo total acumulado (promedio ponderado en Us)

@va_cos_uaB		DECIMAL(14,6),	--Costo unitario actual (promedio ponderado en Bs)
@va_cos_uaU		DECIMAL(14,6),	--Costo unitario actual (promedio ponderado en Us)
@va_nro_cmp_tmp	INT


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_INV007(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_und_cmp		char(3)			null,		--Codigo de la Unidad de Medida
	va_can_cmp		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
   )
   
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_INV007
BEGIN TRY   
  
   -- Carga temporal de compra
   INSERT INTO #tm_INV007
	SELECT * FROM inv007tmp
	WHERE va_cod_tmp = @ar_cod_tmp
	
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('No hay ningun item para la compra',16,1)
		RETURN
	END

	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @ar_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado
	 FROM ads004
	WHERE va_ide_doc = @ar_ide_doc AND 
		  va_nro_tal = @ar_nro_tal
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	--// Verifica la Gestion
	SELECT @va_nro_reg = COUNT(*)
	FROM ads016
	WHERE va_ges_tio = @ar_ges_tio
	IF(@va_nro_reg = 0)
	BEGIN
		RAISERROR ('La gestion no se encuentra definida',16,1)
		RETURN
	END
	
--// Verifica Numeracion
	SELECT @va_nro_cmp = va_con_tad
	FROM ads005
	WHERE va_ide_doc = @ar_ide_doc AND 
		  va_nro_tal = @ar_nro_tal AND
		  va_ges_tio = @ar_ges_tio
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Talonario NO dispone de numeracion',16,1)
		RETURN
	END
	
	--// Verifica bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El bodega no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El bodega se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	--// Verifica Proveedor
	
	SELECT @va_est_ado = va_est_ado,
		   @va_raz_soc = va_raz_soc
	FROM cmr013
	WHERE va_cod_per = @ar_pro_vee
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Proveedor no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Proveedor se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Caja si es al contado
	--IF @ar_for_pag = 0
	--BEGIN
		--SELECT @va_est_ado = va_est_ado
		--FROM tes001
		--WHERE va_cod_cjb = @ar_cod_caj
		--IF @@ROWCOUNT = 0
		--BEGIN
		--	RAISERROR ('La Caja no se encuentra registrada',16,1)
		--	RETURN
		--END
		--IF @va_est_ado = 'N'
		--BEGIN
		--	RAISERROR ('La Caja se encuentra Deshabilitada',16,1)
		--	RETURN
		--END
	--END
	
	----// Verifica Linea de credito si es al credito
	--IF @ar_for_pag = 1
	--BEGIN
	--	SELECT @va_est_ado = va_est_ado
	--	FROM ecp007
	--	WHERE va_cod_per = @ar_pro_vee AND
	--		  va_cod_lib = @ar_lin_cxp
	--	IF @@ROWCOUNT = 0
	--	BEGIN
	--		RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
	--		RETURN
	--	END
	--	IF @va_est_ado = 'N'
	--	BEGIN
	--		RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
	--		RETURN
	--	END
	--END
	
	
	----// Verifica Credito Fis x Recuperar 
	--IF (@ar_tip_cmp = 1 and @ar_ban_fac = 2)
	--BEGIN
	--	SELECT @va_est_ado = va_est_ado
	--	FROM ecp007
	--	WHERE va_cod_per = @ar_pro_vee AND
	--		  va_cod_lib = @ar_lib_cpr
	--	IF @@ROWCOUNT = 0
	--	BEGIN
	--		RAISERROR ('La persona no tiene la libreta de Cred. Fis. x Recuperar espesificada',16,1)
	--		RETURN
	--	END
	--	IF @va_est_ado = 'N'
	--	BEGIN
	--		RAISERROR ('La persona no tiene habilitada la libreta de Cred. Fis. x Recuperar espesificada',16,1)
	--		RETURN
	--	END
	--END
	
	--Suma en uno el contador de compra
	SET @va_nro_cmp = @va_nro_cmp + 1
	
	
	SET @va_nro_tal = 1000 + @ar_nro_tal
	SET @va_nro_cmp_tmp = 1000000 + @va_nro_cmp
	
	--Prepara identificador de la compra
	SET @va_ide_cmp = @ar_ide_doc + '-' + SUBSTRING(CAST (@va_nro_tal AS VARCHAR(4)),2,3) + '-' + SUBSTRING(CAST(@va_nro_cmp_tmp AS VARCHAR(7)),2,7)
	
	
	
	
	
	
	IF @ar_mon_cmp ='B'
	BEGIN
		SELECT @va_tot_bBs = SUM(va_imp_tot) 
		FROM #tm_inv007
		
		SET @va_tot_bUs = @va_tot_bBs / @ar_tip_cam
		
		SET @va_des_cBs = @ar_des_cue
		SET @va_des_cUs = @ar_des_cue / @ar_tip_cam
		
		SET @va_tot_nBs = @va_tot_bBs - @va_des_cBs
		SET @va_tot_nUs = @va_tot_nBs / @ar_tip_cam
	END
	ELSE
	BEGIN
		SELECT @va_tot_bUs = SUM(va_imp_tot) 
		FROM #tm_INV007
		
		SET @va_tot_bBs = @va_tot_bUs * @ar_tip_cam
		
		SET @va_des_cUs = @ar_des_cue
		SET @va_des_cBs = @va_des_cUs * @ar_tip_cam
		
		SET @va_tot_nUs = @va_tot_bUs - @va_des_cUs
		SET @va_tot_nBs = @va_tot_nUs * @ar_tip_cam
	END
	
		
	-- REGISTRA ENCABEZADO COMPRA
	INSERT INTO INV007 VALUES(@ar_ide_doc, @ar_nro_tal, @va_nro_cmp, @ar_ges_tio, @va_ide_cmp, @ar_pro_vee,
							  @va_raz_soc,@ar_fec_cmp, @ar_tip_cam,@ar_mon_cmp,@ar_for_pag,@ar_cod_caj,@ar_lin_cxp,@ar_ref_cmp,
							  @ar_cod_bod,@ar_tip_cmp,@ar_ban_fac,@ar_lib_cpr, GETDATE(), 
							  @va_tot_bBs,@va_tot_bUs, @va_des_cBs, @va_des_cUs, @va_tot_nBs,@va_tot_nUs, @ar_obs_cmp, 
							  0,0,'',0,'',0,0,0,0,0,0,0,@ar_cod_usr, GETDATE(),'','01/01/1900','01/01/1900', 'V' )
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Ocurrio un error al ingresar el encabezado de compra',16,1)
		RETURN
	END
		
	
--// Cursor sobre temporal
DECLARE vc_det_cmp CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_und_cmp,va_can_cmp,va_pre_uni,va_imp_tot,va_tip_fam
FROM #tm_INV007	
	
--** Abre cursor		  
OPEN vc_det_cmp    
	 
SET @va_con_tad = 0

FETCH NEXT FROM vc_det_cmp 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_und_cmp,@va_can_cmp,@va_pre_uni,@va_imp_tot,@va_tip_fam

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_eqv_cmp = va_eqv_cmp
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	-- CANTIDADES SEGUN UNIDADES DE MEDIDA
	--	si la unidad de compra es igual a la unidad de medida
	IF (@va_und_cmp = @va_und_umd ) 
	BEGIN
		SET @va_can_uiv = @va_can_cmp
	END
	ELSE
	BEGIN
		SET @va_can_uiv = @va_can_cmp * @va_eqv_cmp
	END
	
	-- Calcula Precios unitarios
	IF @ar_mon_cmp = 'B' 
	BEGIN
		IF (@va_und_cmp = @va_und_umd )
		BEGIN
			SET @va_pre_uBs = @va_pre_uni
			SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
		END
		IF (@va_und_cmp <> @va_und_umd  )
		BEGIN
			SET @va_pre_uni = @va_pre_uni / @va_eqv_cmp
			SET @va_pre_uBs = @va_pre_uni
			SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
		END
	END
	
	IF @ar_mon_cmp = 'U' 
	BEGIN
		IF (@va_und_cmp = @va_und_umd )
		BEGIN
			SET @va_pre_uUs = @va_pre_uni
			SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
		END
		IF (@va_und_cmp <> @va_und_umd )
		BEGIN
			SET @va_pre_uni = @va_pre_uni / @va_eqv_cmp
			SET @va_pre_uUs = @va_pre_uni
			SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
		END
	END
	
	
	
	-- Calcula Precios Totales 
	IF @ar_mon_cmp = 'B'
	BEGIN
		SET @va_pre_tBs = @va_imp_tot
		SET @va_pre_tUs = @va_imp_tot / @ar_tip_cam
	END
	IF @ar_mon_cmp = 'U'
	BEGIN
		SET @va_pre_tUs = @va_imp_tot
		SET @va_pre_tBs = @va_imp_tot * @ar_tip_cam
	END
	
	-- PRORATEA DESCUENTOS POR ITEM EN MONEDA DEL DOCUMENTO
	IF @ar_mon_cmp ='B'
		SET @va_por_cen = (@va_imp_tot * 100) / @va_tot_bBs
	ELSE
		SET @va_por_cen = (@va_imp_tot * 100) / @va_tot_bUs
	
	
	SET @va_des_uni = (@va_por_cen * @ar_des_cue) / 100
	SET @va_des_acu = @va_des_acu + @va_des_uni
	
	IF @@CURSOR_ROWS = @va_con_tad
	BEGIN
		IF @va_des_acu <> @ar_des_cue
			SET @va_des_uni = @va_des_uni + (@ar_des_cue - @va_des_acu)
	END
	
	-- OBTIENE DESCUENTOS UNITARIOS EN BS Y US PARA CALCULOS
	IF @ar_mon_cmp ='B'
	BEGIN
		SET @va_des_unB = @va_des_uni
		SET @va_des_unU = @va_des_uni / @ar_tip_cam
	END
	ELSE
	BEGIN
		SET @va_des_unU = @va_des_uni
		SET @va_des_unB = @va_des_uni * @ar_tip_cam
	END
	
	-- REGISTRA DETALLE DE COMPRA
	INSERT INTO inv008 VALUES(@ar_ide_doc, @ar_nro_tal, @va_nro_cmp, @ar_ges_tio, @va_ide_cmp, @va_nro_itm,
							  @va_cod_pro,@va_des_pro, 0,@va_und_umd,@va_und_cmp,@va_can_uiv,@va_can_cmp,
							  @va_pre_uBs,@va_pre_uUs,@va_pre_tBs,@va_pre_tUs, @va_des_uni,'','' )
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al ingresar item del detalle',16,1)
		RETURN
	END
	  --//OBTIENE COSTO UNITARIO NETO DE LA COMPRA SIN IVA (en unidad de inventario)
	SET @va_cos_uoB = (@va_pre_tBs - @va_des_unB) / @va_can_uiv
	SET @va_cos_uoU = (@va_pre_tUs - @va_des_unU) / @va_can_uiv
	
	
	
	--IF (@va_und_cmp <> @va_und_umd)
	--BEGIN
	--	SET @va_cos_uoB = @va_cos_uoB / @va_eqv_cmp
	--	SET @va_cos_uoU = @va_cos_uoU / @va_eqv_cmp
	--END
	
--print @va_cos_uoB
--	print @va_cos_uoU
--	print @va_eqv_cmp
--	print '----------------------'
--	print '   '

	--// CALCULO DE COSTO DEL PRODUCTO
		--Obtiene cantidad y costo actual 
		SELECT @va_sal_can = va_sal_can,
			   @va_cos_ubs = va_cos_ubs,
			   @va_cos_uus = va_cos_uus
		  FROM inv099
		 WHERE va_cod_pro = @va_cod_pro	AND
			   va_cod_bod = @ar_cod_bod
			   
		IF @@ROWCOUNT = 0
		BEGIN
			INSERT INTO inv099 VALUES (@ar_cod_bod, @va_cod_pro, 0, 0, 0)
		
			SET @va_sal_can = 0
			SET @va_cos_ubs = 0
			SET @va_cos_uus = 0
		END
		
		
		-- costo total actual (no incluye esta compra)
		SET @va_cos_taB = @va_cos_ubs * @va_sal_can
		SET @va_cos_taU = @va_cos_uus * @va_sal_can
		
		-- cantidad stock actualizado (incluye esta compra)  [Saldo actual + cantidad unidad inventario de compra]
		SET @va_sal_acu = @va_sal_can + @va_can_uiv
		
		IF @ar_tip_cmp = 1	-- SIN FACTURA costea sobre el 100%
		BEGIN
			-- costo total actualizado (incluye esta compra)
			SET @va_cos_taB = @va_cos_taB + (@va_pre_tBs - @va_des_cBs)
			SET @va_cos_taU = @va_cos_taU + (@va_pre_tUs - @va_des_cUs)
		END
		
		
			
		IF (@ar_tip_cmp = 0) OR (@ar_tip_cmp = 2)  	-- CON FACTURA
		BEGIN
		
			IF @ar_ban_fac = 0	--no hay factura, costea sobre el  100%
			BEGIN
				-- costo total actualizado (incluye esta compra)
				SET @va_cos_taB = @va_cos_taB + (@va_pre_tBs - @va_des_cBs)
				SET @va_cos_taU = @va_cos_taU + (@va_pre_tUs - @va_des_cUs)
			END
			IF @ar_ban_fac <> 0	-- si hay/x recuperar, costea sobre el 87%
			BEGIN
				-- costo total actualizado (incluye esta compra)
				SET @va_cos_taB = @va_cos_taB + ((@va_pre_tBs - @va_des_unB) * 0.87)
				SET @va_cos_taU = @va_cos_taU + ((@va_pre_tUs - @va_des_unU) * 0.87)
				
				--Costo unitario de la operacion CON IVA
				SET @va_cos_uoB = (@va_cos_uoB * 0.87)
				SET @va_cos_uoU = (@va_cos_uoU * 0.87)
			END
		END	
		
		-- calcula costo unitario PROMEDIADO actualizado (incluye esta compra)
		SET @va_cos_uaB = @va_cos_taB / @va_sal_acu
		SET @va_cos_uaU = @va_cos_taU / @va_sal_acu
		
		--IF @va_und_umd <> @va_und_cmp
		--BEGIN
		--	SET @va_cos_uaB = @va_cos_uaB / @va_eqv_cmp
		--	SET @va_cos_uaU = @va_cos_uaU / @va_eqv_cmp
		--END
		
	--//ACTUALIZA EXISTENCIA
	 UPDATE inv099 -- ... @va_sal_acu
	    SET va_sal_can= va_sal_can + @va_can_uiv , va_cos_ubs = @va_cos_uaB , va_cos_uus = @va_cos_uaU
	  WHERE va_cod_bod = @ar_cod_bod AND va_cod_pro = @va_cod_pro
  	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al actualizar saldos de stock',16,1)
		RETURN
	END
	  
	--//REGISTRA KARDEX
	INSERT INTO inv100 VALUES (@ar_ges_tio,@ar_ide_doc,@ar_nro_tal,@va_nro_cmp,@va_ide_cmp, @va_nro_itm,
							   @ar_fec_cmp, GETDATE(), @ar_ref_cmp, @ar_mon_cmp,@ar_obs_cmp, @va_cod_pro,
							   @va_can_uiv,0,@va_cos_uoB,@va_cos_uoU,(@va_cos_uoB * @va_can_uiv),(@va_cos_uoU * @va_can_uiv), 
							   @va_cos_uaB,@va_cos_uaU, @ar_cod_bod, 'Lote: ', @ar_tip_cam, @ar_cod_usr)
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: :Error al registrar el kardex',16,1)
		RETURN
   END
   
 
	FETCH NEXT FROM vc_det_cmp 
	INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_und_cmp,@va_can_cmp,@va_pre_uni,@va_imp_tot,@va_tip_fam
END

--// ACTUALIZA CONTADOR
UPDATE ads005 SET va_con_tad = @va_nro_cmp
WHERE va_ide_doc = @ar_ide_doc AND 
	  va_nro_tal = @ar_nro_tal AND
	  va_ges_tio = @ar_ges_tio

CLOSE vc_det_cmp
DEALLOCATE vc_det_cmp

-- Borra temporal
DELETE INV007tmp
WHERE va_cod_tmp = @ar_cod_tmp AND
	  va_cod_usr = @ar_cod_usr
	  
	  
select * from  INV007
WHERE va_doc_doc = @ar_ide_doc	AND
	  va_nro_tal = @ar_nro_tal	AND
	  va_nro_cmp = @va_nro_cmp	AND
	  va_ges_cmp = @ar_ges_tio 
	
	COMMIT TRAN TR_INV007
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_INV007
	RETURN
END CATCH	

GO  
/*
ARCHIVO: inv007_05a_p01.sql
PROCEDIMIENTO: CONSULTA COMPRA
	(Formato = 0 ; en Undidad de Compra)
AUTOR:	CREARSIS(chl)
FECHA:	26-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_05a_p01
GO

CREATE PROCEDURE inv007_05a_p01 @ar_ide_cmp	NVARCHAR(20),	-- Identificador de la compra
								@ar_ges_cmp	INT	-- gestion de la compra
							 WITH ENCRYPTION AS
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_fec_cmp		DATETIME,
@va_cod_doc		CHAR(03),
@va_nro_cmp		INT,
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(50),			-- Numero de del documento
@va_for_pag		INT,	--Identificador de la venta (XXX|000-00000/2018)
@va_tip_cam		DECIMAL(4,2),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(80),
@va_mon_cmp		CHAR(01),
@va_tot_bBs		DECIMAL(16,5),
@va_tot_bUs		DECIMAL(16,5),
@va_tot_bru		DECIMAL(16,5),
@va_des_cBs		DECIMAL(16,5),
@va_des_cUs		DECIMAL(16,5),
@va_des_cue		DECIMAL(16,5),
@va_tot_nBs		DECIMAL(16,5),
@va_tot_nUs		DECIMAL(16,5),
@va_tot_net		DECIMAL(16,5),
@va_obs_cmp		VARCHAR(200),
@va_est_ado		CHAR(01),
@va_usr_reg		VARCHAR(15),
@va_fec_reg		DATETIME,
@va_nro_itm		INT,
@va_cod_pro		VARCHAR(15),
@va_des_pro		varchar(120)	,	--Descripcion del Producto 
@va_can_tid		DECIMAL(14,4),				--Cantidad de producto
@va_und_inv		CHAR(03)		,	--Numero de item 
@va_pre_uBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tot		DECIMAL(16,2),
@va_fir_ma1		VARCHAR(30)	,
@va_fir_ma2		VARCHAR(30)	,
@va_fir_ma3		VARCHAR(30)	,
@va_fir_ma4		VARCHAR(30)	


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv007(
	va_fec_cmp		DATETIME		NOT NULL,	--Codigo del usuario
	va_ide_cmp		VARCHAR(20)		NOT NULL,	--Codigo temporal (fecha y hora)
	va_ges_cmp		INT				not null,	--Numero de item 
	va_nro_cmp		INT				NOT NULL,	--Codigo Producto
	va_cod_bod		INT				not null,	--Numero de item 
	va_nom_bod		VARCHAR(50)		not null,	--Numero de item
	va_for_pag		INT				NOT NULL,	-- Forma de Pago **
	va_tip_cam		DECIMAL(4,2)	NOT NULL,	--Tipo de cambio **
	va_cod_per		INT				not null,	--Numero de item 
	va_raz_soc		VARCHAR(80)		not null,	--Numero de item 
	va_mon_cmp		CHAR(01)		not null,	--Numero de item 
	va_tot_bru		DECIMAL(16,5)	not null,	--Numero de item 
	va_des_cue		DECIMAL(16,5)	not null,	--Numero de item 
	va_tot_net		DECIMAL(16,5)	not null,	--Numero de item 
	va_obs_cmp		VARCHAR(200)	not null,	--Numero de item 
	va_est_ado		CHAR(01)		not null,	--Numero de item 
	va_usr_reg		VARCHAR(15)		NOT NULL,	--Usuario registro
	va_fec_reg		DATETIME		NOT NULL,	--Fecha de registro
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		not null,	--Numero de item 
	va_des_pro		varchar(120)	not null,	--Descripcion del Producto 
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_und_inv		CHAR(03)		not null,	--Numero de item 
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_fir_ma1		VARCHAR(30)	,
	va_fir_ma2		VARCHAR(30)	,
	va_fir_ma3		VARCHAR(30)	,
	va_fir_ma4		VARCHAR(30)	,

   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv007
BEGIN TRY

	-- Obtiene datos del encabezado
	SELECT @va_fec_cmp = va_fec_cmp, @va_nro_cmp = va_nro_cmp,
		   @va_cod_doc = va_doc_doc,
		   @va_cod_per = va_cod_per, @va_raz_soc = va_raz_soc,
		   @va_tot_bBs = va_tot_bBs, @va_tot_bUs = va_tot_bUs,
		   @va_des_cBs = va_des_cBs, @va_des_cUs = va_des_cUs,
		   @va_tot_nBs = va_tot_nBs, @va_tot_nUs = va_tot_nUs,
		   @va_cod_bod = va_cod_bod, @va_tip_cam = va_tip_cam,
		   @va_mon_cmp = va_mon_cmp, @va_for_pag = va_for_pag,
		   @va_usr_reg = va_usr_reg, @va_fec_reg = va_fec_reg,
		   @va_obs_cmp = va_obs_cmp, @va_est_ado = va_est_ado
	FROM inv007
	WHERE va_ide_cmp = @ar_ide_cmp	AND
		  va_ges_cmp = @ar_ges_cmp
	
	-- Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	FROM inv002
	WHERE va_cod_bod = @va_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_nom_bod = '';
	END
	
	-- Obtiene firmas del documento
	SELECT @va_fir_ma1 = va_fir_ma1,
		   @va_fir_ma2 = va_fir_ma2,
		   @va_fir_ma3 = va_fir_ma3,
		   @va_fir_ma4 = va_fir_ma4
	 FROM ads004
	WHERE va_ide_doc = @va_cod_doc
	
	--Obtiene Totales segun moneda de la compra
	IF (@va_mon_cmp = 'B')
	BEGIN
		SET @va_tot_bru = @va_tot_bBs
		SET @va_des_cue = @va_des_cBs
		SET @va_tot_net = @va_tot_nBs
	END
	IF (@va_mon_cmp = 'U')
	BEGIN
		SET @va_tot_bru = @va_tot_bUs
		SET @va_des_cue = @va_des_cUs
		SET @va_tot_net = @va_tot_nUs
	END
		
		
	--// Cursor sobre temporal
	DECLARE vc_inv008 CURSOR LOCAL FOR
	SELECT va_nro_itm, va_cod_pro, va_des_pro, va_can_uiv, va_cod_uni,
		   va_pre_uBs, va_pre_uUs, va_imp_tBs, va_imp_tUs 
	FROM inv008	
	WHERE va_ide_cmp = @ar_ide_cmp	AND
		  va_ges_cmp = @ar_ges_cmp
	
	--** Abre cursor		  
	OPEN vc_inv008    
		 
	FETCH NEXT FROM vc_inv008 INTO @va_nro_itm, @va_cod_pro, @va_des_pro, @va_can_tid, @va_und_inv,
								   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	
	
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@va_mon_cmp = 'B')
		BEGIN
			SET @va_pre_uni = @va_pre_uBs
			SET @va_pre_tot = @va_pre_tBs
		END
		IF (@va_mon_cmp = 'U')
		BEGIN
			SET @va_pre_uni = @va_pre_uUs
			SET @va_pre_tot = @va_pre_tUs
		END
		
	
		INSERT INTO #tm_inv007 VALUES ( @va_fec_cmp		,
										@ar_ide_cmp		,
										@ar_ges_cmp		,
										@va_nro_cmp		,
										@va_cod_bod		,
										@va_nom_bod		,
										@va_for_pag		,
										@va_tip_cam		,
										@va_cod_per		,
										@va_raz_soc		,
										@va_mon_cmp		,
										@va_tot_bru		,
										@va_des_cue		,
										@va_tot_net		,
										@va_obs_cmp		,
										@va_est_ado		,
										@va_usr_reg		,
										@va_fec_reg		,
										@va_nro_itm		,
										@va_cod_pro		,
										@va_des_pro		,
										@va_can_tid		,
										@va_und_inv		,
										@va_pre_uni		,
										@va_pre_tot		,  
										@va_fir_ma1		,
										@va_fir_ma2		,
										@va_fir_ma3		,
										@va_fir_ma4 )
			
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de items en tabla temporal',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_inv008 INTO @va_nro_itm, @va_cod_pro, @va_des_pro, @va_can_tid,@va_und_inv,
									   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	END	
CLOSE vc_inv008
DEALLOCATE vc_inv008

SELECT * FROM #tm_inv007
	

	COMMIT TRAN TR_inv007
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv007
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv007_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE COMPRAS
AUTOR:	CREARSIS(chl)
FECHA:	19-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_R01
GO

CREATE PROCEDURE inv007_R01 @ar_cod_pe1 INT,			-- Proveedor
							@ar_cod_pe2 INT,			-- Proveedor
							@ar_cod_bo1 INT,			-- Bodega
							@ar_cod_bo2 INT,			-- Bodega
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_est_ado CHAR(01)		-- Estado (T=todos ; H=valido ; N=anulado)
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),

@va_fec_cmp		DATETIME, 
@va_ide_cmp		NVARCHAR(15), 
@va_nro_cmp		INT, 
@va_cod_per		INT, 
@va_raz_soc		NVARCHAR(180),
@va_mon_cmp		CHAR(01), 
@va_tot_nBs		DECIMAL(16,2), 
@va_tot_nUs		DECIMAL(16,2), 
@va_est_ado		CHAR(01), 
@va_ges_cmp		INT, 
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(40),
@va_obs_cmp		NVARCHAR(200)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv007(
	va_fec_cmp		DATETIME, 
	va_ide_cmp		NVARCHAR(15), 
	va_nro_cmp		INT, 
	va_cod_per		INT, 
	va_raz_soc		NVARCHAR(180),
	va_mon_cmp		CHAR(01), 
	va_tot_nBs		DECIMAL(16,2), 
	va_tot_nUs		DECIMAL(16,2), 
	va_est_ado		CHAR(01), 
	va_ges_cmp		INT, 
	va_cod_bod		INT,
	va_nom_bod		VARCHAR(40),
	va_obs_cmp		NVARCHAR(200)
   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 


IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'




--// Cursor sobre temporal
DECLARE vc_inv007 CURSOR LOCAL FOR
SELECT	va_fec_cmp, va_ide_cmp, va_nro_cmp, va_cod_per, va_raz_soc, 
		va_mon_cmp, va_tot_nBs, va_tot_nUs, va_est_ado, va_ges_cmp, va_cod_bod, va_obs_cmp
 FROM inv007
WHERE	(va_cod_per BETWEEN @ar_cod_pe1 AND @ar_cod_pe2)  AND
		(va_cod_bod BETWEEN @ar_cod_bo1 AND @ar_cod_bo2)  AND
		
		(va_fec_cmp BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
		 va_est_ado LIKE @ar_est_ado  

--** Abre cursor		  
OPEN vc_inv007    
	 
FETCH NEXT FROM vc_inv007 INTO @va_fec_cmp, @va_ide_cmp, @va_nro_cmp, @va_cod_per, @va_raz_soc,
							   @va_mon_cmp, @va_tot_nBs, @va_tot_nUs, @va_est_ado, @va_ges_cmp, @va_cod_bod, @va_obs_cmp

WHILE (@@FETCH_STATUS = 0)
BEGIN
	--Obtiene nombre de Bodega
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @va_cod_bod
	 
	 INSERT INTO #tm_inv007 VALUES	(@va_fec_cmp,
									@va_ide_cmp	,
									@va_nro_cmp	,
									@va_cod_per	,
									@va_raz_soc	,
									@va_mon_cmp	,
									@va_tot_nBs	,
									@va_tot_nUs	,
									@va_est_ado	,
									@va_ges_cmp	,
									@va_cod_bod	,
									@va_nom_bod	,
									@va_obs_cmp
									)
	FETCH NEXT FROM vc_inv007 INTO @va_fec_cmp, @va_ide_cmp, @va_nro_cmp, @va_cod_per, @va_raz_soc,
							   @va_mon_cmp, @va_tot_nBs, @va_tot_nUs, @va_est_ado, @va_ges_cmp, @va_cod_bod,@va_obs_cmp

END	
CLOSE vc_inv007
DEALLOCATE vc_inv007

SELECT * FROM #tm_inv007
ORDER BY va_fec_cmp

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: inv099_05a_p01.sql
PROCEDIMIENTO: OBTIENE EXISTENCIA ACTUAL DE UN PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	11-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv099_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv099_05a_p01
GO

CREATE PROCEDURE inv099_05a_p01 @ar_cod_pro	VARCHAR(15)
							 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			NVARCHAR(200),
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(40),
@va_cod_pro		VARCHAR(15),
@va_nom_pro		VARCHAR(80),
@va_cod_umd		CHAR(03),
@va_und_cmp		CHAR(03),
@va_und_vta		CHAR(03),
@va_eqv_cmp		DECIMAL(6,2),
@va_eqv_vta		DECIMAL(6,2),
@va_nro_dec		INT,
@va_cod_fam		CHAR(06),
@va_nom_fam		VARCHAR(50),
@va_sal_can		DECIMAL(16,4),
@va_est_ado		CHAR(01)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv099(
	va_cod_bod		INT				NOT NULL,	--Codigo de bodega
	va_nom_bod		VARCHAR(40)		NOT NULL,	--Nombre de bodega
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_nom_pro		VARCHAR(80)		NOT NULL,	--Nombre de producto
	va_cod_umd		CHAR(03),
	va_und_cmp		CHAR(03),
	va_und_vta		CHAR(03),
	va_eqv_cmp		DECIMAL(6,2),
	va_eqv_vta		DECIMAL(6,2),
	va_nro_dec		INT,
	va_cod_fam		CHAR(06),
	va_nom_fam		VARCHAR(50),
	va_sal_can		DECIMAL(16,4)	NOT NULL,	--Saldo actual del producto
	va_est_ado		CHAR(01)
   )
   
IF @@ERROR <> 0
   RETURN
 
--// Cursor sobre tabla stock     
	DECLARE vc_inv099 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_sal_can, va_cod_bod
	  FROM inv099
	 WHERE va_cod_pro = @ar_cod_pro

	--** Abre cursor				  
	OPEN vc_inv099   
	FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		-- Obtiene datos de producto
		SELECT @va_nom_pro = va_nom_pro,
			   @va_cod_umd = va_cod_umd,
			   @va_und_cmp = va_und_cmp,
			   @va_und_vta = va_und_vta,
			   @va_eqv_cmp = va_eqv_cmp,
			   @va_eqv_vta = va_eqv_vta,
			   @va_nro_dec = va_nro_dec,
			   @va_cod_fam = va_cod_fam,
			   @va_est_ado = va_est_ado
		  FROM inv004
		 WHERE (va_cod_pro = @ar_cod_pro)
		
		-- Obtiene nombre de bodega
		SELECT @va_nom_bod = va_nom_bod
		 FROM	inv002
		WHERE	(va_cod_bod = @va_cod_bod)
		
		-- Obtiene nombre de familia
		SELECT @va_nom_fam = va_nom_fam
		  FROM inv003
		 WHERE (va_cod_fam = @va_cod_fam)
		
		-- Inserta en tabla resultado
		INSERT INTO #tm_inv099 VALUES (	@va_cod_bod,
										@va_nom_bod,
										@va_cod_pro,
										@va_nom_pro,
										@va_cod_umd,
										@va_und_cmp,
										@va_und_vta,
										@va_eqv_cmp,
										@va_eqv_vta,
										@va_nro_dec,
										@va_cod_fam,
										@va_nom_fam,
										@va_sal_can,
										@va_est_ado
										)
		FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod

	END
	
CLOSE vc_inv099
DEALLOCATE vc_inv099



SELECT * FROM #tm_inv099


GO  
/*
ARCHIVO: inv099_R01.sql
PROCEDIMIENTO: REPORTE KARDEX DE UN PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	24-04-2019
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv099_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv099_R01
GO

CREATE PROCEDURE inv099_R01		@ar_cod_bod		INT,			-- Almacen
								@ar_cod_pro		VARCHAR(15),	-- Producto
								@ar_fec_ini		DATE,			-- Fecha inicial
								@ar_fec_fin		DATE			-- Fecha final
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_fec_doc	DATE,
@va_ges_tio	INT,
@va_cod_doc	CHAR(03),
@va_nro_tal	INT,
@va_nro_doc	INT,
@va_ide_doc	VARCHAR(25),
@va_nro_itm	INT,
@va_ref_doc	VARCHAR(20),
@va_mon_eda	CHAR(01),
@va_glo_doc	NVARCHAR(100),
@va_cod_pro	VARCHAR(15)		,					--** Codigo del producto 
@va_nom_pro	VARCHAR(80)		,					--** Nombre del producto
@va_und_inv	CHAR(03),
@va_und_cmp	CHAR(03),
@va_und_vta	CHAR(03),
@va_eqv_cmp	DECIMAL(6,2),
@va_eqv_vta	DECIMAL(6,2),
@va_cod_fam	VARCHAR(6)		,					--** Codigo de la familia de producto
@va_can_ing	DECIMAL(14,4),
@va_can_egr	DECIMAL(14,4),
@va_cod_bod	INT				,					--Codigo de la bodega (inv002)
@va_nom_bod VARCHAR(50),
@va_cod_usr  NVARCHAR(15),
@va_fec_ant	DATE,
@va_sal_ant	DECIMAL(16,4),
@va_sal_ope DECIMAL(16,4)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv100(
	va_fec_ant	DATE,
	va_sal_ant	DECIMAL(16,4),
	va_sal_ope	DECIMAL(16,4),
	va_fec_ini	DATE,
	va_fec_fin  DATE,
	va_fec_doc	DATE,
	va_ges_tio	INT,
	va_cod_doc	CHAR(03),
	va_nro_tal	INT,
	va_nro_doc	INT,
	va_ide_doc	VARCHAR(25),
	va_nro_itm	INT,
	va_ref_doc	VARCHAR(20),
	va_mon_eda	CHAR(01),
	va_glo_doc	NVARCHAR(100),
	va_cod_pro	VARCHAR(15)		NOT NULL,					--** Codigo del producto 
	va_nom_pro	VARCHAR(80)		NOT NULL,						--** Nombre del producto
	va_und_inv	CHAR(03),
	va_und_cmp	CHAR(03),
	va_und_vta	CHAR(03),
	va_eqv_cmp	DECIMAL(6,2),
	va_eqv_vta	DECIMAL(6,2),
	va_cod_fam	VARCHAR(6)		NOT NULL,					--** Codigo de la familia de producto
	va_can_ing	DECIMAL(14,4),
	va_can_egr	DECIMAL(14,4),
	va_cod_bod	INT				NOT NULL,	--Codigo de la bodega (inv002)
	va_nom_bod  VARCHAR(50),
	va_cod_usr  NVARCHAR(15)
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
	
		
	--// Cursor sobre tabla kardex
	DECLARE vc_inv100 CURSOR LOCAL FOR
	SELECT va_fec_doc,va_ges_tio,va_cod_doc,va_nro_tal,va_nro_doc, va_ide_doc,va_nro_itm,va_ref_doc,va_mon_eda,va_glo_doc,
		   va_cod_pro,va_can_ing,va_can_egr,va_cod_bod,va_cod_usr
	FROM inv100 
	WHERE  va_cod_pro = @ar_cod_pro and
		   va_cod_bod = @ar_cod_bod	AND
		   (va_fec_doc BETWEEN @ar_fec_ini AND @ar_fec_fin)
	ORDER BY va_fec_doc asc , va_ide_doc asc		   

	--** Abre cursor			@va_nom_pro,@va_und_inv,@va_und_cmp,@va_und_vta	,@va_eqv_cmp,va_eqv_vta,@va_cod_fam,	  
	OPEN vc_inv100   
	FETCH NEXT FROM vc_inv100 INTO @va_fec_doc,@va_ges_tio,@va_cod_doc,@va_nro_tal,@va_nro_doc,@va_ide_doc,@va_nro_itm,@va_ref_doc,
								   @va_mon_eda,@va_glo_doc,@va_cod_pro,@va_can_ing,@va_can_egr,@va_cod_bod,@va_cod_usr 
		
		
	-- Inicializa fecha para saldo anterior
	SET @va_fec_ant = DATEADD(DAY,-1,@ar_fec_ini)
	
	
	 
	-- Obtiene saldo de stock anterior
	SET @va_sal_ant = 0
	EXECUTE inv100_01a_p02 @ar_cod_bod, @ar_cod_pro, @va_fec_ant, @va_sal_ant OUTPUT
	 
	IF (@va_sal_ant IS NULL)
		SET @va_sal_ant = 0
	
	-- Inicializa saldo de operacion
	SET @va_sal_ope = @va_sal_ant
		
		
	-- Obtiene Datos de producto
	SELECT @va_nom_pro=va_nom_pro ,@va_und_inv= va_cod_umd,@va_und_cmp=va_und_cmp ,@va_und_vta=va_und_vta,
		   @va_eqv_cmp=va_eqv_cmp ,@va_eqv_vta=va_eqv_vta ,@va_cod_fam=va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @ar_cod_pro 
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_nom_pro = ''
	END
	
	-- Obtiene nombre de la bodega
	SELECT @va_nom_bod=va_nom_bod 
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod 
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_nom_bod = ''
	END
	
	 
	IF(@@FETCH_STATUS <> 0 AND @va_sal_ant <> 0)	
	BEGIN
		INSERT INTO #tm_inv100 VALUES ( DATEADD(DAY,-1,@ar_fec_ini)	,
										@va_sal_ant ,
										@va_sal_ant ,
										@ar_fec_ini ,
										@ar_fec_fin ,
										@va_fec_doc	,
										@va_ges_tio	,
										@va_cod_doc	,
										@va_nro_tal	,
										@va_nro_doc	,
										@va_ide_doc ,
										@va_nro_itm	,
										@va_ref_doc	,
										@va_mon_eda	,
										@va_glo_doc	,
										@ar_cod_pro	,					--** Codigo del producto 
										@va_nom_pro	,					--** Nombre del producto
										@va_und_inv	,
										@va_und_cmp	,
										@va_und_vta	,
										@va_eqv_cmp	,
										@va_eqv_vta	,
										@va_cod_fam	,					--** Codigo de la familia de producto
										@va_can_ing	,
									  - @va_can_egr	,
										@ar_cod_bod	,					--Codigo de la bodega (inv002)
										@va_nom_bod ,
										@va_cod_usr
										)
	END	
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		
		-- Obtiene saldo de la operacion
		IF(@va_can_ing <> 0 )
			SET @va_sal_ope = @va_sal_ope + @va_can_ing
		
		IF(@va_can_egr <> 0)
			SET @va_sal_ope = @va_sal_ope - @va_can_egr
		
		PRINT @va_sal_ope
		
		INSERT INTO #tm_inv100 VALUES ( DATEADD(DAY,-1,@ar_fec_ini)	,
										@va_sal_ant ,
										@va_sal_ope ,
										@ar_fec_ini ,
										@ar_fec_fin ,
										@va_fec_doc	,
										@va_ges_tio	,
										@va_cod_doc	,
										@va_nro_tal	,
										@va_nro_doc	,
										@va_ide_doc ,
										@va_nro_itm	,
										@va_ref_doc	,
										@va_mon_eda	,
										@va_glo_doc	,
										@va_cod_pro	,					--** Codigo del producto 
										@va_nom_pro	,					--** Nombre del producto
										@va_und_inv	,
										@va_und_cmp	,
										@va_und_vta	,
										@va_eqv_cmp	,
										@va_eqv_vta	,
										@va_cod_fam	,					--** Codigo de la familia de producto
										@va_can_ing	,
										- @va_can_egr	,
										@va_cod_bod	,					--Codigo de la bodega (inv002)
										@va_nom_bod ,
										@va_cod_usr
										)
										
				IF(@va_fec_ant < @ar_fec_ini)
					SET @va_fec_ant = @ar_fec_ini
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de kardex de productos',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_inv100 INTO @va_fec_doc,@va_ges_tio,@va_cod_doc,@va_nro_tal,@va_nro_doc,@va_ide_doc,@va_nro_itm,@va_ref_doc,
								   @va_mon_eda,@va_glo_doc,@va_cod_pro,@va_can_ing,@va_can_egr,@va_cod_bod,@va_cod_usr 
	END	
	
CLOSE vc_inv100
DEALLOCATE vc_inv100


	SELECT * FROM #tm_inv100
	ORDER BY va_fec_doc ASC--, va_sal_ope asc


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv099_R02.sql
PROCEDIMIENTO: CONSULTA EXISTENCIA ACTUAL POR BODEGAS
	
AUTOR:	CREARSIS(fvm)
FECHA:	15-04-2019
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv099_R02') and sysstat & 0xf = 4)
	drop procedure dbo.inv099_R02
GO

CREATE PROCEDURE inv099_R02		@ar_bod_ini		INT,	-- Producto
								@ar_bod_fin		INT,			-- Bodega
								@ar_fam_ini		CHAR(06),		-- Familia inicial
								@ar_fam_fin		CHAR(06),		-- Familia final
								@ar_fec_exi		DATETIME		-- Fecha de existencia
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_cod_bod	INT,			--Codigo deL Bodega (inv002)
@va_nom_bod  VARCHAR(50),
@va_cod_pro	VARCHAR(15),	--** Codigo del producto 
@va_cod_fam	VARCHAR(6),		--C¢digo de la familia de producto
@va_nom_fam	VARCHAR(250),	--Nombre de la familia

@va_cod_fa1	VARCHAR(6),		--C¢digo de la familia 1er nivel
@va_nom_fa1	VARCHAR(50),	--Nombre de la familia 1er nivel
@va_cod_fa2	VARCHAR(6),		--C¢digo de la familia 2er nivel
@va_nom_fa2	VARCHAR(50),	--Nombre de la familia 2er nivel
@va_cod_fa3	VARCHAR(6),		--C¢digo de la familia 3er nivel
@va_nom_fa3	VARCHAR(50),	--Nombre de la familia 3er nivel
@va_tip_fam CHAR(01),		--Tipo de familia

@va_nom_pro	VARCHAR(80),	--** Nombre del producto
@va_sal_can DECIMAL(14,2),	--Stock total x almac‚n (unidad inventario)
@va_cod_umd 	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv099(
	
	va_cod_bod	INT,			--Codigo deL Bodega (inv002)
	va_nom_bod  VARCHAR(50),
	va_cod_fa1	VARCHAR(6),		--C¢digo de la familia 1er nivel
	va_nom_fa1	VARCHAR(50),	--Nombre de la familia 1er nivel
	va_cod_fa2	VARCHAR(6),		--C¢digo de la familia 2er nivel
	va_nom_fa2	VARCHAR(50),	--Nombre de la familia 2er nivel
	va_cod_fa3	VARCHAR(6),		--C¢digo de la familia 3er nivel
	va_nom_fa3	VARCHAR(50),	--Nombre de la familia 3er nivel
	va_tip_fam	CHAR(01),		--Tipo de familia
	va_cod_pro	VARCHAR(15),	--** Codigo del producto 
	va_nom_pro	VARCHAR(80),	--** Nombre del producto
	va_sal_can	DECIMAL(14,2),	--Stock total x almac‚n (unidad inventario)
	va_fec_exi	DATETIME,		--Fecha existencia
	va_cod_umd	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
		
	--// Cursor sobre tabla stock     
	DECLARE vc_inv099 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_sal_can, va_cod_bod
	  FROM inv099
	 WHERE (va_cod_bod BETWEEN @ar_bod_ini AND @ar_bod_fin)
	   AND (va_sal_can > 0)

	--** Abre cursor				  
	OPEN vc_inv099   
	FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		-- Obtiene saldo de stock anterior
		SET @va_sal_can = 0
		EXECUTE inv100_01p02 @va_cod_bod, @va_cod_pro, @ar_fec_exi, @va_sal_can OUTPUT
		
		IF (@va_sal_can IS NULL)
			SET @va_sal_can = 0
	
	
		-- Obtiene Datos de producto
		SELECT @va_nom_pro = va_nom_pro,
			   @va_cod_umd  = va_cod_umd,
			   @va_cod_fam = va_cod_fam
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_pro = ''
			SET @va_cod_umd  = ''
			SET @va_cod_fam = ''
		END
		
		IF (@va_cod_fam NOT BETWEEN @ar_fam_ini AND @ar_fam_fin)
		BEGIN		
			GOTO fi_sal_lin;
		END
		
		
		-- Obtiene nombre del Bodega
		SELECT @va_nom_bod = va_nom_bod 
		  FROM inv002
		 WHERE va_cod_bod = @va_cod_bod 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_bod = ''
		END
		
		
		--*********************************
		-- Obtiene Familia a 3er nivel
		SELECT @va_nom_fa3 = va_nom_fam,
			   @va_cod_fa3 = va_cod_fam,
			   @va_tip_fam = va_tip_fam
		  FROM inv003
		 WHERE va_cod_fam = @va_cod_fam
		
		-- Obtiene Familia a 2do nivel
		SELECT @va_nom_fa2 = va_nom_fam,
			   @va_cod_fa2 = va_cod_fam
		  FROM inv003
		 WHERE va_cod_fam = SUBSTRING(@va_cod_fam,1,4)+'00'
		
		-- Obtiene Familia a 1do nivel
		SELECT @va_nom_fa1 = va_nom_fam,
			   @va_cod_fa1 = va_cod_fam
		  FROM inv003
		 WHERE va_cod_fam = SUBSTRING(@va_cod_fam,1,2)+'0000'
		
		
		INSERT INTO #tm_inv099 VALUES ( @va_cod_bod,	--Codigo deL Bodega (inv002)
										@va_nom_bod,
										@va_cod_fa1,	--C¢digo de la familia de producto
										@va_nom_fa1,	--Nombre de la familia
										@va_cod_fa2,	--C¢digo de la familia de producto
										@va_nom_fa2,	--Nombre de la familia
										@va_cod_fa3,	--C¢digo de la familia de producto
										@va_nom_fa3,	--Nombre de la familia
										@va_tip_fam,	--Tipo de familia
										@va_cod_pro,	--** Codigo del producto 
										@va_nom_pro,	--** Nombre del producto
										@va_sal_can,	--Stock total x almac‚n (unidad inventario)
										@ar_fec_exi,	--Fecha de existencia
										@va_cod_umd      -- Unidad de inventario
										)										
				
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de stock de productos',16,1)
				RETURN
			END
		
		fi_sal_lin:
		FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
	END	
	
CLOSE vc_inv099
DEALLOCATE vc_inv099


	SELECT * FROM #tm_inv099
	WHERE va_sal_can <> 0
		ORDER BY va_cod_bod, va_cod_fa1


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv100_01a_p01.sql
PROCEDIMIENTO: OBTIENE STOCK A LA FECHA DE 1 PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	11-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv100_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv100_01a_p01
GO

CREATE PROCEDURE inv100_01a_p01 @ar_cod_bod	CHAR(06),		-- Usuario registro
							 @ar_cod_pro	VARCHAR(15),	-- Codigo de la temporal 
							 @ar_fec_sal	DATE		
							 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			NVARCHAR(200),
@va_sal_stk		DECIMAL(16,4)


--** CREA TABLA TEMPORAL
--CREATE TABLE #tm_INV100(
--	va_cod_bod		SMALLINT		NOT NULL,	--Codigo del usuario
--	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
--	va_sal_stk		DECIMAL(16,4)	NOT NULL,	--Saldo de stock a la fecha
--	va_fec_sal		DATE			NOT NULL,	--Fecha del saldo de stock
--	va_sal_ant		DECIMAL(16,4)	NOT NULL,	--Saldo anterior a la fecha
--	va_fec_ant		DATE			NOT NULL	--Fecha del saldo de stock
--   )
   
IF @@ERROR <> 0
   RETURN

SET @va_sal_stk = '0'


--// Obtiene saldo de Stock a la fecha
SET @va_sal_stk  = 
(
SELECT  SUM(va_can_ing - va_can_egr) 
  FROM inv100
 WHERE va_cod_bod = @ar_cod_bod AND
	   va_cod_pro = @ar_cod_pro AND
	   va_fec_doc <= @ar_fec_sal
)

IF(@va_sal_stk is null) 
BEGIN
	SET @va_sal_stk = 0
END

SELECT @va_sal_stk AS va_sal_stk, @ar_fec_sal AS va_fec_sal

GO  
/*
ARCHIVO: inv100_01a_p02.sql
PROCEDIMIENTO: RETORNA STOCK A LA FECHA DE 1 PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	11-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv100_01a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.inv100_01a_p02
GO

CREATE PROCEDURE inv100_01a_p02	  @ar_cod_bod	CHAR(06),		-- Usuario registro
								  @ar_cod_pro	VARCHAR(15),	-- Codigo de la temporal 
								  @ar_fec_sal	DATE,
								  @rt_sal_stk	DECIMAL(16,4) OUTPUT	
							 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			NVARCHAR(200),
@va_sal_stk		DECIMAL(16,4), 
@va_fec_sal		DATE

   
IF @@ERROR <> 0
   RETURN

SET @va_sal_stk = '0'
SET @va_fec_sal = '01/01/1990'

--// Obtiene saldo de Stock a la fecha
SET @rt_sal_stk  = 
(
SELECT  SUM(va_can_ing - va_can_egr) as va_sal_stk 
  FROM inv100
 WHERE va_cod_bod = @ar_cod_bod AND
	   va_cod_pro = @ar_cod_pro AND
	   va_fec_doc <= @ar_fec_sal
)

IF(@rt_sal_stk is null) 
BEGIN
	SET @rt_sal_stk = 0
END

GO  
/*
ARCHIVO: inv100_R01.sql
PROCEDIMIENTO: REPORTE KARDEX DE UN PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	24-04-2019
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv100_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv100_R01
GO

CREATE PROCEDURE inv100_R01	@ar_cod_pro		VARCHAR(15),	-- Producto
								@ar_cod_bod		CHAR(06),			-- Almacen
								@ar_fec_ini		DATE,			-- Fecha inicial
								@ar_fec_fin		DATE			-- Fecha final
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_fec_doc	DATE,
@va_ges_tio	INT,
@va_cod_doc	CHAR(03),
@va_nro_tal	INT,
@va_nro_doc	INT,
@va_ide_doc	VARCHAR(25),
@va_nro_itm	INT,
@va_ref_doc	VARCHAR(20),
@va_mon_eda	CHAR(01),
@va_glo_doc	NVARCHAR(100),
@va_cod_pro	VARCHAR(15)		,					--** Codigo del producto 
@va_nom_pro	VARCHAR(80)		,					--** Nombre del producto
@va_und_inv	CHAR(03),
@va_und_cmp	CHAR(03),
@va_und_vta	CHAR(03),
@va_eqv_cmp	DECIMAL(6,2),
@va_eqv_vta	DECIMAL(6,2),
@va_cod_fam	VARCHAR(6)		,					--** Codigo de la familia de producto
@va_can_ing	DECIMAL(14,4),
@va_can_egr	DECIMAL(14,4),
@va_cod_bod	CHAR(06)				,					--Codigo deL ALMACEN (inv011)
@va_nom_alm VARCHAR(50),
@va_cod_usr  NVARCHAR(15),
@va_fec_ant	DATE,
@va_sal_ant	DECIMAL(16,4),
@va_sal_ope DECIMAL(16,4)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv100(
	va_fec_ant	DATE,
	va_sal_ant	DECIMAL(16,4),
	va_sal_ope	DECIMAL(16,4),
	va_fec_ini	DATE,
	va_fec_fin  DATE,
	va_fec_doc	DATE,
	va_ges_tio	INT,
	va_cod_doc	CHAR(03),
	va_nro_tal	INT,
	va_nro_doc	INT,
	va_ide_doc	VARCHAR(25),
	va_nro_itm	INT,
	va_ref_doc	VARCHAR(20),
	va_mon_eda	CHAR(01),
	va_glo_doc	NVARCHAR(100),
	va_cod_pro	VARCHAR(15)		NOT NULL,					--** Codigo del producto 
	va_nom_pro	VARCHAR(80)		NOT NULL,						--** Nombre del producto
	va_und_inv	CHAR(03),
	va_und_cmp	CHAR(03),
	va_und_vta	CHAR(03),
	va_eqv_cmp	DECIMAL(6,2),
	va_eqv_vta	DECIMAL(6,2),
	va_cod_fam	VARCHAR(6)		NOT NULL,					--** Codigo de la familia de producto
	va_can_ing	DECIMAL(14,4),
	va_can_egr	DECIMAL(14,4),
	va_cod_bod	CHAR(06)				NOT NULL,	--Codigo deL ALMACEN (inv011)
	va_nom_alm  VARCHAR(50),
	va_cod_usr  NVARCHAR(15)
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
	
		
	--// Cursor sobre tabla productos     va_nom_pro,va_und_inv,va_und_cmp,va_und_vta,va_eqv_cmp,va_eqv_vta,va_cod_fam,
	DECLARE vc_inv002 CURSOR LOCAL FOR
	SELECT va_fec_doc,va_ges_tio,va_cod_doc,va_nro_tal,va_nro_doc, va_ide_doc,va_nro_itm,va_ref_doc,va_mon_eda,va_glo_doc,
		   va_cod_pro,va_can_ing,va_can_egr,va_cod_bod,va_cod_usr
	FROM inv100 
	WHERE  va_cod_pro = @ar_cod_pro and
		   va_cod_bod = @ar_cod_bod	AND
		   (va_fec_doc BETWEEN @ar_fec_ini AND @ar_fec_fin)

	--** Abre cursor			@va_nom_pro,@va_und_inv,@va_und_cmp,@va_und_vta	,@va_eqv_cmp,va_eqv_vta,@va_cod_fam,	  
	OPEN vc_inv002   
	FETCH NEXT FROM vc_inv002 INTO @va_fec_doc,@va_ges_tio,@va_cod_doc,@va_nro_tal,@va_nro_doc,@va_ide_doc,@va_nro_itm,@va_ref_doc,
								   @va_mon_eda,@va_glo_doc,@va_cod_pro,@va_can_ing,@va_can_egr,@va_cod_bod,@va_cod_usr 
		
		
	-- Inicializa fecha para saldo anterior
	SET @va_fec_ant = DATEADD(DAY,-1,@ar_fec_ini)
	
	-- Obtiene saldo de stock anterior
	SET @va_sal_ant = 0
	EXECUTE inv100_01p2 @va_cod_bod, @va_cod_pro, @va_fec_ant, @va_sal_ant OUTPUT
	
	IF (@va_sal_ant IS NULL)
		SET @va_sal_ant = 0
	
	-- Inicializa saldo de operacion
	SET @va_sal_ope = @va_sal_ant
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		-- Obtiene Datos de producto
		SELECT @va_nom_pro=va_nom_pro ,@va_und_inv= va_cod_umd,@va_und_cmp=va_und_cmp ,@va_und_vta=va_und_vta,
			   @va_eqv_cmp=va_eqv_cmp ,@va_eqv_vta=va_eqv_vta ,@va_cod_fam=va_cod_fam
		FROM inv002
		WHERE va_cod_pro = @ar_cod_pro 
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_pro = ''
		END
		
		-- Obtiene nombre del almacen
		SELECT @va_nom_alm=va_nom_alm 
		FROM inv011
		WHERE va_cod_bod = @ar_cod_bod 
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_alm = ''
		END
		
		-- Obtiene saldo de la operacion
		IF(@va_can_ing <> 0 )
			SET @va_sal_ope = @va_sal_ope + @va_can_ing
		
		
		IF(@va_can_egr <> 0)
			SET @va_sal_ope = @va_sal_ope - @va_can_egr
		
		INSERT INTO #tm_inv100 VALUES ( DATEADD(DAY,-1,@ar_fec_ini)	,
										@va_sal_ant ,
										@va_sal_ope ,
										@ar_fec_ini ,
										@ar_fec_fin ,
										@va_fec_doc	,
										@va_ges_tio	,
										@va_cod_doc	,
										@va_nro_tal	,
										@va_nro_doc	,
										@va_ide_doc ,
										@va_nro_itm	,
										@va_ref_doc	,
										@va_mon_eda	,
										@va_glo_doc	,
										@va_cod_pro	,					--** Codigo del producto 
										@va_nom_pro	,					--** Nombre del producto
										@va_und_inv	,
										@va_und_cmp	,
										@va_und_vta	,
										@va_eqv_cmp	,
										@va_eqv_vta	,
										@va_cod_fam	,					--** Codigo de la familia de producto
										@va_can_ing	,
										- @va_can_egr	,
										@va_cod_bod	,					--Codigo deL ALMACEN (inv011)
										@va_nom_alm ,
										@va_cod_usr
										)
										
				IF(@va_fec_ant < @ar_fec_ini)
					SET @va_fec_ant = @ar_fec_ini
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de kardex de productos',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_inv002 INTO @va_fec_doc,@va_ges_tio,@va_cod_doc,@va_nro_tal,@va_nro_doc,@va_ide_doc,@va_nro_itm,@va_ref_doc,
								   @va_mon_eda,@va_glo_doc,@va_cod_pro,@va_can_ing,@va_can_egr,@va_cod_bod,@va_cod_usr 
	END	
	
CLOSE vc_inv002
DEALLOCATE vc_inv002


	SELECT * FROM #tm_inv100


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: inv100_R02.sql
PROCEDIMIENTO: REPORTE STOCK DE UN PRODUCTO
	
AUTOR:	CREARSIS(fvm)
FECHA:	15-04-2019
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv100_R02') and sysstat & 0xf = 4)
	drop procedure dbo.inv100_R02
GO

CREATE PROCEDURE inv100_R02	@ar_bod_ini		CHAR(06),	-- Producto
								@ar_bod_fin		CHAR(06),			-- Almacen
								@ar_fam_ini		CHAR(06),		-- Familia inicial
								@ar_fam_fin		CHAR(06)		-- Familia final
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_cod_bod	CHAR(06),			--Codigo deL ALMACEN (inv011)
@va_nom_bod  VARCHAR(50),
@va_cod_fam	VARCHAR(6),		--C¢digo de la familia de producto
@va_cod_pro	VARCHAR(15),	--** Codigo del producto 
@va_nom_fam	VARCHAR(250),	--Nombre de la familia
@va_cod_aux VARCHAR(6),		--C¢digo de la familia de producto
@va_cod_aux2 VARCHAR(6),		--C¢digo de la familia de producto
@va_cod_aux3 VARCHAR(6),		--C¢digo de la familia de producto
@va_fam_aux	VARCHAR(250),	--Nombre de la familia
@va_nom_pro	VARCHAR(80),	--** Nombre del producto
@va_sal_can DECIMAL(14,2),	--Stock total x almac‚n (unidad inventario)
@va_und_inv	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv100(
	
	va_cod_bod	CHAR(06),			--Codigo deL ALMACEN (inv011)
	va_nom_bod  VARCHAR(50),
	va_cod_fam	VARCHAR(6),		--C¢digo de la familia de producto
	va_nom_fam	VARCHAR(250),	--Nombre de la familia
	va_cod_pro	VARCHAR(15),	--** Codigo del producto 
	va_nom_pro	VARCHAR(80),	--** Nombre del producto
	va_sal_can DECIMAL(14,2),	--Stock total x almac‚n (unidad inventario)
	va_cod_inv	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
	
		
	--// Cursor sobre tabla stock     
	DECLARE vc_inv002 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_sal_can, va_cod_bod
	  FROM inv101 
	 WHERE (va_cod_bod BETWEEN @ar_bod_ini AND @ar_bod_fin)
	   AND (va_sal_can > 0)

	--** Abre cursor				  
	OPEN vc_inv002   
	FETCH NEXT FROM vc_inv002 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		-- Obtiene Datos de producto
		SELECT @va_nom_pro = va_nom_pro,
			   @va_und_inv = va_cod_umd,
			   @va_cod_fam = va_cod_fam
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_pro = ''
			SET @va_und_inv = ''
			SET @va_cod_fam = ''
		END
		
		IF (@va_cod_fam NOT BETWEEN @ar_fam_ini AND @ar_fam_fin)
		BEGIN		
			GOTO fi_sal_lin;
		END
		
		
		-- Obtiene nombre del almacen
		SELECT @va_nom_bod = va_nom_bod 
		  FROM inv011
		 WHERE va_cod_bod = @va_cod_bod 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_bod = ''
		END
		
		-- Obtiene nombre de la familia
		--** Verifica la familia que se desplegue
		IF SUBSTRING(@va_cod_fam,1,2) <> '00'
		BEGIN 
			SET @va_cod_aux = SUBSTRING(@va_cod_fam,1,2) + '0000'
			
			SELECT @va_nom_fam = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_nom_fam = ''
			END
		END
		
		IF SUBSTRING(@va_cod_fam,3,2) <> '00'
		BEGIN 
			SET @va_cod_aux2 = SUBSTRING(@va_cod_fam,1,4) + '00'
			
			SELECT @va_fam_aux = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux2
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_fam_aux = ''
			END
			
			IF LEN(RTRIM(@va_nom_fam)) <> ''
			BEGIN
				SET @va_nom_fam = @va_cod_aux + ' - ' + @va_nom_fam + CHAR(13) + CHAR(10) + '   ' +@va_cod_aux2+' - '+ @va_fam_aux
			END
			 
		END
		
		IF SUBSTRING(@va_cod_fam,5,2) <> '00'
		BEGIN 
			SET @va_cod_aux3 = SUBSTRING(@va_cod_fam,1,6)
			
			SELECT @va_fam_aux = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux3
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_fam_aux = ''
			END
			
			IF LEN(RTRIM(@va_nom_fam)) <> ''
			BEGIN
				SET @va_nom_fam = @va_nom_fam + CHAR(13) + CHAR(10) + '	     ' + @va_cod_aux3 +' - '+ @va_fam_aux
			END			 
		END
		--SET @va_nom_fam = @va_nom_fam + CHAR(13) + CHAR(10) + '   .'
		
		INSERT INTO #tm_inv100 VALUES ( @va_cod_bod,	--Codigo deL ALMACEN (inv011)
										@va_nom_bod,
										@va_cod_fam,	--C¢digo de la familia de producto
										@va_nom_fam,	--Nombre de la familia
										@va_cod_pro,	--** Codigo del producto 
										@va_nom_pro,	--** Nombre del producto
										@va_sal_can,	--Stock total x almac‚n (unidad inventario)
										@va_und_inv     -- Unidad de inventario
										)										
				
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de stock de productos',16,1)
				RETURN
			END
		
		fi_sal_lin:
		FETCH NEXT FROM vc_inv002 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
	END	
	
CLOSE vc_inv002
DEALLOCATE vc_inv002


	SELECT * FROM #tm_inv100
		ORDER BY va_cod_bod, va_cod_fam


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*????????????????????????????????????????????????
ARCHIVO: inv003_R03.sql
PROCEDIMIENTO: REPORTE CATALOGO DE PRODUCTO
	
AUTOR:	CREARSIS(FVM)
FECHA:	21-04-2019
--????????????????????????????????????????????????*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv003_R03') and sysstat & 0xf = 4)
	drop procedure dbo.inv003_R03
GO

CREATE PROCEDURE inv003_R03	@ar_fam_ini		CHAR(06),		-- Familia inicial
								@ar_fam_fin		CHAR(06)		-- Familia final
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_cod_fam	VARCHAR(6),		--Código de la familia de producto
@va_cod_pro	VARCHAR(15),	--** Codigo del producto 
@va_nom_fam	VARCHAR(250),	--Nombre de la familia
@va_cod_aux	VARCHAR(6),		--Código de la familia de producto
@va_cod_aux2 VARCHAR(6),		--Código de la familia de producto
@va_cod_aux3 VARCHAR(6),		--Código de la familia de producto

@va_fam_aux	VARCHAR(250),	--Nombre de la familia
@va_nom_pro	VARCHAR(80),	--** Nombre del producto
@va_und_cmp	CHAR(3),		--** (inv003-Und. Med)Codigo de la unidad de compra
@va_und_vta	CHAR(3),		--** (inv003-Und. Med)Codigo de la unidad de venta
@va_und_inv	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv100(
	va_cod_fam	VARCHAR(6),		--Código de la familia de producto
	va_nom_fam	VARCHAR(250),	--Nombre de la familia
	va_cod_pro	VARCHAR(15),	--** Codigo del producto 
	va_nom_pro	VARCHAR(80),	--** Nombre del producto
	va_cod_inv	CHAR(3),		--** (inv003-Und. Med)Codigo de la Unidad de Medida
	va_und_cmp	CHAR(3),		--** (inv003-Und. Med)Codigo de la unidad de compra
    va_und_vta	CHAR(3) 		--** (inv003-Und. Med)Codigo de la unidad de venta
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
	
		
	--// Cursor sobre tabla catalogo     
	DECLARE vc_inv004 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_cod_umd,
		   va_cod_fam, va_und_cmp, va_und_vta
	  FROM inv004 
	 WHERE (va_cod_fam BETWEEN @ar_fam_ini AND @ar_fam_fin)
	   
	--** Abre cursor				  
	OPEN vc_inv004   
	FETCH NEXT FROM vc_inv004 INTO @va_cod_pro, @va_nom_pro, @va_und_inv,
								   @va_cod_fam, @va_und_cmp, @va_und_vta
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
				
		-- Obtiene nombre de la familia
		--** Verifica la familia que se desplegue
		IF SUBSTRING(@va_cod_fam,1,2) <> '00'
		BEGIN 
			SET @va_cod_aux = SUBSTRING(@va_cod_fam,1,2) + '0000'
			
			SELECT @va_nom_fam = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_nom_fam = ''
			END
		END
		
		IF SUBSTRING(@va_cod_fam,3,2) <> '00'
		BEGIN 
			SET @va_cod_aux2 = SUBSTRING(@va_cod_fam,1,4) + '00'
			
			SELECT @va_fam_aux = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux2
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_fam_aux = ''
			END
			
			IF LEN(RTRIM(@va_nom_fam)) <> ''
			BEGIN
				SET @va_nom_fam = @va_cod_aux + ' - ' + @va_nom_fam + CHAR(13) + CHAR(10) + '   ' +@va_cod_aux2+' - '+ @va_fam_aux
			END
			 
		END
		
		IF SUBSTRING(@va_cod_fam,5,2) <> '00'
		BEGIN 
			SET @va_cod_aux3 = SUBSTRING(@va_cod_fam,1,6)
			
			SELECT @va_fam_aux = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux3
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_fam_aux = ''
			END
			
			IF LEN(RTRIM(@va_nom_fam)) <> ''
			BEGIN
				SET @va_nom_fam = @va_nom_fam + CHAR(13) + CHAR(10) + '	     ' + @va_cod_aux3 +' - '+ @va_fam_aux
			END			 
		END
		--SET @va_nom_fam = @va_nom_fam + ' - ' + @va_cod_fam + CHAR(13) + CHAR(10) + '   .'
		
		INSERT INTO #tm_inv100 VALUES ( @va_cod_fam,	--Código de la familia de producto
										@va_nom_fam,	--Nombre de la familia
										@va_cod_pro,	--** Codigo del producto 
										@va_nom_pro,	--** Nombre del producto
										@va_und_inv,     -- Unidad de inventario
										@va_und_cmp,
										@va_und_vta
										)										
				
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de stock de productos',16,1)
				RETURN
			END
				
		FETCH NEXT FROM vc_inv004 INTO @va_cod_pro, @va_nom_pro, @va_und_inv,
									   @va_cod_fam, @va_und_cmp, @va_und_vta
	END	
	
CLOSE vc_inv004
DEALLOCATE vc_inv004


	SELECT * FROM #tm_inv100
		ORDER BY va_cod_fam


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: res001_01a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO BUSCA VENTAS
AUTOR:	CREARSIS(chl)
FECHA:	19-01-2019
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res001_01a_p01
GO

CREATE PROCEDURE res001_01a_p01 @ar_cod_cli INT,			-- codigo cliente
							@ar_cod_bod CHAR(06),			-- Almacen
							@ar_fec_ini DATE,				-- Fecha de inicial
							@ar_fec_fin DATE,				-- Fecha de final
							@ar_tex_bus NVARCHAR(200),		-- Texto a buscar
							@ar_par_bus INT,				-- parametro Busqueda (0=Razon Social venta; 1 = Observaciones)
							@ar_est_ado CHAR(01),			-- Estado (T=todos ; H=valido ; N=anulado)
							@ar_tip_doc CHAR(01)			-- Tipo documento (V=Venta; C=Cotizacion; F=Factura)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_cli_ini		INT,
@va_cli_fin		INT,
@va_bod_ini		CHAR(06),
@va_bod_fin		CHAR(06)

IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
 
 PRINT @ar_cod_bod
IF (@ar_cod_bod = '0')
BEGIN	
	SET @va_bod_ini = '0'
	SET @va_bod_fin = '99-999'
END
IF (@ar_cod_bod <> '0')
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
END


IF (@ar_cod_cli = 0)
BEGIN	

	SET @va_cli_ini = 0
	SET @va_cli_fin = 9999999
END
IF (@ar_cod_cli <> 0)
BEGIN	
	SET @va_cli_ini = @ar_cod_cli
	SET @va_cli_fin = @ar_cod_cli
END

IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'

IF @ar_tip_doc = 'F'
BEGIN
	IF(@ar_par_bus = 0)	 -- Busca por Razon Social venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM res001
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 1) AND
			   va_raz_soc  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	IF(@ar_par_bus = 1)	 -- Busca por Observacion venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM res001
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 1) AND
			   va_obs_vta  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	
END

IF @ar_tip_doc = 'V'
BEGIN
IF(@ar_par_bus = 0)	 -- Busca por Razon Social venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM res001
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 2) AND
			   va_raz_soc  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	IF(@ar_par_bus = 1)	 -- Busca por Observacion venta
	BEGIN
		 SELECT va_fec_vta,va_doc_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
				va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_vta, va_ges_vta
		 FROM res001
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			  (va_tip_vta = 2) AND
			   va_obs_vta  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END 
END

--IF @ar_tip_doc = 'C'
--BEGIN
	-- SELECT va_fec_cot AS va_fec_vta, va_ide_cot AS va_ide_vta, va_nro_cot AS va_nro_vta, 
	--		va_cod_per, va_raz_soc, va_mon_cot AS va_mon_vta, va_tot_vtB, va_tot_vtU, 
	--		va_est_ado, va_obs_cot AS va_obs_vta, va_ges_cot AS va_ges_vta
	-- FROM cmr007
	--WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
	--	  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
	--	  (va_fec_cot BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	--	   va_obs_cot  LIKE @ar_tex_bus + '%'	AND
	--	   va_est_ado LIKE @ar_est_ado  
--END


	

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: res001_02a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO REGISTRA VENTA
	(venta, suma existencia, kardex, 
	registra movimiento efectivo/CxC )
AUTOR:	CREARSIS(chl)
FECHA:	12-10-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res001_02a_p01
GO

CREATE PROCEDURE res001_02a_p01 @ar_cod_usr NVARCHAR(15),	-- Usuario registro
							@ar_cod_tmp	 DATETIME,	-- Codigo de la temporal
							
							@ar_pla_vta	INT,			-- Plantilla de Venta
							@ar_tip_vta	INT,			-- Tipo de operacion 
														-- ( 1=Factura; 2=Nota de Venta;  3=Nota de Consumo )
							@ar_nro_fac	INT,			-- Nro de factura en caso que la numeracion sea manual
							@ar_cod_bod CHAR(06),		-- Bodega
							@ar_cod_cli INT,			-- codigo Cliente
							@ar_nit_cli	NVARCHAR(20),	-- Nit del cliente
							@ar_raz_soc	NVARCHAR(100),	-- Razon Social del cliente
							@ar_mon_vta CHAR(01),		-- Moneda de venta (B=Bs ; U=Us )
							@ar_fec_vta DATE,			-- Fecha de venta
							@ar_for_pag INT,			-- Forma de pago (1=Contado; 2=Credito)
							@ar_ven_ded	INT,			-- Vendedor de la venta
							@ar_lis_pre	INT,			-- Lista de precio usada en la venta
							@ar_cod_caj INT,			-- Codigo de caja
							@ar_lin_cxc INT,			-- Linea Cta. x Cob. (codigo de libro)
							
							@ar_tip_cam	DECIMAL(7,5),	-- Tipo de cambio
							@ar_des_cue DECIMAL(10,2),	-- Descuento General
							@ar_obs_vta NVARCHAR(200),  -- Observacion
							@ar_vta_par CHAR(01)	,	-- Venta para (M=Mesa; L=Llevar; D=Delivery)
							@ar_cod_del	INT			,	-- Codigo Delivery
							
							@ar_ref_vta NVARCHAR(20),	-- Referecia del documento
							@ar_mto_efe DECIMAL(16,5),	-- Monto cancelado en la moneda del documento
							@ar_cam_bio	DECIMAL(16,5),	-- Cambio en la moneda del documento
							@ar_nro_aut	VARCHAR(20),	-- Numero de autorizacion/Dosificacion 
							@ar_cod_ctr VARCHAR(20)	-- Codigo de control de la factura
							
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),

@va_ide_doc		CHAR(03),
@va_nro_tal		INT,
@va_tip_tal		INT,			-- Tipo numeracion del talonario (0=manual ; 1=automatico)
@va_nro_fac		INT,			-- Nro de factura

@va_nro_vta		INT,			-- Numero de del documento
@va_nro_vta_tmp INT,
@va_ide_vta		VARCHAR(20),	--Identificador de la venta (XXX|000-00000)
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_cod_tmp		DATETIME,		--Codigo temporal (fecha y hora)
@va_nro_itm		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_des_pro		varchar(80),	--Descripcion del Producto 

@va_opc_und		INT,			--Opcion de unidad de medida seleccionado
@va_und_umd		CHAR(03),		--Unidad de medida inventario del producto
@va_und_vta		CHAR(03),		--Unidad de medida de venta del producto
@va_can_uin		DECIMAL(14,4),	--Cantidad inventario de producto
@va_can_vta		DECIMAL(14,4),	--Cantidad de producto
@va_eqv_vta		DECIMAL(7,3),	-- Equivalencia entre @va_und_vta y @va_und_umd
@va_pre_uni		DECIMAL(14,4),	--Precio Unitario de item en la moneda del documento
@va_pre_tot		DECIMAL(16,2),	--Precio Total de item en la moneda del documento
@va_des_cue		DECIMAL(16,2),	--Descuento del item en moneda de la venta
@va_pre_lis		DECIMAL(16,2),	--Precio de la lista de precio del item en moneda de la venta
@va_imp_tot		DECIMAL(16,2),	--Importe Total en la moneda del documento
@va_cod_fam		VARCHAR(15),	-- Codigo de familida a la que pertenece el producto
@va_tip_fam		CHAR(01),		-- Tipo de familia 

@va_tot_bBs		DECIMAL(16,2),	-- Total bruto del documento en Bs
@va_tot_bUs		DECIMAL(16,2),	-- Total bruto del documento en Us
@va_des_cBs		DECIMAL(16,2),	-- Descuento global al documento en Bs.
@va_des_cUs		DECIMAL(16,2),	-- Descuento global al documento en Us.
@va_tot_nBs		DECIMAL(16,2),	-- Total neto del documento en Bs.
@va_tot_nUs		DECIMAL(16,2),	-- total neto del documento en Us.

@va_pre_uBs		DECIMAL(16,2),	-- Precio unitario en Bs
@va_pre_uUs		DECIMAL(16,2),	-- Precio unitario en Us.
@va_pre_tBs		DECIMAL(16,2),	-- Precio total en Bs.
@va_pre_tUs		DECIMAL(16,2),	-- precio total en Us.
@va_dto_uBs		DECIMAL(16,2),	-- Descueto lineal unitario en Bs.
@va_dto_uUs		DECIMAL(16,2),	-- Descueto lineal unitario en Us.
@va_por_ite		DECIMAL(16,2),	-- Porcentaje lineal unitario

@va_count		INT,			-- Contador de registros
@va_con_tad		INT,			-- Contador para validacion
@va_con_dsf		INT,			-- Contador de la dosificacion
@va_fin_dsf		DATE,			-- Fecha de inicial de la dosificacion
@va_fex_dsf		DATE,			-- Fecha de expiracion de la dosificacion
@va_nin_dsf		INT,			-- Numero inicial de la dosificacion
@va_nfi_dsf		INT,			-- Numero final de la dosificacion

--// Valores para prorratear descuento global del documento sobre los items
@va_por_cen		DECIMAL(16,5),	-- Porcentaje de descuento unitario
@va_des_uni		DECIMAL(16,2),	-- Valor de descuento unitario
@va_des_unB		DECIMAL(16,2),	-- Descuento unitario en Bs para calculo
@va_des_unU		DECIMAL(16,2),	-- Descuento unitario en Us para calculo
@va_des_acu		DECIMAL(16,2),	-- Descuento acumulado para calculo
@va_pmx_des		DECIMAL(16,2),	-- Porcentaje Descuento permitido segun lista de precio
@va_pmx_inc		DECIMAL(16,2),	-- Porcentaje Incremento permitido segun lista de precio

-- VARIABLES PARA CALCULO DE COSTOS
@va_sal_can		DECIMAL(14,2),	--Saldo stock actual EN UNIDAD DE MEDIDA INVENTARIO
@va_cos_ubs		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Bs)
@va_cos_uus		DECIMAL(14,6),	--Costo Unitario (promedio ponderado en Us)

@va_iva_uBs		DECIMAL(14,6),	--Iva unitario por item en Bs
@va_iva_uUs		DECIMAL(14,6),	--Iva unitario por item en Us
@va_itr_uBs		DECIMAL(14,6),	--ITr unitario por item en Bs
@va_itr_uUs		DECIMAL(14,6),	--ITr unitario por item en Us


-- variables para gestion
@va_ges_vta		INT,
@va_ges_tio		INT,
@va_ges_per		INT,
@va_fec_ini		DATE, 
@va_fec_fin		DATE,

@va_fec_exp		DATE,			-- Fecha de expiracion de la libreta de  la persona
@va_sal_act		DECIMAL(16,2),	-- Saldo actual de la libreta de la persona
@va_mto_lim		DECIMAL(16,2),	-- monto limite autorizado en la libreta de la persona

@va_sal_aut		DECIMAL(16,2),	-- Saldo autorizado de credito (@va_mto_lim - @va_sal_act)
@va_mon_lib		CHAR(01),		-- Moneda de la libreta

@va_stk_act		DECIMAL(16,4),	-- ESTOCK ACTUAL DEL PRODUCTO OBTENIDO DEL PROCEDIMIENTO (inv100_01p2)
@va_prd_vta		INT			 ,	-- Periodo de la venta
@va_cod_bod		INT			,	-- Codigo de bodega en  INT
@va_por_del		DECIMAL (3,1)	-- Porcentaje correspondiente al delivery



--** CREA TABLA TEMPORAL
CREATE TABLE #tm_vta001(
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_pre_lis		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_des_cue		DECIMAL(16,2),				--Precio Total en la moneda del documento
	va_por_cen		DECIMAL(16,2)				--Precio Total en la moneda del documento
	
   )
   
IF @@ERROR <> 0
   RETURN

BEGIN TRAN TR_vta001
BEGIN TRY   
  
   -- Carga temporal de venta
   INSERT INTO #tm_vta001
	SELECT * FROM res002tmp
	WHERE va_cod_tmp = @ar_cod_tmp AND
		  va_cod_usr = @ar_cod_usr
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('(10)-No hay ningun item para la venta',16,1)
		RETURN
	END



	/*
	-- Verifica plantilla de venta
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	FROM cmr004
	WHERE va_cod_plv = @ar_pla_vta
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('La Plantilla de Venta no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('La Plantilla de Venta se encuentra Deshabilitada',16,1)
		RETURN
	END	
	*/
	
	--// SEGUN LA OPERACION
	IF(@ar_tip_vta = 1) -- Factura
	BEGIN
		-- Obtiene documento y talonario de la operacion
		SELECT @va_ide_doc = va_doc_fac,
			   @va_nro_tal = va_tal_fac
		  FROM res004
		 WHERE va_cod_plv = @ar_pla_vta
	END
	IF(@ar_tip_vta = 2) -- Nota de Venta
	BEGIN
		-- Obtiene documento y talonario de la operacion
		SELECT @va_ide_doc = va_doc_ntv,
			   @va_nro_tal = va_tal_ntv
		  FROM res004
		 WHERE va_cod_plv = @ar_pla_vta
	END
	--IF(@ar_tip_vta = 3) -- Nota de Consumo
	--BEGIN
	--	-- Obtiene documento y talonario de la operacion
	--	SELECT @va_ide_doc = va_doc_,
	--		   @va_nro_tal = va_tal_fac
	--	  FROM res004
	--	 WHERE va_cod_plv = @ar_pla_vta
	--END
	
	
	--// Verifica Documento
	SET @va_est_ado = 'N'
	SELECT @va_est_ado = va_est_ado
	 FROM ads003
	WHERE va_ide_doc = @va_ide_doc 
		  
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('(11)-El Documento no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('(12)-El Documento se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Talonario
	SELECT @va_est_ado = va_est_ado,
		   @va_tip_tal = va_tip_tal
	 FROM ads004
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal
		   
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('(13)-El Talonario no se encuentra registrado',16,1)
		RETURN
	END
	
	--// Verifica que el usuario tenga permiso sobre el talonario
	SET @va_count = 0;
	SELECT @va_count = COUNT(*)
	  FROM ads008
	 WHERE va_ide_usr = SYSTEM_USER	AND
		   va_ide_tab = 'ads004'	AND
		   va_ide_uno = @va_ide_doc	AND
		   va_ide_dos = @va_nro_tal
		   
	IF(@va_count = 0)
	BEGIN
		RAISERROR ('(14)-El usuario no tiene permiso sobre el talonario',16,1)
		RETURN
	END
	
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('(15)-El Talonario se encuentra Deshabilitado',16,1)
		RETURN
	END
	
	
	
	SELECT	--@va_est_ado = va_est_ado,
			@va_ges_vta = va_ges_tio,
			@va_prd_vta = va_ges_per,
			@va_fec_ini = va_fec_ini,
			@va_fec_fin = va_fec_fin
	  FROM	ads016
	 WHERE	(@ar_fec_vta BETWEEN va_fec_ini AND va_fec_fin)
		 
	 IF (@va_ges_vta = 0)
	 BEGIN
		RAISERROR ('(16)-la fecha del documento no se encuentra dentro de una gestion definida',16,1)
		RETURN
	 END
/*
 IF (@va_est_ado = 'C')
 BEGIN
	RAISERROR ('la fecha del documento se encuentra dentro de un periodo cerrado',16,1)
	RETURN
 END
*/
		
--// Verifica Numeracion / inicialilza fechas iniciales para numeracion
	SET @va_fec_ini = '01.01.1990'
	SET @va_fec_fin = '01.01.1990'
	
	SELECT @va_nro_vta = va_con_tad,
		   @va_fec_ini = va_fec_ini,
		   @va_fec_fin = va_fec_fin
	FROM ads005
	WHERE va_ide_doc = @va_ide_doc AND 
		  va_nro_tal = @va_nro_tal AND
		  va_ges_tio = @va_ges_vta
	IF @@ROWCOUNT = 0
	BEGIN
		
	    SET @msg = '(17)-El Talonario('+ CAST (@va_nro_tal AS NVARCHAR(3)) + ' del Documento('+ @va_ide_doc +') NO dispone de numeracion para la gestion ' + CAST (@va_ges_vta AS VARCHAR(3))
		RAISERROR ( @msg ,16,1)
		RETURN
	END
	
	IF NOT (@ar_fec_vta > @va_fec_ini AND @ar_fec_vta < @va_fec_fin)
	BEGIN
		RAISERROR ('(18)-La fecha del documento no esta dentro del rango permitido en la numeracion para la gestion',16,1)
		RETURN
	END	
	
	--// Verifica Bodega
	SELECT @va_est_ado = va_est_ado
	FROM inv002
	WHERE va_cod_bod = @ar_cod_bod
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('(19)-El Bodega no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('(20)-El Bodega se encuentra Deshabilitada',16,1)
		RETURN
	END
	
	/*
	--// Verifica CLIENTE
	SELECT @va_est_ado = va_est_ado
	FROM adm010
	WHERE va_cod_per = @ar_cod_cli
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('El Cliente no se encuentra registrado',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('El Cliente se encuentra Deshabilitado',16,1)
		RETURN
	END

	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	--// Verifica LISTA DE PRECIO
	SELECT @va_est_ado = va_est_ado
	FROM cmr001
	WHERE va_cod_lis = @ar_lis_pre
	IF @@ROWCOUNT = 0
	BEGIN
		RAISERROR ('(21)-La Lista de Precio no se encuentra registrada',16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		RAISERROR ('(22)-La Lista de Precio se encuentra Deshabilitada',16,1)
		RETURN
	END

/*
	--// Verifica Caja si es al contado
	IF @ar_for_pag = 0
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM tes001
		WHERE va_cod_cjb = @ar_cod_caj
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La Caja/Banco no se encuentra registrada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La Caja/Banco se encuentra Deshabilitada',16,1)
			RETURN
		END
	END
	*/
	
	--// OBTIENE NUMERO CORRELATIVO PARA LA OPERACION
	--Suma en uno el contador de venta
	SET @va_nro_vta = @va_nro_vta + 1
	
	
	SET @va_nro_tal = 1000 + @va_nro_tal
	SET @va_nro_vta_tmp = 1000000 + @va_nro_vta
	
	--Prepara identificador de la venta
	SET @va_ide_vta = @va_ide_doc + '-' + SUBSTRING(CAST (@va_nro_tal AS VARCHAR(4)),2,3) + '-' + SUBSTRING(CAST(@va_nro_vta_tmp AS VARCHAR(7)),2,7)
	
	SET @va_nro_tal = @va_nro_tal - 1000
	
	
	if(@ar_tip_vta = 1)
	BEGIN
	
	
		--// OBTIENE CONTADOR DE LA DOSIFICACION
		SELECT @va_con_dsf = va_con_tad,
			   @va_fin_dsf = va_fec_ini,
			   @va_fex_dsf = va_fec_fin,
			   @va_nin_dsf = va_nro_ini,
			   @va_nfi_dsf = va_nro_fin
		  FROM ctb007  
		 WHERE va_nro_aut = @ar_nro_aut
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('(23)-La dosificacion no se encuentra registrada',16,1)
			RETURN
		END
		
		IF (@ar_fec_vta > @va_fex_dsf OR @ar_fec_vta < @va_fin_dsf)
		BEGIN
			RAISERROR ('(24)-La fecha del documento no esta dentro de las fechas de la dosificacion',16,1)
			RETURN
		END	
		
		if(@va_tip_tal = 0) -- Tipo numeracion Manual
		BEGIN
			SET @va_nro_fac = @ar_nro_fac
		END
		if(@va_tip_tal = 1) -- Tipo numeracion Automatico
		BEGIN
			SET @va_nro_fac = @va_con_dsf + 1
		END
		
		--// Verifica que el numero de la factura este dentro del rango permitido en la dosificacion
		IF (@va_nro_fac > @va_nfi_dsf AND @va_nro_fac < @va_nin_dsf)
		BEGIN
			RAISERROR ('(25)-La fecha del documento no esta dentro de las fechas de la dosificacion',16,1)
			RETURN
		END	
		
	END
	ELSE
	BEGIN
		SET @va_nro_fac = 0
		
	
	END
	
	
	IF @ar_mon_vta ='B'
	BEGIN
		SELECT @va_tot_bBs = SUM(va_pre_tot) 
		FROM #tm_vta001
		
		SET @va_tot_bUs = @va_tot_bBs / @ar_tip_cam
		
		SET @va_des_cBs = @ar_des_cue
		SET @va_des_cUs = @ar_des_cue / @ar_tip_cam
		
		SET @va_tot_nBs = @va_tot_bBs - @va_des_cBs
		SET @va_tot_nUs = @va_tot_nBs / @ar_tip_cam
	END
	ELSE
	BEGIN
		SELECT @va_tot_bUs = SUM(va_pre_tot) 
		FROM #tm_vta001
		
		SET @va_tot_bBs = @va_tot_bUs * @ar_tip_cam
		
		SET @va_des_cUs = @ar_des_cue
		SET @va_des_cBs = @va_des_cUs * @ar_tip_cam
		
		SET @va_tot_nUs = @va_tot_bUs - @va_des_cUs
		SET @va_tot_nBs = @va_tot_nUs * @ar_tip_cam
	END
	
	/*
	--// Verifica Linea de credito si es al credito
	IF @ar_for_pag = 1
	BEGIN
		SELECT @va_est_ado = va_est_ado
		FROM ecp007
		WHERE va_cod_per = @ar_cod_cli AND
			  va_cod_lib = @ar_lin_cxc
		IF @@ROWCOUNT = 0
		BEGIN
			RAISERROR ('La persona no tiene la libreta de la linea de credito espesificada',16,1)
			RETURN
		END
		IF @va_est_ado = 'N'
		BEGIN
			RAISERROR ('La persona no tiene habilitada la linea de credito espesificada',16,1)
			RETURN
		END
		
		IF( @ar_fec_vta > @va_fec_exp)
		BEGIN
			RAISERROR ('La linea de credito de la persona a expirado',16,1)
			RETURN
		END
		
		SELECT @va_mon_lib = va_mon_lib
		  FROM ecp006
		WHERE  va_cod_lib = @ar_lin_cxc
		
		SET @va_sal_aut = @va_mto_lim - @va_sal_act
		
		IF (@va_mon_lib = 'B')
		BEGIN
			IF (@va_tot_nBs > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		ELSE
		BEGIN
			IF (@va_tot_nus > @va_saL_aut )
			BEGIN
				RAISERROR ('El monto de la venta supera el saldo autorizado de la linea de credito',16,1)
				RETURN
			END
		END
		
	END
	*/
	
	
	-- Obtiene Porcentaje Delivery
	SET @va_por_del = 0
	IF(@ar_vta_par ='D')
	BEGIN
		SELECT @va_por_del = va_por_del 
		  FROM cmr015
		 WHERE va_cod_del = @ar_cod_del
	END
	ELSE
	BEGIN
		SET @ar_cod_del = 0
		SET @va_por_del = 0
	END
	
	-- REGISTRA ENCABEZADO venta select * from res001
	INSERT INTO res001 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_vta, @va_ges_vta, @va_ide_vta, @ar_tip_vta, @va_nro_fac, @ar_cod_cli,
							  @ar_raz_soc,@ar_nit_cli, @ar_fec_vta, @ar_tip_cam, @ar_pla_vta, @ar_ven_ded, @ar_mon_vta,
							  @ar_for_pag,@ar_cod_caj,@ar_lin_cxc,@ar_ref_vta,
							  @ar_cod_bod, @ar_lis_pre, @ar_vta_par,@ar_cod_del, @va_por_del,  
							  @va_tot_bBs, @va_tot_bUs,@va_des_cBs, @va_des_cUs,@va_tot_nBs, @va_tot_nUs, 
							  @ar_obs_vta, @ar_cod_usr, GETDATE(), '', '01/01/1900','V')
				 		 
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('(26)-Ocurrio un error al ingresar el encabezado de venta',16,1)
		RETURN
	END
		
	--// Si es factura 
	if (@ar_tip_vta = 1)
	BEGIN
		--//graba debito fiscal
		INSERT INTO ctb008 VALUES (@va_ges_vta,@va_prd_vta,@va_ide_vta,@va_nro_fac,@ar_nro_aut,@ar_nit_cli,@ar_raz_soc,@va_tot_bBs,
									@va_des_cBs,@va_tot_nBs, (@va_tot_nBs * 0.13), '' , @ar_fec_vta,GETDATE(),null)
		
		--// Registro de Nit de la persona
		SELECT @va_count = COUNT(*) 
		  FROM cmr013
		 WHERE va_nit_per = @ar_nit_cli AND
			   va_cod_per = @ar_cod_cli
			   
		IF @va_count = 0
			INSERT INTO cmr013 VALUES (@ar_cod_cli,@ar_nit_cli, @ar_raz_soc,1)
		IF @va_count = 1
		BEGIN
			--** Coloca los anteriores nit de la persona en antiguo
			UPDATE cmr013 SET va_act_ual = 0
			 WHERE va_cod_per = @ar_cod_cli
			 
			--** Actualiza el mas reciente nit usado
			UPDATE cmr013 SET va_raz_soc = @ar_raz_soc , va_act_ual = 1
			 WHERE va_nit_per =@ar_nit_cli AND va_cod_per = @ar_cod_cli
		END
	END	
			
--//OBTIENE IMPORTE TOTAL DEL DOCUMENTO
SELECT @va_imp_tot = sum(va_pre_tot)
FROM #tm_vta001
	/*
	--// SI ES EFECTIVO-GRABA RECIBO DE INGRESO A CAJA
	IF (@ar_for_pag = 0 ) --Contado
	BEGIN
	 --select * from tes002
		INSERT INTO TES002 VALUES (@ar_cod_caj,@va_ide_doc,@va_nro_tal,@va_nro_vta,@va_ges_vta,@va_ide_vta,@ar_cod_cli,@ar_raz_soc,0,
									@ar_mon_vta,@va_imp_tot,@ar_mto_efe, @ar_cam_bio, @ar_obs_vta,'V')
	END
	*/
	

	

	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_nro_itm,va_cod_pro,va_des_pro,va_opc_und, va_can_tid,va_pre_uni,va_pre_tot, va_pre_lis, va_des_cue, va_por_cen
FROM #tm_vta001	
	
--** Abre cursor		  
OPEN vc_det_vta    
	 
SET @va_con_tad = 0
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und,@va_can_vta,@va_pre_uni,@va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_con_tad = @va_con_tad + 1
	
	-- Verifica producto
	SELECT @va_est_ado = va_est_ado,
		   @va_und_umd = va_cod_umd,
		   @va_und_vta = va_und_vta,
		   @va_eqv_vta = va_eqv_vta,
		   @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no se encuentra registrado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +')  se encuentra deshabilitado'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	--//VERIFICA TIPO DE FAMILIA (SERVICIO/DETALLE/...)
	SELECT @va_est_ado = va_est_ado,
		   @va_tip_fam = va_tip_fam
	  FROM inv003
	 WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +') no se encuentra registrada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	IF @va_est_ado = 'N'
	BEGIN
		SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : La familia del producto ('+ @va_cod_pro +')  se encuentra deshabilitada'
		RAISERROR (@msg,16,1)
		RETURN
	END
	
	
	-- Calcula cantidades segun unidades de medida
	SET @va_can_uin = @va_can_vta
	
	IF (@va_tip_fam <> 'S')
	BEGIN
		IF (@va_und_umd <> @va_und_vta) 
		BEGIN
			IF(@va_opc_und = 0)
				SET @va_can_uin = @va_can_vta * @va_eqv_vta
		END
	END
	
	SET @va_cod_bod = @ar_cod_bod
		
	-- VERIFICA EXISTENCIA
	IF (@va_tip_fam <> 'S')
	BEGIN
		SET @va_stk_act = 0
		
		
		EXECUTE inv100_01a_p02 @va_cod_bod, @va_cod_pro, @ar_fec_vta, @va_stk_act OUTPUT
		
		IF (@va_stk_act IS NULL)
			SET @va_stk_act = 0
			
		IF (@va_stk_act = 0) OR (@va_can_uin > @va_stk_act)	
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : 
El producto ('+ @va_cod_pro +') NO cuenta con existencia suficiente  
Saldo a la fecha: (' + CAST(@va_stk_act AS VARCHAR(16)) + ')   '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	
	-- Calcula Precios unitarios
	IF @ar_mon_vta = 'B' AND (@va_und_umd = @va_und_vta)
	BEGIN
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'B' AND (@va_und_umd <> @va_und_vta)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA VENTA FUE "UNIDAD DE VENTA" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_vta
			
		SET @va_pre_uBs = @va_pre_uni
		SET @va_pre_uUs = @va_pre_uBs / @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'U' AND (@va_und_umd = @va_und_vta)
	BEGIN
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
	END
	
	IF @ar_mon_vta = 'U' AND (@va_und_umd <> @va_und_vta)
	BEGIN
		IF (@va_opc_und = 0) --// SI LA UNIDAD SELECCIONADA EN LA VENTA FUE "UNIDAD DE VENTA" ENTONCES DIVIDIR PRECIO UNITARIO ENTRE EQUIVALENTE
			SET @va_pre_uni = @va_pre_uni / @va_eqv_vta
			
		SET @va_pre_uUs = @va_pre_uni
		SET @va_pre_uBs = @va_pre_uUs * @ar_tip_cam
	END
	
	-- Calcula Precios y descuento unitarios Totales 
	IF @ar_mon_vta = 'B'
	BEGIN
		SET @va_pre_tBs = @va_pre_tot
		SET @va_pre_tUs = @va_pre_tot / @ar_tip_cam
		
		SET @va_dto_uBs = @va_des_cue
		SET @va_dto_uUs = @va_des_cue / @ar_tip_cam
	END
	IF @ar_mon_vta = 'U'
	BEGIN
		SET @va_pre_tUs = @va_pre_tot
		SET @va_pre_tBs = @va_pre_tot * @ar_tip_cam
		
		SET @va_dto_uUs = @va_des_cue
		SET @va_dto_uBs = @va_des_cue * @ar_tip_cam
	END
	
	
	SET @va_sal_can = 0
	SET @va_cos_ubs = 0
	SET @va_cos_uUs = 0
	
	IF (@va_tip_fam = 'D')
	BEGIN
		--//VERIFICA EXISTENCIA EN Bodega Y OBTIENE COSTO
		SELECT @va_sal_can = va_sal_can,
			   @va_cos_ubs = va_cos_ubs,
			   @va_cos_uUs = va_cos_uUs
		  FROM inv099
		WHERE va_cod_bod = @ar_cod_bod	AND
			  va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') jamas tuvo movimiento en el Bodega'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_can_uin > @va_sal_can 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con stock suficiente ('+ CAST(@va_sal_can AS NVARCHAR(10)) +')  '
			RAISERROR (@msg,16,1)
			RETURN
		END
		
		--//VERIFICA LIMITES DE DESCUENTO SEGUN LISTA DE PRECIO
		SELECT @va_pmx_des = va_pmx_des,
			   @va_pmx_inc = va_pmx_inc
		FROM cmr002
		 WHERE va_cod_lis = @ar_lis_pre AND
			   va_cod_pro = @va_cod_pro
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El producto ('+ @va_cod_pro +') no cuenta con precio definido en la lista de precio ('+ CAST(@ar_lis_pre AS NVARCHAR(10))  +')'
			RAISERROR (@msg,16,1)
			RETURN
		END
		IF @va_por_ite > @va_pmx_des 
		BEGIN
			SET @msg = 'Item: ' + CAST(@va_nro_itm AS CHAR(01)) + ' : El descuento para el producto ('+ @va_cod_pro +'), supera el permitido (Desc. Max.: '+ CAST(@va_pmx_des AS NVARCHAR(10)) +' %)  '
			RAISERROR (@msg,16,1)
			RETURN
		END
	END
	
	-- PRORATEA DESCUENTO GENERAL DOCUMENTO A LOS ITEM, EN MONEDA DEL DOCUMENTO
	SET @va_por_cen = (@va_pre_tot * 100) / @va_imp_tot
	
	SET @va_des_uni = (@va_por_cen * @ar_des_cue) / 100
	SET @va_des_acu = @va_des_acu + @va_des_uni
	
	IF @@CURSOR_ROWS = @va_con_tad
	BEGIN
		IF @va_des_acu <> @ar_des_cue
			SET @va_des_uni = @va_des_uni + (@ar_des_cue - @va_des_acu)
	END
	
	-- OBTIENE DESCUENTO GLOBAL UNITARIOS PRORATEADOS EN BS Y US PARA CALCULOS
	IF @ar_mon_vta ='B'
	BEGIN
		SET @va_des_unB = @va_des_uni
		SET @va_des_unU = @va_des_uni / @ar_tip_cam
	END
	ELSE
	BEGIN
		SET @va_des_unU = @va_des_uni
		SET @va_des_unB = @va_des_uni * @ar_tip_cam
	END
	
	--// CALCULA VALORES IMPOSITIVOS
	--IVA
	SET @va_iva_uBs = (@va_pre_tBs - @va_des_unU) * 0.13
	SET @va_iva_uUs = (@va_pre_tUs - @va_des_unB) * 0.13

	--ITR
	SET @va_itr_uBs = (@va_pre_tBs - @va_des_unU)  * 0.03
	SET @va_itr_uUs = (@va_pre_tUs - @va_des_unB) * 0.03
		
		
	
	-- REGISTRA DETALLE DE venta 
	INSERT INTO res002 VALUES(@va_ide_doc, @va_nro_tal, @va_nro_vta, @va_ges_vta, @va_ide_vta, @va_nro_itm,
							  @va_cod_pro,@va_des_pro, @va_opc_und,@va_und_vta,@va_und_umd,@va_eqv_vta,@va_can_vta,@va_can_uin,
							  @va_pre_lis, (@va_pre_uBs + @va_dto_uBs), (@va_pre_uUs + @va_dto_uUs), 
							  @va_dto_uBs, @va_dto_uUs,@va_por_ite, @va_pre_tBs,@va_pre_tUs,
							  @va_cos_uBs, @va_cos_uUs, @va_iva_uBs, @va_iva_uUs, @va_itr_uBs, @va_itr_uUs )
	
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: Error al ingresar item del detalle',16,1)
		RETURN
	END

	--//ACTUALIZA EXISTENCIA
	 UPDATE inv099 
	    SET va_sal_can = va_sal_can - @va_can_uin
	  WHERE va_cod_bod = @ar_cod_bod AND va_cod_pro = @va_cod_pro
  	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: Error al actualizar saldos de stock',16,1)
		RETURN
	END
  
	--//REGISTRA KARDEX
	INSERT INTO inv100 VALUES (@va_ges_vta,@va_ide_doc,@va_nro_tal,@va_nro_vta,@va_ide_vta, @va_nro_itm,
							   @ar_fec_vta, GETDATE(), @ar_ref_vta, @ar_mon_vta,@ar_obs_vta, @va_cod_pro,
							   0,@va_can_uin,@va_cos_ubs,@va_cos_uus,(@va_cos_ubs * @va_can_vta),(@va_cos_uus * @va_can_vta), 
							   @va_cos_ubs,@va_cos_uus, @va_cod_bod, 'Lote: ', @ar_tip_cam, @ar_cod_usr)
	IF @@ERROR <> 0
	BEGIN
		RAISERROR ('Item: Error al registrar el kardex',16,1)
		RETURN
   END
   
 
FETCH NEXT FROM vc_det_vta 
INTO @va_nro_itm,@va_cod_pro,@va_des_pro,@va_opc_und, @va_can_vta,@va_pre_uni,@va_pre_tot, @va_pre_lis, @va_des_cue, @va_por_ite

END


--// GRABA CXC 

--// GRABA INGRESO EFECTIVO


--// ACTUALIZA CONTADOR DE LA NUMERACION DEL DOCUMENTO
UPDATE ads005 SET va_con_tad = @va_nro_vta
WHERE va_ide_doc = @va_ide_doc AND 
	  va_nro_tal = @va_nro_tal AND
	  va_ges_tio = @va_ges_vta


--// ACTUALIZA CONTADOR DE LA DOSIFICACION
IF(@ar_tip_vta = 1) -- solo si la operacion es factura
BEGIN
	UPDATE ctb007 SET va_con_tad = @va_nro_fac
	WHERE va_nro_aut = @ar_nro_aut 
END

-- Cierra cursor
CLOSE vc_det_vta
DEALLOCATE vc_det_vta

-- Borra temporal
DELETE res002tmp
WHERE va_cod_tmp = @ar_cod_tmp AND
	  va_cod_usr = @ar_cod_usr

-- Consulta operacion para devolver
SELECT * FROM  res001
WHERE va_doc_vta = @va_ide_doc	AND
	  va_nro_tal = @va_nro_tal	AND
	  va_nro_vta = @va_nro_vta	AND
	  va_ges_vta = @va_ges_vta 
	
	COMMIT TRAN TR_vta001
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() 
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_vta001
	RETURN
END CATCH	

GO  
/*
ARCHIVO: res001_04a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO ANULA VENTA
	(anula venta, suma existencia, borra kardex, 
	costea reingreso de los productos, )
AUTOR:	CREARSIS(chl)
FECHA:	01-05-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res001_04a_p01
GO

CREATE PROCEDURE res001_04a_p01 @ar_ide_vta	VARCHAR(20),--Identificador de la venta (XXX|000-00000/2018)
							 @ar_ges_vta	INT --,		--Gestion de la venta							
							 --@ar_ide_usr	VARCHAR(15)	--Codigo del usuario que anula
							  WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_nro_doc		INT, 
@va_nro_reg		INT,
@va_est_ado		CHAR(01),
@va_cod_usr		VARCHAR(15),	--Codigo del usuario
@va_itm_vta		INT,			--Numero de item 
@va_cod_pro		VARCHAR(15),	--Codigo Producto
@va_can_uni		DECIMAL(14,4),	--Cantidad inventario de producto
@va_cod_fam		VARCHAR(6),					--** Codigo de la familia de producto
@va_tip_fam		CHAR(1),		--Tipo de la cuenta (M=Matriz ; D=DETALLE ; S=Servicio C=Combo)
@va_cod_bod		INT,	        --Codigo del almacen (7 numeros)
@va_ges_tio		INT,			--Gestion de la venta

@va_sal_can		DECIMAL(14,2)

BEGIN TRAN TR_CMR005
BEGIN TRY   
  		
SELECT @va_est_ado = va_est_ado,
       @va_cod_bod = va_cod_bod,
       @va_ges_tio = va_ges_vta
  FROM res001
WHERE va_ide_vta = @ar_ide_vta	AND
	  va_ges_vta = @ar_ges_vta
	  
IF @@ROWCOUNT = 0
BEGIN
	RAISERROR ('LA VENTA NO SE ENCUENTRA REGISTRADA',16,1)
	RETURN
END
IF @va_est_ado = 'N'
BEGIN
	RAISERROR ('LA VENTA YA SE ENCUENTRA ANULADA',16,1)
	RETURN
END
	
--// Cursor sobre temporal
DECLARE vc_det_vta CURSOR LOCAL FOR
SELECT va_itm_vta, va_cod_pro, va_can_uni
FROM res002
WHERE va_ide_vta = @ar_ide_vta	AND
	  va_ges_vta = @ar_ges_vta

	
--** Abre cursor		  
OPEN vc_det_vta    
	 
FETCH NEXT FROM vc_det_vta 
INTO @va_itm_vta, @va_cod_pro, @va_can_uni

WHILE (@@FETCH_STATUS = 0)
BEGIN
	
	-- Obtiene el codigo de familia
	SELECT @va_cod_fam = va_cod_fam
	FROM inv004
	WHERE va_cod_pro = @va_cod_pro
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_cod_fam = ''
	END
	
	-- Obtiene el tipo de familia
	SELECT @va_tip_fam = va_tip_fam
	FROM inv003
	WHERE va_cod_fam = @va_cod_fam
	
	IF @@ROWCOUNT = 0
	BEGIN
		SET @va_tip_fam = ''
	END
	
	IF @va_tip_fam = 'D'
	BEGIN
		---- Obtien saldo actual de inventario
		--SELECT @va_sal_can = va_sal_can
		--FROM inv101
		--WHERE va_cod_pro = @va_cod_pro
		--  AND va_cod_bod = @va_cod_bod
		
		--IF @@ROWCOUNT = 0
		--BEGIN
		--	SET @va_sal_can = 0
		--END
		
		----** Verifica que saldo existencia sea mayor que la cantidad de la venta
		--IF @va_can_uni > @va_sal_can 
		--BEGIN
		--	SET @msg = 'Item: ' + CAST(@va_itm_vta AS CHAR(01)) + ' :El producto ('+ @va_cod_pro +')  NO tiene existencia suficiente'
		--	RAISERROR (@msg,16,1)
		--	RETURN
		--END
		--** resta saldo existencia
		UPDATE inv099 SET va_sal_can = va_sal_can + @va_can_uni
		 WHERE va_cod_pro = @va_cod_pro 
		   AND va_cod_bod = @va_cod_bod
		   
		-- costea reingreso del producto
		
		-- si es al contado - anula Recibo de Ingreso por venta
		
		-- si es al credito - anula Registro CxC (si aun no tiene pagos reslizados)
		
		
		--SI ES FACTURA (ELIMINA REGISTRO DEBITO FISCAL)
	END
	
	--** elimina registro del kardex
	DELETE FROM inv100 WHERE va_ide_doc = @ar_ide_vta
					     AND va_cod_pro = @va_cod_pro
					     AND va_ges_tio = @va_ges_tio
   
 
FETCH NEXT FROM vc_det_vta 
INTO @va_itm_vta, @va_cod_pro, @va_can_uni
END
--** cambia estado encabezado venta
UPDATE res001 SET va_est_ado = 'N', 
				  va_usr_anu = SYSTEM_USER, -- @ar_ide_usr,
				  va_fec_anu = GETDATE()
 WHERE va_ide_vta = @ar_ide_vta	AND
	   va_ges_vta = @ar_ges_vta

CLOSE vc_det_vta
DEALLOCATE vc_det_vta


COMMIT TRAN TR_CMR005

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1) 
	Rollback TRAN TR_CMR005   
	RETURN
END CATCH	

RETURN (0)

GO  
/*
ARCHIVO: res001_05a_p01.sql
PROCEDIMIENTO: CONSULTA NOTA DE VENTA RESTAURANT
	(Formato = 0 ; en Undidad de Compra)
AUTOR:	CREARSIS(chl)
FECHA:	26-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.res001_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res001_05a_p01
GO

CREATE PROCEDURE res001_05a_p01 @ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
								@ar_ges_vta	INT	-- gestion de la compra
							 WITH ENCRYPTION AS
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
--@ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
--@ar_ges_vta	INT	,-- gestion de la compra
@msg			nvarchar(200),
@va_fec_vta		DATETIME,
@va_nro_vta		INT,
@va_cod_bod		CHAR(06),
@va_nom_bod		VARCHAR(50),			-- Numero de del documento
@va_for_pag		INT,	--Identificador de la venta (XXX|000-00000/2018)
@va_tip_cam		DECIMAL(4,2),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(80),
@va_mon_vta		CHAR(01),
@va_sub_toB		DECIMAL(16,5),
@va_sub_toU		DECIMAL(16,5),
@va_tot_bru		DECIMAL(16,5),
@va_dto_vtB		DECIMAL(16,5),
@va_dto_vtU		DECIMAL(16,5),
@va_des_cue		DECIMAL(16,5),
@va_tot_vtB		DECIMAL(16,5),
@va_tot_vtU		DECIMAL(16,5),
@va_tot_net		DECIMAL(16,5),
@va_obs_vta		VARCHAR(200),
@va_vta_par		CHAR(01)	,
@va_est_ado		CHAR(01),
@va_usr_reg		VARCHAR(15),
@va_fec_reg		DATETIME,
@va_itm_vta		INT,
@va_cod_pro		VARCHAR(15),
@va_des_pro		varchar(120)	,			--Descripcion del Producto 
@va_can_tid		DECIMAL(14,4),				--Cantidad de producto
@va_und_inv		CHAR(03)		,			--Numero de item 
@va_pre_uBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tot		DECIMAL(16,2),

@va_doc_vta     CHAR(03),					-- Documento de la operacion
@va_nro_tal     INT,						-- Nro de talonario de la operacion
@va_fir_ma1		VARCHAR(20),				--Firma del talonario 1
@va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
@va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
@va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
--@va_log_emp		VARBINARY(max),				--Logo de la empresa
@va_log_emp		NVARCHAR(100),				--Logo de la empresa
@va_for_log		TINYINT, 					--Formato de logo
											-- 0=Nombre de la empresa
											-- 1=logo 1
@va_cod_del		int,
@va_nom_del		varchar(30),
@va_cod_ven		INT,						--Codigo Vendedor
@va_nom_ven		VARCHAR(50),				--Nombre vendedor

@va_cod_plv		INT,						-- Plantilla de venta											
@va_tip_vta		INT,						-- Tipo de venta (1=factura ; 2=nota de venta)
@va_ref_vta		VARCHAR(20)

	

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_res001(
	va_fec_vta		DATETIME		NOT NULL,	--Codigo del usuario
	va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador compuesto para la venta
	va_ges_vta		INT				not null,	--Gestion de la venta 
	va_nro_vta		INT				NOT NULL,	--Nro venta
	va_cod_bod		char(06)		not null,	--Almacen
	va_nom_bod		VARCHAR(50)		not null,	--Nombre almacen
	va_for_pag		INT				NOT NULL,	-- Forma de Pago **
	va_tip_cam		DECIMAL(4,2)	NOT NULL,	--Tipo de cambio **
	va_cod_per		INT				not null,	--Codigo persona
	va_raz_soc		VARCHAR(80)		not null,	--Razon social
	va_mon_vta		CHAR(01)		not null,	--Numero de item 
	va_tot_bru		DECIMAL(16,5)	not null,	--Numero de item 
	va_des_cue		DECIMAL(16,5)	not null,	--Numero de item 
	va_tot_net		DECIMAL(16,5)	not null,	--Numero de item 
	va_obs_vta		VARCHAR(200)	not null,	--Numero de item 
	va_vta_par		CHAR(01)		not null,	--Venta para (M=Mesa; L=Llevar ; D=Delivery)
	
	
	va_est_ado		CHAR(01)		not null,	--Numero de item 
	va_usr_reg		VARCHAR(15)		NOT NULL,	--Usuario registro
	va_fec_reg		DATETIME		NOT NULL,	--Fecha de registro
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		not null,	--Numero de item 
	va_des_pro		varchar(120)	not null,	--Descripcion del Producto 
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_und_inv		CHAR(03)		not null,	--Numero de item 
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
    va_fir_ma1		VARCHAR(20),    		    --Firma del talonario 1
	va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
	va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
	va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
	va_for_log		TINYINT, 	                --Formato de logo
												-- 0=Nombre de la empresa
												-- 1=logo 1
	--va_log_emp		VARBINARY(max),				--Logo de la empresa
	va_cod_del		INT,
	va_nom_del		VARCHAR(30),
	va_cod_ven		INT,						--Codigo Vendedor
	va_nom_ven		VARCHAR(50),				--Nombre vendedor
	va_cod_plv		INT,						--Codigo plantilla de venta
	va_log_emp		NVARCHAR(100),				--Logo de la empresa
	va_ref_vta		VARCHAR(20),				--Referencia de la venta
	va_tip_vta		INT							--Tipo de venta (1=Factura ; 2=Nota de venta)
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_res001
BEGIN TRY
--SET @ar_ide_vta = 'VRS-000-000007'
--SET @ar_ges_vta = 2020
	-- Obtiene datos del encabezado
	SELECT @va_fec_vta = va_fec_vta, @va_nro_vta = va_nro_vta,
		   @va_cod_per = va_cod_per, @va_raz_soc = va_raz_soc,
		   @va_sub_toB = va_sub_toB, @va_sub_toU = va_sub_toU,
		   @va_dto_vtB = va_dto_vtB, @va_dto_vtU = va_dto_vtU,
		   @va_tot_vtB = va_tot_vtB, @va_tot_vtU = va_tot_vtU,
		   @va_cod_bod = va_cod_bod, @va_tip_cam = va_tip_cam,
		   @va_vta_par = va_vta_par,
		   @va_mon_vta = va_mon_vta, @va_for_pag = va_for_pag,
		   @va_usr_reg = va_usr_reg, @va_fec_reg = va_fec_reg,
		   @va_obs_vta = va_obs_vta, @va_est_ado = va_est_ado,
		   @va_doc_vta = va_doc_vta, @va_nro_tal = va_nro_tal,
		   @va_ref_vta = va_ref_vta, @va_cod_del = va_cod_del,
		   @va_cod_ven = va_cod_ven, @va_cod_plv = va_cod_plv,
		   @va_tip_vta = va_tip_vta
	FROM res001
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
	
	
	
	-- Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	FROM inv002
	WHERE va_cod_bod = @va_cod_bod
	
	
	-- Obtiene nombre del Delivery
	SELECT @va_nom_del = va_nom_del
	FROM cmr015
	WHERE va_cod_del = @va_cod_del
	
	-- Obtiene nombre del Vendedor
	SELECT @va_nom_ven = va_nom_ven
	FROM cmr014
	WHERE va_cod_ven = @va_cod_ven
	
	--Obtiene Totales segun moneda de la venta
	IF (@va_mon_vta = 'B')
	BEGIN
		SET @va_tot_bru = @va_sub_toB
		SET @va_des_cue = @va_dto_vtB
		SET @va_tot_net = @va_tot_vtB
	END
	IF (@va_mon_vta = 'U')
	BEGIN
		SET @va_tot_bru = @va_sub_toU
		SET @va_des_cue = @va_dto_vtU
		SET @va_tot_net = @va_tot_vtU
	END
	
	--// obtiene datos de Talonario
	SELECT @va_for_log = va_for_log,
		   @va_fir_ma1 = va_fir_ma1,
		   @va_fir_ma2 = va_fir_ma2,
		   @va_fir_ma3 = va_fir_ma3,
		   @va_fir_ma4 = va_fir_ma4
	 FROM ads004
	WHERE va_ide_doc = @va_doc_vta AND 
		  va_nro_tal = @va_nro_tal
	 IF @@ROWCOUNT = 0
	 BEGIN
		SET @va_for_log = 0
		SET @va_fir_ma1 = ''
		SET @va_fir_ma2 = ''
		SET @va_fir_ma3 = ''
		SET @va_fir_ma4 = ''
	 END
	 
	 IF @va_for_log = 1
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 12
	 END
	 IF @va_for_log = 2
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 13
	 END	
	 IF @va_for_log = 3
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 14
	 END	
	 IF @va_for_log = 4
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 15
	 END	
	 
	--// Cursor sobre Detalle
	DECLARE vc_res001 CURSOR LOCAL FOR
	SELECT va_itm_vta, va_cod_pro, va_des_pro, va_can_uni, va_und_inv,
		   (va_mto_brB - va_val_dtB), (va_mto_brU - va_val_dtU), va_mto_neB, va_mto_neU 
	 FROM res002 --WHERE va_ide_vta = 'VRS-000-000008'	
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
		
	--** Abre cursor		  
	OPEN vc_res001    
		 
	FETCH NEXT FROM vc_res001 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid, @va_und_inv,
								   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@va_mon_vta = 'B')
		BEGIN
			SET @va_pre_uni = @va_pre_uBs
			SET @va_pre_tot = @va_pre_tBs
		END
		IF (@va_mon_vta = 'U')
		BEGIN
			SET @va_pre_uni = @va_pre_uUs
			SET @va_pre_tot = @va_pre_tUs
		END
		
		
		--//** Obtiene nombre del producto de la tabla producto
		SELECT @va_des_pro = va_nom_pro
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro
		 
	----//** Obtiene nombre del delivery
	--	SELECT @va_nom_del = va_nom_del
	--	  FROM cmr010
	--	 WHERE va_cod_del = @va_cod_del
	
		INSERT INTO #tm_res001 VALUES ( @va_fec_vta		,
										@ar_ide_vta		,
										@ar_ges_vta		,
										@va_nro_vta		,
										@va_cod_bod		,
										@va_nom_bod		,
										@va_for_pag		,
										@va_tip_cam		,
										@va_cod_per		,
										@va_raz_soc		,
										@va_mon_vta		,
										@va_tot_bru		,
										@va_des_cue		,
										@va_tot_net		,
										@va_obs_vta		,
										@va_vta_par		,
										@va_est_ado		,
										@va_usr_reg		,
										@va_fec_reg		,
										@va_itm_vta		,
										@va_cod_pro		,
										@va_des_pro		,
										@va_can_tid		,
										@va_und_inv		,
										@va_pre_uni		,
										@va_pre_tot		,
										@va_fir_ma1		,
										@va_fir_ma2		,
										@va_fir_ma3		,
										@va_fir_ma4		,
										@va_for_log		,
										
										@va_cod_del		,
										@va_nom_del		,
										@va_cod_ven		,
										@va_nom_ven		,
										@va_cod_plv		,
										@va_log_emp		,
										@va_ref_vta		,
										@va_tip_vta		)
												
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de items en tabla temporal',16,1)
				RETURN
			END
	
		FETCH NEXT FROM vc_res001 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid,@va_und_inv,
									   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	END	
CLOSE vc_res001
DEALLOCATE vc_res001

SELECT * FROM #tm_res001

COMMIT TRAN TR_res001
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_res001
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: res001_05b_p01.sql
PROCEDIMIENTO: CONSULTA NOTA DE VENTA RESTAURANT
	(Formato = 0 ; en Undidad de Compra)
AUTOR:	CREARSIS(chl)
FECHA:	26-12-2018 
--*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.res001_05b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res001_05b_p01
GO

CREATE PROCEDURE res001_05b_p01 @ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
								@ar_ges_vta	INT				-- gestion de la compra
							 WITH ENCRYPTION AS
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
--@ar_ide_vta	NVARCHAR(20),	-- Identificador de la compra
--@ar_ges_vta	INT	,-- gestion de la compra
@msg			nvarchar(200),
@va_fec_vta		DATETIME,
@va_nro_vta		INT,
@va_cod_bod		CHAR(06),
@va_nom_bod		VARCHAR(50),			-- Numero de del documento
@va_for_pag		INT,	--Identificador de la venta (XXX|000-00000/2018)
@va_tip_cam		DECIMAL(4,2),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(80),
@va_mon_vta		CHAR(01),
@va_sub_toB		DECIMAL(16,5),
@va_sub_toU		DECIMAL(16,5),
@va_tot_bru		DECIMAL(16,5),
@va_dto_vtB		DECIMAL(16,5),
@va_dto_vtU		DECIMAL(16,5),
@va_des_cue		DECIMAL(16,5),
@va_tot_vtB		DECIMAL(16,5),
@va_tot_vtU		DECIMAL(16,5),
@va_tot_net		DECIMAL(16,5),
@va_obs_vta		VARCHAR(200),
@va_vta_par		CHAR(01)	,
@va_est_ado		CHAR(01),
@va_usr_reg		VARCHAR(15),
@va_fec_reg		DATETIME,
@va_itm_vta		INT,
@va_cod_pro		VARCHAR(15),
@va_nom_pro		varchar(80)	,				--Nombre del Producto 
@va_des_pro		varchar(300)	,			--Descripcion del Producto concatenados
@va_can_tid		DECIMAL(14,4),				--Cantidad de producto
@va_und_inv		CHAR(03)		,			--Numero de item 
@va_pre_uBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tBs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tUs		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
@va_pre_tot		DECIMAL(16,2),

@va_doc_vta     CHAR(03),					-- Documento de la operacion
@va_nro_tal     INT,						-- Nro de talonario de la operacion
@va_fir_ma1		VARCHAR(20),				--Firma del talonario 1
@va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
@va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
@va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
--@va_log_emp		VARBINARY(max),				--Logo de la empresa
@va_log_emp		NVARCHAR(100),				--Logo de la empresa
@va_for_log		TINYINT, 					--Formato de logo
											-- 0=Nombre de la empresa
											-- 1=logo 1
@va_ref_vta		VARCHAR(20)

	

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_res001(
	va_fec_vta		DATETIME		NOT NULL,	--Codigo del usuario
	va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador compuesto para la venta
	va_ges_vta		INT				not null,	--Gestion de la venta 
	va_nro_vta		INT				NOT NULL,	--Nro venta
	va_cod_bod		char(06)		not null,	--Almacen
	va_nom_bod		VARCHAR(50)		not null,	--Nombre almacen
	va_for_pag		INT				NOT NULL,	-- Forma de Pago **
	va_tip_cam		DECIMAL(4,2)	NOT NULL,	--Tipo de cambio **
	va_cod_per		INT				not null,	--Codigo persona
	va_raz_soc		VARCHAR(80)		not null,	--Razon social
	va_mon_vta		CHAR(01)		not null,	--Numero de item 
	va_tot_bru		DECIMAL(16,5)	not null,	--Numero de item 
	va_des_cue		DECIMAL(16,5)	not null,	--Numero de item 
	va_tot_net		DECIMAL(16,5)	not null,	--Numero de item 
	va_obs_vta		VARCHAR(200)	not null,	--Numero de item 
	va_vta_par		CHAR(01)		not null,	--Venta para (M=Mesa; L=Llevar ; D=Delivery)
	
	va_est_ado		CHAR(01)		not null,	--Numero de item 
	va_usr_reg		VARCHAR(15)		NOT NULL,	--Usuario registro
	va_fec_reg		DATETIME		NOT NULL,	--Fecha de registro
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		not null,	--Numero de item
	va_nom_pro		VARCHAR(80)		not null,	--Nombre del producto 
	va_des_pro		varchar(300)	not null,	--Nota del item para Producto 
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_und_inv		CHAR(03)		not null,	--Numero de item 
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_pre_tot		DECIMAL(16,2),				--Precio Total en la moneda del documento
    va_fir_ma1		VARCHAR(20),    		    --Firma del talonario 1
	va_fir_ma2		VARCHAR(20),				--Firma del talonario 2
	va_fir_ma3		VARCHAR(20),				--Firma del talonario 3
	va_fir_ma4		VARCHAR(20),				--Firma del talonario 4
	va_for_log		TINYINT, 	                --Formato de logo
												-- 0=Nombre de la empresa
												-- 1=logo 1
	--va_log_emp		VARBINARY(max),				--Logo de la empresa
	va_log_emp		NVARCHAR(100),				--Logo de la empresa
	va_ref_vta		VARCHAR(20)					--Referencia de la venta
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_res001
BEGIN TRY

	-- Obtiene datos del encabezado
	SELECT @va_fec_vta = va_fec_vta, @va_nro_vta = va_nro_vta,
		   @va_cod_per = va_cod_per, @va_raz_soc = va_raz_soc,
		   @va_sub_toB = va_sub_toB, @va_sub_toU = va_sub_toU,
		   @va_dto_vtB = va_dto_vtB, @va_dto_vtU = va_dto_vtU,
		   @va_tot_vtB = va_tot_vtB, @va_tot_vtU = va_tot_vtU,
		   @va_cod_bod = va_cod_bod, @va_tip_cam = va_tip_cam,
		   @va_vta_par = va_vta_par,
		   @va_mon_vta = va_mon_vta, @va_for_pag = va_for_pag,
		   @va_usr_reg = va_usr_reg, @va_fec_reg = va_fec_reg,
		   @va_obs_vta = va_obs_vta, @va_est_ado = va_est_ado,
		   @va_doc_vta = va_doc_vta, @va_nro_tal = va_nro_tal,
		   @va_ref_vta = va_ref_vta
	FROM res001
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
	--IF @@ROWCOUNT = 0
	--BEGIN
	--	RAISERROR ('El Documento de venta no se encuentra registrado',16,1)
	--	RETURN
	--END
	
	
	-- Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	FROM inv002
	WHERE va_cod_bod = @va_cod_bod
	--IF @@ROWCOUNT = 0
	--BEGIN
	--	RAISERROR ('La bodega no se encuentra registrada',16,1)
	--	RETURN
	--END

	--Obtiene Totales segun moneda de la venta
	IF (@va_mon_vta = 'B')
	BEGIN
		SET @va_tot_bru = @va_sub_toB
		SET @va_des_cue = @va_dto_vtB
		SET @va_tot_net = @va_tot_vtB
	END
	IF (@va_mon_vta = 'U')
	BEGIN
		SET @va_tot_bru = @va_sub_toU
		SET @va_des_cue = @va_dto_vtU
		SET @va_tot_net = @va_tot_vtU
	END
	
	--// obtiene datos de Talonario
	SELECT @va_for_log = va_for_log,
		   @va_fir_ma1 = va_fir_ma1,
		   @va_fir_ma2 = va_fir_ma2,
		   @va_fir_ma3 = va_fir_ma3,
		   @va_fir_ma4 = va_fir_ma4
	 FROM ads004
	WHERE va_ide_doc = @va_doc_vta AND 
		  va_nro_tal = @va_nro_tal
	 IF @@ROWCOUNT = 0
	 BEGIN
		SET @va_for_log = 0
		SET @va_fir_ma1 = ''
		SET @va_fir_ma2 = ''
		SET @va_fir_ma3 = ''
		SET @va_fir_ma4 = ''
	 END
	 
	 IF @va_for_log = 1
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 12
	 END
	 IF @va_for_log = 2
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 13
	 END	
	 IF @va_for_log = 3
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 14
	 END	
	 IF @va_for_log = 4
	 BEGIN
		SELECT @va_log_emp = va_glo_car
		 FROM ads013
		WHERE va_ide_mod = 1 AND
			  va_ide_glo = 15
	 END	
	 
	--// Cursor sobre Detalle
	DECLARE vc_res001 CURSOR LOCAL FOR
	SELECT va_itm_vta, va_cod_pro, va_des_pro, va_can_uni, va_und_inv,
		   (va_mto_brB - va_val_dtB), (va_mto_brU - va_val_dtU), va_mto_neB, va_mto_neU 
	 FROM res002 	
	WHERE va_ide_vta = @ar_ide_vta	AND
		  va_ges_vta = @ar_ges_vta
		
	--** Abre cursor		  
	OPEN vc_res001    
		 
	FETCH NEXT FROM vc_res001 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid, @va_und_inv,
								   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@va_mon_vta = 'B')
		BEGIN
			SET @va_pre_uni = @va_pre_uBs
			SET @va_pre_tot = @va_pre_tBs
		END
		IF (@va_mon_vta = 'U')
		BEGIN
			SET @va_pre_uni = @va_pre_uUs
			SET @va_pre_tot = @va_pre_tUs
		END
		
		
		--//** Obtiene nombre del producto de la tabla producto
		SELECT @va_nom_pro = va_nom_pro
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro
	
		--// Concatena Nombre + Nota del item
		--IF(@va_des_pro = '')
		--	SET @va_des_pro = @va_nom_pro
		--ELSE
		--	SET @va_des_pro = @va_nom_pro + CHAR(13) + CHAR(10) + '(' + @va_des_pro + ')'
		
		
		INSERT INTO #tm_res001 VALUES ( @va_fec_vta		,
										@ar_ide_vta		,
										@ar_ges_vta		,
										@va_nro_vta		,
										@va_cod_bod		,
										@va_nom_bod		,
										@va_for_pag		,
										@va_tip_cam		,
										@va_cod_per		,
										@va_raz_soc		,
										@va_mon_vta		,
										@va_tot_bru		,
										@va_des_cue		,
										@va_tot_net		,
										@va_obs_vta		,
										@va_vta_par		,
										@va_est_ado		,
										@va_usr_reg		,
										@va_fec_reg		,
										@va_itm_vta		,
										@va_cod_pro		,
										@va_nom_pro		,
										@va_des_pro		,
										@va_can_tid		,
										@va_und_inv		,
										@va_pre_uni		,
										@va_pre_tot		,
										@va_fir_ma1		,
										@va_fir_ma2		,
										@va_fir_ma3		,
										@va_fir_ma4		,
										@va_for_log		,
										@va_log_emp		,
										@va_ref_vta		)
												
			--IF @@ERROR <> 0
			--BEGIN
			--	RAISERROR ('Ocurrio un error al registrar detalle de items en tabla temporal',16,1)
			--	RETURN
			--END
	
		FETCH NEXT FROM vc_res001 INTO @va_itm_vta, @va_cod_pro, @va_des_pro, @va_can_tid,@va_und_inv,
									   @va_pre_uBs, @va_pre_uUs, @va_pre_tBs, @va_pre_tUs
	END	
CLOSE vc_res001
DEALLOCATE vc_res001

SELECT * FROM #tm_res001

COMMIT TRAN TR_res001
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_res001
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: res001_R01p.sql
PROCEDIMIENTO: REPORTE LISTADO DE VENTAS
AUTOR:	CREARSIS(chl)
FECHA:	27-01-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_R01p') and sysstat & 0xf = 4)
	drop procedure dbo.res001_R01p
GO

CREATE PROCEDURE res001_R01p @ar_cod_bod INT,			-- Almacen
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_est_ado CHAR(01),		-- Estado (T=todos ; H=valido ; N=anulado)
							@ar_tip_doc	INT				-- Tipo de documento (0=Ambos; 1=Factura; 2=Nota de Venta)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_cli_ini		INT,
@va_cli_fin		INT,
@va_bod_ini		INT,
@va_bod_fin		INT,
@va_nom_bod		VARCHAR(50)
--** CREA TABLA TEMPORAL
--CREATE TABLE #tm_vta005(
--	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
--	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
--	va_nro_itm		INT				not null,	--Numero de item 
--	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
--	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
--	va_und_vta		char(3)			null,		--Codigo de la Unidad de Medida
--	va_can_vta		DECIMAL(14,4),				--Cantidad de producto
--	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
--	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
--	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
--   )
   
IF @@ERROR <> 0
   RETURN

print 'EMPIEZA'
BEGIN TRY	 
SET @va_nom_bod = 'Todos';

IF (@ar_cod_bod = 0)
BEGIN	
	SET @va_bod_ini = 0
	SET @va_bod_fin = 9999999
END
IF (@ar_cod_bod <> 0)
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
	
	--Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @ar_cod_bod 
	
END

IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'



IF (@ar_tip_doc = 0)
BEGIN 
 SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, 
		@ar_cod_bod as va_cod_bod, @va_nom_bod as va_nom_bod, va_obs_vta
 FROM res001
 WHERE (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
  	   (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	    va_est_ado LIKE @ar_est_ado  
END
IF (@ar_tip_doc <> 0)
BEGIN 
 SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, 
		@ar_cod_bod as va_cod_bod, @va_nom_bod as va_nom_bod, va_obs_vta
 FROM res001
 WHERE (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
  	   (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	   (va_tip_vta = @ar_tip_doc) AND
	    va_est_ado LIKE @ar_est_ado  
END
	
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: res001_R02.sql
PROCEDIMIENTO: REPORTE VENTAS DE UN DELIVERY
AUTOR:	CREARSIS(chl)
FECHA:	11-10-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_R02') and sysstat & 0xf = 4)
	drop procedure dbo.res001_R02
GO

CREATE PROCEDURE res001_R02 @ar_cod_bod INT,			-- Bodega
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_cod_del	INT			-- Codigo delivery
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),

@va_fec_vta		DATETIME, 
@va_ide_vta		NVARCHAR(15), 
@va_nro_vta		INT, 
@va_cod_per		INT, 
@va_raz_soc		NVARCHAR(180),
@va_mon_vta		CHAR(01), 
@va_tot_vtB		DECIMAL(16,2), 
@va_tot_vtU		DECIMAL(16,2), 
@va_est_ado		CHAR(01), 
@va_ges_vta		INT, 
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(40),

@va_nom_del		VARCHAR(30),
@va_por_cen		INT,
@va_mto_cal		DECIMAL(16,2)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_res001(
	va_fec_vta		DATETIME, 
	va_ide_vta		NVARCHAR(15), 
	va_nro_vta		INT, 
	va_cod_per		INT, 
	va_raz_soc		NVARCHAR(180),
	va_mon_vta		CHAR(01), 
	va_tot_vtB		DECIMAL(16,2), 
	va_tot_vtU		DECIMAL(16,2), 
	va_est_ado		CHAR(01), 
	va_ges_vta		INT, 
	va_cod_bod		INT,
	va_nom_bod		VARCHAR(40),
	va_cod_del		INT,
	va_nom_del		VARCHAR(30),
	va_por_cen		INT,
	va_mto_cal		DECIMAL(16,2)
   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 

--// Cursor sobre temporal
DECLARE vc_res001 CURSOR LOCAL FOR
	SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		   va_mon_vta,va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, va_cod_bod 
	  FROM res001
	 WHERE(va_cod_bod = @ar_cod_bod)	AND
		  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
		  (va_cod_del = @ar_cod_del)	AND va_est_ado = 'V'

--** Abre cursor		  
OPEN vc_res001    
	 
FETCH NEXT FROM vc_res001 INTO @va_fec_vta, @va_ide_vta, @va_nro_vta, @va_cod_per, @va_raz_soc, @va_mon_vta, 
							   @va_tot_vtB, @va_tot_vtU, @va_est_ado, @va_ges_vta, @va_cod_bod 

WHILE (@@FETCH_STATUS = 0)
BEGIN
	--Obtiene nombre de Bodega
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @va_cod_bod
	 
	 --Obtiene nombre de Delivery
	SELECT @va_nom_del = va_nom_del,
		   @va_por_cen = va_por_del
	  FROM cmr015
	 WHERE va_cod_del = @ar_cod_del
	 
	 -- Calcula monto correspondiente al delivery segun su porcentaje
	 
	 SET @va_mto_cal = (@va_tot_vtB * @va_por_cen) / 100
	 
	 INSERT INTO #tm_res001 VALUES	(@va_fec_vta,
									@va_ide_vta	,
									@va_nro_vta	,
									@va_cod_per	,
									@va_raz_soc	,
									@va_mon_vta	,
									@va_tot_vtB	,
									@va_tot_vtU	,
									@va_est_ado	,
									@va_ges_vta	,
									@va_cod_bod	,
									@va_nom_bod	,
									@ar_cod_del	,
									@va_nom_del	,
									@va_por_cen	,
									@va_mto_cal
									)
	FETCH NEXT FROM vc_res001 INTO @va_fec_vta, @va_ide_vta, @va_nro_vta, @va_cod_per, @va_raz_soc, @va_mon_vta, 
							   @va_tot_vtB, @va_tot_vtU, @va_est_ado, @va_ges_vta, @va_cod_bod 

END	
CLOSE vc_res001
DEALLOCATE vc_res001

SELECT * FROM #tm_res001
ORDER BY va_fec_vta

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO  
/*
ARCHIVO: res001_R03.sql
PROCEDIMIENTO: REPORTE RESUMEN DE VENTAS POR DELIVERY
AUTOR:	CREARSIS(chl)
FECHA:	11-10-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_R03') and sysstat & 0xf = 4)
	drop procedure dbo.res001_R03
GO

CREATE PROCEDURE res001_R03 @ar_cod_bod INT,			-- Bodega
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_cod_de1	INT	,			-- Codigo delivery
							@ar_cod_de2	INT				-- Codigo delivery
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),

@va_fec_vta		DATETIME, 
@va_ide_vta		NVARCHAR(15), 
@va_nro_vta		INT, 
@va_cod_per		INT, 
@va_raz_soc		NVARCHAR(180),
@va_mon_vta		CHAR(01), 
@va_tot_vtB		DECIMAL(16,2), 
@va_tot_vtU		DECIMAL(16,2), 
@va_est_ado		CHAR(01), 
@va_ges_vta		INT, 
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(40),
@va_cod_del		INT	,
@va_nom_del		VARCHAR(30),
@va_por_cen		INT,
@va_mto_cal		DECIMAL(16,2)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_res001(
	va_cod_bod		INT,
	va_nom_bod		VARCHAR(40),
	va_tot_vtB		DECIMAL(16,2), 
	va_tot_vtU		DECIMAL(16,2), 
	va_mon_vta		CHAR(01), 
	va_cod_del		INT,
	va_nom_del		VARCHAR(30),
	va_por_cen		INT,
	va_mto_cal		DECIMAL(16,2)
   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 

--// Cursor sobre temporal
DECLARE vc_res001 CURSOR LOCAL FOR
	SELECT va_mon_vta,SUM(va_tot_vtB), SUM(va_tot_vtU), va_cod_bod, va_cod_del 
	  FROM res001
	 WHERE(va_cod_bod = @ar_cod_bod)	AND
		  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
		  (va_cod_del BETWEEN @ar_cod_de1 AND @ar_cod_de2) AND 
		  (va_cod_del <> 0 )	AND va_est_ado = 'V'
  GROUP BY va_cod_bod,va_cod_del,va_mon_vta
  
--** Abre cursor		  
OPEN vc_res001    
	 
FETCH NEXT FROM vc_res001 INTO @va_mon_vta,@va_tot_vtB, @va_tot_vtU, @va_cod_bod, @va_cod_del 

WHILE (@@FETCH_STATUS = 0)
BEGIN
	--Obtiene nombre de Bodega
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @va_cod_bod
	 
	 --Obtiene nombre de Delivery
	SELECT @va_nom_del = va_nom_del,
		   @va_por_cen = va_por_del
	  FROM cmr010
	 WHERE va_cod_del = @va_cod_del
	 
	 -- Calcula monto correspondiente al delivery segun su porcentaje
	 
	 SET @va_mto_cal = (@va_tot_vtB * @va_por_cen) / 100
	 
	 INSERT INTO #tm_res001 VALUES(	@va_cod_bod	,
									@va_nom_bod	,
									@va_tot_vtB	,
									@va_tot_vtU	,
									@va_mon_vta	,
									@va_cod_del	,
									@va_nom_del	,
									@va_por_cen	,
									@va_mto_cal
									)
	FETCH NEXT FROM vc_res001 INTO @va_mon_vta,@va_tot_vtB, @va_tot_vtU, @va_cod_bod, @va_cod_del 

END	
CLOSE vc_res001
DEALLOCATE vc_res001

SELECT * FROM #tm_res001
ORDER BY va_cod_bod, va_cod_del

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO
  
/*
ARCHIVO: res004_01a_p01.sql
PROCEDIMIENTO: BUSCA PLANTILLA DE VENTA RESTAURANT
	
AUTOR:	CREARSIS(CHL)
FECHA:	28-10-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res004_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res004_01a_p01
GO

CREATE PROCEDURE res004_01a_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01)		-- Estado (H = Habilitado, N=Deshabilitado)
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_plv		INT,
@va_nom_plv		NVARCHAR(30),
@va_des_plv		NVARCHAR(120),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_plv		INT,
va_nom_plv		NVARCHAR(30),
va_des_plv		NVARCHAR(120),
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'

IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_cod_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_nom_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_des_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
  
OPEN vc_pla_vta
FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	
	 INSERT INTO #resultado VALUES (@va_cod_plv		,
									@va_nom_plv		,
									@va_des_plv		,
									@va_est_ado	
									)
	
	
	FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado
END	

SELECT * FROM #resultado

CLOSE vc_pla_vta
DEALLOCATE vc_pla_vta

	
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
ARCHIVO: res004_01b_p01.sql
PROCEDIMIENTO: BUSCA PLANTILLA DE VENTA RESTAURANT
	CON PERMISOS PARA EL USUARIO
AUTOR:	CREARSIS(CHL)
FECHA:	28-10-2020 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res004_01b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res004_01b_p01
GO

CREATE PROCEDURE res004_01b_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01)		-- Estado (H = Habilitado, N=Deshabilitado)
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_plv		INT,
@va_nom_plv		NVARCHAR(30),
@va_des_plv		NVARCHAR(120),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_plv		INT,
va_nom_plv		NVARCHAR(30),
va_des_plv		NVARCHAR(120),
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'

IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_cod_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_nom_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_des_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
  
OPEN vc_pla_vta
FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	 SELECT @cout = COUNT(*)
	 FROM	ads008
	 WHERE	va_ide_usr = SYSTEM_USER	AND
			va_ide_tab = 'res004'		AND
			va_ide_uno = @va_cod_plv
	 
	IF @cout <> 0
	BEGIN 
	 INSERT INTO #resultado VALUES (@va_cod_plv		,
									@va_nom_plv		,
									@va_des_plv		,
									@va_est_ado	
									)
	END
	
	FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado
END	

SELECT * FROM #resultado

CLOSE vc_pla_vta
DEALLOCATE vc_pla_vta

	
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (l¡nea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO  
/*
AUTOR:	CREARSIS(chl)
FECHA:	27-01-2019 
--*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_R01p') and sysstat & 0xf = 4)
	drop procedure dbo.res001_R01p
GO

CREATE PROCEDURE res001_R01p			-- Tipo de documento (0=Ambos; 1=Factura; 2=Nota de Venta)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON


select * from res001
return
go

							
							  
