/*--**********************************************
ARCHIVO:	ads022.sql	
TABLA:		Tabla de "Tipo de Cambio Bs/Us"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		22-04-2021
*/--**********************************************

PRINT 'ads022 : Tipo de Cambio Bs/Us'
CREATE TABLE ads022
(
	--** Llave Primaria
	va_fec_bus	DATETIME	 NOT NULL,				--** Fecha T.C (Bs; Us)
	--** Atributos     	
	va_val_bus	DEC(8,6)  	 NOT NULL DEFAULT(0)	--** Valor (Bs; Us)

CONSTRAINT pk1_ads022 PRIMARY KEY(va_fec_bus)
)
GO