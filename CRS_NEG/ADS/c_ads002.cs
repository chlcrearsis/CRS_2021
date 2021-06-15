using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG.ADS
{
    /// <summary>
    /// Clase: APLICACIONES
    /// </summary>
    public class c_ads002
    {
        //######################################################################
        //##       Tabla: ads002                                              ##
        //##      Nombre: Aplicaciones                                        ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (07-04-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public c_ads002()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(int ar_ide_mod, string ar_ide_apl, string ar_nom_apl, string ar_est_ado)
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
            cadena = " UPDATE ads002 SET va_est_ado = 'H'" +
                    " WHERE va_ide_apl = '" + ar_ide_apl + "' AND va_ide_mod = " + ar_ide_mod;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_ide_mod, string ar_ide_apl)
        {
            cadena = " ads002_04a_p01 '" + ar_ide_apl + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_apl(int ar_ide_mod, string ar_ide_apl)
        {
            cadena = " ads002_06a_p01 '" + ar_ide_apl + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_apl( string ar_ide_apl)
        {
            cadena = " ads002_05a_p01 '" + ar_ide_apl + "' ";
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
