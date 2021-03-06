/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads002_06a_p01.sql
PROCEDIMIENTO: ELIMINAR aplicacion
	
AUTOR:	CREARSIS(CHL)
FECHA:	06-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

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
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO