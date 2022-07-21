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
