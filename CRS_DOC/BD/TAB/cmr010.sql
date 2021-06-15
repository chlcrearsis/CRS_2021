/*--**********************************************
ARCHIVO:	cmr010.sql
TABLA:		Tabla de Detalle de proforma
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		28-05-2021
*/--**********************************************

CREATE TABLE cmr010
(
-- Llaves primarias
va_doc_prf		CHAR(03)		NOT NULL,	--Documento de proforma
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_prf		INT				NOT NULL,	--Numero de documento
va_ges_prf		SMALLINT		NOT NULL,	--Gestión de el proforma
va_ide_prf		VARCHAR(20)		NOT NULL,	--Identificador de la proforma (XXX|000-00000/2018)
va_itm_prf		INT				NOT NULL,	--Nro de item de el proforma

va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del producto
va_des_pro		VARCHAR(200)	NOT NULL,	--Nombre/Descripcion del producto

va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para la proforma
											  -- (1= Unidad de medida venta ; 2= Unidad de medida inventario)

va_und_prf		CHAR(03)		NOT NULL,	--Unidad de medida venta											  
va_und_inv		CHAR(03)		NOT NULL,	--Unidad de medida Inventario
va_eqv_und		DECIMAL(6,2)	NOT NULL,	--equivalencia de la Und en el proforma con la Und. inproformario

va_can_unv		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad proforma) solo para fin de calculo
va_can_uni		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Inventario)la que da de baja al inproformario

va_pre_lis		DECIMAL(15,5)	NOT NULL,	--Precio de lista en la moneda de el proforma

va_mto_brB		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Bs
va_mto_brU		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Us
va_val_dtB		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Bs
va_val_dtU		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Us
va_por_dto		DECIMAL(15,5)	NOT NULL,	--porcentaje de descuento proporcionado
va_mto_neB		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Bs
va_mto_neU		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Us

	

CONSTRAINT pk1_cmr010 PRIMARY KEY(va_doc_prf,va_nro_tal,va_nro_prf,va_itm_prf)
)

