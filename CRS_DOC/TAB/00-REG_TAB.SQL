/*--**********************************************
ARCHIVO:	adp001.sql	
TABLA:		Tabla de "Grupo de Persona"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		03-01-2018
*/--**********************************************

PRINT 'adp001 : Grupo Persona'
CREATE TABLE adp001 
(
	--** Llave Primaria
	va_cod_gru	INT			 NOT NULL DEFAULT(0),	--** Codigo de Grupo de persona

	--** Atributos     
	va_nom_gru	VARCHAR(50)	 NOT NULL DEFAULT(''),	--** Nombre de Grupo de persona
	va_est_ado  CHAR(01)     NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp001 PRIMARY KEY(va_cod_gru)
)
GO


--** INSERTA GRUPO DE PERSONA POR DEFECTO
INSERT INTO adp001 VALUES (1, 'Clientes', 'H')
INSERT INTO adp001 VALUES (20, 'Empleados', 'H')
INSERT INTO adp001 VALUES (30, 'Proveedores', 'H')
INSERT INTO adp001 VALUES (40, 'Socios', 'H')
  
/*--**********************************************
ARCHIVO:	adp002.sql	
TABLA:		Tabla de "Registro Persona"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		03-01-2018
*/--**********************************************
	 
PRINT 'adp002 : Registro Persona'
CREATE TABLE adp002 
(
	--** Llave Primaria
	va_cod_per  INT			 NOT NULL DEFAULT(0),	--** Codigo Persona (2 de Grup. Per y 5 de Persona)

	--** Llave Secundaria
	va_cod_gru	INT	   	     NOT NULL DEFAULT(0),	--** Cod Grupo Persona
																
	--** Atributos
	va_tip_per  CHAR(01)     NOT NULL DEFAULT(''),  --** Tipo de Cliente (P=Particular; E=Empresa)
	va_nom_bre  VARCHAR(30)  NOT NULL DEFAULT(''),  --** Nombre
	va_ape_pat  VARCHAR(20)  NOT NULL DEFAULT(''),  --** Apellido Paterno
	va_ape_mat  VARCHAR(20)  NOT NULL DEFAULT(''),  --** Apellido Materno
	va_raz_soc	VARCHAR(80)	 NOT NULL DEFAULT(''),	--** Razon Social
	va_nom_fac  VARCHAR(120) NOT NULL DEFAULT(''),  --** Nombre a Facturar
	va_ruc_nit	BIGINT       NOT NULL DEFAULT(0),	--** RUC/NIT
	va_sex_per  CHAR(01)     NOT NULL DEFAULT(''),  --** Sexo (H=Hombre; M=Mujer)
	va_fec_nac  DATETIME,                           --** Fecha de Nacimiento
	va_tip_doc  CHAR(02)     NOT NULL DEFAULT(''),  --** Tipo Documento	
	va_nro_doc	BIGINT       NOT NULL DEFAULT(0),	--** Carnet de Identidad
	va_ext_doc  CHAR(02)     NOT NULL DEFAULT(''),  --** Extensión Documento	
	va_tel_per	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Telefono Personal
	va_cel_ula	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Telefono Celular
	va_tel_fij	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Telefono Fijo
	va_dir_pri	VARCHAR(120) NOT NULL DEFAULT(''),	--** Direccion Principal
	va_dir_ent	VARCHAR(120) NOT NULL DEFAULT(''),	--** Direccion de Entrega
	va_ema_ail	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Email
	va_ubi_gps	GEOGRAPHY,		                    --** Ubicación Geografica
	va_cod_ven	INT			 NOT NULL DEFAULT(0),	--** Código de Vendedor Asignado
	va_cod_cob	INT			 NOT NULL DEFAULT(0),	--** Código de Cobrador Asignado	   	    	  	   		
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado(H=Habilitado; N=Deshabilitado)
     
CONSTRAINT pk1_adp002 PRIMARY KEY(va_cod_per)
)
GO      
/*--**********************************************
ARCHIVO:	adp003.sql	
TABLA:		Tabla de "Tipo de atributos"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp003 : Tipo de atributos'
CREATE TABLE adp003 
(
	--** Llave Primaria
	va_ide_tip  INT		    NOT NULL DEFAULT(0),	--** ID. tipo de atributo

	--** Atributos     
	va_nom_tip  VARCHAR(30) NOT NULL DEFAULT(''),   --** Nombre
	va_atr_def  INT			NOT NULL DEFAULT(0),    --** ID. atributo por defecto (adp004)
	va_est_ado  CHAR(01)    NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp003 PRIMARY KEY(va_ide_tip)
)
GO


--** Inserta los tipo de atributos iniciales
INSERT INTO adp003 VALUES (1, 'Ciudad', 1, 'H')
INSERT INTO adp003 VALUES (2, 'Zona', 1, 'H')
INSERT INTO adp003 VALUES (3, 'Sector', 2, 'H')
INSERT INTO adp003 VALUES (4, 'Canal', 99, 'H')
INSERT INTO adp003 VALUES (5, 'Calificación', 1, 'H')
INSERT INTO adp003 VALUES (6, 'Profesión', 99, 'H')
INSERT INTO adp003 VALUES (7, 'Distribuidor', 1, 'H')
INSERT INTO adp003 VALUES (8, 'Despacho', 1, 'H')
  
/*--**********************************************
ARCHIVO:	adp004.sql	
TABLA:		Tabla de "Definiciones de Atributos"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp004 : Definiciones de Atributos'
CREATE TABLE adp004 
(
	--** Llave Primaria
	va_ide_tip	INT			 NOT NULL DEFAULT(0),	--** ID. tipo de atributo
	va_ide_atr	INT			 NOT NULL DEFAULT(0),	--** ID. Atributo

	--** Atributos     
	va_nom_atr  VARCHAR(30)	 NOT NULL DEFAULT(''),  --** Nombre Atributo
	va_est_ado  CHAR(01)	 NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp004 PRIMARY KEY(va_ide_tip, va_ide_atr)
)
GO

--** Inserta Atributo : Ciudad
INSERT INTO adp004 VALUES (1, 1, 'Santa Cruz', 'H')
INSERT INTO adp004 VALUES (1, 2, 'Cochabamba', 'H')
INSERT INTO adp004 VALUES (1, 3, 'La Paz', 'H')
INSERT INTO adp004 VALUES (1, 4, 'Tarija', 'H')
INSERT INTO adp004 VALUES (1, 5, 'Potosi', 'H')
INSERT INTO adp004 VALUES (1, 6, 'Pando', 'H')
INSERT INTO adp004 VALUES (1, 7, 'Beni', 'H')
INSERT INTO adp004 VALUES (1, 8, 'Oruro', 'H')
INSERT INTO adp004 VALUES (1, 9, 'Sucre', 'H')

--** Inserta Atributo : Zona
INSERT INTO adp004 VALUES (2, 1, 'Zona Central', 'H')
INSERT INTO adp004 VALUES (2, 2, 'Zona Norte', 'H')
INSERT INTO adp004 VALUES (2, 3, 'Zona Sur', 'H')
INSERT INTO adp004 VALUES (2, 4, 'Zona Este', 'H')
INSERT INTO adp004 VALUES (2, 5, 'Zona Oeste', 'H')
INSERT INTO adp004 VALUES (2, 99, 'N/A', 'H')

--** Inserta Atributos : Sector
INSERT INTO adp004 VALUES (3, 1, 'Agricultura', 'H')
INSERT INTO adp004 VALUES (3, 2, 'Comercial', 'H')
INSERT INTO adp004 VALUES (3, 3, 'Industrial', 'H')
INSERT INTO adp004 VALUES (3, 4, 'Ganadero', 'H')
INSERT INTO adp004 VALUES (3, 5, 'Servicios', 'H')
INSERT INTO adp004 VALUES (3, 6, 'Dependientes', 'H')
INSERT INTO adp004 VALUES (3, 7, 'Socios', 'H')
INSERT INTO adp004 VALUES (3, 99, 'N/A', 'H')

--** Inserta Atributos : Canal
INSERT INTO adp004 VALUES (4, 1, 'Mayorista', 'H')
INSERT INTO adp004 VALUES (4, 2, 'Agencias', 'H')
INSERT INTO adp004 VALUES (4, 3, 'Mercados', 'H')
INSERT INTO adp004 VALUES (4, 4, 'Supermercado', 'H')
INSERT INTO adp004 VALUES (4, 5, 'Tienda de Barrio', 'H')
INSERT INTO adp004 VALUES (4, 6, 'Fabrica', 'H')
INSERT INTO adp004 VALUES (4, 7, 'Restaurant', 'H')
INSERT INTO adp004 VALUES (4, 8, 'Hotel', 'H')
INSERT INTO adp004 VALUES (4, 9, 'Frial', 'H')
INSERT INTO adp004 VALUES (4, 99, 'N/A', 'H')

--** Inserta Atributos : Calificación
INSERT INTO adp004 VALUES (5, 1, 'Normal', 'H')
INSERT INTO adp004 VALUES (5, 2, 'Problema', 'H')
INSERT INTO adp004 VALUES (5, 3, 'Riesgo', 'H')
INSERT INTO adp004 VALUES (5, 4, 'Legal', 'H')
INSERT INTO adp004 VALUES (5, 5, 'Perdido', 'H')
INSERT INTO adp004 VALUES (5, 6, 'Eventual', 'H')
INSERT INTO adp004 VALUES (5, 7, 'Inactivo', 'H')
INSERT INTO adp004 VALUES (5, 99, 'N/A', 'H')

--** Inserta Atributos : Profesión
INSERT INTO adp004 VALUES (6, 1, 'Licenciado', 'H')
INSERT INTO adp004 VALUES (6, 2, 'Medico', 'H')
INSERT INTO adp004 VALUES (6, 3, 'Ingeniero', 'H')
INSERT INTO adp004 VALUES (6, 4, 'Abogado', 'H')
INSERT INTO adp004 VALUES (6, 5, 'Obrero', 'H')
INSERT INTO adp004 VALUES (6, 6, 'Comerciante', 'H')
INSERT INTO adp004 VALUES (6, 7, 'Chofer', 'H')
INSERT INTO adp004 VALUES (6, 8, 'Secretario', 'H')
INSERT INTO adp004 VALUES (6, 9, 'Empleado', 'H')
INSERT INTO adp004 VALUES (6, 10, 'Militar', 'H')
INSERT INTO adp004 VALUES (6, 99, 'N/A', 'H')

--** Inserta Atributos : Distribuidor
INSERT INTO adp004 VALUES (7, 1, 'Distribuidor 1', 'H')
INSERT INTO adp004 VALUES (7, 2, 'Distribuidor 2', 'H')
INSERT INTO adp004 VALUES (7, 3, 'Distribuidor 3', 'H')
INSERT INTO adp004 VALUES (7, 99, 'N/A', 'H')

--** Inserta Atributos : Despacho
INSERT INTO adp004 VALUES (8, 1, 'Despacho 1', 'H')
INSERT INTO adp004 VALUES (8, 2, 'Despacho 2', 'H')
INSERT INTO adp004 VALUES (8, 3, 'Despacho 3', 'H')
INSERT INTO adp004 VALUES (8, 99, 'N/A', 'H')  
/*--**********************************************
ARCHIVO:	adp005.sql	
TABLA:		Tabla de "Atributos por persona"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp005 : Atributos por persona'
CREATE TABLE adp005 
(
	--** Llave Primaria
	va_cod_per	INT			 NOT NULL DEFAULT(0),	--** Codigo Persona
	va_ide_tip	INT			 NOT NULL DEFAULT(0),	--** ID. tipo de atributo
	va_ide_atr	INT			 NOT NULL DEFAULT(0),	--** ID. Atributo

CONSTRAINT pk1_adp005 PRIMARY KEY(va_cod_per, va_ide_tip, va_ide_atr)
)
GO
  
/*--**********************************************
ARCHIVO:	adp006.sql	
TABLA:		Tabla de "Imagenes por Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		25-10-2021
*/--**********************************************

PRINT 'adp006 : Imagenes por Persona'
CREATE TABLE adp006 
(
	--** Llave Primaria
	va_cod_per	INT				NOT NULL DEFAULT(0),	--** Codigo Persona
	va_ide_tip	CHAR(02)		NOT NULL DEFAULT(0),	--** ID. Tipo de Imagen

	--** Atributos
	va_img_arc	VARBINARY(MAX)	NOT NULL,				--** Archivo
	va_ext_arc	CHAR(05)		NOT NULL DEFAULT(''),	--** Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)
	va_tam_arc	DECIMAL(10, 2)	NOT NULL DEFAULT(0),	--** Tamaño del archivo
	va_ide_usr 	VARCHAR(15) 	NOT NULL DEFAULT(''),	--** ID. Usuario Registro
	va_fec_reg	DATETIME		NOT NULL,				--** Fecha y hora de registro
	va_nom_equ  VARCHAR(30)     NOT NULL DEFAULT(''),   --** Nombre de la PC O Celular

CONSTRAINT pk1_adp006 PRIMARY KEY(va_ide_tip, va_cod_per)
)
GO




  
/*--**********************************************
ARCHIVO:	adp007.sql	
TABLA:		Tabla de "Definiciones de Rutas"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp007 : Definiciones de Rutas'
CREATE TABLE adp007 
(
	--** Llave Primaria
	va_ide_rut	INT			 NOT NULL DEFAULT(0),	--** ID. Ruta

	--** Atributos
	va_nom_rut	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre de la ruta
	va_nom_cor	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Nombre corto
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT('')	--** Estado (H=habilitado; N= deshabilitado)

CONSTRAINT pk1_adp007 PRIMARY KEY(va_ide_rut)
)
GO


--** Inserta Registro por Defecto
INSERT INTO adp007 VALUES (1, 'Lunes','LUN','H')
INSERT INTO adp007 VALUES (2, 'Martes','MAR','H')
INSERT INTO adp007 VALUES (3, 'Miercoles','MIE','H')
INSERT INTO adp007 VALUES (4, 'Jueves','JUE','H')
INSERT INTO adp007 VALUES (5, 'Viernes','VIE','H')
INSERT INTO adp007 VALUES (6, 'Sábado','SAB','H')
INSERT INTO adp007 VALUES (7, 'Domingo','DOM','H')
GO


  
/*--**********************************************
ARCHIVO:	adp008.sql	
TABLA:		Tabla de "Rutas p/Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		03-01-2018
*/--**********************************************

PRINT 'adp008 : Rutas p/Persona'
CREATE TABLE adp008 
(
	--** Llave Primaria
	va_cod_per  INT	NOT NULL DEFAULT(0),  --** Codigo Persona
	va_ide_rut	INT	NOT NULL DEFAULT(0)   --** ID. Ruta

CONSTRAINT pk1_adp008 PRIMARY KEY(va_cod_per, va_ide_rut)
)
GO




  
/*--**********************************************
ARCHIVO:	adp009.sql	
TABLA:		Tabla de "Permiso Lista de Precio p/Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		03-01-2018
*/--**********************************************

PRINT 'adp009 : Permiso Lista de Precio p/Persona'
CREATE TABLE adp009 
(
	--** Llave Primaria
	va_cod_per  INT	NOT NULL DEFAULT(0),  --** Codigo Persona
	va_cod_lis	INT	NOT NULL DEFAULT(0),  --** Codigo del la lista

CONSTRAINT pk1_adp009 PRIMARY KEY(va_cod_per, va_cod_lis)
)
GO
  
/*--**********************************************
ARCHIVO:	adp010.sql	
TABLA:		Tabla de "Descuento General p/Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		14-07-2022
*/--**********************************************

PRINT 'adp010 : Descuento General p/Persona'
CREATE TABLE adp010 
(
	--** Llave Primaria
	va_cod_per	INT			 NOT NULL DEFAULT(0),	--** Codigo Persona (2 de Grup. Per y 5 de Persona)

	--** Atributos     
	va_tip_fac	CHAR(01)	 NOT NULL DEFAULT(''),	--** p/Factura (S=Si; N=No)
	va_tip_ndv	CHAR(01)	 NOT NULL DEFAULT(''),	--** p/Nota de Venta (S=Si; N=No)
	va_por_con  DEC(14,2)    NOT NULL DEFAULT(0),   --** Porcentajde de Descuento al Contado
	va_por_cre  DEC(14,2)    NOT NULL DEFAULT(0),   --** Porcentajde de Descuento al Crédito

CONSTRAINT pk1_adp010 PRIMARY KEY(va_cod_per)
)
GO
  
