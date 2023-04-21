/*--**********************************************
ARCHIVO:	ads012.sql	
TABLA:		Tabla de "Restriccion Menú al Usuario"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		19-08-2022
*/--**********************************************

PRINT 'ads012 : Restriccion Menú al Usuario'
CREATE TABLE ads012
(
	--** Llave Primaria
	va_ide_usr  VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_nom_frm	VARCHAR(10)	 NOT NULL DEFAULT(0),	--** Nombre Formulario
	va_ide_men	VARCHAR(10)	 NOT NULL DEFAULT(0),	--** ID. Menu Formulario

CONSTRAINT pk1_ads012 PRIMARY KEY(va_ide_usr, va_nom_frm, va_ide_men)
)
GO