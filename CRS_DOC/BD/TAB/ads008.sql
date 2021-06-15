/*########################################################
ARCHIVO:	ads008.sql
TABLA:		Autorizacion usuario s/aplicaciones
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads008
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_ide_apl		VARCHAR(20)		NOT NULL,	--Ide Aplicacion

CONSTRAINT pk1_ads008 PRIMARY KEY(va_ide_usr,va_ide_apl)
)

go
