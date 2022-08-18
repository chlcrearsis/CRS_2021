/*****************************************************************/
/*	ARCHIVO: ads001_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME MÓDULO DEL SISTEMA                    */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 18/08/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads001_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads001_R01
GO

CREATE PROCEDURE ads001_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''

--** Obtiene el informe en el orden especificado
SELECT va_ide_mod, va_nom_mod, va_abr_mod,  
       CASE WHEN va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM ads001
 WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_ide_mod END ASC,
  CASE WHEN @ar_ord_dat = 'N' THEN va_nom_mod END ASC


