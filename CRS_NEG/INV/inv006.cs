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
    /// Clase: MARCAS
    /// </summary>
    public class inv006
    {
        //######################################################################
        //##       Tabla: inv006                                              ##
        //##      Nombre: MARCAS                                              ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (11-09-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public inv006()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(int ar_cod_mar, string ar_nom_mar)
        {
            cadena = " INSERT INTO inv006 VALUES(" + ar_cod_mar + ", '" + ar_nom_mar + "')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_mar(int ar_cod_mar, string ar_nom_mar)
        {
            cadena = " UPDATE inv006 SET va_nom_mar = '" + ar_nom_mar + "'  " +
                    " WHERE va_cod_mar = " + ar_cod_mar;
            ob_con_ecA.fe_exe_sql(cadena);
        }
 
        public void Fe_eli_mar(int ar_cod_mar )
        {
            cadena = " DELETE inv006 " +
                 " WHERE va_cod_mar = " + ar_cod_mar + " "; 
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_mar( int ar_cod_mar)
        {
            cadena = " SELECT * FROM inv006" +
                " WHERE va_cod_mar = " + ar_cod_mar + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus )
        {
            cadena = " SELECT * FROM inv006 ";
            cadena += " WHERE va_nom_mar like '" + ar_tex_bus + "%'";
           
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_mar"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_inv006_R01( string ar_est_ado)
        {   
            cadena = " SELECT * FROM inv006" +
                "WHERE va_est_ado = '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
