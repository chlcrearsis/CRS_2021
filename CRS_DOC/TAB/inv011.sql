/*--**********************************************
ARCHIVO:	inv011.sql
TABLA:		Tallas permitidas por linea de producto
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv011 
(
va_cod_fam		VARCHAR(06)		NOT NULL,	--Codigo linea de producto
va_cod_tal		INT				NOT NULL,	--Codigo talla

CONSTRAINT pk1_inv011 PRIMARY KEY(va_cod_fam,va_cod_tal)
)
GO
