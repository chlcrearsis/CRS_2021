/*********************************************************************/
/*	ARCHIVO: adp016_01a_p01.sql                                      */
/*	PROCEDIMIENTO: OBTIENE LISTA DE LISTA DE LIBRETAS AUTORIZADAS    */
/*                 A GRUPO PERSONA                                   */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 08/11/2021                 */
/********************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp016_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp016_01a_p01
GO

CREATE PROCEDURE adp016_01a_p01		@ar_cod_gru  INT	--** Codigo de Grupo de persona
									WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		   --** Nro de Registro
            @va_cod_lib	 INT,	       --** Código de la Libreta
			@va_des_lib  VARCHAR(50),  --** Nombre Libreta
			@va_cod_cta	 VARCHAR(12),  --** Cod. Cuenta Contable
			@va_tip_lib  INT,          --** Tipo (1=CxC('Cuentas por Cobrar') ; 2=CxP('Cuentas por Pagar')
			@va_mon_lib	 CHAR(01),	   --** Moneda (B=Bolivianos; D=Dolares)
			@va_per_mis  CHAR(01)      --** Permiso (S=Si; N=No)

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_mis
(
	va_cod_lib	INT,
	va_des_lib  VARCHAR(50),
	va_cod_cta	VARCHAR(12),
	va_tip_lib  INT,
	va_mon_lib	CHAR(01),
	va_per_mis  CHAR(01)
)

--** Obtiene la lista de las libretas habilitadas
DECLARE vc_lis_lib CURSOR LOCAL FOR
SELECT va_cod_lib, va_des_lib, va_cod_cta,
       va_tip_lib, va_mon_lib 
  FROM ecp002
 WHERE va_est_ado = 'H'	    --** Habilitado
   AND (va_tip_lib = 1 OR	--** Cta. p/Cobrar
        va_tip_lib = 2)		--** Cta. p/Pagar

--** Abre cursor
OPEN vc_lis_lib

--** Lee primer registro
FETCH NEXT FROM vc_lis_lib INTO @va_cod_lib, @va_des_lib, @va_cod_cta,
								@va_tip_lib, @va_mon_lib 

WHILE (@@FETCH_STATUS = 0)
BEGIN	
    --** Verifica si el usuario tiene habilitado al vendedor
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT (*)
	  FROM adp016
	 WHERE va_cod_gru = @ar_cod_gru
	   AND va_cod_lib = @va_cod_lib

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'


	--** Graba registro a la tabla temporal
	INSERT INTO #tm_per_mis VALUES (@va_cod_lib, @va_des_lib, @va_cod_cta,
								    @va_tip_lib, @va_mon_lib, @va_per_mis)

	--** Lee el siguiente registro
	FETCH NEXT FROM vc_lis_lib INTO @va_cod_lib, @va_des_lib, @va_cod_cta,
								    @va_tip_lib, @va_mon_lib 
END

--** Cierre y destruye cursor
CLOSE vc_lis_lib
DEALLOCATE vc_lis_lib

--** Devuelve datos
SELECT va_cod_lib, va_des_lib, va_cod_cta,
	   va_tip_lib, va_mon_lib, va_per_mis 
  FROM #tm_per_mis
 ORDER BY va_cod_lib


