/*########################################################
ARCHIVO:	inv001.sql
TABLA:		Grupo de Bodegas
AUTOR:		CHL
FECHA:		21/07/2020
########################################################*/

CREATE TABLE inv001
(
va_ide_gru 		INT			 	NOT NULL,	--Ide de grupo de bodega
va_nom_gru		VARCHAR(30)		NOT NULL,	--Nombre de grupo de bodega
va_des_gru		VARCHAR(60) 	NOT NULL,	--Descripcion de grupo de bodega
va_est_ado		CHAR(01)		NOT NULL	--Estado

CONSTRAINT pk1_inv001 PRIMARY KEY(va_ide_gru)
)

go
