/*--**********************************************
ARCHIVO:	ads010.sql	
TABLA:		Tabla de "Tipo de Imagenes"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'ads010 : Tipo de Imagenes'
CREATE TABLE ads010 
(
	--** Llave Primaria
	va_ide_tip	CHAR(02)	NOT NULL DEFAULT(0),	--** ID. Tipo Imagen
	--** Atributos
	va_nom_tip	VARCHAR(20)	NOT NULL DEFAULT(''),	--** Nombre
	va_ide_tab	CHAR(06)	NOT NULL DEFAULT(''),	--** ID. Tabla
	va_est_ado	CHAR(01)	NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_ads010 PRIMARY KEY(va_ide_tip)
)
GO

--** PERSONAS (adp002)
INSERT INTO ads010 VALUES ('FP','Foto Persona','adp002','H')
INSERT INTO ads010 VALUES ('CI','Carnet de Identidad','adp002','H')
INSERT INTO ads010 VALUES ('NI','NIT/RUC','adp002','H')
INSERT INTO ads010 VALUES ('CQ','Croquis','adp002','H')
INSERT INTO ads010 VALUES ('FT','Frotis','adp002','H')
 
--** PRODUCTOS (inv004)
INSERT INTO ads010 VALUES ('PF','Producto Frente','inv004','H')
INSERT INTO ads010 VALUES ('PD','Producto Derecha','inv004','H')
INSERT INTO ads010 VALUES ('PI','Producto Izquirda','inv004','H')
INSERT INTO ads010 VALUES ('PA','Producto Detras','inv004','H')
INSERT INTO ads010 VALUES ('PR','Descripcion','inv004','H')

GO
 