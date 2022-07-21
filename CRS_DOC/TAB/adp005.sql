/*--**********************************************
ARCHIVO:	adp005.sql	
TABLA:		Tabla de "Atributos por persona"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp005 : Atributos por persona'
CREATE TABLE adp005 
(
	--** Llave Primaria
	va_cod_per	INT			 NOT NULL DEFAULT(0),	--** Codigo Persona
	va_ide_tip	INT			 NOT NULL DEFAULT(0),	--** ID. tipo de atributo
	va_ide_atr	INT			 NOT NULL DEFAULT(0),	--** ID. Atributo

CONSTRAINT pk1_adp005 PRIMARY KEY(va_cod_per, va_ide_tip, va_ide_atr)
)
GO