/*--**********************************************
ARCHIVO:	adp010.sql	
TABLA:		Tabla de "Contactos de persona"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

CREATE TABLE adp010 
(
--** Llave Primaria
va_cod_per		INT				NOT NULL	DEFAULT(0),			--** Codigo Persona (2 de Grup. Per y 5 de Persona)

--** Atributos     
va_cod_con		INT			    NOT NULL,		--** Codigo de contacto
va_nom_con      VARCHAR(30)     NOT NULL,       --** Nombre del contacto
va_car_con      VARCHAR(15)				,       --** Cargo del contacto
va_rel_con      VARCHAR(30)				,       --** Relacion del contacto
va_tel_con		VARCHAR(10)				,		--** Telefono del contacto
va_cel_con      VARCHAR(10)				,       --** Celular del contacto
va_ema_con		VARCHAR(30)				,		--** Correo del contacto
va_dir_con      VARCHAR(120)			,       --** Direccion del contacto
va_obs_con      VARCHAR(160)			,       --** Observacion del contacto

CONSTRAINT pk1_adp010 PRIMARY KEY(va_cod_per,va_cod_con)
)
GO
  
/*--**********************************************
ARCHIVO:	adp012.sql	
TABLA:		Tabla de "Asig. Grupo Empresarial"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'adp012 : Asig. Grupo Empresarial'
CREATE TABLE adp012 
(
	--** Llave Primaria
	va_cod_per  INT	NOT NULL DEFAULT(0),	--** Codigo Persona
	va_gru_emp	INT	NOT NULL DEFAULT(0),	--** Codigo Grupo Empresarial

CONSTRAINT pk1_adp012 PRIMARY KEY(va_cod_per, va_gru_emp)
)
GO
  
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
/*--**********************************************
ARCHIVO:	adp014.sql	
TABLA:		Tabla de "Tipo de Documento"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		15-09-2021
*/--**********************************************

PRINT 'adp014 : Tipo de Documento'	
CREATE TABLE adp014 
(
	--** Llave Primaria
	va_ide_tip  CHAR(02)    NOT NULL DEFAULT(''),	--** ID. Tipo de Documento

	--** Atributos     
	va_des_tip  VARCHAR(30) NOT NULL DEFAULT(''),   --** Nombre
	va_ext_doc  CHAR(01)    NOT NULL DEFAULT(''),   --** Usa Extension Documento (S=Si; N=No)
	va_est_ado  CHAR(01)    NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp014 PRIMARY KEY(va_ide_tip)
)
GO


--** Inserta los tipo de atributos iniciales
INSERT INTO adp014 VALUES ('CI', 'Carnet de Identidad', 'S', 'H')
INSERT INTO adp014 VALUES ('LC', 'Licencia de Conducir', 'S', 'H')
INSERT INTO adp014 VALUES ('SM', 'Libreta Servicio Militar', 'N', 'H')
INSERT INTO adp014 VALUES ('PS', 'Pasaporte', 'N', 'H')  
/*--**********************************************
ARCHIVO:	adp015.sql	
TABLA:		Tabla de "Validación Registro de Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		15-09-2021
*/--**********************************************

PRINT 'adp015 : Validación Registro de Persona'	
CREATE TABLE adp015 
(
	--** Llave Primaria
	va_nom_col  CHAR(10)    NOT NULL DEFAULT(''),	--** Nombre Columna

	--** Atributos     
	va_ide_col  INT         NOT NULL DEFAULT(0),    --** Identificador Columna
	va_des_col  VARCHAR(30) NOT NULL DEFAULT(''),   --** Descripción
	va_dat_req  CHAR(01)    NOT NULL DEFAULT(''),   --** Dato Requerido (S=Si; N=No)

CONSTRAINT pk1_adp015 PRIMARY KEY(va_nom_col)
)
GO


--** Inserta los tipo de atributos iniciales
INSERT INTO adp015 VALUES ('va_raz_soc', 1,  'Razón Social', 'S')
INSERT INTO adp015 VALUES ('va_nom_fac', 2,  'Facturar a', 'S')
INSERT INTO adp015 VALUES ('va_ruc_nit', 3,  'RUC/NIT', 'N')
INSERT INTO adp015 VALUES ('va_nom_bre', 4,  'Nombre', 'S')
INSERT INTO adp015 VALUES ('va_ape_pat', 5,  'Apellido Paterno', 'S')
INSERT INTO adp015 VALUES ('va_ape_mat', 6,  'Apellido Materno', 'S')
INSERT INTO adp015 VALUES ('va_nro_doc', 7,  'Nro. Documento', 'N')
INSERT INTO adp015 VALUES ('va_fec_nac', 8,  'Fecha de Nacimiento', 'N')
INSERT INTO adp015 VALUES ('va_tel_per', 9,  'Teléfono Personal', 'N')
INSERT INTO adp015 VALUES ('va_cel_ula', 10, 'Teléfono Celular', 'N')
INSERT INTO adp015 VALUES ('va_tel_fij', 11, 'Teléfono Fijo', 'N')
INSERT INTO adp015 VALUES ('va_ema_ail', 12, 'Email', 'N')
INSERT INTO adp015 VALUES ('va_dir_pri', 13, 'Dirección', 'N')
INSERT INTO adp015 VALUES ('va_dir_ent', 14, 'Dirección de Entrega', 'N')
  
/*--************************************************************************
ARCHIVO:	adp016.sql	
TABLA:		Tabla de "Inscripción Automatica Libreta p/Grupo de Persona"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		08-11-2021
*/--************************************************************************

PRINT 'adp016 : Inscripción Automatica Libreta p/Grupo de Persona'	
CREATE TABLE adp016 
(
	--** Llave Primaria
	va_cod_gru	INT	NOT NULL DEFAULT(0),	--** Codigo de Grupo de persona
	va_cod_lib	INT	NOT NULL DEFAULT(0),	--** Código de la Libreta

CONSTRAINT pk1_adp016 PRIMARY KEY(va_cod_gru, va_cod_lib)
)
GO  
/*--**********************************************
ARCHIVO:	adp017.sql	
TABLA:		Tabla de "Relación Contacto de Persona"
AUTOR:		CREARSIS 3.0.0
FECHA:		11-11-2021
*/--**********************************************

PRINT 'adp017 : Relación Contacto de Persona'	
CREATE TABLE adp017 
(
	--** Llave Primaria
	va_ide_rel	INT			  NOT NULL DEFAULT(0),		--** ID. Relacion Contacto

	--** Atributos     
	va_nre_hom	NVARCHAR(20)  NOT NULL DEFAULT(''),		--** Nombre Relación p/Hombre
	va_nre_muj	NVARCHAR(20)  NOT NULL DEFAULT(''),		--** Nombre Relación p/Mujer
	va_est_ado	CHAR(01)	  NOT NULL DEFAULT(''),		--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp017 PRIMARY KEY(va_ide_rel)
)
GO

--** Inserta Registro p/Defectos
INSERT INTO adp017 VALUES (1, 'Ninguno', 'Ninguno', 'H')
INSERT INTO adp017 VALUES (2, 'Esposo', 'Esposa', 'H')
INSERT INTO adp017 VALUES (3, 'Padre', 'Madre', 'H')
INSERT INTO adp017 VALUES (4, 'Hijo', 'Hija', 'H')
INSERT INTO adp017 VALUES (5, 'Hermano', 'Hermana', 'H')
INSERT INTO adp017 VALUES (6, 'Hermanastro', 'Hermanastra', 'H')
INSERT INTO adp017 VALUES (7, 'Tio', 'Tia', 'H')
INSERT INTO adp017 VALUES (8, 'Sobrino', 'Sobrina', 'H')
INSERT INTO adp017 VALUES (9, 'Bisabuelo', 'Bisabuela', 'H')
INSERT INTO adp017 VALUES (10, 'Biznieto', 'Biznieta', 'H')
INSERT INTO adp017 VALUES (11, 'Primo', 'Prima', 'H')
INSERT INTO adp017 VALUES (12, 'Suegro', 'Suegra', 'H')
INSERT INTO adp017 VALUES (13, 'Cuñado', 'Cuñada', 'H')
INSERT INTO adp017 VALUES (14, 'Amigo', 'Amiga', 'H')
INSERT INTO adp017 VALUES (15, 'Jefe', 'Jefa', 'H')
INSERT INTO adp017 VALUES (16, 'Socio', 'Socia', 'H')
INSERT INTO adp017 VALUES (17, 'Profesor', 'Profesora', 'H')
INSERT INTO adp017 VALUES (18, 'Compañero', 'Compañera', 'H')
INSERT INTO adp017 VALUES (19, 'Entrenador', 'Entrenadora', 'H')
INSERT INTO adp017 VALUES (20, 'Pastor', 'Pastora', 'H')
INSERT INTO adp017 VALUES (21, 'Doctor', 'Doctora', 'H')
INSERT INTO adp017 VALUES (22, 'Colega de Trabajo', 'Colega de Trabajo', 'H')

  
/*--**********************************************
ARCHIVO:	adp018.sql	
TABLA:		Tabla de "Grupo Empresarial"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		12-11-2021
*/--**********************************************

PRINT 'adp018 : Grupo Empresarial'
CREATE TABLE adp018 
(
	--** Llave Primaria
	va_gru_emp  INT		     NOT NULL DEFAULT(0),	--** Codigo Grupo Empresarial

	--** Atributos     
	va_nom_gru  VARCHAR(40)	 NOT NULL DEFAULT(''),  --** Nombre
	va_ban_fac  INT			 NOT NULL DEFAULT(''),  --** Datos de Facturación (0=Registro Cliente; 1=Grupo Empresarial)
	va_nom_fac	VARCHAR(80)	 NOT NULL DEFAULT(''),	--** Nombre a Facturar
	va_ruc_nit	BIGINT       NOT NULL DEFAULT(0),	--** RUC/NIT
	va_dir_ent  VARCHAR(160) NOT NULL DEFAULT(''),  --** Dirección de Entregas d/Factura
	va_est_ado  CHAR(01)     NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_adp018 PRIMARY KEY(va_gru_emp)
)
GO  
/*--**********************************************
ARCHIVO:	ads001.sql	
TABLA:		Tabla de "Módulo"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads001 : Módulo'
CREATE TABLE ads001
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo
	--** Atributos
	va_nom_mod	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_abr_mod	VARCHAR(05)	 NOT NULL DEFAULT(''),	--** Abrebiacion
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads001 PRIMARY KEY(va_ide_mod)
)
GO

--** INSERTA MODULO DEL SISTEMA POR DEFECTO
INSERT INTO ads001 VALUES (1, 'Administracion y Seguridad', 'ADS', 'H')
INSERT INTO ads001 VALUES (2, 'Inventario', 'INV', 'H')
INSERT INTO ads001 VALUES (3, 'Comercializacion', 'CMR', 'H')
INSERT INTO ads001 VALUES (4, 'Exigibles', 'ECP', 'H')
INSERT INTO ads001 VALUES (5, 'Tesoreria', 'TES', 'H')
  
/*--**********************************************
ARCHIVO:	ads002.sql	
TABLA:		Tabla de "Aplicaciones"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads002 : Aplicaciones'
CREATE TABLE ads002
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo
	va_ide_apl	VARCHAR(10)	 NOT NULL DEFAULT(''),	--** ID. Aplicacion
	--** Atributos
	va_nom_apl	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre Aplicación
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads002 PRIMARY KEY(va_ide_mod,va_ide_apl)
)
GO

--** INSERTA APLICACIONES DEL SISTEMA POR DEFECTO
INSERT INTO ads002 VALUES (1, 'ads200', 'Administrador', 'H')
INSERT INTO ads002 VALUES (2, 'inv200', 'Inventario', 'H')
INSERT INTO ads002 VALUES (3, 'crm200', 'Comercialización', 'H')
INSERT INTO ads002 VALUES (4, 'res200', 'Restaurant', 'H')


  
/*--**********************************************
ARCHIVO:	ads003.sql	
TABLA:		Tabla de "Definición Documentos"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads003 : Definición Documentos'
CREATE TABLE ads003
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo
	va_ide_doc	CHAR(03)	 NOT NULL DEFAULT(''),	--** ID. Documento
	--** Atributos
	va_nom_doc	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_des_doc	VARCHAR(120) NOT NULL DEFAULT(''),	--** Descripción
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads003 PRIMARY KEY(va_ide_mod, va_ide_doc)
)
GO

--** INSERTA DOCUMENTOS DEL SISTEMA POR DEFECTO
--* Modulo Inventario
INSERT INTO ads003 VALUES(2, 'CMP', 'Compra en Bodega', 'Compra en Bodega', 'H')
INSERT INTO ads003 VALUES(2, 'AJI', 'Ajuste de Ingreso', 'Ajuste de Ingreso', 'H')
INSERT INTO ads003 VALUES(2, 'AJE', 'Ajuste de Salida', 'Ajuste de Salida', 'H')
INSERT INTO ads003 VALUES(2, 'AJC', 'Ajuste al Costo', 'Ajuste al Costo', 'H')
INSERT INTO ads003 VALUES(2, 'TRA', 'Traspaso entre Bodegas', 'Traspaso entre Bodegas', 'H')
INSERT INTO ads003 VALUES(2, 'OPD', 'Orden de Producción', 'Orden de Producción', 'H')

--* Modulo Comercializacion
INSERT INTO ads003 VALUES(3, 'COT', 'Cotización', 'Cotización', 'H')
INSERT INTO ads003 VALUES(3, 'PED', 'Pedido', 'Pedido', 'H')
INSERT INTO ads003 VALUES(3, 'VTS', 'Nota de Venta', 'Nota de Venta', 'H')
INSERT INTO ads003 VALUES(3, 'VTF', 'Factura', 'Factura', 'H')
INSERT INTO ads003 VALUES(3, 'VRS', 'Nota de Venta Restaurant', 'Nota de Venta Restaurant', 'H')
INSERT INTO ads003 VALUES(3, 'VRF', 'Factura Restaurant', 'Factura Restaurant', 'H')
INSERT INTO ads003 VALUES(3, 'CON', 'Nota de Consumo', 'Nota de Consumo', 'H')

--* Modulo Exigibles
INSERT INTO ads003 VALUES(4, 'CXC', 'Ctas por Cobrar', 'Ctas por Cobrar', 'H')
INSERT INTO ads003 VALUES(4, 'CXP', 'Ctas por Pagar', 'Ctas por Pagar', 'H')
INSERT INTO ads003 VALUES(4, 'DAU', 'Diario Auxiliar', 'Diario Auxiliar', 'H')

--* Modulo Tesoreria
INSERT INTO ads003 VALUES(5, 'RIN', 'Recibo de Ingreso', 'Recibo de Ingreso', 'H')
INSERT INTO ads003 VALUES(5, 'REG', 'Recibo de Egreso', 'Recibo de Egreso', 'H')
INSERT INTO ads003 VALUES(5, 'TIN', 'Comprobante de Ingreso', 'Comprobante de Ingreso', 'H')
INSERT INTO ads003 VALUES(5, 'TEG', 'Comprobante de Egreso', 'Comprobante de Egreso', 'H')  
/*--**********************************************
ARCHIVO:	ads004.sql	
TABLA:		Tabla de "Talonario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads004 : Talonario'
CREATE TABLE ads004
(
	--** Llave Primaria
	va_ide_doc	CHAR(03)	 NOT NULL DEFAULT(''),	--** ID. Documento
	va_nro_tal	INT			 NOT NULL DEFAULT(0),	--** Nro de Talonario
	--** Atributos
	va_nom_tal	VARCHAR(60)	 NOT NULL DEFAULT(''),	--** Nombre Talonario
	va_tip_tal	INT			 NOT NULL DEFAULT(0),	--** Tipo de Talonario (0=Manual; 1=Automatico)
	va_nro_aut	DEC(15,0)	 NOT NULL DEFAULT(''),	--** Número de Autorización
	va_for_mat	INT			 NOT NULL DEFAULT(0),	--** Formato de Impresión
	va_nro_cop	INT			 NOT NULL DEFAULT(0),	--** Nro. de Copias a Imprimir
	va_fir_ma1	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 1
	va_fir_ma2	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 2
	va_fir_ma3	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 3
	va_fir_ma4	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Firma Nro. 4
	va_for_log	INT			 NOT NULL DEFAULT(0),	--** Formato de Logo	
												    --** 0=Razon Social de Empresa; 1=Logotipo 1
												    --** 2=Logotipo 2 ;3=Logotipo 3
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

	CONSTRAINT pk1_ads004 PRIMARY KEY(va_ide_doc, va_nro_tal)
)
GO

--** INSERTA TALONARIO DEL SISTEMA POR DEFECTO

--* Modulo Inventario
INSERT INTO ads004 VALUES('CMP', 0, 'Compra en Bodega', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('AJI', 0, 'Ajuste de Ingreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('AJE', 0, 'Ajuste de Salida', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('AJC', 0, 'Ajuste al Costo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('TRA', 0, 'Traspaso entre Bodegas', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('OPD', 0, 'Orden de Producción', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')

--* Modulo Comercializacion
INSERT INTO ads004 VALUES('COT', 0, 'Cotización', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('PED', 0, 'Pedido', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VTS', 0, 'Nota de Venta', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VTF', 0, 'Factura', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VRS', 0, 'Nota de Venta Restaurant', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('VRF', 0, 'Factura Restaurant', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('CON', 0, 'Nota de Consumo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')

--* Modulo Exigibles
INSERT INTO ads004 VALUES('CXC', 0, 'Ctas por Cobrar', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('CXP', 0, 'Ctas por Pagar', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 0, 'Diario Auxiliar Anual', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 1, 'Diario Auxiliar - Enero', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 2, 'Diario Auxiliar - Febrero', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 3, 'Diario Auxiliar - Marzo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 4, 'Diario Auxiliar - Abril', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 5, 'Diario Auxiliar - Mayo', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 6, 'Diario Auxiliar - Junio', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 7, 'Diario Auxiliar - Julio', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 8, 'Diario Auxiliar - Agosto', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 9, 'Diario Auxiliar - Septiembre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 10, 'Diario Auxiliar - Octubre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 11, 'Diario Auxiliar - Noviembre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('DAU', 12, 'Diario Auxiliar - Diciembre', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')

--* Modulo Tesoreria
INSERT INTO ads004 VALUES('RIN', 0, 'Recibo de Ingreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('REG', 0, 'Recibo de Egreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('TIN', 0, 'Comprobante de Ingreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')
INSERT INTO ads004 VALUES('TEG', 0, 'Comprobante de Egreso', 1, 0, 0, 0, 'Elaborado por', 'Revisado por', 'Aprobado por', '', 0, 'H')

  
/*--**********************************************
ARCHIVO:	ads005.sql	
TABLA:		Tabla de "Numerador de Talonario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		21-08-2019
*/--**********************************************

