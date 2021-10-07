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
    public class ctb006
    {
        //######################################################################
        //##       Tabla: ctb006                                              ##
        //##      Nombre: Leyenda                                             ##
        //## Descripcion: Leyenda                                             ##         
        //##       Autor: CHL - (047-10-2021)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();



        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;


        DataTable Tabla = new DataTable();
        string cadena;
        public ctb006()
        {

            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda  = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }



        public DataTable Fe_obt_ley()
        {
            cadena = "SELECT * FROM ctb006 ";
            Tabla =  ob_con_ecA.fe_exe_sql(cadena);

            return Tabla;
        }

        public void Fe_crea(int ar_cod_ley , string ar_nom_ley)
        {
            cadena = " INSERT INTO ctb006 VALUES(" + ar_cod_ley + ",'" + ar_nom_ley + "')";


            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_ley (int ar_cod_ley , string ar_nom_ley )
        {
            cadena = " UPDATE ctb006 SET va_nom_ley = '" + ar_nom_ley + "' " +
                    " WHERE va_cod_ley = " + ar_cod_ley ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_eli_ley (int ar_cod_ley )
        {
            cadena = " ctb006_06a_p01 " + ar_cod_ley + "";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_ley (string ar_cod_ley )
        {
            cadena = " SELECT * FROM ctb006 WHERE va_cod_ley =  " + ar_cod_ley + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public Boolean Fe_ver_exi(string ar_cod_ley)
        {
            bool ret_val = false;
            cadena = " SELECT * FROM ctb006 WHERE va_cod_ley =  " + ar_cod_ley + " ";
            Tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (Tabla.Rows.Count == 0)
                ret_val = false;
            else
                ret_val = true;

            return ret_val;
        }


        public DataTable Fe_bus_car(string ar_tex_bus, int ar_par_ame)
        {
            cadena = " SELECT * FROM ctb006 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_cod_ley like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_ley like '" + ar_tex_bus + "%'";
            
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: TIPOS DE USUARIOS
        /// </summary>
        /// <param name="ar_cod_ley "> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_ctb006_R01(int ar_cod_ley)
        {
            cadena = " ctb006_R01 " + ar_cod_ley ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }


    }
}