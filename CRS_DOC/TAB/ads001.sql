/*########################################################
ARCHIVO:	ads001.sql
TABLA:		Modulo
AUTOR:		CHL
FECHA:		21/08/2019
########################################################*/

CREATE TABLE ads001
(
va_ide_mod		INT				NOT NULL,	--Ide Modulo
va_nom_mod		varchar(30)		NOT NULL,	--Nombre modulo
va_abr_mod		varchar(05)		NOT NULL,	--Abrebiacion del modulo
va_est_ado		CHAR(01)		NOT NULL,	--Estado


CONSTRAINT pk1_ads001 PRIMARY KEY(va_ide_mod)
)

go