PRINT 'ads005 : Numerador de Talonario'
CREATE TABLE ads005
(
	--** Llave Primaria
	va_ges_tio	INT			 NOT NULL DEFAULT(0),	--** Gestión
	va_ide_doc	CHAR(03)	 NOT NULL DEFAULT(''),	--** ID. Documento
	va_nro_tal	INT			 NOT NULL DEFAULT(0),	--** Nro de Talonario
	--** Atributos
	va_fec_ini	DATETIME	 NOT NULL,	            --** Fecha Inicial 
	va_fec_fin	DATETIME	 NOT NULL,	            --** Fecha Final
	va_nro_ini	INT			 NOT NULL DEFAULT(0),	--** Numero Inicial
	va_nro_fin	INT			 NOT NULL DEFAULT(0),	--** Numero Final
	va_con_tad	INT			 NOT NULL DEFAULT(0),	--** Contador Actual

	CONSTRAINT pk1_ads005 PRIMARY KEY(va_ide_doc, va_nro_tal, va_ges_tio)
)
GO
  
/*--**********************************************
ARCHIVO:	ads006.sql	
TABLA:		Tabla de "Tipo de Usuario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2019
*/--**********************************************

PRINT 'ads006 : Tipo de Usuario'
CREATE TABLE ads006
(
	--** Llave Primaria
	va_ide_tus	INT			 NOT NULL DEFAULT(0),	--** ID. Tipo de Usuario
	--** Atributos
	va_nom_tus	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_des_tus	VARCHAR(120) NOT NULL DEFAULT(''),	--** Descripción
	va_est_ado	CHAR		 NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_ads006 PRIMARY KEY(va_ide_tus)
)
GO
  
/*--**********************************************
ARCHIVO:	ads007.sql	
TABLA:		Tabla de "Usuario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2019
*/--**********************************************

PRINT 'ads007 : Usuario'
CREATE TABLE ads007
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	--** Atributos
	va_nom_usr	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Nombre
	va_tel_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Teléfono
	va_car_usr	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Cargo
	va_dir_ect	VARCHAR(30)	 NOT NULL DEFAULT(''),	--** Directorio de Trabajo
	va_ema_usr	VARCHAR(90)	 NOT NULL DEFAULT(''),	--** Email
	va_win_max	INT			 NOT NULL DEFAULT(0),	--** Nro. Maximo de Ventanas Abierta
	va_ide_per	INT			 NOT NULL DEFAULT(0),	--** ID. Persona Asociada
	va_ide_tus	INT			 NOT NULL DEFAULT(0),	--** ID. Tipo de Usuario
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(''),	--** Estado (H=habilitado; N=deshabilitado)

CONSTRAINT pk1_ads007 PRIMARY KEY(va_ide_usr)
)
GO  
/*--**********************************************
ARCHIVO:	ads008.sql	
TABLA:		Tabla de "Autorizaciones de Usuario sobre el Sistema"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		27-10-2020
*/--**********************************************

PRINT 'ads008 : Autorizaciones de Usuario sobre el Sistema'
CREATE TABLE ads008
(
	--** Llave Primaria
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_ide_tab	VARCHAR(06)  NOT NULL DEFAULT(''),	--** ID. Tabla
	va_ide_uno	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Uno
	va_ide_dos	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Dos
	va_ide_tre	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Tres
	--** Atributos
	va_ide_int	INT	         NOT NULL DEFAULT(0),	--** Identificador Entero

CONSTRAINT pk1_ads008 PRIMARY KEY(va_ide_usr, va_ide_tab, va_ide_uno, 
                                  va_ide_dos, va_ide_tre)
)
GO  
/*--**********************************************
ARCHIVO:	ads009.sql	
TABLA:		Tabla de "Autorizaciones de Tipo de Usuario sobre el Sistema"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		26-07-2021
*/--**********************************************

PRINT 'ads009 : Autorizaciones de Tipo de Usuario sobre el Sistema'
CREATE TABLE ads009
(
	--** Llave Primaria
	va_ide_tus 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_ide_tab	VARCHAR(06)  NOT NULL DEFAULT(''),	--** ID. Tabla
	va_ide_uno	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Uno
	va_ide_dos	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Dos
	va_ide_tre	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Tres
	--** Atributos
	va_ide_int	INT	         NOT NULL DEFAULT(0),	--** Identificador Entero

CONSTRAINT pk1_ads009 PRIMARY KEY(va_ide_tus, va_ide_tab, va_ide_uno,
                                  va_ide_dos, va_ide_tre)
)
GO  
/*--**********************************************
ARCHIVO:	ads010.sql	
TABLA:		Tabla de "Tipo de Imagenes"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		25-08-2021
*/--**********************************************

PRINT 'ads010 : Tipo de Imagenes'
CREATE TABLE ads010 
(
	--** Llave Primaria
	va_ide_tip	CHAR(02)	NOT NULL DEFAULT(0),	--** ID. Tipo Imagen
	--** Atributos
	va_nom_tip	VARCHAR(20)	NOT NULL DEFAULT(''),	--** Nombre
	va_ide_tab	CHAR(06)	NOT NULL DEFAULT(''),	--** ID. Tabla
	va_est_ado	CHAR(01)	NOT NULL DEFAULT('')	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_ads010 PRIMARY KEY(va_ide_tip)
)
GO

--** PERSONAS (adp002)
INSERT INTO ads010 VALUES ('FP','Foto Persona','adp002','H')
INSERT INTO ads010 VALUES ('CI','Carnet de Identidad','adp002','H')
INSERT INTO ads010 VALUES ('NI','NIT/RUC','adp002','H')
INSERT INTO ads010 VALUES ('CQ','Croquis','adp002','H')
INSERT INTO ads010 VALUES ('FT','Frotis','adp002','H')
 
--** PRODUCTOS (inv004)
INSERT INTO ads010 VALUES ('PF','Producto Frente','inv004','H')
INSERT INTO ads010 VALUES ('PD','Producto Derecha','inv004','H')
INSERT INTO ads010 VALUES ('PI','Producto Izquirda','inv004','H')
INSERT INTO ads010 VALUES ('PA','Producto Detras','inv004','H')
INSERT INTO ads010 VALUES ('PD','Descripcion','inv004','H')

GO
   
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
/*--**********************************************
ARCHIVO:	ads012.sql	
TABLA:		Tabla de "Restriccion Menú al Usuario"
AUTOR:		CREARSIS 3.0.0 (JEJR)
FECHA:		19-08-2022
*/--**********************************************

PRINT 'ads012 : Restriccion Menú al Usuario'
CREATE TABLE ads012
(
	--** Llave Primaria
	va_ide_usr  VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_nom_frm	VARCHAR(10)	 NOT NULL DEFAULT(0),	--** Nombre Formulario
	va_ide_men	VARCHAR(10)	 NOT NULL DEFAULT(0),	--** ID. Menu Formulario

CONSTRAINT pk1_ads012 PRIMARY KEY(va_ide_usr, va_nom_frm, va_ide_men)
)
GO  
/*--**********************************************
ARCHIVO:	ads013.sql	
TABLA:		Tabla de "Globales"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads013 : Globales'
CREATE TABLE ads013
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo (ads001)
    va_ide_glo	INT			 NOT NULL DEFAULT(0),	--** ID. Global
	--** Atributos
    va_nom_glo	VARCHAR(60)	 NOT NULL DEFAULT(''),	--** Nombre
    va_tip_glo	INT			 NOT NULL DEFAULT(0),	--** Tipo Global (1=Caracter; 2=Numérico; 3=Decimal)
    va_glo_car	VARCHAR(120) NOT NULL DEFAULT(''),	--** Global Caracter											
    va_glo_ent 	INT 		 NOT NULL DEFAULT(0),	--** Global Numérico
    va_glo_dec	DEC(18,5)    NOT NULL DEFAULT(0),	--** Global Decimal

CONSTRAINT pk1_ads013 PRIMARY KEY(va_ide_mod, va_ide_glo)
)
GO

--** Inserta Globales del Sistema
insert into ads013 values (1,1,'Contraseña por defecto', 1,'Contra123.', 0, 0)
INSERT INTO ads013 VALUES (1,2,'Gestion', 2, '', 2010, 0)
INSERT INTO ads013 VALUES (1,3,'Periodo', 2, '', 12, 0)
INSERT INTO ads013 VALUES (1,4,'Razon Social Empresa', 1,'Empresa S.R.L.', 0, 0)
INSERT INTO ads013 VALUES (1,5,'Representante legal',1,'Nombre representante', 0, 0)
INSERT INTO ads013 VALUES (1,6,'Nit de la empresa', 3, '', 0, 123456789)
INSERT INTO ads013 VALUES (1,7,'Telefono fijo', 1, '33-333333', 0, 0)
INSERT INTO ads013 VALUES (1,8,'Telefono Celular', 1, '999-99999', 0, 0)
INSERT INTO ads013 VALUES (1,9,'Email', 1, 'empresa@gmail.com', 0, 0)
INSERT INTO ads013 VALUES (1,10,'Dirección', 1, 'Direccion', 0, 0)
INSERT INTO ads013 VALUES (1,11,'Clave Wifi', 1, '', 0, 0)
INSERT INTO ads013 VALUES (1,12,'Logo Empresa', 1, '', 0, 0)
INSERT INTO ads013 VALUES (1,13,'Logo B', 1, '', 0, 0)
INSERT INTO ads013 VALUES (1,14,'Logo C', 1, '', 0, 0)
INSERT INTO ads013 VALUES (1,15,'Logo D', 1, '', 0, 0)
INSERT INTO ads013 VALUES (1,16,'UsrLicAct', 2, '', 15360,0)	-- Cantidad de Licencia * 1024; (15*1024 = 15360)
INSERT INTO ads013 VALUES (1,17,'FecLicAct', 1, '21260026', 0, 0) -- Cadena encriptada de la licencia que contiene la fecha de expiracion
INSERT INTO ads013 VALUES (1,100,'Version del sistema',1,'1.0.0',0,0)
INSERT INTO ads013 VALUES (3,1,'Formulario Ventas',1,'Normal',0,0) -- 1 = Normal ; 2= Tactil

GO
  
/*--**********************************************
ARCHIVO:	ads014.sql	
TABLA:		Tabla de "Región"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads014 : Región'
CREATE TABLE ads014
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo (ads001)
	--** Atributos
	va_ide_reg 	INT			 NOT NULL DEFAULT(0),	--** ID. Región
	va_nom_reg	VARCHAR(30)	 NOT NULL DEFAULT(0),	--** Nombre
	va_est_ado	CHAR(01)	 NOT NULL DEFAULT(0),	--** Estado (H=Habilitado; N=Deshabilitado)

CONSTRAINT pk1_ads014 PRIMARY KEY(va_ide_reg)
)
GO  
/*--**********************************************
ARCHIVO:	ads015.sql	
TABLA:		Tabla de "?"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		06-11-2029
*/--**********************************************

PRINT 'ads015 : ?'
CREATE TABLE ads015
(
	--** Llave Primaria
	va_ide_mod	INT			 NOT NULL DEFAULT(0),	--** ID. Módulo (ads001)
	--** Atributos

CONSTRAINT pk1_ads015 PRIMARY KEY(va_ide_mod)
)
GO
  
/*--**********************************************
ARCHIVO:	ads015.sql	
TABLA:		Tabla de "Gestión Periodos"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		23-03-2020
*/--**********************************************

PRINT 'ads016 : Gestión Periodos'
CREATE TABLE ads016
(
	--** Llave Primaria
	va_ges_tio 	INT			 NOT NULL DEFAULT(0),	--** Gestion Año
	va_ges_per	INT			 NOT NULL DEFAULT(0),	--** Periodo Mes
	--** Atributos     	
	va_nom_per	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** Nombre del periodo
	va_fec_ini	DATE		 NOT NULL,	            --** Fecha inicial del periodo
	va_fec_fin	DATE		 NOT NULL,	            --** Fecha final del periodo

CONSTRAINT pk1_ads016 PRIMARY KEY(va_ges_tio, va_ges_per)
)
GO  
/*--**********************************************
ARCHIVO:	ads017.sql	
TABLA:		Tabla de "PIN Usuario"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		16-10-2020
*/--**********************************************

PRINT 'ads017 : PIN Usuario'
CREATE TABLE ads017 
(
	--** Llave Primaria
	va_ide_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** ID. Usuario

	--** Atributos     
	va_pin_usr	INT			 NOT NULL DEFAULT(0),	--** Pin usuario
	va_fec_reg	DATETIME	 NOT NULL,		        --** Fecha de registro pin
	va_fec_exp  DATETIME     NOT NULL,              --** Fecha de expiracion del pin
	va_nom_eqp	VARCHAR(20)  NOT NULL DEFAULT(''),	--** Nombre del equipo de donde se registro

CONSTRAINT pk1_ads017 PRIMARY KEY(va_ide_usr)
)
GO  
/*--**********************************************
ARCHIVO:	ads018.sql	
TABLA:		Tabla de "Autorizacion Usuario s/Plantilla de Ventas
            p/Restaurant (res004)"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		27-10-2020
*/--**********************************************

PRINT 'ads018 : Autorizacion Usuario s/Plantilla de Ventas p/Restaurant'
CREATE TABLE ads018
(
	--** Llave Primaria
	va_ide_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** ID. Usuario
	va_cod_plv	INT	 		 NOT NULL DEFAULT(0),	--** Codigo de la plantilla

CONSTRAINT pk1_ads018 PRIMARY KEY(va_ide_usr, va_cod_plv)
)
GO


  
/*--**********************************************
ARCHIVO:	ads018.sql	
TABLA:		Tabla de "Autorizacion Usuario s/Lista de Precio"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		27-10-2020
*/--**********************************************

PRINT 'ads019 : Autorizacion Usuario s/Lista de Precio'
CREATE TABLE ads019
(
	--** Llave Primaria
	va_ide_usr	VARCHAR(15)	 NOT NULL DEFAULT(''),	--** ID. Usuario
	va_cod_lis	INT			 NOT NULL DEFAULT(0),	--** Codigo de la Lista de Precio

CONSTRAINT pk1_ads019 PRIMARY KEY(va_ide_usr, va_cod_lis)
)
GO  
/*--**********************************************
ARCHIVO:	ads022.sql	
TABLA:		Tabla de "Tipo de Cambio Bs/Us"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		22-04-2021
*/--**********************************************

PRINT 'ads022 : Tipo de Cambio Bs/Us'
CREATE TABLE ads022
(
	--** Llave Primaria
	va_fec_bus	DATETIME	 NOT NULL,				--** Fecha T.C (Bs; Us)
	--** Atributos     	
	va_val_bus	DEC(8,6)  	 NOT NULL DEFAULT(0)	--** Valor (Bs; Us)

CONSTRAINT pk1_ads022 PRIMARY KEY(va_fec_bus)
)
GO  
/*--**********************************************
ARCHIVO:	ads023.sql	
TABLA:		Tabla de "Tipo de Cambio Bs/Ufv"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		22-04-2021
*/--**********************************************

PRINT 'ads023 : Tipo de Cambio Bs/Ufv'
CREATE TABLE ads023
(
	--** Llave Primaria
	va_fec_buf	DATETIME	 NOT NULL,				--** Fecha T.C (Bs; Ufv)
	--** Atributos     	
	va_val_buf	DEC(8,6)  	 NOT NULL DEFAULT(0)	--** Valor (Bs; Ufv)

CONSTRAINT pk1_ads023 PRIMARY KEY(va_fec_buf)
)
GO  
/*--**********************************************
ARCHIVO:	ads024.sql	
TABLA:		Tabla de "Bitacora de Inicio de Sesion"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		26-08-2021
*/--**********************************************

PRINT 'ads024 : Bitacora de Inicio de Sesion'
CREATE TABLE ads024 
(
	--** Llave Primaria
	va_ide_uni  CHAR(32)     NOT NULL DEFAULT(''),  --** Identificador Unico
	--** Atributos     
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** Identificador Usuario
	va_fec_reg	DATETIME     NOT NULL,				--** Fecha Actual Sin hh:MM:ss
	va_nom_maq  VARCHAR(30)  NOT NULL DEFAULT(''),  --** Nombre de la Maquina
	va_fec_ini  DATETIME     NOT NULL,              --** Fecha y Hora de Inicio
	va_fec_fin  DATETIME,                           --** Fecha y Hora de Cierre

CONSTRAINT pk1_ads024 PRIMARY KEY(va_ide_uni)
)
GO  
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
/*--**********************************************
ARCHIVO:	ads026.sql	
TABLA:		Tabla de "Bitacora p/Documento"
AUTOR:		CREARSIS 3.0.0 (EJR)
FECHA:		23-09-2021
*/--**********************************************

