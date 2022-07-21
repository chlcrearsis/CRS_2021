using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp015 - Validación Registro de Persona               */
    /* Descripción: Campos Obligatorio a validar en Registro de Persona   */
    /*       Autor: JEJR - Crearsis             Fecha: 15-09-2021         */
    /**********************************************************************/
    public class adp015
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;       

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA VALIDACIÓN REGISTRO DE PERSONA"
        /// </summary>
        /// <param name="nom_col">Nombre Columna</param>
        /// <param name="dat_req">Dato Requerido (S=Si; N=No)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(string nom_col, string dat_req)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp015 SET va_dat_req = '" + dat_req + "' WHERE va_nom_col = '" + nom_col + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA VALIDACIÓN REGISTRO DE PERSONA"
        /// </summary>
        /// <param name="nom_col">Nombre Columna</param>
        /// <returns></returns>
        public DataTable Fe_con_val(string nom_col)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_nom_col, va_ide_col, va_des_col, va_dat_req");
                cadena.AppendLine("  FROM adp015");
                cadena.AppendLine(" WHERE va_nom_col = '" + nom_col + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA VALIDACIÓN REGISTRO DE PERSONA"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_lis_val()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_nom_col, va_ide_col, va_des_col, va_dat_req");
                cadena.AppendLine("  FROM adp015");
                cadena.AppendLine(" ORDER BY va_ide_col ASC");                
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }       
    }
}
