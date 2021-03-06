/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads007_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE USUARIOS
AUTOR:	CREARSIS(chl)
FECHA:	07-04-2020
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads007_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads007_R01
GO

CREATE PROCEDURE ads007_R01 @ag_est_ado CHAR(01)		-- Estado (T=todos ; H=Habilitado ; N=Deshabilitado)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)

IF @@ERROR <> 0
   RETURN


BEGIN TRY	 

IF (@ag_est_ado = 'T')
	SET @ag_est_ado = '%'


	 SELECT *
	   FROM ads007
	  WHERE va_est_ado LIKE @ag_est_ado  

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO