/*****************************************************************/
/*	ARCHIVO: adp014_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME TIPO DE DOCUMENTO                     */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 15/07/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp014_R01') and sysstat & 0xf = 4)
	drop procedure dbo.adp014_R01
GO

CREATE PROCEDURE adp014_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene el informe en el orden especificado
SELECT va_ide_tip, va_des_tip, 
       CASE WHEN va_ext_doc = 'S'
		    THEN 'Si' 
		    ELSE 'No' 
	   END AS va_ext_doc,
       CASE WHEN va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM adp014
 WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'T' THEN va_ide_tip END ASC,
  CASE WHEN @ar_ord_dat = 'D' THEN va_des_tip END ASC


