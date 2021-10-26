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
    ///  Clase PERMISO LISTA DE PRECIO P/PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp006
    {
        //######################################################################
        //##       Tabla: adp006                                              ##
        //##      Nombre: IMAGENES POR PERSONA                                ##
        //## Descripcion: Definición de Imagenes por Persona                  ##         
        //##       Autor: JEJR  - (25-10-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA IMAGEN POR PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. tipo de imagen</param>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ext_arc">Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)</param>
        /// <param name="tam_arc">Tamaño del archivo en KB</param>
        /// <param name="fec_reg">Fecha y hora de registro</param>
        /// <param name="ide_usr">ID. Usuario Registro</param>
        /// <returns></returns>
        public void Fe_reg_ima(int ide_tip, int cod_per, string ext_arc, decimal tam_arc, string fec_reg, string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp006_02a_p01 " + ide_tip + ", " + cod_per + ", '" + ext_arc + "', " + tam_arc + ", '" + fec_reg + "', '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ACTUALIZA IMAGEN POR PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. tipo de imagen</param>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ext_arc">Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)</param>
        /// <param name="tam_arc">Tamaño del archivo en KB</param>
        /// <param name="fec_reg">Fecha y hora de registro</param>
        /// <param name="ide_usr">ID. Usuario Registro</param>
        /// <returns></returns>
        public void Fe_act_ima(int ide_tip, int cod_per, string ext_arc, decimal tam_arc, string fec_reg, string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp006_03a_p01 " + ide_tip + ", " + cod_per + ", '" + ext_arc + "', " + tam_arc + ", '" + fec_reg + "', '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA IMAGEN POR PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. tipo de imagen</param>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public void Fe_eli_ima(int ide_tip, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp006 WHERE va_ide_tip = " + ide_tip + " AND va_cod_per = " + cod_per + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA IMAGEN POR PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. tipo de imagen</param>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_ima(int ide_tip, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_cod_per, va_img_arc, va_ext_arc,");
                cadena.AppendLine("       va_tam_arc, va_fec_reg, va_ide_usr");
                cadena.AppendLine("  FROM adp006");
                cadena.AppendLine(" WHERE va_ide_tip = " + ide_tip + "");
                cadena.AppendLine("   AND va_cod_per = " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
