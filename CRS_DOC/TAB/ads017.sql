/*--**********************************************
ARCHIVO:	ads017.sql	
TABLA:		Tabla de "PIN Usuario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		16-10-2020
*/--**********************************************

PRINT 'ads017 : PIN Usuario'
CREATE TABLE ads017 
(
	--** Llave Primaria
	va_ide_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** ID. Usuario

	--** Atributos     
	va_pin_usr	INT			 NOT NULL DEFAULT(0),	--** Pin usuario
	va_fec_reg	DATETIME	 NOT NULL,		        --** Fecha de registro pin
	va_fec_exp  DATETIME     NOT NULL,              --** Fecha de expiracion del pin
	va_nom_eqp	VARCHAR(20)  NOT NULL DEFAULT(''),	--** Nombre del equipo de donde se registro

CONSTRAINT pk1_ads017 PRIMARY KEY(va_ide_usr)
)
GO