/*--**********************************************
ARCHIVO:	ads024.sql	
TABLA:		Tabla de "Bitacora de Inicio de Sesion"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		26-08-2021
*/--**********************************************

CREATE TABLE ads024 
(
--** Llave Primaria
va_ide_uni      CHAR(32),                   --** Identificador Unico

--** Atributos     
va_ide_usr 		VARCHAR(15) 	NOT NULL,	--** Identificador Usuario
va_fec_reg		DATETIME,					--** Fecha Actual Sin hh:MM:ss
va_nom_maq      VARCHAR(30)     NOT NULL,   --** Nombre de la Maquina
va_fec_ini      DATETIME,                   --** Fecha y Hora de Inicio
va_fec_fin      DATETIME,                   --** Fecha y Hora de Cierre

CONSTRAINT pk1_ads024 PRIMARY KEY(va_ide_uni)
)
GO