/*--**********************************************
ARCHIVO:	ads010.sql	
TABLA:		Tabla de "Tipo de imagenes"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE ads010 
(
--** Llave Primaria
va_ide_tip		INT				NOT NULL	DEFAULT(0),			--** ID. tipo de imagen
va_nom_tip		VARCHAR(20)		NOT NULL	DEFAULT(''),		--** Nombre
va_ide_tab		CHAR(06)		NOT NULL,						--** ID. tabla
va_est_ado		CHAR(01)		NOT NULL						--** Estado (H= habilitado; N=deshabilitado)

CONSTRAINT pk1_ads010 PRIMARY KEY(va_ide_tip)
)
GO

--** PERSONAS (adp002)
INSERT INTO ads010 VALUES (10,'Foto Persona','adp002','H')
INSERT INTO ads010 VALUES (11,'CI','adp002','H')
INSERT INTO ads010 VALUES (12,'Nit','adp002','H')
INSERT INTO ads010 VALUES (13,'Croquis','adp002','H')
INSERT INTO ads010 VALUES (14,'Frotis','adp002','H')
 
--** PRODUCTOS (inv004)
INSERT INTO ads010 VALUES (20,'Producto Frente','inv004','H')
INSERT INTO ads010 VALUES (21,'Producto Derecha','inv004','H')
INSERT INTO ads010 VALUES (22,'Producto Izquirda','inv004','H')
INSERT INTO ads010 VALUES (23,'Producto Detras','inv004','H')
INSERT INTO ads010 VALUES (24,'Descripcion','inv004','H')

GO
 