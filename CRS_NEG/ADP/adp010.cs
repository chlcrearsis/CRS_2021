using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase DESCUENTO GENERAL P/PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp010
    {
        //######################################################################
        //##       Tabla: adp009                                              ##
        //##      Nombre: DESCUENTO GENERAL P/PERSONA                         ##
        //## Descripcion: Descuento General p/Pesona sobre el Precio Neto     ##         
        //##       Autor: JEJR  - (14-07-2022)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA DESCUENTO GENERAL P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="tip_fac">p/Factura (S=Si; N=No)</param>
        /// <param name="tip_ndv">p/Nota de Venta (S=Si; N=No)</param>
        /// <param name="por_con">Porcentaje Descuento p/Contado</param>
        /// <param name="por_cre">Porcentaje Descuento p/Crédito</param>
        /// <returns></returns>
        public void Fe_nue_reg(int cod_per, string tip_fac, string tip_ndv, decimal por_con, decimal por_cre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp010 VALUES (" + cod_per + ", '" + tip_fac + "', '" + tip_ndv + "', " + por_con + ", " + por_cre + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "EDITA DESCUENTO GENERAL P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="tip_fac">p/Factura (S=Si; N=No)</param>
        /// <param name="tip_ndv">p/Nota de Venta (S=Si; N=No)</param>
        /// <param name="por_con">Porcentaje Descuento p/Contado</param>
        /// <param name="por_cre">Porcentaje Descuento p/Crédito</param>
        /// <returns></returns>
        public void Fe_edi_tar(int cod_per, string tip_fac, string tip_ndv, decimal por_con, decimal por_cre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp010 SET va_tip_fac = '" + tip_fac + "',");
                cadena.AppendLine("                  va_tip_ndv = '" + tip_ndv + "',");
                cadena.AppendLine("                  va_por_con =  " + por_con + ",");
                cadena.AppendLine("                  va_por_cre =  " + por_cre + "");
                cadena.AppendLine("            WHERE va_cod_per =  " + cod_per + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA DESCUENTO GENERAL P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp010 WHERE va_cod_per = " + cod_per + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA DESCUENTO GENERAL P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_sul(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp010_01a_p01 " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA REGISTRO DESCUENTO GENERAL P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_reg(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_cod_per, va_tip_fac, va_tip_ndv,");
                cadena.AppendLine("       va_por_con, va_por_cre");
                cadena.AppendLine("  FROM adp010");
                cadena.AppendLine(" WHERE va_cod_per = " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
