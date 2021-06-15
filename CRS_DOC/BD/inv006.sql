/*--**********************************************
ARCHIVO:	inv006.sql
TABLA:		Tabla de Marcas
AUTOR:		CHL-CREARSIS 
FECHA:		27-11-2017
*/--**********************************************

CREATE TABLE inv006
(
va_cod_mar		SMALLINT		NOT NULL,	--Codigo de la Marca (3 numeros)
va_nom_mar		VARCHAR(50)		NOT NULL,	--Nombre de la Marca

CONSTRAINT pk1_inv006 PRIMARY KEY(va_cod_mar)
)
GO
    
--INSERT INICIAL
INSERT INTO inv006 VALUES (1,'S/M')