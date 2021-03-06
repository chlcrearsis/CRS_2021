/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads000_01a_p01.sql
PROCEDIMIENTO: VERIFICA USUARIO EN EL SISTEMA
	CON PERMISOS PARA EL USUARIO
AUTOR:	CREARSIS(JEJR)
FECHA:	07-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads000_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads000_01a_p01
GO

CREATE PROCEDURE ads000_01a_p01		@ar_ide_usr	 CHAR(15),	-- ID. Usuario
									@ar_pas_usr	 CHAR(30)	-- Contraseña
									WITH ENCRYPTION AS

DECLARE		@va_per_rol  INT,			--** Permiso sobre Rol
			@va_est_ado  CHAR(01),		--** Estado (H=Habilitado; N=Deshabilitado)
			@va_cod_err  INT,			--** Código de Error
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
	SET @va_msn_err = 'NO existe ningún Inicio de Sesion con ese nombre en el Servidor.'
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
		SET @va_msn_err = 'NO Existe ningún Inicio de Sesion con ese nombre en la Base de Datos.'
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
	    SET @va_msn_err = 'NO Existe ningún Usuario con ese nombre en el Sistema.'
		SET @va_cod_err = 105
	END

	IF (@va_est_ado = 'N' AND @va_cod_err = 0)
	BEGIN
	    SET @va_msn_err = 'El Usuario NO está habilitado para ingresar al Sistema.'
		SET @va_cod_err = 106
	END
END



/* Devuelve Datos del Usuario */
SELECT @va_cod_err AS va_cod_err,
       @va_msn_err AS va_msn_err

GO