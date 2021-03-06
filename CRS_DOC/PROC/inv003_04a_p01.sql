/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv003_04a_p01.sql
PROCEDIMIENTO: DESHABILITA FAMILIA
	
AUTOR:	CREARSIS(CHL)
FECHA:	22-07-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv003_04a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv003_04a_p01
GO

CREATE PROCEDURE inv003_04a_p01	@ar_cod_fam		CHAR(06)		
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_can_tid			INT,	--** Cantidad de registros encontrados
@va_niv_fam			INT,
@va_cod_fam			CHAR(06)


IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 -- Inicializa variables
	 SET @va_can_tid = -1;
	 SET @va_niv_fam = 0;
	 SET @va_cod_fam = @ar_cod_fam
	 
	 -- obtiene nivel de la familia
	IF(SUBSTRING(@ar_cod_fam,1,2)<> '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@ar_cod_fam,1,2)
		SET @va_niv_fam = 1
	END
	IF(SUBSTRING(@ar_cod_fam,3,2)<> '00')
	BEGIN
		SET @va_cod_fam = SUBSTRING(@ar_cod_fam,1,4)
		SET @va_niv_fam = 2
	END
	IF(SUBSTRING(@ar_cod_fam,5,2)<> '00')
	BEGIN
		SET @va_niv_fam = 3
	END
		
	 IF(@va_niv_fam <> 3) -- Si la familia no es del 3er nivel, entonces pregunta por sus familias dependientes
	 BEGIN
		
		 SELECT @va_can_tid = COUNT(*)
		  FROM inv003 
		 WHERE (va_cod_fam <> @ar_cod_fam)
			AND (va_cod_fam LIKE RTRIM(@va_cod_fam) + '%')
			AND (va_est_ado = 'H')
			 
			
	END
	ELSE
		SET @va_can_tid = 0
	
	
	IF(@va_can_tid = -1)
	BEGIN
		RAISERROR ('La familia de producto no se encuentra registrada' ,16,1)
		RETURN
	END
	 
	IF(@va_can_tid > 0)
	BEGIN
		RAISERROR ('La familia No puede ser Deshabilitada, Existen otras familias relacionados a ella que estan Habilitadas, revise por favor ' ,16,1)
		RETURN
	END
	
	IF(@va_can_tid = 0 AND @va_niv_fam <> 3)--Si no hay otras familas dependientes y el nivel es distinto de 3, 
											--procede a deshabilitar
	BEGIN
		UPDATE inv003 SET va_est_ado = 'N'
		WHERE va_cod_fam = @ar_cod_fam
	END
	
	IF(@va_can_tid = 0 AND @va_niv_fam = 3) -- Si no hay otras familias dependientes y el nivel es igual a 3, pregunta
											-- si tiene productos dependientes que esten habilitados  
	BEGIN
		-- Verifica que no tenga productos relacionados que esten habilitados
		SELECT @va_can_tid = COUNT(*)
		  FROM inv004 
		 WHERE (va_cod_fam = @ar_cod_fam)
			AND (va_est_ado = 'H')
		
		IF(@va_can_tid > 0)-- Si hay registros, no podra deshabilitar
		BEGIN
			RAISERROR ('La familia no puede ser Deshabilitada, Existen Productos relacionados que estan Habilitados, revise por favor. ' ,16,1)
			RETURN
		END
		IF(@va_can_tid = 0) -- Si no hay registros, deshabilita familia
		BEGIN
			UPDATE inv003 SET va_est_ado = 'N'
			WHERE va_cod_fam = @ar_cod_fam
		END
		
	END
	 
	
	
	
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO