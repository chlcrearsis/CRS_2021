/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv001_05a_p01.sql
PROCEDIMIENTO: CONSULTA GRUPO DE BODEGAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv001_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv001_05a_p01
GO

CREATE PROCEDURE inv001_05a_p01	@ar_ide_gru		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT inv001.va_ide_gru,
            inv001.va_nom_gru, inv001.va_des_gru, inv001.va_est_ado
	  FROM	inv001 
	 WHERE (inv001.va_ide_gru = @ar_ide_gru)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO