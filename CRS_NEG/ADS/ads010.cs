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
    public class ads010
    {
        //######################################################################
        //##       Tabla: ads010                                              ##
        //##      Nombre: Modulo                                              ##
        //## Descripcion: Modulos del sistema                                 ##         
        //##       Autor: FVM - (07-09-2021)                                  ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();



        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;


        DataTable Tabla = new DataTable();
        string cadena;
        public ads010()
        {

            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda  = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }



        public DataTable Fe_obt_mod()
        {
            cadena = "SELECT * FROM ads010 " +
                " WHERE va_est_ado = 'H' ";
            Tabla =  ob_con_ecA.fe_exe_sql(cadena);

            return Tabla;
        }

        public void Fe_crea(int ar_ide_tip , string ar_nom_tip , string ar_ide_tab , string ar_est_ado)
        {
            cadena = " INSERT INTO ads010 VALUES(" + ar_ide_tip + ",'" + ar_nom_tip + "' , '" + ar_ide_tab + "', 'H')";


            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_mod (int ar_ide_tip , string ar_nom_tip , string ar_ide_tab )
        {
            cadena = " UPDATE ads010 SET va_nom_tip = '" + ar_nom_tip + "' , va_ide_tab = '" + ar_ide_tab + "'" +
                    " WHERE va_ide_tip = " + ar_ide_tip ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili(int ar_ide_tip )
        {
            cadena = " UPDATE ads010 SET va_est_ado = 'H'" +
                    " WHERE va_ide_tip = " + ar_ide_tip ;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_ide_tip )
        {
            cadena = " ads010_04a_p01 '" + ar_ide_tip + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_mod (int ar_ide_tip )
        {
            cadena = " ads010_06a_p01 " + ar_ide_tip + "";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_mod (string ar_ide_tip )
        {
            cadena = " SELECT * FROM ads010 WHERE va_ide_tip =  " + ar_ide_tip + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(string ar_tex_bus, int ar_par_ame, string ar_est_ado)
        {
            cadena = " SELECT * FROM ads010 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_ide_tip like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_tip like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 2)
                cadena += " WHERE va_ide_tab like '" + ar_tex_bus + "%'";
            


            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";


            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: TIPOS DE USUARIOS
        /// </summary>
        /// <param name="ar_ide_tip "> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_ads010_R01(int ar_ide_tip , string ar_est_ado)
        {
            cadena = " ads010_R01 " + ar_ide_tip + ", '" + ar_est_ado + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }


    }
}