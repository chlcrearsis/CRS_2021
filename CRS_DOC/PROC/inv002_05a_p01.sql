/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv002_05a_p01.sql
PROCEDIMIENTO: CONSULTA BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	16-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_05a_p01
GO

CREATE PROCEDURE inv002_05a_p01	@ar_cod_bod		INT	
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT inv001.va_ide_gru, inv001.va_nom_gru, inv002.va_cod_bod, inv002.va_nom_bod,
			inv002.va_des_bod, inv002.va_dir_bod, inv002.va_fec_ctr, inv002.va_mon_inv,
			inv002.va_mtd_cto, inv002.va_nom_ecg, inv002.va_tlf_ecg, inv002.va_dir_ecg,inv002.va_est_ado
	  FROM inv002, inv001
	 WHERE (inv001.va_ide_gru = inv002.va_ide_gru)
		   AND (inv002.va_cod_bod = @ar_cod_bod)

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO