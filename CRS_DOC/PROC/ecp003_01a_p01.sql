/***********************************************************************/
/*	ARCHIVO: ecp003_01a_p01.sql                                        */
/*	PROCEDIMIENTO: BUSCA INSCRIPCION PERSONA-LIBRETA                   */
/*      ARGUMENTO: @ar_cod_per  INT         --** Código Persona        */
/*				   @ar_tip_lib  INT         --** Criterio de Busqueda  */
/*                 @ar_est_ado  CHAR(01)    --** Estado                */
/*	AUTOR:	CREARSIS(CHLG)        FECHA : 17/11/2021                   */
/***********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ecp003_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.ecp003_01a_p01
GO

CREATE PROCEDURE ecp003_01a_p01		@ar_cod_per	 INT,			--** Código Persona
                                    --@ar_tip_lib  INT,			--** Tipo libreta (1=CxC ; 2=CxP; 0=Todos)
									@ar_est_ado	 CHAR(01)		--** Estado (H=Habilitado; N=Deshabilitado; T=Todos)
									WITH ENCRYPTION AS

DECLARE     @va_cod_per  INT,	      --** Codigo Persona (2 de Grup. Per y 5 de Persona)
			@va_nom_bre  VARCHAR(30), --** Nombre
			@va_ape_pat  VARCHAR(20), --** Apellido Paterno
			@va_ape_mat  VARCHAR(20), --** Apellido Materno
			@va_raz_soc	 VARCHAR(80), --** Razon Social
			@va_cod_lib	 INT,
			@va_des_lib	 VARCHAR(50),
			@va_tip_lib  INT,
			@va_mon_lib	 CHAR(01),
			@va_mto_lim	 DECIMAL(12,2),
			@va_sal_act	 DECIMAL(12,2),
			@va_fec_exp	 DATE,
			@va_est_ado	 CHAR(01),	  --** Estado de la inscripcion(H=Habilitado; N=Deshabilitado)
			@va_msn_err  VARCHAR(200) --** Nro. Registro

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

--** Tabla Temporal: Lista Persona
CREATE TABLE #tm_lis_ins (
    va_cod_per  INT,
	va_nom_bre  VARCHAR(30),
	va_ape_pat  VARCHAR(20),
	va_ape_mat  VARCHAR(20),
	va_raz_soc	VARCHAR(80),
	va_cod_lib	INT,
	va_des_lib	VARCHAR(50),
	va_tip_lib	INT,
	va_mon_lib	CHAR(01),
	va_mto_lim	DECIMAL(12,2),
	va_sal_act	DECIMAL(12,2),
	va_fec_exp	DATE,
	va_est_ado	CHAR(1)
)

   
BEGIN TRY 

--** filtro estado de la inscripcion T=Todos
IF(@ar_est_ado = 'T')
	SET @ar_est_ado = '%'

--** Obtiene inscripcion de la persona
DECLARE vc_sus_crip CURSOR LOCAL FOR
 SELECT va_cod_per, va_cod_lib, va_mto_lim, 
		va_sal_act, va_fec_exp, va_est_ado
   FROM ecp003
  WHERE va_cod_per = @ar_cod_per	AND
	    va_est_ado LIKE @ar_est_ado + '%'

--** Abre Cursor
OPEN vc_sus_crip
--** Lee el primer registro
FETCH NEXT FROM vc_sus_crip INTO @va_cod_per, @va_cod_lib, @va_mto_lim, 
								 @va_sal_act, @va_fec_exp, @va_est_ado
														
WHILE (@@FETCH_STATUS = 0)
BEGIN
	--** Obtiene datos de la persona
	SELECT @va_nom_bre= va_nom_bre,
		   @va_ape_pat = va_ape_pat,
		   @va_raz_soc = va_raz_soc
	  FROM adp002
	 WHERE va_cod_per = @va_cod_per
	
	--** Obtiene datos de la libreta
	SELECT @va_des_lib = va_des_lib,
		   @va_tip_lib = va_tip_lib,
		   @va_mon_lib = va_mon_lib
	  FROM ecp002
	 WHERE va_cod_lib = @va_cod_lib
  
	--** Inserta en la tabla temporal
	INSERT INTO #tm_lis_ins VALUES (@va_cod_per  ,
									@va_nom_bre  ,
									@va_ape_pat  ,
									@va_ape_mat  ,
									@va_raz_soc	,
									@va_cod_lib	,
									@va_des_lib	,
									@va_tip_lib	,
									@va_mon_lib	,
									@va_mto_lim	,
									@va_sal_act	,
									@va_fec_exp	,
									@va_est_ado	)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_sus_crip INTO @va_cod_per, @va_cod_lib, @va_mto_lim,  
									 @va_sal_act, @va_fec_exp, @va_est_ado
	
END	

CLOSE vc_sus_crip
DEALLOCATE vc_sus_crip

--** Obtiene resultado TODO los Grupos
SELECT * FROM #tm_lis_ins


END TRY
BEGIN CATCH	
	SET @va_msn_err = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@va_msn_err,16,1)
	RETURN
END CATCH	   
GO


