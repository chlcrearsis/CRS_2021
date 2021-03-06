/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads007_03a_p01.sql
PROCEDIMIENTO: EDITA USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

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
@va_psw_usr	NVARCHAR(30),	-- Contraseña por defecto

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
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO