using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp012 - Asignación Persona a Grupo Empresarial       */
    /* Descripción: Relación de Personas a Grupo Empresarial              */
    /*       Autor: JEJR - Crearsis             Fecha: 13-11-2021         */
    /**********************************************************************/
    public class adp012
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA ASIG. GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="gru_emp">Codigo Grupo Empresarial</param>
        /// <returns></returns>
        public void Fe_nue_reg(int cod_per, int gru_emp)
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
        /// Funcion "ELIMINA ASIG. GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="gru_emp">Codigo Grupo Empresarial</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_per, int gru_emp)
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
        /// Funcion "ELIMINA ASIG. GRUPO EMPRESARIAL P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_per)
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
        /// Funcion "CONSULTA ASIG. GRUPO EMPRESARIAL"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <param name="gru_per">Código Grupo Empresarial</param>
        /// <returns></returns>
        public DataTable Fe_con_rel(int cod_per, int gru_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp012.va_cod_per, adp002.va_raz_soc, adp012.va_gru_emp, adp018.va_nom_gru");
                cadena.AppendLine("  FROM adp012, adp002, adp018");
                cadena.AppendLine(" WHERE adp012.va_cod_per = adp002.va_cod_per");
                cadena.AppendLine("   AND adp012.va_gru_emp = adp018.va_gru_emp");
                cadena.AppendLine("   AND adp012.va_cod_per = " + cod_per + "");
                cadena.AppendLine("   AND adp012.va_gru_emp = " + gru_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA ASIG. GRUPO EMPRESARIAL P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_per(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp012.va_cod_per, adp002.va_raz_soc, adp012.va_gru_emp, adp018.va_nom_gru");
                cadena.AppendLine("  FROM adp012, adp002, adp018");
                cadena.AppendLine(" WHERE adp012.va_cod_per = adp002.va_cod_per");
                cadena.AppendLine("   AND adp012.va_gru_emp = adp018.va_gru_emp");
                cadena.AppendLine("   AND adp012.va_cod_per = " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA ASIG. GRUPO EMPRESARIAL P/GRUPO"
        /// </summary>
        /// <param name="gru_per">Código Grupo Empresarial</param>
        /// <returns></returns>
        public DataTable Fe_con_gru(int gru_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp012.va_cod_per, adp002.va_raz_soc, adp012.va_gru_emp, adp018.va_nom_gru");
                cadena.AppendLine("  FROM adp012, adp002, adp018");
                cadena.AppendLine(" WHERE adp012.va_cod_per = adp002.va_cod_per");
                cadena.AppendLine("   AND adp012.va_gru_emp = adp018.va_gru_emp");
                cadena.AppendLine("   AND adp012.va_gru_emp = " + gru_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
