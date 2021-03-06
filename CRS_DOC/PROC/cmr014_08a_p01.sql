/*****************************************************************/
/*	ARCHIVO: cmr014_08a_p01.sql                                  */
/*	PROCEDIMIENTO: OBTIENE LISTA DE USUARIO ASIG. P/VENDEDOR     */
/*	AUTOR:	CREARSIS(JEJR)        FECHA : 20/10/2021             */
/*   NOTA: En caso de error devuelve del 101 as 118              */
/*****************************************************************/

/* Verifica si el procedimiento se encuentra creado */
if exists (select * from sysobjects where id = object_id('dbo.cmr014_08a_p01') and sysstat & 0xf = 4)
	drop procedure dbo.cmr014_08a_p01
GO

CREATE PROCEDURE cmr014_08a_p01		@ar_ide_tip  INT,	--** Tipo (1=Vendedor; 2=Cobrador)
                                    @ar_cod_ide  INT    --** Código Vendedor/Cobrador
									WITH ENCRYPTION AS

DECLARE		@va_nro_reg  INT,		   --** Nro de Registro
            @va_ide_usr  VARCHAR(15),  --** ID. Usuario
			@va_nom_usr  VARCHAR(30),  --** Nombre Usuario
			@va_tip_usr	 INT,          --** Tipo de usuario
			@va_nom_tip	 VARCHAR(30),  --** Nombre tipo usuario
			@va_per_mis  CHAR(01)      --** Permiso S=Si; N=No

--** Inhabilita mensajes numero de filas afectadas
SET NOCOUNT ON

CREATE TABLE #tm_per_mis
(
	va_ide_usr  VARCHAR(15),
	va_nom_usr  VARCHAR(30),
	va_tip_usr	INT,        
	va_nom_tip	VARCHAR(30),
	va_per_mis  CHAR(01)    
)

--** Graba los atributos seleccionado del usuario
DECLARE vc_lis_usr CURSOR LOCAL FOR
SELECT va_ide_usr, va_nom_usr, va_tip_usr 
  FROM ads007
 WHERE va_est_ado = 'H'

--** Abre cursor
OPEN vc_lis_usr

--** Lee primer registro
FETCH NEXT FROM vc_lis_usr INTO @va_ide_usr, @va_nom_usr, @va_tip_usr

WHILE (@@FETCH_STATUS = 0)
BEGIN	

	--** Obtiene el nombre del tipo de usuario
	SELECT @va_nom_tip = ISNULL(va_nom_tus, '')
	  FROM ads006
	 WHERE va_ide_tus = @va_tip_usr

	--** Verifica si el usuario tiene habilitado al vendedor
	SET @va_nro_reg = 0
	SELECT @va_nro_reg = COUNT (*)
	  FROM ads008
	 WHERE va_ide_usr = @va_ide_usr
	   AND va_ide_tab = 'cmr014'
	   AND va_ide_uno = @ar_ide_tip
	   AND va_ide_dos = @ar_cod_ide

	IF (@va_nro_reg = 0)
		SET @va_per_mis = 'N'
	ELSE
		SET @va_per_mis = 'S'


	--** Graba el atributo de persona
	INSERT INTO #tm_per_mis VALUES (@va_ide_usr, @va_nom_usr, @va_tip_usr, @va_nom_tip, @va_per_mis)


	FETCH NEXT FROM vc_lis_usr INTO @va_ide_usr, @va_nom_usr, @va_tip_usr
END

--** Cierre y destruya cursor
CLOSE vc_lis_usr
DEALLOCATE vc_lis_usr

--** Devuelve datos
SELECT va_ide_usr, va_nom_usr, va_tip_usr, va_nom_tip, va_per_mis 
  FROM #tm_per_mis


