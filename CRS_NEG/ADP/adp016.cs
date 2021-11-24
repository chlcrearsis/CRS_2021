using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase INSCRIPCIÓN AUTOMATICA LIBRETA P/GRUPO DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp016
    {
        //######################################################################
        //##       Tabla: adp016                                              ##
        //##      Nombre: INSCRIPCIÓN LIBRETA P/GRUPO DE PERSONA              ##
        //## Descripcion: Inscripción Automatica de Libros a Grupos de Perona ##         
        //##       Autor: JEJR  - (08-11-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA INSCRIPCIÓN LIBRETA P/GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_gru">Código de Grupo de Persona</param>
        /// <param name="cod_lib">Código de la Libreta</param>
        /// <returns></returns>
        public void Fe_nue_reg(int cod_gru, int cod_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp016 VALUES (" + cod_gru + ", " + cod_lib + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA INSCRIPCIÓN LIBRETA P/GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_gru">Código de Grupo de Persona</param>
        /// <param name="cod_lib">Código de la Libreta</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_gru, int cod_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp016 WHERE va_cod_gru = " + cod_gru + " AND va_cod_lib = " + cod_lib + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA INSCRIPCIÓN LIBRETA P/GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_gru">Código de Grupo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_lis_lib(int cod_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp016_01a_p01 " + cod_gru + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
