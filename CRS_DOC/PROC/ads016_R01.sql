/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads016_R01.sql
PROCEDIMIENTO: PERIODOS DE UNA GESTION
	
AUTOR:	CREARSIS(CHL)
FECHA:	31-03-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_R01
GO

CREATE PROCEDURE ads016_R01
							@ag_ges_tio	INT			
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

	SELECT *
	FROM ads016
	WHERE va_ges_tio = @ag_ges_tio
	
GO
	