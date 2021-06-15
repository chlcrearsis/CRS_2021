/*########################################################
ARCHIVO:	ads007.sql
TABLA:		Usuario
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads007
(
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--Identificador Usuario
va_nom_usr		VARCHAR(30)		NOT NULL,	--Nombre usuario
va_tel_usr		VARCHAR(15)				,	--Telefono usuario
va_car_usr		VARCHAR(30)				,	--Cargo usuario
va_ema_usr		VARCHAR(90)				,	--Email usuario
va_win_max		INT				NOT NULL,	--Nro maximo de ventanas
va_ide_per		INT				NOT NULL,	--Ide de persona
va_est_ado		CHAR			NOT NULL	--Estado (H=habilitado; N=deshabilitado)

CONSTRAINT pk1_ads007 PRIMARY KEY(va_ide_usr)
)

go
INSERT INTO ads007 VALUES('chlsql','Administrador del sistema','','','',3,0,'H')

GO