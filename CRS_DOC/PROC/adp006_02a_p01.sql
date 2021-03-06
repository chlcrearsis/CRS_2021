/*****************************************************************/
/*	ARCHIVO: adp006_02a_p01.sql                                  */
/*	PROCEDIMIENTO: CONSULTA REGISTRO IMAGENES P/PERSONA          */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 27/10/2021             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp006_02a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp006_02a_p01
GO

CREATE PROCEDURE adp006_02a_p01		@ar_cod_per  INT,	  --** Código de Persona
                                    @ar_ide_tip  CHAR(02) --** ID. Tipo de Imagen 
									WITH ENCRYPTION AS

DECLARE		@va_cod_per  INT,		   --** Codigo Persona, 
			@va_raz_soc  VARCHAR(80),  --** Razon Social
			@va_est_ado  CHAR(01),	   --** Estado(H=Habilitado; N=Deshabilitado)
            @va_ide_tip	 CHAR(02),     --** ID. Tipo de Imagen
			@va_nom_tip	 VARCHAR(20),  --** Nombre Tipo de Imagen
			@va_ext_arc	 CHAR(05),	   --** Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)
			@va_tam_arc	 VARCHAR(10),  --** Tamaño del archivo
			@va_ide_usr  VARCHAR(15),  --** ID. Usuario Registro
			@va_fec_reg  DATETIME,	   --** Fecha y hora de registro
			@va_nom_equ  VARCHAR(30),  --** Nombre de la PC O Celular
			@va_ima_per  CHAR(01)      --** Tiene Imagen Persona (S=Si; N=No)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_ima_per
(
	va_ide_tip	INT,
	va_nom_tip	VARCHAR(20),
	va_ext_arc	CHAR(05),
	va_tam_arc	VARCHAR(10),
	va_ima_per  CHAR(01)
)



--** Obtiene Datos de la Persona
SELECT @va_cod_per = va_cod_per, 
       @va_raz_soc = va_raz_soc,
	   @va_est_ado = va_est_ado 
  FROM adp002
 WHERE va_cod_per = @ar_cod_per

IF (@@ROWCOUNT = 0)
BEGIN
	SET @va_cod_per = 0
    SET @va_raz_soc = ''
	SET @va_est_ado = ''
END

--** Obtiene Datos del Tipo de Imagem
SELECT @va_ide_tip = va_ide_tip, 
       @va_nom_tip = va_nom_tip 
  FROM ads010
 WHERE va_ide_tip = @ar_ide_tip

IF (@@ROWCOUNT = 0)
BEGIN
	SET @va_ide_tip = 0
    SET @va_nom_tip = ''
END

--** Verifica si la persona tiene imagen registrada
SELECT @va_ext_arc = va_ext_arc,
	   @va_tam_arc = va_tam_arc,
	   @va_ide_usr = va_ide_usr,
	   @va_fec_reg = va_fec_reg,
	   @va_nom_equ = va_nom_equ,
	   @va_ima_per = 'S'
  FROM adp006
 WHERE va_cod_per = @ar_cod_per
   AND va_ide_tip = @ar_ide_tip

IF (@@ROWCOUNT = 0)
BEGIN
	SET @va_ima_per = 'N'
	SET @va_ext_arc = ''
	SET @va_tam_arc = 0.0
	SET @va_ide_usr = ''
	SET @va_fec_reg = NULL
	SET @va_nom_equ = ''
END

--** Devuelve datos
SELECT @va_cod_per AS va_cod_per, 
       @va_raz_soc AS va_raz_soc,
	   @va_est_ado AS va_est_ado,
	   @va_ide_tip AS va_ide_tip, 
       @va_nom_tip AS va_nom_tip,
	   @va_ext_arc AS va_ext_arc,
	   @va_tam_arc AS va_tam_arc,
	   @va_ide_usr AS va_ide_usr,
	   @va_fec_reg AS va_fec_reg,
	   @va_nom_equ AS va_nom_equ,
	   @va_ima_per AS va_ima_per


