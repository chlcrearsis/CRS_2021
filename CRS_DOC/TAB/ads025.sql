/*--**********************************************
ARCHIVO:	ads025.sql	
TABLA:		Tabla de "Bitacora p/Operaciones"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		23-09-2021
*/--**********************************************

PRINT 'ads025 : Bitacora p/Operaciones'
CREATE TABLE ads025 
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_fch_reg  DATETIME     NOT NULL,				--** Fecha y Hora de Registro
	--** Atributos     
	va_nom_apl  VARCHAR(06)  NOT NULL DEFAULT(''),	--** Nombre Aplicación
	va_tip_ope  CHAR(01)     NOT NULL DEFAULT(''),	--** Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; 
										            --** D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza)
	va_nom_maq  VARCHAR(30)  NOT NULL DEFAULT(''),	--** Nombre de la Maquina
	va_obs_reg  VARCHAR(120) NOT NULL DEFAULT(''),	--** Observación

	CONSTRAINT pk1_ads025 PRIMARY KEY(va_ide_usr, va_fch_reg)
)
GO