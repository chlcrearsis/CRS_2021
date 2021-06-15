/*########################################################
ARCHIVO:	pto004.sql
TABLA:		Contrato
AUTOR:		CHL
FECHA:		08/01/2020
########################################################*/

CREATE TABLE pto004
(
va_ide_cto 		INT				NOT NULL,	--Ide. puerto  
va_nom_pto		VARCHAR(60)		NOT NULL,	--Nombre puerto
va_des_pto		VARCHAR(120)	NOT NULL,	--Descripcion puerto
va_dir_pto		VARCHAR(120)	NOT NULL,	--Direccion puerto
va_ubi_pto		GEOGRAPHY		NOT NULL,	--Ubicacion puerto
va_res_pon		INT				NOT NULL,	--Codigo Persona responsable
va_res_tel		VARCHAR(10)				,	--Telefono del responsable											
va_est_ado		INT 			NOT NULL	--Estado


CONSTRAINT pk1_pto004 PRIMARY KEY(va_ide_cto)
)

go
