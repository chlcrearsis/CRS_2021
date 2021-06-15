/*--**********************************************
ARCHIVO:	cmr006tmp.sql
TABLA:		Tabla detalle de VENTA RESTAURANT temporal
AUTOR:		CREARSIS(chl)
FECHA:		12-10-2018
*/--*********************************************
CREATE TABLE cmr006tmp(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)

	--Llave Foránea
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto	 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento (digitado x usuario)
	va_pre_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento (va_pre_uni * va_can_tid
	
	va_pre_lis		DECIMAL(14,4),				--Precio definido en la lista de precio
	va_des_cue		DECIMAL(14,4),				--Descuento en moneda del documento
	va_por_cen		DECIMAL(14,4),				--Porcentaje de descuento
	
		
		
	CONSTRAINT pk1_cmr006tmp PRIMARY KEY(va_cod_usr,va_cod_tmp,va_nro_itm)

)