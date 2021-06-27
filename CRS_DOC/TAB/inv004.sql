/*--**********************************************
ARCHIVO:	inv004.sql
TABLA:		Tabla de "Producto"
AUTOR:		CREARSIS 3.0.0 (
FECHA:		23-07-2020
*/--**********************************************

CREATE TABLE inv004 
(
--** Llave Primaria
va_cod_pro	VARCHAR(15)	NOT NULL,					--** Codigo del producto 

--** Llaves Foreaneas
va_cod_fam	VARCHAR(6)		NOT NULL,					--** Codigo de la familia de producto
va_cod_umd	CHAR(3)			NOT NULL,					--** (inv003-Und. Med)Codigo de la Unidad de Medida
va_und_cmp	CHAR(3)			NOT NULL,					--** (inv003-Und. Med)Codigo de la unidad de compra
va_und_vta	CHAR(3)			NOT NULL,					--** (inv003-Und. Med)Codigo de la unidad de venta
va_cod_mar	CHAR(3)			NOT NULL,					--** Codigo de la Marca del producto


--** Atributos     
va_nom_pro	VARCHAR(80)	NOT NULL,						--** Nombre del producto
va_des_pro	VARCHAR(200)	NOT NULL,					--** Descripcion del producto
va_cod_bar	VARCHAR(20)	NOT NULL,						--** Codigo de barra del producto
va_fab_ric	VARCHAR(50)	NOT NULL,						--** Fabricante al que pertenece el producto      
va_eqv_cmp	DECIMAL(6,2)	NOT NULL	DEFAULT(1),		--** Cantidad de unidad de medida por unidad de compra     
va_eqv_vta	DECIMAL(6,2)	NOT NULL	DEFAULT(1),		--** Cantidad de unidad de medida por unidad de presentacion (venta) 
va_nro_dec	INT				NOT NULL	DEFAULT(0),		--** Nro de decimales a manejar el inventario    
va_ban_ser	TINYINT				NOT NULL,					--** Bandera identifica si el producto se maneja por ¨serie 
															/* 0=No ; 
															1= si en todas
															2= solo en salidas	*/ 
     
va_ban_lot	CHAR(1)			NOT NULL,					--** Bandera identifica si el producto se maneja por LOTE 1=SI ; 2=NO
va_est_ado	CHAR(1)			NOT NULL,					  --** Estado del producto
      
      
CONSTRAINT pk1_inv004 PRIMARY KEY(va_cod_pro)
)
GO

     
     