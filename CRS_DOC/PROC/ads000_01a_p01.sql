/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads000_01b_p01.sql
PROCEDIMIENTO: VERIFICA USUARIO EN EL SISTEMA
	CON PERMISOS PARA EL USUARIO
AUTOR:	CREARSIS(JEJR)
FECHA:	07-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads000_01b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads000_01b_p01
GO

CREATE PROCEDURE ads000_01b_p01		@ar_ide_usr	 CHAR(15),	-- ID. Usuario
									@ar_pas_usr	 CHAR(30)	-- Contraseña
									WITH ENCRYPTION AS

DECLARE		@va_per_rol  INT,		--** Permiso sobre Rol
			@va_est_ado  CHAR(01)	--** Estado (H=Habilitado; N=Deshabilitado)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
       
--** Verifica que exista el usuario en Seguridad > Inicio de Sesion
IF NOT EXISTS
  (SELECT name  
     FROM master.sys.server_principals
     WHERE name = @ar_ide_usr)
BEGIN
    RAISERROR('ERROR 100: NO existe ningún Inicio de Sesion con ese nombre en el Servidor.', 16, 1)
	RETURN
END

--** Verifica que exista el usuario en la {Base de Datos}{Seguridad}{Usuarios}
IF NOT EXISTS
  (SELECT name  
     FROM master.sys.server_principals
     WHERE name = @ar_ide_usr)
BEGIN
    RAISERROR('ERROR 101: NO Existe ningún Inicio de Sesion con ese nombre en la Base de Datos.', 16, 1)
	RETURN
END

--** Verifica si tiene adicionado el rol 'dbcreator'
SET @va_per_rol = 0
SET @va_per_rol = IS_SRVROLEMEMBER('dbcreator', RTRIM(@ar_ide_usr))
IF (@va_per_rol = 0)
BEGIN
	RAISERROR('ERROR 102: El Inicio de Sesion NO tiene permiso sobre el rol (dbcreator). Consulte con su Administrador', 16, 1)
	RETURN
END

--** Verifica si tiene adicionado el rol 'sysadmin'
SET @va_per_rol = 0
SET @va_per_rol = IS_SRVROLEMEMBER('sysadmin', RTRIM(@ar_ide_usr))
IF (@va_per_rol = 0)
BEGIN
	RAISERROR('ERROR 103: El Inicio de Sesion NO tiene permiso sobre el rol (sysadmin). Consulte con su Administrador', 16, 1)
	RETURN
END

--** Verifica si tiene adicionado el rol 'serveradmin'
SET @va_per_rol = 0
SET @va_per_rol = IS_SRVROLEMEMBER('serveradmin', RTRIM(@ar_ide_usr))
IF (@va_per_rol = 0)
BEGIN
	RAISERROR('ERROR 104: El Inicio de Sesion NO tiene permiso sobre el rol (serveradmin). Consulte con su Administrador', 16, 1)
	RETURN
END

--** Verificar si existe el usuario creado en la tabla ads007
SET @va_est_ado = ''
SELECT @va_est_ado = va_est_ado 
  FROM ads007
 WHERE va_ide_usr = RTRIM(@ar_ide_usr)

IF (@@ROWCOUNT = 0)
BEGIN
    RAISERROR('ERROR 105: NO Existe ningún Usuario con ese nombre en el Sistema.', 16, 1)
	RETURN
END

IF (@va_est_ado = 'N')
BEGIN
    RAISERROR('ERROR 106: El Usuario NO está habilitado para ingresar al Sistema.', 16, 1)
	RETURN
END

/* Devuelve Datos del Usuario */
SELECT va_ide_usr, va_nom_usr, va_tel_usr,
	   va_car_usr, va_dir_ect, va_ema_usr,
       va_win_max, va_ide_per, va_tip_usr,
       va_est_ado
  FROM ads007
 WHERE va_ide_usr = RTRIM(@ar_ide_usr)
GO