using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads010                                              ##
    //##      Nombre: Opciones del Menú                                   ##
    //## Descripcion: Opciones del Menú Formulario                        ##         
    //##       Autor: EJER - (07-09-2021)                                  ##
    //######################################################################
    public class ads011
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA OPCIÓN DEL MENU"
        /// </summary>
        /// <param name="nom_frm">Nombre Formulario</param>
        /// <param name="ide_men">ID. Menu Formulario</param>
        /// <param name="tex_men">Texto Menu Formulario</param>
        /// <param name="des_men">Descripción</param>
        /// <param name="ide_pad">ID. Menu Padre</param>
        public void Fe_nue_tip(string nom_frm, string ide_men, string tex_men, string des_men, string ide_pad)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads011_01a_p01 '" + nom_frm + "', '" + ide_men + "', '" + tex_men + "', '" + des_men + "', '" + ide_pad + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA OPCIÓN MENU POR NOMBRE FORMULARIO"
        /// </summary>
        /// <param name="nom_frm">Nombre Formulario</param>
        /// <returns></returns>
        public DataTable Fe_con_frm(string nom_frm)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_nom_frm, va_ide_men, va_tex_men,");
                cadena.AppendLine("       va_des_men, va_ide_pad");
                cadena.AppendLine("  FROM ads011");
                cadena.AppendLine(" WHERE va_nom_frm = '" + nom_frm + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA OPCIÓN MENU POR FORMULARIO Y MENU FORMULARIO"
        /// </summary>
        /// <param name="nom_frm">Nombre Formulario</param>
        /// <returns></returns>
        public DataTable Fe_con_frm(string nom_frm, string ide_men)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_nom_frm, va_ide_men, va_tex_men,");
                cadena.AppendLine("       va_des_men, va_ide_pad");
                cadena.AppendLine("  FROM ads011");
                cadena.AppendLine(" WHERE va_nom_frm = '" + nom_frm + "'");
                cadena.AppendLine("   AND va_ide_men = '" + ide_men + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}