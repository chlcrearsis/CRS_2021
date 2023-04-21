/*--**********************************************
ARCHIVO:	ads015.sql	
TABLA:		Tabla de "Gestión Periodos"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		23-03-2020
*/--**********************************************

PRINT 'ads016 : Gestión Periodos'
CREATE TABLE ads016
(
	--** Llave Primaria
	va_ges_tio 	INT			 NOT NULL DEFAULT(0),	--** Gestion Año
	va_ges_per	INT			 NOT NULL DEFAULT(0),	--** Periodo Mes
	--** Atributos     	
	va_nom_per	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Nombre del periodo
	va_fec_ini	DATE		 NOT NULL,	            --** Fecha inicial del periodo
	va_fec_fin	DATE		 NOT NULL,	            --** Fecha final del periodo

CONSTRAINT pk1_ads016 PRIMARY KEY(va_ges_tio, va_ges_per)
)
GO