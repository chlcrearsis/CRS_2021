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
    /// Clase: NUMERACION
    /// </summary>
    public class ads005
    {
        //######################################################################
        //##       Tabla: ads005                                              ##
        //##      Nombre: Numeracion                                          ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (28-05-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public ads005()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        public void Fe_crea(string ar_ide_doc, int ar_nro_tal,  int ar_ges_tio, DateTime ar_fec_ini, DateTime ar_fec_fin,
                            int ar_nro_ini, int ar_nro_fin, int ar_con_tad)
        {
            cadena = " INSERT INTO ads005 VALUES('" + ar_ide_doc + "' , " + ar_nro_tal + ", " + ar_ges_tio +
                                               ",'" + ar_fec_ini.ToString("dd/MM/yyyy") + "', '" + ar_fec_fin.ToString("dd/MM/yyyy") + "', " + ar_nro_ini + 
                                               ", " + ar_nro_fin + ", " + ar_con_tad + ")" ;
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_num(string ar_ide_doc, int ar_nro_tal, int ar_ges_tio, DateTime ar_fec_ini, DateTime ar_fec_fin,
                            int ar_nro_ini, int ar_nro_fin, int ar_con_tad)
            {
            cadena = " UPDATE ads005 SET va_fec_ini = '" + ar_fec_ini.ToString("dd/MM/yyyy") + "',  va_fec_fin = '" + ar_fec_fin.ToString("dd/MM/yyyy") + "', " +
                  " va_nro_ini = " + ar_nro_ini + ", va_nro_fin = " + ar_nro_fin + ", va_con_tad =" + ar_con_tad +
                  " WHERE va_ide_doc = '" + ar_ide_doc + "' AND va_nro_tal = " + ar_nro_tal + " AND va_ges_tio = " + ar_ges_tio;
            ob_con_ecA.fe_exe_sql(cadena);
        }


        public void Fe_edi_con(string ar_ide_doc, int ar_nro_tal, int ar_ges_tio,int ar_con_tad)
        {
            cadena = " UPDATE ads005 SET va_con_tad =" + ar_con_tad +
                  " WHERE va_ide_doc = '" + ar_ide_doc + "' AND va_nro_tal = " + ar_nro_tal + " AND va_ges_tio = " + ar_ges_tio;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_eli_num(string ar_ide_doc, int ar_nro_tal, int ar_ges_tio)
        {
            cadena = " DELETE ads005 " +
            " WHERE va_ide_doc = '" + ar_ide_doc + "' AND va_nro_tal = " + ar_nro_tal + " AND va_ges_tio = " + ar_ges_tio;

            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_num( string ar_ide_doc, int ar_nro_tal, int ar_ges_tio)
        {
            cadena = " ads005_05a_p01 '" + ar_ide_doc + "', " + ar_nro_tal + ", " + ar_ges_tio;
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(int ar_ide_mod, int ar_ges_tio, string ar_tex_bus,int ar_cri_ter )
        {
            cadena = "ads005_01a_p01 " + ar_ide_mod + ", " + ar_ges_tio + ", '"+ ar_tex_bus + "', " + ar_cri_ter ;
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

            /// <summary>
            /// Funcion externa reporte: PERIODOS DE UNA GESTION
            /// </summary>
            /// <param name="ar_ges_tio"></param>
            /// <returns></returns>
        public DataTable Fe_ads005_R01(int ar_ide_mod, string ar_est_ado)
        {   
            cadena = " ads005_R01 " + ar_ide_mod + ", '" + ar_est_ado + "'" ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

     
    }
}
