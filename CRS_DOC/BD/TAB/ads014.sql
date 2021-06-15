/*########################################################
ARCHIVO:	ads014.sql
TABLA:		Region
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads014
(
va_ide_reg 		INT			 	NOT NULL,	--Ide. region
va_nom_reg		VARCHAR(30)		NOT NULL,	--Nombre region
va_est_ado		CHAR(01)		NOT NULL,	--Estado (H=habilitado; N=deshabilitado)

CONSTRAINT pk1_ads014 PRIMARY KEY(va_ide_reg)
)

go
