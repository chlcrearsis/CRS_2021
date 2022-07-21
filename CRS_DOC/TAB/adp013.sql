/*--**********************************************
ARCHIVO:	adp013.sql	
TABLA:		Tabla de "Contactos p/Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		03-01-2018
*/--**********************************************

PRINT 'adp013 : Contactos p/Persona'	 
CREATE TABLE adp013 
(
	--** Llave Primaria
	va_cod_per  INT			 NOT NULL DEFAULT(0),	 --** Código Persona (2 de Grup. Per y 5 de Persona)
	va_cod_con  INT			 NOT NULL DEFAULT(0),	 --** Código Contacto
																
	--** Atributos
	va_nom_bre  VARCHAR(30)  NOT NULL DEFAULT(''),   --** Nombre
	va_ape_pat  VARCHAR(20)  NOT NULL DEFAULT(''),   --** Apellido Paterno
	va_ape_mat  VARCHAR(20)  NOT NULL DEFAULT(''),   --** Apellido Materno
	va_nro_cid  VARCHAR(10)  NOT NULL DEFAULT(''),   --** Nro. Carnet de Identida
	va_ext_doc  CHAR(02)     NOT NULL DEFAULT(''),   --** Extensión Documento	
	va_sex_con  CHAR(01)     NOT NULL DEFAULT(''),   --** Sexo (H=Hombre; M=Mujer)
	va_fec_nac  DATETIME,                            --** Fecha de Nacimiento
	va_par_con  CHAR(15)     NOT NULL DEFAULT(''),   --** Parentesco	
	va_tel_per	VARCHAR(15)	 NOT NULL DEFAULT(''),	 --** Telefono Personal
	va_cel_ula	VARCHAR(15)	 NOT NULL DEFAULT(''),	 --** Telefono Celular
	va_ema_ail	VARCHAR(30)	 NOT NULL DEFAULT(''),	 --** Email
	va_dir_ubi	VARCHAR(120) NOT NULL DEFAULT(''),	 --** Direccion Ubicación
	va_obs_con  VARCHAR(160) NOT NULL DEFAULT(''),   --** Observación
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	 --** Estado(H=Habilitado; N=Deshabilitado)
     
CONSTRAINT pk1_adp013 PRIMARY KEY(va_cod_per, va_cod_con)
)
GO    