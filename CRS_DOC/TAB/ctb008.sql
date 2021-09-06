 /**********************************************************/
     /* SCRIPT : ctb008.sql								*/
     /* Crea la Tabla "debito fiscal"									*/
     /* Autor :  CREARSIS - CHL									*/
     /**********************************************************/
--use BD_Rest

go
     PRINT '08.- Creando la tabla : Debito Fiscal'
	
     CREATE TABLE ctb008 (
       --** Llave Primaria
      va_ges_tio		INT     			NOT NULL,	--** Gestion del documento
	  va_per_ges		INT					NOT NULL,	--** Periodo de la gestion
	  va_ide_fac		NVARCHAR(30)		NOT NULL,	--** IDE de la venta concatena(XXX-000-000000-0000) 
      va_nro_fac	    INT					NOT NULL,	--** Numero de factura
     
      --** Atributos     
      va_nro_dos		NVARCHAR(20)		NOT NULL,	--** Numero de dosificacion/autorizacion
      va_nit_per		DECIMAL(15,0)		NOT NULL,	--** Nit de la persona
      va_raz_soc		NVARCHAR(120)		NOT NULL,	--** Razon social de la persona
      
      va_mto_fac		DECIMAL(16,4)		NOT NULL,	--** Monto total de la factura
      va_dto_fac		DECIMAL(16,4) 		NOT NULL,	--** Monto de descuento de la factura
      va_net_fac		DECIMAL(16,4)		NOT NULL,	--** Monto neto de la factura (de aca se saca el 13%)
      va_mto_iva		DECIMAL(16,4)		NOT NULL,	--** (va_net_fac * 0.13) iva=13%
      va_cod_con		NVARCHAR(20)		NOT NULL,	--** Codigo de control
      va_fec_fac		DATE				NOT NULL,	--** Fecha de la factura
      va_fec_reg		DATETIME			NOT NULL,   --** Fecha en que realmente fue registrado		
      va_img_qrf		VARBINARY(MAX)		NULL,	--** Guarda la imagen del qr de la factura
      
      CONSTRAINT pk1_ctb008 PRIMARY KEY(va_ges_tio,va_per_ges,va_ide_fac,va_nro_fac)
     )
     GO
     
     