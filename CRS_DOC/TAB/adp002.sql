/*--**********************************************
ARCHIVO:	adp002.sql	
TABLA:		Tabla de "Persona"
AUTOR:		CREARSIS 3.0.0 (LEO)
FECHA:		03-01-2018
*/--**********************************************
	 
CREATE TABLE adp002 
(
--** Llave Primaria
va_cod_per		INT				NOT NULL	DEFAULT(0),			--** Codigo Persona (2 de Grup. Per y 5 de Persona)

--** Llave Secundaria
va_cod_gru		TINYINT				NOT NULL	DEFAULT(0),		--** Cod Grupo Persona
																
--** Atributos
va_raz_soc		VARCHAR(120)	NOT NULL	DEFAULT(''),		--** Razon social de la persona
va_nom_com		VARCHAR(100)	NOT NULL	DEFAULT(''),		--** Nombre comercial de la persona
	      	  
va_nit_per		BIGINT,											--** Nit de la persona
va_car_net		BIGINT,											--** Carnet de la persona
va_dir_per		VARCHAR(80)	    NOT NULL	DEFAULT(''),		--** Direccion de la persona
va_tel_per		VARCHAR(15)				    DEFAULT(''),		--// Telefono de la persona
va_cel_per		VARCHAR(15)				    DEFAULT(''),		--// Celular de la persona
va_ema_per		VARCHAR(30)				    DEFAULT(''),		--// Email de la persona
va_ubi_gps		GEOGRAPHY								,		--// uBICACION GEOGRAFICA DEL CLIENTE
-- Llaves FOraneas
va_cod_lpr		INT							DEFAULT(0),			--// Codigo de lista de precio(8 numeros)
va_cod_ven		SMALLINT					DEFAULT(0),			--// Codigo de Vendedor asociado(4 numeros)
	   	    	  	   		
va_est_ado		CHAR(1)			NOT NULL	DEFAULT(''),		--** Estado(H=Habilitado; N=Deshabilitado)
     
CONSTRAINT pk1_adp002 PRIMARY KEY(va_cod_per,va_cod_gru)
  
)
GO
         