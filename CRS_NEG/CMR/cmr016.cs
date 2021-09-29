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



        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;


        DataTable Tabla = new DataTable();
        string cadena;
        public cmr016()
        {

            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda  = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }



        public DataTable Fe_obt_act()
        {
            cadena = "SELECT * FROM cmr016 ";
            Tabla =  ob_con_ecA.fe_exe_sql(cadena);

            return Tabla;
        }

        public void Fe_crea(int ar_cod_act , string ar_nom_act)
        {
            cadena = " INSERT INTO cmr016 VALUES(" + ar_cod_act + ",'" + ar_nom_act + "')";


            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_act (int ar_cod_act , string ar_nom_act )
        {
            cadena = " UPDATE cmr016 SET va_nom_act = '" + ar_nom_act + "' " +
                    " WHERE va_cod_act = " + ar_cod_act ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_eli_act (int ar_cod_act )
        {
            cadena = " cmr016_06a_p01 " + ar_cod_act + "";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_act (string ar_cod_act )
        {
            cadena = " SELECT * FROM cmr016 WHERE va_cod_act =  " + ar_cod_act + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(string ar_tex_bus, int ar_par_ame)
        {
            cadena = " SELECT * FROM cmr016 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_cod_act like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_act like '" + ar_tex_bus + "%'";
            
            return ob_con_ecA.fe_exe_sql(cadena);
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
            cadena = " cmr016_R01 " + ar_cod_act ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }


    }
}