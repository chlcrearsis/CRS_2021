/*--**********************************************
ARCHIVO:	inv003.sql
TABLA:		Familia de Producto
AUTOR:		CHL-CREARSIS
FECHA:		23-07-2020
*/--**********************************************
	
CREATE TABLE inv003 
(
va_cod_fam		VARCHAR(6)		NOT NULL,	--Código de la familia de producto
va_nom_fam		VARCHAR(50)		NOT NULL,	--Nombre de la familia
va_tip_fam		CHAR(1)			NOT NULL,	--Tipo de la cuenta (M=Matriz ; D=DETALLE ; S=Servicio C=Combo)
va_est_ado		CHAR(1)			NOT NULL	--Estado de la cuenta (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_inv003 PRIMARY KEY(va_cod_fam)
)

     
     