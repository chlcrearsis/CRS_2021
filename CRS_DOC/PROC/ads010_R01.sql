/*****************************************************************/
/*	ARCHIVO: ads010_R01.sql                                      */
/*	PROCEDIMIENTO: INFORME TIPO DE IMAGEN                        */
/*  PARAMETROS:   @ar_est_ado  CHAR(01)  Estado                  */
/*                @ar_ord_dat  CHAR(02)  Orden Datos             */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 22/09/2022             */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads010_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads010_R01
GO

CREATE PROCEDURE ads010_R01		@ar_est_ado  CHAR(01),
                                @ar_ord_dat  CHAR(01) WITH ENCRYPTION AS

--** Castea el estado si es T=Todos
IF (@ar_est_ado = 'T')
	SET @ar_est_ado = ''
--** Obtiene el informe en el orden especificado
SELECT va_ide_tip, va_nom_tip, 
       CASE WHEN va_ide_tab = 'adp002'
		    THEN 'Persona' 
		    ELSE 'Producto' 
	   END AS va_ide_tab,
       CASE WHEN va_est_ado = 'H'
		    THEN 'Habilitado' 
		    ELSE 'Deshabilitado' 
	   END AS va_est_ado
  FROM ads010
 WHERE va_est_ado LIKE '%' + RTRIM(@ar_est_ado)
 ORDER BY 
  CASE WHEN @ar_ord_dat = 'C' THEN va_ide_tip END ASC,
  CASE WHEN @ar_ord_dat = 'D' THEN va_nom_tip END ASC


