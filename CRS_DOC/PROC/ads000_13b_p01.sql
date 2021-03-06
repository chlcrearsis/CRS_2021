/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads000_13b_p01.sql
PROCEDIMIENTO: OBTIENE LA LICENCIA DEL SISTEMA
	Y LOS MODULOS ATORIZADOS
AUTOR:	CREARSIS(JEJR)
FECHA:	16-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads000_13b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ads000_13b_p01
GO

CREATE PROCEDURE ads000_13b_p01		@ag_nro_usr	 INT,
                                    @ag_fec_exp  CHAR(10),
									@ag_mod_adm  CHAR(01),
									@ag_mod_inv  CHAR(01),
									@ag_mod_com  CHAR(01),
									@ag_mod_res  CHAR(01)  WITH ENCRYPTION AS

DECLARE		@va_nom_ser  NVARCHAR(120), --** Nombre del Servidor
			@va_nom_bda  CHAR(80),      --** Nombre de la Base de Datos
			@va_nro_usr  INT,           --** Nro. Usuario
			@va_fec_exp  CHAR(08),      --** Fecha de Expiración		
			@va_nro_reg  INT            --** Nro de Registro


--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa Variable
SET @va_nom_ser = ''
SET @va_nom_bda = ''
SET @va_nro_usr = 0
SET @va_fec_exp = ''

--** Obtiene el nombre del servidor
SELECT @va_nom_ser = @@SERVERNAME

--** Inserta en la Global el nombre del servidor
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*)
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 300

IF (@va_nro_reg = 0)
BEGIN
	INSERT INTO ads013 VALUES (1, 300, 'NAME_SRV', 1, @va_nom_ser, 0, 0.0)
END
ELSE
BEGIN
	UPDATE ads013 SET va_nom_glo = 'NAME_SRV',
	                  va_tip_glo = 1,
					  va_glo_car = @va_nom_ser,
					  va_glo_ent = 0,
					  va_glo_dec = 0.00
				WHERE va_ide_mod = 1 AND va_ide_glo = 300
END

--** Obtiene el nombre de la Base de Datos
SELECT @va_nom_bda = DB_NAME()

--** Inserta en la Global el nombre de la Base de Datos
SET @va_nro_reg = 0
SELECT @va_nro_reg = COUNT(*)
  FROM ads013 
 WHERE va_ide_mod = 1 AND va_ide_glo = 301

IF (@va_nro_reg = 0)
BEGIN
	INSERT INTO ads013 VALUES (1, 301, 'NAME_BDA', 1, @va_nom_bda, 0, 0.0)
END
ELSE
BEGIN
	UPDATE ads013 SET va_nom_glo = 'NAME_BDA',
	                  va_tip_glo = 1,
					  va_glo_car = @va_nom_bda,
					  va_glo_ent = 0,
					  va_glo_dec = 0.00
				WHERE va_ide_mod = 1 AND va_ide_glo = 301
END

--** Inserta el nro de usuario concurrentes
IF (@ag_nro_usr > 0)
BEGIN
	SET @va_nro_usr = @ag_nro_usr * 1024

	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 302

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 302, 'NUMBER_USR', 2, '', @va_nro_usr, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'NUMBER_USR',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = @va_nro_usr,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 302
	END
END

--** Inserta la fecha de expiración de la licencia

IF (@ag_fec_exp <> '')
BEGIN
	SET @va_fec_exp = SUBSTRING(@ag_fec_exp, 10, 1) +
					  SUBSTRING(@ag_fec_exp, 1, 1) + 
					  SUBSTRING(@ag_fec_exp, 9, 1) +
					  SUBSTRING(@ag_fec_exp, 2, 1) + 
					  SUBSTRING(@ag_fec_exp, 8, 1) +
					  SUBSTRING(@ag_fec_exp, 4, 1) +
					  SUBSTRING(@ag_fec_exp, 7, 1) +
					  SUBSTRING(@ag_fec_exp, 5, 1)

	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 303

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 303, 'DATE_VALUE', 1, @va_fec_exp, 0, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'DATE_VALUE',
						  va_tip_glo = 1,
						  va_glo_car = @va_fec_exp,
						  va_glo_ent = 0,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 303
	END					  
END

--** Verifica e Inserta el Modulo de Administrador
IF (@ag_mod_adm = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 310

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 310, 'MOD_ADM', 2, '', 2170, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_ADM',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2170,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 310
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 310
END

--** Verifica e Inserta el Modulo de Inventario
IF (@ag_mod_inv = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 311

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 311, 'MOD_INV', 2, '', 2177, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_ADM',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2177,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 311
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 311
END


--** Verifica e Inserta el Modulo de Comercialización
IF (@ag_mod_com = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 312

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 312, 'MOD_COM', 2, '', 2184, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_COM',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2184,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 312
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 312
END


--** Verifica e Inserta el Modulo de Restaurant
IF (@ag_mod_res = 'S')
BEGIN
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT(*)
	  FROM ads013 
	 WHERE va_ide_mod = 1 AND va_ide_glo = 313

	IF (@va_nro_reg = 0)
	BEGIN
		INSERT INTO ads013 VALUES (1, 313, 'MOD_RES', 2, '', 2191, 0.0)
	END
	ELSE
	BEGIN
		UPDATE ads013 SET va_nom_glo = 'MOD_RES',
						  va_tip_glo = 2,
						  va_glo_car = '',
						  va_glo_ent = 2191,
						  va_glo_dec = 0.00
					WHERE va_ide_mod = 1 AND va_ide_glo = 313
	END	
END
ELSE
BEGIN
	DELETE ads013 WHERE va_ide_mod = 1 AND va_ide_glo = 313
END

RETURN

GO