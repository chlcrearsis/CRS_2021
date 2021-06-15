/*--**********************************************
ARCHIVO:	cmr014.sql	
TABLA:		Tabla de "Vendedor"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		15/09/2020
*/--**********************************************

CREATE TABLE cmr014 
(
--** Llave Primaria
va_cod_ven		SMALLINT			NOT NULL,		--** Codigo del Vendedor(4 numeros)

--** Atributos     
va_nom_ven		VARCHAR(50)			NOT NULL,		--** Nombre del Vendedor
va_por_cms		DECIMAL(4,2)		NOT NULL,		--** Porcentaje Comisión
va_tip_cms		TINYINT				NOT NULL,		--** Tipo comisión (0=Ventas, 1=Cobranzas)
va_est_ado		CHAR(01)			NOT NULL,		--** Estado del Vendedor
      

CONSTRAINT pk1_cmr014 PRIMARY KEY(va_cod_ven)
)
GO
     
     