/*--**********************************************
ARCHIVO:	adp004.sql	
TABLA:		Tabla de "Atributos"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp004 
(
--** Llave Primaria
va_ide_tip		INT				NOT NULL	DEFAULT(0),			--** ID. tipo de atributo
va_ide_atr		INT				NOT NULL	DEFAULT(0),			--** ID. Atributo

--** Atributos     
va_nom_atr      VARCHAR(30)     NOT NULL,       --** Nombre
va_est_ado      CHAR(01)				        --** Estado

CONSTRAINT pk1_adp004 PRIMARY KEY(va_ide_tip, va_ide_atr)
)
GO
