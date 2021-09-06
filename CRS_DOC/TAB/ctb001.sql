/*--**********************************************
ARCHIVO:	ctb001.sql
TABLA:		Tabla de Regional de la empresa
AUTOR:		CHL-CREARSIS
FECHA:		26-08-2021
*/--**********************************************

CREATE TABLE ctb001
(
va_cod_rgn		INT				NOT NULL,	-- Codigo de la regional
va_nom_rgn		VARCHAR(40)		NOT NULL,	-- Nombre de la regional

CONSTRAINT pk1_ctb001 PRIMARY KEY(va_cod_rgn)
)

GO
INSERT INTO ctb001 VALUES 
(1,'Regional')

GO