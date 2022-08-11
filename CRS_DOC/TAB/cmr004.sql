/*--**********************************************
ARCHIVO:	cmr004.sql
TABLA:		Tabla de Plantilla de Venta(leo)
AUTOR:		CHL-CREARSIS
FECHA:		21-02-2018
*/--**********************************************

CREATE TABLE cmr004
(
	va_cod_plv		SMALLINT		NOT NULL,	--Codigo de plantilla de venta (3 números)
	va_nom_plv		VARCHAR(30)		NOT NULL,	--Nombre de la plantilla
	va_des_plv		VARCHAR(120)	NOT NULL,	--Descripcion de la plantilla
	--LLAVE FORANEA
	va_cod_bod		INT						,	--Codigo de almacen (inv002) (##-##-###) -> compuesto por (va_cod_gru , va_nro_alm)	
	va_cam_bod		TINYINT					,	--Bandera cambia almacen ? (0=NO ; 1=SI)
	--LLAVE FORANEA
	va_cod_cli		VARCHAR(07)				,	--Cliente por defecto (adm013) (##-#####) (2 de Grup. Per y 5 de Persona)
	va_cod_caj		INT						,	--Caja para las ventas al contado (tes001) (5 Números)
	va_cam_caj		TINYINT					,	--Bandera cambia caja ? (0=NO ; 1=SI)
	--LLAVE FORANEA
	va_cod_lis		INT						,	--Lista de precio por defecto (cmr001)  (8 numeros)

	va_cam_lis		TINYINT					,	--Bandera, cambia lista ? (0=NO; 1=CAMBIA ; 2=Si o si la Asignada al cliente)
	va_mon_vta		CHAR(1)					,	--Moneda de la venta (B=Bolivianos; U= Dolares)
	va_cam_mon		TINYINT					,	--cambia moneda ? ( 0=NO; 1=CAMBIA; 2=Obtiene moneda de la lista fija)

	--LLAVE FORANEA
	va_cod_ven		SMALLINT				,	--Codigo del vendedor por defecto (cmr003) (4 numeros)
	va_cam_ven		TINYINT					,	--Cambia vendedor ? (0=NO; 1=CAMBIA; 2=Obtiene el asignado DEL cliente)

	va_cod_del		SMALLINT				,	--Codigo del delivery por defecto (cmr010) 
	va_cam_del		TINYINT					,	--Cambia delivery ? (0=NO; 1=CAMBIA)

	va_dia_ret		TINYINT					,	--Dias permitidos para ventas retrasadas ##
	va_for_pgo		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)
	va_cam_fpg		TINYINT					,	--Cambia forma de pago ? (0=NO; 1=CAMBIA)
	va_pgo_cta		TINYINT					,	--en la forma de pago Credito, Permite pago a cuenta ? (0=NO; 1= SI)
	va_ope_def		TINYINT					,	--Operacion por defecto (1=Factura; 2=Nota de Venta; 3=Pedido; 4=Cotizacion)

	--LLAVE FORANEA
	va_lib_cre		INT						,	--Codigo Libreta para ventas al credito (ecp006) (5 Numeros)
	va_lib_dev		INT						,	--Codigo Libreta para devoluciones de ventas (ecp006) (5 Numeros)

	va_bus_pro		TINYINT					,	--Busqueda rapida de producto por (0= no usa; 1=Codigo 2=nombre; 3= Descripcion; )
	va_des_srv		TINYINT					,	--Permite escribir descripcion en productos de servicio ? (0=NO; 1=SI)
	va_pro_rep		TINYINT					,	--Permite productos repetidos ? (0=NO; 1=SI)

	--LLAVE FORANEA
	va_doc_fac		CHAR(3)					,	--Documento factura (adm003) (3 Letras)
	va_tal_fac		TINYINT					,	--Talonario factura  (adm004) (2 numeros)
	va_doc_ntv		CHAR(3)					,	--Documento Nota de Venta (adm003) (3 Letras)
	va_tal_ntv		TINYINT					,	--Talonario Nota de venta (adm004) (2 numeros)
	va_doc_ped		CHAR(3)					,	--Documento Pedido (adm003) (3 Letras)
	va_tal_ped		TINYINT					,	--Talonario Pedido (adm004) (2 numeros)
	va_doc_cot		CHAR(3)					,	--Documento Cotizacion (adm003) (3 Letras)
	va_tal_cot		TINYINT					,	--Talonario Cotizacion (adm004) (2 numeros)
	va_doc_dcf		CHAR(3)					,	--Documento DeV C/F (adm003) (3 Letras)
	va_tal_dcf		TINYINT					,	--Talonario DeV C/F (adm004) (2 numeros)
	va_doc_dsf		CHAR(3)					,	--Documento DeV S/F (adm003) (3 Letras)
	va_tal_dsf		TINYINT					,	--Talonario DeV S/F (adm004) (2 numeros)
	va_doc_rei		CHAR(3)					,	--Documento Recibo de Ingreso (adm003) (3 Letras)
	va_tal_rei		TINYINT					,	--Talonario Recibo de Ingreso (adm004) (2 numeros)
	
	va_imp_fac		VARCHAR(80)				,	--Impresora por defecto para factura
	va_imp_ntv		VARCHAR(80)				,	--Impresora por defecto para Nota de venta
	va_imp_ped		VARCHAR(80)				,	--Impresora para pedido
	va_imp_cot		VARCHAR(80)				,	--Impresora para cotizacion
	va_imp_dcf		VARCHAR(80)				,	--Impresora para DeV C/F
	va_imp_dsf		VARCHAR(80)				,	--Impresora para DeV S/F
	va_ban_av1		TINYINT					,	--Imprime aviso de venta 1? (0=NO; 1=SI)
	va_imp_av1		VARCHAR(80)				,	--Impresora para aviso de venta 1
	va_ban_av2		TINYINT					,	--Imprime aviso de venta 2? (0=NO; 1=SI)
	va_imp_av2		VARCHAR(80)				,	--Impresora para aviso de venta 2
	va_ban_imp		TINYINT					,	--Bandera de impresion (0=No imprime; 1=Imprime directo ; 2=Pregunta para imprimir)

	va_est_ado		CHAR(01)					--Estado de la planilla de Venta


	CONSTRAINT pk1_cmr004 PRIMARY KEY(va_cod_plv)
)



