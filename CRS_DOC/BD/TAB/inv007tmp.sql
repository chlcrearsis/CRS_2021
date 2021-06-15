/*--**********************************************
ARCHIVO:	inv007tmp.sql
TABLA:		Tabla detalle de compra temporal
AUTOR:		CREARSIS(chl)
FECHA:		20-09-2020
*/--*********************************************
-- select * from inv007tmp
CREATE TABLE inv007tmp(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)

	--Llave Foránea
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_und_cmp		char(3)			null,		--Codigo de la Unidad de Medida
	va_can_cmp		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
												--(S=Servicio ; D=Detalle; C=Combo)
	
	CONSTRAINT pk1_inv007tmp PRIMARY KEY(va_cod_usr,va_cod_tmp,va_nro_itm)

)