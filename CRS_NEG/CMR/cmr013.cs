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
    /// Clase: REGISTRO DE NIT
    /// </summary>
    public class cmr013
    {
        //######################################################################
        //##       Tabla: cmr013                                              ##
        //##      Nombre: Registro de Nit                                     ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (30-08-2021)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public cmr013()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea( int ar_cod_per, int ar_nit_per, string ar_raz_soc)
        {
            cadena = " INSERT INTO cmr013 VALUES(" + ar_cod_per + "," + ar_nit_per + ",'" + ar_raz_soc + "' )";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_nit(int ar_nit_per, string ar_raz_soc,int ar_cod_per)
        {
            cadena = " UPDATE cmr013 SET va_raz_soc = '" + ar_raz_soc + "' " +
                    " WHERE  va_nit_per = " + ar_nit_per +
                     " AND va_cod_per = '" + ar_cod_per;
            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_eli_nit(int ar_nit_per, int ar_cod_per)
        {
            cadena = " DELETE cmr013 " +
                     "WHERE va_nit_per = " + ar_nit_per +
                     " AND va_cod_per = " + ar_cod_per ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_nit(int ar_nit_per, int ar_cod_per)
        {
            cadena = " SELECT * FROM cmr013 WHERE va_nit_per = " + ar_nit_per +
                     " AND va_cod_per = " + ar_cod_per;
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public DataTable Fe_con_nit(int ar_cod_per)
        {
            cadena = " SELECT * FROM cmr013 WHERE " +
                     " va_cod_per = " + ar_cod_per;
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_ult_nit(int ar_cod_per)
        {
            cadena = " SELECT * FROM cmr013 WHERE " +
                     " va_cod_per = " + ar_cod_per +" AND va_act_ual = 1";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame )
        {
            cadena = " SELECT * FROM cmr013 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_nit_per like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_raz_soc like '" + ar_tex_bus + "%'";


            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: NIT DE PERSONAS
        /// </summary>
        /// <param name="ar_nit_per"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr013_R01()
        {   
            cadena = " EXECUTE cmr013_R01 " ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
