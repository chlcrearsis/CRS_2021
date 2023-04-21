/*--**********************************************
ARCHIVO:	inv010.sql
TABLA:		Productos sustitutos
AUTOR:		CHL-CREARSIS
FECHA:		23-03-2023
*/--**********************************************

CREATE TABLE inv010 
(
va_cod_pro	VARCHAR(15)		NOT NULL,				--** Codigo del producto 
va_pro_sus	VARCHAR(15)		NOT NULL,				--** Codigo del producto sustituto

CONSTRAINT pk1_inv010 PRIMARY KEY(va_cod_pro,va_pro_sus)
)
GO
