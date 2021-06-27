/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads003_04a_p1.sql
PROCEDIMIENTO: DESHABILITA DOCUMENTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_04a_p01
GO

CREATE PROCEDURE ads003_04a_p01	@ar_ide_doc		CHAR(03)		
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
	 
	 --/ Pregunta si tiene talonarios Habilitados ligados al documento que se quiere Deshabilitar
	 SELECT @va_can_tid = COUNT(*)
	  FROM ads004 
	 WHERE (va_ide_doc = @ar_ide_doc)
		AND (va_est_ado = 'H')

	--/ Procede a anular el documento
	IF(@va_can_tid = 0)
	BEGIN
		UPDATE ads003 SET va_est_ado = 'N'
		WHERE va_ide_doc = @ar_ide_doc
		
		-- Registrar bitacora
		--INSERT INTO
	END
	
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('No puede Deshabilitar, Existen Talonarios Habilitados relacionados con el documento' ,16,1)
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