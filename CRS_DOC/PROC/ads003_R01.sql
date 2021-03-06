/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads003_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE DOCUMENTOS
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_R01
GO

CREATE PROCEDURE ads003_R01	@ar_ide_mod		INT,
							@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 --/ Inicializa variable contador de registro
	IF(@ar_est_ado = 'T')
		SET @va_est_ado = '%'
	IF(@ar_est_ado <> 'T')
		SET @va_est_ado = @ar_est_ado
		
		PRINT @ar_est_ado
		PRINT @va_est_ado
		
		
		 
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,
            ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado
	  FROM	ads003 , ads001
	 WHERE (ads003.va_ide_mod = ads001.va_ide_mod)
	   AND (ads001.va_ide_mod = @ar_ide_mod)
	   AND (ads003.va_est_ado LIKE @va_est_ado)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO