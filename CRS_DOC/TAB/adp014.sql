/*--**********************************************
ARCHIVO:	adp014.sql	
TABLA:		Tabla de "Tipo de Documento"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		15-09-2021
*/--**********************************************

CREATE TABLE adp014 
(
	--** Llave Primaria
	va_ide_tip  INT		    NOT NULL DEFAULT(0),	--** ID. Tipo de Documento

	--** Atributos     
	va_nom_tip  VARCHAR(30) NOT NULL DEFAULT(''),   --** Nombre
	va_est_ado  CHAR(01)    NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp014 PRIMARY KEY(va_ide_tip)
)
GO


--** Inserta los tipo de atributos iniciales
INSERT INTO adp014 VALUES (1, 'Carnet de Identidad', 'H')
INSERT INTO adp014 VALUES (2, 'Licencia de Conducir', 'H')
INSERT INTO adp014 VALUES (3, 'Libreta Servicio Militar', 'H')
INSERT INTO adp014 VALUES (4, 'Pasaporte', 'H')

