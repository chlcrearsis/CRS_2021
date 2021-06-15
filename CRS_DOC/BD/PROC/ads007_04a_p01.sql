/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads007_04a_p01.sql
PROCEDIMIENTO: HABILITA/DESHABILITA USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

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
@va_ide_usr		NVARCHAR(15)	-- Usuario registro
  
IF @@ERROR <> 0
   RETURN

BEGIN TRY   
	-- Verifica que el usuario siga registrado en la BD.
	SELECT @va_ide_usr = va_ide_usr
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
	PRINT 'HABILITADO...'
		UPDATE ads007 SET va_est_ado = 'H' 
		WHERE va_ide_usr = @ag_ide_usr 
	END	
	ELSE IF (@ag_est_ado = 'H')
	BEGIN
	PRINT 'Deshabilitando...'
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
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO