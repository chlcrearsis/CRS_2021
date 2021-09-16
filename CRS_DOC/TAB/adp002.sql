/*--**********************************************
ARCHIVO:	adp002.sql	
TABLA:		Tabla de "Persona"
AUTOR:		CREARSIS 3.0.0
FECHA:		03-01-2018
*/--**********************************************
	 
CREATE TABLE adp002 
(
	--** Llave Primaria
	va_cod_per  INT			NOT NULL DEFAULT(0),	--** Codigo Persona (2 de Grup. Per y 5 de Persona)

	--** Llave Secundaria
	va_cod_gru	TINYINT		NOT NULL DEFAULT(0),	--** Cod Grupo Persona
																
	--** Atributos
	va_tip_per  CHAR(01)    NOT NULL DEFAULT(''),   --** Tipo de Cliente (P=Particular; E=Empresa)
	va_nom_bre  VARCHAR(30) NOT NULL DEFAULT(''),   --** Nombre
	va_ape_pat  VARCHAR(20) NOT NULL DEFAULT(''),   --** Apellido Paterno
	va_ape_mat  VARCHAR(20) NOT NULL DEFAULT(''),   --** Apellido Materno
	va_raz_soc	VARCHAR(80)	NOT NULL DEFAULT(''),	--** Razon Social
	va_nom_fac	VARCHAR(80)	NOT NULL DEFAULT(''),	--** Nombre a Facturar
	va_ruc_nit	BIGINT      NOT NULL DEFAULT(0),	--** RUC/NIT
	va_sex_per  CHAR(01)    NOT NULL DEFAULT(''),   --** Sexo (H=Hombre; M=Mujer)   
	va_tip_doc  INT         NOT NULL DEFAULT(0),    --** Tipo Documento	
	va_nro_doc	BIGINT      NOT NULL DEFAULT(0),	--** Carnet de Identidad	
	va_tel_per	VARCHAR(15)	NOT NULL DEFAULT(''),	--** Telefono Personal
	va_cel_ula	VARCHAR(15)	NOT NULL DEFAULT(''),	--** Telefono Celular
	va_tel_fij	VARCHAR(15)	NOT NULL DEFAULT(''),	--** Telefono Fijo
	va_dir_pri	VARCHAR(80)	NOT NULL DEFAULT(''),	--** Direccion Principal
	va_dir_ent	VARCHAR(80)	NOT NULL DEFAULT(''),	--** Direccion de Entrega
	va_ema_per	VARCHAR(30)	NOT NULL DEFAULT(''),	--** Email
	va_ubi_gps	GEOGRAPHY,		                    --** Ubicación Geografica

	-- Llaves FOraneas
	va_cod_lpr	INT					 DEFAULT(0),	--** Codigo de lista de precio(8 numeros)
	va_cod_ven	SMALLINT			 DEFAULT(0),	--** Codigo de Vendedor asociado(4 numeros)
	   	    	  	   		
	va_est_ado	CHAR(1)		NOT NULL DEFAULT(''),	--** Estado(H=Habilitado; N=Deshabilitado)
     
CONSTRAINT pk1_adp002 PRIMARY KEY(va_cod_per, va_cod_gru)
  
)
GO
         