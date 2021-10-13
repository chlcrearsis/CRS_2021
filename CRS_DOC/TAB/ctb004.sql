/*--**********************************************
ARCHIVO:	ctb004.sql
TABLA:		Plan de Cuentas
AUTOR:		CHL-CREARSIS
FECHA:		26-08-2021
*/--**********************************************
	
CREATE TABLE ctb004 
(
va_cod_cta		VARCHAR(12)		NOT NULL,	--Codigo Plan de Cuentas (#.#.##.##)(6 caracteres)
va_nom_cta		VARCHAR(40)		NOT NULL,	--Nombre Plan de Cuentas
va_tip_cta		CHAR(1)			NOT NULL,	--Tipo (M=Matriz ; A=Analitica)
va_uso_cta		CHAR(1)			NOT NULL,	--Uso (S=Sistema ; N=normal)
va_mon_cta		CHAR(1)			NOT NULL,	--Moneda (B=Bolivianos ; U=Dolares)
va_est_ado		CHAR(1)			NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_ctb004 PRIMARY KEY(va_cod_cta)
)
