/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads003_05a_p01.sql
PROCEDIMIENTO: CONSULTA DOCUMENTO
	
AUTOR:	CREARSIS(CHL)
FECHA:	14-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads003_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads003_05a_p01
GO

CREATE PROCEDURE ads003_05a_p01	@ar_ide_doc		CHAR(03)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,
            ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado
	  FROM	ads003 , ads001
	 WHERE (ads003.va_ide_doc = @ar_ide_doc)
	   AND (ads003.va_ide_mod = ads001.va_ide_mod)
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO