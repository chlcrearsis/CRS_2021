/*****************************************************************/
/*	ARCHIVO: adp002_06a_p01.sql                                  */
/*	PROCEDIMIENTO: ELIMINA REGISTRO PERSONA                      */
/*                 - (adp002) Elimina Registro de Persona        */
/*				   - (cmr013) Elimina Registro de NIT            */
/*				   - (adp005) Elimina Atributos de Cliente	     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 17/09/2021             */
/*   NOTA: En caso de error devuelve del 101 as 118              */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_06a_p01
GO

CREATE PROCEDURE adp002_06a_p01		@ar_cod_per  INT WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		 --** Nro de Registro
            @va_est_ado  CHAR(01),   --** Estado
			@va_fec_act  DATETIME,   --** Fecha Actual
			@va_fec_str  CHAR(10),   --** Fecha Actual
			@va_tip_atr  INT,        --** ID. Tipo Atributo
			@va_ide_atr  INT,        --** ID. Atributo
			@va_nom_tip  VARCHAR(30) --** Nombre Tipo de Atributo

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
BEGIN TRANSACTION

--** Obtiene la fecha actual en dd/MM/yyyy 
SET @va_fec_act = GETDATE()
SET @va_fec_str = CONVERT(CHAR(10), @va_fec_act, 103)
SET @va_fec_act = CONVERT(DATETIME, @va_fec_str)

--** Verifica que el Código Persona sea distinto a cero
IF (@ar_cod_per = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 101: El Código de Persona tiene que ser DISTINTO a Cero', 16, 1)
	RETURN
END

--** Verifica si el registro de persona esta definida y deshabilitada
SELECT @va_est_ado = va_est_ado 
  FROM adp002
 WHERE va_cod_per = @ar_cod_per

IF (@@ROWCOUNT = 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 102: La persona con el codigo %d NO está definido en la base de datos.', 16, 1, @ar_cod_per)
	RETURN
END

IF (@va_est_ado = 'H')
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 103: La persona con el codigo %d NO está deshabilitada en la base de datos.', 16, 1, @ar_cod_per)
	RETURN
END

--** Valida que el grupo de persona este definido y habilitado
SELECT @va_nro_reg = ISNULL(COUNT(*), 0)
  FROM ads026
 WHERE va_cod_per = @ar_cod_per

IF (@va_nro_reg > 0)
BEGIN
    ROLLBACK TRANSACTION	
	RAISERROR ('Error 104: La Persona %d tiene movimientos realizados, NO se puede eliminar el registro.', 16, 1, @ar_cod_per)
	RETURN
END

--** Si todo es OK, Procede eliminar los registro de persona de la base de datos

--******************************************************************************
--***  ELIMINA REGISTRO DE PERSONA                                           ***
--******************************************************************************
DELETE adp002 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 105: Error al eliminar los datos de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA ATRIBUTOS DE PERSONA                                          ***
--******************************************************************************
DELETE adp005 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 106: Error al eliminar los atributos de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA IMAGENES DE PERSONA                                          ***
--******************************************************************************
DELETE adp006 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 107: Error al eliminar las imagenes de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA RUTAS POR PERSONA                                             ***
--******************************************************************************
DELETE adp008 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 108: Error al eliminar las rutas establecidas de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA LISTA DE PRECIO POR PERSONA                                   ***
--******************************************************************************
DELETE adp009 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 109: Error al eliminar las listas autorizadas de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA CONTRATO POR PERSONA                                          ***
--******************************************************************************
DELETE adp010 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 110: Error al eliminar los contratos de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA DESCUENTO ESPECIAL POR PERSONA                                ***
--******************************************************************************
DELETE adp011 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 111: Error al eliminar los descuentos especiales de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA PERSONA RELACIONADAS                                          ***
--******************************************************************************
DELETE adp012 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 112: Error al eliminar las personas relacionadas de la persona.', 16, 1)
	RETURN
END

--******************************************************************************
--***  ELIMINA CONTACTOS POR PERSONA                                         ***
--******************************************************************************
DELETE adp013 WHERE va_cod_per = @ar_cod_per

IF (@@ERROR > 0)
BEGIN
    ROLLBACK TRANSACTION
	RAISERROR ('Error 113: Error al eliminar los contactos de la persona.', 16, 1)
	RETURN
END

COMMIT TRANSACTION

RETURN


