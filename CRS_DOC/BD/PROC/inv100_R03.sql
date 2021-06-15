/*????????????????????????????????????????????????
ARCHIVO: inv003_R03.sql
PROCEDIMIENTO: REPORTE CATALOGO DE PRODUCTO
	
AUTOR:	CREARSIS(FVM)
FECHA:	21-04-2019
--????????????????????????????????????????????????*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv003_R03') and sysstat & 0xf = 4)
	drop procedure dbo.inv003_R03
GO

CREATE PROCEDURE inv003_R03	@ar_fam_ini		CHAR(06),		-- Familia inicial
								@ar_fam_fin		CHAR(06)		-- Familia final
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_cod_fam	VARCHAR(6),		--Código de la familia de producto
@va_cod_pro	VARCHAR(15),	--** Codigo del producto 
@va_nom_fam	VARCHAR(250),	--Nombre de la familia
@va_cod_aux	VARCHAR(6),		--Código de la familia de producto
@va_cod_aux2 VARCHAR(6),		--Código de la familia de producto
@va_cod_aux3 VARCHAR(6),		--Código de la familia de producto

@va_fam_aux	VARCHAR(250),	--Nombre de la familia
@va_nom_pro	VARCHAR(80),	--** Nombre del producto
@va_und_cmp	CHAR(3),		--** (inv003-Und. Med)Codigo de la unidad de compra
@va_und_vta	CHAR(3),		--** (inv003-Und. Med)Codigo de la unidad de venta
@va_und_inv	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv100(
	va_cod_fam	VARCHAR(6),		--Código de la familia de producto
	va_nom_fam	VARCHAR(250),	--Nombre de la familia
	va_cod_pro	VARCHAR(15),	--** Codigo del producto 
	va_nom_pro	VARCHAR(80),	--** Nombre del producto
	va_cod_inv	CHAR(3),		--** (inv003-Und. Med)Codigo de la Unidad de Medida
	va_und_cmp	CHAR(3),		--** (inv003-Und. Med)Codigo de la unidad de compra
    va_und_vta	CHAR(3) 		--** (inv003-Und. Med)Codigo de la unidad de venta
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
	
		
	--// Cursor sobre tabla catalogo     
	DECLARE vc_inv004 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_nom_pro, va_cod_umd,
		   va_cod_fam, va_und_cmp, va_und_vta
	  FROM inv004 
	 WHERE (va_cod_fam BETWEEN @ar_fam_ini AND @ar_fam_fin)
	   
	--** Abre cursor				  
	OPEN vc_inv004   
	FETCH NEXT FROM vc_inv004 INTO @va_cod_pro, @va_nom_pro, @va_und_inv,
								   @va_cod_fam, @va_und_cmp, @va_und_vta
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
				
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
		--SET @va_nom_fam = @va_nom_fam + ' - ' + @va_cod_fam + CHAR(13) + CHAR(10) + '   .'
		
		INSERT INTO #tm_inv100 VALUES ( @va_cod_fam,	--Código de la familia de producto
										@va_nom_fam,	--Nombre de la familia
										@va_cod_pro,	--** Codigo del producto 
										@va_nom_pro,	--** Nombre del producto
										@va_und_inv,     -- Unidad de inventario
										@va_und_cmp,
										@va_und_vta
										)										
				
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de stock de productos',16,1)
				RETURN
			END
				
		FETCH NEXT FROM vc_inv004 INTO @va_cod_pro, @va_nom_pro, @va_und_inv,
									   @va_cod_fam, @va_und_cmp, @va_und_vta
	END	
	
CLOSE vc_inv004
DEALLOCATE vc_inv004


	SELECT * FROM #tm_inv100
		ORDER BY va_cod_fam


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO