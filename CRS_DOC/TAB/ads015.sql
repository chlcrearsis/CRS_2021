/*--**********************************************
ARCHIVO:	ads015.sql	
TABLA:		Tabla de "?"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads015 : ?'
CREATE TABLE ads015
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo (ads001)
	--** Atributos

CONSTRAINT pk1_ads015 PRIMARY KEY(va_ide_mod)
)
GO
