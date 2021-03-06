/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv004_02a_p03.sql
PROCEDIMIENTO: CODIFICACION AUTOMATICA DE PRODUCTO CON 3 DIGITOS
	
AUTOR:	CREARSIS(CHL)
FECHA:	07-09-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv004_02a_p03') and sysstat & 0xf = 4)
	drop procedure dbo.inv004_02a_p03
GO

CREATE PROCEDURE inv004_02a_p03		@ar_cod_fam		VARCHAR(15)	-- Codigo familia
									WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@cout			INT			,	-- Contador de registros para verificar
@va_cod_pro		VARCHAR(15),
@va_cod_fam		VARCHAR(06),
@va_ult_cod		VARCHAR(15),
@va_cod_aux		VARCHAR(15),
@va_cod_num		INT,

@va_est_ado		CHAR(01)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	SET @va_cod_pro = ''
	
	SELECT @va_cod_pro = ISNULL(MAX(va_cod_pro),'')
	FROM inv004
	WHERE va_cod_fam = @ar_cod_fam AND
		  va_cod_pro LIKE @ar_cod_fam + '%'
	
	--IF(@va_cod_pro IS NULL)		
	--	SET @va_cod_pro = ''
		
	IF @va_cod_pro = ''	-- Si no hay 
	BEGIN
		SET @va_ult_cod = @ar_cod_fam + '.001'
	END
	ELSE
	BEGIN
		print @va_cod_pro
		
		SET @va_cod_num = CAST (SUBSTRING(@va_cod_pro,8,3) AS INT )
		SET @va_cod_num = @va_cod_num  + 1
		SET @va_cod_num = 1000 + @va_cod_num
		SET @va_cod_aux = CAST(@va_cod_num AS VARCHAR(15))
		
		SET @va_cod_aux = SUBSTRING(@va_cod_aux,2,3) 
		
		SET @va_ult_cod = @ar_cod_fam + '.' + @va_cod_aux
	END
	
	SELECT @va_ult_cod AS va_cod_pro
  		
	RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO


