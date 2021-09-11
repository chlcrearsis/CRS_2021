/*--**********************************************
ARCHIVO:	ctb003.sql
TABLA:		Tabla Centro de Costos
AUTOR:		CHL-CREARSIS
FECHA:		26-08-2021
*/--**********************************************

CREATE TABLE ctb003
(
--Llave Primaria
va_cod_cct		SMALLINT		NOT NULL,	--Codigo del centro de Costos (4 numeros)

--Atributos
va_nom_cct		VARCHAR(50)		NOT NULL,	--Nombre del centro de Costos
va_tip_cct		CHAR(01)		NOT NULL,	--Tipo del centro de Costos (M=Matriz; A=Analitica)
va_est_ado		CHAR(01)		NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)	
 
CONSTRAINT pk1_ctb003 PRIMARY KEY(va_cod_cct)
)