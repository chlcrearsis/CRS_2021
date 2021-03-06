/*****************************************************************/
/*	ARCHIVO: adp018_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME GRUPO EMPRESARIAL                     */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*                @ar_ban_fac  INT       Datos de Facturación    */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/07/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp018_R01') and sysstat & 0xf = 4)
	drop procedure dbo.adp018_R01
GO

CREATE PROCEDURE adp018_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01),
								@ar_ban_fac  CHAR(01) WITH ENCRYPTION AS

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

IF (@ar_ban_fac = '2')
	SET @ar_ban_fac = ''

--** Obtiene el informe en el orden especificado
SELECT va_gru_emp, va_nom_gru, 
       CASE WHEN va_ban_fac = 0
		    THEN 'Registro Cliente' 
		    ELSE 'Grupo Empresarial' 
	   END AS va_ban_fac,
	   va_nom_fac, va_ruc_nit, va_dir_ent,
       CASE WHEN va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM adp018
 WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
   AND va_ban_fac LIKE '%' + RTRIM(@ar_ban_fac)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_gru_emp END ASC,
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_gru END ASC


