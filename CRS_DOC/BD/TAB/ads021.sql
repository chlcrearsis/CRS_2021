/*########################################################
ARCHIVO:	ads021.sql
TABLA:		Autorizacion usuario s/Delivery
AUTOR:		CHL
FECHA:		27/10/2020
########################################################*/

CREATE TABLE ads021
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_cod_del		INT				NOT NULL,	--Codigo Delivery

CONSTRAINT pk1_ads021 PRIMARY KEY(va_ide_usr,va_cod_del)
)

go
