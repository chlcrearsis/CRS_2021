/*--**********************************************
ARCHIVO:	adp007.sql	
TABLA:		Tabla de "Definiciones de Rutas"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp007 : Definiciones de Rutas'
CREATE TABLE adp007 
(
	--** Llave Primaria
	va_ide_rut	INT			 NOT NULL DEFAULT(0),	--** ID. Ruta

	--** Atributos
	va_nom_rut	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre de la ruta
	va_nom_cor	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Nombre corto
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT('')	--** Estado (H=habilitado; N= deshabilitado)

CONSTRAINT pk1_adp007 PRIMARY KEY(va_ide_rut)
)
GO


--** Inserta Registro por Defecto
INSERT INTO adp007 VALUES (1, 'Lunes','LUN','H')
INSERT INTO adp007 VALUES (2, 'Martes','MAR','H')
INSERT INTO adp007 VALUES (3, 'Miercoles','MIE','H')
INSERT INTO adp007 VALUES (4, 'Jueves','JUE','H')
INSERT INTO adp007 VALUES (5, 'Viernes','VIE','H')
INSERT INTO adp007 VALUES (6, 'Sábado','SAB','H')
INSERT INTO adp007 VALUES (7, 'Domingo','DOM','H')
GO


