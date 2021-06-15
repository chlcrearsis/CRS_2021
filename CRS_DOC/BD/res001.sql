/*--**********************************************
ARCHIVO:	res001.sql
TABLA:		Tabla de Encabezado de Vetas Restaurant
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		24-03-2017
*/--**********************************************
--drop table cmr005
CREATE TABLE res001
(
--Llaves primarias
va_doc_vta		CHAR(03)		NOT NULL,	--Documento de venta
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_vta		INT				NOT NULL,	--Numero de documento
va_ges_vta		SMALLINT		NOT NULL,	--Gestión de la venta (adm002) (4 numeros)
va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador de la venta (XXX|000-00000/2018)

--Llave Foránea
va_tip_vta		INT				NOT NULL,	--Tipo de venta ( 2= Nota de Venta ; 1=Factura )

va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del cliente (adm010) (7 numeros)
va_raz_soc		VARCHAR(180)			,	--Razon social del cliente 
va_nit_vta		VARCHAR(15)				,	--Nit del cliente
va_fec_vta		DATE					,	--Fecha de la venta
va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

--Llave Foránea
va_cod_plv		INT						,	--Plantilla de venta
va_cod_ven		SMALLINT				,	--Codigo de vendedor (cmr003) (4 numeros)

va_mon_vta		CHAR(1)					,	--Moneda de la venta  (B=Bolivianos; U= Dolares)
va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

--Llaves Foráneas
va_cod_caj		INT						,	--Codigo de la caja para ventas al contado (5 numeros)
va_cod_lcr		INT						,	--Libreta para ventas al credito (5 numeros)

va_ref_vta		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si la venta es hecha en base a una cotizacion u otro)

--Llaves Foráneas
va_cod_bod		CHAR(06)				,	--Codigo del almacen (7 numeros)
va_cod_lis		INT						,	--Codigo de lista (7 numeros)
va_vta_par		CHAR(01)				,	-- Venta para (M=Mesa ; D=Delivery ; L=Llevar)

va_cod_del		INT						,	-- Codigo del delivery
va_por_del		DECIMAL(3,1)			,	-- Porcentaje correspondiente al delivery


va_sub_toB		DECIMAL(16,5)			,	--Sub total de la venta Bolivianos
va_sub_toU		DECIMAL(16,5)			,	--Sub total de la venta Dolares
va_dto_vtB		DECIMAL(16,5)			,	--Descuento de la venta Bs
va_dto_vtU		DECIMAL(16,5)			,	--Descuento de la venta Us
va_tot_vtB		DECIMAL(16,5)			,	--Total de la venta Bs
va_tot_vtU		DECIMAL(16,5)			,	--Total de la venta Us

va_obs_vta		VARCHAR(180)			,	--Observacion de la venta

va_usr_reg		VARCHAR(15)				,	--Usuario que registro la venta
va_fec_reg		DATETIME				,	--Fecha real del registro
va_usr_anu		VARCHAR(15)				,	--Usuario que anulo
va_fec_anu		DATETIME				,	--Fecha real del registro
va_est_ado		CHAR(01)					--Estado


CONSTRAINT pk1_res001 PRIMARY KEY(va_doc_vta,va_nro_tal,va_nro_vta,va_ges_vta)


)

