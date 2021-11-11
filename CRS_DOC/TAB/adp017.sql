/*--**********************************************
ARCHIVO:	adp017.sql	
TABLA:		Tabla de "Relación Contacto de Persona"
AUTOR:		CREARSIS 3.0.0
FECHA:		11-11-2021
*/--**********************************************

CREATE TABLE adp017 
(
	--** Llave Primaria
	va_ide_rel	INT				NOT NULL DEFAULT(0),	--** ID. Relacion Contacto

	--** Atributos     
	va_nre_hom	NVARCHAR(20)	NOT NULL DEFAULT(''),	--** Nombre Relación p/Hombre
	va_nre_muj	NVARCHAR(20)	NOT NULL DEFAULT(''),	--** Nombre Relación p/Mujer
	va_est_ado	CHAR(01)		NOT NULL DEFAULT(''),	--** Estado (H=Habilitado; N=Deshabilitado)

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

