/*########################################################
ARCHIVO:	cmr013.sql
TABLA:		Registro de Nit
AUTOR:		CHL
FECHA:		30/08/2021
########################################################*/

CREATE TABLE cmr013
(
va_cod_per		INT				NOT NULL	DEFAULT(0),			--Codigo Persona ADP002
va_nit_per		BIGINT,											--Nit de la persona
va_raz_soc		VARCHAR(120)	NOT NULL	DEFAULT(''),		--Razon social de la persona
va_act_ual		INT				NOT NULL	DEFAULT(0)			--Nit recientemente usado (0=pasado; 1=renciente)

CONSTRAINT pk1_cmr013 PRIMARY KEY(va_cod_per,va_nit_per)
)

go
