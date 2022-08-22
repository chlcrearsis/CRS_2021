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
    /// Clase: TALONARIOS
    /// </summary>
    public class ads004
    {
        //######################################################################
        //##       Tabla: ads004                                              ##
        //##      Nombre: Talonarios                                          ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (15-05-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public ads004()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(string ar_ide_doc, int ar_nro_tal, string ar_nom_tal, int ar_tip_tal, int ar_nro_aut,
            int ar_for_mar, int ar_nro_cop, string ar_fir_ma1, string ar_fir_ma2, string ar_fir_ma3, string ar_fir_ma4,
            int ar_form_log)
        {
            cadena = " INSERT INTO ads004 VALUES('" + ar_ide_doc + "' , " + ar_nro_tal + ", '" + ar_nom_tal + "'," + ar_tip_tal + 
                 "," + ar_nro_aut + ", " + ar_for_mar +", "+ ar_nro_cop + ", '"+ ar_fir_ma1 + "', '" + ar_fir_ma2 + "'," +
                 "'" + ar_fir_ma3 + "','" + ar_fir_ma4 + "', " + ar_form_log + ",'H')";

            ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// Créa Talonario y numeracion (Anual/Mensual)
        /// </summary>
         public void Fe_cre_tal_num(string ar_ide_doc, int ar_nro_tal, string ar_nom_tal, int ar_tip_tal, int ar_nro_aut,
            int ar_for_mar, int ar_nro_cop, string ar_fir_ma1, string ar_fir_ma2, string ar_fir_ma3, string ar_fir_ma4,
            int ar_form_log, int ar_ges_tio, int ar_anu_mes)
        {
            cadena = " ads004_02a_p01 " + ar_ges_tio + ", " + ar_anu_mes + ", '" + ar_ide_doc + "' , " + ar_nro_tal + ", '" +
                    ar_nom_tal + "'," + ar_tip_tal + "," + ar_nro_aut + ", " + ar_for_mar + ", " + ar_nro_cop + ", '" +
                    ar_fir_ma1 + "', '" + ar_fir_ma2 + "'," + "'" + ar_fir_ma3 + "','" + ar_fir_ma4 + "', " + ar_form_log;


            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_tal(string ar_ide_doc, int ar_nro_tal, string ar_nom_tal, int ar_tip_tal, int ar_nro_aut,
            int ar_for_mar, int ar_nro_cop, string ar_fir_ma1, string ar_fir_ma2, string ar_fir_ma3, string ar_fir_ma4,
            int ar_for_log)
        {
            cadena = " UPDATE ads004 SET va_nom_tal = '" + ar_nom_tal + "', va_tip_tal = " + ar_tip_tal + ", " +
                  " va_nro_aut = " + ar_nro_aut + ", va_for_mat = '" + ar_for_mar + "', va_nro_cop =" + ar_nro_cop + ", " +
                  " va_fir_ma1 = '" + ar_fir_ma1 + "', va_fir_ma2 = '" + ar_fir_ma2 + "', " +
                  " va_fir_ma3 ='" + ar_fir_ma3 + "' , va_fir_ma4 ='" + ar_fir_ma4 + "', va_for_log = " + ar_for_log +
                  " WHERE va_ide_doc = '" + ar_ide_doc + "' AND va_nro_tal = " + ar_nro_tal ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_hab_ili( string ar_ide_doc, int ar_nro_tal)
        {
            cadena = " ads004_04a_p01 '" + ar_ide_doc + "'," + ar_nro_tal;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_des_hab(string ar_ide_doc, int ar_nro_tal)
        {
            cadena = " ads004_04a_p02 '" + ar_ide_doc + "'," + ar_nro_tal;
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_eli_tal(string ar_ide_doc, int ar_nro_tal)
        {
            cadena = " ads004_06a_p01 '" + ar_ide_doc + "'," + ar_nro_tal;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_tal( string ar_ide_doc, int ar_nro_tal)
        {
            cadena = " ads004_05a_p01 '" + ar_ide_doc + "', " + ar_nro_tal;
            return ob_con_ecA.fe_exe_sql(cadena);
        }

       

        public DataTable Fe_con_tal_permiso(string ar_ide_doc, int ar_nro_tal)
        {
            cadena = " ads004_05a_p02 '" + ar_ide_doc + "', " + ar_nro_tal;
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(string ar_tex_bus,int ar_par_ame, string ar_est_ado, int ar_ide_mod )
        {
            cadena = " SELECT ads003.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal, ads004.va_est_ado" +
                     " FROM ads004, ads003 ";
            cadena += " WHERE ads003.va_ide_doc = ads004.va_ide_doc ";

            if (ar_par_ame == 0)
                cadena += "AND ads004.va_nom_tal LIKE '" + ar_tex_bus + "%'";
            if (ar_par_ame == 1)
                cadena += "AND ads003.va_nom_doc LIKE '" + ar_tex_bus + "%'";
            if (ar_par_ame == 2)
                cadena += "AND ads003.va_ide_doc LIKE '" + ar_tex_bus + "%'";

            if (ar_est_ado != "T")
                cadena += " AND ads004.va_est_ado ='" + ar_est_ado + "'";

            if (ar_ide_mod != 0)
                cadena += " AND ads003.va_ide_mod = " + ar_ide_mod ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car_permiso(string ar_tex_bus,  string  ar_ide_doc)
        {
            cadena = " ads004_01b_p01  '" + ar_tex_bus + "%' , '" + ar_ide_doc + "'";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Funcion consultar "CONSULTA TALONARIO POR ID. MODULOS Y DOCUMENTOS"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <returns></returns>
        public DataTable Fe_con_doc(int ide_mod, string ide_doc)
        {
            try
            {
                cadena = " ads004_R01 " + ide_mod + ", '" + ide_doc + "'";

                return ob_con_ecA.fe_exe_sql(cadena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_ges_tio"></param>
        /// <returns></returns>
        public DataTable Fe_ads004_R01(int ar_ide_mod, string ar_est_ado)
        {   
            cadena = " ads004_R01 " + ar_ide_mod + ", '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

     
    }
}
