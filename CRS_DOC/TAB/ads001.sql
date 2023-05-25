/*--**********************************************
ARCHIVO:	ads001.sql	
TABLA:		Tabla de "Módulo"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads001 : Módulo'
CREATE TABLE ads001
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo
	--** Atributos
	va_nom_mod	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_abr_mod	CHAR(03)	 NOT NULL DEFAULT(''),	--** Abrebiacion
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads001 PRIMARY KEY(va_ide_mod)
)
GO

--** INSERTA MODULO DEL SISTEMA POR DEFECTO
INSERT INTO ads001 VALUES (1, 'Administracion y Seguridad', 'ADS', 'H')
INSERT INTO ads001 VALUES (2, 'Inventario', 'INV', 'H')
INSERT INTO ads001 VALUES (3, 'Comercializacion', 'CMR', 'H')
INSERT INTO ads001 VALUES (4, 'Contabilidad', 'CTB', 'H')
INSERT INTO ads001 VALUES (5, 'Tesoreria', 'TES', 'H')

