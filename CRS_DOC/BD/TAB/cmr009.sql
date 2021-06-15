/*--**********************************************
ARCHIVO:	cmr009.sql
TABLA:		Tabla de Encabezado de proforma
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		28-05-2021
*/--**********************************************

CREATE TABLE cmr009
(
--Llaves primarias
va_doc_prf		CHAR(03)		NOT NULL,	--Documento de proforma
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_prf		INT				NOT NULL,	--Numero de documento
va_ges_prf		SMALLINT		NOT NULL,	--Gestión de la proforma (adm002) (4 numeros)
va_ide_prf		VARCHAR(20)		NOT NULL,	--Identificador de la proforma (XXX|000-00000/2018)

--Llave Foránea
va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del cliente (adm010) (7 numeros)
va_raz_soc		VARCHAR(180)			,	--Razon social del cliente 
va_nit_prf		VARCHAR(15)				,	--Nit del cliente
va_fec_prf		DATE					,	--Fecha del proforma
va_fec_val		DATE					,	--Fecha de valides
va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

--Llave Foránea
va_cod_plv		INT						,	--Plantilla de proforma
va_cod_ven		SMALLINT				,	--Codigo de vendedor (cmr003) (4 numeros)

va_mon_prf		CHAR(1)					,	--Moneda de la proforma  (B=Bolivianos; U= Dolares)
va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

--Llaves Foráneas
va_cod_caj		INT						,	--Codigo de la caja para proformas al contado (5 numeros)
va_cod_lcr		INT						,	--Libreta para proformas al credito (5 numeros)

va_ref_prf		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si el proforma es hecha en base a una cotizacion u otro)

--Llaves Foráneas
va_cod_bod		CHAR(06)				,	--Codigo del almacen (7 numeros)
va_cod_lis		INT						,	--Codigo de lista (7 numeros)
va_prf_par		CHAR(01)				,	-- proforma para (M=Mesa ; D=Delivery ; L=Llevar)

va_cod_del		INT						,	-- Codigo del delivery
va_por_del		DECIMAL(3,1)			,	-- Porcentaje correspondiente al delivery


va_sub_toB		DECIMAL(16,5)			,	--Sub total de la proforma Bolivianos
va_sub_toU		DECIMAL(16,5)			,	--Sub total de la proforma Dolares
va_dto_vtB		DECIMAL(16,5)			,	--Descuento de la proforma Bs
va_dto_vtU		DECIMAL(16,5)			,	--Descuento de la proforma Us
va_tot_vtB		DECIMAL(16,5)			,	--Total de la proforma Bs
va_tot_vtU		DECIMAL(16,5)			,	--Total de la proforma Us

va_obs_prf		VARCHAR(180)			,	--Observacion de la proforma

va_usr_reg		VARCHAR(15)				,	--Usuario que registro la proforma
va_fec_reg		DATETIME				,	--Fecha real del registro
va_usr_anu		VARCHAR(15)				,	--Usuario que anulo
va_fec_anu		DATETIME				,	--Fecha real del registro
va_est_ado		CHAR(01)					--Estado


CONSTRAINT pk1_cmr009 PRIMARY KEY(va_doc_prf,va_nro_tal,va_nro_prf,va_ges_prf)


)

