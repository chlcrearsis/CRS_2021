/*########################################################
ARCHIVO:	ads006.sql
TABLA:		Tipo de usuario
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads006
(
va_ide_tus		INT				NOT NULL,	--Identificador Tipo de Usuario
va_nom_tus		VARCHAR(30)		NOT NULL,	--Nombre tipo usuario
va_des_tus		VARCHAR(120)	NOT NULL,	--Descripcion tipo usuario
va_est_ado		CHAR			NOT NULL	--Estado (H=habilitado; N=deshabilitado)

CONSTRAINT pk1_ads006 PRIMARY KEY(va_ide_tus)
)

go
