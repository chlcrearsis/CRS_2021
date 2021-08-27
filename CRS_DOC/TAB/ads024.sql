/*--**********************************************
ARCHIVO:	ads024.sql	
TABLA:		Tabla de "Bitacora de Inicio de Sesion"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		26-08-2021
*/--**********************************************

CREATE TABLE ads024 
(
--** Llave Primaria
va_fec_reg		DATETIME,					--** Fecha y Hora de Registro
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--** Identificador Usuario

--** Atributos     
va_nom_maq      VARCHAR(30)     NOT NULL,   --** Nombre de la Maquina

CONSTRAINT pk1_ads024 PRIMARY KEY(va_fec_reg, va_ide_usr)
)
GO
