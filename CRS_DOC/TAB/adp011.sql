/*--**********************************************
ARCHIVO:	adp010.sql	
TABLA:		Tabla de "Contactos de persona"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp010 
(
--** Llave Primaria
va_cod_per		INT				NOT NULL	DEFAULT(0),			--** Codigo Persona (2 de Grup. Per y 5 de Persona)

--** Atributos     
va_cod_con		INT			    NOT NULL,		--** Codigo de contacto
va_nom_con      VARCHAR(30)     NOT NULL,       --** Nombre del contacto
va_car_con      VARCHAR(15)				,       --** Cargo del contacto
va_rel_con      VARCHAR(30)				,       --** Relacion del contacto
va_tel_con		VARCHAR(10)				,		--** Telefono del contacto
va_cel_con      VARCHAR(10)				,       --** Celular del contacto
va_ema_con		VARCHAR(30)				,		--** Correo del contacto
va_dir_con      VARCHAR(120)			,       --** Direccion del contacto
va_obs_con      VARCHAR(160)			,       --** Observacion del contacto

CONSTRAINT pk1_adp010 PRIMARY KEY(va_cod_per,va_cod_con)
)
GO
