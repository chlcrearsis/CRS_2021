/*--**********************************************
ARCHIVO:	ads005.sql	
TABLA:		Tabla de "Numerador de Talonario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads005 : Numerador de Talonario'
CREATE TABLE ads005
(
	--** Llave Primaria
	va_ges_tio	INT			 NOT NULL DEFAULT(0),	--** Gestión
	va_ide_doc	CHAR(03)	 NOT NULL DEFAULT(''),	--** ID. Documento
	va_nro_tal	INT			 NOT NULL DEFAULT(0),	--** Nro de Talonario
	--** Atributos
	va_fec_ini	DATETIME	 NOT NULL,	            --** Fecha Inicial 
	va_fec_fin	DATETIME	 NOT NULL,	            --** Fecha Final	
	va_con_act	INT			 NOT NULL DEFAULT(0),	--** Contador Actual
	va_con_fin	INT			 NOT NULL DEFAULT(0),	--** Contador Final	

	CONSTRAINT pk1_ads005 PRIMARY KEY(va_ges_tio, va_ide_doc, va_nro_tal)
)
GO
