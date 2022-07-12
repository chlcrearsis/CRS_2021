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
    /// Clase: GESTION PERIODO
    /// </summary>
    public class ads016
    {
        //######################################################################
        //##       Tabla: ads016                                              ##
        //##      Nombre: Gestion/Periodo                                     ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (26-03-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;
        string cadena = "";

        public ads016()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        public void Fe_crea(int ar_ges_tio, int ar_per_ini)
        {
            cadena = " Execute ads016_02a_p01 " + ar_ges_tio + "," + ar_per_ini;
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_cre_per(int ar_ges_tio, int ar_per_ini, string ar_nom_per, DateTime ar_fec_ini, DateTime ar_fec_fin)
        {
            cadena = " INSERT INTO ads016 VALUES( " + ar_ges_tio + "," + ar_per_ini + ", '" + ar_nom_per + "','"+ 
                        ar_fec_ini + "','" + ar_fec_fin + "' )";
            ob_con_ecA.fe_exe_sql(cadena);
        }
        public void Fe_sig_ges(int ar_ges_tio)
        {
            cadena = " Execute ads016_02b_p01 " + ar_ges_tio ;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_edi_per(int ar_ges_tio, int ar_per_ini, string ar_nom_per, DateTime ar_fec_ini, DateTime ar_fec_fin)
        {
            cadena = " UPDATE ads016 SET va_nom_per = '" + ar_nom_per + "', va_fec_ini = '" + ar_fec_ini + "'," +
                    " va_fec_fin = '" + ar_fec_fin + "'" +
                    " WHERE va_ges_tio = " + ar_ges_tio + " AND va_ges_per = " + ar_per_ini;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_eli_per(int ar_ges_tio, int ar_per_ini)
        {
            cadena = " DELETE ads016 " +
                    " WHERE va_ges_tio = " + ar_ges_tio + " AND va_ges_per = " + ar_per_ini;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_obt_ges()
        {
            cadena = " SELECT va_ges_tio FROM ads016";
            cadena += " GROUP BY va_ges_tio ";
            cadena += " ORDER BY va_ges_tio DESC ";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Obtiene la gestion de una fecha
        /// </summary>
        /// <returns>Retorna la gestion de la fecha proporcionada</returns>
        public DataTable Fe_obt_ges(DateTime ar_fec_ha)
        {
            cadena = " select * from ads016 ";
            cadena += " where va_fec_ini <= '"+ ar_fec_ha.ToString("dd/MM/yyyy") + "' ";
            cadena += " and va_fec_fin >= '" + ar_fec_ha.ToString("dd/MM/yyyy") + "' ";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_per(int ar_ges_tio , int ar_ges_per)
        {
            cadena = " SELECT * FROM ads016";
            cadena += " WHERE va_ges_tio =" + ar_ges_tio;
            cadena += " AND va_ges_per = " + ar_ges_per;
            
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public int Fe_ult_ges()
        {
            DataTable tabla = new DataTable();
            int res_ult = 0;
            cadena = "";
            cadena = " SELECT  ISNULL(MAX(va_ges_tio),0) AS va_ges_tio FROM ads016";
            
            tabla = ob_con_ecA.fe_exe_sql(cadena);
            if (tabla.Rows.Count > 0 )
                res_ult = int.Parse(tabla.Rows[0][0].ToString());

            return res_ult;
        }

        public DataTable Fe_bus_car(int ar_ges_tio)
        {
            cadena = " SELECT * FROM ads016 ";
            cadena += " WHERE va_ges_tio = " + ar_ges_tio;
            cadena += " ORDER BY va_ges_tio, va_ges_per DESC ";
            
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        //** FUNCIONES DE REPORTES

            /// <summary>
            /// Funcion externa reporte: PERIODOS DE UNA GESTION
            /// </summary>
            /// <param name="ar_ges_tio"></param>
            /// <returns></returns>
        public DataTable Fe_ads016_R01(int ar_ges_tio)
        {
            cadena = " ads016_R01 " + ar_ges_tio;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Obtiene listado de todas las gestiones
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ads016_R02()
        {
            cadena = " ads016_R02 ";

            return ob_con_ecA.fe_exe_sql(cadena);
        }
    }
}
