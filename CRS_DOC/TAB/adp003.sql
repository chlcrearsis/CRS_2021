/*--**********************************************
ARCHIVO:	adp003.sql	
TABLA:		Tabla de "Tipo de atributos"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp003 : Tipo de atributos'
CREATE TABLE adp003 
(
	--** Llave Primaria
	va_ide_tip  INT		    NOT NULL DEFAULT(0),	--** ID. tipo de atributo

	--** Atributos     
	va_nom_tip  VARCHAR(30) NOT NULL DEFAULT(''),   --** Nombre
	va_atr_def  INT			NOT NULL DEFAULT(0),    --** ID. atributo por defecto (adp004)
	va_est_ado  CHAR(01)    NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp003 PRIMARY KEY(va_ide_tip)
)
GO


--** Inserta los tipo de atributos iniciales
INSERT INTO adp003 VALUES (1, 'Ciudad', 1, 'H')
INSERT INTO adp003 VALUES (2, 'Zona', 1, 'H')
INSERT INTO adp003 VALUES (3, 'Sector', 2, 'H')
INSERT INTO adp003 VALUES (4, 'Canal', 99, 'H')
INSERT INTO adp003 VALUES (5, 'Calificación', 1, 'H')
INSERT INTO adp003 VALUES (6, 'Profesión', 99, 'H')
INSERT INTO adp003 VALUES (7, 'Distribuidor', 1, 'H')
INSERT INTO adp003 VALUES (8, 'Despacho', 1, 'H')
