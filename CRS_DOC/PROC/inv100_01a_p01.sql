/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv100_01a_p01.sql
PROCEDIMIENTO: OBTIENE STOCK A LA FECHA DE 1 PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	11-12-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv100_01a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.inv100_01a_p01
GO

CREATE PROCEDURE inv100_01a_p01 @ar_cod_bod	CHAR(06),		-- Usuario registro
							 @ar_cod_pro	VARCHAR(15),	-- Codigo de la temporal 
							 @ar_fec_sal	DATE		
							 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			NVARCHAR(200),
@va_sal_stk		DECIMAL(16,4)


--** CREA TABLA TEMPORAL
--CREATE TABLE #tm_INV100(
--	va_cod_bod		SMALLINT		NOT NULL,	--Codigo del usuario
--	va_cod_pro		VARCHAR(15)		NOT NULL,	--Codigo Producto
--	va_sal_stk		DECIMAL(16,4)	NOT NULL,	--Saldo de stock a la fecha
--	va_fec_sal		DATE			NOT NULL,	--Fecha del saldo de stock
--	va_sal_ant		DECIMAL(16,4)	NOT NULL,	--Saldo anterior a la fecha
--	va_fec_ant		DATE			NOT NULL	--Fecha del saldo de stock
--   )
   
IF @@ERROR <> 0
   RETURN

SET @va_sal_stk = '0'


--// Obtiene saldo de Stock a la fecha
SET @va_sal_stk  = 
(
SELECT  SUM(va_can_ing - va_can_egr) 
  FROM inv100
 WHERE va_cod_bod = @ar_cod_bod AND
	   va_cod_pro = @ar_cod_pro AND
	   va_fec_doc <= @ar_fec_sal
)

IF(@va_sal_stk is null) 
BEGIN
	SET @va_sal_stk = 0
END

SELECT @va_sal_stk AS va_sal_stk, @ar_fec_sal AS va_fec_sal

GO