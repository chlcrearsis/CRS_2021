/*--**********************************************
ARCHIVO:	inv012.sql
TABLA:		Colores permitidos por linea de producto
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv012 
(
va_cod_fam		VARCHAR(06)		NOT NULL,	--Codigo linea de producto
va_cod_col		INT				NOT NULL,	--Codigo color

CONSTRAINT pk1_inv012 PRIMARY KEY(va_cod_fam,va_cod_col)
)
GO
