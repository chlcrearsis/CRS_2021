/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr002_05b_p01.sql
PROCEDIMIENTO: CONSULTA PRECIO EN VARIAS LISTAS
	
AUTOR:	CREARSIS(CHL)
FECHA:	21-01-2021 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr002_05b_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr002_05b_p01
GO

CREATE PROCEDURE cmr002_05b_p01	@ar_cod_pro		VARCHAR(15),
								@ar_lis_ini		INT,
								@ar_lis_fin		INT WITH ENCRYPTION AS
							
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200)	,	-- Mensaje
@va_cod_pro		VARCHAR(15)		,	-- Codigo producto
@va_nom_pro		VARCHAR(80)		,	-- Nombre producto
@va_cod_umd		CHAR(03)		,	-- Unidad de medida
@va_und_vta		CHAR(03)		,	-- Unidad de medida de venta
@va_cod_lis		INT				,	-- Codigo/Numero de lista de precio  
@va_nom_lis		VARCHAR(30)		,	-- Nombre de lista de precio
@va_mon_lis		CHAR(01)		,	-- Moneda de lista de precio
@va_pre_cio		DECIMAL(10,5)	,	-- Precio
@va_pmx_des		DECIMAL(4,2)	,	-- Porcentaje maximo de descuento
@va_pmx_inc		DECIMAL(4,2)		-- Porcentaje maximo de incremento

CREATE TABLE #CMR002
(
va_cod_pro		VARCHAR(15)		,	-- Codigo de producto
va_nom_pro		VARCHAR(80)		,	-- Nombre de producto
va_cod_umd		CHAR(03)		,	-- Unidad de medida
va_und_vta		CHAR(03)		,	-- Unidad de venta
va_cod_lis		INT				,	-- Numero de lista de precio
va_nom_lis		VARCHAR(30)		,	-- Nombre de lista de precio				
va_mon_lis		VARCHAR(30)		,	-- Moneda de lista de precio
va_pre_cio		DECIMAL(10,5)	,	-- Precio
va_pmx_des		DECIMAL(10,5)	,	-- Porcentaje maximo de descuento
va_pmx_inc		DECIMAL(10,5)		-- Porcentaje maximo de incremento				
)

IF @@ERROR <> 0
   RETURN
   
BEGIN TRY 

DECLARE vc_pre_cio CURSOR LOCAL FOR
select inv004.va_cod_pro, inv004.va_nom_pro, inv004.va_cod_umd, inv004.va_und_vta,
	   cmr002.va_cod_lis, cmr002.va_pre_cio, cmr002.va_pmx_des, cmr002.va_pmx_inc
	from inv004 , cmr002
	where (inv004.va_cod_pro = cmr002.va_cod_pro)	AND
		  (inv004.va_cod_pro = @ar_cod_pro)			AND
		  (cmr002.va_cod_lis BETWEEN @ar_lis_ini AND @ar_lis_fin)	
		  	
--** Abre cursor		  
OPEN vc_pre_cio    
	 
FETCH NEXT FROM vc_pre_cio INTO @va_cod_pro, @va_nom_pro, @va_cod_umd, @va_und_vta,
								@va_cod_lis, @va_pre_cio, @va_pmx_des, @va_pmx_inc

WHILE (@@FETCH_STATUS = 0)
BEGIN
	-- Obtiene nombre de lista de precio
	SELECT @va_nom_lis = va_nom_lis, @va_mon_lis = va_mon_lis
	  FROM cmr001
	 WHERE va_cod_lis = @va_cod_lis
	 
	 INSERT INTO #CMR002 VALUES (@va_cod_pro, @va_nom_pro, @va_cod_umd, @va_und_vta,
								@va_cod_lis,@va_nom_lis,@va_mon_lis, @va_pre_cio, @va_pmx_des, @va_pmx_inc)
	


	FETCH NEXT FROM vc_pre_cio INTO @va_cod_pro, @va_nom_pro, @va_cod_umd, @va_und_vta,
									@va_cod_lis, @va_pre_cio, @va_pmx_des, @va_pmx_inc	
END	

CLOSE vc_pre_cio
DEALLOCATE vc_pre_cio

SELECT *
FROM #CMR002

RETURN

END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
    --Rollback TRAN TR_inv100
	RETURN
END CATCH	   

GO