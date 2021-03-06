/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: res004_01b_p01.sql
PROCEDIMIENTO: BUSCA PLANTILLA DE VENTA RESTAURANT
	CON PERMISOS PARA EL USUARIO
AUTOR:	CREARSIS(CHL)
FECHA:	28-10-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res004_01b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.res004_01b_p01
GO

CREATE PROCEDURE res004_01b_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = Codigo Prod. , 1=Nombre Prod.)
									@ar_est_bus		CHAR(01)		-- Estado (H = Habilitado, N=Deshabilitado)
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_plv		INT,
@va_nom_plv		NVARCHAR(30),
@va_des_plv		NVARCHAR(120),
@va_est_ado		CHAR(01)


CREATE TABLE #resultado
(
va_cod_plv		INT,
va_nom_plv		NVARCHAR(30),
va_des_plv		NVARCHAR(120),
va_est_ado		CHAR(01)

)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

IF (@ar_est_bus = 'T')
	SET @ar_est_bus = '%'

IF (@ar_cri_bus = 0) -- Busca por Codigo
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_cod_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 1) -- Busca por Nombre
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_nom_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
IF (@ar_cri_bus = 2) -- Busca por Descripcion
BEGIN
	DECLARE vc_pla_vta CURSOR LOCAL FOR
	SELECT va_cod_plv, va_nom_plv, va_des_plv,va_est_ado
	FROM res004
	WHERE va_des_plv LIKE @ar_tex_bus + '%'	AND
		  va_est_ado LIKE @ar_est_bus
END
  
OPEN vc_pla_vta
FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	 SELECT @cout = COUNT(*)
	 FROM	ads008
	 WHERE	va_ide_usr = SYSTEM_USER	AND
			va_ide_tab = 'res004'		AND
			va_ide_uno = @va_cod_plv
	 
	IF @cout <> 0
	BEGIN 
	 INSERT INTO #resultado VALUES (@va_cod_plv		,
									@va_nom_plv		,
									@va_des_plv		,
									@va_est_ado	
									)
	END
	
	FETCH NEXT FROM vc_pla_vta INTO @va_cod_plv, @va_nom_plv, @va_des_plv, @va_est_ado
END	

SELECT * FROM #resultado

CLOSE vc_pla_vta
DEALLOCATE vc_pla_vta

	
RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO