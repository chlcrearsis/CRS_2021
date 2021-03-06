/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: ads004_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE DOCUMENTOS
	
AUTOR:	CREARSIS(CHL)
FECHA:	25-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.ads004_R01') and sysstat & 0xf = 4)
	drop procedure dbo.ads004_R01
GO

CREATE PROCEDURE ads004_R01	@ar_ide_mod		INT,
							@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_est_ado		CHAR(01),
@va_ide_doc		CHAR(03),	--Ide Documento
@va_nro_tal		INT,						--Nro de Talonario
@va_nom_tal		VARCHAR(60),	--Nombre Talonario
@va_tip_tal		INT						,	--Tipo de talonario  
@va_nro_aut		DECIMAL(15,0)	,	-- Numero de autorizacion
@va_for_mat		INT				,	-- Formato de impresion
@va_nro_cop		INT				,	-- Nro de copias a imprimir
@va_fir_ma1		VARCHAR(30)		,	-- Firma nro 1
@va_fir_ma2		VARCHAR(30)		,	-- Firma nro 1
@va_fir_ma3		VARCHAR(30)		,	-- Firma nro 1
@va_fir_ma4		VARCHAR(30)		,	-- Firma nro 1
@va_for_log		INT,
@va_nom_mod		VARCHAR(30)				


CREATE TABLE #ADS004
(
va_ide_mod		INT,
va_nom_mod		VARCHAR(30),
va_ide_doc		CHAR(03),	--Ide Documento
va_nro_tal		INT,						--Nro de Talonario
va_nom_tal		VARCHAR(60),	--Nombre Talonario
va_tip_tal		INT						,	--Tipo de talonario  
va_nro_aut		DECIMAL(15,0)	,	-- Numero de autorizacion
va_for_mat		INT				,	-- Formato de impresion
va_nro_cop		INT				,	-- Nro de copias a imprimir
va_fir_ma1		VARCHAR(30)		,	-- Firma nro 1
va_fir_ma2		VARCHAR(30)		,	-- Firma nro 1
va_fir_ma3		VARCHAR(30)		,	-- Firma nro 1
va_fir_ma4		VARCHAR(30)		,	-- Firma nro 1
va_for_log		INT,
va_est_ado		CHAR(01)				
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 




--/ Inicializa variable contador de registro
IF(@ar_est_ado = 'T')
	SET @va_est_ado = '%'
IF(@ar_est_ado <> 'T')
	SET @va_est_ado = @ar_est_ado
	
	
DECLARE vc_tal_ona CURSOR LOCAL FOR
SELECT ads004.va_ide_doc, ads004.va_nro_tal, ads004.va_nom_tal, ads004.va_tip_tal, ads004.va_nro_aut,
	   ads004.va_for_mat, ads004.va_nro_cop, ads004.va_fir_ma1 , ads004.va_fir_ma2, ads004.va_fir_ma3,
	   ads004.va_fir_ma4, ads004.va_for_log, ads004.va_est_ado
FROM ads004, ads003
WHERE (ads004. va_ide_doc = ads003.va_ide_doc)
  AND (ads003.va_ide_mod = @ar_ide_mod)
  AND (ads004.va_est_ado like @va_est_ado )
	
--** Abre cursor		  
OPEN vc_tal_ona    
	 
FETCH NEXT FROM vc_tal_ona INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_tip_tal , @va_nro_aut, @va_for_mat,@va_nro_cop,
								@va_fir_ma1, @va_fir_ma2, @va_fir_ma3,@va_fir_ma4,@va_for_log,@va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del modulo
	SELECT @va_nom_mod = va_nom_mod
	  FROM ads001
	 WHERE va_ide_mod = @ar_ide_mod
	 
	 INSERT INTO #ADS004 VALUES (@ar_ide_mod, @va_nom_mod,@va_ide_doc,@va_nro_tal,@va_nom_tal,
								 @va_tip_tal,@va_nro_aut,@va_for_mat,@va_nro_cop,
								 @va_fir_ma1,@va_fir_ma2,@va_fir_ma3,@va_fir_ma4,@va_for_log,@va_est_ado)
	


	FETCH NEXT FROM vc_tal_ona INTO @va_ide_doc, @va_nro_tal, @va_nom_tal, @va_tip_tal , @va_nro_aut, @va_for_mat,@va_nro_cop,
								@va_fir_ma1, @va_fir_ma2, @va_fir_ma3,@va_fir_ma4,@va_for_log,@va_est_ado	
END	

CLOSE vc_tal_ona
DEALLOCATE vc_tal_ona

SELECT *
FROM #ADS004

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO