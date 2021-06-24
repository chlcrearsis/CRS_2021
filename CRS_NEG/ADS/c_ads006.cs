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
    /// Clase: TIPO DE USUARIOS
    /// </summary>
    public class c_ads006
    {
        //######################################################################
        //##       Tabla: ads006                                              ##
        //##      Nombre: TIPO DE USUARIOS                                    ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (19-06-2021)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public c_ads006()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(int ar_ide_tus, string ar_nom_tus, string ar_des_tus, string ar_est_ado)
        {
            cadena = " INSERT INTO ads006 VALUES(" + ar_ide_tus + ",'" + ar_nom_tus + "' , '" + ar_des_tus + "', 'H')";
            

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_tus(int ar_ide_tus, string ar_nom_tus, string ar_des_tus)
        {
            cadena = " UPDATE ads006 SET va_nom_tus = '" + ar_nom_tus + "' , va_des_tus = '" + ar_des_tus + "'" +
                    " WHERE va_ide_tus = " + ar_ide_tus;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili(int ar_ide_tus)
        {
            cadena = " UPDATE ads006 SET va_est_ado = 'H'" +
                    " WHERE va_ide_tus = " + ar_ide_tus;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_ide_tus)
        {
            cadena = " ads006_04a_p01 '" + ar_ide_tus + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_tus(int ar_ide_tus)
        {
            cadena = " ads006_06a_p01 '" + ar_ide_tus + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_tus( string ar_ide_tus)
        {
            cadena = " ads006_05a_p01 '" + ar_ide_tus + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_lis_tus()
        {
            cadena = "SELECT * FROM ads006 WHERE va_est_ado = 'H' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            cadena = " SELECT * FROM ads006 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_nom_tus like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_des_tus like '" + ar_tex_bus + "%'";
            

            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

           
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: TIPOS DE USUARIOS
        /// </summary>
        /// <param name="ar_ide_tus"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_ads006_R01(int ar_ide_tus, string ar_est_ado)
        {   
            cadena = " ads006_R01 " + ar_ide_tus + ", '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
