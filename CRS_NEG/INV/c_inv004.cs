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
    /// Clase: PRODUCTOS
    /// </summary>
    public class c_inv004
    {
        //######################################################################
        //##       Tabla: INV004                                              ##
        //##      Nombre: PRODUCTOS                                           ##
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



        public c_inv004()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(string ar_cod_pro, string ar_cod_fam,string ar_cod_umd,string ar_und_cmp, string ar_und_vta, 
            int ar_cod_mar, string ar_nom_pro, string ar_des_pro,string ar_cod_bar,
            string ar_fab_ric,double ar_eqv_cmp, double ar_eqv_vta,int ar_nro_dec, int ar_ban_ser,int ar_ban_lot)
        {
            cadena = " INSERT INTO INV004 VALUES('" + ar_cod_pro + "','" + ar_cod_fam + "','" + ar_cod_umd + "', '" + ar_und_cmp + "', '" + ar_und_vta + "'," +
                "" + ar_cod_mar + ", '" + ar_nom_pro + "','" + ar_des_pro + "','" + ar_cod_bar + "','" + ar_fab_ric + "'," +
                " '" + ar_eqv_cmp + "','" + ar_eqv_vta + "'," + ar_nro_dec + "," + ar_ban_ser + "," + ar_ban_lot + ",'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }

      
        public void Fe_edi_pro(string ar_cod_pro,   
            int ar_cod_mar, string ar_nom_pro, string ar_des_pro, string ar_cod_bar,
            string ar_fab_ric,  int ar_nro_dec )
        { 
            cadena = " UPDATE INV004 SET va_cod_mar = " + ar_cod_mar + ", va_nom_pro = '" + ar_nom_pro + "', va_des_pro = '" + ar_des_pro + "', " +   
                " va_cod_bar = '" + ar_cod_bar + "', va_fab_ric = '" + ar_fab_ric + "', va_nro_dec = " + ar_nro_dec +
                " WHERE  va_cod_pro = '" + ar_cod_pro + "'";

            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_des(string ar_cod_pro, string ar_est_ado )
        {
            cadena = " UPDATE INV004 SET va_est_ado = '"+ ar_est_ado  + "' " +
                    " WHERE va_cod_pro = '" + ar_cod_pro + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_eli_pro(string ar_cod_pro )
        {
            cadena = " INV004_06a_p01 '" + ar_cod_pro + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_pro( string ar_cod_pro)
        {
            cadena = " INV004_05a_p01 '" + ar_cod_pro + "' ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public string Fe_con_cod_max(string ar_cod_fam)
        {
            DataTable tabla = new DataTable();
            string cod_pro = "";

            cadena = " inv004_02a_p03 '" + ar_cod_fam + "' ";
             tabla = ob_con_ecA.fe_exe_sql(cadena);

            if (tabla.Rows.Count > 0)
                cod_pro = tabla.Rows[0][0].ToString();

            return cod_pro;
        }

        public DataTable Fe_con_pro_fam(string ar_cod_fam)
        {
            cadena = " SELECT * FROM inv004" +
                " WHERE va_cod_fam = " + ar_cod_fam + " ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado , string ar_cod_fam = "000000")
        {
            cadena = " inv004_01a_p01 '" + ar_tex_bus + "' , " + ar_par_ame + " , " +
                "'" + ar_est_ado + "', '" + ar_cod_fam + "'" ;
           
 
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_bus_car(string ar_tex_bus, int ar_par_ame, string ar_est_ado, int ar_cod_lis, int ar_cod_bod, string ar_cod_fam = "000000")
        {

            cadena = " inv004_01b_p01 '" + ar_tex_bus + "' , " + ar_par_ame + " ,'" + ar_est_ado + "', " +
                "" + ar_cod_lis + " ," + ar_cod_bod + " , '" + ar_cod_fam + "'";


            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_cod_pro"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_INV004_R01( string ar_est_ado)
        {   
            cadena = " INV004_R01 '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

       
    }
}
