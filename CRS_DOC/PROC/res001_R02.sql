/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: res001_R02.sql
PROCEDIMIENTO: REPORTE VENTAS DE UN DELIVERY
AUTOR:	CREARSIS(chl)
FECHA:	11-10-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.res001_R02') and sysstat & 0xf = 4)
	drop procedure dbo.res001_R02
GO

CREATE PROCEDURE res001_R02 @ar_cod_bod INT,			-- Bodega
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_cod_del	INT			-- Codigo delivery
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),

@va_fec_vta		DATETIME, 
@va_ide_vta		NVARCHAR(15), 
@va_nro_vta		INT, 
@va_cod_per		INT, 
@va_raz_soc		NVARCHAR(180),
@va_mon_vta		CHAR(01), 
@va_tot_vtB		DECIMAL(16,2), 
@va_tot_vtU		DECIMAL(16,2), 
@va_est_ado		CHAR(01), 
@va_ges_vta		INT, 
@va_cod_bod		INT,
@va_nom_bod		VARCHAR(40),

@va_nom_del		VARCHAR(30),
@va_por_cen		INT,
@va_mto_cal		DECIMAL(16,2)


--** CREA TABLA TEMPORAL
CREATE TABLE #tm_res001(
	va_fec_vta		DATETIME, 
	va_ide_vta		NVARCHAR(15), 
	va_nro_vta		INT, 
	va_cod_per		INT, 
	va_raz_soc		NVARCHAR(180),
	va_mon_vta		CHAR(01), 
	va_tot_vtB		DECIMAL(16,2), 
	va_tot_vtU		DECIMAL(16,2), 
	va_est_ado		CHAR(01), 
	va_ges_vta		INT, 
	va_cod_bod		INT,
	va_nom_bod		VARCHAR(40),
	va_cod_del		INT,
	va_nom_del		VARCHAR(30),
	va_por_cen		INT,
	va_mto_cal		DECIMAL(16,2)
   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 

--// Cursor sobre temporal
DECLARE vc_res001 CURSOR LOCAL FOR
	SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		   va_mon_vta,va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, va_cod_bod 
	  FROM res001
	 WHERE(va_cod_bod = @ar_cod_bod)	AND
		  (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
		  (va_cod_del = @ar_cod_del)	AND va_est_ado = 'V'

--** Abre cursor		  
OPEN vc_res001    
	 
FETCH NEXT FROM vc_res001 INTO @va_fec_vta, @va_ide_vta, @va_nro_vta, @va_cod_per, @va_raz_soc, @va_mon_vta, 
							   @va_tot_vtB, @va_tot_vtU, @va_est_ado, @va_ges_vta, @va_cod_bod 

WHILE (@@FETCH_STATUS = 0)
BEGIN
	--Obtiene nombre de Bodega
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @va_cod_bod
	 
	 --Obtiene nombre de Delivery
	SELECT @va_nom_del = va_nom_del,
		   @va_por_cen = va_por_del
	  FROM cmr015
	 WHERE va_cod_del = @ar_cod_del
	 
	 -- Calcula monto correspondiente al delivery segun su porcentaje
	 
	 SET @va_mto_cal = (@va_tot_vtB * @va_por_cen) / 100
	 
	 INSERT INTO #tm_res001 VALUES	(@va_fec_vta,
									@va_ide_vta	,
									@va_nro_vta	,
									@va_cod_per	,
									@va_raz_soc	,
									@va_mon_vta	,
									@va_tot_vtB	,
									@va_tot_vtU	,
									@va_est_ado	,
									@va_ges_vta	,
									@va_cod_bod	,
									@va_nom_bod	,
									@ar_cod_del	,
									@va_nom_del	,
									@va_por_cen	,
									@va_mto_cal
									)
	FETCH NEXT FROM vc_res001 INTO @va_fec_vta, @va_ide_vta, @va_nro_vta, @va_cod_per, @va_raz_soc, @va_mon_vta, 
							   @va_tot_vtB, @va_tot_vtU, @va_est_ado, @va_ges_vta, @va_cod_bod 

END	
CLOSE vc_res001
DEALLOCATE vc_res001

SELECT * FROM #tm_res001
ORDER BY va_fec_vta

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO