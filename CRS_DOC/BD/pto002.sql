/*########################################################
ARCHIVO:	pto002.sql
TABLA:		Pala
AUTOR:		CHL
FECHA:		08/01/2020
########################################################*/

CREATE TABLE pto002
(
va_ide_pal		INT				NOT NULL,	--Ide. pala  
va_nom_pal		VARCHAR(60)		NOT NULL,	--Nombre pala
va_des_pal		VARCHAR(120)	NOT NULL,	--Descripcion pala
va_res_pon		INT				NOT NULL,	--Codigo Persona responsable
va_res_tel		VARCHAR(10)				,	--Telefono del responsable											
va_ide_pto		INT				NOT NULL,	--Ide de puerto
va_est_ado		INT 						--Estado


CONSTRAINT pk1_pto002 PRIMARY KEY(va_ide_pal)
)

go
