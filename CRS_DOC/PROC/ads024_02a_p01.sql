/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads024_02a_p01.sql
PROCEDIMIENTO: BITACORA DE INICIO DE SESION
AUTOR:	CREARSIS(JEJR)
FECHA:	28-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads024_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads024_02a_p01
GO

CREATE PROCEDURE ads024_02a_p01		@ag_ide_uni  CHAR(32) 	WITH ENCRYPTION AS

DECLARE		@va_fec_fin  DATETIME,      --** Fecha y Hora de Salida
			@va_nro_reg  INT            --** Nro. Registro


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable


IF (@ag_ide_uni <> '')
BEGIN
	SELECT @va_fec_fin = va_fec_fin
	  FROM ads024
	 WHERE va_ide_uni = @ag_ide_uni

	IF (@@ROWCOUNT = 1 AND @va_fec_fin IS NULL)
	BEGIN
		SET @va_fec_fin = GETDATE()
		UPDATE ads024 SET va_fec_fin = @va_fec_fin
		            WHERE va_ide_uni = @ag_ide_uni
	END
END

GO