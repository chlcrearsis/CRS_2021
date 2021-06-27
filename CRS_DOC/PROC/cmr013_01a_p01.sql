/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr013_01a_p01.sql
PROCEDIMIENTO: BUSCA PERSONA
	
AUTOR:	CREARSIS(CHL)
FECHA:	18-09-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr013_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr013_01a_p01
GO

CREATE PROCEDURE cmr013_01a_p01		@ar_cod_gru		INT,			-- Ide del modulo
									@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT	,			-- 0=cod per , 1=Razon Social
																	-- 2=Nombre Comercial, 3=Nit, 4=CI, 
									@ar_est_ado		CHAR(01)		-- Estado
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
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

IF(@ar_est_ado ='T')
	SET @ar_est_ado = '%'

-- Crea cursor para busqueda
IF(@ar_cri_bus = 0)  -- Codigo Persona
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM cmr013 
	WHERE (va_cod_per LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 1)  -- Razon Social
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM cmr013 
	WHERE (va_raz_soc LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 2)  -- Nombre Comercial
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM cmr013 
	WHERE (va_nom_com LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 3)  -- Nit
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM cmr013 
	WHERE (va_nit_per LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END

IF(@ar_cri_bus = 4)  -- CI
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM cmr013 
	WHERE (va_car_net LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END


IF(@ar_cri_bus = 5)  -- Celular
BEGIN
	DECLARE vc_per_son CURSOR LOCAL FOR
	SELECT va_cod_gru,va_cod_per, va_raz_soc, va_nom_com, va_nit_per, va_car_net, 
		   va_dir_per, va_tel_per, va_cel_per, va_est_ado
	FROM cmr013 
	WHERE (va_cel_per LIKE @ar_tex_bus + '%')	AND
		  (va_est_ado LIKE @ar_est_ado)
		  
END


OPEN vc_per_son
FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, @va_car_net, @va_dir_per, @va_tel_per, @va_cel_per, @va_est_ado
									
					
WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del Grupo
	SELECT @va_nom_gru = va_nom_gru
	  FROM cmr012
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
									@va_est_ado		
									)

	FETCH NEXT FROM vc_per_son INTO @va_cod_gru,@va_cod_per, @va_raz_soc, @va_nom_com, @va_nit_per, @va_car_net, @va_dir_per, @va_tel_per, @va_cel_per, @va_est_ado
END	

CLOSE vc_per_son
DEALLOCATE vc_per_son

IF(@ar_cod_gru = 0)	
BEGIN
	SELECT * 
	FROM #resultado
END
IF(@ar_cod_gru <> 0)	
BEGIN
	SELECT * 
	FROM #resultado
	WHERE va_cod_gru = @ar_cod_gru
END

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


