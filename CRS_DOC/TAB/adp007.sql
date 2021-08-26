/*--**********************************************
ARCHIVO:	adp007.sql	
TABLA:		Tabla de "imagenes por persona"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp007 
(
--** Llave Primaria
va_ide_rut		INT				NOT NULL	DEFAULT(0),			--** ID. Ruta

--** Atributos
va_nom_rut		VARCHAR(30)		NOT NULL	DEFAULT(''),		--** Nombre de la ruta
va_nom_cor		VARCHAR(30)		NOT NULL	DEFAULT(''),		--** Nombre corto
va_est_ado		CHAR(01)		NOT NULL	DEFAULT('')		--** Estado (H=habilitado; N= deshabilitado)

CONSTRAINT pk1_adp007 PRIMARY KEY(va_ide_rut)
)
GO

INSERT INTO adp007 VALUES (1,'LUNES','LUN','H')
INSERT INTO adp007 VALUES (2,'MARTES','MAR','H')
INSERT INTO adp007 VALUES (3,'MIERCOLES','MIE','H')
INSERT INTO adp007 VALUES (4,'JUEVES','JUE','H')
INSERT INTO adp007 VALUES (5,'VIERNES','VIE','H')
INSERT INTO adp007 VALUES (6,'SABADO','SAB','H')
INSERT INTO adp007 VALUES (7,'DOMINGO','DOM','H')
GO


