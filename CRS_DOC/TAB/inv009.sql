/*--**********************************************
ARCHIVO:	inv009.sql
TABLA:		Tabla Vademecum Producto
AUTOR:		CHL-CREARSIS
FECHA:		23-03-2023
*/--**********************************************

CREATE TABLE inv009 
(
va_cod_pro	VARCHAR(15)		NOT NULL,				--** Codigo del producto 
va_pri_act	VARCHAR(150)	NOT NULL,				--** Principios activos
va_pro_ind	VARCHAR(200)			,				--** Indicaciones
va_con_ind	VARCHAR(200)			,				--** Contra indicaciones

CONSTRAINT pk1_inv009 PRIMARY KEY(va_cod_pro)
)
GO