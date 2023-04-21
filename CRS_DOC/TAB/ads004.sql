/*--**********************************************
ARCHIVO:	ads004.sql	
TABLA:		Tabla de "Talonario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads004 : Talonario'
CREATE TABLE ads004
(
	--** Llave Primaria
	va_ide_doc	CHAR(03)	 NOT NULL DEFAULT(''),	--** ID. Documento
	va_nro_tal	INT			 NOT NULL DEFAULT(0),	--** Nro de Talonario
	--** Atributos
	va_nom_tal	VARCHAR(60)	 NOT NULL DEFAULT(''),	--** Nombre Talonario
	va_tip_tal	INT			 NOT NULL DEFAULT(0),	--** Tipo de Talonario (0=Manual; 1=Automatico)
	va_nro_aut	DEC(15,0)	 NOT NULL DEFAULT(''),	--** Número de Autorización
	va_for_mat	INT			 NOT NULL DEFAULT(0),	--** Formato de Impresión
	va_nro_cop	INT			 NOT NULL DEFAULT(0),	--** Nro. de Copias a Imprimir
	va_fir_ma1	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 1
	va_fir_ma2	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 2
	va_fir_ma3	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 3
	va_fir_ma4	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 4
	va_for_log	INT			 NOT NULL DEFAULT(0),	--** Formato de Logo	
												    --** 0=Razon Social de Empresa; 1=Logotipo 1
												    --** 2=Logotipo 2 ;3=Logotipo 3
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads004 PRIMARY KEY(va_ide_doc, va_nro_tal)
)
GO

--** INSERTA TALONARIO DEL SISTEMA POR DEFECTO

--* Modulo Inventario
INSERT INTO ads004 VALUES('CMP', 0, 'Compra en Bodega', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('AJI', 0, 'Ajuste de Ingreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('AJE', 0, 'Ajuste de Salida', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('AJC', 0, 'Ajuste al Costo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('TRA', 0, 'Traspaso entre Bodegas', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('OPD', 0, 'Orden de Producción', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')

--* Modulo Comercializacion
INSERT INTO ads004 VALUES('COT', 0, 'Cotización', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('PED', 0, 'Pedido', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VTS', 0, 'Nota de Venta', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VTF', 0, 'Factura', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VRS', 0, 'Nota de Venta Restaurant', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VRF', 0, 'Factura Restaurant', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('CON', 0, 'Nota de Consumo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')

--* Modulo Exigibles
INSERT INTO ads004 VALUES('CXC', 0, 'Ctas por Cobrar', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('CXP', 0, 'Ctas por Pagar', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 0, 'Diario Auxiliar Anual', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 1, 'Diario Auxiliar - Enero', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 2, 'Diario Auxiliar - Febrero', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 3, 'Diario Auxiliar - Marzo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 4, 'Diario Auxiliar - Abril', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 5, 'Diario Auxiliar - Mayo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 6, 'Diario Auxiliar - Junio', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 7, 'Diario Auxiliar - Julio', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 8, 'Diario Auxiliar - Agosto', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 9, 'Diario Auxiliar - Septiembre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 10, 'Diario Auxiliar - Octubre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 11, 'Diario Auxiliar - Noviembre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 12, 'Diario Auxiliar - Diciembre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')

--* Modulo Tesoreria
INSERT INTO ads004 VALUES('RIN', 0, 'Recibo de Ingreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('REG', 0, 'Recibo de Egreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('TIN', 0, 'Comprobante de Ingreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('TEG', 0, 'Comprobante de Egreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')