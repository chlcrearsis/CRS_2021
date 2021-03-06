/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv002_06a_p01.sql
PROCEDIMIENTO: ELIMINAR BODEGA
	
AUTOR:	CREARSIS(CHL)
FECHA:	01-08-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_06a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_06a_p01
GO

CREATE PROCEDURE inv002_06a_p01	@ar_ide_gru		INT,
								@ar_cod_bod		INT
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg				nvarchar(200),
@count				INT,
@va_est_ado			CHAR(01)	    --** Estado del Grupo



IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 
	 
	 SELECT @va_est_ado = va_est_ado
	  FROM inv002 
	 WHERE (va_cod_bod = @ar_cod_bod)
	  
		IF (@va_est_ado = 'V')
		BEGIN
			RAISERROR ('No puede Elminiar la bodega, se encuentra habilitada' ,16,1)
			RETURN
		END
		IF (@va_est_ado = 'N')
		BEGIN
		
			-- Verifica que no haya movimientos en el kardex correspondiente al almacen a eliminar
			SET @count = 0
			SELECT @count = COUNT(*)
			  FROM inv100
			 WHERE va_cod_bod = @ar_cod_bod
			IF(@count = 0)
			BEGIN
				-- Elimina almacen
				DELETE inv002
				WHERE va_ide_gru = @ar_ide_gru AND va_cod_bod = @ar_cod_bod
				
				-- Registrar bitacora por operacion
				--INSERT INTO
			END
			ELSE
			BEGIN
				RAISERROR ('No puede Elminiar la bodega por que ya cuenta con movimientos' ,16,1)
				RETURN
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