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
    /// Clase: VENDEDORES
    /// </summary>
    public class cmr014
    {
        //######################################################################
        //##       Tabla: cmr014                                              ##
        //##      Nombre: VENDEDORES                                          ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (15-09-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public cmr014()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(int ar_cod_ven, string ar_nom_ven,int ar_tip_cms, decimal ar_por_ven)
        {
            cadena = " INSERT INTO cmr014 VALUES(" + ar_cod_ven + ", '" + ar_nom_ven + "', " +
                "'" + ar_por_ven + "',  "+ ar_tip_cms  + ", 'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_ven(int ar_cod_ven, string ar_nom_ven, decimal ar_por_ven, int ar_tip_cms)
        {
            cadena = " UPDATE cmr014 SET va_nom_ven = '" + ar_nom_ven + "' , " +
                " va_por_cms = '" + ar_por_ven + "', va_tip_cms = " + ar_tip_cms +
                    " WHERE va_cod_ven = " + ar_cod_ven;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili(int ar_cod_ven )
        {
            cadena = " UPDATE cmr014 SET va_est_ado = 'H'" +
                    " WHERE va_cod_ven = " + ar_cod_ven;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_cod_ven )
        {
            cadena = " UPDATE cmr014 SET va_est_ado = 'N'" ;
            cadena += " WHERE va_cod_ven = '" + ar_cod_ven + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_ven(int ar_cod_ven)
        {
            cadena = " DELETE cmr014 " ;
            cadena += " WHERE va_cod_ven = '" + ar_cod_ven + "'";
            ob_con_ecA.fe_exe_sql(cadena);

            
        }

        public DataTable Fe_con_ven( int ar_cod_ven)
        {
            cadena = " SELECT * FROM cmr014 WHERE va_cod_ven = " + ar_cod_ven + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado )
        {
            cadena = " SELECT * FROM cmr014 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_cod_ven like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_ven like '" + ar_tex_bus + "%'";



            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

           
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_ven"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr014_R01( string ar_est_ado)
        {   
            cadena = " cmr014_R01 '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
