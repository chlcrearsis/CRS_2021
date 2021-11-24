using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase ATRIBUTOS DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp005
    {
        //######################################################################
        //##       Tabla: adp005                                              ##
        //##      Nombre: ATRIBUTOS DE PERSONA                                ##
        //## Descripcion: Atributos asignados a la Persona                    ##         
        //##       Autor: JEJR  - (12-10-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <returns></returns>
        public void Fe_nue_reg(int cod_per, int ide_tip, int ide_atr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp005 VAULES (" + cod_per + ", " + ide_tip + ", " + ide_atr + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <returns></returns>
        public void Fe_edi_tar(int cod_per, int ide_tip, int ide_atr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp005 SET va_ide_atr = " + ide_atr + " WHERE va_cod_per = " + cod_per + " AND va_ide_tip = " + ide_tip + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_per, int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp005 WHERE va_cod_per = " + cod_per + " AND va_ide_tip = " + ide_tip + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <returns></returns>
        public DataTable Fe_con_reg(int cod_per, int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp005.va_cod_per, adp005.va_ide_tip, adp003.va_nom_tip,");
                cadena.AppendLine("       adp005.va_ide_atr, adp004.va_nom_atr");
                cadena.AppendLine("  FROM adp005, adp003, adp004");
                cadena.AppendLine(" WHERE adp005.va_ide_tip = adp003.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_tip = adp004.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_atr = adp004.va_ide_atr");
                cadena.AppendLine("   AND adp005.va_cod_per = " + cod_per + "");
                cadena.AppendLine("   AND adp005.va_ide_tip = " + ide_tip + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA ATRIBUTO DE PERSONA POR PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public DataTable Fe_lis_per(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp005.va_cod_per, adp005.va_ide_tip, adp003.va_nom_tip,");
                cadena.AppendLine("       adp005.va_ide_atr, adp004.va_nom_atr");
                cadena.AppendLine("  FROM adp005, adp003, adp004");
                cadena.AppendLine(" WHERE adp005.va_ide_tip = adp003.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_tip = adp004.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_atr = adp004.va_ide_atr");
                cadena.AppendLine("   AND adp005.va_cod_per = " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA ATRIBUTO DE PERSONA POR TIPO DE ATRIBUTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <returns></returns>
        public DataTable Fe_lis_tip(int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp005.va_cod_per, adp005.va_ide_tip, adp003.va_nom_tip,");
                cadena.AppendLine("       adp005.va_ide_atr, adp004.va_nom_atr");
                cadena.AppendLine("  FROM adp005, adp003, adp004");
                cadena.AppendLine(" WHERE adp005.va_ide_tip = adp003.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_tip = adp004.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_atr = adp004.va_ide_atr");
                cadena.AppendLine("   AND adp005.va_ide_tip = " + ide_tip + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA ATRIBUTO DE PERSONA POR ATRIBUTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <returns></returns>
        public DataTable Fe_lis_atr(int ide_tip, int ide_atr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp005.va_cod_per, adp005.va_ide_tip, adp003.va_nom_tip,");
                cadena.AppendLine("       adp005.va_ide_atr, adp004.va_nom_atr");
                cadena.AppendLine("  FROM adp005, adp003, adp004");
                cadena.AppendLine(" WHERE adp005.va_ide_tip = adp003.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_tip = adp004.va_ide_tip");
                cadena.AppendLine("   AND adp005.va_ide_atr = adp004.va_ide_atr");
                cadena.AppendLine("   AND adp005.va_ide_tip = " + ide_tip + "");
                cadena.AppendLine("   AND adp005.va_ide_atr = " + ide_atr + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }
    }
}
