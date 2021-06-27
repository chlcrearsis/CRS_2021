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
va_dir_ect		VARCHAR(30)				,	--Directorio de trabajo
va_ema_usr		VARCHAR(90)				,	--Email usuario
va_win_max		INT				NOT NULL,	--Nro maximo de ventanas
va_ide_per		INT				NOT NULL,	--Ide de persona
va_tip_usr		INT				NOT NULL,	--Tipo de usuario 
va_est_ado		CHAR(01)		NOT NULL	--Estado (H=habilitado; N=deshabilitado)

CONSTRAINT pk1_ads007 PRIMARY KEY(va_ide_usr)
)
