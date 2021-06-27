/*########################################################
ARCHIVO:	ads022.sql
TABLA:		Tipo de cambio Bs/Us
AUTOR:		CHL
FECHA:		22/04/2021
########################################################*/

CREATE TABLE ads022
(
va_fec_bus		DATETIME					NOT NULL,	--Nombre modulo
va_val_bus		DECIMAL(8,6)				NOT NULL	--Ide Modulo

CONSTRAINT pk1_ads022 PRIMARY KEY(va_fec_bus)
)