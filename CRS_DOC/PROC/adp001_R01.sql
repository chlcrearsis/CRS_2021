/*****************************************************************/
/*	ARCHIVO: adp001_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME GRUPO PERSONA                         */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 08/07/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp001_R01') and sysstat & 0xf = 4)
	drop procedure dbo.adp001_R01
GO

CREATE PROCEDURE adp001_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene el informe en el orden especificado
SELECT va_cod_gru, va_nom_gru, 
       CASE WHEN va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM adp001
 WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_cod_gru END ASC,
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_gru END ASC


