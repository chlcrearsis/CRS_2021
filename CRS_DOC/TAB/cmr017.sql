/*--**********************************************
ARCHIVO:	cmr017.sql	
TABLA:		Tabla de " Detalle de comision"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		15/09/2021
*/--**********************************************

CREATE TABLE cmr017 
(
--** Llave Primaria
va_cod_ven		SMALLINT			NOT NULL,		--** Codigo Vendedor(4 numeros)
va_ite_cms		VARCHAR(15)			NOT NULL,		--** Codigo Familia/Producto
--** Atributos     
va_cms_con		DECIMAL(4,2)		NOT NULL,		--** Porcentaje comision al contado
va_cms_cre		DECIMAL(4,2)		NOT NULL,		--** Porcentaje comision al credito      

CONSTRAINT pk1_cmr017 PRIMARY KEY(va_cod_ven, va_ite_cms)
)
GO
     