/*--**********************************************
ARCHIVO:	adp009.sql	
TABLA:		Tabla de "Permiso Lista de Precio p/Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		03-01-2018
*/--**********************************************

CREATE TABLE adp009 
(
	--** Llave Primaria
	va_cod_per  INT	NOT NULL DEFAULT(0),  --** Codigo Persona
	va_cod_lis	INT	NOT NULL DEFAULT(0),  --** Codigo del la lista

CONSTRAINT pk1_adp009 PRIMARY KEY(va_cod_per, va_cod_lis)
)
GO
