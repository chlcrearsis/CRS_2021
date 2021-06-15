/*--**********************************************
ARCHIVO:	inv009.sql
TABLA:		Tabla Tallas
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv009 
(
va_cod_tal		INT				NOT NULL,	--Codigo de la Talla
va_nom_tal		VARCHAR(50)		NOT NULL,	--Nombre de la Talla
va_est_ado		CHAR(01)		NOT NULL	--Estado
CONSTRAINT pk1_inv009 PRIMARY KEY(va_cod_tal)
)
GO
     
--INSERT INICIAL
INSERT INTO inv009 VALUES (6,'36','H')
INSERT INTO inv009 VALUES (8,'38','H')
INSERT INTO inv009 VALUES (10,'40','H')
INSERT INTO inv009 VALUES (12,'42','H')
INSERT INTO inv009 VALUES (14,'44','H')

INSERT INTO inv009 VALUES (20,'S','H')
INSERT INTO inv009 VALUES (22,'M','H')
INSERT INTO inv009 VALUES (24,'L','H')
INSERT INTO inv009 VALUES (26,'XL','H')

GO