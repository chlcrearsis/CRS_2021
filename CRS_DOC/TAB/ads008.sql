/*--**********************************************
ARCHIVO:	ads008.sql	
TABLA:		Tabla de "Autorización Usuario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-10-2020
*/--**********************************************

PRINT 'ads008 : Autorizaciones Usuario'
CREATE TABLE ads008
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_ide_tab	VARCHAR(06)  NOT NULL DEFAULT(''),	--** ID. Tabla
	va_ide_uno	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Uno
	va_ide_dos	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Dos
	va_ide_tre	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Tres
	--** Atributos
	va_ide_int	INT	         NOT NULL DEFAULT(0),	--** Identificador Entero

CONSTRAINT pk1_ads008 PRIMARY KEY(va_ide_usr, va_ide_tab, va_ide_uno, 
                                  va_ide_dos, va_ide_tre)
)
GO