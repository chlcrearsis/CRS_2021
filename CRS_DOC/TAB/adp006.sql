/*--**********************************************
ARCHIVO:	adp006.sql	
TABLA:		Tabla de "Imagenes por Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		25-10-2021
*/--**********************************************

CREATE TABLE adp006 
(
--** Llave Primaria
va_cod_per		INT				NOT NULL	DEFAULT(0),		--** Codigo Persona
va_ide_tip		CHAR(02)		NOT NULL	DEFAULT(0),		--** ID. Tipo de Imagen

--** Atributos
va_img_arc		VARBINARY(MAX)	NOT NULL,					--** Archivo
va_ext_arc		CHAR(05)		NOT NULL	DEFAULT(''),	--** Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)
va_tam_arc		VARCHAR(10)		NOT NULL	DEFAULT(''),	--** Tamaño del archivo
va_ide_usr 		VARCHAR(15) 	NOT NULL	DEFAULT(''),	--** ID. Usuario Registro
va_fec_reg		DATETIME		NOT NULL,					--** Fecha y hora de registro
va_nom_equ      VARCHAR(30)     NOT NULL    DEFAULT(''),    --** Nombre de la PC O Celular

CONSTRAINT pk1_adp006 PRIMARY KEY(va_ide_tip, va_cod_per)
)
GO




