/*########################################################
ARCHIVO:	cmr003.sql
TABLA:		Sucursal
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE cmr003
(
va_ide_suc 		INT			 	NOT NULL,	--ID. sucursal
va_nom_suc		VARCHAR(30)		NOT NULL,	--Nombre sucursal
va_des_suc		VARCHAR(90)		NOT NULL,	--Descripcion sucursal
va_dto_suc		VARCHAR(30)		NOT NULL,	--Departamento sucursal
va_ciu_suc		VARCHAR(30)		NOT NULL,	--Ciudad sucursal
va_dir_suc		VARCHAR(90)		NOT NULL,	--Direccion sucursal
va_enc_suc		VARCHAR(90)				,	--Encargdo sucursal
va_tel_suc		VARCHAR(15)				,	--Telefono
va_cel_suc		VARCHAR(15)				,	--Celular
va_cla_wif		VARCHAR(15)				,	--Clave wifi
va_ubi_lat		VARCHAR(30)				,	--Ubicacion Latitud
va_ubi_lon		VARCHAR(30)				,	--Ubicacion Longitud
va_est_ado		CHAR(01)		NOT NULL,	--Estado (H=habilitada; N=deshabilitada)

CONSTRAINT pk1_cmr003 PRIMARY KEY(va_ide_suc)
)

GO

INSERT INTO cmr003 VALUES(1,'CENTRAL', '','SANTA CRUZ', 'SANTA CRUZ','Av. San Aurelio Nº 392','','3358694','72195985','123456789','0','0','H')