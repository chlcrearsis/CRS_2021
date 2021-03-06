/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: adp003_01a_p01.sql
PROCEDIMIENTO: - INSERTA TIPO DE ATRIBUTO (adp003)
               - INSERTA ATRIBUTO P/DEFECTO (adp004)
			   - ASIGNA ATRIBUTO P/DEFECTO A PERSONAS (adp005)
	
AUTOR:	CREARSIS(JEJR)
FECHA:	30-08-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp003_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp003_01a_p01
GO

CREATE PROCEDURE adp003_01a_p01		@ar_ide_tip	 INT,			-- Id. Tipo de Atributo
									@ar_nom_tip  VARCHAR(30),	-- Nombre de Atributo
									@ar_atr_def  INT,			-- ID. Atributo p/Defecto
									@ar_nom_atr  VARCHAR(30)	-- Nombre de Atributo
									WITH ENCRYPTION AS

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

BEGIN TRANSACTION

--** Verifica que el ID. Tipo Atributo sea distinto a cero
IF (@ar_ide_tip = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 100: El ID. Tipo de Atributo tiene que ser DISTINTO a Cero', 16, 1)
	RETURN
END

--** Verifica que no existena otro registro con el mismo ID.
SELECT * FROM adp003
 WHERE va_ide_tip = @ar_ide_tip

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 101: Ya existe un registro en la tabla (ads003) con el mismo ID.', 16, 1)
	RETURN
END

--** Inserta el Tipo de Atributo
INSERT INTO adp003 VALUES (@ar_ide_tip, @ar_nom_tip, @ar_atr_def, 'H')

IF (@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 102: Error al inserta datos en la tabla (ads003).', 16, 1)
	RETURN
END

--** Verifica que no existena otro registro con el mismo ID.
SELECT * FROM adp004
 WHERE va_ide_tip = @ar_ide_tip
   AND va_ide_atr = @ar_atr_def

IF (@@ROWCOUNT > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 103: Ya existe un registro en la tabla (adp004) con el mismo ID.', 16, 1)
	RETURN
END

--** Inserta la definición del atributo
INSERT INTO adp004 VALUES (@ar_ide_tip, @ar_atr_def, @ar_nom_atr, 'H')

IF (@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 104: Error al inserta datos en la tabla (ads004)', 16, 1)
	RETURN
END

--** Asigna de manera masiva a todos los clientes el atributo p/Defecto
INSERT INTO adp005
SELECT @ar_ide_tip, @ar_atr_def, va_cod_per
  FROM adp002
 ORDER BY va_cod_per ASC

IF (@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 104: Error al inserta datos en la tabla (adp005)', 16, 1)
	RETURN
END

COMMIT TRANSACTION

RETURN


