using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase RELACIÓN DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp012
    {
        //######################################################################
        //##       Tabla: adp012                                              ##
        //##      Nombre: RELACIÓN DE PERSONA                                 ##
        //## Descripcion: Personas Relacionadas a Grupo Empresarial           ##         
        //##       Autor: JEJR  - (13-11-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA RELACIÓN DE PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="gru_emp">Codigo Grupo Empresarial</param>
        /// <returns></returns>
        public void Fe_reg_rel(int cod_per, int gru_emp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp012 VALUES (" + cod_per + ", " + gru_emp + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA RELACIÓN DE PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="gru_emp">Codigo Grupo Empresarial</param>
        /// <returns></returns>
        public void Fe_eli_rel(int cod_per, int gru_emp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp012 WHERE va_cod_per = " + cod_per + " AND va_gru_emp = " + gru_emp + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA RELACIÓN DE PERSONA P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public void Fe_eli_rel(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp012 WHERE va_cod_per = " + cod_per + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA RELACIÓN DE PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <param name="gru_per">Código Grupo Empresarial</param>
        /// <returns></returns>
        public DataTable Fe_con_rel(int cod_per, int gru_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_per_ide, va_gru_per");
                cadena.AppendLine("  FROM ad012");
                cadena.AppendLine(" WHERE va_per_ide = " + cod_per + "");
                cadena.AppendLine("   AND va_gru_per = " + gru_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA RELACIÓN DE PERSONA P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_per(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_per_ide, va_gru_per");
                cadena.AppendLine("  FROM ad012");
                cadena.AppendLine(" WHERE va_per_ide = " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA RELACIÓN DE PERSONA P/GRUPO"
        /// </summary>
        /// <param name="gru_per">Código Grupo Empresarial</param>
        /// <returns></returns>
        public DataTable Fe_con_gru(int gru_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_per_ide, va_gru_per");
                cadena.AppendLine("  FROM ad012");
                cadena.AppendLine(" WHERE va_gru_per = " + gru_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
