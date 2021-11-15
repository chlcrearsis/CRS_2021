/*--**********************************************
ARCHIVO:	adp018.sql	
TABLA:		Tabla de "Grupo Empresarial"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		12-11-2021
*/--**********************************************

CREATE TABLE adp018 
(
	--** Llave Primaria
	va_gru_emp  INT		    NOT NULL DEFAULT(0),	--** Codigo Grupo Empresarial

	--** Atributos     
	va_nom_gru  VARCHAR(40)	 NOT NULL DEFAULT(''),  --** Nombre
	va_ban_fac  INT			 NOT NULL DEFAULT(''),  --** Datos de Facturación (0=Cliente; 1=Grupo Empresarial)
	va_nom_fac	VARCHAR(80)	 NOT NULL DEFAULT(''),	--** Nombre a Facturar
	va_ruc_nit	BIGINT       NOT NULL DEFAULT(0),	--** RUC/NIT
	va_dir_ent  VARCHAR(160) NOT NULL DEFAULT(''),  --** Dirección de Entregas d/Factura
	va_est_ado  CHAR(01)     NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp018 PRIMARY KEY(va_gru_emp)
)
GO