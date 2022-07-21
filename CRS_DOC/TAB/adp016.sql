/*--************************************************************************
ARCHIVO:	adp016.sql	
TABLA:		Tabla de "Inscripción Automatica Libreta p/Grupo de Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		08-11-2021
*/--************************************************************************

PRINT 'adp016 : Inscripción Automatica Libreta p/Grupo de Persona'	
CREATE TABLE adp016 
(
	--** Llave Primaria
	va_cod_gru	INT	NOT NULL DEFAULT(0),	--** Codigo de Grupo de persona
	va_cod_lib	INT	NOT NULL DEFAULT(0),	--** Código de la Libreta

CONSTRAINT pk1_adp016 PRIMARY KEY(va_cod_gru, va_cod_lib)
)
GO