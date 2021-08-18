/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: adp002_05a_p01.sql
PROCEDIMIENTO: BUSCA PERSONA
	
AUTOR:	CREARSIS(CHL)
FECHA:	20-09-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.adp002_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.adp002_05a_p01
GO

CREATE PROCEDURE adp002_05a_p01		@ar_cod_per		INT	
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_gru		INT,
@va_nom_gru		VARCHAR(50),
@va_cod_per		INT,
@va_raz_soc		VARCHAR(120),
@va_nom_com		VARCHAR(100),
@va_nit_per		BIGINT,
@va_car_net		BIGINT,
@va_dir_per		VARCHAR(80),
@va_tel_per		VARCHAR(15),
@va_cel_per		VARCHAR(15),
@va_ema_per		VARCHAR(30), 
@va_ubi_gps		GEOGRAPHY,
@va_cod_lpr		INT,
@va_cod_ven		INT,
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_gru		INT,
va_nom_gru		VARCHAR(50),
va_cod_per		INT,
va_raz_soc		VARCHAR(120),
va_nom_com		VARCHAR(100),
va_nit_per		BIGINT,
va_car_net		BIGINT,
va_dir_per		VARCHAR(80),
va_tel_per		VARCHAR(15),
va_cel_per		VARCHAR(15),
va_ema_per		VARCHAR(30), 
va_ubi_gps		GEOGRAPHY,
va_cod_lpr		INT,
va_cod_ven		INT,
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	-- Crea cursor para busqueda
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per,va_ema_per,  va_ubi_gps,va_cod_lpr, va_cod_ven, va_est_ado
	FROM adp002 
	WHERE (va_cod_per = @ar_cod_per  )


OPEN vc_per_son
FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, 
								@va_car_net, @va_dir_per, @va_tel_per, @va_cel_per,@va_ema_per,  
								@va_ubi_gps, @va_cod_lpr, @va_cod_ven, @va_est_ado
									
WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del Grupo
	SELECT @va_nom_gru = va_nom_gru
	  FROM adp001
	 WHERE va_cod_gru = @va_cod_gru
 
	 INSERT INTO #resultado VALUES (@va_cod_gru,
									@va_nom_gru		,
									@va_cod_per		,
									@va_raz_soc		,
									@va_nom_com		,
									@va_nit_per		,
									@va_car_net		,
									@va_dir_per		,
									@va_tel_per		,
									@va_cel_per		,
									@va_ema_per		, 
									@va_ubi_gps		,
									@va_cod_lpr		,
									@va_cod_ven		,
									@va_est_ado		
									)

			FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, 
								@va_car_net, @va_dir_per, @va_tel_per, @va_cel_per,@va_ema_per,  
								@va_ubi_gps, @va_cod_lpr, @va_cod_ven, @va_est_ado
END	

CLOSE vc_per_son
DEALLOCATE vc_per_son
 
	SELECT * 
	FROM #resultado
 
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    
	RETURN
END CATCH	   

GO


