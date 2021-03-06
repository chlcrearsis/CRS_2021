/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads002_05a_p01.sql
PROCEDIMIENTO: CONSULTA APLICACION
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-07-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads002_05a_p01
GO

CREATE PROCEDURE ads002_05a_p01	@ar_ide_apl		CHAR(06)	
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_ide_mod		INT


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 -- Obtiene modulo de la aplicacion
	 SELECT @va_ide_mod = va_ide_mod
	   FROM ads002
	  WHERE va_ide_apl = @ar_ide_apl
	  
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl, 
			ads002.va_nom_apl, ads002.va_est_ado
	  FROM ads002, ads001
	 WHERE (ADS001.va_ide_mod = ads001.va_ide_mod)
	   AND (ads001.va_ide_mod = @va_ide_mod)
	   AND (ads002.va_ide_apl = @ar_ide_apl)

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO