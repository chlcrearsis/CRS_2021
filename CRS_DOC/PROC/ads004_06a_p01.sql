/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads004_06a_p01.sql
PROCEDIMIENTO: ELIMINAR TALONARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	19-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_06a_p01
GO

CREATE PROCEDURE ads004_06a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@count				INT,
@va_est_doc			CHAR(01)	    --** Estado del documento



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del documento
	 SELECT @count = COUNT(*)
	  FROM ads005
	 WHERE (va_ide_doc = @ar_ide_doc)
	   AND (va_nro_tal = @ar_nro_tal)
		
	--/ revisa si tiene documentos registrados en el historial
	--
	--
	
	
	IF(@count > 0)
	BEGIN
		RAISERROR ('No puede Elminiar el talonario, Revise la numeracion' ,16,1)
		RETURN
	END
	
	IF(@count = 0)
	BEGIN
		DELETE ads004
		WHERE va_ide_doc = @ar_ide_doc AND va_nro_tal = @ar_nro_tal
		
		DELETE ads005
		WHERE va_ide_doc = @ar_ide_doc AND va_nro_tal = @ar_nro_tal
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