PRINT 'ads026 : Bitacora p/Documento'
CREATE TABLE ads026 
(
	--** Llave Primaria
	va_ges_doc  INT          NOT NULL DEFAULT(0),	--** Gestión
	va_ide_doc  CHAR(03)     NOT NULL DEFAULT(''),	--** ID. Documento
	va_nro_doc  INT          NOT NULL DEFAULT(0),	--** Nro. Documento
	va_fch_reg  DATETIME     NOT NULL,				--** Fecha y Hora de Registro
	--** Atributos     
	va_cod_per  INT          NOT NULL DEFAULT(0),	--** Código Persona
	va_tip_ope  CHAR(01)     NOT NULL DEFAULT(''),	--** Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; 
										            --** D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza)
	va_ide_usr 	VARCHAR(15)  NOT NULL DEFAULT(''),	--** ID. Usuario
	va_obs_reg  VARCHAR(120) NOT NULL DEFAULT(''),	--** Observación

	CONSTRAINT pk1_ads026 PRIMARY KEY(va_ges_doc, va_ide_doc, va_nro_doc, va_fch_reg)
)
GO  
/*--**********************************************
ARCHIVO:	cmr001.sql
TABLA:		Tabla Lista de Precios
AUTOR:		CHL-CREARSIS-ALDA
FECHA:		11/01/2018
*/--**********************************************

CREATE TABLE cmr001
(
va_cod_lis		INT			NOT NULL,	--Codigo del la lista(8 numeros)
va_nom_lis		VARCHAR(30)	NOT NULL,	--Nombre
va_mon_lis		CHAR(01)	NOT NULL,	--Moneda (B=Bolivianos; D=Dolares)
va_fec_ini		DATE		NOT NULL,	--Fecha inicio
va_fec_fin		DATE		NOT NULL,	--Fecha final
va_nro_dec		INT			NOT NULL,	--Nro. Decimales a trabajar
va_est_ado		CHAR(01)	NOT NULL	--Estado
 
CONSTRAINT pk1_cmr001 PRIMARY KEY(va_cod_lis)
)  
/*--**********************************************
ARCHIVO:	cmr002.sql
TABLA:		Tabla Detalle de Precios
AUTOR:		CHL-CREARSIS-ALDA
FECHA:		11/01/2018
*/--**********************************************

CREATE TABLE cmr002
(
va_cod_lis		INT				NOT NULL,	--Codigo del la lista(cmr001)(8 numeros)
va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo de Producto(inv002)
va_pre_cio		DECIMAL(10,5)	NOT NULL,	--Precio del Producto
va_pmx_des		DECIMAL(4,2)	NOT NULL,	--Porcentaje maximo de descuento permitido
va_pmx_inc		DECIMAL(4,2)	NOT NULL,	--Porcentaje maximo de incremento permitido
va_por_cal		DECIMAL(4,2)	NOT NULL,	--Porcentaje de utilidad(Ganancia) calculado
 
CONSTRAINT pk1_cmr002 PRIMARY KEY(va_cod_lis,va_cod_pro)
)
  
/*########################################################
ARCHIVO:	cmr003.sql
TABLA:		Sucursal
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE cmr003
(
va_ide_suc 		INT			 	NOT NULL,	--ID. sucursal
va_nom_suc		VARCHAR(30)		NOT NULL,	--Nombre sucursal
va_des_suc		VARCHAR(90)		NOT NULL,	--Descripcion sucursal
va_dto_suc		VARCHAR(30)		NOT NULL,	--Departamento sucursal
va_ciu_suc		VARCHAR(30)		NOT NULL,	--Ciudad sucursal
va_dir_suc		VARCHAR(90)		NOT NULL,	--Direccion sucursal
va_enc_suc		VARCHAR(90)				,	--Encargdo sucursal
va_tel_suc		VARCHAR(15)				,	--Telefono
va_cel_suc		VARCHAR(15)				,	--Celular
va_cla_wif		VARCHAR(15)				,	--Clave wifi
va_ubi_suc		GEOGRAPHY				,	--Ubicacion
va_est_ado		CHAR(01)		NOT NULL,	--Estado (H=habilitada; N=deshabilitada)

CONSTRAINT pk1_cmr003 PRIMARY KEY(va_ide_suc)
)

GO

INSERT INTO cmr003 VALUES(1,'CENTRAL', '','SANTA CRUZ', 'SANTA CRUZ','Av. San Aurelio Nº 392','','3358694','72195985','123456789','null','H')  
/*--**********************************************
ARCHIVO:	cmr004.sql
TABLA:		Tabla de Plantilla de Venta(leo)
AUTOR:		CHL-CREARSIS
FECHA:		21-02-2018
*/--**********************************************

CREATE TABLE cmr004
(
	va_cod_plv		SMALLINT		NOT NULL,	--Codigo de plantilla de venta (3 números)
	va_nom_plv		VARCHAR(30)		NOT NULL,	--Nombre de la plantilla
	va_des_plv		VARCHAR(120)	NOT NULL,	--Descripcion de la plantilla
	--LLAVE FORANEA
	va_cod_bod		INT						,	--Codigo de almacen (inv002) (##-##-###) -> compuesto por (va_cod_gru , va_nro_alm)	
	va_cam_bod		TINYINT					,	--Bandera cambia almacen ? (0=NO ; 1=SI)
	--LLAVE FORANEA
	va_cod_cli		VARCHAR(07)				,	--Cliente por defecto (adm013) (##-#####) (2 de Grup. Per y 5 de Persona)
	va_cod_caj		INT						,	--Caja para las ventas al contado (tes001) (5 Números)
	va_cam_caj		TINYINT					,	--Bandera cambia caja ? (0=NO ; 1=SI)
	--LLAVE FORANEA
	va_cod_lis		INT						,	--Lista de precio por defecto (cmr001)  (8 numeros)

	va_cam_lis		TINYINT					,	--Bandera, cambia lista ? (0=NO; 1=CAMBIA ; 2=Si o si la Asignada al cliente)
	va_mon_vta		CHAR(1)					,	--Moneda de la venta (B=Bolivianos; U= Dolares)
	va_cam_mon		TINYINT					,	--cambia moneda ? ( 0=NO; 1=CAMBIA; 2=Obtiene moneda de la lista fija)

	--LLAVE FORANEA
	va_cod_ven		SMALLINT				,	--Codigo del vendedor por defecto (cmr003) (4 numeros)
	va_cam_ven		TINYINT					,	--Cambia vendedor ? (0=NO; 1=CAMBIA; 2=Obtiene el asignado DEL cliente)

	va_cod_del		SMALLINT				,	--Codigo del delivery por defecto (cmr010) 
	va_cam_del		TINYINT					,	--Cambia delivery ? (0=NO; 1=CAMBIA)

	va_dia_ret		TINYINT					,	--Dias permitidos para ventas retrasadas ##
	va_for_pgo		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)
	va_cam_fpg		TINYINT					,	--Cambia forma de pago ? (0=NO; 1=CAMBIA)
	va_pgo_cta		TINYINT					,	--en la forma de pago Credito, Permite pago a cuenta ? (0=NO; 1= SI)
	va_ope_def		TINYINT					,	--Operacion por defecto (1=Factura; 2=Nota de Venta; 3=Pedido; 4=Cotizacion)

	--LLAVE FORANEA
	va_lib_cre		INT						,	--Codigo Libreta para ventas al credito (ecp006) (5 Numeros)
	va_lib_dev		INT						,	--Codigo Libreta para devoluciones de ventas (ecp006) (5 Numeros)

	va_bus_pro		TINYINT					,	--Busqueda rapida de producto por (0= no usa; 1=Codigo 2=nombre; 3= Descripcion; )
	va_des_srv		TINYINT					,	--Permite escribir descripcion en productos de servicio ? (0=NO; 1=SI)
	va_pro_rep		TINYINT					,	--Permite productos repetidos ? (0=NO; 1=SI)

	--LLAVE FORANEA
	va_doc_fac		CHAR(3)					,	--Documento factura (adm003) (3 Letras)
	va_tal_fac		TINYINT					,	--Talonario factura  (adm004) (2 numeros)
	va_doc_ntv		CHAR(3)					,	--Documento Nota de Venta (adm003) (3 Letras)
	va_tal_ntv		TINYINT					,	--Talonario Nota de venta (adm004) (2 numeros)
	va_doc_ped		CHAR(3)					,	--Documento Pedido (adm003) (3 Letras)
	va_tal_ped		TINYINT					,	--Talonario Pedido (adm004) (2 numeros)
	va_doc_cot		CHAR(3)					,	--Documento Cotizacion (adm003) (3 Letras)
	va_tal_cot		TINYINT					,	--Talonario Cotizacion (adm004) (2 numeros)
	va_doc_dcf		CHAR(3)					,	--Documento DeV C/F (adm003) (3 Letras)
	va_tal_dcf		TINYINT					,	--Talonario DeV C/F (adm004) (2 numeros)
	va_doc_dsf		CHAR(3)					,	--Documento DeV S/F (adm003) (3 Letras)
	va_tal_dsf		TINYINT					,	--Talonario DeV S/F (adm004) (2 numeros)
	va_doc_rei		CHAR(3)					,	--Documento Recibo de Ingreso (adm003) (3 Letras)
	va_tal_rei		TINYINT					,	--Talonario Recibo de Ingreso (adm004) (2 numeros)
	
	va_imp_fac		VARCHAR(80)				,	--Impresora por defecto para factura
	va_imp_ntv		VARCHAR(80)				,	--Impresora por defecto para Nota de venta
	va_imp_ped		VARCHAR(80)				,	--Impresora para pedido
	va_imp_cot		VARCHAR(80)				,	--Impresora para cotizacion
	va_imp_dcf		VARCHAR(80)				,	--Impresora para DeV C/F
	va_imp_dsf		VARCHAR(80)				,	--Impresora para DeV S/F
	va_ban_av1		TINYINT					,	--Imprime aviso de venta 1? (0=NO; 1=SI)
	va_imp_av1		VARCHAR(80)				,	--Impresora para aviso de venta 1
	va_ban_av2		TINYINT					,	--Imprime aviso de venta 2? (0=NO; 1=SI)
	va_imp_av2		VARCHAR(80)				,	--Impresora para aviso de venta 2
	va_ban_imp		TINYINT					,	--Bandera de impresion (0=No imprime; 1=Imprime directo ; 2=Pregunta para imprimir)

	va_est_ado		CHAR(01)					--Estado de la planilla de Venta


	CONSTRAINT pk1_cmr004 PRIMARY KEY(va_cod_plv)
)



  
/*--**********************************************
ARCHIVO:	cmr005.sql
TABLA:		Tabla de Encabezado de Vetas
AUTOR:		CHL-CREARSIS
FECHA:		24-03-2017
*/--**********************************************

CREATE TABLE cmr005
(
--Llaves primarias
va_doc_vta		CHAR(03)		NOT NULL,	--Documento de venta
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_vta		INT				NOT NULL,	--Numero de documento
va_ges_vta		SMALLINT		NOT NULL,	--Gestión de la venta (adm002) (4 numeros)
va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador de la venta (XXX|000-00000/2018)

--Llave Foránea
va_tip_vta		INT				NOT NULL,	--Tipo de venta ( 2= Nota de Venta ; 1=Factura )
va_nro_fac		INT				NOT NULL DEFAULT(0),	-- Nro de factura

va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del cliente (adm010) (7 numeros)
va_raz_soc		VARCHAR(180)			,	--Razon social del cliente 
va_nit_vta		VARCHAR(15)				,	--Nit del cliente
va_fec_vta		DATE					,	--Fecha de la venta
va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

--Llave Foránea
va_cod_plv		INT						,	--Plantilla de venta
va_cod_ven		SMALLINT				,	--Codigo de vendedor (cmr003) (4 numeros)

va_mon_vta		CHAR(1)					,	--Moneda de la venta  (B=Bolivianos; U= Dolares)
va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

--Llaves Foráneas
va_cod_caj		INT						,	--Codigo de la caja para ventas al contado (5 numeros)
va_cod_lcr		INT						,	--Libreta para ventas al credito (5 numeros)

va_ref_vta		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si la venta es hecha en base a una cotizacion u otro)

--Llaves Foráneas
va_cod_bod		CHAR(06)				,	--Codigo del almacen (7 numeros)
va_cod_lis		INT						,	--Codigo de lista (7 numeros)
va_vta_par		CHAR(01)				,	-- Venta para (M=Mesa ; D=Delivery ; L=Llevar)

va_cod_del		INT						,	-- Codigo del delivery
va_por_del		DECIMAL(3,1)			,	-- Porcentaje correspondiente al delivery


va_sub_toB		DECIMAL(16,5)			,	--Sub total de la venta Bolivianos
va_sub_toU		DECIMAL(16,5)			,	--Sub total de la venta Dolares
va_dto_vtB		DECIMAL(16,5)			,	--Descuento de la venta Bs
va_dto_vtU		DECIMAL(16,5)			,	--Descuento de la venta Us
va_tot_vtB		DECIMAL(16,5)			,	--Total de la venta Bs
va_tot_vtU		DECIMAL(16,5)			,	--Total de la venta Us

va_obs_vta		VARCHAR(180)			,	--Observacion de la venta

va_usr_reg		VARCHAR(15)				,	--Usuario que registro la venta
va_fec_reg		DATETIME				,	--Fecha real del registro
va_usr_anu		VARCHAR(15)				,	--Usuario que anulo
va_fec_anu		DATETIME				,	--Fecha real del registro
va_est_ado		CHAR(01)					--Estado


CONSTRAINT pk1_cmr005 PRIMARY KEY(va_doc_vta,va_nro_tal,va_nro_vta,va_ges_vta)


)

  
/*--**********************************************
ARCHIVO:	cmr006.sql
TABLA:		Tabla de Detalle de Venta
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		26-02-2018
*/--**********************************************
--drop table cmr006
CREATE TABLE cmr006
(
-- Llaves primarias
va_doc_vta		CHAR(03)		NOT NULL,	--Documento de venta
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_vta		INT				NOT NULL,	--Numero de documento
va_ges_vta		SMALLINT		NOT NULL,	--Gestión de la venta
va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador de la venta (XXX|000-00000/2018)
va_itm_vta		INT				NOT NULL,	--Nro de item de la venta

va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del producto
va_des_pro		VARCHAR(200)	NOT NULL,	--Nombre/Descripcion del producto

va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para la venta
											  -- (1= Unidad de medida Venta ; 2= Unidad de medida inventario)

va_und_vta		CHAR(03)		NOT NULL,	--Unidad de medida Venta											  
va_und_inv		CHAR(03)		NOT NULL,	--Unidad de medida Inventario
va_eqv_und		DECIMAL(6,2)	NOT NULL,	--equivalencia de la Und en la venta con la Und. inventario

va_can_unv		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Venta) solo para fin de calculo
va_can_uni		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Inventario)la que da de baja al inventario

va_pre_lis		DECIMAL(15,5)	NOT NULL,	--Precio de lista en la moneda de la venta

va_mto_brB		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Bs
va_mto_brU		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Us
va_val_dtB		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Bs
va_val_dtU		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Us
va_por_dto		DECIMAL(15,5)	NOT NULL,	--porcentaje de descuento proporcionado
va_mto_neB		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Bs
va_mto_neU		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Us

va_cto_uBS		DECIMAL(15,5)	NOT NULL,	--Costo Unitario en Bs
va_cto_uUS		DECIMAL(15,5)	NOT NULL,	--Costo Unitario en Us

va_iva_uBS		DECIMAL(15,5)	NOT NULL,	--IVA Unitario en Bs
va_iva_uUS		DECIMAL(15,5)	NOT NULL,	--IVA Unitario en Us
va_itr_uBS		DECIMAL(15,5)	NOT NULL,	--ITR Unitario en Bs
va_itr_uUS		DECIMAL(15,5)	NOT NULL	--ITR Unitario en Us

	
	

