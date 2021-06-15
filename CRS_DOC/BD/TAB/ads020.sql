/*########################################################
ARCHIVO:	ads020.sql
TABLA:		Autorizacion usuario s/Vendedor
AUTOR:		CHL
FECHA:		27/10/2020
########################################################*/

CREATE TABLE ads020
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_cod_ven		INT				NOT NULL,	--Codigo Vendedor

CONSTRAINT pk1_ads020 PRIMARY KEY(va_ide_usr,va_cod_ven)
)

go
