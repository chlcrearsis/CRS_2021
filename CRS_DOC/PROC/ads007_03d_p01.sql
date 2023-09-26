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

CREATE PROCEDURE ads007_03d_p01		@ag_ide_usr VARCHAR(15),
							        @ag_tus_nue	INT		WITH ENCRYPTION AS

DECLARE		@va_est_ado  CHAR(01),	    --** Estado (H=habilitado ; N=Deshabilitado)
            @va_tus_act  INT,			--** Tipo de usuario actual
			@va_est_tus  CHAR(01),	    --** Estado Tipo de Usuario (H=habilitado ; N=Deshabilitado)
            @va_msn_err  NVARCHAR(200)  --** Mensaje de Error


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
  
BEGIN TRANSACTION 
	--** Verifica que exista el usuario creado y Habilitado
	SELECT @va_est_ado = va_est_ado,
	       @va_tus_act = va_ide_tus
	  FROM ads007
	 WHERE va_ide_usr = @ag_ide_usr

	IF (@@ROWCOUNT = 0)
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
	    ROLLBACK TRANSACTION 
		RAISERROR('Error al actualizar datos del Usuario (ads007)', 16, 1)
		RETURN
	END

	--** ELIMINA LOS PERMISOS DEL USUARIO
	DELETE ads008 WHERE va_ide_usr = @ag_ide_usr

	IF (@@ERROR > 0)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('Error al eliminar los permisos autorizados al Usuario (ads008)', 16, 1)
		RETURN
	END
	
	--** COPIA LOS PERMISOS DEL TIPO DE USUARIO AL USUARIO
	INSERT INTO ads008
	SELECT @ag_ide_usr, va_ide_tab, va_ide_uno, 
	       va_ide_dos,  va_ide_tre, va_ide_int
	  FROM ads009
	 WHERE va_ide_tus = @ag_tus_nue

	IF (@@ERROR > 0)
	BEGIN
	    ROLLBACK TRANSACTION 
		RAISERROR('Error al insertar los permisos al Usuario (ads009)', 16, 1)
		RETURN
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