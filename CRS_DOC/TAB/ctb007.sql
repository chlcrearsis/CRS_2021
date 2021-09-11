/*--**********************************************
ARCHIVO:	ctb007.sql
TABLA:		Tabla de dosificacion
AUTOR:		FVM-CREARSIS
FECHA:		05-07-2017
*/--**********************************************


CREATE TABLE ctb007(
	va_nro_aut DECIMAL(15,0)	 NOT NULL,
	va_tip_fac int NOT NULL,		--//0=Computarizada; 1=Manual
	va_fec_ini date NOT NULL,
	va_fec_fin date NOT NULL,
	va_nro_ini int NOT NULL,
	va_nro_fin int NOT NULL,
	va_cod_suc tinyint NOT NULL,	--2 numeros
	va_cod_act tinyint NOT NULL,	--1 numeros
	va_cod_ley tinyint NOT NULL,	--2 numeros
	va_lla_vee varchar(500) NULL,
	va_est_ado char(1) NOT NULL,
	va_con_tad int	   NOT NULL,	-- Contador de factura

CONSTRAINT pk1_ctb007 PRIMARY KEY(va_nro_aut)
)

GO