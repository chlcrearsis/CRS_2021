/*########################################################
ARCHIVO:	ads010.sql
TABLA:		Sucursal
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads010
(
va_suc_urs 		INT			 	NOT NULL,	--Identificador sucursal
va_nom_suc		VARCHAR(30)		NOT NULL,	--Nombre sucursal
va_des_suc		VARCHAR(90)		NOT NULL,	--Descripcion sucursal
va_dto_suc		INT				NOT NULL,	--Departamento sucursal
va_ciu_suc		VARCHAR(30)		NOT NULL,	--Ciudad sucursal
va_dir_suc		VARCHAR(90)		NOT NULL,	--Direccion sucursal
va_enc_suc		VARCHAR(90)				,	--Encargdo sucursal
va_tel_suc		VARCHAR(15)				,	--Telefono
va_cel_suc		VARCHAR(15)				,	--Celular
va_cla_wif		VARCHAR(15)				,	--Clave wifi
va_ubi_suc		GEOGRAPHY				,	--Ubicacion
va_est_ado		CHAR(01)		NOT NULL,	--Estado (H=habilitada; N=deshabilitada)

CONSTRAINT pk1_ads010 PRIMARY KEY(va_suc_urs)
)

go
