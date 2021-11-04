
/*--**********************************************
ARCHIVO:	ecp001.sql
TABLA:		Plan de Pago
AUTOR:		CHL-CREARSIS
FECHA:		10-10-2021
*/--**********************************************
	
CREATE TABLE ecp001 
(
va_cod_plg		INT				NOT NULL,	--Código Plan de Pago (3 Numeros)
va_des_plg		VARCHAR(50)		NOT NULL,	--Descripcion
va_nro_cuo		TINYINT			NOT NULL,	--Numero de Cuotas (2 numeros)
va_int_dia		TINYINT			NOT NULL,	--Intervalo de Dias entre Cuotas (2 numeros)
va_dia_ini		TINYINT			NOT NULL,	--dia inicial p/primer cuota (2 numeros)
va_est_ado		CHAR(1)			NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_ecp001 PRIMARY KEY(va_cod_plg)
)
