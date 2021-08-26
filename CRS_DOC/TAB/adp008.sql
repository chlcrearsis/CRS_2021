/*--**********************************************
ARCHIVO:	adp008.sql	
TABLA:		Tabla de "imagenes por persona"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp008 
(
--** Llave Primaria
va_ide_rut		INT				NOT NULL	DEFAULT(0),			--** ID. Ruta
va_cod_per		INT				NOT NULL	DEFAULT(0),			--** Codigo Persona (2 de Grup. Per y 5 de Persona)

CONSTRAINT pk1_adp008 PRIMARY KEY(va_ide_rut, va_cod_per)
)
GO



