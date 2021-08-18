/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: adp002_01a_p02.sql
PROCEDIMIENTO: OBTIENE ULTIMO NUMERO DE PERSONA
			   EN EL GRUPO ESPESIFICADO
	
AUTOR:	CREARSIS(CHL)
FECHA:	19-09-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_01a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_01a_p02
GO

CREATE PROCEDURE adp002_01a_p02		@ar_cod_gru		INT			-- Codigo de grupo
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE
		@nro	INT 
 
SELECT @nro = MAX(va_cod_per) from adp002
WHERE va_cod_gru = @ar_cod_gru

SET @ar_cod_gru = @ar_cod_gru * 10000

SET @nro = @nro - @ar_cod_gru

IF(@nro IS nulL)
	SET @nro = 0

SELECT @nro AS va_ult_nro
IF @@ERROR <> 0
   RETURN
 
GO


