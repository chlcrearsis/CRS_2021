/*--**********************************************
ARCHIVO:	cmr006.sql
TABLA:		Tabla de Detalle de Venta
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		26-02-2018
*/--**********************************************
--drop table cmr006
CREATE TABLE cmr006
(
-- Llaves primarias
va_doc_vta		CHAR(03)		NOT NULL,	--Documento de venta
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_vta		INT				NOT NULL,	--Numero de documento
va_ges_vta		SMALLINT		NOT NULL,	--Gestión de la venta
va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador de la venta (XXX|000-00000/2018)
va_itm_vta		INT				NOT NULL,	--Nro de item de la venta

va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del producto
va_des_pro		VARCHAR(200)	NOT NULL,	--Nombre/Descripcion del producto

va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para la venta
											  -- (1= Unidad de medida Venta ; 2= Unidad de medida inventario)

va_und_vta		CHAR(03)		NOT NULL,	--Unidad de medida Venta											  
va_und_inv		CHAR(03)		NOT NULL,	--Unidad de medida Inventario
va_eqv_und		DECIMAL(6,2)	NOT NULL,	--equivalencia de la Und en la venta con la Und. inventario

va_can_unv		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Venta) solo para fin de calculo
va_can_uni		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Inventario)la que da de baja al inventario

va_pre_lis		DECIMAL(15,5)	NOT NULL,	--Precio de lista en la moneda de la venta

va_mto_brB		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Bs
va_mto_brU		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Us
va_val_dtB		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Bs
va_val_dtU		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Us
va_por_dto		DECIMAL(15,5)	NOT NULL,	--porcentaje de descuento proporcionado
va_mto_neB		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Bs
va_mto_neU		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Us

va_cto_uBS		DECIMAL(15,5)	NOT NULL,	--Costo Unitario en Bs
va_cto_uUS		DECIMAL(15,5)	NOT NULL,	--Costo Unitario en Us

va_iva_uBS		DECIMAL(15,5)	NOT NULL,	--IVA Unitario en Bs
va_iva_uUS		DECIMAL(15,5)	NOT NULL,	--IVA Unitario en Us
va_itr_uBS		DECIMAL(15,5)	NOT NULL,	--ITR Unitario en Bs
va_itr_uUS		DECIMAL(15,5)	NOT NULL	--ITR Unitario en Us

	
	

CONSTRAINT pk1_cmr006 PRIMARY KEY(va_doc_vta,va_nro_tal,va_nro_vta,va_itm_vta)
)

