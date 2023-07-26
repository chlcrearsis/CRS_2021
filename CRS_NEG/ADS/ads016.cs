using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
using Microsoft.SqlServer.Server;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads004                                              ##
    //##      Nombre: Gestión Periodo                                     ##
    //## Descripcion: Gestión Periodo                                     ##         
    //##       Autor: CHL  - (26-03-2020)                                 ##
    //######################################################################
    public class ads016
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar Primera Gestión"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="per_ini">Periodo Inicial</param>
        public void Fe_nue_ges(int ges_tio, int per_ini)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads016_02a_p01 " + ges_tio + ", " + per_ini + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Registrar Siguiente Gestión"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        public void Fe_sig_ges(int ges_tio)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads016_02b_p01 " + ges_tio + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Registrar Periodo"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ges_per">Periodo</param>
        /// <param name="nom_per">Nombre</param>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        public void Fe_nue_reg(int ges_tio, int ges_per, string nom_per, string fec_ini, string fec_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads016 VALUES (" + ges_tio + ", " + ges_per + ", '" + nom_per + "', '" + fec_ini + "', '" + fec_fin + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Funcion "Modifica Periodo"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ges_per">Periodo</param>
        /// <param name="nom_per">Nombre</param>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        public void Fe_edi_tar(int ges_tio, int ges_per, string nom_per, string fec_ini, string fec_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads016 SET va_nom_per = '" + nom_per + "',");
                cadena.AppendLine("                  va_fec_ini = '" + fec_ini + "',");
                cadena.AppendLine("                  va_fec_fin = '" + fec_fin + "'");
                cadena.AppendLine("            WHERE va_ges_tio =  " + ges_tio + "");
                cadena.AppendLine("              AND va_ges_per =  " + ges_per + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Periodo"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ges_per">Periodo</param>
        public void Fe_eli_min(int ges_tio, int ges_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads016 WHERE va_ges_tio = " + ges_tio + " AND va_ges_per = " + ges_per + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función "Filtra Gestión Periodo"
        /// </summary>
        /// <param name="cri_bus">Criterio de Búsqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ges_tio; 1=va_nom_per)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ges_tio, va_ges_per, va_nom_per,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin");
                cadena.AppendLine("  FROM ads016");
                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" WHERE va_ges_tio like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_per like '" + cri_bus + "%'"); break;
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Función "Obtiene Gestión p/Fecha"
        /// </summary>
        /// <param name="fch_per">Fecha Periodo</param>
        /// <returns></returns>
        public DataTable Fe_ges_fec(string fch_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ges_tio, va_ges_per, va_nom_per,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin");
                cadena.AppendLine("  FROM ads016");
                cadena.AppendLine(" WHERE va_fec_ini <= '" + fch_per + "'");
                cadena.AppendLine("   AND va_fec_fin >= '" + fch_per + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función "Consulta Gestión Periodo"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ges_per">Periodo</param>
        /// <returns></returns>
        public DataTable Fe_con_per(int ges_tio , int ges_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ges_tio, va_ges_per, va_nom_per,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin");
                cadena.AppendLine("  FROM ads016");
                cadena.AppendLine(" WHERE va_ges_tio = " + ges_tio + "");
                cadena.AppendLine("   AND va_ges_per = " + ges_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función "Consulta Periodo p/Gestión"
        /// </summary>
        /// <param name="ges_tio"></param>
        /// <returns></returns>
        public DataTable Fe_con_ges(int ges_tio)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ges_tio, va_ges_per, va_nom_per,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin");
                cadena.AppendLine("  FROM ads016");
                cadena.AppendLine(" WHERE va_ges_tio = " + ges_tio + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Función "Consulta Periodo p/Gestión y Nombre"
        /// </summary>
        /// <param name="nom_per">Nombre</param>
        /// <param name="ges_tio">Gestion</param>
        /// <param name="ges_per">Periodo</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_per, int ges_tio, int ges_per = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ges_tio, va_ges_per, va_nom_per,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin");
                cadena.AppendLine("  FROM ads016");
                cadena.AppendLine(" WHERE va_ges_tio =  " + ges_tio + "");
                cadena.AppendLine("   AND va_nom_per = '" + nom_per + "'");
                if (ges_per > 0)
                    cadena.AppendLine(" AND va_ges_per <> " + ges_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función "Lista Gestión"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_lis_ges()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ges_tio, va_ges_per, va_nom_per,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_ini, 103) AS va_fec_ini,");
                cadena.AppendLine("       CONVERT(CHAR(10), va_fec_fin, 103) AS va_fec_fin");
                cadena.AppendLine("  FROM ads016");
                cadena.AppendLine(" ORDER BY va_ges_tio, va_ges_per DESC");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función "Obtiene Nueva Gestión"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_nue_ges()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ges_tio INT ");
                cadena.AppendLine(" SELECT @va_ges_tio = ISNULL(MAX(va_ges_tio), 0) FROM ads016");
                cadena.AppendLine(" SELECT @va_ges_tio + 1 AS va_ges_tio");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función "Obtiene Primera Gestión"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_pri_ges()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ges_tio INT ");
                cadena.AppendLine(" SELECT @va_ges_tio = ISNULL(MIN(va_ges_tio), 0) FROM ads016");
                cadena.AppendLine(" SELECT @va_ges_tio AS va_ges_tio");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función "Obtiene Ultima Gestión"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_ult_ges()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ges_tio INT ");
                cadena.AppendLine(" SELECT @va_ges_tio = ISNULL(MAX(va_ges_tio), 0) FROM ads016");
                cadena.AppendLine(" SELECT @va_ges_tio AS va_ges_tio");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Informe: Periodo de Una Gestión 
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ord_dat">Orden Datos (P=Periodo; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int ges_tio, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads016_R01 " + ges_tio + ", '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Todas las Gestiones 
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_inf_R02()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads016_R02");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
