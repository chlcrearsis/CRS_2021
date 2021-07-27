/*########################################################
ARCHIVO:	ads009.sql
TABLA:		Autorizaciones de tipo de usuario sobre el sistema
AUTOR:		CHL
FECHA:		26/07/2021
########################################################*/

CREATE TABLE ads009
(
va_ide_tus 		VARCHAR(15) 	NOT NULL,	--ID. Usuario
va_ide_tab		CHAR(06)		NOT NULL,	--ID. tabla
va_ide_uno		CHAR(15)		NOT NULL,	--Identificador uno
va_ide_dos		CHAR(15),					--Identificador dos
va_ide_tre		CHAR(15),					--Identificador tres
va_ide_int		INT	NOT NULL DEFAULT(0),	--Identificador entero

CONSTRAINT pk1_ads009 PRIMARY KEY(va_ide_tus,va_ide_tab,va_ide_uno,va_ide_dos,va_ide_tre)
)

go
