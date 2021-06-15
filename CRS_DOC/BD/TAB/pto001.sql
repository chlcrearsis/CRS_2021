/*########################################################
ARCHIVO:	pto001.sql
TABLA:		Draga
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE pto001
(
va_ide_dra		INT				NOT NULL,	--Ide. draga  
va_nom_dra		VARCHAR(60)		NOT NULL,	--Nombre draga
va_des_dra		VARCHAR(120)	NOT NULL,	--Descripcion draga
va_res_pon		INT				NOT NULL,	--Codigo Persona responsable
va_res_tel		VARCHAR(10)				,	--Telefono del responsable											
va_ide_pto		INT				NOT NULL,	--Ide de puerto
va_est_ado		INT 						--Estado


CONSTRAINT pk1_pto001 PRIMARY KEY(va_ide_dra)
)

go