CONSTRAINT pk1_cmr006 PRIMARY KEY(va_doc_vta,va_nro_tal,va_nro_vta,va_itm_vta)
)

  
/*--**********************************************
ARCHIVO:	cmr006tmp.sql
TABLA:		Tabla detalle de VENTA RESTAURANT temporal
AUTOR:		CREARSIS(chl)
FECHA:		12-10-2018
*/--*********************************************
CREATE TABLE cmr006tmp(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)

	--Llave Foránea
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto	 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento (digitado x usuario)
	va_pre_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento (va_pre_uni * va_can_tid
	
	va_pre_lis		DECIMAL(14,4),				--Precio definido en la lista de precio
	va_des_cue		DECIMAL(14,4),				--Descuento en moneda del documento
	va_por_cen		DECIMAL(14,4),				--Porcentaje de descuento
	
		
		
	CONSTRAINT pk1_cmr006tmp PRIMARY KEY(va_cod_usr,va_cod_tmp,va_nro_itm)

)  
/*--**********************************************
ARCHIVO:	cmr007.sql
TABLA:		Tabla de Encabezado de Pedido
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		24-03-2017
*/--**********************************************
--drop table cmr007
CREATE TABLE cmr007
(
--Llaves primarias
va_doc_ped		CHAR(03)		NOT NULL,	--Documento de pedido
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_ped		INT				NOT NULL,	--Numero de documento
va_ges_ped		SMALLINT		NOT NULL,	--Gestión de la pedido (adm002) (4 numeros)
va_ide_ped		VARCHAR(20)		NOT NULL,	--Identificador de la pedido (XXX|000-00000/2018)

--Llave Foránea
va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del cliente (adm010) (7 numeros)
va_raz_soc		VARCHAR(180)			,	--Razon social del cliente 
va_nit_ped		VARCHAR(15)				,	--Nit del cliente
va_fec_ped		DATE					,	--Fecha del pedido
va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

--Llave Foránea
va_cod_plv		INT						,	--Plantilla de pedido
va_cod_ven		SMALLINT				,	--Codigo de vendedor (cmr003) (4 numeros)

va_mon_ped		CHAR(1)					,	--Moneda de la pedido  (B=Bolivianos; U= Dolares)
va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

--Llaves Foráneas
va_cod_caj		INT						,	--Codigo de la caja para pedidos al contado (5 numeros)
va_cod_lcr		INT						,	--Libreta para pedidos al credito (5 numeros)

va_ref_ped		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si el pedido es hecha en base a una cotizacion u otro)

--Llaves Foráneas
va_cod_bod		CHAR(06)				,	--Codigo del almacen (7 numeros)
va_cod_lis		INT						,	--Codigo de lista (7 numeros)
va_ped_par		CHAR(01)				,	-- pedido para (M=Mesa ; D=Delivery ; L=Llevar)

va_cod_del		INT						,	-- Codigo del delivery
va_por_del		DECIMAL(3,1)			,	-- Porcentaje correspondiente al delivery


va_sub_toB		DECIMAL(16,5)			,	--Sub total de la pedido Bolivianos
va_sub_toU		DECIMAL(16,5)			,	--Sub total de la pedido Dolares
va_dto_vtB		DECIMAL(16,5)			,	--Descuento de la pedido Bs
va_dto_vtU		DECIMAL(16,5)			,	--Descuento de la pedido Us
va_tot_vtB		DECIMAL(16,5)			,	--Total de la pedido Bs
va_tot_vtU		DECIMAL(16,5)			,	--Total de la pedido Us

va_obs_ped		VARCHAR(180)			,	--Observacion de la pedido

va_usr_reg		VARCHAR(15)				,	--Usuario que registro la pedido
va_fec_reg		DATETIME				,	--Fecha real del registro
va_usr_anu		VARCHAR(15)				,	--Usuario que anulo
va_fec_anu		DATETIME				,	--Fecha real del registro
va_est_ado		CHAR(01)					--Estado


CONSTRAINT pk1_cmr007 PRIMARY KEY(va_doc_ped,va_nro_tal,va_nro_ped,va_ges_ped)


)

  
/*--**********************************************
ARCHIVO:	cmr008.sql
TABLA:		Tabla de Detalle de Pedido
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		12-03-2021
*/--**********************************************
--drop table cmr008
CREATE TABLE cmr008
(
-- Llaves primarias
va_doc_ped		CHAR(03)		NOT NULL,	--Documento de Pedido
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_ped		INT				NOT NULL,	--Numero de documento
va_ges_ped		SMALLINT		NOT NULL,	--Gestión de el Pedido
va_ide_ped		VARCHAR(20)		NOT NULL,	--Identificador de el Pedido (XXX|000-00000/2018)
va_itm_ped		INT				NOT NULL,	--Nro de item de el Pedido

va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del producto
va_des_pro		VARCHAR(200)	NOT NULL,	--Nombre/Descripcion del producto

va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para el Pedido
											  -- (1= Unidad de medida Pedido ; 2= Unidad de medida inPedidorio)

va_und_ped		CHAR(03)		NOT NULL,	--Unidad de medida Pedido											  
va_und_inv		CHAR(03)		NOT NULL,	--Unidad de medida InPedidorio
va_eqv_und		DECIMAL(6,2)	NOT NULL,	--equivalencia de la Und en el Pedido con la Und. inPedidorio

va_can_unv		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Pedido) solo para fin de calculo
va_can_uni		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad InPedidorio)la que da de baja al inPedidorio

va_pre_lis		DECIMAL(15,5)	NOT NULL,	--Precio de lista en la moneda de el Pedido

va_mto_brB		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Bs
va_mto_brU		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Us
va_val_dtB		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Bs
va_val_dtU		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Us
va_por_dto		DECIMAL(15,5)	NOT NULL,	--porcentaje de descuento proporcionado
va_mto_neB		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Bs
va_mto_neU		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Us

	

CONSTRAINT pk1_cmr008 PRIMARY KEY(va_doc_ped,va_nro_tal,va_nro_ped,va_itm_ped)
)

  
/*--**********************************************
ARCHIVO:	cmr009.sql
TABLA:		Tabla de Encabezado de proforma
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		28-05-2021
*/--**********************************************

CREATE TABLE cmr009
(
--Llaves primarias
va_doc_prf		CHAR(03)		NOT NULL,	--Documento de proforma
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_prf		INT				NOT NULL,	--Numero de documento
va_ges_prf		SMALLINT		NOT NULL,	--Gestión de la proforma (adm002) (4 numeros)
va_ide_prf		VARCHAR(20)		NOT NULL,	--Identificador de la proforma (XXX|000-00000/2018)

--Llave Foránea
va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del cliente (adm010) (7 numeros)
va_raz_soc		VARCHAR(180)			,	--Razon social del cliente 
va_nit_prf		VARCHAR(15)				,	--Nit del cliente
va_fec_prf		DATE					,	--Fecha del proforma
va_fec_val		DATE					,	--Fecha de valides
va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

--Llave Foránea
va_cod_plv		INT						,	--Plantilla de proforma
va_cod_ven		SMALLINT				,	--Codigo de vendedor (cmr003) (4 numeros)

va_mon_prf		CHAR(1)					,	--Moneda de la proforma  (B=Bolivianos; U= Dolares)
va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

--Llaves Foráneas
va_cod_caj		INT						,	--Codigo de la caja para proformas al contado (5 numeros)
va_cod_lcr		INT						,	--Libreta para proformas al credito (5 numeros)

va_ref_prf		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si el proforma es hecha en base a una cotizacion u otro)

--Llaves Foráneas
va_cod_bod		CHAR(06)				,	--Codigo del almacen (7 numeros)
va_cod_lis		INT						,	--Codigo de lista (7 numeros)
va_prf_par		CHAR(01)				,	-- proforma para (M=Mesa ; D=Delivery ; L=Llevar)

va_cod_del		INT						,	-- Codigo del delivery
va_por_del		DECIMAL(3,1)			,	-- Porcentaje correspondiente al delivery


va_sub_toB		DECIMAL(16,5)			,	--Sub total de la proforma Bolivianos
va_sub_toU		DECIMAL(16,5)			,	--Sub total de la proforma Dolares
va_dto_vtB		DECIMAL(16,5)			,	--Descuento de la proforma Bs
va_dto_vtU		DECIMAL(16,5)			,	--Descuento de la proforma Us
va_tot_vtB		DECIMAL(16,5)			,	--Total de la proforma Bs
va_tot_vtU		DECIMAL(16,5)			,	--Total de la proforma Us

va_obs_prf		VARCHAR(180)			,	--Observacion de la proforma

va_usr_reg		VARCHAR(15)				,	--Usuario que registro la proforma
va_fec_reg		DATETIME				,	--Fecha real del registro
va_usr_anu		VARCHAR(15)				,	--Usuario que anulo
va_fec_anu		DATETIME				,	--Fecha real del registro
va_est_ado		CHAR(01)					--Estado


CONSTRAINT pk1_cmr009 PRIMARY KEY(va_doc_prf,va_nro_tal,va_nro_prf,va_ges_prf)


)

  
/*--**********************************************
ARCHIVO:	cmr010.sql
TABLA:		Tabla de Detalle de proforma
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		28-05-2021
*/--**********************************************

CREATE TABLE cmr010
(
-- Llaves primarias
va_doc_prf		CHAR(03)		NOT NULL,	--Documento de proforma
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_prf		INT				NOT NULL,	--Numero de documento
va_ges_prf		SMALLINT		NOT NULL,	--Gestión de el proforma
va_ide_prf		VARCHAR(20)		NOT NULL,	--Identificador de la proforma (XXX|000-00000/2018)
va_itm_prf		INT				NOT NULL,	--Nro de item de el proforma

va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del producto
va_des_pro		VARCHAR(200)	NOT NULL,	--Nombre/Descripcion del producto

va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para la proforma
											  -- (1= Unidad de medida venta ; 2= Unidad de medida inventario)

va_und_prf		CHAR(03)		NOT NULL,	--Unidad de medida venta											  
va_und_inv		CHAR(03)		NOT NULL,	--Unidad de medida Inventario
va_eqv_und		DECIMAL(6,2)	NOT NULL,	--equivalencia de la Und en el proforma con la Und. inproformario

va_can_unv		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad proforma) solo para fin de calculo
va_can_uni		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Inventario)la que da de baja al inproformario

va_pre_lis		DECIMAL(15,5)	NOT NULL,	--Precio de lista en la moneda de el proforma

va_mto_brB		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Bs
va_mto_brU		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Us
va_val_dtB		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Bs
va_val_dtU		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Us
va_por_dto		DECIMAL(15,5)	NOT NULL,	--porcentaje de descuento proporcionado
va_mto_neB		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Bs
va_mto_neU		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Us

	

CONSTRAINT pk1_cmr010 PRIMARY KEY(va_doc_prf,va_nro_tal,va_nro_prf,va_itm_prf)
)

  
/*########################################################
ARCHIVO:	cmr013.sql
TABLA:		Registro de Nit
AUTOR:		CHL
FECHA:		30/08/2021
########################################################*/

CREATE TABLE cmr013
(
va_cod_per		INT				NOT NULL	DEFAULT(0),			--Codigo Persona ADP002
va_nit_per		BIGINT,											--Nit de la persona
va_raz_soc		VARCHAR(120)	NOT NULL	DEFAULT(''),		--Razon social de la persona
va_act_ual		INT				NOT NULL	DEFAULT(0)			--Nit recientemente usado (0=pasado; 1=renciente)

CONSTRAINT pk1_cmr013 PRIMARY KEY(va_cod_per,va_nit_per)
)

go
  
/*--**********************************************
ARCHIVO:	cmr014.sql	
TABLA:		Tabla de "Vendedor/Cobrador"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		15/09/2020
*/--**********************************************

CREATE TABLE cmr014 
(
--** Llave Primaria
va_ide_tip		INT					NOT NULL,		--** ID. Tipo (1= Vendedor ; 2= Cobrador)
va_cod_ide		INT					NOT NULL,		--** Codigo identificador(4 numeros)

--** Atributos     
va_nom_bre		VARCHAR(50)			NOT NULL,		--** Nombre del Vendedor/Cobrador
va_tel_cel		VARCHAR(15)					,		--** Telefono Celular
va_ema_ail		VARCHAR(30)					,		--** Email
va_pro_ced		INT					NOT NULL,		--** Procedencia (1=Interno ; 2=Externo)
va_tip_cms		TINYINT				NOT NULL,		--** Tipo comisión (0=No Aplica; 1=General Venta; 2=Familia, 3=Producto)
va_cms_con		DECIMAL(4,2)		NOT NULL,		--** Porcentaje comision general al contado
va_cms_cre		DECIMAL(4,2)		NOT NULL,		--** Porcentaje comision general al credito      
va_est_ado		CHAR(01)			NOT NULL,		--** Estado (H=Habilitado; N=Deshabilitado)
      

CONSTRAINT pk1_cmr014 PRIMARY KEY(va_ide_tip,va_cod_ide)
)
GO

INSERT INTO cmr014 VALUES (1, 1, 'Vendedor 1', '','email@gmail.com',1, 1, 0,0,'H')
     
   
/*--**********************************************
ARCHIVO:	cmr015.sql
TABLA:		Tabla Deliverys
AUTOR:		CHL-CREARSIS
FECHA:		02/09/2020
*/--**********************************************
--drop table cmr015
CREATE TABLE cmr015
(
va_cod_del		INT			NOT NULL,	--Codigo  Delivery
va_nom_del		VARCHAR(30)	NOT NULL,	--Nombre
va_por_del		DECIMAL(3,1)	NOT NULL,	--Porcenta que cobra el delivery
va_est_ado		CHAR(01)	NOT NULL	--Estado
 
CONSTRAINT pk1_cmr015 PRIMARY KEY(va_cod_del)
)


  
/*--**********************************************
ARCHIVO:	cmr016.sql
TABLA:		Tabla Actividad economica
AUTOR:		CREARSIS
FECHA:		12-09-2021
*/--**********************************************

CREATE TABLE cmr016(
	va_cod_act		tinyint			NOT NULL,	-- Codigo actividad economica
	va_nom_act		varchar(200)	NOT NULL,	-- Nombre actividad economica
	
	CONSTRAINT pk1_cmr016 PRIMARY KEY(va_cod_act)
) 

GO

INSERT INTO cmr016 VALUES (0,'ACTIVIDAD ECONOMICA PRINCIPAL')  
/*--**********************************************
ARCHIVO:	cmr017.sql	
TABLA:		Tabla de " Detalle de comision"
AUTOR:		CREARSIS 3.0.0 (CHL)
FECHA:		15/09/2021
*/--**********************************************

CREATE TABLE cmr017 
(
--** Llave Primaria
va_cod_ven		SMALLINT			NOT NULL,		--** Codigo Vendedor(4 numeros)
va_ite_cms		VARCHAR(15)			NOT NULL,		--** Codigo Familia/Producto
--** Atributos     
va_cms_con		DECIMAL(4,2)		NOT NULL,		--** Porcentaje comision al contado
va_cms_cre		DECIMAL(4,2)		NOT NULL,		--** Porcentaje comision al credito      

CONSTRAINT pk1_cmr017 PRIMARY KEY(va_cod_ven, va_ite_cms)
)
GO
       
/*--**********************************************
ARCHIVO:	ctb001.sql
TABLA:		Tabla de Regional de la empresa
AUTOR:		CHL-CREARSIS
FECHA:		26-08-2021
*/--**********************************************

CREATE TABLE ctb001
(
va_cod_rgn		INT				NOT NULL,	-- Codigo de la regional
va_nom_rgn		VARCHAR(40)		NOT NULL,	-- Nombre de la regional

CONSTRAINT pk1_ctb001 PRIMARY KEY(va_cod_rgn)
)

GO
INSERT INTO ctb001 VALUES 
(1,'Regional')

GO  
/*--**********************************************
ARCHIVO:	ctb002.sql
TABLA:		Capitulo/Agrupador
AUTOR:		CHL-CREARSIS(ALDA)
FECHA:		03-12-2017
*/--**********************************************
	
CREATE TABLE ctb002 
(
va_cod_cap		INT				NOT NULL,	--Capitulo/Agrupador (1 Número)
va_nom_cap		VARCHAR(20)		NOT NULL,	--Nombre Capitulo/Agrupador
va_tip_cap		CHAR(01)		NOT NULL,	--Tipo de capitulo (A=activo; P=pasivo; T=patrimonio; I=ingreso; E=egreso; C=costo)
va_tra_cap		CHAR(1)			NOT NULL,	--Tratamiento (D=Deudor ; A=Acreedor)
va_cen_cto		INT				NOT NULL,	--Usa Centro de Costo(0=No ; 1=Si Usa)
va_est_ado		CHAR(1)			NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_ctb002 PRIMARY KEY(va_cod_cap)
)

INSERT INTO ctb002 VALUES(1,'ACTIVO','D','A',0,'H')
INSERT INTO ctb002 VALUES(2,'PASIVO','A','P',0,'H')
INSERT INTO ctb002 VALUES(3,'PATRIMONIO','A','T',0,'H')
INSERT INTO ctb002 VALUES(4,'INGRESOS','D','I',1,'H')
INSERT INTO ctb002 VALUES(5,'EGRESO','D','E',1,'H')
INSERT INTO ctb002 VALUES(6,'COSTO','D','C',1,'H')

  
/*--**********************************************
ARCHIVO:	ctb003.sql
TABLA:		Tabla Centro de Costos
AUTOR:		CHL-CREARSIS
FECHA:		26-08-2021
*/--**********************************************

CREATE TABLE ctb003
(
--Llave Primaria
va_cod_cct		INT				NOT NULL,	--Codigo del centro de Costos (4 numeros)

--Atributos
va_nom_cct		VARCHAR(50)		NOT NULL,	--Nombre del centro de Costos
va_tip_cct		CHAR(01)		NOT NULL,	--Tipo del centro de Costos (M=Matriz; A=Analitica)
va_est_ado		CHAR(01)		NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)	
 
CONSTRAINT pk1_ctb003 PRIMARY KEY(va_cod_cct)
)  
/*--**********************************************
ARCHIVO:	ctb004.sql
TABLA:		Plan de Cuentas
AUTOR:		CHL-CREARSIS
FECHA:		26-08-2021
*/--**********************************************
	
