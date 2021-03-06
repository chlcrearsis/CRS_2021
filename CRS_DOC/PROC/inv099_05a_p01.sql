/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv099_05a_p01.sql
PROCEDIMIENTO: OBTIENE EXISTENCIA ACTUAL DE UN PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	11-12-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv099_05a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv099_05a_p01
GO

CREATE PROCEDURE inv099_05a_p01 @ar_cod_pro	VARCHAR(15)
							 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			NVARCHAR(200),
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(40),
@va_cod_pro		VARCHAR(15),
@va_nom_pro		VARCHAR(80),
@va_cod_umd		CHAR(03),
@va_und_cmp		CHAR(03),
@va_und_vta		CHAR(03),
@va_eqv_cmp		DECIMAL(6,2),
@va_eqv_vta		DECIMAL(6,2),
@va_nro_dec		INT,
@va_cod_fam		CHAR(06),
@va_nom_fam		VARCHAR(50),
@va_sal_can		DECIMAL(16,4),
@va_est_ado		CHAR(01)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv099(
	va_cod_bod		INT				NOT NULL,	--Codigo de bodega
	va_nom_bod		VARCHAR(40)		NOT NULL,	--Nombre de bodega
	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
	va_nom_pro		VARCHAR(80)		NOT NULL,	--Nombre de producto
	va_cod_umd		CHAR(03),
	va_und_cmp		CHAR(03),
	va_und_vta		CHAR(03),
	va_eqv_cmp		DECIMAL(6,2),
	va_eqv_vta		DECIMAL(6,2),
	va_nro_dec		INT,
	va_cod_fam		CHAR(06),
	va_nom_fam		VARCHAR(50),
	va_sal_can		DECIMAL(16,4)	NOT NULL,	--Saldo actual del producto
	va_est_ado		CHAR(01)
   )
   
IF @@ERROR <> 0
   RETURN
 
--// Cursor sobre tabla stock     
	DECLARE vc_inv099 CURSOR LOCAL FOR
	SELECT va_cod_pro, va_sal_can, va_cod_bod
	  FROM inv099
	 WHERE va_cod_pro = @ar_cod_pro

	--** Abre cursor				  
	OPEN vc_inv099   
	FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod
		
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		-- Obtiene datos de producto
		SELECT @va_nom_pro = va_nom_pro,
			   @va_cod_umd = va_cod_umd,
			   @va_und_cmp = va_und_cmp,
			   @va_und_vta = va_und_vta,
			   @va_eqv_cmp = va_eqv_cmp,
			   @va_eqv_vta = va_eqv_vta,
			   @va_nro_dec = va_nro_dec,
			   @va_cod_fam = va_cod_fam,
			   @va_est_ado = va_est_ado
		  FROM inv004
		 WHERE (va_cod_pro = @ar_cod_pro)
		
		-- Obtiene nombre de bodega
		SELECT @va_nom_bod = va_nom_bod
		 FROM	inv002
		WHERE	(va_cod_bod = @va_cod_bod)
		
		-- Obtiene nombre de familia
		SELECT @va_nom_fam = va_nom_fam
		  FROM inv003
		 WHERE (va_cod_fam = @va_cod_fam)
		
		-- Inserta en tabla resultado
		INSERT INTO #tm_inv099 VALUES (	@va_cod_bod,
										@va_nom_bod,
										@va_cod_pro,
										@va_nom_pro,
										@va_cod_umd,
										@va_und_cmp,
										@va_und_vta,
										@va_eqv_cmp,
										@va_eqv_vta,
										@va_nro_dec,
										@va_cod_fam,
										@va_nom_fam,
										@va_sal_can,
										@va_est_ado
										)
		FETCH NEXT FROM vc_inv099 INTO @va_cod_pro, @va_sal_can, @va_cod_bod

	END
	
CLOSE vc_inv099
DEALLOCATE vc_inv099



SELECT * FROM #tm_inv099


GO