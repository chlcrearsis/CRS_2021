/*########################################################
ARCHIVO:	ads017.sql
TABLA:		Autorizacion usuario s/Plantilla de ventas (cmr004)
AUTOR:		CHL
FECHA:		27/10/2020
########################################################*/

CREATE TABLE ads017
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_cod_plv		INT				NOT NULL,	--Codigo de la plantilla

CONSTRAINT pk1_ads017 PRIMARY KEY(va_ide_usr,va_cod_plv)
)

go
