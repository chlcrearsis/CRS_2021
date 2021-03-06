/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv002_04a_p01.sql
PROCEDIMIENTO: HABILITA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_04a_p01
GO

CREATE PROCEDURE inv002_04a_p01	@ar_ide_gru		INT	,
								@ar_cod_bod		INT
									
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@va_est_gru			CHAR(01)	    --** Estado del Grupo



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Obtiene el estado del Grupo
	 SELECT @va_est_gru = va_est_ado
	  FROM inv001 
	 WHERE (va_ide_gru = @ar_ide_gru)
		

	--/ Si el Grupo esta Deshabilitado, no se puede habilitar la bodega
	IF(@va_est_gru = 'N')
	BEGIN
		RAISERROR ('No puede Habilitar la bodega si el Grupo esta Deshabilitado' ,16,1)
		RETURN
	END
	
	IF(@va_est_gru = 'H')
	BEGIN
		UPDATE inv002 SET va_est_ado = 'H'
		WHERE va_cod_bod = @ar_cod_bod AND va_ide_gru = @ar_ide_gru
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