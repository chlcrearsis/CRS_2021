/*--**********************************************
ARCHIVO:	adp004.sql	
TABLA:		Tabla de "Definiciones de Atributos"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp004 : Definiciones de Atributos'
CREATE TABLE adp004 
(
	--** Llave Primaria
	va_ide_tip	INT			 NOT NULL DEFAULT(0),	--** ID. tipo de atributo
	va_ide_atr	INT			 NOT NULL DEFAULT(0),	--** ID. Atributo

	--** Atributos     
	va_nom_atr  VARCHAR(30)	 NOT NULL DEFAULT(''),  --** Nombre Atributo
	va_est_ado  CHAR(01)	 NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp004 PRIMARY KEY(va_ide_tip, va_ide_atr)
)
GO

--** Inserta Atributo : Ciudad
INSERT INTO adp004 VALUES (1, 1, 'Santa Cruz', 'H')
INSERT INTO adp004 VALUES (1, 2, 'Cochabamba', 'H')
INSERT INTO adp004 VALUES (1, 3, 'La Paz', 'H')
INSERT INTO adp004 VALUES (1, 4, 'Tarija', 'H')
INSERT INTO adp004 VALUES (1, 5, 'Potosi', 'H')
INSERT INTO adp004 VALUES (1, 6, 'Pando', 'H')
INSERT INTO adp004 VALUES (1, 7, 'Beni', 'H')
INSERT INTO adp004 VALUES (1, 8, 'Oruro', 'H')
INSERT INTO adp004 VALUES (1, 9, 'Sucre', 'H')

--** Inserta Atributo : Zona
INSERT INTO adp004 VALUES (2, 1, 'Zona Central', 'H')
INSERT INTO adp004 VALUES (2, 2, 'Zona Norte', 'H')
INSERT INTO adp004 VALUES (2, 3, 'Zona Sur', 'H')
INSERT INTO adp004 VALUES (2, 4, 'Zona Este', 'H')
INSERT INTO adp004 VALUES (2, 5, 'Zona Oeste', 'H')
INSERT INTO adp004 VALUES (2, 99, 'N/A', 'H')

--** Inserta Atributos : Sector
INSERT INTO adp004 VALUES (3, 1, 'Agricultura', 'H')
INSERT INTO adp004 VALUES (3, 2, 'Comercial', 'H')
INSERT INTO adp004 VALUES (3, 3, 'Industrial', 'H')
INSERT INTO adp004 VALUES (3, 4, 'Ganadero', 'H')
INSERT INTO adp004 VALUES (3, 5, 'Servicios', 'H')
INSERT INTO adp004 VALUES (3, 6, 'Dependientes', 'H')
INSERT INTO adp004 VALUES (3, 7, 'Socios', 'H')
INSERT INTO adp004 VALUES (3, 99, 'N/A', 'H')

--** Inserta Atributos : Canal
INSERT INTO adp004 VALUES (4, 1, 'Mayorista', 'H')
INSERT INTO adp004 VALUES (4, 2, 'Agencias', 'H')
INSERT INTO adp004 VALUES (4, 3, 'Mercados', 'H')
INSERT INTO adp004 VALUES (4, 4, 'Supermercado', 'H')
INSERT INTO adp004 VALUES (4, 5, 'Tienda de Barrio', 'H')
INSERT INTO adp004 VALUES (4, 6, 'Fabrica', 'H')
INSERT INTO adp004 VALUES (4, 7, 'Restaurant', 'H')
INSERT INTO adp004 VALUES (4, 8, 'Hotel', 'H')
INSERT INTO adp004 VALUES (4, 9, 'Frial', 'H')
INSERT INTO adp004 VALUES (4, 99, 'N/A', 'H')

--** Inserta Atributos : Calificación
INSERT INTO adp004 VALUES (5, 1, 'Normal', 'H')
INSERT INTO adp004 VALUES (5, 2, 'Problema', 'H')
INSERT INTO adp004 VALUES (5, 3, 'Riesgo', 'H')
INSERT INTO adp004 VALUES (5, 4, 'Legal', 'H')
INSERT INTO adp004 VALUES (5, 5, 'Perdido', 'H')
INSERT INTO adp004 VALUES (5, 6, 'Eventual', 'H')
INSERT INTO adp004 VALUES (5, 7, 'Inactivo', 'H')
INSERT INTO adp004 VALUES (5, 99, 'N/A', 'H')

--** Inserta Atributos : Profesión
INSERT INTO adp004 VALUES (6, 1, 'Licenciado', 'H')
INSERT INTO adp004 VALUES (6, 2, 'Medico', 'H')
INSERT INTO adp004 VALUES (6, 3, 'Ingeniero', 'H')
INSERT INTO adp004 VALUES (6, 4, 'Abogado', 'H')
INSERT INTO adp004 VALUES (6, 5, 'Obrero', 'H')
INSERT INTO adp004 VALUES (6, 6, 'Comerciante', 'H')
INSERT INTO adp004 VALUES (6, 7, 'Chofer', 'H')
INSERT INTO adp004 VALUES (6, 8, 'Secretario', 'H')
INSERT INTO adp004 VALUES (6, 9, 'Empleado', 'H')
INSERT INTO adp004 VALUES (6, 10, 'Militar', 'H')
INSERT INTO adp004 VALUES (6, 99, 'N/A', 'H')

--** Inserta Atributos : Distribuidor
INSERT INTO adp004 VALUES (7, 1, 'Distribuidor 1', 'H')
INSERT INTO adp004 VALUES (7, 2, 'Distribuidor 2', 'H')
INSERT INTO adp004 VALUES (7, 3, 'Distribuidor 3', 'H')
INSERT INTO adp004 VALUES (7, 99, 'N/A', 'H')

--** Inserta Atributos : Despacho
INSERT INTO adp004 VALUES (8, 1, 'Despacho 1', 'H')
INSERT INTO adp004 VALUES (8, 2, 'Despacho 2', 'H')
INSERT INTO adp004 VALUES (8, 3, 'Despacho 3', 'H')
INSERT INTO adp004 VALUES (8, 99, 'N/A', 'H')