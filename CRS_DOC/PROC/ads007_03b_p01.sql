/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads007_03b_p01.sql
PROCEDIMIENTO: EDITA CONTRASEÑA USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-11-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_03b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_03b_p01
GO

CREATE PROCEDURE ads007_03b_p01
							@ag_ide_usr NVARCHAR(15),	-- Usuario registro
							@ag_new_pss	NVARCHAR(30)	-- Nueva contraseña
							
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
		RAISERROR('No pudo ser cambiada la contraseña.', 16, 1)

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