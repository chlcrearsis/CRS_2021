/*****************************************************************/
/*	ARCHIVO: adp009_01a_p01.sql                                  */
/*	PROCEDIMIENTO: OBTIENE LISTA DE LISTA DE PRECIO P/PERSONA    */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 21/10/2021             */
/*   NOTA: En caso de error devuelve del 101 as 118              */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp009_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp009_01a_p01
GO

CREATE PROCEDURE adp009_01a_p01		@ar_cod_per  INT	--** Código de Persona
									WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		   --** Nro de Registro
            @va_cod_lis	 INT,	       --** Codigo del la lista
			@va_nom_lis	 VARCHAR(30),  --** Nombre
			@va_mon_lis	 CHAR(01),	   --** Moneda (B=Bolivianos; D=Dolares)
			@va_fec_ini	 DATE,	       --** Fecha inicio
			@va_fec_fin	 DATE,	       --** Fecha final
			@va_per_mis  CHAR(01)      --** Permiso (S=Si; N=No)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_mis
(
	va_cod_lis	INT,
	va_nom_lis	VARCHAR(30),
	va_mon_lis	CHAR(01),
	va_fec_ini	DATE,
	va_fec_fin	DATE,
	va_per_mis  CHAR(01)
)

--** Graba los atributos seleccionado del usuario
DECLARE vc_lis_pre CURSOR LOCAL FOR
SELECT va_cod_lis, va_nom_lis, va_mon_lis,
       va_fec_ini, va_fec_fin 
  FROM cmr001
 WHERE va_est_ado = 'H'

--** Abre cursor
OPEN vc_lis_pre

--** Lee primer registro
FETCH NEXT FROM vc_lis_pre INTO @va_cod_lis, @va_nom_lis, @va_mon_lis,
								@va_fec_ini, @va_fec_fin 

WHILE (@@FETCH_STATUS = 0)
BEGIN	
    --** Verifica si el usuario tiene habilitado al vendedor
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT (*)
	  FROM adp009
	 WHERE va_cod_per = @ar_cod_per
	   AND va_cod_lis = @va_cod_lis

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'


	--** Graba el atributo de persona
	INSERT INTO #tm_per_mis VALUES (@va_cod_lis, @va_nom_lis, @va_mon_lis,
								    @va_fec_ini, @va_fec_fin, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_lis_pre INTO @va_cod_lis, @va_nom_lis, @va_mon_lis,
								    @va_fec_ini, @va_fec_fin 
END

--** Cierre y destruya cursor
CLOSE vc_lis_pre
DEALLOCATE vc_lis_pre

--** Devuelve datos
SELECT va_cod_lis, va_nom_lis, va_mon_lis,
	   va_fec_ini, va_fec_fin, va_per_mis 
  FROM #tm_per_mis


