/*--**********************************************
ARCHIVO:	ecp002.sql
TABLA:		Libreta
AUTOR:		CHL-CREARSIS(ALDA)
FECHA:		03-12-2017
*/--**********************************************

CREATE TABLE ecp002 
(
va_cod_lib		INT				NOT NULL,	--Código de la Libreta(5 Numeros)
va_des_lib		VARCHAR(50)		NOT NULL,	--Descripcion

--Llave foranea
va_cod_cta		VARCHAR(12)		NOT NULL,	--Cod. Cuenta Contable

va_tip_lib		INT				NOT NULL,	--Tipo (1=CxC('Cuentas por Cobrar') ; 2=CxP('Cuentas por Pagar')
va_mon_lib		CHAR(1)			NOT NULL,	--Moneda (B=Bolivianos; U=USD)
va_est_ado		CHAR(1)			NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_ecp002 PRIMARY KEY(va_cod_lib)
)
