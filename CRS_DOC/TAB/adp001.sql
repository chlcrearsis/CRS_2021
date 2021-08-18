/*--**********************************************
ARCHIVO:	adp001.sql	
TABLA:		Tabla de "Grupo de Persona"
AUTOR:		CREARSIS 3.0.0 (LEO)
FECHA:		03-01-2018
*/--**********************************************

CREATE TABLE adp001 
(
--** Llave Primaria
va_cod_gru		TINYINT			NOT NULL,		--** Codigo de Grupo de persona (2 NUMEROS)

--** Atributos     
va_nom_gru		VARCHAR(50)	    NOT NULL,		--** Nombre de Grupo de persona
va_est_ado      CHAR(01)        NOT NULL,       --** Estado

CONSTRAINT pk1_adp001 PRIMARY KEY(va_cod_gru)
)
GO
