/*########################################################
ARCHIVO:	ads019.sql
TABLA:		Autorizacion usuario s/Lista de Precio
AUTOR:		CHL
FECHA:		27/10/2020
########################################################*/

CREATE TABLE ads019
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_cod_lis		INT				NOT NULL,	--Codigo de la Lista de Precio

CONSTRAINT pk1_ads019 PRIMARY KEY(va_ide_usr,va_cod_lis)
)

go
