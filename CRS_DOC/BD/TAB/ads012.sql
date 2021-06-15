/*########################################################
ARCHIVO:	ads012.sql
TABLA:		Restriccion menu
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads012
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_ide_apl		VARCHAR(20)		NOT NULL,	--Ide Aplicacion
va_ide_mnu		VARCHAR(30)		NOT NULL,	--Ide menu

CONSTRAINT pk1_ads012 PRIMARY KEY(va_ide_usr,va_ide_apl,va_ide_mnu)
)

go
