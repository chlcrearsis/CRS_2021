/*########################################################
ARCHIVO:	ads009.sql
TABLA:		Autorizacion usuario s/Talonario
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads009
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_ide_doc		CHAR(03)		NOT NULL,	--Ide del documento
va_nro_tal		INT				NOT NULL,	--Nro talonario

CONSTRAINT pk1_ads009 PRIMARY KEY(va_ide_usr,va_ide_doc,va_nro_tal)
)

go
