using System.Data;
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
        string cadena = "";
         
        public void Fe_crea(int ar_cod_ven, string ar_nom_ven, string ar_tel_cel, string ar_ema_ail,
                            int ar_pro_ced, int ar_tip_cms, decimal ar_por_con, decimal ar_por_cre, int ar_ide_tip)
        {
            cadena = " INSERT INTO cmr014 VALUES( "+ ar_ide_tip  + ", " + ar_cod_ven + ", '" + ar_nom_ven + "', '" + ar_tel_cel + "',  '" + ar_ema_ail + "'," +
                 + ar_pro_ced  + ", " + ar_tip_cms + ", '" + ar_por_con + "', '" + ar_por_cre + "', 'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_ven(int ar_cod_ven, string ar_nom_ven, decimal ar_cms_con , decimal ar_cms_cre, int ar_tip_cms, int ar_pro_ced, int ar_ide_tip)
        {
            cadena = " UPDATE cmr014 SET va_nom_bre = '" + ar_nom_ven + "' , " +
                " va_cms_con = '" + ar_cms_con + "',va_cms_cre = '" + ar_cms_cre + "', va_tip_cms = " + ar_tip_cms +
                ", va_pro_ced = " + ar_pro_ced +
                " WHERE va_cod_ide = " + ar_cod_ven + " AND va_ide_tip = " + ar_ide_tip;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili(int ar_cod_ven, int ar_ide_tip)
        {
            cadena = " UPDATE cmr014 SET va_est_ado = 'H'" +
                    " WHERE va_cod_ide = " + ar_cod_ven + " AND va_ide_tip = " + ar_ide_tip;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_cod_ven, int ar_ide_tip)
        {
            cadena = " UPDATE cmr014 SET va_est_ado = 'N'" ;
            cadena += " WHERE va_cod_ide = " + ar_cod_ven + " AND va_ide_tip = " + ar_ide_tip;
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_ven(int ar_cod_ven, int ar_ide_tip)
        {
            cadena = " DELETE cmr014 " ;
            cadena += " WHERE va_cod_ide = " + ar_cod_ven + " AND va_ide_tip = " + ar_ide_tip;
            ob_con_ecA.fe_exe_sql(cadena);            
        }

        public DataTable Fe_con_ven( int ar_cod_ven, int ar_ide_tip)
        {
            cadena = " SELECT * FROM cmr014 WHERE va_cod_ide = " + ar_cod_ven + " AND va_ide_tip = " + ar_ide_tip;
            return ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado, int ar_ide_tip)
        {
            cadena = " SELECT * FROM cmr014 ";
            if (ar_par_ame == 0)
                cadena += " WHERE va_cod_ide like '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += " WHERE va_nom_bre like '" + ar_tex_bus + "%'";



            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

            cadena += " AND va_ide_tip ='" + ar_ide_tip + "'";


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
