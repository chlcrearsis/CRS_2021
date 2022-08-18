/*--**********************************************
ARCHIVO:	ads023.sql	
TABLA:		Tabla de "Tipo de Cambio Bs/Ufv"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		22-04-2021
*/--**********************************************

PRINT 'ads023 : Tipo de Cambio Bs/Ufv'
CREATE TABLE ads023
(
	--** Llave Primaria
	va_fec_buf	DATETIME	 NOT NULL,				--** Fecha T.C (Bs; Ufv)
	--** Atributos     	
	va_val_buf	DEC(8,6)  	 NOT NULL DEFAULT(0)	--** Valor (Bs; Ufv)

CONSTRAINT pk1_ads023 PRIMARY KEY(va_fec_buf)
)
GO