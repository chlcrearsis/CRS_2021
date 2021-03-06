/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads007_03d_p01.sql
PROCEDIMIENTO: CAMBIA TIPO DE USUARIO AL USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

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
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_ads008
	RETURN
END CATCH	

GO