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
     
 