CREATE TABLE ctb004 
(
va_cod_cta		VARCHAR(12)		NOT NULL,	--Codigo Plan de Cuentas (#.#.##.##)(6 caracteres)
va_nom_cta		VARCHAR(40)		NOT NULL,	--Nombre Plan de Cuentas
va_tip_cta		CHAR(1)			NOT NULL,	--Tipo (M=Matriz ; A=Analitica)
va_uso_cta		CHAR(1)			NOT NULL,	--Uso (S=Sistema ; N=normal)
va_mon_cta		CHAR(1)			NOT NULL,	--Moneda (B=Bolivianos ; U=Dolares)
va_est_ado		CHAR(1)			NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_ctb004 PRIMARY KEY(va_cod_cta)
)
  
/*--**********************************************
ARCHIVO:	ctb006.sql
TABLA:		Tabla de leyendas
AUTOR:		FVM-CREARSIS
FECHA:		05-07-2017
*/--**********************************************

CREATE TABLE ctb006(
	va_cod_ley		tinyint			NOT NULL,	-- Codigo leyenda de 0 A 99
	va_nom_ley		varchar(500)	NOT NULL,	-- Nombre de la leyenda
	
	CONSTRAINT pk1_ctb006 PRIMARY KEY(va_cod_ley)
) 

GO
	 INSERT ctb006 VALUES(1,  'Ley N° 453: Si se te ha vulnerado algún derecho puedes exigir la reposición o restauración.') 
     INSERT ctb006 VALUES(2,  'Ley N° 453: El proveedor deberá dar cumplimiento a las condiciones ofertadas.') 
     INSERT ctb006 VALUES(3,  'Ley N° 453: Están prohibidas las prácticas comerciales abusivas, tienes derecho a denunciarlas.') 
     INSERT ctb006 VALUES(4,  'Ley N° 453: Tienes derecho a recibir información que te proteja de la publicidad engañosa.') 
     INSERT ctb006 VALUES(5,  'Ley N° 453: Puedes acceder a la reclamación cuando tus derechos han sido vulnerados.')
     INSERT ctb006 VALUES(6,  'Ley N° 453: Los contratos de adhesión deben redactarse en términos claros, comprensibles, ' + 
     'legibles y deben informar todas las facilidades y limitaciones.')
     INSERT ctb006 VALUES(7,  'Ley N° 453: Se debe promover el consumo solidario,justo, en armonía con la Madre Tierra y ' + 
     'precautelando el hábitat, en el marco del Vivir Bien.')
     INSERT ctb006 VALUES(8,  'Ley N° 453: El proveedor de productos debe habilitar medios e instrumentos para efectuar ' + 
     'consultas y reclamaciones.')
     INSERT ctb006 VALUES(9,  'Ley N° 453: El proveedor debe brindar atención sin discriminación, con respeto, calidez ' + 
     'y cordialidad a los usuarios y consumidores.')
     INSERT ctb006 VALUES(10,  'Ley N° 453: Los servicios deben suministrarse en condiciones de inocuidad, calidad y seguridad.')
     INSERT ctb006 VALUES(11,  'Ley N° 453: Tienes derecho a un trato equitativo sin discriminación en la oferta de servicios.')
     INSERT ctb006 VALUES(12,  'Ley N° 453: El proveedor deberá suministrar  el servicio en las modalidades y términos ' + 
     'ofertados o convenidos.')
     INSERT ctb006 VALUES(13,  'Ley N° 453: En caso de incumplimiento a lo ofertado o convenido, el proveedor debe reparar ' + 
     'o sustituir el servicio.')
     INSERT ctb006 VALUES(14,  'Ley N° 453: Tienes derecho a recibir información sobre las características y contenidos ' + 
     'de los servicios que utilices.')
     INSERT ctb006 VALUES(15,  'Ley N° 453: La interrupción del servicio debe comunicarse con anterioridad a las ' + 
     'Autoridades que correspondan y a los usuarios afectados.')
     INSERT ctb006 VALUES(16,  'Ley N° 453: El proveedor de servicios debe habilitar medios e instrumentos para efectuar ' + 
     'consultas y reclamaciones.')
     INSERT ctb006 VALUES(17,  'Ley N° 453: El proveedor debe exhibir certificaciones de habilitación o documentos que ' + 
     'acrediten las capacidades u ofertas de servicios especializados.')
     INSERT ctb006 VALUES(18,  'Ley N° 453: Los productos deben suministrarse en condiciones de inocuidad, calidad ' + 
     'y seguridad.')
     INSERT ctb006 VALUES(19,  'Ley N° 453: Está prohibido importar, distribuir o comercializar productos expirados ' + 
     'o prontos a expirar.')
     INSERT ctb006 VALUES(20,  'Ley N° 453: Está prohibido importar, distribuir o comercializar productos prohibidos o ' +
     'retirados en el país de origen por atentar a la integridad física y a la salud.')
     INSERT ctb006 VALUES(21,  'Ley N° 453: Tienes derecho a recibir información sobre las características y ' + 
     'contenidos de los productos que consumes.')
     INSERT ctb006 VALUES(22,  'Ley N° 453: Tienes derecho a un trato equitativo sin discriminación en la oferta ' + 
     'de productos.')
     INSERT ctb006 VALUES(23,  'Ley N° 453: El proveedor deberá entregar el producto en las modalidades y términos ' + 
     'ofertados o convenidos.')
     INSERT ctb006 VALUES(24,  'Ley N° 453: En caso de incumplimiento a lo ofertado o convenido, el proveedor debe ' + 
     'reparar o sustituir el producto.')
     INSERT ctb006 VALUES(25,  'Ley N° 453: Los alimentos declarados de primera necesidad deben ser suministrados de ' + 
     'manera adecuada, oportuna, continua y a precio justo.')
     INSERT ctb006 VALUES(26,  'Ley N° 453: El prestador de servicio médico debe brindar atención de calidad al paciente.')
     INSERT ctb006 VALUES(27,  'Ley N° 453: Cuando lo solicite el paciente, se debe informar los resultados de exámenes, ' + 
     'diagnósticos y estudios de laboratorio.')
     INSERT ctb006 VALUES(28,  'Ley N° 453: El prestador de servicio médico debe prescribir medicamentos debidamente ' + 
     'autorizados por el Ministerio de Salud.')
     INSERT ctb006 VALUES(29,  'Ley N° 453: Se debe otorgar el auxilio y atención necesarios en casos de urgencia o ' + 
     'emergencia hospitalaria, sin aducir excusa alguna.')
     INSERT ctb006 VALUES(30,  'Ley N° 453: Se debe brindar alternativas de pago por servicios utilizados en emergencia ' + 
     'médica u hospitalaria, no pudiendo retenerse al usuario por deuda.')
     INSERT ctb006 VALUES(31,  'Ley N° 453: Tienes derecho a denunciar la existencia de productos y servicios que pongan ' + 
     'en riesgo tu salud o integridad física.')
     INSERT ctb006 VALUES(32,  'Ley N° 453: La entidad financiera tiene la obligación de promover la educación ' + 
     'financiera.')
     INSERT ctb006 VALUES(33,  'Ley N° 453: La entidad financiera debe facilitar en cualquier momento y gratuitamente, ' + 
     'toda la información de los movimientos bancarios, financieros o de crédito.')
     INSERT ctb006 VALUES(34,  'Ley N° 453: La entidad financiera debe informar por escrito los motivos por los cuales ' + 
     'se denegó un crédito.')
     INSERT ctb006 VALUES(35, 'Ley N° 453: Los medios de comunicación deben difundir mensajes o programas de ' + 
     'educación de consumo responsable y sustentable.')
     INSERT ctb006 VALUES(36, 'Ley N° 453: Los medios de comunicación deben promover el respeto de los derechos de ' + 
     'los usuarios y consumidores.')
     INSERT ctb006 VALUES(37, 'Ley N° 453: Las publicaciones, mensajes e imágenes no deben promover la sumisión o ' + 
     'explotación de las mujeres.')
     INSERT ctb006 VALUES(38, 'Ley N° 453: Las publicaciones, mensajes e imágenes no deben deshonrar y atentar ' + 
     'contra la dignidad e imagen de la mujer.')
     INSERT ctb006 VALUES(39, 'Ley N° 453: Los medios de comunicación deben evitar contenidos inapropiados que ' + 
     'vulneren la protección de niñas, niños y adolescentes.')
GO  
/*--**********************************************
ARCHIVO:	ctb007.sql
TABLA:		Tabla de dosificacion
AUTOR:		FVM-CREARSIS
FECHA:		05-07-2017
*/--**********************************************


CREATE TABLE ctb007(
	va_nro_aut DECIMAL(15,0)		NOT NULL,	--** Numero de Autorizació
	va_tip_fac INT					NOT NULL,	--** Tipo de Factuta (0=Computarizada; 1=Manual)
	va_fec_ini DATE					NOT NULL,	--** Fecha de tramite dosificacion
	va_fec_fin DATE					NOT NULL,	--** Fecha limite de factura
	va_nro_ini INT					NOT NULL,	--** Numero unicial
	va_nro_fin INT					NOT NULL,	--** Numero final
	va_cod_suc INT					NOT NULL,	--** Codigo de sucursal
	va_cod_act INT					NOT NULL,	--** Cosigo de Actividad Economica
	va_cod_ley INT					NOT NULL,	--** Codigo Leyenda
	va_lla_vee VARCHAR(500)			NULL,		--** Llave dosificacion	
	va_con_act INT					NOT NULL,	--** Contador Actual de la factura

CONSTRAINT pk1_ctb007 PRIMARY KEY(va_nro_aut)
)

GO  
 /**********************************************************/
     /* SCRIPT : ctb008.sql								*/
     /* Crea la Tabla "debito fiscal"									*/
     /* Autor :  CREARSIS - CHL									*/
     /**********************************************************/
--use BD_Rest

go
     PRINT '08.- Creando la tabla : Debito Fiscal'
	
     CREATE TABLE ctb008 (
       --** Llave Primaria
      va_ges_tio		INT     			NOT NULL,	--** Gestion del documento
	  va_per_ges		INT					NOT NULL,	--** Periodo de la gestion
	  va_ide_fac		NVARCHAR(30)		NOT NULL,	--** IDE de la venta concatena(XXX-000-000000-0000) 
      va_nro_fac	    INT					NOT NULL,	--** Numero de factura
     
      --** Atributos     
      va_nro_dos		NVARCHAR(20)		NOT NULL,	--** Numero de dosificacion/autorizacion
      va_nit_per		DECIMAL(15,0)		NOT NULL,	--** Nit de la persona
      va_raz_soc		NVARCHAR(120)		NOT NULL,	--** Razon social de la persona
      
      va_mto_fac		DECIMAL(16,4)		NOT NULL,	--** Monto total de la factura
      va_dto_fac		DECIMAL(16,4) 		NOT NULL,	--** Monto de descuento de la factura
      va_net_fac		DECIMAL(16,4)		NOT NULL,	--** Monto neto de la factura (de aca se saca el 13%)
      va_mto_iva		DECIMAL(16,4)		NOT NULL,	--** (va_net_fac * 0.13) iva=13%
      va_cod_con		NVARCHAR(20)		NOT NULL,	--** Codigo de control
      va_fec_fac		DATE				NOT NULL,	--** Fecha de la factura
      va_fec_reg		DATETIME			NOT NULL,   --** Fecha en que realmente fue registrado		
      va_img_qrf		VARBINARY(MAX)		NULL,	--** Guarda la imagen del qr de la factura
      
      CONSTRAINT pk1_ctb008 PRIMARY KEY(va_ges_tio,va_per_ges,va_ide_fac,va_nro_fac)
     )
     GO
     
       

/*--**********************************************
ARCHIVO:	ecp001.sql
TABLA:		Plan de Pago
AUTOR:		CHL-CREARSIS
FECHA:		10-10-2021
*/--**********************************************
	
CREATE TABLE ecp001 
(
va_cod_plg		INT				NOT NULL,	--Código Plan de Pago (3 Numeros)
va_des_plg		VARCHAR(50)		NOT NULL,	--Descripcion
va_nro_cuo		TINYINT			NOT NULL,	--Numero de Cuotas (2 numeros)
va_int_dia		TINYINT			NOT NULL,	--Intervalo de Dias entre Cuotas (2 numeros)
va_dia_ini		TINYINT			NOT NULL,	--dia inicial p/primer cuota (2 numeros)
va_est_ado		CHAR(1)			NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_ecp001 PRIMARY KEY(va_cod_plg)
)
  
/*--**********************************************
ARCHIVO:	ecp002.sql
TABLA:		Libreta
AUTOR:		CHL-CREARSIS(ALDA)
FECHA:		03-12-2017
*/--**********************************************

CREATE TABLE ecp002 
(
va_cod_lib		INT				NOT NULL,	--Código de la Libreta(5 Numeros)
va_des_lib		VARCHAR(50)		NOT NULL,	--Descripcion

--Llave foranea
va_cod_cta		VARCHAR(12)		NOT NULL,	--Cod. Cuenta Contable

va_tip_lib		INT				NOT NULL,	--Tipo (1=CxC('Cuentas por Cobrar') ; 2=CxP('Cuentas por Pagar')
va_mon_lib		CHAR(1)			NOT NULL,	--Moneda (B=Bolivianos; U=USD)
va_est_ado		CHAR(1)			NOT NULL	--Estado (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_ecp002 PRIMARY KEY(va_cod_lib)
)
  
/*--**********************************************
ARCHIVO:	ecp003.sql
TABLA:		Inscripción Personas-Libretas
AUTOR:		CHL-CREARSIS(CHL)
FECHA:		11-11-2021
*/--**********************************************
	
CREATE TABLE ecp003 
(
va_cod_lib		INT				NOT NULL,					--Código de la Libreta(ecp002)
va_cod_per		INT				NOT NULL	DEFAULT(''),	--ID. Persona 
va_cod_plg		INT				NOT NULL,					--Código Plan de Pago(ecp005)

va_mto_lim		DECIMAL(12,2)	NOT NULL	DEFAULT(0),		--Monto Limite
va_sal_act		DECIMAL(12,2)	NOT NULL	DEFAULT(0),		--Saldo Actual
va_max_cuo		INT				NOT NULL	DEFAULT(0),		--
va_fec_exp		DATE			NOT NULL,					--Fecha de Expiracion
va_est_ado		CHAR(01)		NOT NULL	DEFAULT(''),	--Estado de la inscripcion (H=habilitado N=Deshabilitado)

CONSTRAINT pk1_ecp003 PRIMARY KEY(va_cod_lib,va_cod_per,va_cod_plg)
)
  
/*########################################################
ARCHIVO:	inv001.sql
TABLA:		Grupo de Bodegas
AUTOR:		CHL
FECHA:		21/07/2020
########################################################*/

CREATE TABLE inv001
(
va_ide_gru 		INT			 	NOT NULL,	--Ide de grupo de bodega
va_nom_gru		CHAR(30)		NOT NULL,	--Nombre de grupo de bodega
va_des_gru		VARCHAR(160) 	NOT NULL,	--Descripcion de grupo de bodega
va_est_ado		CHAR(01)		NOT NULL	--Estado

CONSTRAINT pk1_inv001 PRIMARY KEY(va_ide_gru)
)

go
  
/*--**********************************************
ARCHIVO:	inv002.sql
TABLA:		Tabla de Bodega
AUTOR:		CHL-CREARSIS(CHL)
FECHA:		26-07-2020
*/--*********************************************

CREATE TABLE inv002
(
va_ide_gru		SMALLINT		NOT NULL,	--Grupo de Almacen (4 numeros)
va_cod_bod		INT				NOT NULL,	--Codigo deL ALMACEN (#####) -> compuesto por (va_cod_gru , va_nro_bod)	

va_nom_bod		VARCHAR(40)		NOT NULL,	--Nombre del almacen
va_des_bod		VARCHAR(160)	NOT NULL,	--Descripcion del almacen
va_dir_bod		VARCHAR(200),				--Direccion del almacen
va_fec_ctr		DATE			NOT NULL,	--ULTIMA FECHA CONTROL  DEL ALMACEN
va_mon_inv		CHAR(01)		NOT NULL,	--Moneda del inventario B=Bolivianos ; U=Dolares
va_mtd_cto		CHAR(01)		NOT NULL,	/* Metodo de costeo 
												P=Promedio Ponderado (Solo usaremos este inicialmente) 
												C=UEPS (Ultimos en Entrar, Primeros en Salir)
												A=PEPS (Primeros en Entrar Primeros en Salir)*/

	 
va_nom_ecg		VARCHAR(120)	NOT NULL,	--Nombre del encargado del almacen
va_tlf_ecg		VARCHAR(10),				--Telefono del encargado
va_dir_ecg		VARCHAR(200),				--Direccion del encargado
va_est_ado		CHAR(01)		NOT NULL,	--Estado del almacen
	  														

      	
       
CONSTRAINT pk1_inv002 PRIMARY KEY(va_ide_gru,va_cod_bod)
)  
/*--**********************************************
ARCHIVO:	inv003.sql
TABLA:		Familia de Producto
AUTOR:		CHL-CREARSIS
FECHA:		23-07-2020
*/--**********************************************
	
CREATE TABLE inv003 
(
va_cod_fam		VARCHAR(6)		NOT NULL,	--Código de la familia de producto
va_nom_fam		VARCHAR(50)		NOT NULL,	--Nombre de la familia
va_tip_fam		CHAR(1)			NOT NULL,	--Tipo de la cuenta (M=Matriz ; D=DETALLE ; S=Servicio C=Combo)
va_est_ado		CHAR(1)			NOT NULL	--Estado de la cuenta (H=Habilitado ; N=Deshabilitado)		  
      
CONSTRAINT pk1_inv003 PRIMARY KEY(va_cod_fam)
)

     
       
/*--**********************************************
ARCHIVO:	inv004.sql
TABLA:		Tabla de "Producto"
AUTOR:		CREARSIS 3.0.0 (
FECHA:		23-07-2020
*/--**********************************************

CREATE TABLE inv004 
(
--** Llave Primaria
va_cod_pro	VARCHAR(15)	NOT NULL,					--** Codigo del producto 

--** Llaves Foreaneas
va_cod_fam	VARCHAR(6)		NOT NULL,					--** Codigo de la familia de producto
va_cod_umd	CHAR(3)			NOT NULL,					--** (inv003-Und. Med)Codigo de la Unidad de Medida
va_und_cmp	CHAR(3)			NOT NULL,					--** (inv003-Und. Med)Codigo de la unidad de compra
va_und_vta	CHAR(3)			NOT NULL,					--** (inv003-Und. Med)Codigo de la unidad de venta
va_cod_mar	CHAR(3)			NOT NULL,					--** Codigo de la Marca del producto


--** Atributos     
va_nom_pro	VARCHAR(80)	NOT NULL,						--** Nombre del producto
va_des_pro	VARCHAR(200)	NOT NULL,					--** Descripcion del producto
va_cod_bar	VARCHAR(20)	NOT NULL,						--** Codigo de barra del producto
va_fab_ric	VARCHAR(50)	NOT NULL,						--** Fabricante al que pertenece el producto      
va_eqv_cmp	DECIMAL(6,2)	NOT NULL	DEFAULT(1),		--** Cantidad de unidad de medida por unidad de compra     
va_eqv_vta	DECIMAL(6,2)	NOT NULL	DEFAULT(1),		--** Cantidad de unidad de medida por unidad de presentacion (venta) 
va_nro_dec	INT				NOT NULL	DEFAULT(0),		--** Nro de decimales a manejar el inventario    
va_ban_ser	TINYINT				NOT NULL,					--** Bandera identifica si el producto se maneja por ¨serie 
															/* 0=No ; 
															1= si en todas
															2= solo en salidas	*/ 
     
va_ban_lot	CHAR(1)			NOT NULL,					--** Bandera identifica si el producto se maneja por LOTE 1=SI ; 2=NO
va_est_ado	CHAR(1)			NOT NULL,					  --** Estado del producto
      
      
CONSTRAINT pk1_inv004 PRIMARY KEY(va_cod_pro)
)
GO

     
       
/*--**********************************************
ARCHIVO:	inv005.sql
TABLA:		Tabla de Unidades de Medida
AUTOR:		CHL-CREARSIS
FECHA:		23-07-2020
*/--**********************************************

CREATE TABLE inv005 
(
va_cod_umd		VARCHAR(3)		NOT NULL,	--Codigo de la Unidad de medida
va_nom_umd		VARCHAR(50)		NOT NULL,	--Nombre de la Unidad de medida

CONSTRAINT pk1_inv005 PRIMARY KEY(va_cod_umd)
)
GO
     
--INSERT INICIAL
INSERT INTO inv005 VALUES ('MTS','Metros')
INSERT INTO inv005 VALUES ('KLS','Kilos')
INSERT INTO inv005 VALUES ('LTS','Litros')
INSERT INTO inv005 VALUES ('UND','Unidad')
INSERT INTO inv005 VALUES ('PZA','Pieza')  
/*--**********************************************
ARCHIVO:	inv006.sql
TABLA:		Tabla de Marcas
AUTOR:		CHL-CREARSIS 
FECHA:		27-11-2017
*/--**********************************************

CREATE TABLE inv006
(
va_cod_mar		SMALLINT		NOT NULL,	--Codigo de la Marca (3 numeros)
va_nom_mar		VARCHAR(50)		NOT NULL,	--Nombre de la Marca

CONSTRAINT pk1_inv006 PRIMARY KEY(va_cod_mar)
)
GO
    
--INSERT INICIAL
INSERT INTO inv006 VALUES (1,'S/M')  
/*--**********************************************
ARCHIVO:	inv007.sql
TABLA:		Tabla del Documento de Compra(Cabecera)
AUTOR:		CREARSIS(Jorge)
FECHA:		15-02-2018
*/--*********************************************
	
CREATE TABLE inv007(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_doc_doc		CHAR(03)		NOT NULL,	--Documento de Compra
	va_nro_tal		INT				NOT NULL,	--Numero de talonario
	va_nro_cmp		INT				NOT NULL,	--Numero de documento
	va_ges_cmp		SMALLINT		NOT NULL,	--GestiÃ³n de la compra (adm002) (4 numeros)
	va_ide_cmp		VARCHAR(20)		NOT NULL,	--Identificador de la compra (XXX|000-00000/2018)

	--Llave ForÃ¡nea
	va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del Proveedor (cmr013) (7 numeros)
	va_raz_soc		VARCHAR(180)			,	--Razon social del proveedor 
	va_fec_cmp		DATE					,	--Fecha de la compra
	va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

	va_mon_cmp		CHAR(1)					,	--Moneda de la compra  (B=Bolivianos; U= Dolares)
	va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

	va_cod_caj		INT						,	--Codigo de la caja/banco para compra al contado (5 numeros)
	va_cod_lcr		INT						,	--Libreta x pagar para compras al credito (5 numeros)
	va_ref_cmp		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si la compra es hecha en base a una cotizacion u otro)

	va_cod_bod		INT						,	--Codigo del bodega (7 numeros)

	va_tip_cmp		INT						,	-- Tipo de Compra [0=Sin Fac. ; 1=Con Fac.]
	va_ban_fac		INT						,	-- Bandera Factura [0=NO  ; 1=SI hay  ; 2= Por Recuperar]
	va_lib_cpr		INT						,	-- Libreta Credito Fiscal por Recuperar (en caso que va_ban_fac=2) (5 numeros)
	
	va_fec_emi		datetime not null		,	-- Fecha de Emision(este campo aplica mas para las factura)
	va_tot_bBs		decimal(16,2) not null	,	-- Valor Bruto en Bs. de la Compra
	va_tot_bUs		decimal(16,2) not null	,	-- Valor Bruto en Us. de la Compra
	va_des_cBs		decimal(14,2) not null default 0, -- Valor del Descuento en Bs. de la Compra
	va_des_cUs		decimal(14,2) not null default 0, -- Valor del Descuento en Us. de la Compra
	va_tot_nBs		decimal(16,2) not null default 0, -- Valor Neto en Bs. de la Compra
	va_tot_nUs		decimal(16,2) not null default 0, -- Valor Neto en Us. de la Compra
	va_obs_cmp		nvarchar(100) not null default '', -- Observacion de la Compra
	--Datos Impositivos en Bs.
	va_nro_fac		int not null default 0,				-- Nro. de Factura
	va_nit_fac		bigint not null default 0,			-- NIT del Proveedor 
	va_raz_fac		nvarchar(100) null default '',		-- Razon Social del Proveedor
	va_nro_aut		varchar(20) null,					-- Nro. de Autorizacion
	va_cod_ctr		varchar(20) null,					-- Codigo de Control
	va_tot_exe		decimal(16,2) not null default 0,	--Total Valor Exento
	va_tot_suj		decimal(16,2) not null default 0,	-- Total Sujeto a Impuestos
	va_tot_imp		decimal(14,2) not null default 0,	--Valor de impuesto IVA 13%
	va_rim_itr		decimal(12,2) not null default 0,	-- Total de la Retencion de IT 3%
	va_riu_bie		decimal(12,2) not null default 0,	-- Total de la Retencion de IUE para Bienes 5%
	va_riu_ser		decimal(12,2) not null default 0,	-- Total de la Retencion de IUE para Servicios 12.5 %
	va_rie_alq		decimal(12,2) not null default 0,	-- Total de la Retencion de IUE para Alquileres 13 %

	va_usr_reg		VARCHAR(15)				,			--Usuario que registro la compra
	va_fec_reg		DATETIME				,			--Fecha real del registro
	va_usr_anu		VARCHAR(15)				,			--Usuario que anulo
	va_fec_anu		DATETIME				,			--Fecha real de la anulacion
	va_fec_cer		DATETIME,							--Fecha que fue Cerrado el Documento	
	va_est_ado		CHAR(01)							--Estado H=Abierto,C=Cerrado,A=Anulado
	
	CONSTRAINT pk1_inv007 PRIMARY KEY(va_doc_doc,va_nro_tal,va_nro_cmp,va_ges_cmp)
)




  
/*--**********************************************
ARCHIVO:	inv007tmp.sql
TABLA:		Tabla detalle de compra temporal
AUTOR:		CREARSIS(chl)
FECHA:		20-09-2020
*/--*********************************************
-- select * from inv007tmp
CREATE TABLE inv007tmp(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)

	--Llave Foránea
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_und_cmp		char(3)			null,		--Codigo de la Unidad de Medida
	va_can_cmp		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
												--(S=Servicio ; D=Detalle; C=Combo)
	
	CONSTRAINT pk1_inv007tmp PRIMARY KEY(va_cod_usr,va_cod_tmp,va_nro_itm)

)  
/*--**********************************************
ARCHIVO:	inv008.sql
TABLA:		Tabla del Detalle de Compra
AUTOR:		CREARSIS(CHL)
FECHA:		20-09-2020
*/--********************************************* 
CREATE TABLE inv008(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_doc_doc		CHAR(03)		NOT NULL,	--Documento de Compra
	va_nro_tal		INT				NOT NULL,	--Numero de talonario
	va_nro_cmp		INT				NOT NULL,	--Numero de documento
	va_ges_cmp		SMALLINT		NOT NULL,	--Gestión de la compra (adm002) (4 numeros)
	va_ide_cmp		VARCHAR(20)		NOT NULL,	--Identificador de la compra (XXX|000-00000/2018)
	va_nro_itm		int				not null,	--Numero de item del Documento de Compra
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
	va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para la compra
	va_cod_uni		char(3)			null,		--Codigo de la Unidad de Medida  Inventario
	va_cod_unc		char(3)			null,		--Codigo de la Unidad de Medida  Compra
	va_can_uiv		DECIMAL(14,4),				--Cantidad unidad inventario
	va_can_ucm		DECIMAL(14,4),				--Cantidad unidad compra
	va_pre_uBs		DECIMAL(14,4),				--Precio Unitario Bs (en unidad de inventario)
	va_pre_uUs		DECIMAL(14,4),				--Precio Unitario Us (en unidad de inventario)
	va_imp_tBs		DECIMAL(16,2),				--Importe Total BS.(Importe Total + Importe de Gastos)
	va_imp_tUs		DECIMAL(16,2),				--Importe Total US.(Importe Total + Importe de Gastos)
	va_des_uni		DECIMAL(16,2),				--Descuento prorateado en moneda del documento
	va_lot_cod		varchar(50)		DEFAULT 0,	--Código de Lote
	va_ser_cod		varchar(50)		DEFAULT 0,	--Código de serie
	
CONSTRAINT PK_inv008 PRIMARY KEY ( va_doc_doc, va_nro_tal,va_nro_cmp, va_ges_cmp, va_ide_cmp, va_nro_itm)
)

GO  
/*--**********************************************
ARCHIVO:	inv009.sql
TABLA:		Tabla Tallas
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv009 
(
va_cod_tal		INT				NOT NULL,	--Codigo de la Talla
va_nom_tal		VARCHAR(50)		NOT NULL,	--Nombre de la Talla
va_est_ado		CHAR(01)		NOT NULL	--Estado
CONSTRAINT pk1_inv009 PRIMARY KEY(va_cod_tal)
)
GO
     
--INSERT INICIAL
INSERT INTO inv009 VALUES (6,'36','H')
INSERT INTO inv009 VALUES (8,'38','H')
INSERT INTO inv009 VALUES (10,'40','H')
INSERT INTO inv009 VALUES (12,'42','H')
INSERT INTO inv009 VALUES (14,'44','H')

INSERT INTO inv009 VALUES (20,'S','H')
INSERT INTO inv009 VALUES (22,'M','H')
INSERT INTO inv009 VALUES (24,'L','H')
INSERT INTO inv009 VALUES (26,'XL','H')

GO  
/*--**********************************************
ARCHIVO:	inv010.sql
TABLA:		Tabla Colors
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv010 
(
va_cod_col		INT				NOT NULL,	--Codigo de la Color
va_nom_col		VARCHAR(50)		NOT NULL,	--Nombre de la Color
va_est_ado		CHAR(01)		NOT NULL	--Estado
CONSTRAINT pk1_inv010 PRIMARY KEY(va_cod_col)
)
GO
     
--INSERT INICIAL
INSERT INTO inv010 VALUES (1,'Azul','H')
INSERT INTO inv010 VALUES (2,'Celeste','H')
INSERT INTO inv010 VALUES (3,'Negro','H')
INSERT INTO inv010 VALUES (4,'Verde','H')

GO  
/*--**********************************************
ARCHIVO:	inv011.sql
TABLA:		Tallas permitidas por linea de producto
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv011 
(
va_cod_fam		VARCHAR(06)		NOT NULL,	--Codigo linea de producto
va_cod_tal		INT				NOT NULL,	--Codigo talla

CONSTRAINT pk1_inv011 PRIMARY KEY(va_cod_fam,va_cod_tal)
)
GO
  
/*--**********************************************
ARCHIVO:	inv012.sql
TABLA:		Colores permitidos por linea de producto
AUTOR:		CHL-CREARSIS
FECHA:		24-02-2021
*/--**********************************************

CREATE TABLE inv012 
(
va_cod_fam		VARCHAR(06)		NOT NULL,	--Codigo linea de producto
va_cod_col		INT				NOT NULL,	--Codigo color

CONSTRAINT pk1_inv012 PRIMARY KEY(va_cod_fam,va_cod_col)
)
GO
  
/*--**********************************************
ARCHIVO:	inv099.sql
TABLA:		Tabla de Saldos Fisicos y Valorados
AUTOR:		CREARSIS()
FECHA:		18-08-2020
*/--*********************************************

CREATE TABLE inv099(
	--Cuanto tiene de stock actual un almacÃ©n de ese producto
	va_cod_bod INT				NOT NULL,	--Codigo deL ALMACEN (inv011)
	va_cod_pro VARCHAR(15)		NOT NULL,	--Codigo de Producto (inv002)
	va_sal_can DECIMAL(14,2)	Default 0,	--Stock total x almacÃ©n (unidad inventario)
	va_cos_ubs DECIMAL(14,6)	Default 0,	--Costo Unitario (promedio ponderado en Bs)
	va_cos_uus DECIMAL(14,6)	Default 0	--Costo Unitario (promedio ponderado en USD)
)

  
/*--**********************************************
ARCHIVO:	inv100.sql
TABLA:		Tabla de Movimiento de Inventario
AUTOR:		CREARSIS(Jorge)
FECHA:		04-02-2018
*/--*********************************************
	
CREATE TABLE inv100(
	va_ges_tio INT				NOT NULL,	--CÃ³digo de GestiÃ³n
	va_cod_doc CHAR(3)			NOT NULL,	--Codigo del documento (XXX)
	va_nro_tal INT				NOT NULL,	--Numero de talonario(000)
	va_nro_doc INT				NOT NULL,	--Numero del documento
	va_ide_doc VARCHAR(20)		NOT NULL,	--Identificador del documento (XXX|000-00000/2018)
	va_nro_itm INT				NOT NULL,	--NÃºmero de item en el documento
	va_fec_doc DATETIME			NOT NULL,	--Fecha del documento
	va_fec_reg DATETIME			NOT NULL,	--Fecha de registro real
	va_ref_doc VARCHAR(20)				NOT NULL DEFAULT (''),		--Nro de Referencia Ã³ Numero de Documento
	va_mon_eda CHAR(01)			NOT NULL,	--Moneda (B=Bolivianos; D=Dolares)
	va_glo_doc VARCHAR(100)		NOT NULL,	--Glosa del documento
	va_cod_pro VARCHAR(15)		NOT NULL,	--Codigo del Producto
	
	va_can_ing DECIMAL(14,4),				--Cantidad Ingreso en unidad inventario con signo(+)
	va_can_egr DECIMAL(14,4),				--Cantidad Egreso en unidad inventario con signo(-)
	
	va_cos_uoB DECIMAL(14,4),				--Costo Unitario de la operacion en bs
	va_cos_uoU DECIMAL(14,4),				--Costo Unitario de la operacion en Us
	
	va_cos_toB DECIMAL(14,4),				--Costo Total Operacion en bs
	va_cos_toU DECIMAL(14,4),				--Costo Total Operacion en Us
	
	va_cos_upB DECIMAL(14,4),				--Costo Unitario promediado en bs
	va_cos_upU DECIMAL(14,4),				--Costo Unitario promediado en Us
	
	va_cod_bod INT				NOT NULL,	--Codigo deL ALMACEN (inv011)
	va_lot_pro VARCHAR(50)		DEFAULT 0,	--Lote de producto
	va_tas_cam DECIMAL(6,4)		DEFAULT 0,	-- Tipo de Cambio de la Transaccion
	va_cod_usr NVARCHAR(15)		NOT NULL	--Codigo del Usuario
	
	CONSTRAINT pk1_inv100 PRIMARY KEY(va_ges_tio,va_cod_doc,va_nro_tal,va_nro_itm,va_fec_doc,va_fec_reg)
	)
	





  
/*########################################################
ARCHIVO:	pto001.sql
TABLA:		Draga
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE pto001
(
va_ide_dra		INT				NOT NULL,	--Ide. draga  
va_nom_dra		VARCHAR(60)		NOT NULL,	--Nombre draga
va_des_dra		VARCHAR(120)	NOT NULL,	--Descripcion draga
va_res_pon		INT				NOT NULL,	--Codigo Persona responsable
va_res_tel		VARCHAR(10)				,	--Telefono del responsable											
va_ide_pto		INT				NOT NULL,	--Ide de puerto
va_est_ado		INT 						--Estado


CONSTRAINT pk1_pto001 PRIMARY KEY(va_ide_dra)
)

go
  
/*########################################################
ARCHIVO:	pto002.sql
TABLA:		Pala
AUTOR:		CHL
FECHA:		08/01/2020
########################################################*/

CREATE TABLE pto002
(
va_ide_pal		INT				NOT NULL,	--Ide. pala  
va_nom_pal		VARCHAR(60)		NOT NULL,	--Nombre pala
va_des_pal		VARCHAR(120)	NOT NULL,	--Descripcion pala
va_res_pon		INT				NOT NULL,	--Codigo Persona responsable
va_res_tel		VARCHAR(10)				,	--Telefono del responsable											
va_ide_pto		INT				NOT NULL,	--Ide de puerto
va_est_ado		INT 						--Estado


CONSTRAINT pk1_pto002 PRIMARY KEY(va_ide_pal)
)

go
  
/*########################################################
ARCHIVO:	pto003.sql
TABLA:		Puerto
AUTOR:		CHL
FECHA:		08/01/2020
########################################################*/

CREATE TABLE pto003
(
va_ide_pto		INT				NOT NULL,	--Ide. puerto  
va_nom_pto		VARCHAR(60)		NOT NULL,	--Nombre puerto
va_des_pto		VARCHAR(120)	NOT NULL,	--Descripcion puerto
va_dir_pto		VARCHAR(120)	NOT NULL,	--Direccion puerto
va_ubi_pto		GEOGRAPHY		NOT NULL,	--Ubicacion puerto
va_res_pon		INT				NOT NULL,	--Codigo Persona responsable
va_res_tel		VARCHAR(10)				,	--Telefono del responsable											
va_est_ado		INT 			NOT NULL	--Estado


CONSTRAINT pk1_pto003 PRIMARY KEY(va_ide_pto)
)

go
  
/*########################################################
ARCHIVO:	pto004.sql
TABLA:		Contrato
AUTOR:		CHL
FECHA:		08/01/2020
########################################################*/

CREATE TABLE pto004
(
va_ide_cto 		INT				NOT NULL,	--Ide. puerto  
va_nom_pto		VARCHAR(60)		NOT NULL,	--Nombre puerto
va_des_pto		VARCHAR(120)	NOT NULL,	--Descripcion puerto
va_dir_pto		VARCHAR(120)	NOT NULL,	--Direccion puerto
va_ubi_pto		GEOGRAPHY		NOT NULL,	--Ubicacion puerto
va_res_pon		INT				NOT NULL,	--Codigo Persona responsable
va_res_tel		VARCHAR(10)				,	--Telefono del responsable											
va_est_ado		INT 			NOT NULL	--Estado


CONSTRAINT pk1_pto004 PRIMARY KEY(va_ide_cto)
)

go
  
/*--**********************************************
ARCHIVO:	res001.sql
TABLA:		Tabla de Encabezado de Vetas Restaurant
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		24-03-2017
*/--**********************************************
--drop table cmr005
CREATE TABLE res001
(
--Llaves primarias
va_doc_vta		CHAR(03)		NOT NULL,	--Documento de venta
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_vta		INT				NOT NULL,	--Numero de documento
va_ges_vta		SMALLINT		NOT NULL,	--Gestión de la venta (adm002) (4 numeros)
va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador de la venta (XXX|000-00000/2018)

--Llave Foránea
va_tip_vta		INT				NOT NULL,	--Tipo de venta ( 2= Nota de Venta ; 1=Factura )
va_nro_fac		INT				NOT NULL DEFAULT(0),	-- Nro de factura

va_cod_per		VARCHAR(7)		NOT NULL,	--Codigo del cliente (adm010) (7 numeros)
va_raz_soc		VARCHAR(180)			,	--Razon social del cliente 
va_nit_vta		VARCHAR(15)				,	--Nit del cliente
va_fec_vta		DATE					,	--Fecha de la venta
va_tip_cam		DECIMAL(6,5)			,	--Tipo de cambio Bs/Us

--Llave Foránea
va_cod_plv		INT						,	--Plantilla de venta
va_cod_ven		SMALLINT				,	--Codigo de vendedor (cmr003) (4 numeros)

va_mon_vta		CHAR(1)					,	--Moneda de la venta  (B=Bolivianos; U= Dolares)
va_for_pag		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)

--Llaves Foráneas
va_cod_caj		INT						,	--Codigo de la caja para ventas al contado (5 numeros)
va_cod_lcr		INT						,	--Libreta para ventas al credito (5 numeros)

va_ref_vta		VARCHAR(20)				,	--Documento de referencia interna (XXX|000-00000/2018) (si la venta es hecha en base a una cotizacion u otro)

--Llaves Foráneas
va_cod_bod		CHAR(06)				,	--Codigo del almacen (7 numeros)
va_cod_lis		INT						,	--Codigo de lista (7 numeros)
va_vta_par		CHAR(01)				,	-- Venta para (M=Mesa ; D=Delivery ; L=Llevar)

va_cod_del		INT						,	-- Codigo del delivery
va_por_del		DECIMAL(3,1)			,	-- Porcentaje correspondiente al delivery


va_sub_toB		DECIMAL(16,5)			,	--Sub total de la venta Bolivianos
va_sub_toU		DECIMAL(16,5)			,	--Sub total de la venta Dolares
va_dto_vtB		DECIMAL(16,5)			,	--Descuento de la venta Bs
va_dto_vtU		DECIMAL(16,5)			,	--Descuento de la venta Us
va_tot_vtB		DECIMAL(16,5)			,	--Total de la venta Bs
va_tot_vtU		DECIMAL(16,5)			,	--Total de la venta Us

va_obs_vta		VARCHAR(180)			,	--Observacion de la venta

va_usr_reg		VARCHAR(15)				,	--Usuario que registro la venta
va_fec_reg		DATETIME				,	--Fecha real del registro
va_usr_anu		VARCHAR(15)				,	--Usuario que anulo
va_fec_anu		DATETIME				,	--Fecha real del registro
va_est_ado		CHAR(01)					--Estado


CONSTRAINT pk1_res001 PRIMARY KEY(va_doc_vta,va_nro_tal,va_nro_vta,va_ges_vta)


)

  
/*--**********************************************
ARCHIVO:	res002.sql
TABLA:		Tabla de Detalle de Venta
AUTOR:		CHL-CREARSIS-BABOO
FECHA:		26-02-2018
*/--**********************************************
--drop table cmr006
CREATE TABLE res002
(
-- Llaves primarias
va_doc_vta		CHAR(03)		NOT NULL,	--Documento de venta
va_nro_tal		INT				NOT NULL,	--Numero de talonario
va_nro_vta		INT				NOT NULL,	--Numero de documento
va_ges_vta		SMALLINT		NOT NULL,	--Gestión de la venta
va_ide_vta		VARCHAR(20)		NOT NULL,	--Identificador de la venta (XXX|000-00000/2018)
va_itm_vta		INT				NOT NULL,	--Nro de item de la venta

va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo del producto
va_des_pro		VARCHAR(200)	NOT NULL,	--Nombre/Descripcion del producto

va_opc_und		INT				NOT NULL,	-- Opcion de Unidad elegida para la venta
											  -- (1= Unidad de medida Venta ; 2= Unidad de medida inventario)

va_und_vta		CHAR(03)		NOT NULL,	--Unidad de medida Venta											  
va_und_inv		CHAR(03)		NOT NULL,	--Unidad de medida Inventario
va_eqv_und		DECIMAL(6,2)	NOT NULL,	--equivalencia de la Und en la venta con la Und. inventario

va_can_unv		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Venta) solo para fin de calculo
va_can_uni		DECIMAL(15,5)	NOT NULL,	--Cantidad del producto (Unidad Inventario)la que da de baja al inventario

va_pre_lis		DECIMAL(15,5)	NOT NULL,	--Precio de lista en la moneda de la venta

va_mto_brB		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Bs
va_mto_brU		DECIMAL(15,5)	NOT NULL,	--Monto Total Bruto en Us
va_val_dtB		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Bs
va_val_dtU		DECIMAL(15,5)	NOT NULL,	--Valor decuento en Us
va_por_dto		DECIMAL(15,5)	NOT NULL,	--porcentaje de descuento proporcionado
va_mto_neB		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Bs
va_mto_neU		DECIMAL(15,5)	NOT NULL,	--Monto Total Neto en Us

va_cto_uBS		DECIMAL(15,5)	NOT NULL,	--Costo Unitario en Bs
va_cto_uUS		DECIMAL(15,5)	NOT NULL,	--Costo Unitario en Us

va_iva_uBS		DECIMAL(15,5)	NOT NULL,	--IVA Unitario en Bs
va_iva_uUS		DECIMAL(15,5)	NOT NULL,	--IVA Unitario en Us
va_itr_uBS		DECIMAL(15,5)	NOT NULL,	--ITR Unitario en Bs
va_itr_uUS		DECIMAL(15,5)	NOT NULL,	--ITR Unitario en Us

CONSTRAINT pk1_res002 PRIMARY KEY(va_doc_vta,va_nro_tal,va_nro_vta,va_itm_vta,va_ges_vta)
)

  
/*--**********************************************
ARCHIVO:	res002tmp.sql
TABLA:		Tabla detalle de VENTA RESTAURANT temporal
AUTOR:		CREARSIS(chl)
FECHA:		12-10-2018
*/--*********************************************
CREATE TABLE res002tmp(
	--PRIMARY key
	-- Atributos
	--Llaves primarias
	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)

	--Llave Foránea
	va_nro_itm		INT				not null,	--Numero de item 
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_des_pro		varchar(80)		not null,	--Descripcion del Producto	 
	va_opc_und		INT						,	--Codigo de la Unidad de Medida
	
	va_can_tid		DECIMAL(14,4),				--Cantidad de producto
	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento (digitado x usuario)
	va_pre_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento (va_pre_uni * va_can_tid
	
	va_pre_lis		DECIMAL(14,4),				--Precio definido en la lista de precio
	va_des_cue		DECIMAL(14,4),				--Descuento en moneda del documento
	va_por_cen		DECIMAL(14,4)				--Porcentaje de descuento
		/**/
	CONSTRAINT pk1_res002tmp PRIMARY KEY(va_cod_usr,va_cod_tmp,va_nro_itm)

)  
/*--**********************************************
ARCHIVO:	res004.sql
TABLA:		Tabla de Plantilla de Venta Restaurant
AUTOR:		CHL-CREARSIS
FECHA:		27-10-2020
*/--**********************************************

