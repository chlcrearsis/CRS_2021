/*--**********************************************
ARCHIVO:	cmr001.sql
TABLA:		Tabla Lista de Precios
AUTOR:		CHL-CREARSIS-ALDA
FECHA:		11/01/2018
*/--**********************************************

CREATE TABLE cmr001
(
va_cod_lis		INT			NOT NULL,	--Codigo del la lista(8 numeros)
va_nom_lis		VARCHAR(30)	NOT NULL,	--Nombre
va_mon_lis		CHAR(01)	NOT NULL,	--Moneda (B=Bolivianos; D=Dolares)
va_fec_ini		DATE		NOT NULL,	--Fecha inicio
va_fec_fin		DATE		NOT NULL,	--Fecha final
va_nro_dec		INT			NOT NULL,	--Nro. Decimales a trabajar
va_est_ado		CHAR(01)	NOT NULL	--Estado
 
CONSTRAINT pk1_cmr001 PRIMARY KEY(va_cod_lis)
)