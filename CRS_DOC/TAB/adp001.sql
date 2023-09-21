/*--**********************************************
ARCHIVO:	adp001.sql	
TABLA:		Tabla de "Grupo de Persona"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		03-01-2018
*/--**********************************************

PRINT 'adp001 : Grupo Persona'
CREATE TABLE adp001 
(
	--** Llave Primaria
	va_cod_gru	INT			 NOT NULL DEFAULT(0),	--** Codigo de Grupo de persona

	--** Atributos     
	va_nom_gru	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre de Grupo de persona
	va_est_ado  CHAR(01)     NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp001 PRIMARY KEY(va_cod_gru)
)
GO


--** INSERTA GRUPO DE PERSONA POR DEFECTO
INSERT INTO adp001 VALUES (1, 'Clientes', 'H')
INSERT INTO adp001 VALUES (20, 'Empleados', 'H')
INSERT INTO adp001 VALUES (30, 'Proveedores', 'H')
INSERT INTO adp001 VALUES (40, 'Socios', 'H')
