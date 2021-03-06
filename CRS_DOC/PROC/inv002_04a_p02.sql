/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv002_04a_p02.sql
PROCEDIMIENTO: DESHABILITA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_04a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_04a_p02
GO

CREATE PROCEDURE inv002_04a_p02	@ar_ide_gru		INT	,
								@ar_cod_bod		INT
										
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	
	UPDATE inv002 SET va_est_ado = 'N'
	WHERE va_cod_bod = @ar_cod_bod AND va_ide_gru = @ar_ide_gru

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO