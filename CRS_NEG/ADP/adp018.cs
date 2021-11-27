using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    /// <summary>
    /// Clase GUPO EMPRESARIAL
    /// </summary>
    public class adp018
    {
        //######################################################################
        //##       Tabla: adp018                                              ##
        //##      Nombre: GUPO EMPRESARIAL                                    ##
        //## Descripcion: Grupo Empresarial                                   ##         
        //##       Autor: JEJR  - (30-08-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="gru_emp">Código Grupo Empresarial</param>
        /// <param name="nom_gru">Nombre</param>
        /// <param name="ban_fac">Datos de Facturación (0=Cliente; 1=Grupo Empresarial)</param>
        /// <param name="nom_fac">Nombre a Facturar</param>
        /// <param name="ruc_nit">RUC/NIT</param>
        /// <param name="dir_ent">Dirección de Entregas d/Factura</param>
        /// <returns></returns>
        public void Fe_nue_reg(int gru_emp, string nom_gru, int ban_fac, string nom_fac, long ruc_nit, string dir_ent)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp018 VALUES (" + gru_emp + ", '" + nom_gru + "', " + ban_fac + ", '" + nom_fac + "',");
                cadena.AppendLine("                           " + ruc_nit + ", '" + dir_ent + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="gru_emp">Código Grupo Empresarial</param>
        /// <param name="nom_gru">Nombre</param>
        /// <param name="ban_fac">Datos de Facturación (0=Cliente; 1=Grupo Empresarial)</param>
        /// <param name="nom_fac">Nombre a Facturar</param>
        /// <param name="ruc_nit">RUC/NIT</param>
        /// <param name="dir_ent">Dirección de Entregas d/Factura</param>
        /// <returns></returns>
        public void Fe_edi_tar(int gru_emp, string nom_gru, int ban_fac, string nom_fac, long ruc_nit, string dir_ent)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp018 SET va_nom_gru = '" + nom_gru + "', va_ban_fac = " + ban_fac + ",");
                cadena.AppendLine("                  va_nom_fac = '" + nom_fac + "', va_ruc_nit = " + ruc_nit + ",");
                cadena.AppendLine("                  va_dir_ent = '" + ban_fac + "'");
                cadena.AppendLine("            WHERE va_gru_emp =  " + gru_emp + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="gru_emp">ID. Grupo Empresarial</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int gru_emp, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp018 SET va_est_ado = '" + est_ado + "' WHERE va_gru_emp = " + gru_emp + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA GRUPO EMPRESARIALS"
        /// </summary>
        /// <param name="gru_emp">ID. Grupo Empresarial</param>
        /// <returns></returns>
        public void Fe_eli_min(int gru_emp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp018 WHERE va_gru_emp = " + gru_emp + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="gru_emp">ID. Grupo Empresarial</param>
        /// <returns></returns>
        public DataTable Fe_con_cod(int gru_emp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_gru_emp, va_nom_gru, va_ban_fac,");
                cadena.AppendLine("       va_nom_fac, va_ruc_nit, va_dir_ent,");
                cadena.AppendLine("       va_est_ado");
                cadena.AppendLine("  FROM adp018");
                cadena.AppendLine(" WHERE va_gru_emp = " + gru_emp + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA GRUPO EMPRESARIAL POR NOMBRE"
        /// </summary>        
        /// <param name="nom_gru">Nombre Relación p/Hombre</param>
        /// <param name="gru_emp">ID. Grupo Empresarial</param>
        /// <returns></returns>
        public DataTable Fe_nom_gru(string nom_gru, int gru_emp = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_gru_emp, va_nom_gru, va_ban_fac,");
                cadena.AppendLine("       va_nom_fac, va_ruc_nit, va_dir_ent,");
                cadena.AppendLine("       va_est_ado");
                cadena.AppendLine("  FROM adp018");
                cadena.AppendLine(" WHERE va_nom_gru = '" + nom_gru + "'");
                if (gru_emp > 0)
                    cadena.AppendLine(" AND va_gru_emp <> " + gru_emp + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_gru_emp; 1=va_nom_gru; 2=va_nom_fac; 3=va_ruc_nit)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_gru_emp, va_nom_gru, va_ban_fac,");
                cadena.AppendLine("       va_nom_fac, va_ruc_nit, va_dir_ent,");
                cadena.AppendLine("       va_est_ado");
                cadena.AppendLine("  FROM adp018");

                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_gru_emp LIKE '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_gru LIKE '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" WHERE va_nom_fac LIKE '" + cri_bus + "%'"); break;
                    case 3: cadena.AppendLine(" WHERE va_ruc_nit LIKE '" + cri_bus + "%'"); break;


                }
                switch (est_bus){
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                    cadena.AppendLine(" AND va_est_ado ='" + est_bus + "'");                

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_rel(string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_gru_emp, va_nom_gru, va_ban_fac,");
                cadena.AppendLine("       va_nom_fac, va_ruc_nit, va_dir_ent,");
                cadena.AppendLine("       va_est_ado");
                cadena.AppendLine("  FROM adp018");
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")              
                    cadena.AppendLine(" WHERE va_est_ado = '" + est_bus + "'");
                
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "OBTIENE ULTIMO ID. GRUPO EMPRESARIAL"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_gru_emp INT ");
                cadena.AppendLine(" SELECT @va_gru_emp = ISNULL(MAX(va_gru_emp), 0) FROM adp018");
                cadena.AppendLine(" SELECT @va_gru_emp + 1 AS va_gru_emp");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
