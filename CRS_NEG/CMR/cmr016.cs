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
    /// Clase: MODULOS
    /// </summary>
    public class cmr016
    {
        //######################################################################
        //##       Tabla: cmr016                                              ##
        //##      Nombre: Actividad Economica                                 ##
        //## Descripcion: Actividad Economica                                 ##         
        //##       Autor: CHL - (07-11-2019)                                  ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        DataTable Tabla = new DataTable();
        string cadena;

 
        public DataTable Fe_obt_act()
        {
            try
            {
                 cadena = "SELECT * FROM cmr016 ";
                Tabla =  ob_con_ecA.fe_exe_sql(cadena);

                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fe_nue_reg(int ar_cod_act , string ar_nom_act)
        {
            try
            {
                cadena = " INSERT INTO cmr016 VALUES(" + ar_cod_act + ",'" + ar_nom_act + "')";


                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Fe_edi_act (int ar_cod_act , string ar_nom_act )
        {
            try
            {
                 cadena = " UPDATE cmr016 SET va_nom_act = '" + ar_nom_act + "' " +
                        " WHERE va_cod_act = " + ar_cod_act ;
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        public void Fe_eli_act (int ar_cod_act )
        {
            try
            {
                cadena = " cmr016_06a_p01 " + ar_cod_act + "";
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Fe_con_act (string ar_cod_act )
        {
            try
            {
                cadena = " SELECT * FROM cmr016 WHERE va_cod_act =  " + ar_cod_act + " ";
                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Fe_ver_exi(string ar_cod_act)
        {
            try
            {
                 bool ret_val = false;
                cadena = " SELECT * FROM cmr016 WHERE va_cod_act =  " + ar_cod_act + " ";
                Tabla = ob_con_ecA.fe_exe_sql(cadena);

                if (Tabla.Rows.Count == 0)
                    ret_val = false;
                else
                    ret_val = true;

                return ret_val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Fe_bus_car(string ar_tex_bus, int ar_par_ame)
        {
            try
            {
                cadena = " SELECT * FROM cmr016 ";
                if (ar_par_ame == 0)
                    cadena += " WHERE va_cod_act like '" + ar_tex_bus + "%'";
                if (ar_par_ame == 1)
                    cadena += " WHERE va_nom_act like '" + ar_tex_bus + "%'";
            
                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: TIPOS DE USUARIOS
        /// </summary>
        /// <param name="ar_cod_act "> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr016_R01(int ar_cod_act)
        {
            try
            {
                cadena = " cmr016_R01 " + ar_cod_act ;

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}