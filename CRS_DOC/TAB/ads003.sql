/*--**********************************************
ARCHIVO:	ads003.sql	
TABLA:		Tabla de "Documentos"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads003 : Documentos'
CREATE TABLE ads003
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo
	va_ide_doc	CHAR(03)	 NOT NULL DEFAULT(''),	--** ID. Documento
	--** Atributos
	va_nom_doc	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_des_doc	VARCHAR(120) NOT NULL DEFAULT(''),	--** Descripción
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads003 PRIMARY KEY(va_ide_mod, va_ide_doc)
)
GO

--** INSERTA DOCUMENTOS DEL SISTEMA POR DEFECTO
--* Modulo Inventario
INSERT INTO ads003 VALUES(2, 'CMP', 'Compra en Bodega', '', 'H')
INSERT INTO ads003 VALUES(2, 'AJI', 'Ajuste de Ingreso', '', 'H')
INSERT INTO ads003 VALUES(2, 'AJE', 'Ajuste de Salida', '', 'H')
INSERT INTO ads003 VALUES(2, 'AJC', 'Ajuste al Costo', '', 'H')
INSERT INTO ads003 VALUES(2, 'TRA', 'Traspaso entre Bodegas', '', 'H')
INSERT INTO ads003 VALUES(2, 'OPD', 'Orden de Producción', '', 'H')

--* Modulo Comercializacion
INSERT INTO ads003 VALUES(3, 'COT', 'Cotización', '', 'H')
INSERT INTO ads003 VALUES(3, 'PED', 'Pedido', '', 'H')
INSERT INTO ads003 VALUES(3, 'VTS', 'Nota de Venta', '', 'H')
INSERT INTO ads003 VALUES(3, 'VTF', 'Factura', '', 'H')
INSERT INTO ads003 VALUES(3, 'VRS', 'Nota de Venta Restaurant', '', 'H')
INSERT INTO ads003 VALUES(3, 'VRF', 'Factura Restaurant', '', 'H')
INSERT INTO ads003 VALUES(3, 'CON', 'Nota de Consumo', '', 'H')

--* Modulo Exigibles
INSERT INTO ads003 VALUES(4, 'CXC', 'Ctas por Cobrar', '', 'H')
INSERT INTO ads003 VALUES(4, 'CXP', 'Ctas por Pagar', '', 'H')
INSERT INTO ads003 VALUES(4, 'DAU', 'Diario Auxiliar', '', 'H')

--* Modulo Tesoreria
INSERT INTO ads003 VALUES(5, 'RIN', 'Recibo de Ingreso', '', 'H')
INSERT INTO ads003 VALUES(5, 'REG', 'Recibo de Egreso', '', 'H')
INSERT INTO ads003 VALUES(5, 'TIN', 'Comprobante de Ingreso', '', 'H')
INSERT INTO ads003 VALUES(5, 'TEG', 'Comprobante de Egreso', '', 'H')

