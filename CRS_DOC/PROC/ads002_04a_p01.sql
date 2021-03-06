/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads002_04a_p01.sql
PROCEDIMIENTO: HABILITA aplicacion
	
AUTOR:	CREARSIS(CHL)
FECHA:	06-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads002_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads002_04a_p01
GO

CREATE PROCEDURE ads002_04a_p01	@ar_ide_mod		INT ,
								@ar_ide_apl		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@va_est_mod			CHAR(01)	    --** Estado del modulo



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del modulo
	 SELECT @va_est_mod = va_est_ado
	  FROM ads001 
	 WHERE (va_ide_mod = @ar_ide_mod)
		

	--/ Si el modulo esta Deshabilitado, no se puede habilitar la aplicacion
	IF(@va_est_mod = 'N')
	BEGIN
		RAISERROR ('No puede Habilitar la aplicacion si el modulo esta Deshabilitado' ,16,1)
		RETURN
	END
	
	IF(@va_est_mod = 'H')
	BEGIN
		UPDATE ads002 SET va_est_ado = 'H'
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