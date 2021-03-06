/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads001_04a_p01.sql
PROCEDIMIENTO: DESHABILITA MODULO
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-07-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads001_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads001_04a_p01
GO

CREATE PROCEDURE ads001_04a_p01	@ar_ide_mod		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT	--** Cantidad de registros encontrados


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	 SET @va_can_tid = 0;
	 
	 --/ Pregunta si tiene Aplicaciones Habilitadas ligados al documento que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	   FROM ads002 
	  WHERE (va_ide_mod = @ar_ide_mod)
		AND (va_est_ado = 'H')

	--/ Procede a deshabilitar el Modulo
	IF(@va_can_tid = 0)
	BEGIN
		UPDATE ads001 SET va_est_ado = 'N'
		WHERE va_ide_mod = @ar_ide_mod
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Deshabilitar, Existen Aplicaciones Habilitadas relacionadas con el Modulo' ,16,1)
		RETURN
	END
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO