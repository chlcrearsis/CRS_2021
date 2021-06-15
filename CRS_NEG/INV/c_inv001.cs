using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG.INV
{
    /// <summary>
    /// Clase: GRUPO BODEGAS
    /// </summary>
    public class c_inv001
    {
        //######################################################################
        //##       Tabla: inv001                                              ##
        //##      Nombre: GRUPO BODEGAS                                       ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public c_inv001()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(int ar_ide_gru, string ar_nom_gru, string ar_des_gru, string ar_est_ado)
        {
            cadena = " INSERT INTO inv001 VALUES(" + ar_ide_gru + ", '" + ar_nom_gru + "', " +
                "'" + ar_des_gru + "', 'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_gru(int ar_ide_gru, string ar_nom_gru, string ar_des_gru)
        {
            cadena = " UPDATE inv001 SET va_nom_gru = '" + ar_nom_gru + "', va_des_gru = '" + ar_des_gru + "' " +
                    " WHERE va_ide_gru = " + ar_ide_gru;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili(int ar_ide_gru )
        {
            cadena = " UPDATE inv001 SET va_est_ado = 'H'" +
                    " WHERE va_ide_gru = " + ar_ide_gru;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_ide_gru )
        {
            cadena = " inv001_04a_p01 '" + ar_ide_gru + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_gru(int ar_ide_gru )
        {
            cadena = " inv001_06a_p01 '" + ar_ide_gru + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_gru( int ar_ide_gru)
        {
            cadena = " inv001_05a_p01 " + ar_ide_gru + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            cadena = " SELECT * FROM inv001 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_ide_gru like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_gru ='" + ar_tex_bus + "'";
            if (ar_par_ame == 2)
                cadena += " WHERE va_des_gru ='" + ar_tex_bus + "'";


            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

           
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public DataTable Fe_obt_gru()
        {
            cadena = "SELECT * FROM inv001 ";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_ide_gru"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_inv001_R01( string ar_est_ado)
        {   
            cadena = " inv001_R01 '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
