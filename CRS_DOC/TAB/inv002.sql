/*--**********************************************
ARCHIVO:	inv002.sql
TABLA:		Tabla de Bodega
AUTOR:		CHL-CREARSIS(CHL)
FECHA:		26-07-2020
*/--*********************************************

CREATE TABLE inv002
(
va_ide_gru		SMALLINT		NOT NULL,	--Grupo de Almacen (4 numeros)
va_cod_bod		INT				NOT NULL,	--Codigo deL ALMACEN (#####) -> compuesto por (va_cod_gru , va_nro_bod)	

va_nom_bod		VARCHAR(40)		NOT NULL,	--Nombre del almacen
va_des_bod		VARCHAR(160)	NOT NULL,	--Descripcion del almacen
va_dir_bod		VARCHAR(200),				--Direccion del almacen
va_fec_ctr		DATE			NOT NULL,	--ULTIMA FECHA CONTROL  DEL ALMACEN
va_mon_inv		CHAR(01)		NOT NULL,	--Moneda del inventario B=Bolivianos ; U=Dolares
va_mtd_cto		CHAR(01)		NOT NULL,	/* Metodo de costeo 
												P=Promedio Ponderado (Solo usaremos este inicialmente) 
												C=UEPS (Ultimos en Entrar, Primeros en Salir)
												A=PEPS (Primeros en Entrar Primeros en Salir)*/

	 
va_nom_ecg		VARCHAR(120)	NOT NULL,	--Nombre del encargado del almacen
va_tlf_ecg		VARCHAR(10),				--Telefono del encargado
va_dir_ecg		VARCHAR(200),				--Direccion del encargado
va_est_ado		CHAR(01)		NOT NULL,	--Estado del almacen
	  														

      	
       
CONSTRAINT pk1_inv002 PRIMARY KEY(va_ide_gru,va_cod_bod)
)