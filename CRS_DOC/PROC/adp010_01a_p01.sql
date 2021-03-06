/***********************************************************************/
/*	ARCHIVO: adp010_01a_p01.sql                                        */
/*	PROCEDIMIENTO: CONSULTA DESCUENTO GENERAL P/PERSONA                */
/*      ARGUMENTO: @ar_cod_per  INT         --** Código Persona        */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 14/07/2022                   */
/***********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp010_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp010_01a_p01
GO

CREATE PROCEDURE adp010_01a_p01		@ar_cod_per	 INT WITH ENCRYPTION AS

DECLARE     @va_raz_soc	 VARCHAR(80), --** Razon Social
			@va_nro_doc	 BIGINT,	  --** Carnet de Identidad
			@va_tip_doc  CHAR(02),    --** Tipo Documento
			@va_ext_doc  CHAR(02),    --** Extension Documento
            @va_tip_fac	 CHAR(01),	  --** p/Factura (S=Si; N=No)
	        @va_tip_ndv	 CHAR(01),	  --** p/Nota de Venta (S=Si; N=No)
	        @va_por_con  DEC(14,2),   --** Porcentajde de Descuento al Contado
	        @va_por_cre  DEC(14,2)    --** Porcentajde de Descuento al Crédito

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Inicializa variables
SET @va_raz_soc = ''
SET @va_tip_doc = ''
SET @va_nro_doc = 0
SET @va_ext_doc = ''
SET @va_tip_fac	= ''
SET @va_tip_ndv	= ''
SET @va_por_con = 0
SET @va_por_cre = 0

--** Obtiene Datos del Cliente
SELECT @va_raz_soc = va_raz_soc,
       @va_tip_doc = va_tip_doc,
	   @va_nro_doc = va_nro_doc,
	   @va_ext_doc = va_ext_doc 
  FROM adp002
 WHERE va_cod_per = @ar_cod_per

--** Obtiene datos del descuento general del cliente
SELECT @va_tip_fac = va_tip_fac,
       @va_tip_ndv = va_tip_ndv,
	   @va_por_con = va_por_con,
	   @va_por_cre = va_por_cre
  FROM adp010
 WHERE va_cod_per = @ar_cod_per

 IF (@va_tip_fac = '')
	SET @va_tip_fac = 'N'

IF (@va_tip_ndv = '')
	SET @va_tip_ndv = 'N'

--** Obtiene Datos
SELECT @ar_cod_per AS va_cod_per,
       @va_raz_soc AS va_raz_soc,
       @va_tip_doc AS va_tip_doc,
	   @va_nro_doc AS va_nro_doc,
	   @va_ext_doc AS va_ext_doc,
	   @va_tip_fac AS va_tip_fac,
       @va_tip_ndv AS va_tip_ndv,
	   @va_por_con AS va_por_con,
	   @va_por_cre AS va_por_cre