/*########################################################
ARCHIVO:	ads013.sql
TABLA:		Globales
AUTOR:		CHL
FECHA:		06/11/2019
########################################################*/

CREATE TABLE ads013
(
va_ide_mod		INT				NOT NULL,	--Ide. modulo (ads001)
va_ide_glo		INT				NOT NULL,	--Ide. global
va_nom_glo		VARCHAR(60)		NOT NULL,	--Nombre de global
va_tip_glo		INT				NOT NULL,	--Tipo global 
											-- 1=caracter; 
											-- 2=numerico; 
											-- 3=decimal
va_glo_car		NVARCHAR(120)			,	--Global caracter											
va_glo_ent 		INT 					,	--Global numerico
va_glo_dec		DECIMAL(18,5)	NOT NULL,	--Global decimal

CONSTRAINT pk1_ads013 PRIMARY KEY(va_ide_mod,va_ide_glo)
)

go
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

--16/06/2021
INSERT INTO ads013 VALUES (1,16,'UsrLicAct', 2, '', 15360,0)	-- Cantidad de Licencia * 1024; (15*1024 = 15360)
INSERT INTO ads013 VALUES (1,17,'FecLicAct', 1, '21260026', 0, 0) -- Cadena encriptada de la licencia que contiene la fecha de expiracion
--16/06/2021


INSERT INTO ads013 VALUES (1,100,'Version del sistema',1,'1.0.0',0,0)

-- Modulo Comercializacion
INSERT INTO ads013 VALUES (3,1,'Formulario Ventas',1,'Normal',0,0) -- 1 = Normal ; 2= Tactil


go
