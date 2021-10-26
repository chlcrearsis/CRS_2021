/*--**********************************************
ARCHIVO:	adp006.sql	
TABLA:		Tabla de "Imagenes por Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		25-10-2021
*/--**********************************************

CREATE TABLE adp006 
(
--** Llave Primaria
va_ide_tip		INT				NOT NULL	DEFAULT(0),			--** ID. tipo de imagen
va_cod_per		INT				NOT NULL	DEFAULT(0),			--** Codigo Persona

--** Atributos
va_img_arc		VARBINARY(MAX)	NOT NULL	,					--** Archivo
va_ext_arc		CHAR(05)		NOT NULL	DEFAULT(''),		--** Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)
va_tam_arc		VARCHAR(10)		NOT NULL	DEFAULT(''),		--** Tamaño del archivo
va_fec_reg		DATETIME		NOT NULL	,					--** Fecha y hora de registro
va_ide_usr 		VARCHAR(15) 	NOT NULL						--** ID. Usuario Registro

CONSTRAINT pk1_adp006 PRIMARY KEY(va_ide_tip, va_cod_per)
)
GO



