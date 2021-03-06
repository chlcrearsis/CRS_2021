/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr001_01a_p01.sql
PROCEDIMIENTO: BUSCA LSITA DE PRECIOS PERMITIDAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	19-02-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr001_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr001_01a_p01
GO

CREATE PROCEDURE cmr001_01a_p01		@ar_tex_bus		VARCHAR(60),	-- Texto a ser buscado
									@ar_cri_bus		INT,			-- Criterio (0 = ide doc , 1=Nombre Doc, 2=Nombre Talonario)
									@ar_est_ado		CHAR(01)		-- Estado (H= Habilitado; N= deshabilitado
									 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

-- Prepara criterio estado
IF @ar_est_ado = 'T'
	SET @va_est_ado = '%'
ELSE
	SET @va_est_ado = @ar_est_ado


IF(@ar_cri_bus = 0)	-- busca por codigo
BEGIN
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_fec_ini, 
		   cmr001.va_fec_fin, cmr001.va_mon_lis, cmr001.va_est_ado
	FROM cmr001
	WHERE (cmr001.va_cod_lis LIKE @ar_tex_bus + '%')
	AND	  (cmr001.va_est_ado LIKE @va_est_ado)
END

IF(@ar_cri_bus = 1)	-- busca por nombre
BEGIN
	SELECT cmr001.va_cod_lis, cmr001.va_nom_lis, cmr001.va_fec_ini, 
		   cmr001.va_fec_fin, cmr001.va_mon_lis, cmr001.va_est_ado
	FROM cmr001
	WHERE (cmr001.va_nom_lis LIKE @ar_tex_bus + '%' )
	AND	  (cmr001.va_est_ado LIKE @va_est_ado)
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


