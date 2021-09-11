/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads010_06a_p01.sql
PROCEDIMIENTO: ELIMINA TIPO IMAGEN
	
AUTOR:	CREARSIS(FVM)
FECHA:	10-09-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads010_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads010_06a_p01
GO

CREATE PROCEDURE ads010_06a_p01	@ar_ide_tip		INT		
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
	 
	 --/ Pregunta si tiene Aplicaciones ligadas al documento que se quiere Deshabilitar
	 /*SELECT @va_can_tid = COUNT(*)
	   FROM ads002 
	  WHERE (va_ide_mod = @ar_ide_tip)*/

	--/ Procede a Eliminar el Modulo
	IF(@va_can_tid = 0)
	BEGIN
		DELETE ads010 
		WHERE va_ide_tip = @ar_ide_tip
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Eliminar el Tipo de Imagen, Existen Aplicaciones relacionadas con el mismo' ,16,1)
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