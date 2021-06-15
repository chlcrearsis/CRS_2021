/*--**********************************************
ARCHIVO:	cmr002.sql
TABLA:		Tabla Detalle de Precios
AUTOR:		CHL-CREARSIS-ALDA
FECHA:		11/01/2018
*/--**********************************************

CREATE TABLE cmr002
(
va_cod_lis		INT				NOT NULL,	--Codigo del la lista(cmr001)(8 numeros)
va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo de Producto(inv002)
va_pre_cio		DECIMAL(10,5)	NOT NULL,	--Precio del Producto
va_pmx_des		DECIMAL(4,2)	NOT NULL,	--Porcentaje maximo de descuento permitido
va_pmx_inc		DECIMAL(4,2)	NOT NULL,	--Porcentaje maximo de incremento permitido
va_por_cal		DECIMAL(4,2)	NOT NULL,	--Porcentaje de utilidad(Ganancia) calculado
 
CONSTRAINT pk1_cmr002 PRIMARY KEY(va_cod_lis,va_cod_pro)
)
