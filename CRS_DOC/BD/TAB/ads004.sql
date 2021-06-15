/*########################################################
ARCHIVO:	ads004.sql
TABLA:		Talonario
AUTOR:		CHL
FECHA:		23/09/2019
########################################################*/

CREATE TABLE ads004
(
va_ide_doc		CHAR(03)		NOT NULL,	--Ide Documento
va_nro_tal		INT,						--Nro de Talonario
va_nom_tal		VARCHAR(60)		NOT NULL,	--Nombre Talonario
va_tip_tal		INT						,	--Tipo de talonario 
											-- 0=Manual; 1=Automatico
va_nro_aut		DECIMAL(15,0)	NOT NULL,	-- Numero de autorizacion
va_for_mat		INT				NOT NULL,	-- Formato de impresion
va_nro_cop		INT				NOT NULL,	-- Nro de copias a imprimir
va_fir_ma1		VARCHAR(30)		NOT NULL,	-- Firma nro 1
va_fir_ma2		VARCHAR(30)		NOT NULL,	-- Firma nro 2
va_fir_ma3		VARCHAR(30)		NOT NULL,	-- Firma nro 3
va_fir_ma4		VARCHAR(30)		NOT NULL,	-- Firma nro 4
va_for_log		INT				NOT NULL,	/* Formato de logo	
											0=Razon social de empresa; 1=Logotipo1
											2=Logotipo2 ;3=Logotipo3	*/
va_est_ado		CHAR(01)		NOT NULL	--Estado

CONSTRAINT pk1_ads004 PRIMARY KEY(va_ide_doc,va_nro_tal)
)

go

--* Modulo Inventario
INSERT INTO ads004 VALUES('CMP',0,'Compra',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('AJI',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('AJE',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('AJC',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('TRA',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')

--* Modulo Comercializacion
INSERT INTO ads004 VALUES('COT',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('PED',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('VTS',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('VTF',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')

--* Modulo Exigibles
INSERT INTO ads004 VALUES('CXC',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('CXP',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',1,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',2,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',3,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',4,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',5,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',6,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',7,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',8,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',9,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',10,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',11,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('DAU',12,'Talonario',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')

--* Modulo Tesoreria
INSERT INTO ads004 VALUES('RIN',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('REG',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('TIN',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')
INSERT INTO ads004 VALUES('TEG',0,'Talonario anual',1,0,0,0,'Elaborado por','Revisado por','Aprobado por','',0,'H')

