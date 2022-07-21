/*--**********************************************
ARCHIVO:	adp008.sql	
TABLA:		Tabla de "Rutas p/Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		03-01-2018
*/--**********************************************

PRINT 'adp008 : Rutas p/Persona'
CREATE TABLE adp008 
(
	--** Llave Primaria
	va_cod_per  INT	NOT NULL DEFAULT(0),  --** Codigo Persona
	va_ide_rut	INT	NOT NULL DEFAULT(0)   --** ID. Ruta

CONSTRAINT pk1_adp008 PRIMARY KEY(va_cod_per, va_ide_rut)
)
GO




