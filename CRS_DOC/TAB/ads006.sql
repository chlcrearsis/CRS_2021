/*--**********************************************
ARCHIVO:	ads006.sql	
TABLA:		Tabla de "Tipo de Usuario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2019
*/--**********************************************

PRINT 'ads006 : Tipo de Usuario'
CREATE TABLE ads006
(
	--** Llave Primaria
	va_ide_tus	INT			    NOT NULL DEFAULT(0),	--** ID. Tipo de Usuario
	--** Atributos
	va_nom_tus	VARCHAR(30)	    NOT NULL DEFAULT(''),	--** Nombre
	va_des_tus	VARCHAR(120)    NOT NULL DEFAULT(''),	--** Descripción	
	va_est_ado	CHAR		    NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_ads006 PRIMARY KEY(va_ide_tus)
)
GO



--** INSERTA TIPO DE USUARIO POR DEFECTO
INSERT INTO ads006 VALUES (1, 'Administrador', 'Nivel de Privilegio Alto', 'H')
INSERT INTO ads006 VALUES (2, 'Supervisor', 'Nivel de Privilegio Básico', 'H')
INSERT INTO ads006 VALUES (3, 'Operativo', 'Nivel de Privilegio Restringido', 'H')
