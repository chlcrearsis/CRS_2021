/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv004_01a_p01.sql
PROCEDIMIENTO: BUSCA PRODUCTO ABM
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_01a_p01
GO

CREATE PROCEDURE inv004_01a_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01),		-- Estado (H = Habilitado, N=Deshabilitado)
									@ar_cod_fam		VARCHAR(06)		-- Codigo familia
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_pro		VARCHAR(15),
@va_nom_pro		NVARCHAR(80),
@va_des_pro		NVARCHAR(200),
@va_cod_umd		CHAR(03),
@va_und_cmp		CHAR(03),
@va_und_vta		CHAR(03),
@va_cod_mar		INT,
@va_nom_mar		VARCHAR(20),
@va_eqv_cmp		DECIMAL(6,2),
@va_eqv_vta		DECIMAL(6,2),
@va_cod_fam		VARCHAR(06),
@va_nom_fam		VARCHAR(60),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_pro		VARCHAR(15),
va_nom_pro		NVARCHAR(80),
va_des_pro		NVARCHAR(200),
va_cod_umd		CHAR(03),
va_und_cmp		CHAR(03),
va_und_vta		CHAR(03),
va_cod_mar		INT,
va_nom_mar		VARCHAR(20),
va_eqv_cmp		DECIMAL(6,2),
va_eqv_vta		DECIMAL(6,2),
va_cod_fam		VARCHAR(06),
va_nom_fam		VARCHAR(60),
va_est_ado		CHAR(01)

)



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 


IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'


IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_cod_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_nom_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_des_pro LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END

IF (@ar_cri_bus = 3) -- Busca por Cod. Barra
BEGIN
	DECLARE vc_pro_duc CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_des_pro, va_cod_umd, va_und_cmp,va_und_vta,va_cod_mar,va_eqv_cmp,va_eqv_vta,va_cod_fam,va_est_ado
	FROM inv004
	WHERE va_cod_bar LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
  
OPEN vc_pro_duc
FETCH NEXT FROM vc_pro_duc INTO @va_cod_pro, @va_nom_pro, @va_des_pro, @va_cod_umd, @va_und_cmp,@va_und_vta,@va_cod_mar,@va_eqv_cmp,@va_eqv_vta,@va_cod_fam, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del Marca
	SELECT @va_nom_mar = va_nom_mar
	  FROM inv006
	 WHERE va_cod_mar = @va_cod_mar
	 
	-- Obtiene nombre de la familia
	SELECT @va_nom_fam = va_nom_fam
	  FROM inv003
	 WHERE va_cod_fam LIKE @va_cod_fam + '%'
	 
	
	 INSERT INTO #resultado VALUES (@va_cod_pro		,
									@va_nom_pro		,
									@va_des_pro		,
									@va_cod_umd		,
									@va_und_cmp		,
									@va_und_vta		,
									@va_cod_mar		,
									@va_nom_mar		,
									@va_eqv_cmp		,
									@va_eqv_vta		,
									@va_cod_fam		,
									@va_nom_fam		,
									@va_est_ado	
									)
	FETCH NEXT FROM vc_pro_duc INTO @va_cod_pro, @va_nom_pro, @va_des_pro, @va_cod_umd, @va_und_cmp,@va_und_vta,@va_cod_mar,@va_eqv_cmp,@va_eqv_vta,@va_cod_fam, @va_est_ado
END	

CLOSE vc_pro_duc
DEALLOCATE vc_pro_duc

IF(@ar_cod_fam = '000000')	
BEGIN
	SELECT * 
	FROM #resultado
END

IF (@ar_cod_fam <> '000000')	
BEGIN
	SET @va_cod_fam = @ar_cod_fam


	IF (RIGHT(@va_cod_fam,4) = '0000')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@va_cod_fam, 1, 2)
		SET @va_cod_fam = @va_cod_fam + '____'
		
		
	END	
	IF (RIGHT(@va_cod_fam,2) = '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@va_cod_fam, 1, 4)
		SET @va_cod_fam = @va_cod_fam + '__'
	END
	
	


	
	SELECT * 
	FROM #resultado
	WHERE va_cod_fam LIKE @va_cod_fam
			
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


