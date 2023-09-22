using System;
using System.Data;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: BODEGA
    /// </summary>
    public class inv002
    {
        //######################################################################
        //##       Tabla: inv002                                              ##
        //##      Nombre: BODEGA                                             ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (15-05-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        string cadena = "";
 
        public void Fe_crea(int ar_ide_gru, int ar_cod_bod, string ar_nom_bod, string ar_des_bod, string ar_dir_bod,
            DateTime ar_fec_ctr, string ar_mon_inv, string ar_mtd_cto,string ar_nom_ecg, string ar_tlf_ecg, string ar_dir_ecg)
        {
            cadena = " INSERT INTO inv002 VALUES( " + ar_ide_gru + " , " + ar_cod_bod + ", '" + ar_nom_bod + "','" + ar_des_bod + "', " +
                 "'" + ar_dir_bod + "','" + ar_fec_ctr + "', '"+ ar_mon_inv + "', '"+ ar_mtd_cto + "', '" + ar_nom_ecg + "'," +
                 "'" + ar_tlf_ecg + "','" + ar_dir_ecg + "','H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_bod(int ar_ide_gru, int ar_cod_bod, string ar_nom_bod, string ar_des_bod, string ar_dir_bod,
                string ar_mon_inv, string ar_mtd_cto, string ar_nom_ecg, string ar_tlf_ecg, string ar_dir_ecg)
        {
            cadena = " UPDATE inv002 SET va_nom_bod = '" + ar_nom_bod + "', va_des_bod = '" + ar_des_bod + "', " +
                  " va_dir_bod = '" + ar_dir_bod + "', va_mon_inv ='" + ar_mon_inv + "', " +
                  " va_mtd_cto = '" + ar_mtd_cto + "', va_nom_ecg = '" + ar_nom_ecg + "', va_tlf_ecg = '" + ar_tlf_ecg + "', " +
                  " va_dir_ecg ='" + ar_dir_ecg + "' " +
                  " WHERE va_ide_gru = " + ar_ide_gru + " AND va_cod_bod = " + ar_cod_bod + "" ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_ape_fec(int ar_cod_bod, DateTime ar_fec_ctr)
        {
            cadena = " UPDATE inv002 SET va_fec_ctr = '" + ar_fec_ctr.ToString("d") + "'" +
                  " WHERE va_cod_bod = " + ar_cod_bod + "";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_hab_ili( int ar_ide_gru, int ar_cod_bod)
        {
            cadena = " inv002_04a_p01 " + ar_ide_gru + "," + ar_cod_bod + "";
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(int ar_ide_gru, int ar_cod_bod)
        {
            cadena = " inv002_04a_p02 " + ar_ide_gru + "," + ar_cod_bod + "";
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_bod(int ar_ide_gru, int ar_cod_bod)
        {
            cadena = " inv002_06a_p01 " + ar_ide_gru + "," + ar_cod_bod + "";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_bod( int ar_cod_bod)
        {
            cadena = " inv002_05a_p01  " + ar_cod_bod +"";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_gru(int ar_ide_gru)
        {
            cadena = " SELECT * FROM inv002 WHERE va_ide_gru = " + ar_ide_gru + " AND va_est_ado = 'H'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado, int ar_ide_gru )
        {
            cadena = " SELECT va_ide_gru, va_cod_bod, va_nom_bod, va_mon_inv, va_fec_ctr, va_est_ado" +
                     " FROM inv002 ";
            cadena += " WHERE va_ide_gru = va_ide_gru ";

            cadena += "AND va_nom_bod LIKE '" + ar_tex_bus + "%'";
           
            if (ar_est_ado != "T")
                cadena += " AND va_est_ado ='" + ar_est_ado + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

            /// <summary>
            /// Funcion externa reporte: BODEGA
            /// </summary>
            /// <returns></returns>
        public DataTable Fe_inv002_R01(int ar_gru_ini, int ar_gru_fin, string ar_est_ado)
        {   
            cadena = " inv002_R01 " + ar_gru_ini + "," + ar_gru_fin + ", '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

     
    }
}
