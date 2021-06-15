/*--**********************************************
ARCHIVO:	cmr015.sql
TABLA:		Tabla Deliverys
AUTOR:		CHL-CREARSIS
FECHA:		02/09/2020
*/--**********************************************
--drop table cmr015
CREATE TABLE cmr015
(
va_cod_del		INT			NOT NULL,	--Codigo  Delivery
va_nom_del		VARCHAR(30)	NOT NULL,	--Nombre
va_por_del		DECIMAL(3,1)	NOT NULL,	--Porcenta que cobra el delivery
va_est_ado		CHAR(01)	NOT NULL	--Estado
 
CONSTRAINT pk1_cmr015 PRIMARY KEY(va_cod_del)
)


