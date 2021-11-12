/*--**********************************************
ARCHIVO:	ecp003.sql
TABLA:		Inscripción Personas-Libretas
AUTOR:		CHL-CREARSIS(CHL)
FECHA:		11-11-2021
*/--**********************************************
	
CREATE TABLE ecp003 
(
va_cod_lib		INT				NOT NULL,					--Código de la Libreta(ecp002)
va_cod_per		INT				NOT NULL	DEFAULT(''),	--ID. Persona 
va_cod_plg		INT				NOT NULL,					--Código Plan de Pago(ecp005)

va_mto_lim		DECIMAL(12,2)	NOT NULL	DEFAULT(0),		--Monto Limite
va_sal_act		DECIMAL(12,2)	NOT NULL	DEFAULT(0),		--Saldo Actual
va_max_cuo		INT				NOT NULL	DEFAULT(0),		--
va_fec_exp		DATE			NOT NULL,					--Fecha de Expiracion
va_est_ado		CHAR(01)		NOT NULL	DEFAULT(''),	--Estado de la inscripcion (H=habilitado N=Deshabilitado)

CONSTRAINT pk1_ecp003 PRIMARY KEY(va_cod_lib,va_cod_per,va_cod_plg)
)
