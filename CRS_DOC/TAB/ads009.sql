/*--**********************************************
ARCHIVO:	ads009.sql	
TABLA:		Tabla de "Autorizaciones de Tipo de Usuario sobre el Sistema"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		26-07-2021
*/--**********************************************

PRINT 'ads009 : Autorizaciones de Tipo de Usuario sobre el Sistema'
CREATE TABLE ads009
(
	--** Llave Primaria
	va_ide_tus 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_ide_tab	VARCHAR(06)  NOT NULL DEFAULT(''),	--** ID. Tabla
	va_ide_uno	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Uno
	va_ide_dos	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Dos
	va_ide_tre	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Tres
	--** Atributos
	va_ide_int	INT	         NOT NULL DEFAULT(0),	--** Identificador Entero

CONSTRAINT pk1_ads009 PRIMARY KEY(va_ide_tus, va_ide_tab, va_ide_uno,
                                  va_ide_dos, va_ide_tre)
)
GO