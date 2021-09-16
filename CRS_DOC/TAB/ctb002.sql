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

