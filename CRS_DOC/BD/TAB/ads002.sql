/*########################################################
ARCHIVO:	ads002.sql
TABLA:		Aplicaciones
AUTOR:		CHL
FECHA:		21/08/2019
########################################################*/

CREATE TABLE ads002
(
va_ide_mod		INT				NOT NULL,	--Ide Modulo
va_ide_apl		VARCHAR(20)		NOT NULL,	--Ide Aplicacion
va_nom_apl		VARCHAR(120)	NOT NULL,	--Nombre Aplicacion
va_est_ado		CHAR(01)		NOT NULL,	--Estado

CONSTRAINT pk1_ads002 PRIMARY KEY(va_ide_mod,va_ide_apl)
)

go
INSERT INTO ads002 VALUES (1,'ads200','Administrador','V')
INSERT INTO ads002 VALUES (2,'inv200','Inventario','V')
INSERT INTO ads002 VALUES (3,'cmr200','Comercializacion','V')
INSERT INTO ads002 VALUES (3,'res200','Restaurant','V')


