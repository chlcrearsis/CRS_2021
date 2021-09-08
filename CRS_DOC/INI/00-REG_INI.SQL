/* INICIALIZA MODULOS */
	INSERT INTO ads001 VALUES (1,'Administracion y Seguridad','ADS','H')
	INSERT INTO ads001 VALUES (2,'Inventario','INV','H')
	INSERT INTO ads001 VALUES (3,'Comercializacion','CMR','H')
	INSERT INTO ads001 VALUES (4,'Exigibles','ECP','H')
	INSERT INTO ads001 VALUES (5,'Tesoreria','TES','H')
GO
  
/* INICIALIZA APLICACIONES */
	INSERT INTO ads002 VALUES (1,'ads200','Administrador','H')
	INSERT INTO ads002 VALUES (2,'inv200','Inventario','H')
	INSERT INTO ads002 VALUES (3,'cmr200','Comercializacion','H')
	INSERT INTO ads002 VALUES (3,'res200','Restaurant','H')
GO
  
/* INICIALIZA TIPO DE USUARIOS */
INSERT INTO ads006 VALUES(1,'Administrador','Administrador del sistema','H')
INSERT INTO ads006 VALUES(2,'Supervisor','Obtiene reportes y autoriza ciertas operaciones','H')
INSERT INTO ads006 VALUES(3,'Operativo','Usuario operativo con permisos restringidos','H')

GO
  
/* INICIALIZA USUARIOS */
INSERT INTO ads007 VALUES('chlsql','Administrador del sistema','','','C:\TEMP','',3,0,1,'H')
GO

  
