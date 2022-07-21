/*--**********************************************
ARCHIVO:	adp014.sql	
TABLA:		Tabla de "Tipo de Documento"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		15-09-2021
*/--**********************************************

PRINT 'adp014 : Tipo de Documento'	
CREATE TABLE adp014 
(
	--** Llave Primaria
	va_ide_tip  CHAR(02)    NOT NULL DEFAULT(''),	--** ID. Tipo de Documento

	--** Atributos     
	va_des_tip  VARCHAR(30) NOT NULL DEFAULT(''),   --** Nombre
	va_ext_doc  CHAR(01)    NOT NULL DEFAULT(''),   --** Usa Extension Documento (S=Si; N=No)
	va_est_ado  CHAR(01)    NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp014 PRIMARY KEY(va_ide_tip)
)
GO


--** Inserta los tipo de atributos iniciales
INSERT INTO adp014 VALUES ('CI', 'Carnet de Identidad', 'S', 'H')
INSERT INTO adp014 VALUES ('LC', 'Licencia de Conducir', 'S', 'H')
INSERT INTO adp014 VALUES ('SM', 'Libreta Servicio Militar', 'N', 'H')
INSERT INTO adp014 VALUES ('PS', 'Pasaporte', 'N', 'H')