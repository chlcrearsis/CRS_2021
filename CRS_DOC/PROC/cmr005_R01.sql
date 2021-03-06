/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr005_R01.sql
PROCEDIMIENTO: REPORTE LISTADO DE VENTAS
AUTOR:	CREARSIS(chl)
FECHA:	27-01-2019 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr005_R01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr005_R01
GO

CREATE PROCEDURE cmr005_R01 @ar_cod_bod INT,			-- Almacen
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_est_ado CHAR(01),		-- Estado (T=todos ; H=valido ; N=anulado)
							@ar_tip_doc	INT				-- Tipo de documento (0=Ambos; 1=Factura; 2=Nota de Venta)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_cli_ini		INT,
@va_cli_fin		INT,
@va_bod_ini		INT,
@va_bod_fin		INT,
@va_nom_bod		VARCHAR(50)
--** CREA TABLA TEMPORAL
--CREATE TABLE #tm_vta005(
--	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
--	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
--	va_nro_itm		INT				not null,	--Numero de item 
--	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
--	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
--	va_und_vta		char(3)			null,		--Codigo de la Unidad de Medida
--	va_can_vta		DECIMAL(14,4),				--Cantidad de producto
--	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
--	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
--	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
--   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
SET @va_nom_bod = 'Todos';

IF (@ar_cod_bod = 0)
BEGIN	
	SET @va_bod_ini = 0
	SET @va_bod_fin = 9999999
END
IF (@ar_cod_bod <> 0)
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
	
	--Obtiene nombre de almacen
	SELECT @va_nom_bod = va_nom_bod
	  FROM inv002
	 WHERE va_cod_bod = @ar_cod_bod 
	
END

IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'



IF (@ar_tip_doc = 0)
BEGIN 
 SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, 
		@ar_cod_bod as va_cod_bod, @va_nom_bod as va_nom_bod, va_obs_vta
 FROM cmr005
 WHERE (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
  	   (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	    va_est_ado LIKE @ar_est_ado  
END
IF (@ar_tip_doc <> 0)
BEGIN 
 SELECT va_fec_vta, va_ide_vta, va_nro_vta, va_cod_per, va_raz_soc, 
		va_mon_vta, va_tot_vtB, va_tot_vtU, va_est_ado, va_ges_vta, 
		@ar_cod_bod as va_cod_bod, @va_nom_bod as va_nom_bod, va_obs_vta
 FROM cmr005
 WHERE (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
  	   (va_fec_vta BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	   (va_tip_vta = @ar_tip_doc) AND
	    va_est_ado LIKE @ar_est_ado  
END
	
	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO