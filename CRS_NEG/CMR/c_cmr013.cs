using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

using Microsoft.SqlServer.Types;

namespace CRS_NEG.CMR
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase Persona
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_cmr013
    {
        //######################################################################
        //##       Tabla: cmr013                                              ##
        //##      Nombre: PERSONAS                                            ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        StringBuilder cadena;

        DataTable tabla = new DataTable();


        public c_cmr013()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }


        /// <summary>
        /// Funcion "Buscar PERSONAS"
        /// </summary>
        /// <param name="val_bus">Valor de la busqued</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo ; 2=Raz Soc;3=nombre Comercial; 4=NIT/CI )</param>
        /// <param name="est_bus">Estado del persona (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )(</param>
        /// <param name="con_bus">Condición de Búsqueda 0=LIKE(%); 1=IGUAL(=)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string val_bus, int prm_bus, string est_bus, int gru_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" cmr013_01a_p01  ");
                cadena.AppendFormat("{0},", gru_per);  
                cadena.AppendFormat("'{0}',", val_bus);  
                cadena.AppendFormat("{0},", prm_bus); 
                cadena.AppendFormat("'{0}'", est_bus);  
              
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Registrar "PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo Persona (2 de Grup. Per y 5 de Persona)</param>
        /// <param name="nro_per">Nro. de Persona (5 digitos)</param>
        /// <param name="cod_gru">Cod Grupo Persona</param>
        /// <param name="raz_soc">Razon social de la persona</param>
        /// <param name="nom_com">Nombre comercial de la persona</param>
        /// <param name="nit_per">Nit/Cedula de la persona</param>
        /// <param name="dir_per">Direccion de la persona</param>
        /// <param name="tel_per">Telefono de la persona</param>
        /// <param name="cel_per">Celular de la persona</param>
        /// <param name="ema_per">Email de la persona</param>
        /// <param name="cod_lpr">Codigo de lista de precio</param>
        /// <param name="cod_ven">Codigo de Vendedor asociado</param>
        /// <param name="ban_ven">Bandera si identifica persona como cliente</param>
        /// <param name="ban_com">Bandera si identifica persona como proveedor</param>
        /// <returns></returns>
        public void Fe_crea(int cod_per, int cod_gru, string raz_soc, string nom_com, decimal nit_per, int car_net, string dir_per,
                            string tel_per, string cel_per, string ema_per, SqlGeography ubi_gps, int cod_lpr, int cod_ven)
        {
            try
            {

                cadena = new StringBuilder();
                cadena.AppendLine(" INSERT INTO cmr013 VALUES ");
                cadena.AppendFormat("({0},{1},'{2}','{3}',", cod_per,  cod_gru, raz_soc, nom_com);
                cadena.AppendFormat(" '{0}',{1},'{2}','{3}','{4}','{5}',", nit_per,car_net, dir_per, tel_per, cel_per, ema_per);

                cadena.AppendFormat("'{0}','{1}','{2}','H')",  ubi_gps, cod_lpr, cod_ven  );

                ob_con_ecA.fe_exe_sql(cadena.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// actualiza "PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo Persona (2 de Grup. Per y 5 de Persona)</param>
        /// <param name="nro_per">Nro. de Persona (5 digitos)</param>
        /// <param name="cod_gru">Cod Grupo Persona</param>
        /// <param name="raz_soc">Razon social de la persona</param>
        /// <param name="nom_com">Nombre comercial de la persona</param>
        /// <param name="nit_per">Nit/Cedula de la persona</param>
        /// <param name="dir_per">Direccion de la persona</param>
        /// <param name="tel_per">Telefono de la persona</param>
        /// <param name="cel_per">Celular de la persona</param>
        /// <param name="ema_per">Email de la persona</param>
        /// <param name="cod_lpr">Codigo de lista de precio</param>
        /// <param name="cod_ven">Codigo de Vendedor asociado</param>
        /// <param name="ban_ven">Bandera si identifica persona como cliente</param>
        /// <param name="ban_com">Bandera si identifica persona como proveedor</param>
        /// <returns></returns>
        public void Fe_edi_per(int cod_per, string raz_soc, string nom_com, decimal nit_per, int car_net, string dir_per, string tel_per,
                            string cel_per, string ema_per, int cod_ven )
        {
            try
            {

                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE cmr013 SET ");
                cadena.AppendFormat("va_raz_soc='{0}',va_nom_com='{1}',va_nit_per='{2}',va_car_net={3},", raz_soc, nom_com, nit_per,car_net);
                cadena.AppendFormat("va_dir_per='{0}',va_tel_per='{1}',va_cel_per='{2}',va_ema_per='{3}', ", dir_per, tel_per, cel_per, ema_per);
                cadena.AppendFormat("va_cod_ven='{0}' ", cod_ven);
                cadena.AppendFormat("  WHERE va_cod_per='{0}'", cod_per);

                ob_con_ecA.fe_exe_sql(cadena.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "Habilita/Deshabilita persona"
        /// </summary>
        /// <param name="cod_per">Codigo del persona</param>
        /// <param name="est_ado">Estado del persona</param>
        /// <returns></returns>
        public void Fe_hab_des(int cod_per, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE cmr013 SET ");
                cadena.AppendLine(" va_est_ado='" + est_ado + "' ");
                cadena.AppendLine(" WHERE  va_cod_per = '" + cod_per + "'");

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta persona"
        /// </summary>
        /// <param name="cod_per">Codigo del persona</param>
        /// <returns></returns>
        public DataTable Fe_con_per(int cod_per)
        {
            try
            {

                cadena = new StringBuilder();
                cadena.AppendLine(" cmr013_05a_p01 " + cod_per + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por NIT "
        /// </summary>
        /// <param name="nit_ci">NIT/CI de persona</param>
        /// <returns></returns>
        public DataTable Fe_con_per_nit(int cod_per, decimal nit_ci)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT * FROM cmr013 ");
                cadena.AppendLine(" WHERE  va_nit_per = " + nit_ci + " AND ");
                cadena.AppendLine("        va_cod_per <> " + cod_per + "  ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta persona por  CI"
        /// </summary>
        /// <param name="nit_ci">NIT/CI de persona</param>
        /// <returns></returns>
        public DataTable Fe_con_per_ci(int cod_per, int nro_ci)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT * FROM cmr013 ");
                cadena.AppendLine(" WHERE  va_car_net = " + nro_ci + " AND ");
                cadena.AppendLine("        va_cod_per <> " + cod_per + "  ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Fe_obt_ult_nro(int nro_gru)
        {
            try
            {
                int ult_nro = 0;

                cadena = new StringBuilder();
                cadena.AppendLine(" cmr013_01a_p02 " + nro_gru + "");
                tabla = new DataTable();
                tabla = ob_con_ecA.fe_exe_sql(cadena.ToString());
                ult_nro = int.Parse(tabla.Rows[0][0].ToString());

                return ult_nro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion sugerir nro de Persona según el Codigo de grupo de Persona
        /// </summary>
        /// <param name="cod_gru">codigo del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable _05b(int cod_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT MAX(va_nro_per) FROM cmr013   ");
                cadena.AppendLine(" WHERE va_cod_gru ='" + cod_gru + "' ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina persona"
        /// </summary>
        /// <param name="cod_per">Codigo del persona</param>
        /// <returns></returns>
        public void Fe_eli_per(string cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" cmr013_06a_p01 " + cod_per + " ");

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Buscar PERSONAS"
        /// </summary>
        /// <param name="val_bus">Valor de la busqued</param>
        /// <param name="prm_bus">Parametro de busqueda (1=codigo ; 2=Raz Soc;3=nombre Comercial; 4=NIT/CI )</param>
        /// <param name="est_bus">Estado del persona (0=todos ; 1=Valido/habilitado ; 2=Nulo/Deshabilitado )(</param>
        /// <param name="con_bus">Condición de Búsqueda 0=LIKE(%); 1=IGUAL(=)</param>
        /// <param name="lventa">Bandera que inidica si muestra o no las personas visibles para Ventas</param>
        /// <param name="lcompra">Bandera que inidica si muestra o no las personas visibles para Compras</param>
        /// <returns></returns>
        public DataTable _01a(string val_bus, int prm_bus)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendLine(" select * from cmr013  ");

                switch (prm_bus)
                {
                    case 1: cadena.AppendFormat(" where va_cod_per like '{0}%'", val_bus); break;
                    case 2: cadena.AppendFormat(" where va_raz_soc like '{0}%'", val_bus); break;
                    case 3: cadena.AppendFormat(" where va_nom_com like '{0}%'", val_bus); break;
                    case 4: cadena.AppendFormat(" where va_nit_per like '{0}%'", val_bus); break;
                }


                cadena.AppendFormat(" and va_est_ado ='H' ");
               

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
   
