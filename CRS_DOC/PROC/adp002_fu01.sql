/**************************************************************************/
/*  FUNCION : adp002_fu01 (FUNCIÓN QUE DEVUELVE ATRIBUTOS DEL CLIENTE)    */
/*                  Devuelve paramtros del Usuario Movil                  */
/*  ARGUMENTOS    : @ar_tip_atr  VARCHAR(MAX),	--** Tipo de Atributo     */
/*                  @ar_atr_sel  VARCHAR(MAX),	--** Atributo Seleccionao */
/*                  @ar_car_sep  VARCHAR(10))  --** Caracter Separador    */
/*  AUTOR         : CREARSIS - JEJR	                                      */
/**************************************************************************/

/* Verifica si la funcion se encuentra creado */
if exists (select * from sys.objects where type IN (N'TF') and name = 'adp002_fu01')
	drop function dbo.adp002_fu01
GO

CREATE FUNCTION adp002_fu01 (@ar_tip_atr  VARCHAR(MAX),	--** Array Tipo de Atributo
                             @ar_atr_sel  VARCHAR(MAX),	--** Array Atributo Seleccionao
                             @ar_car_sep  VARCHAR(10))  --** Caracter Separador
        --** Tabla a Retornar
		RETURNS @tb_atr_cli TABLE (va_ide_tip INT NOT NULL,
                                   va_ide_atr INT NOT NULL) AS
BEGIN
   DECLARE @va_pri_tip  INT = 1,	--** Primera Posicion Tipo Atributo
           @va_pri_atr  INT = 1,    --** Primera Posicion Atributo
           @va_sig_tip  INT = 1,    --** Siguiente Posicion Tipo Atributo
		   @va_sig_atr  INT = 1,    --** Siguiente Posicion Atributo
           @va_len_sep  INT = 1,    --** Longitud del caracter separador
		   @va_ult_pos  INT = 0,    --** Ultima Posicion del caracter a obtener
           @va_ide_tip  INT = 0,    --** ID. Tipo Atributo
		   @va_ide_atr  INT = 0     --** ID. Atributo         

   WHILE (@va_sig_tip > 0)
   BEGIN
	  --** Obtiene las posiciones para obtener el tipo de atributo
      SET @va_sig_tip = CHARINDEX(@ar_car_sep COLLATE Czech_BIN2, @ar_tip_atr, @va_pri_tip)
      SET @va_ult_pos = CASE WHEN @va_sig_tip > 0 THEN @va_sig_tip
                             ELSE LEN(@ar_tip_atr) + 1
                        END - @va_pri_tip

      --** Obtiene el caracter del tipo de atributo
      SET @va_ide_tip = CONVERT(INT, LTRIM(RTRIM(SUBSTRING(@ar_tip_atr, @va_pri_tip, @va_ult_pos))))


	  --** Obtiene las posiciones y caracter para obtener el atributo seleccionado
      SET @va_sig_atr = CHARINDEX(@ar_car_sep COLLATE Czech_BIN2, @ar_atr_sel, @va_pri_atr)
      SET @va_ult_pos = CASE WHEN @va_sig_atr > 0 THEN @va_sig_atr
                             ELSE LEN(@ar_atr_sel) + 1
                        END - @va_pri_atr

      --** Obtiene el caracter del atributo
      SET @va_ide_atr = CONVERT(INT, LTRIM(RTRIM(SUBSTRING(@ar_atr_sel, @va_pri_atr, @va_ult_pos))))

	  --** Iserta datos en la tabla temporal
      INSERT INTO @tb_atr_cli VALUES (@va_ide_tip, @va_ide_atr)

	  --** Obtiene el primera posicion del siguiente caracter
      SET @va_pri_tip = @va_sig_tip + @va_len_sep
	  SET @va_pri_atr = @va_sig_atr + @va_len_sep
   END

   --** Retorna Tabla
   RETURN
END
