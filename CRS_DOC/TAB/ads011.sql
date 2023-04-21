/*--**********************************************
ARCHIVO:	ads011.sql	
TABLA:		Tabla de "Opciones del Menú Formulario"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		19-08-2022
*/--**********************************************

PRINT 'ads011 : Opciones del Menú Formulario'
CREATE TABLE ads011 
(
	--** Llave Primaria
	va_nom_frm	VARCHAR(10)	 NOT NULL DEFAULT(0),	--** Nombre Formulario
	va_ide_men	VARCHAR(10)	 NOT NULL DEFAULT(0),	--** ID. Menu Formulario
	--** Atributos
	va_tex_men	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Texto Menu Formulario
	va_des_men	VARCHAR(50)	 NOT NULL DEFAULT(''),	--** Descripción
	va_ide_pad	VARCHAR(01)	 NOT NULL DEFAULT('')	--** ID. Menu Padre

CONSTRAINT pk1_ads011 PRIMARY KEY(va_nom_frm, va_ide_men)
)
GO