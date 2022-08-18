/*--**********************************************
ARCHIVO:	ads018.sql	
TABLA:		Tabla de "Autorizacion Usuario s/Lista de Precio"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		27-10-2020
*/--**********************************************

PRINT 'ads019 : Autorizacion Usuario s/Lista de Precio'
CREATE TABLE ads019
(
	--** Llave Primaria
	va_ide_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** ID. Usuario
	va_cod_lis	INT			 NOT NULL DEFAULT(0),	--** Codigo de la Lista de Precio

CONSTRAINT pk1_ads019 PRIMARY KEY(va_ide_usr, va_cod_lis)
)
GO