/*--**********************************************
ARCHIVO:	ctb007.sql
TABLA:		Tabla de dosificacion
AUTOR:		FVM-CREARSIS
FECHA:		05-07-2017
*/--**********************************************


CREATE TABLE ctb007(
	va_nro_aut DECIMAL(15,0)		NOT NULL,	--** Numero de Autorizació
	va_tip_fac INT					NOT NULL,	--** Tipo de Factuta (0=Computarizada; 1=Manual)
	va_fec_ini DATE					NOT NULL,	--** Fecha de tramite dosificacion
	va_fec_fin DATE					NOT NULL,	--** Fecha limite de factura
	va_nro_ini INT					NOT NULL,	--** Numero unicial
	va_nro_fin INT					NOT NULL,	--** Numero final
	va_cod_suc INT					NOT NULL,	--** Codigo de sucursal
	va_cod_act INT					NOT NULL,	--** Cosigo de Actividad Economica
	va_cod_ley INT					NOT NULL,	--** Codigo Leyenda
	va_lla_vee VARCHAR(500)			NULL,		--** Llave dosificacion	
	va_con_act INT					NOT NULL,	--** Contador Actual de la factura

CONSTRAINT pk1_ctb007 PRIMARY KEY(va_nro_aut)
)

GO