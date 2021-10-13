/*--**********************************************
ARCHIVO:	ads025.sql	
TABLA:		Tabla de "Bitacora p/Operaciones"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		23-09-2021
*/--**********************************************

CREATE TABLE ads025 
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL,	 --** ID. Usuario
	va_fch_reg  DATETIME     NOT NULL,   --** Fecha y Hora de Registro

	--** Atributos     
	va_nom_apl  CHAR(06)     NOT NULL,   --** Nombre Aplicación
	va_tip_ope  CHAR(01)     NOT NULL,   --** Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; 
										 --** D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza)
	va_nom_maq  VARCHAR(30)  NOT NULL,   --** Nombre de la Maquina
	va_obs_reg  VARCHAR(120) NOT NULL    --** Observación

	CONSTRAINT pk1_ads025 PRIMARY KEY(va_ide_usr, va_fch_reg)
)
GO