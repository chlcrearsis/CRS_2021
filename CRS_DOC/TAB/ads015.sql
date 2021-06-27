/*########################################################
ARCHIVO:	ads015.sql
TABLA:		Restriccion menu
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads015
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_ide_reg		INT				NOT NULL	--Ide Region

CONSTRAINT pk1_ads015 PRIMARY KEY(va_ide_usr)
)

go
