/*--**********************************************
ARCHIVO:	ads012.sql	
TABLA:		Tabla de "Restriccion Men�"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads012 : Restriccion Men�'
CREATE TABLE ads012
(
	--** Llave Primaria
	va_ide_usr  VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_ide_apl	VARCHAR(20)	 NOT NULL DEFAULT(''),	--** ID. Aplicaci�n
	va_ide_mnu	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** ID. Men�

CONSTRAINT pk1_ads012 PRIMARY KEY(va_ide_usr, va_ide_apl, va_ide_mnu)
)
GO
