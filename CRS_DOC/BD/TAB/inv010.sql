/*--**********************************************
ARCHIVO:	inv010.sql
TABLA:		Tabla Colors
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv010 
(
va_cod_col		INT				NOT NULL,	--Codigo de la Color
va_nom_col		VARCHAR(50)		NOT NULL,	--Nombre de la Color
va_est_ado		CHAR(01)		NOT NULL	--Estado
CONSTRAINT pk1_inv010 PRIMARY KEY(va_cod_col)
)
GO
     
--INSERT INICIAL
INSERT INTO inv010 VALUES (1,'Azul','H')
INSERT INTO inv010 VALUES (2,'Celeste','H')
INSERT INTO inv010 VALUES (3,'Negro','H')
INSERT INTO inv010 VALUES (4,'Verde','H')

GO