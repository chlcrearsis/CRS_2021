/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv007_01a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO BUSCA COMPRA
AUTOR:	CREARSIS(chl)
FECHA:	20-09-20120
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv007_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv007_01a_p01
GO

CREATE PROCEDURE inv007_01a_p01 @ar_cod_prv INT,		-- codigo Proveedor
							@ar_cod_bod INT,			-- Almacen
							@ar_fec_ini DATE,			-- Fecha de inicial
							@ar_fec_fin DATE,			-- Fecha de final
							@ar_obs_cmp NVARCHAR(200),  -- Observacion
							@ar_est_ado CHAR(01)		-- Estado (T=todos ; H=valido ; N=anulado)
							
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_prv_ini		INT,
@va_prv_fin		INT,
@va_bod_ini		INT,
@va_bod_fin		INT

--** CREA TABLA TEMPORAL
--CREATE TABLE #tm_inv007(
--	va_cod_usr		VARCHAR(15)		NOT NULL,	--Codigo del usuario
--	va_cod_tmp		DATETIME		NOT NULL,	--Codigo temporal (fecha y hora)
--	va_nro_itm		INT				not null,	--Numero de item 
--	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
--	va_des_pro		varchar(80)		not null,	--Descripcion del Producto 
--	va_und_cmp		char(3)			null,		--Codigo de la Unidad de Medida
--	va_can_cmp		DECIMAL(14,4),				--Cantidad de producto
--	va_pre_uni		DECIMAL(14,4),				--Precio Unitario en la moneda del documento
--	va_imp_tot		DECIMAL(16,2),				--Importe Total en la moneda del documento
--	va_tip_fam		CHAR(01)					--Tipo de familia a la que corresponde el producto 
--   )
   
IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
 
IF (@ar_cod_bod = 0)
BEGIN	
	SET @va_bod_ini = 0
	SET @va_bod_fin = 99999
END
IF (@ar_cod_bod <> 0)
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
END
PRINT @ar_cod_bod

IF (@ar_cod_prv = 0)
BEGIN	

	SET @va_prv_ini = 0
	SET @va_prv_fin = 999999
END
IF (@ar_cod_prv <> 0)
BEGIN	

	SET @va_prv_ini = @ar_cod_prv
	SET @va_prv_fin = @ar_cod_prv
END
PRINT @ar_cod_prv

IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'



 SELECT va_fec_cmp, va_ide_cmp, va_nro_cmp, va_cod_per, va_raz_soc, 
		va_mon_cmp, va_tot_nBs, va_tot_nUs, va_est_ado, va_obs_cmp, va_ges_cmp
 FROM inv007
WHERE (va_cod_per BETWEEN @va_prv_ini AND @va_prv_fin) AND
	  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin)  AND
	  (va_fec_cmp BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
	   va_obs_cmp  LIKE @ar_obs_cmp + '%'	AND
	   va_est_ado LIKE @ar_est_ado  
	

	
END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO