/*--**********************************************
ARCHIVO:	adp005.sql	
TABLA:		Tabla de "Atributos por persona"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp005 
(
--** Llave Primaria
va_ide_tip		INT				NOT NULL	DEFAULT(0),			--** ID. tipo de atributo
va_ide_atr		INT				NOT NULL	DEFAULT(0),			--** ID. Atributo
va_cod_per		INT				NOT NULL	DEFAULT(0),			--** Codigo Persona (2 de Grup. Per y 5 de Persona)

CONSTRAINT pk1_adp005 PRIMARY KEY(va_ide_tip, va_ide_atr, va_cod_per)
)
GO


