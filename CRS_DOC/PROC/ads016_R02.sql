/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads016_R02.sql
PROCEDIMIENTO: LISTA DE GESTIONES
	
AUTOR:	CREARSIS(CHL)
FECHA:	02-04-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads016_R02') and sysstat & 0xf = 4)
	drop procedure dbo.ads016_R02
GO

CREATE PROCEDURE ads016_R02		
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

	SELECT *
	FROM ads016
	
GO
	