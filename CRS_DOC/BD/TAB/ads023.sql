/*########################################################
ARCHIVO:	ads023.sql
TABLA:		Tipo de cambio Bs/Ufv
AUTOR:		CHL
FECHA:		22/04/2021
########################################################*/

CREATE TABLE ads023
(
va_fec_buf		DATETIME					NOT NULL,	--Fecha bs / ufv
va_val_buf		DECIMAL(8,6)				NOT NULL	--Valor Bs / Ufv

CONSTRAINT pk1_ads023 PRIMARY KEY(va_fec_buf)
)