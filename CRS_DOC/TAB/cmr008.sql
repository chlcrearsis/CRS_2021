/*--**********************************************
ARCHIVO:	cmr008.sql
TABLA:		Tabla de Detalle de Pedido
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		12-03-2021
*/--**********************************************
--drop table cmr008
CREATE TABLE cmr008
(
-- Llaves primarias
va_doc_ped		CHAR(03)		NOT NULL,	--Documento de Pedido
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_ped		INT				NOT NULL,	--Numero de documento
va_ges_ped		SMALLINT		NOT NULL,	--Gestión de el Pedido
va_ide_ped		VARCHAR(20)		NOT NULL,	--Identificador de el Pedido (XXX|000-00000/2018)
va_itm_ped		INT				NOT NULL,	--Nro de item de el Pedido

va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del producto
va_des_pro		VARCHAR(200)	NOT NULL,	--Nombre/Descripcion del producto

va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para el Pedido
											  -- (1= Unidad de medida Pedido ; 2= Unidad de medida inPedidorio)

va_und_ped		CHAR(03)		NOT NULL,	--Unidad de medida Pedido											  
va_und_inv		CHAR(03)		NOT NULL,	--Unidad de medida InPedidorio
va_eqv_und		DECIMAL(6,2)	NOT NULL,	--equivalencia de la Und en el Pedido con la Und. inPedidorio

va_can_unv		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Pedido) solo para fin de calculo
va_can_uni		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad InPedidorio)la que da de baja al inPedidorio

va_pre_lis		DECIMAL(15,5)	NOT NULL,	--Precio de lista en la moneda de el Pedido

va_mto_brB		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Bs
va_mto_brU		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Us
va_val_dtB		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Bs
va_val_dtU		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Us
va_por_dto		DECIMAL(15,5)	NOT NULL,	--porcentaje de descuento proporcionado
va_mto_neB		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Bs
va_mto_neU		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Us

	

CONSTRAINT pk1_cmr008 PRIMARY KEY(va_doc_ped,va_nro_tal,va_nro_ped,va_itm_ped)
)

