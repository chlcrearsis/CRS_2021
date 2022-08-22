using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads003                                              ##
    //##      Nombre: Definición de Documento                             ##
    //## Descripcion: Definición de Documento del Sistema                 ##         
    //##       Autor: CHL  - (07-04-2020)                                 ##
    //######################################################################
    public class ads003
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar Documentos"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nom_doc">Nombre</param>
        /// <param name="des_doc">Descripción</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ide_mod, string ide_doc, string nom_doc, string des_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads003 VALUES (" + ide_mod + ", '" + ide_doc + "', '" + nom_doc + "', '" + des_doc + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Documentos"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nom_doc">Nombre</param>
        /// <param name="des_doc">Descripción</param>
        /// <returns></returns>
        public void Fe_edi_tar(int ide_mod, string ide_doc, string nom_doc, string des_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads003 SET va_nom_doc = '" + nom_doc + "', va_des_doc = '" + des_doc + "' WHERE va_ide_mod = " + ide_mod + " AND va_ide_doc = '" + ide_doc + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Documentos"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_mod, string ide_doc, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads003 SET va_est_ado = '" + est_ado + "' WHERE va_ide_mod = " + ide_mod + " AND va_ide_doc = '" + ide_doc + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Documentos"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_mod, string ide_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads003 WHERE va_ide_mod = " + ide_mod + " AND va_ide_doc = '" + ide_doc + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA DOCUMENTOS"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_doc; 1=va_nom_doc; 2=va_des_doc)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>       
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads003.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,");
                cadena.AppendLine("       ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado");
                cadena.AppendLine("  FROM ads003, ads001");
                cadena.AppendLine(" WHERE ads003.va_ide_mod = ads001.va_ide_mod");
                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" AND ads003.va_ide_doc like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND ads003.va_nom_doc like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" AND ads001.va_des_doc like '" + cri_bus + "%'"); break;
                }
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND ads003.va_est_ado = '" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "DOCUMENTOS POR MODULOS DEL SISTEMA"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_mod(int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads003.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,");
                cadena.AppendLine("       ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado");
                cadena.AppendLine("  FROM ads003, ads001");
                cadena.AppendLine(" WHERE ads003.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads003.va_ide_mod = " + ide_mod + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA DOCUMENTOS POR ID. MODULOS Y DOCUMENTOS"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <returns></returns>
        public DataTable Fe_con_doc(int ide_mod, string ide_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads003.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,");
                cadena.AppendLine("       ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado");
                cadena.AppendLine("  FROM ads003, ads001");
                cadena.AppendLine(" WHERE ads003.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads003.va_ide_mod = " + ide_mod + "");
                cadena.AppendLine("   AND ads003.va_ide_doc = '" + ide_doc + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA DOCUMENTOS POR ID. DOCUMENTOS"
        /// </summary>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <returns></returns>
        public DataTable Fe_con_doc(string ide_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads003.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,");
                cadena.AppendLine("       ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado");
                cadena.AppendLine("  FROM ads003, ads001");
                cadena.AppendLine(" WHERE ads003.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads003.va_ide_doc = '" + ide_doc + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA DOCUMENTOS POR NOMBRE"
        /// </summary>
        /// <param name="nom_doc">Nombre</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_doc, string ide_doc = "0")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads003.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,");
                cadena.AppendLine("       ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado");
                cadena.AppendLine("  FROM ads003, ads001");
                cadena.AppendLine(" WHERE ads003.va_ide_mod = ads001.va_ide_mod");
                cadena.AppendLine("   AND ads003.va_nom_doc = '" + nom_doc + "'");
                if (ide_doc != "0")
                    cadena.AppendLine("   AND ads003.va_ide_doc <> '" + ide_doc + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "LISTA DOCUMENTOS"
        /// </summary>
        /// <param name="est_ado">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_doc(string est_ado = "0")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads003.va_ide_mod, ads001.va_nom_mod, ads003.va_ide_doc,");
                cadena.AppendLine("       ads003.va_nom_doc, ads003.va_des_doc, ads003.va_est_ado");
                cadena.AppendLine("  FROM ads003, ads001");
                cadena.AppendLine(" WHERE ads003.va_ide_mod = ads001.va_ide_mod");
                switch (est_ado)
                {
                    case "0": est_ado = "T"; break;
                    case "1": est_ado = "H"; break;
                    case "2": est_ado = "N"; break;
                }

                if (est_ado != "T")
                    cadena.AppendLine(" AND ads003.va_est_ado = '" + est_ado + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Documentos Internos del Sistema
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
                cadena.AppendLine("EXECUTE ads003_R01 '" + est_ado + "', " + mod_ini + ", " + mod_fin + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
