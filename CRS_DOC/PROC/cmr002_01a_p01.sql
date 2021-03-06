/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr002_01a_p01.sql
PROCEDIMIENTO: BUSCA LSITA DE PRECIOS PERMITIDAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	20-02-2021 
◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr002_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr002_01a_p01
GO

CREATE PROCEDURE cmr002_01a_p01		@ar_cod_pro		VARCHAR(15),	-- Texto a ser buscado
									@ar_lis_ini		INT,			-- Criterio (0 = ide doc , 1=Nombre Doc, 2=Nombre Talonario)
									@ar_lis_fin		INT				-- Estado (H= Habilitado; N= deshabilitado
									 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01),
@va_cod_lis		INT,
@va_nom_lis		VARCHAR(30),
@va_mon_lis		CHAR(01),
@va_pre_cio		DECIMAL(10,5),
@va_pmx_des		DECIMAL(4,2),
@va_pmx_inc		DECIMAL(4,2),
@va_nro_dec		INT

CREATE TABLE #RESULTADO
(
va_cod_lis		INT,
va_nom_lis		VARCHAR(30),
va_mon_lis		CHAR(01),
va_pre_cio		DECIMAL(10,5),
va_pmx_des		DECIMAL(4,2),
va_pmx_inc		DECIMAL(4,2),
va_nro_dec		INT
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 


DECLARE vc_pre_cio CURSOR LOCAL FOR
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_mon_lis, cmr001.va_nro_dec
	FROM cmr001, ads008
	WHERE (cmr001.va_cod_lis = RTRIM(ads008.va_ide_uno))
	AND	  (ads008.va_ide_tab = 'cmr001')
	AND   (ads008.va_ide_usr = SYSTEM_USER)
	AND   (cmr001.va_cod_lis BETWEEN @ar_lis_ini AND @ar_lis_fin)
	AND	  (cmr001.va_est_ado = 'H')
	

OPEN vc_pre_cio
FETCH NEXT FROM vc_pre_cio INTO @va_cod_lis, @va_nom_lis,@va_mon_lis, @va_nro_dec

WHILE (@@FETCH_STATUS = 0)
BEGIN

	SET @va_pre_cio = 0
	SET @va_pmx_des = 0
	SET @va_pmx_inc = 0

	-- Obtiene precio del producto
	SELECT @va_pre_cio = va_pre_cio,
		   @va_pmx_des = va_pmx_des,
		   @va_pmx_inc = va_pmx_inc
	  FROM cmr002
	 WHERE va_cod_pro = @ar_cod_pro
	   AND va_cod_lis = @va_cod_lis
	   
	--IF(@@ERROR <> 0)
	--BEGIN
	--	SET @va_pre_cio = 0
	--	SET @va_pmx_des = 0
	--	SET @va_pmx_inc = 0
	--END   
	   
	 
	INSERT INTO #resultado VALUES (@va_cod_lis		,
									@va_nom_lis		,
									@va_mon_lis		,
									@va_pre_cio		,
									@va_pmx_des		,
									@va_pmx_inc		,
									@va_nro_dec
									)
	FETCH NEXT FROM vc_pre_cio INTO @va_cod_lis, @va_nom_lis,@va_mon_lis, @va_nro_dec
END	

CLOSE vc_pre_cio
DEALLOCATE vc_pre_cio

SELECT *
  FROM #RESULTADO



RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


