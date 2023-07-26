using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads002                                              ##
    //##      Nombre: Aplicaciones                                        ##
    //## Descripcion: Aplicaciones del Sistema                            ##         
    //##       Autor: CHL  - (07-04-2020)                                 ##
    //######################################################################
    public class ads002
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar Aplicaciones del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_apl">ID. Aplicaciones</param>
        /// <param name="nom_apl">Nombre</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ide_mod, string ide_apl, string nom_apl)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads002 VALUES (" + ide_mod + ", '" + ide_apl + "', '" + nom_apl + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Aplicaciones del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_apl">ID. Aplicaciones</param>
        /// <param name="nom_apl">Nombre</param>
        /// <returns></returns>
        public void Fe_edi_tar(int ide_mod, string ide_apl, string nom_apl)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads002 SET va_nom_apl = '" + nom_apl + "' WHERE va_ide_mod = " + ide_mod + " AND va_ide_apl = '" + ide_apl + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Aplicaciones del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_apl">ID. Aplicaciones</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_mod, string ide_apl, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads002 SET va_est_ado = '" + est_ado + "' WHERE va_ide_mod = " + ide_mod + " AND va_ide_apl = '" + ide_apl + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Aplicaciones del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_apl">ID. Aplicaciones</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_mod, string ide_apl)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads002 WHERE va_ide_mod = " + ide_mod + " AND va_ide_apl = '" + ide_apl + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA APLICACIONES DEL SISTEMA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_apl; 1=va_nom_apl; 2=va_nom_mod)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {           
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads002.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl,");
                cadena.AppendLine("       ads002.va_nom_apl, ads002.va_est_ado");
                cadena.AppendLine("  FROM ads002, ads001");
                cadena.AppendLine(" WHERE ads002.va_ide_mod = ads001.va_ide_mod");
                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" AND ads002.va_ide_apl like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND ads002.va_nom_apl like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" AND ads001.va_nom_mod like '" + cri_bus + "%'"); break;                                        
                }
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND ads002.va_est_ado = '" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "APLICACIONES POR MODULOS DEL SISTEMA"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado; T=Todos)</param>
        /// <returns></returns>
        public DataTable Fe_con_mod(int ide_mod, string est_ado = "T")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads002.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl,");
                cadena.AppendLine("       ads002.va_nom_apl, ads002.va_est_ado");
                cadena.AppendLine("  FROM ads002, ads001");
                cadena.AppendLine(" WHERE ads002.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads002.va_ide_mod = " + ide_mod + "");
                if (est_ado.CompareTo("T") != 0)
                    cadena.AppendLine("   AND ads002.va_est_ado = '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA APLICACIONES DEL SISTEMA POR ID. MODULOS Y APLICACIONES"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_apl">ID. Aplicaciones</param>
        /// <returns></returns>
        public DataTable Fe_con_apl(int ide_mod, string ide_apl)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads002.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl,");
                cadena.AppendLine("       ads002.va_nom_apl, ads002.va_est_ado");
                cadena.AppendLine("  FROM ads002, ads001");
                cadena.AppendLine(" WHERE ads002.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads002.va_ide_mod = " + ide_mod + "");
                cadena.AppendLine("   AND ads002.va_ide_apl = '" + ide_apl + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA APLICACIONES DEL SISTEMA POR ID. APLICACIONES"
        /// </summary>
        /// <param name="ide_apl">ID. Aplicaciones</param>
        /// <returns></returns>
        public DataTable Fe_con_apl(string ide_apl)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads002.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl,");
                cadena.AppendLine("       ads002.va_nom_apl, ads002.va_est_ado");
                cadena.AppendLine("  FROM ads002, ads001");
                cadena.AppendLine(" WHERE ads002.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads002.va_ide_apl = '" + ide_apl + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA APLICACIONES DEL SISTEMA POR NOMBRE"
        /// </summary>
        /// <param name="nom_apl">Nombre</param>
        /// <param name="ide_apl">ID. Aplicaciones</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_apl, string ide_apl = "0")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads002.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl,");
                cadena.AppendLine("       ads002.va_nom_apl, ads002.va_est_ado");
                cadena.AppendLine("  FROM ads002, ads001");
                cadena.AppendLine(" WHERE ads002.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads002.va_nom_apl = '" + nom_apl + "'");
                if (ide_apl != "0")
                    cadena.AppendLine("   AND ads002.va_ide_apl <> '" + ide_apl + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "LISTA APLICACIÓN DEL SISTEMA"
        /// </summary>
        /// <param name="est_ado">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_apl(string est_ado = "0")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads002.va_ide_mod, ads001.va_nom_mod, ads002.va_ide_apl,");
                cadena.AppendLine("       ads002.va_nom_apl, ads002.va_est_ado");
                cadena.AppendLine("  FROM ads002, ads001");
                cadena.AppendLine(" WHERE ads002.va_ide_mod = ads001.va_ide_mod");
                switch (est_ado)
                {
                    case "0": est_ado = "T"; break;
                    case "1": est_ado = "H"; break;
                    case "2": est_ado = "N"; break;
                }

                if (est_ado != "T")
                    cadena.AppendLine(" AND ads002.va_est_ado = '" + est_ado + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Aplicaciones del Sistema
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="mod_ini">ID. Módulo Inicial</param>
        /// <param name="mod_fin">ID. Módulo Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string est_ado, int mod_ini, int mod_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads002_R01 '" + est_ado + "', " + mod_ini + ", " + mod_fin + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
