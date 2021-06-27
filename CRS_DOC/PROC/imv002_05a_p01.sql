/*????????????????????????????????????????????????
ARCHIVO: inv002_05a_p01.sql
PROCEDIMIENTO: CONSULTA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--????????????????????????????????????????????????*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_05a_p01
GO

CREATE PROCEDURE inv002_05a_p01	@ar_ide_bod		CHAR(03),
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
	 SELECT inv001.va_ide_gru, inv001.va_nom_gru, inv002.va_ide_bod, ads003.va_nom_doc,
			inv002.va_nro_tal, inv002.va_nom_tal, inv002.va_tip_tal, inv002.va_nro_aut,
			inv002.va_for_mat, inv002.va_nro_cop, inv002.va_fir_ma1, inv002.va_fir_ma2,
			inv002.va_fir_ma3, inv002.va_fir_ma4, inv002.va_for_log, inv002.va_est_ado
	  FROM inv002, ads003, inv001
	 WHERE (inv001.va_ide_gru = ADS003.va_ide_gru)
	   AND (ADS003.va_ide_bod = inv002.va_ide_bod)
	   AND (inv002.va_ide_bod = @ar_ide_bod)
	   AND (inv002.va_nro_tal = @ar_nro_tal)

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO