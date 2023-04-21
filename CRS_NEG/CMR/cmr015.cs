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
    /// Clase: LISTA DE DELIVERY
    /// </summary>
    public class cmr015
    {
        //######################################################################
        //##       Tabla: cmr015                                              ##
        //##      Nombre: LISTA DE DELIVERY                                   ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        string cadena = "";

        public void Fe_nue_reg(int ar_cod_del, string ar_nom_del, decimal ar_por_del)
        {
            try
            {
                cadena = " INSERT INTO cmr015 VALUES(" + ar_cod_del + ", '" + ar_nom_del + "', " +
                    "'" + ar_por_del + "', 'H')";

                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public void Fe_edi_del(int ar_cod_del, string ar_nom_del, decimal ar_por_del)
        {
            try
            {
                 cadena = " UPDATE cmr015 SET va_nom_del = '" + ar_nom_del + "' , " +
                    " va_por_del = '" + ar_por_del + "' " +
                        " WHERE va_cod_del = " + ar_cod_del;
                ob_con_ecA.fe_exe_sql(cadena);
           }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fe_hab_ili(int ar_cod_del )
        {
            try
            {
                 cadena = " UPDATE cmr015 SET va_est_ado = 'H'" +
                        " WHERE va_cod_del = " + ar_cod_del;
                 ob_con_ecA.fe_exe_sql(cadena);
           }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Fe_des_hab(int ar_cod_del )
        {
            try
            {
                 cadena = " UPDATE cmr015 SET va_est_ado = 'N'" ;
                cadena += " WHERE va_cod_del = '" + ar_cod_del + "'";
                ob_con_ecA.fe_exe_sql(cadena);
           }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Fe_eli_del(int ar_cod_del)
        {
            try
            {
                 cadena = " DELETE cmr015 " ;
                cadena += " WHERE va_cod_del = '" + ar_cod_del + "'";
                ob_con_ecA.fe_exe_sql(cadena);

                cadena = " DELETE cmr002 ";
                cadena += " WHERE va_cod_del = '" + ar_cod_del + "'";
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Fe_con_del( int ar_cod_del)
        {
            try
            {
                cadena = " SELECT * FROM cmr015 WHERE va_cod_del = " + ar_cod_del + " ";
                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            try
            {
                cadena = " SELECT * FROM cmr015 ";
                if (ar_par_ame == 0)
                    cadena += " WHERE va_cod_del like '" + ar_tex_bus + "%'";
                if (ar_par_ame == 1)
                    cadena += " WHERE va_nom_del like '" + ar_tex_bus + "%'";



                if (ar_est_ado != "T")
                    cadena += " AND va_est_ado ='" + ar_est_ado + "'";

           
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
        /// <param name="ar_cod_del"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr015_R01( string ar_est_ado)
        {
            try
            {
                cadena = " cmr015_R01 '" + ar_est_ado + "'" ;

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
