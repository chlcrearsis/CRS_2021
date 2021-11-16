/*--**********************************************
ARCHIVO:	adp012.sql	
TABLA:		Tabla de "Personas Relacionadas a Grupo Empresarial"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp012 
(
	--** Llave Primaria
	va_cod_per  INT		NOT NULL	DEFAULT(0),			--** Codigo Persona
	va_gru_emp	INT		NOT NULL	DEFAULT(0),			--** Codigo Grupo Empresarial

CONSTRAINT pk1_adp012 PRIMARY KEY(va_cod_per, va_gru_emp)
)
GO
