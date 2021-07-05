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
    /// Clase: DOCUMENTOS
    /// </summary>
    public class ads003
    {
        //######################################################################
        //##       Tabla: ads003                                              ##
        //##      Nombre: Documentos                                          ##
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



        public ads003()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(int ar_ide_mod, string ar_ide_doc, string ar_nom_doc, string ar_des_cri, string ar_est_ado)
        {
            cadena = " INSERT INTO ads003 VALUES(" + ar_ide_mod + ",'" + ar_ide_doc + "' , '" + ar_nom_doc + "', " +
                "'" + ar_des_cri + "', 'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_doc(int ar_ide_mod, string ar_ide_doc, string ar_nom_doc, string ar_des_cri)
        {
            cadena = " UPDATE ads003 SET va_nom_doc = '" + ar_nom_doc + "', va_des_doc = '" + ar_des_cri + "' " +
                    " WHERE va_ide_doc = '" + ar_ide_doc + "' AND va_ide_mod = " + ar_ide_mod;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili(int ar_ide_mod, string ar_ide_doc)
        {
            cadena = " UPDATE ads003 SET va_est_ado = 'H'" +
                    " WHERE va_ide_doc = '" + ar_ide_doc + "' AND va_ide_mod = " + ar_ide_mod;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_ide_mod, string ar_ide_doc)
        {
            cadena = " ads003_04a_p01 '" + ar_ide_doc + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_doc(int ar_ide_mod, string ar_ide_doc)
        {
            cadena = " ads003_06a_p01 '" + ar_ide_doc + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_doc( string ar_ide_doc)
        {
            cadena = " ads003_05a_p01 '" + ar_ide_doc + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado, int ar_ide_mod )
        {
            cadena = " SELECT * FROM ads003 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_ide_doc like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_doc like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 2)
                cadena += " WHERE va_des_doc like '" + ar_tex_bus + "%'";


            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

            cadena += " AND va_ide_mod = " + ar_ide_mod ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_ide_mod"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_ads003_R01(int ar_ide_mod, string ar_est_ado)
        {   
            cadena = " ads003_R01 " + ar_ide_mod + ", '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
