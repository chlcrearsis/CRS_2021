/*--**********************************************
ARCHIVO:	adp010.sql	
TABLA:		Tabla de "Descuento General p/Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		14-07-2022
*/--**********************************************

PRINT 'adp010 : Descuento General p/Persona'
CREATE TABLE adp010 
(
	--** Llave Primaria
	va_cod_per	INT			 NOT NULL DEFAULT(0),	--** Codigo Persona (2 de Grup. Per y 5 de Persona)

	--** Atributos     
	va_tip_fac	CHAR(01)	 NOT NULL DEFAULT(''),	--** p/Factura (S=Si; N=No)
	va_tip_ndv	CHAR(01)	 NOT NULL DEFAULT(''),	--** p/Nota de Venta (S=Si; N=No)
	va_por_con  DEC(14,2)    NOT NULL DEFAULT(0),   --** Porcentajde de Descuento al Contado
	va_por_cre  DEC(14,2)    NOT NULL DEFAULT(0),   --** Porcentajde de Descuento al Crédito

CONSTRAINT pk1_adp010 PRIMARY KEY(va_cod_per)
)
GO
