/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv099_R02.sql
PROCEDIMIENTO: CONSULTA EXISTENCIA ACTUAL POR BODEGAS
	
AUTOR:	CREARSIS(fvm)
FECHA:	15-04-2019
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */ 
if exists (select * from sysobjects where id = object_id('dbo.inv099_R02') and sysstat & 0xf = 4)
	drop procedure dbo.inv099_R02
GO

CREATE PROCEDURE inv099_R02		@ar_bod_ini		INT,	-- Producto
								@ar_bod_fin		INT,			-- Bodega
								@ar_fam_ini		CHAR(06),		-- Familia inicial
								@ar_fam_fin		CHAR(06),		-- Familia final
								@ar_fec_exi		DATETIME		-- Fecha de existencia
								WITH ENCRYPTION AS
							 
							 
--** Inhabilita mensajes numero de filas afectadas

SET NOCOUNT ON
DECLARE 
@msg			nvarchar(200),
@va_cod_bod	INT,			--Codigo deL Bodega (inv002)
@va_nom_bod  VARCHAR(50),
@va_cod_pro	VARCHAR(15),	--** Codigo del producto 
@va_cod_fam	VARCHAR(6),		--Código de la familia de producto
@va_nom_fam	VARCHAR(250),	--Nombre de la familia

@va_cod_fa1	VARCHAR(6),		--Código de la familia 1er nivel
@va_nom_fa1	VARCHAR(50),	--Nombre de la familia 1er nivel
@va_cod_fa2	VARCHAR(6),		--Código de la familia 2er nivel
@va_nom_fa2	VARCHAR(50),	--Nombre de la familia 2er nivel
@va_cod_fa3	VARCHAR(6),		--Código de la familia 3er nivel
@va_nom_fa3	VARCHAR(50),	--Nombre de la familia 3er nivel
@va_tip_fam CHAR(01),		--Tipo de familia

@va_nom_pro	VARCHAR(80),	--** Nombre del producto
@va_sal_can DECIMAL(14,2),	--Stock total x almacén (unidad inventario)
@va_cod_umd 	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida

--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv099(
	
	va_cod_bod	INT,			--Codigo deL Bodega (inv002)
	va_nom_bod  VARCHAR(50),
	va_cod_fa1	VARCHAR(6),		--Código de la familia 1er nivel
	va_nom_fa1	VARCHAR(50),	--Nombre de la familia 1er nivel
	va_cod_fa2	VARCHAR(6),		--Código de la familia 2er nivel
	va_nom_fa2	VARCHAR(50),	--Nombre de la familia 2er nivel
	va_cod_fa3	VARCHAR(6),		--Código de la familia 3er nivel
	va_nom_fa3	VARCHAR(50),	--Nombre de la familia 3er nivel
	va_tip_fam	CHAR(01),		--Tipo de familia
	va_cod_pro	VARCHAR(15),	--** Codigo del producto 
	va_nom_pro	VARCHAR(80),	--** Nombre del producto
	va_sal_can	DECIMAL(14,2),	--Stock total x almacén (unidad inventario)
	va_fec_exi	DATETIME,		--Fecha existencia
	va_cod_umd	CHAR(3)			--** (inv003-Und. Med)Codigo de la Unidad de Medida
   )

IF @@ERROR <> 0
   RETURN


BEGIN TRAN TR_inv100
BEGIN TRY
		
	--// Cursor sobre tabla stock     
	DECLARE vc_inv099 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_sal_can, va_cod_bod
	  FROM inv099
	 WHERE (va_cod_bod BETWEEN @ar_bod_ini AND @ar_bod_fin)
	   AND (va_sal_can > 0)

	--** Abre cursor				  
	OPEN vc_inv099   
	FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
	
		-- Obtiene saldo de stock anterior
		SET @va_sal_can = 0
		EXECUTE inv100_01p02 @va_cod_bod, @va_cod_pro, @ar_fec_exi, @va_sal_can OUTPUT
		
		IF (@va_sal_can IS NULL)
			SET @va_sal_can = 0
	
	
		-- Obtiene Datos de producto
		SELECT @va_nom_pro = va_nom_pro,
			   @va_cod_umd  = va_cod_umd,
			   @va_cod_fam = va_cod_fam
		  FROM inv004
		 WHERE va_cod_pro = @va_cod_pro 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_pro = ''
			SET @va_cod_umd  = ''
			SET @va_cod_fam = ''
		END
		
		IF (@va_cod_fam NOT BETWEEN @ar_fam_ini AND @ar_fam_fin)
		BEGIN		
			GOTO fi_sal_lin;
		END
		
		
		-- Obtiene nombre del Bodega
		SELECT @va_nom_bod = va_nom_bod 
		  FROM inv002
		 WHERE va_cod_bod = @va_cod_bod 
		
		IF @@ROWCOUNT = 0
		BEGIN
			SET @va_nom_bod = ''
		END
		
		
		--*********************************
		-- Obtiene Familia a 3er nivel
		SELECT @va_nom_fa3 = va_nom_fam,
			   @va_cod_fa3 = va_cod_fam,
			   @va_tip_fam = va_tip_fam
		  FROM inv003
		 WHERE va_cod_fam = @va_cod_fam
		
		-- Obtiene Familia a 2do nivel
		SELECT @va_nom_fa2 = va_nom_fam,
			   @va_cod_fa2 = va_cod_fam
		  FROM inv003
		 WHERE va_cod_fam = SUBSTRING(@va_cod_fam,1,4)+'00'
		
		-- Obtiene Familia a 1do nivel
		SELECT @va_nom_fa1 = va_nom_fam,
			   @va_cod_fa1 = va_cod_fam
		  FROM inv003
		 WHERE va_cod_fam = SUBSTRING(@va_cod_fam,1,2)+'0000'
		
		
		INSERT INTO #tm_inv099 VALUES ( @va_cod_bod,	--Codigo deL Bodega (inv002)
										@va_nom_bod,
										@va_cod_fa1,	--Código de la familia de producto
										@va_nom_fa1,	--Nombre de la familia
										@va_cod_fa2,	--Código de la familia de producto
										@va_nom_fa2,	--Nombre de la familia
										@va_cod_fa3,	--Código de la familia de producto
										@va_nom_fa3,	--Nombre de la familia
										@va_tip_fam,	--Tipo de familia
										@va_cod_pro,	--** Codigo del producto 
										@va_nom_pro,	--** Nombre del producto
										@va_sal_can,	--Stock total x almacén (unidad inventario)
										@ar_fec_exi,	--Fecha de existencia
										@va_cod_umd      -- Unidad de inventario
										)										
				
				
			IF @@ERROR <> 0
			BEGIN
				RAISERROR ('Ocurrio un error al registrar detalle de stock de productos',16,1)
				RETURN
			END
		
		fi_sal_lin:
		FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
	END	
	
CLOSE vc_inv099
DEALLOCATE vc_inv099


	SELECT * FROM #tm_inv099
	WHERE va_sal_can <> 0
		ORDER BY va_cod_bod, va_cod_fa1


	COMMIT TRAN TR_inv100
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO