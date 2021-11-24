using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase TIPO DE DOCUMENTO
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp014
    {
        //######################################################################
        //##       Tabla: adp014                                              ##
        //##      Nombre: TIPO DE DOCUMENTO                                   ##
        //## Descripcion: Tipo de Documento de Persona                        ##         
        //##       Autor: JEJR  - (15-09-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Documento</param>
        /// <param name="nom_tip">Nombre Tipo de Documento</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_tip, string nom_tip, string ext_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp014 VALUES ('" + ide_tip + "', '" + nom_tip + "', '" + ext_doc + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Documento</param>
        /// <param name="nom_tip">Nombre Tipo de Documento</param>
        /// <returns></returns>
        public void Fe_edi_tar(string ide_tip, string des_tip, string ext_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp014 SET va_des_tip = '" + des_tip + "', va_ext_doc = '" + ext_doc + "' WHERE va_ide_tip = '" + ide_tip + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Documento</param>
        /// <param name="est_ado">Estado de Tipo de Documento</param>
        /// <remarks></remarks>
        public void Fe_hab_des(string ide_tip, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp014 SET va_est_ado = '" + est_ado + "' WHERE va_ide_tip = '" + ide_tip + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Documento</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp014 WHERE va_ide_tip = '" + ide_tip + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Documento</param>
        /// <returns></returns>
        public DataTable Fe_con_tip(string ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_des_tip, va_ext_doc, va_est_ado");
                cadena.AppendLine("  FROM adp014");
                cadena.AppendLine(" WHERE va_ide_tip = '" + ide_tip + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA TIPO DE DOCUMENTO POR NOMBRE"
        /// </summary>
        /// <param name="nom_tip">Nombre Tipo Documento</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string des_tip, string ide_tip = "")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_des_tip, va_ext_doc, va_est_ado");
                cadena.AppendLine("  FROM adp014");
                cadena.AppendLine(" WHERE va_des_tip = '" + des_tip + "'");
                if (ide_tip.CompareTo("") != 0)
                    cadena.AppendLine(" AND va_ide_tip <> '" + ide_tip + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_tip; 1=va_des_tip)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_des_tip, va_ext_doc, va_est_ado");
                cadena.AppendLine("  FROM adp014");

                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_ide_tip LIKE '" + cri_bus + "%' "); break;
                    case 1: cadena.AppendLine(" WHERE va_des_tip LIKE '" + cri_bus + "%' "); break;

                }
                switch (est_bus){
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T"){
                    cadena.AppendLine(" AND va_est_ado = '" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                     

        /// <summary>
        /// Funcion "LISTA TIPO DE DOCUMENTO
        /// </summary>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tip(string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_des_tip, va_ext_doc, va_est_ado");
                cadena.AppendLine("  FROM adp014");
                switch (est_bus){
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T"){
                    cadena.AppendLine(" AND va_est_ado ='" + est_bus + "'");
                }
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }       
    }
}
