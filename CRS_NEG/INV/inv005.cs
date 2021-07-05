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
    /// Clase: UNIDAD DE MEDIDA
    /// </summary>
    public class inv005
    {
        //######################################################################
        //##       Tabla: inv005                                              ##
        //##      Nombre: UNIDAD DE MEDIDA                                    ##
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



        public inv005()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(string ar_cod_umd, string ar_nom_umd)
        {
            cadena = " INSERT INTO inv005 VALUES('" + ar_cod_umd + "', '" + ar_nom_umd + "')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_umd(string ar_cod_umd, string ar_nom_umd )
        {
            cadena = " UPDATE inv005 SET va_nom_umd = '" + ar_nom_umd + "'  " +
                    " WHERE va_cod_umd = '" + ar_cod_umd + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_eli_umd(string ar_cod_umd )
        {
            cadena = " DELETE inv005 " +
                 " WHERE va_cod_umd ='" + ar_cod_umd + "' ";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_umd( string ar_cod_umd)
        {
            cadena = " SELECT * FROM inv005" +
                " WHERE va_cod_umd = '" + ar_cod_umd + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            cadena = " SELECT * FROM inv005 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_cod_umd like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_umd LIKE '" + ar_tex_bus + "%'";
          

            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

           
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_umd"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_inv005_R01( )
        {   
            cadena = " SELECT * FROM inv005"  ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
