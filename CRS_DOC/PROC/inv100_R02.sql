/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv100_R02.sql
PROCEDIMIENTO: REPORTE STOCK DE UN PRODUCTO
	
AUTOR:	CREARSIS(fvm)
FECHA:	15-04-2019
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv100_R02') and sysstat & 0xf = 4)
	drop procedure dbo.inv100_R02
GO

CREATE PROCEDURE inv100_R02	@ar_bod_ini		CHAR(06),	-- Producto
								@ar_bod_fin		CHAR(06),			-- Almacen
								@ar_fam_ini		CHAR(06),		-- Familia inicial
								@ar_fam_fin		CHAR(06)		-- Familia final
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_cod_bod	CHAR(06),			--Codigo deL ALMACEN (inv011)
@va_nom_bod  VARCHAR(50),
@va_cod_fam	VARCHAR(6),		--Código de la familia de producto
@va_cod_pro	VARCHAR(15),	--** Codigo del producto 
@va_nom_fam	VARCHAR(250),	--Nombre de la familia
@va_cod_aux VARCHAR(6),		--Código de la familia de producto
@va_cod_aux2 VARCHAR(6),		--Código de la familia de producto
@va_cod_aux3 VARCHAR(6),		--Código de la familia de producto
@va_fam_aux	VARCHAR(250),	--Nombre de la familia
@va_nom_pro	VARCHAR(80),	--** Nombre del producto
@va_sal_can DECIMAL(14,2),	--Stock total x almacén (unidad inventario)
@va_und_inv	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv100(
	
	va_cod_bod	CHAR(06),			--Codigo deL ALMACEN (inv011)
	va_nom_bod  VARCHAR(50),
	va_cod_fam	VARCHAR(6),		--Código de la familia de producto
	va_nom_fam	VARCHAR(250),	--Nombre de la familia
	va_cod_pro	VARCHAR(15),	--** Codigo del producto 
	va_nom_pro	VARCHAR(80),	--** Nombre del producto
	va_sal_can DECIMAL(14,2),	--Stock total x almacén (unidad inventario)
	va_cod_inv	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
	
		
	--// Cursor sobre tabla stock     
	DECLARE vc_inv002 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_sal_can, va_cod_bod
	  FROM inv101 
	 WHERE (va_cod_bod BETWEEN @ar_bod_ini AND @ar_bod_fin)
	   AND (va_sal_can > 0)

	--** Abre cursor				  
	OPEN vc_inv002   
	FETCH NEXT FROM vc_inv002 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		-- Obtiene Datos de producto
		SELECT @va_nom_pro = va_nom_pro,
			   @va_und_inv = va_cod_umd,
			   @va_cod_fam = va_cod_fam
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_pro = ''
			SET @va_und_inv = ''
			SET @va_cod_fam = ''
		END
		
		IF (@va_cod_fam NOT BETWEEN @ar_fam_ini AND @ar_fam_fin)
		BEGIN		
			GOTO fi_sal_lin;
		END
		
		
		-- Obtiene nombre del almacen
		SELECT @va_nom_bod = va_nom_bod 
		  FROM inv011
		 WHERE va_cod_bod = @va_cod_bod 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_bod = ''
		END
		
		-- Obtiene nombre de la familia
		--** Verifica la familia que se desplegue
		IF SUBSTRING(@va_cod_fam,1,2) <> '00'
		BEGIN 
			SET @va_cod_aux = SUBSTRING(@va_cod_fam,1,2) + '0000'
			
			SELECT @va_nom_fam = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_nom_fam = ''
			END
		END
		
		IF SUBSTRING(@va_cod_fam,3,2) <> '00'
		BEGIN 
			SET @va_cod_aux2 = SUBSTRING(@va_cod_fam,1,4) + '00'
			
			SELECT @va_fam_aux = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux2
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_fam_aux = ''
			END
			
			IF LEN(RTRIM(@va_nom_fam)) <> ''
			BEGIN
				SET @va_nom_fam = @va_cod_aux + ' - ' + @va_nom_fam + CHAR(13) + CHAR(10) + '   ' +@va_cod_aux2+' - '+ @va_fam_aux
			END
			 
		END
		
		IF SUBSTRING(@va_cod_fam,5,2) <> '00'
		BEGIN 
			SET @va_cod_aux3 = SUBSTRING(@va_cod_fam,1,6)
			
			SELECT @va_fam_aux = va_nom_fam 
			  FROM inv003
			 WHERE va_cod_fam = @va_cod_aux3
			
			IF @@ROWCOUNT = 0
			BEGIN
				SET @va_fam_aux = ''
			END
			
			IF LEN(RTRIM(@va_nom_fam)) <> ''
			BEGIN
				SET @va_nom_fam = @va_nom_fam + CHAR(13) + CHAR(10) + '	     ' + @va_cod_aux3 +' - '+ @va_fam_aux
			END			 
		END
		--SET @va_nom_fam = @va_nom_fam + CHAR(13) + CHAR(10) + '   .'
		
		INSERT INTO #tm_inv100 VALUES ( @va_cod_bod,	--Codigo deL ALMACEN (inv011)
										@va_nom_bod,
										@va_cod_fam,	--Código de la familia de producto
										@va_nom_fam,	--Nombre de la familia
										@va_cod_pro,	--** Codigo del producto 
										@va_nom_pro,	--** Nombre del producto
										@va_sal_can,	--Stock total x almacén (unidad inventario)
										@va_und_inv     -- Unidad de inventario
										)										
				
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de stock de productos',16,1)
				RETURN
			END
		
		fi_sal_lin:
		FETCH NEXT FROM vc_inv002 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
	END	
	
CLOSE vc_inv002
DEALLOCATE vc_inv002


	SELECT * FROM #tm_inv100
		ORDER BY va_cod_bod, va_cod_fam


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO