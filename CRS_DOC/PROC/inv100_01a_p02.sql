/*◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
ARCHIVO: inv100_01a_p02.sql
PROCEDIMIENTO: RETORNA STOCK A LA FECHA DE 1 PRODUCTO
	
AUTOR:	CREARSIS(chl)
FECHA:	11-12-2018 
--◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘*/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.inv100_01a_p02') and sysstat & 0xf = 4)
	drop procedure dbo.inv100_01a_p02
GO

CREATE PROCEDURE inv100_01a_p02	  @ar_cod_bod	CHAR(06),		-- Usuario registro
								  @ar_cod_pro	VARCHAR(15),	-- Codigo de la temporal 
								  @ar_fec_sal	DATE,
								  @rt_sal_stk	DECIMAL(16,4) OUTPUT	
							 WITH ENCRYPTION AS
--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON
DECLARE 
@msg			NVARCHAR(200),
@va_sal_stk		DECIMAL(16,4), 
@va_fec_sal		DATE

   
IF @@ERROR <> 0
   RETURN

SET @va_sal_stk = '0'
SET @va_fec_sal = '01/01/1990'

--// Obtiene saldo de Stock a la fecha
SET @rt_sal_stk  = 
(
SELECT  SUM(va_can_ing - va_can_egr) as va_sal_stk 
  FROM inv100
 WHERE va_cod_bod = @ar_cod_bod AND
	   va_cod_pro = @ar_cod_pro AND
	   va_fec_doc <= @ar_fec_sal
)

IF(@rt_sal_stk is null) 
BEGIN
	SET @rt_sal_stk = 0
END

GO