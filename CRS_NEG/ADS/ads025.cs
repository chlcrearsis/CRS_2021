using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase BITACORA P/OPERACIONES
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class ads025
    {
        //######################################################################
        //##       Tabla: ads025                                              ##
        //##      Nombre: BITACORA P/OPERACIONES                              ##
        //## Descripcion: Informe Bitacora p/Operaciones                      ##         
        //##       Autor: JEJR  - (23-09-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA BITACORA P/OPERACIONES"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="fch_reg">Fecha y Hora de Registro</param>
        /// <param name="nom_apl">Nombre de Aplicación</param>
        /// <param name="tip_ope">Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza)</param>
        /// <param name="nom_maq">Nombre de Equipo</param>
        /// <param name="obs_reg">Observación</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_usr, string fch_reg, string nom_apl, 
                               string tip_ope, string nom_maq, string obs_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads025 VALUES ('" + ide_usr + "', '" + fch_reg + "', '" + nom_apl + "',");
                cadena.AppendLine("                           '" + tip_ope + "', '" + nom_maq + "', '" + obs_reg + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA BITACORA DE OPERACIONES POR USUARIO"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_con_usr(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_fch_reg, va_nom_apl, va_tip_ope,");
                cadena.AppendLine("       va_nom_maq, va_obs_reg");
                cadena.AppendLine("  FROM ads025");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA BITACORA DE OPERACIONES POR USUARIO Y FECHA"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="fch_reg">Fecha de Registro (Formato dd/MM/yyyy)</param>
        /// <returns></returns>
        public DataTable Fe_usr_fch(string ide_usr, string fch_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_fch_reg, va_nom_apl, va_tip_ope,");
                cadena.AppendLine("       va_nom_maq, va_obs_reg");
                cadena.AppendLine("  FROM ads025");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND CONVERT(CHAR(10), va_fch_reg, 103) = '" + fch_reg + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA BITACORA DE OPERACIONES POR USUARIO Y RANGO DE FECHA"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="fch_ini">Fecha Inicial (Formato dd/MM/yyyy)</param>
        /// <param name="fch_ini">Fecha Final (Formato dd/MM/yyyy)</param>
        /// <returns></returns>
        public DataTable Fe_usr_fch(string ide_usr, string fch_ini, string fch_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_fch_reg, va_nom_apl, va_tip_ope,");
                cadena.AppendLine("       va_nom_maq, va_obs_reg");
                cadena.AppendLine("  FROM ads025");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_fch_reg BETWEEN '" + fch_ini + "00:00:00' AND '" + fch_fin + "23:59:59'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA BITACORA DE OPERACIONES POR USUARIO Y RANGO APLICACIÓN"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="apl_ini">Aplicación Inicial</param>
        /// <param name="apl_fin">Aplicación Final</param>
        /// <returns></returns>
        public DataTable Fe_usr_apl(string ide_usr, string apl_ini, string apl_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_fch_reg, va_nom_apl, va_tip_ope,");
                cadena.AppendLine("       va_nom_maq, va_obs_reg");
                cadena.AppendLine("  FROM ads025");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_nom_apl BETWEEN '" + apl_ini + "' AND '" + apl_fin + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA BITACORA DE OPERACIONES POR USUARIO Y TIPO DE OPERACIÓN"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="tip_ope">Tipo de Operación</param>
        /// <returns></returns>
        public DataTable Fe_usr_apl(string ide_usr, string tip_ope)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_fch_reg, va_nom_apl, va_tip_ope,");
                cadena.AppendLine("       va_nom_maq, va_obs_reg");
                cadena.AppendLine("  FROM ads025");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_tip_ope = '" + tip_ope + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
