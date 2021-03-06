/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads007_02a_p01.sql
PROCEDIMIENTO: REGISTRA USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	13-11-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

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
@va_psw_usr	NVARCHAR(30),	-- Contraseña por defecto

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

	--Obtiene contraseña por defecto de la global (1-1)
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
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO