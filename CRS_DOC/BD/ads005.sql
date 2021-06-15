/*########################################################
ARCHIVO:	ads005.sql
TABLA:		Numerador de talonario
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads005
(
va_ide_doc		CHAR(03)		NOT NULL,	--Ide Documento
va_nro_tal		INT,						--Nro de Talonario
va_ges_tio		INT				NOT NULL,	--Gestion (año)
va_fec_ini		DATETIME		NOT NULL,	--Fecha inicial 
va_fec_fin		DATETIME		NOT NULL,	--Fecha final
va_nro_ini		INT				NOT NULL,	--Numero inicial
va_nro_fin		INT				NOT NULL,	--Numero final
va_con_tad		INT				NOT NULL,	--Contador

CONSTRAINT pk1_ads005 PRIMARY KEY(va_ide_doc,va_nro_tal,va_ges_tio)
)

go
