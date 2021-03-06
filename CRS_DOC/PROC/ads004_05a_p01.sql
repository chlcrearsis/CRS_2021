/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads004_05a_p01.sql
PROCEDIMIENTO: CONSULTA TALONARIO
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_05a_p01
GO

CREATE PROCEDURE ads004_05a_p01	@ar_ide_doc		CHAR(03),
								@ar_nro_tal		INT		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 --/ Pregunta si tiene talonarios Habilitados ligados al documento que se quiere Deshabilitar
	 SELECT ads001.va_ide_mod, ads001.va_nom_mod, ads004.va_ide_doc, ads003.va_nom_doc,
			ads004.va_nro_tal, ads004.va_nom_tal, ads004.va_tip_tal, ads004.va_nro_aut,
			ads004.va_for_mat, ads004.va_nro_cop, ads004.va_fir_ma1, ads004.va_fir_ma2,
			ads004.va_fir_ma3, ads004.va_fir_ma4, ads004.va_for_log, ads004.va_est_ado
	  FROM ads004, ads003, ads001
	 WHERE (ADS001.va_ide_mod = ADS003.va_ide_mod)
	   AND (ADS003.va_ide_doc = ADS004.va_ide_doc)
	   AND (ads004.va_ide_doc = @ar_ide_doc)
	   AND (ads004.va_nro_tal = @ar_nro_tal)

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO