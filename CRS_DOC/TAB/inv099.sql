/*--**********************************************
ARCHIVO:	inv099.sql
TABLA:		Tabla de Saldos Fisicos y Valorados
AUTOR:		CREARSIS()
FECHA:		18-08-2020
*/--*********************************************

CREATE TABLE inv099(
	--Cuanto tiene de stock actual un almacén de ese producto
	va_cod_bod INT				NOT NULL,	--Codigo deL ALMACEN (inv011)
	va_cod_pro VARCHAR(15)		NOT NULL,	--Codigo de Producto (inv002)
	va_sal_can DECIMAL(14,2)	Default 0,	--Stock total x almacén (unidad inventario)
	va_cos_ubs DECIMAL(14,6)	Default 0,	--Costo Unitario (promedio ponderado en Bs)
	va_cos_uus DECIMAL(14,6)	Default 0	--Costo Unitario (promedio ponderado en USD)
)

