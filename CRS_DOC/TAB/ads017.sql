/*--**********************************************
ARCHIVO:	ads017.sql	
TABLA:		Tabla de "Grupo de Persona"
AUTOR:		CREARSIS 1.0.0
FECHA:		16-10-2021
*/--**********************************************

CREATE TABLE ads017 
(
--** Llave Primaria
va_ide_usr		NVARCHAR(15)	NOT NULL,		--** ID. Usuario

--** Atributos     
va_pin_usr		INT			    NOT NULL,		--** Pin usuario
va_fec_reg		DATETIME		NOT NULL,		--** Fecha de registro pin
va_fec_exp      DATETIME        NOT NULL,       --** Fecha de expiracion del pin
va_nom_eqp		NVARCHAR(20)	NOT NULL		--** Nombre del equipo de donde se registro

CONSTRAINT pk1_ads017 PRIMARY KEY(va_ide_usr)
)
GO
