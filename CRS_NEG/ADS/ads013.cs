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
    /// Clase:  PARAMETROS GLOBALES PARA LA EMPRESA
    /// </summary>
    public class ads013
    {
        //######################################################################
        //##       Tabla: ads013                                              ##
        //##      Nombre: GLOBALES                                            ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (01-04-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public ads013()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        public void Fe_crea(int ar_ges_tio, int ar_per_ini)
        {
            //cadena = " Execute ads016_02a_p01 " + ar_ges_tio + "," + ar_per_ini;
            //ob_con_ecA.fe_exe_sql(cadena);
        }
       
        public void Fe_edi_glo(int ar_ide_mod, int ar_ide_glo,string ar_nom_glo, int ar_tip_glo,
            string ar_glo_car, int ar_glo_int, decimal ar_glo_dec)
        {
            cadena = " UPDATE ads013 SET va_nom_glo = '" + ar_nom_glo + "', va_tip_glo = " + ar_tip_glo +", " +
                    " va_glo_car ='" + ar_glo_car + "', va_glo_int =" + ar_glo_int + ", va_glo_dec = '" + ar_glo_dec + "' " +
                    " WHERE va_ide_mod = " + ar_ide_mod + " AND va_ide_glo = " + ar_ide_glo;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_obt_glo(int ar_ide_mod, int ar_ide_glo)
        {
            cadena = " SELECT * FROM ads013";
            cadena += " WHERE va_ide_mod =" + ar_ide_mod ;
            cadena += "   AND va_ide_glo =" + ar_ide_glo;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        // Obtiene Datos de la Licencia del Servidor
        public DataTable Fe_obt_lic()
        {
            cadena = " EXECUTE ads000_13a_p01";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        // Graba Datos de la Licencia del Servidor
        public void Fe_gra_lic(int ag_nro_usr, string ag_fec_exp, string ag_mod_adm,
                                    string ag_mod_inv, string ag_mod_com, string ag_mod_res)
        {
            cadena = " EXECUTE ads000_13b_p01 " + ag_nro_usr + ", '" + ag_fec_exp + "', '" + ag_mod_adm + "', " +
                "'" + ag_mod_inv + "', '" + ag_mod_com + "', '" + ag_mod_res + "'";

            ob_con_ecA.fe_exe_sql(cadena);
        }

        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: PERIODOS DE UNA GESTION
        /// </summary>
        /// <param name="ar_ges_tio"></param>
        /// <returns></returns>
        //public DataTable Fe_ads016_R01(int ar_ges_tio)
        //{
        //    cadena = " ads016_R01 " + ar_ges_tio;

        //    return ob_con_ecA.fe_exe_sql(cadena);
        //}


    }
}
