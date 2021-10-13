/*--**********************************************
ARCHIVO:	cmr016.sql
TABLA:		Tabla Actividad economica
AUTOR:		CREARSIS
FECHA:		12-09-2021
*/--**********************************************

CREATE TABLE cmr016(
	va_cod_act		tinyint			NOT NULL,	-- Codigo actividad economica
	va_nom_act		varchar(200)	NOT NULL,	-- Nombre actividad economica
	
	CONSTRAINT pk1_cmr016 PRIMARY KEY(va_cod_act)
) 

GO

INSERT INTO cmr016 VALUES (0,'ACTIVIDAD ECONOMICA PRINCIPAL')