CREATE TABLE res004
(
	va_cod_plv		SMALLINT		NOT NULL,	--Codigo de plantilla de venta (3 números)
	va_nom_plv		VARCHAR(30)		NOT NULL,	--Nombre de la plantilla
	va_des_plv		VARCHAR(120)	NOT NULL,	--Descripcion de la plantilla
	
	va_cod_bod		INT						,	--Codigo de almacen (inv002) (##-##-###) -> compuesto por (va_cod_gru , va_nro_alm)	
	va_cam_bod		TINYINT					,	--Bandera cambia almacen ? (0=NO ; 1=SI)
	
	va_cod_cli		VARCHAR(07)				,	--Cliente por defecto (adm013) (##-#####) (2 de Grup. Per y 5 de Persona)
	va_cod_caj		INT						,	--Caja para las ventas al contado (tes001) (5 Números)
	va_cam_caj		TINYINT					,	--Bandera cambia caja ? (0=NO ; 1=SI)
	
	va_cod_lis		INT						,	--Lista de precio por defecto (cmr001)  
	va_cam_lis		TINYINT					,	--Bandera, cambia lista ? (0=NO; 1=CAMBIA ; 2=Si o si la Asignada al cliente)
	--va_mon_vta		CHAR(1)					,	--Moneda de la venta (B=Bolivianos; U= Dolares)
	--va_cam_mon		TINYINT					,	--cambia moneda ? ( 0=NO; 1=CAMBIA; 2=Obtiene moneda de la lista fija)

	--LLAVE FORANEA
	va_cod_ven		SMALLINT				,	--Codigo del vendedor por defecto (cmr014)
	va_cam_ven		TINYINT					,	--Cambia vendedor ? (0=NO; 1=CAMBIA; 2=Obtiene el asignado del cliente)

	va_cod_del		SMALLINT				,	--Codigo del delivery por defecto (cmr010) 
	va_cam_del		TINYINT					,	--Cambia delivery ? (0=NO; 1=CAMBIA)

	va_dia_ret		TINYINT					,	--Dias permitidos para ventas retrasadas ##
	va_for_pgo		TINYINT					,	--Forma de pago (1=Contado; 2=Credito)
	va_cam_fpg		TINYINT					,	--Cambia forma de pago ? (0=NO; 1=CAMBIA)
	va_pgo_cta		TINYINT					,	--en la forma de pago Credito, Permite pago a cuenta ? (0=NO; 1= SI)
	va_ope_def		TINYINT					,	--Operacion por defecto (1=Factura; 2=Nota de Venta; 3=Nota de Consumo)

	--LLAVE FORANEA
	va_lib_cre		INT						,	--Codigo Libreta para ventas al credito (ecp006) (5 Numeros)
	va_lib_dev		INT						,	--Codigo Libreta para devoluciones de ventas (ecp006) (5 Numeros)

	va_bus_pro		TINYINT					,	--Busqueda rapida de producto por (1=nombre; 2= Descripcion; 3=Codigo)
	--va_des_srv		TINYINT					,	--Permite escribir descripcion en productos de servicio ? (0=NO; 1=SI)
	--va_img_pro		TINYINT					,	--Panel de venta con imagen en producto? (0=NO; 1=SI)

	
	va_doc_fac		CHAR(3)					,	--Documento factura (adm003) (3 Letras)
	va_tal_fac		TINYINT					,	--Talonario factura  (adm004) (2 numeros)
	va_doc_ntv		CHAR(3)					,	--Documento Nota de Venta (adm003) (3 Letras)
	va_tal_ntv		TINYINT					,	--Talonario Nota de venta (adm004) (2 numeros)
	va_doc_opd		CHAR(3)					,	--Documento Orden de Produccion (ads003) (3 Letras)
	va_tal_opd		TINYINT					,	--Talonario Orden de Produccion (ads004) (2 numeros)
	va_doc_con		CHAR(3)					,	--Documento Nota de Cosumo (adm003) (3 Letras)
	va_tal_con		TINYINT					,	--Talonario Nota de Cosumo (adm004) (2 numeros)
	va_doc_dcf		CHAR(3)					,	--Documento DeV C/F (adm003) (3 Letras)
	va_tal_dcf		TINYINT					,	--Talonario DeV C/F (adm004) (2 numeros)
	va_doc_dsf		CHAR(3)					,	--Documento DeV S/F (adm003) (3 Letras)
	va_tal_dsf		TINYINT					,	--Talonario DeV S/F (adm004) (2 numeros)

	va_imp_fac		VARCHAR(80)				,	--Impresora por defecto para factura
	va_imp_ntv		VARCHAR(80)				,	--Impresora por defecto para Nota de venta
	va_imp_opd		VARCHAR(80)				,	--Impresora para Orden de Produccion
	va_imp_con		VARCHAR(80)				,	--Impresora para Nota de Cosumo
	va_imp_dcf		VARCHAR(80)				,	--Impresora para DeV C/F
	va_imp_dsf		VARCHAR(80)				,	--Impresora para DeV S/F
	va_ban_av1		TINYINT					,	--Imprime aviso de venta 1? (0=NO; 1=SI)
	va_imp_av1		VARCHAR(80)				,	--Impresora para aviso de venta 1
	va_ban_av2		TINYINT					,	--Imprime aviso de venta 2? (0=NO; 1=SI)
	va_imp_av2		VARCHAR(80)				,	--Impresora para aviso de venta 2
	va_ban_imp		TINYINT					,	--Bandera de impresion (0=No imprime; 1=Imprime directo ; 2=Pregunta para imprimir)
	
	va_img_pro		INT						,	--Bandera que muestra los productos con imagenes(0=sin imagen; 1=con imagen)
	
	va_est_ado		CHAR(01)					--Estado de la planilla de Venta


	CONSTRAINT pk1_res004 PRIMARY KEY(va_cod_plv)
)



  
