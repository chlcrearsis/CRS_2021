/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: cmr007_01a_p01.sql
PROCEDIMIENTO: PROCEDIMIENTO BUSCA PEDIDOS
AUTOR:	CREARSIS(chl)
FECHA:	19-01-2019
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr007_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr007_01a_p01
GO

CREATE PROCEDURE cmr007_01a_p01 @ar_cod_cli INT,			-- codigo cliente
							@ar_cod_bod CHAR(06),			-- Almacen
							@ar_fec_ini DATE,				-- Fecha de inicial
							@ar_fec_fin DATE,				-- Fecha de final
							@ar_tex_bus NVARCHAR(200),		-- Texto a buscar
							@ar_par_bus INT,				-- parametro Busqueda (0=Razon Social pedido; 1 = Observaciones)
							@ar_est_ado CHAR(01)			-- Estado (T=todos ; H=valido ; N=anulado)
							--@ar_tip_doc CHAR(01)			-- Tipo documento (V=pedido; C=Cotizacion; F=Factura)
							WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

DECLARE 
@msg			nvarchar(200),
@va_cli_ini		INT,
@va_cli_fin		INT,
@va_bod_ini		CHAR(06),
@va_bod_fin		CHAR(06)

IF @@ERROR <> 0
   RETURN


BEGIN TRY	 
 
 PRINT @ar_cod_bod
IF (@ar_cod_bod = '0')
BEGIN	
	SET @va_bod_ini = '0'
	SET @va_bod_fin = '99-999'
END
IF (@ar_cod_bod <> '0')
BEGIN	
	SET @va_bod_ini = @ar_cod_bod
	SET @va_bod_fin = @ar_cod_bod
END


IF (@ar_cod_cli = 0)
BEGIN	

	SET @va_cli_ini = 0
	SET @va_cli_fin = 9999999
END
IF (@ar_cod_cli <> 0)
BEGIN	
	SET @va_cli_ini = @ar_cod_cli
	SET @va_cli_fin = @ar_cod_cli
END



IF (@ar_est_ado = 'T')
	SET @ar_est_ado = '%'


	IF(@ar_par_bus = 0)	 -- Busca por Razon Social pedido
	BEGIN
		 SELECT va_fec_ped,va_doc_ped, va_ide_ped, va_nro_ped, va_cod_per, va_raz_soc, 
				va_mon_ped, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_ped, va_ges_ped
		 FROM cmr007
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_ped BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			   va_raz_soc  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	IF(@ar_par_bus = 1)	 -- Busca por Observacion pedido
	BEGIN
		 SELECT va_fec_ped,va_doc_ped, va_ide_ped, va_nro_ped, va_cod_per, va_raz_soc, 
				va_mon_ped, va_tot_vtB, va_tot_vtU, va_est_ado, va_obs_ped, va_ges_ped
		 FROM cmr007
		WHERE (va_cod_per BETWEEN @va_cli_ini AND @va_cli_fin) AND
			  (va_cod_bod BETWEEN @va_bod_ini AND @va_bod_fin) AND
			  (va_fec_ped BETWEEN @ar_fec_ini AND @ar_fec_fin) AND
			   va_obs_ped  LIKE @ar_tex_bus + '%'	AND
			   va_est_ado LIKE @ar_est_ado  
	END
	


END TRY
BEGIN CATCH
	
	SET @msg = 'Error: ' + ERROR_MESSAGE() + ' (línea ' + CONVERT(NVARCHAR(255), ERROR_LINE() ) + ').'
	RAISERROR(@msg,16,1)
	RETURN
END CATCH	

GO