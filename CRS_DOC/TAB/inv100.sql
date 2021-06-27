/*--**********************************************
ARCHIVO:	inv100.sql
TABLA:		Tabla de Movimiento de Inventario
AUTOR:		CREARSIS(Jorge)
FECHA:		04-02-2018
*/--*********************************************
	
CREATE TABLE inv100(
	va_ges_tio INT				NOT NULL,	--Código de Gestión
	va_cod_doc CHAR(3)			NOT NULL,	--Codigo del documento (XXX)
	va_nro_tal INT				NOT NULL,	--Numero de talonario(000)
	va_nro_doc INT				NOT NULL,	--Numero del documento
	va_ide_doc VARCHAR(20)		NOT NULL,	--Identificador del documento (XXX|000-00000/2018)
	va_nro_itm INT				NOT NULL,	--Número de item en el documento
	va_fec_doc DATETIME			NOT NULL,	--Fecha del documento
	va_fec_reg DATETIME			NOT NULL,	--Fecha de registro real
	va_ref_doc VARCHAR(20)				NOT NULL DEFAULT (''),		--Nro de Referencia ó Numero de Documento
	va_mon_eda CHAR(01)			NOT NULL,	--Moneda (B=Bolivianos; D=Dolares)
	va_glo_doc VARCHAR(100)		NOT NULL,	--Glosa del documento
	va_cod_pro VARCHAR(15)		NOT NULL,	--Codigo del Producto
	
	va_can_ing DECIMAL(14,4),				--Cantidad Ingreso en unidad inventario con signo(+)
	va_can_egr DECIMAL(14,4),				--Cantidad Egreso en unidad inventario con signo(-)
	
	va_cos_uoB DECIMAL(14,4),				--Costo Unitario de la operacion en bs
	va_cos_uoU DECIMAL(14,4),				--Costo Unitario de la operacion en Us
	
	va_cos_toB DECIMAL(14,4),				--Costo Total Operacion en bs
	va_cos_toU DECIMAL(14,4),				--Costo Total Operacion en Us
	
	va_cos_upB DECIMAL(14,4),				--Costo Unitario promediado en bs
	va_cos_upU DECIMAL(14,4),				--Costo Unitario promediado en Us
	
	va_cod_bod INT				NOT NULL,	--Codigo deL ALMACEN (inv011)
	va_lot_pro VARCHAR(50)		DEFAULT 0,	--Lote de producto
	va_tas_cam DECIMAL(6,4)		DEFAULT 0,	-- Tipo de Cambio de la Transaccion
	va_cod_usr NVARCHAR(15)		NOT NULL	--Codigo del Usuario
	
	CONSTRAINT pk1_inv100 PRIMARY KEY(va_ges_tio,va_cod_doc,va_nro_tal,va_nro_itm,va_fec_doc,va_fec_reg)
	)
	





