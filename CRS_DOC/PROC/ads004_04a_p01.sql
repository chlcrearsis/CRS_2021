/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads004_04a_p01.sql
PROCEDIMIENTO: HABILITA TALONARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_04a_p01
GO

CREATE PROCEDURE ads004_04a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@va_est_doc			CHAR(01)	    --** Estado del documento



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del documento
	 SELECT @va_est_doc = va_est_ado
	  FROM ads003 
	 WHERE (va_ide_doc = @ar_ide_doc)
		

	--/ Si el documento esta Deshabilitado, no se puede habilitar el talonario
	IF(@va_est_doc = 'N')
	BEGIN
		RAISERROR ('No puede Habilitar el talonario si el Documento esta Deshabilitado' ,16,1)
		RETURN
	END
	
	IF(@va_est_doc = 'H')
	BEGIN
		UPDATE ads004 SET va_est_ado = 'H'
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