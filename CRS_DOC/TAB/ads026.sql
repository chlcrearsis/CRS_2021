/*--**********************************************
ARCHIVO:	ads026.sql	
TABLA:		Tabla de "Bitacora p/Documento"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		23-09-2021
*/--**********************************************

CREATE TABLE ads026 
(
	--** Llave Primaria
	va_ges_doc  INT          NOT NULL,   --** Gestión
	va_ide_doc  CHAR(03)     NOT NULL,   --** ID. Documento
	va_nro_doc  INT          NOT NULL,   --** Nro. Documento
	va_fch_reg  DATETIME     NOT NULL,   --** Fecha y Hora de Registro

	--** Atributos     
	va_cod_per  INT          NOT NULL,   --** Código Persona
	va_tip_ope  CHAR(01)     NOT NULL,   --** Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; 
										 --** D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza)
	va_ide_usr 	VARCHAR(15)  NOT NULL,	 --** ID. Usuario
	va_obs_reg  VARCHAR(120) NOT NULL    --** Observación

	CONSTRAINT pk1_ads026 PRIMARY KEY(va_ges_doc, va_ide_doc, va_nro_doc, va_fch_reg)
)
GO