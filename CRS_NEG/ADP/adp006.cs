using System;
using System.Data;
using System.Text;
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
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_tip">ID. Tipo de Imagen</param>
        /// <param name="img_arc">Archivo Imagen</param>
        /// <param name="ext_arc">Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)</param>
        /// <param name="tam_arc">Tamaño del archivo en KB</param>
        /// <param name="ide_usr">ID. Usuario Registro</param>
        /// <param name="fec_reg">Fecha y hora de registro</param>
        /// <param name="nom_equ">Nombre Equipo</param>
        /// <returns></returns>       
        public void Fe_nue_reg(int cod_per, string ide_tip, byte[] img_arc, string ext_arc, decimal tam_arc, string ide_usr, string fec_reg, string nom_equ)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp006 VALUES (" + cod_per + ", '" + ide_tip + "',  @va_img_arc, '" + ext_arc + "', " + tam_arc + ", '" + ide_usr + "', '" + fec_reg + "', '" + nom_equ + "')");
                ob_con_ecA.fu_exe_sql_img(cadena.ToString(), "@va_img_arc", img_arc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "ACTUALIZA IMAGEN POR PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_tip">ID. Tipo de Imagen</param>
        /// <param name="img_arc">Archivo Imagen</param>
        /// <param name="ext_arc">Extencion del archivo (JPG, JPEG, BMP, PNG, PDF)</param>
        /// <param name="tam_arc">Tamaño del archivo en KB</param>
        /// <param name="ide_usr">ID. Usuario Registro</param>
        /// <param name="fec_reg">Fecha y hora de registro</param>
        /// <param name="nom_equ">Nombre Equipo</param>
        /// <returns></returns>
        public void Fe_edi_tar(int cod_per, string ide_tip, byte[] img_arc, string ext_arc, decimal tam_arc, string ide_usr, string fec_reg, string nom_equ)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp006 SET va_img_arc = @va_img_arc, va_ext_arc = '" + ext_arc + "', va_tam_arc = " + tam_arc + ", va_ide_usr = '" + ide_usr + "', va_fec_reg = '" + fec_reg + "', va_nom_equ = '" + nom_equ + "'");
                cadena.AppendLine("            WHERE va_cod_per = " + cod_per + "");
                cadena.AppendLine("              AND va_ide_tip = '" + ide_tip + "'");
                ob_con_ecA.fu_exe_sql_img(cadena.ToString(), "@va_img_arc", img_arc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA IMAGEN POR PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_tip">ID. tipo de imagen</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_per, string ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp006 WHERE va_cod_per = " + cod_per + " AND va_ide_tip = '" + ide_tip + "'");
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
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public DataTable Fe_lis_ima(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp006_01a_p01 " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA REGISTRO IMAGEN POR PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Imagen</param>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_reg(int cod_per, string ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp006_02a_p01 " + cod_per + ", '" + ide_tip + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
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
        public DataTable Fe_con_ima(int cod_per, string ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_cod_per, va_img_arc, va_ext_arc,");
                cadena.AppendLine("       va_tam_arc, va_fec_reg, va_ide_usr");
                cadena.AppendLine("  FROM adp006");
                cadena.AppendLine(" WHERE va_ide_tip = '" + ide_tip + "'");
                cadena.AppendLine("   AND va_cod_per =  " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
