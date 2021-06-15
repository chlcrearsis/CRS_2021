/*--**********************************************
ARCHIVO:	inv005.sql
TABLA:		Tabla de Unidades de Medida
AUTOR:		CHL-CREARSIS
FECHA:		23-07-2020
*/--**********************************************

CREATE TABLE inv005 
(
va_cod_umd		VARCHAR(3)		NOT NULL,	--Codigo de la Unidad de medida
va_nom_umd		VARCHAR(50)		NOT NULL,	--Nombre de la Unidad de medida

CONSTRAINT pk1_inv005 PRIMARY KEY(va_cod_umd)
)
GO
     
--INSERT INICIAL
INSERT INTO inv005 VALUES ('MTS','Metros')
INSERT INTO inv005 VALUES ('KLS','Kilos')
INSERT INTO inv005 VALUES ('LTS','Litros')
INSERT INTO inv005 VALUES ('UND','Unidad')
INSERT INTO inv005 VALUES ('PZA','Pieza')