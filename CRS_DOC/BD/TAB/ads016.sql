/*########################################################
ARCHIVO:	ads016.sql
TABLA:		Gestion Periodos
AUTOR:		CHL
FECHA:		23/03/2020
########################################################*/

CREATE TABLE ads016
(
va_ges_tio 		INT				NOT NULL,	-- Gestion Año
va_ges_per		INT				NOT NULL,	-- Periodo Mes
va_nom_per		VARCHAR(15)		NOT NULL,	-- Nombre del periodo
va_fec_ini		DATE			NOT NULL,	-- Fecha inicial del periodo
va_fec_fin		DATE			NOT NULL,	-- Fecha final del periodo

CONSTRAINT pk1_ads016 PRIMARY KEY(va_ges_tio,
								  va_ges_per)
)

go	