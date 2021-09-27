/*########################################################
ARCHIVO:	ads003.sql
TABLA:		Documentos
AUTOR:		CHL
FECHA:		21/08/2019
########################################################*/

CREATE TABLE ads003
(
va_ide_mod		INT				NOT NULL,	--Ide Modulo
va_ide_doc		CHAR(03)		NOT NULL,	--Ide Documento
va_nom_doc		VARCHAR(30)		NOT NULL,	--Nombre Documento
va_des_doc		VARCHAR(120)			,	-- Descipcion Documento
va_est_ado		CHAR(01)		NOT NULL,	--Estado

CONSTRAINT pk1_ads003 PRIMARY KEY(va_ide_mod,va_ide_doc)
)

go


--* Modulo Inventario
INSERT INTO ads003 VALUES(2,'CMP','Compra en Bodega','','H')
INSERT INTO ads003 VALUES(2,'AJI','Ajuste de ingreso','','H')
INSERT INTO ads003 VALUES(2,'AJE','Ajuste de salida','','H')
INSERT INTO ads003 VALUES(2,'AJC','Ajuste al costo','','H')
INSERT INTO ads003 VALUES(2,'TRA','Traspaso entre bodegas','','H')
INSERT INTO ads003 VALUES(2,'OPD','Orden de Producción','','H')

--* Modulo Comercializacion
INSERT INTO ads003 VALUES(3,'COT','Cotizacion','','H')
INSERT INTO ads003 VALUES(3,'PED','Pedido','','H')
INSERT INTO ads003 VALUES(3,'VTS','Nota de venta','','H')
INSERT INTO ads003 VALUES(3,'VTF','Factura','','H')
INSERT INTO ads003 VALUES(3,'VRS','Nota de venta Restaurant','','H')
INSERT INTO ads003 VALUES(3,'VRF','Factura Restaurant','','H')
INSERT INTO ads003 VALUES(3,'CON','Nota de Consumo','','H')

--* Modulo Exigibles
INSERT INTO ads003 VALUES(4,'CXC','Ctas por Cobrar','','H')
INSERT INTO ads003 VALUES(4,'CXP','Ctas por Pagar','','H')
INSERT INTO ads003 VALUES(4,'DAU','Diario Auxiliar','','H')

--* Modulo Tesoreria
INSERT INTO ads003 VALUES(5,'RIN','Recibo de ingreso','','H')
INSERT INTO ads003 VALUES(5,'REG','Recibo de Egreso','','H')
INSERT INTO ads003 VALUES(5,'TIN','Comprobante de ingreso','','H')
INSERT INTO ads003 VALUES(5,'TEG','Comprobante de Egreso','','H')

