/*########################################################
ARCHIVO:	ads011.sql
TABLA:		Autorizacion usuario s/sucursal
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads011
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_ide_suc		INT				NOT NULL,	--Ide Sucursal

CONSTRAINT pk1_ads011 PRIMARY KEY(va_ide_usr,va_ide_suc)
)

go
