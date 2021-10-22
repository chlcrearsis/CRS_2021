using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase ASIGNACIÓN RUTAS P/PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp008
    {
        //######################################################################
        //##       Tabla: adp008                                              ##
        //##      Nombre: REGISTRA RUTEO P/PERSONA                            ##
        //## Descripcion: Asignación de Rutas p/persona                       ##         
        //##       Autor: JEJR  - (21-10-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA RUTEO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_rut">ID. Ruta</param>
        /// <returns></returns>
        public void Fe_reg_rut(int cod_per, int ide_rut)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp008 VALUES (" + cod_per + ", " + ide_rut + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA RUTEO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_rut">ID. Ruta</param>
        /// <returns></returns>
        public void Fe_eli_rut(int cod_per, int ide_rut)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp008 WHERE va_cod_per = " + cod_per + " AND va_ide_rut = " + ide_rut + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA RUTEO P/Persona"
        /// </summary>
        /// <param name="cod_per">Codigo de Persona</param>
        /// <returns></returns>
        public DataTable Fe_lis_per(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp008_01a_p01 " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
