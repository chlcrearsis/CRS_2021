using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: SUCURSAL
    /// </summary>
    public class cmr017
    {
        //######################################################################
        //##       Tabla: cmr017                                              ##
        //##      Nombre: SUCURSAL                                            ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (14-09-2021)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        string cadena = "";
        string DateFornat = "dd.MM.yyyy hh:mm:ss";

 
        public void Fe_nue_reg(int cod_suc, string nom_suc, string enc_suc,
            string ubi_suc, string tel_suc, string ema_suc, string ciu_suc, string ley_suc)
        {
            try
            {
                cadena = "";
                cadena +=" INSERT INTO cmr017 VALUES ";
                cadena += " (" + cod_suc + ", '" + nom_suc + "','" + enc_suc + "','" + ubi_suc + "','" + tel_suc;
                cadena += "','" + ema_suc + "','" + ciu_suc + "','" + ley_suc + "','H')";

                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
       
      
        public void Fe_edi_suc(int cod_suc, string nom_suc, string enc_suc,
            string ubi_suc, string tel_suc, string ema_suc, string ciu_suc, string ley_suc)
        {
            try
            {
                cadena ="";
                cadena = " UPDATE adm007 SET ";
                cadena += " va_nom_suc='" + nom_suc + "', va_enc_suc='" + enc_suc + "', va_ubi_suc='" + ubi_suc + "',";
                cadena += " va_tel_suc='" + tel_suc + "', va_ema_suc='" + ema_suc + "', va_ciu_suc='" + ciu_suc + "',";
                cadena += " WHERE va_cod_suc =" + cod_suc;

                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fe_hab_ili(int ar_cod_suc )
        {
            try
            {
                cadena = " UPDATE cmr017 SET va_est_ado = 'H'" +
                        " WHERE va_cod_suc = " + ar_cod_suc;
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        public void Fe_des_hab(int ar_cod_suc )
        {
            try
            {
                cadena = " UPDATE cmr017 SET va_est_ado = 'N'" ;
                cadena += " WHERE va_cod_suc = '" + ar_cod_suc + "'";
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public void Fe_eli_suc(int ar_cod_suc)
        {
            try
            {
             
                cadena = " DELETE cmr017 " ;
                cadena += " WHERE va_cod_suc = '" + ar_cod_suc + "'";
                ob_con_ecA.fe_exe_sql(cadena);

                cadena = " DELETE cmr002 ";
                cadena += " WHERE va_cod_suc = '" + ar_cod_suc + "'";
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Fe_con_suc( int ar_cod_suc)
        {          

            try
            {    
                cadena = " SELECT * FROM cmr017 WHERE va_cod_suc = " + ar_cod_suc + " ";
                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// BUSCAR LISTA DE PRECIOS ABM
        /// </summary>
        /// <param name="ar_tex_bus"></param>
        /// <param name="ar_par_ame"></param>
        /// <param name="ar_est_ado"></param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            try
            {
                cadena = " EXECUTE cmr017_01a_p01  '" + ar_tex_bus + "' , " + ar_par_ame + " , '" + ar_est_ado  + "'";
           
                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// BUSCAR LISTA DE PRECIOS PERMITIDAS
        /// </summary>
        /// <param name="ar_tex_bus"></param>
        /// <param name="ar_par_ame"></param>
        /// <param name="ar_est_ado"></param>
        /// <returns></returns>
        public DataTable Fe_bus_car_b(string ar_tex_bus, int ar_par_ame, string ar_est_ado)
        {
            try
            {
                cadena = " EXECUTE cmr017_01b_p01  '" + ar_tex_bus + "' , " + ar_par_ame + " , '" + ar_est_ado + "'";

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_suc"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr017_R01( string ar_est_ado)
        {
            try
            {
                 cadena = " cmr017_R01 '" + ar_est_ado + "'" ;

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
