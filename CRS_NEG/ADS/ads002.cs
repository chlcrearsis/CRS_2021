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
    /// Clase: APLICACIONES
    /// </summary>
    public class ads002
    {
        //######################################################################
        //##       Tabla: ads002                                              ##
        //##      Nombre: Aplicaciones                                        ##
        //## Descripcion: Aplicaciones del Sistema                            ##         
        //##       Autor: CHL  - (07-04-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        string cadena = "";
 
        public void Fe_crea(int ar_ide_mod, string ar_ide_apl, string ar_nom_apl)
        {
            cadena = " INSERT INTO ads002 VALUES(" + ar_ide_mod + ",'" + ar_ide_apl + "' , '" + ar_nom_apl + "', 'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_apl(int ar_ide_mod, string ar_ide_apl, string ar_nom_apl)
        {
            cadena = " UPDATE ads002 SET va_nom_apl = '" + ar_nom_apl + "' " +
                    " WHERE va_ide_apl = '" + ar_ide_apl + "' AND va_ide_mod = " + ar_ide_mod;
            ob_con_ecA.fe_exe_sql(cadena);
        }        

        public void Fe_hab_ili(int ar_ide_mod, string ar_ide_apl)
        {
            cadena = " ads002_04a_p01 " + ar_ide_mod + ", '" + ar_ide_apl + "'";
            ob_con_ecA.fe_exe_sql(cadena);           
        }
        public void Fe_des_hab(int ar_ide_mod, string ar_ide_apl)
        {
            cadena = " UPDATE ads002 SET va_est_ado = 'N'" +
                    " WHERE va_ide_apl = '" + ar_ide_apl + "' AND va_ide_mod = " + ar_ide_mod;
            ob_con_ecA.fe_exe_sql(cadena);
        }

   

        public void Fe_eli_apl(int ar_ide_mod, string ar_ide_apl)
        {
            cadena = " ads002_06a_p01 '" + ar_ide_apl + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_lis_mod(int ar_ide_mod)
        {
            cadena = " ads002_06a_p01 '" + ar_ide_mod + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_apl( string ar_ide_apl)
        {
            cadena = " ads002_05a_p01 '" + ar_ide_apl + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            cadena = " SELECT * FROM ads002 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_ide_apl like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_apl like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 2)
                cadena += " WHERE va_des_apl like '" + ar_tex_bus + "%'";


            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";
           
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_ide_mod"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_ads002_R01(int ar_ide_mod, string ar_est_ado)
        {   
            cadena = " ads002_R01 " + ar_ide_mod + ", '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
