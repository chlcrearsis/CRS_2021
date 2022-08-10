using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp009 - Permiso Lista de Precio p/Persona            */
    /* Descripción: Permiso de Lista de Precio p/Persona                  */
    /*       Autor: JEJR - Crearsis             Fecha: 21-10-2021         */
    /**********************************************************************/
    public class adp009
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA PERMISO DE LISTA DE PRECIO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="cod_lis">Código de Lista de Precio</param>
        /// <returns></returns>
        public void Fe_nue_reg(int cod_per, int cod_lis)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp009 VALUES (" + cod_per + ", " + cod_lis + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA PERMISO DE LISTA DE PRECIO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="cod_lis">Código de Lista de Precio</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_per, int cod_lis)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp009 WHERE va_cod_per = " + cod_per + " AND va_cod_lis = " + cod_lis + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA PERMISO DE LISTA DE PRECIO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_lis_per(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp009_01a_p01 " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA PERMISO DE LISTA DE PRECIO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp009_R01 " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
