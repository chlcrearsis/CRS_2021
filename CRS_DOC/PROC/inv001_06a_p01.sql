/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv001_06a_p01.sql
PROCEDIMIENTO: ELIMINA GRUPO DE BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-07-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv001_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv001_06a_p01
GO

CREATE PROCEDURE inv001_06a_p01	@ar_ide_gru		CHAR(03)		
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
	 
	 --/ Pregunta si tiene Bodegas ligados al Grupo de Bodega que se quiere Deshabilitar
	 --SELECT @va_can_tid = COUNT(*)
	 -- FROM inv002 
	 --WHERE (va_ide_gru = @ar_ide_gru)

	--/ Procede a anular el Grupo de Bodega
	IF(@va_can_tid = 0)
	BEGIN
		DELETE inv001
		WHERE va_ide_gru = @ar_ide_gru
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede eliminar, Existen Bodegas relacionadas con el Grupo de Bodega' ,16,1)
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