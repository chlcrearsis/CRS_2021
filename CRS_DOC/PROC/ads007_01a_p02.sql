/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads007_01a_p02.sql
PROCEDIMIENTO: VERIFICA CONCURRENCIA USUARIO
			   PARA EDITAR INFORMACION
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

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
	ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), 
	ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_ads007
	RETURN
END CATCH	

GO