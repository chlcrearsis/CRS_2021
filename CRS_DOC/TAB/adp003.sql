/*--**********************************************
ARCHIVO:	adp003.sql	
TABLA:		Tabla de "Tipo de atributos"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp003 
(
--** Llave Primaria
va_ide_tip		INT				NOT NULL	DEFAULT(0),			--** ID. tipo de atributo

--** Atributos     
va_nom_tip      VARCHAR(30)     NOT NULL,       --** Nombre
va_atr_def      INT						,       --** ID. atributo por defecto (adp004)
va_est_ado      CHAR(01)				        --** Estado

CONSTRAINT pk1_adp003 PRIMARY KEY(va_ide_tip)
)
GO
