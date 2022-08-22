using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads001                                              ##
    //##      Nombre: Modulo                                              ##
    //## Descripcion: Modulos del Sistema                                 ##         
    //##       Autor: CHL - (07-11-2019)                                  ##
    //######################################################################
    public class ads001
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;                

        /// <summary>
        /// Funcion "Registrar Modulos del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="nom_mod">Nombre</param>
        /// <param name="abr_mod">Abrebiacion</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ide_mod , string nom_mod , string abr_mod)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads001 VALUES (" + ide_mod + ", '" + nom_mod + "', '" + abr_mod + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Modulos del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="nom_mod">Nombre</param>
        /// <param name="abr_mod">Abrebiacion</param>
        /// <returns></returns>
        public void Fe_edi_tar(int ide_mod , string nom_mod , string abr_mod )
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads001 SET va_nom_mod = '" + nom_mod + "', va_abr_mod = '" + abr_mod + "' WHERE va_ide_mod = " + ide_mod + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Modulos del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_mod, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads001 SET va_est_ado = '" + est_ado + "' WHERE va_ide_mod = " + ide_mod + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Modulos del Sistema"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads001 WHERE va_ide_mod = " + ide_mod + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA MÓDULOS DEL SISTEMA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_mod; 1=va_nom_mod; 2=va_abr_mod)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_mod, va_nom_mod, va_abr_mod, va_est_ado");
                cadena.AppendLine("  FROM ads001");
                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" WHERE va_ide_mod like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_mod like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" WHERE va_abr_mod like '" + cri_bus + "%'"); break;
                }
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND va_est_ado = '" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "MODULOS DEL SISTEMA"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_mod(int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_mod, va_nom_mod, va_abr_mod, va_est_ado");
                cadena.AppendLine("  FROM ads001");
                cadena.AppendLine(" WHERE va_ide_mod = " + ide_mod + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA MODULOS DEL SISTEMA POR NOMBRE"
        /// </summary>
        /// <param name="nom_mod">Nombre</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_mod, int ide_mod = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_mod, va_nom_mod, va_abr_mod, va_est_ado");
                cadena.AppendLine("  FROM ads001");
                cadena.AppendLine(" WHERE va_nom_mod = '" + nom_mod + "'");
                if (ide_mod > 0)
                    cadena.AppendLine(" AND va_ide_mod <> " + ide_mod + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA MODULOS DEL SISTEMA POR ABREVIACIÓN"
        /// </summary>
        /// <param name="abr_mod">Abreviación</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_con_abr(string abr_mod, int ide_mod = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_mod, va_nom_mod, va_abr_mod, va_est_ado");
                cadena.AppendLine("  FROM ads001");
                cadena.AppendLine(" WHERE va_abr_mod = '" + abr_mod + "'");
                if (ide_mod > 0)
                    cadena.AppendLine(" AND va_ide_mod <> " + ide_mod + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "LISTA MÓDULO DEL SISTEMA"
        /// </summary>
        /// <param name="est_ado">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_mod(string est_ado = "0")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_mod, va_nom_mod, va_abr_mod, va_est_ado");
                cadena.AppendLine("  FROM ads001");
                switch (est_ado)
                {
                    case "0": est_ado = "T"; break;
                    case "1": est_ado = "H"; break;
                    case "2": est_ado = "N"; break;
                }

                if (est_ado != "T")
                    cadena.AppendLine(" WHERE va_est_ado = '" + est_ado + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "OBTIENE ULTIMO ID. MÓDULO DEL SISTEMA"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_mod INT ");
                cadena.AppendLine(" SELECT @va_ide_mod = ISNULL(MAX(va_ide_mod), 0) FROM ads001");
                cadena.AppendLine(" SELECT @va_ide_mod + 1 AS va_ide_mod");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Módulo del Sistema 
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads001_R01 '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
    }
}