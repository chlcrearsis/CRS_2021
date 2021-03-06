/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads006_06a_p01.sql
PROCEDIMIENTO: ELIMINA TIPO DE USUARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-07-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads006_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads006_06a_p01
GO

CREATE PROCEDURE ads006_06a_p01	@ar_ide_tus		INT		
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
	 
	 --/ Pregunta si tiene Usuarios ligados al Tipo de Usuario que se quiere Eliminar
	 SELECT @va_can_tid = COUNT(*)
	   FROM ads007 
	  WHERE (va_tip_usr = @ar_ide_tus)

	--/ Procede a Eliminar el Tipo de usuario
	IF(@va_can_tid = 0)
	BEGIN
		DELETE ads006 
		WHERE va_ide_tus = @ar_ide_tus
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Eliminar el Tipo de usuario, Existen Usuarios relacionados con el mismo' ,16,1)
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