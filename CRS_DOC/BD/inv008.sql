/*--**********************************************
ARCHIVO:	inv008.sql
TABLA:		Tabla del Detalle de Compra
AUTOR:		CREARSIS(CHL)
FECHA:		20-09-2020
*/--********************************************* 
CREATE TABLE inv008(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_doc_doc		CHAR(03)		NOT NULL,	--Documento de Compra
	va_nro_tal		INT				NOT NULL,	--Numero de talonario
	va_nro_cmp		INT				NOT NULL,	--Numero de documento
	va_ges_cmp		SMALLINT		NOT NULL,	--Gestión de la compra (adm002) (4 numeros)
	va_ide_cmp		VARCHAR(20)		NOT NULL,	--Identificador de la compra (XXX|000-00000/2018)
	va_nro_itm		int				not null,	--Numero de item del Documento de Compra
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para la compra
	va_cod_uni		char(3)			null,		--Codigo de la Unidad de Medida  Inventario
	va_cod_unc		char(3)			null,		--Codigo de la Unidad de Medida  Compra
	va_can_uiv		DECIMAL(14,4),				--Cantidad unidad inventario
	va_can_ucm		DECIMAL(14,4),				--Cantidad unidad compra
	va_pre_uBs		DECIMAL(14,4),				--Precio Unitario Bs (en unidad de inventario)
	va_pre_uUs		DECIMAL(14,4),				--Precio Unitario Us (en unidad de inventario)
	va_imp_tBs		DECIMAL(16,2),				--Importe Total BS.(Importe Total + Importe de Gastos)
	va_imp_tUs		DECIMAL(16,2),				--Importe Total US.(Importe Total + Importe de Gastos)
	va_des_uni		DECIMAL(16,2),				--Descuento prorateado en moneda del documento
	va_lot_cod		varchar(50)		DEFAULT 0,	--Código de Lote
	va_ser_cod		varchar(50)		DEFAULT 0,	--Código de serie
	
CONSTRAINT PK_inv008 PRIMARY KEY ( va_doc_doc, va_nro_tal,va_nro_cmp, va_ges_cmp, va_ide_cmp, va_nro_itm)
)

GO