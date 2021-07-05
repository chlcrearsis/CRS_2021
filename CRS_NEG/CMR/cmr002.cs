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
    /// Clase: PRECIOS
    /// </summary>
    public class cmr002
    {
        //######################################################################
        //##       Tabla: cmr002                                              ##
        //##      Nombre: PRECIOS                                             ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (25-07-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public cmr002()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        public void Fe_crea(int ar_cod_lis, string ar_cod_pro, decimal ar_pre_cio, decimal ar_pmx_des, decimal ar_pmx_inc)
        {
            try
            {
                // Elimina precio para luego crearlo
                cadena = "DELETE cmr002 " +
                    " WHERE va_cod_lis = " + ar_cod_lis + "" +
                    " AND va_cod_pro =  '" + ar_cod_pro + "'";
                ob_con_ecA.fe_exe_sql(cadena);

                // Crea precio
                cadena = "";
                cadena = "INSERT INTO cmr002 VALUES (" + ar_cod_lis + ", '" + ar_cod_pro + "', '" + ar_pre_cio + "','" + ar_pmx_des + "', '" + ar_pmx_inc + "',0 )";
           
                ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Fe_edi_pre(int ar_cod_lis, string ar_cod_pro, decimal ar_pre_cio, decimal ar_pmx_des, decimal ar_pmx_inc)
        {
            cadena = " UPDATE cmr002 SET va_pre_cio = '" + ar_pre_cio + "', va_pmx_des = '" + ar_pmx_des + "', " +
                " va_pmx_inc = '" + ar_pmx_inc  + "'" +
                    " WHERE va_cod_lis = " + ar_cod_lis + " and va_cod_pro = '" + ar_cod_pro + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_eli_lis(int ar_cod_lis, string ar_cod_pro)
        {
            cadena = " DELETE cmr002 " +
            " WHERE va_cod_lis = " + ar_cod_lis + " and va_cod_pro = '" + ar_cod_pro + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_pre(int ar_cod_lis, string ar_cod_pro)
        {
            cadena = " SELECT * FROM cmr002 " +
                 " WHERE va_cod_lis = " + ar_cod_lis + " and va_cod_pro = '" + ar_cod_pro + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// Busca precio en varias listas (autorizadas al usuario)
        /// </summary>
        /// <param name="ar_cod_pro"></param>
        /// <param name="ar_lis_ini"></param>
        /// <param name="ar_lis_fin"></param>
        /// <returns></returns>
        public DataTable Fe_bus_var( string ar_cod_pro, int ar_lis_ini, int ar_lis_fin)
        {
            cadena = " cmr002_01a_p01 '" + ar_cod_pro + "', " + ar_lis_ini + ", " + ar_lis_fin;
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        /// <summary>
        /// Consulta precio en varias listas
        /// </summary>
        /// <param name="ar_cod_pro">Codigo producto</param>
        /// <param name="ar_lis_ini">Lista de precio inicial</param>
        /// <param name="ar_lis_fin">Lista de precio final</param>
        /// <returns></returns>
        public DataTable Fe_con_pre(string ar_cod_pro, int ar_lis_ini, int ar_lis_fin)
        {
            cadena = " cmr002_05b_p01 '" + ar_cod_pro + "'," + ar_lis_ini + "," + ar_lis_fin + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, int ar_cod_lis )
        {
            cadena = " SELECT * FROM cmr002 ";
            cadena += " WHERE va_nom_pro like '" + ar_tex_bus + "%'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_lis"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr002_R01( string ar_est_ado)
        {   
            cadena = " cmr002_R01 '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
