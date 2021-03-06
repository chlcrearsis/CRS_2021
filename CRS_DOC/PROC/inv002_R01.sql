/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv002_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE BODEGAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	25-05-2020 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv002_R01') and sysstat & 0xf = 4)
	drop procedure dbo.inv002_R01
GO

CREATE PROCEDURE inv002_R01	@ar_ide_gr1	INT,
							@ar_ide_gr2	INT,
							@ar_est_ado		CHAR(01)
							WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),

@va_ide_gru		INT,				-- Ide Documento
@va_nom_gru		CHAR(30),			-- Nombre de grupo
@va_cod_bod		CHAR(06),			-- Codigo Bodega
@va_nom_bod		VARCHAR(40),		-- Nombre Talonario
@va_des_bod		VARCHAR(160),		-- Nombre Talonario
@va_dir_bod		VARCHAR(200),		-- Nombre Talonario
@va_fec_ctr		DATETIME		,	-- Fecha de Control
@va_mon_inv		CHAR(01)	,	-- Numero de autorizacion

@va_mtd_cto		CHAR(01),/* Metodo de costeo 
												P=Promedio Ponderado (Solo usaremos este inicialmente) 
												C=UEPS (Ultimos en Entrar, Primeros en Salir)
												A=PEPS (Primeros en Entrar Primeros en Salir)*/
	 
@va_nom_ecg		VARCHAR(120)	,--Nombre del encargado del almacen
@va_tlf_ecg		VARCHAR(10),				--Telefono del encargado
@va_dir_ecg		VARCHAR(200),				--Direccion del encargado
@va_est_ado		CHAR(01)		--Estado del almacen
			

CREATE TABLE #inv002
(
va_ide_gru		INT,				-- Ide Documento
va_nom_gru		CHAR(30),			-- Nombre de grupo
va_cod_bod		CHAR(06),			-- Codigo Bodega
va_nom_bod		VARCHAR(40),		-- Nombre Talonario
va_des_bod		VARCHAR(160),		-- Nombre Talonario
va_dir_bod		VARCHAR(200),		-- Nombre Talonario
va_fec_ctr		DATETIME		,	-- Fecha de Control
va_mon_inv		CHAR(01)	,	-- Numero de autorizacion

va_mtd_cto		CHAR(01)		NOT NULL,	/* Metodo de costeo 
												P=Promedio Ponderado (Solo usaremos este inicialmente) 
												C=UEPS (Ultimos en Entrar, Primeros en Salir)
												A=PEPS (Primeros en Entrar Primeros en Salir)*/

	 
va_nom_ecg		VARCHAR(120)	NOT NULL,	--Nombre del encargado del almacen
va_tlf_ecg		VARCHAR(10),				--Telefono del encargado
va_dir_ecg		VARCHAR(200),				--Direccion del encargado
va_est_ado		CHAR(01)		NOT NULL	--Estado del almacen
				
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 


--/ Inicializa variable contador de registro
IF(@ar_est_ado = 'T')
	SET @va_est_ado = '%'
IF(@ar_est_ado <> 'T')
	SET @va_est_ado = @ar_est_ado
	
	
DECLARE vc_bod_ega CURSOR LOCAL FOR
SELECT inv002.va_ide_gru, inv002.va_cod_bod, inv002.va_nom_bod, inv002.va_des_bod, inv002.va_dir_bod,
	   inv002.va_fec_ctr,inv002.va_mon_inv, inv002.va_mtd_cto, inv002.va_nom_ecg , inv002.va_tlf_ecg, inv002.va_dir_ecg,
	   inv002.va_est_ado
FROM inv002, inv001
WHERE (inv002. va_ide_gru = inv001.va_ide_gru)
  AND (inv001.va_ide_gru BETWEEN @ar_ide_gr1 and @ar_ide_gr2)
  AND (inv002.va_est_ado like @va_est_ado )
	
--** Abre cursor		  
OPEN vc_bod_ega    
	 
FETCH NEXT FROM vc_bod_ega INTO @va_ide_gru, @va_cod_bod, @va_nom_bod, @va_des_bod, @va_dir_bod,
	   @va_fec_ctr,@va_mon_inv, @va_mtd_cto, @va_nom_ecg , @va_tlf_ecg, @va_dir_ecg,@va_est_ado

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre del nom_gru 1
	SELECT @va_nom_gru = va_nom_gru
	  FROM inv001
	 WHERE va_ide_gru = @va_ide_gru
	 
	 INSERT INTO #inv002 VALUES (@va_ide_gru,@va_nom_gru, @va_cod_bod, @va_nom_bod, @va_des_bod, @va_dir_bod,
						   @va_fec_ctr,@va_mon_inv, @va_mtd_cto, @va_nom_ecg , @va_tlf_ecg, @va_dir_ecg,
						   @va_est_ado)
	


		FETCH NEXT FROM vc_bod_ega INTO @va_ide_gru, @va_cod_bod, @va_nom_bod, @va_des_bod, @va_dir_bod,
		   @va_fec_ctr,@va_mon_inv, @va_mtd_cto, @va_nom_ecg , @va_tlf_ecg, @va_dir_ecg,
	   @va_est_ado
END	

CLOSE vc_bod_ega
DEALLOCATE vc_bod_ega

SELECT *
FROM #inv002

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO