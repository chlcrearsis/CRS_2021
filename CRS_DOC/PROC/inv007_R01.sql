/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv007_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE COMPRAS
AUTOR:	CREARSIS(chl)
FECHA:	19-12-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_R01
GO

CREATE PROCEDURE inv007_R01 @ar_cod_pe1 INT,			-- Proveedor
							@ar_cod_pe2 INT,			-- Proveedor
							@ar_cod_bo1 INT,			-- Bodega
							@ar_cod_bo2 INT,			-- Bodega
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_est_ado CHAR(01)		-- Estado (T=todos ; H=valido ; N=anulado)
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),

@va_fec_cmp		DATETIME, 
@va_ide_cmp		NVARCHAR(15), 
@va_nro_cmp		INT, 
@va_cod_per		INT, 
@va_raz_soc		NVARCHAR(180),
@va_mon_cmp		CHAR(01), 
@va_tot_nBs		DECIMAL(16,2), 
@va_tot_nUs		DECIMAL(16,2), 
@va_est_ado		CHAR(01), 
@va_ges_cmp		INT, 
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(40),
@va_obs_cmp		NVARCHAR(200)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_inv007(
	va_fec_cmp		DATETIME, 
	va_ide_cmp		NVARCHAR(15), 
	va_nro_cmp		INT, 
	va_cod_per		INT, 
	va_raz_soc		NVARCHAR(180),
	va_mon_cmp		CHAR(01), 
	va_tot_nBs		DECIMAL(16,2), 
	va_tot_nUs		DECIMAL(16,2), 
	va_est_ado		CHAR(01), 
	va_ges_cmp		INT, 
	va_cod_bod		INT,
	va_nom_bod		VARCHAR(40),
	va_obs_cmp		NVARCHAR(200)
   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 


IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'




--// Cursor sobre temporal
DECLARE vc_inv007 CURSOR LOCAL FOR
SELECT	va_fec_cmp, va_ide_cmp, va_nro_cmp, va_cod_per, va_raz_soc, 
		va_mon_cmp, va_tot_nBs, va_tot_nUs, va_est_ado, va_ges_cmp, va_cod_bod, va_obs_cmp
 FROM inv007
WHERE	(va_cod_per BETWEEN @ar_cod_pe1 AND @ar_cod_pe2)  AND
		(va_cod_bod BETWEEN @ar_cod_bo1 AND @ar_cod_bo2)  AND
		
		(va_fec_cmp BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
		 va_est_ado LIKE @ar_est_ado  

--** Abre cursor		  
OPEN vc_inv007    
	 
FETCH NEXT FROM vc_inv007 INTO @va_fec_cmp, @va_ide_cmp, @va_nro_cmp, @va_cod_per, @va_raz_soc,
							   @va_mon_cmp, @va_tot_nBs, @va_tot_nUs, @va_est_ado, @va_ges_cmp, @va_cod_bod, @va_obs_cmp

WHILE (@@FETCH_STATUS = 0)
BEGIN
	--Obtiene nombre de Bodega
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @va_cod_bod
	 
	 INSERT INTO #tm_inv007 VALUES	(@va_fec_cmp,
									@va_ide_cmp	,
									@va_nro_cmp	,
									@va_cod_per	,
									@va_raz_soc	,
									@va_mon_cmp	,
									@va_tot_nBs	,
									@va_tot_nUs	,
									@va_est_ado	,
									@va_ges_cmp	,
									@va_cod_bod	,
									@va_nom_bod	,
									@va_obs_cmp
									)
	FETCH NEXT FROM vc_inv007 INTO @va_fec_cmp, @va_ide_cmp, @va_nro_cmp, @va_cod_per, @va_raz_soc,
							   @va_mon_cmp, @va_tot_nBs, @va_tot_nUs, @va_est_ado, @va_ges_cmp, @va_cod_bod,@va_obs_cmp

END	
CLOSE vc_inv007
DEALLOCATE vc_inv007

SELECT * FROM #tm_inv007
ORDER BY va_fec_cmp

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO