/*--**********************************************
ARCHIVO:	inv007.sql
TABLA:		Tabla del Documento de Compra(Cabecera)
AUTOR:		CREARSIS(Jorge)
FECHA:		15-02-2018
*/--*********************************************
	
CREATE TABLE inv007(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_doc_doc		CHAR(03)		NOT NULL,	--Documento de Compra
	va_nro_tal		INT				NOT NULL,	--Numero de talonario
	va_nro_cmp		INT				NOT NULL,	--Numero de documento
	va_ges_cmp		SMALLINT		NOT NULL,	--Gestión de la compra (adm002) (4 numeros)
	va_ide_cmp		VARCHAR(20)		NOT NULL,	--Identificador de la compra (XXX|000-00000/2018)

	--Llave Foránea
	va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del Proveedor (cmr013) (7 numeros)
	va_raz_soc		VARCHAR(180)			,	--Razon social del proveedor 
	va_fec_cmp		DATE					,	--Fecha de la compra
	va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

	va_mon_cmp		CHAR(1)					,	--Moneda de la compra  (B=Bolivianos; U= Dolares)
	va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

	va_cod_caj		INT						,	--Codigo de la caja/banco para compra al contado (5 numeros)
	va_cod_lcr		INT						,	--Libreta x pagar para compras al credito (5 numeros)
	va_ref_cmp		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si la compra es hecha en base a una cotizacion u otro)

	va_cod_bod		INT						,	--Codigo del bodega (7 numeros)

	va_tip_cmp		INT						,	-- Tipo de Compra [0=Sin Fac. ; 1=Con Fac.]
	va_ban_fac		INT						,	-- Bandera Factura [0=NO  ; 1=SI hay  ; 2= Por Recuperar]
	va_lib_cpr		INT						,	-- Libreta Credito Fiscal por Recuperar (en caso que va_ban_fac=2) (5 numeros)
	
	va_fec_emi		datetime not null		,	-- Fecha de Emision(este campo aplica mas para las factura)
	va_tot_bBs		decimal(16,2) not null	,	-- Valor Bruto en Bs. de la Compra
	va_tot_bUs		decimal(16,2) not null	,	-- Valor Bruto en Us. de la Compra
	va_des_cBs		decimal(14,2) not null default 0, -- Valor del Descuento en Bs. de la Compra
	va_des_cUs		decimal(14,2) not null default 0, -- Valor del Descuento en Us. de la Compra
	va_tot_nBs		decimal(16,2) not null default 0, -- Valor Neto en Bs. de la Compra
	va_tot_nUs		decimal(16,2) not null default 0, -- Valor Neto en Us. de la Compra
	va_obs_cmp		nvarchar(100) not null default '', -- Observacion de la Compra
	--Datos Impositivos en Bs.
	va_nro_fac		int not null default 0,				-- Nro. de Factura
	va_nit_fac		bigint not null default 0,			-- NIT del Proveedor 
	va_raz_fac		nvarchar(100) null default '',		-- Razon Social del Proveedor
	va_nro_aut		varchar(20) null,					-- Nro. de Autorizacion
	va_cod_ctr		varchar(20) null,					-- Codigo de Control
	va_tot_exe		decimal(16,2) not null default 0,	--Total Valor Exento
	va_tot_suj		decimal(16,2) not null default 0,	-- Total Sujeto a Impuestos
	va_tot_imp		decimal(14,2) not null default 0,	--Valor de impuesto IVA 13%
	va_rim_itr		decimal(12,2) not null default 0,	-- Total de la Retencion de IT 3%
	va_riu_bie		decimal(12,2) not null default 0,	-- Total de la Retencion de IUE para Bienes 5%
	va_riu_ser		decimal(12,2) not null default 0,	-- Total de la Retencion de IUE para Servicios 12.5 %
	va_rie_alq		decimal(12,2) not null default 0,	-- Total de la Retencion de IUE para Alquileres 13 %

	va_usr_reg		VARCHAR(15)				,			--Usuario que registro la compra
	va_fec_reg		DATETIME				,			--Fecha real del registro
	va_usr_anu		VARCHAR(15)				,			--Usuario que anulo
	va_fec_anu		DATETIME				,			--Fecha real de la anulacion
	va_fec_cer		DATETIME,							--Fecha que fue Cerrado el Documento	
	va_est_ado		CHAR(01)							--Estado H=Abierto,C=Cerrado,A=Anulado
	
	CONSTRAINT pk1_inv007 PRIMARY KEY(va_doc_doc,va_nro_tal,va_nro_cmp,va_ges_cmp)
)




