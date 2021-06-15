/*
AUTOR:	CREARSIS(chl)
FECHA:	27-01-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_R01p') and sysstat & 0xf = 4)
	drop procedure dbo.res001_R01p
GO

CREATE PROCEDURE res001_R01p			-- Tipo de documento (0=Ambos; 1=Factura; 2=Nota de Venta)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON


select * from res001
return
go

							
							