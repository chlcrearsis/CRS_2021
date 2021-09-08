/*--**********************************************
ARCHIVO:	ctb007.sql
TABLA:		Tabla de leyendas
AUTOR:		FVM-CREARSIS
FECHA:		05-07-2017
*/--**********************************************

CREATE TABLE ctb006(
	va_cod_ley		tinyint			NOT NULL,	-- Codigo leyenda de 0 A 99
	va_nom_ley		varchar(500)	NOT NULL,	-- Nombre de la leyenda
	
	CONSTRAINT pk1_ctb006 PRIMARY KEY(va_cod_ley)
) 

GO