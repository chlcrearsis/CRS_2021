using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase TIPO DE ATRIBUTO
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp003
    {
        //######################################################################
        //##       Tabla: adp003                                              ##
        //##      Nombre: TIPO DE ATRIBUTO                                    ##
        //## Descripcion: Tipo de Atributos de Persona                        ##         
        //##       Autor: JEJR  - (30-08-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA TIPO DE ATRIBUTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <param name="nom_tip">Nombre Tipo de Atributo</param>
        /// <param name="atr_def">ID. Atributo p/Defecto</param>
        /// <param name="nom_def">Nombre Atributo p/Defecto</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ide_tip, string nom_tip, int atr_def, string nom_def)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp003_01a_p01 " + ide_tip + ", '" + nom_tip + "', " + atr_def + ", '" + nom_def + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA TIPO DE ATRIBUTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="nom_tip">Nombre tipo de atributo</param>
        /// <returns></returns>
        public void Fe_edi_tar(int ide_tip, string nom_tip, int atr_def)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp003 SET va_nom_tip = '" + nom_tip + "', va_atr_def = " + atr_def + " WHERE va_ide_tip = " + ide_tip + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA TIPO DE ATRIBUTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="est_ado">Estado de Tipo de Atributo</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_tip, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp003 SET va_est_ado = '" + est_ado + "' WHERE va_ide_tip = " + ide_tip + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA TIPO DE ATRIBUTOS"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributos</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp003 WHERE va_ide_tip = " + ide_tip + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA TIPO DE ATRIBUTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <returns></returns>
        public DataTable Fe_con_tip(int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp003.va_ide_tip, adp003.va_nom_tip, adp003.va_atr_def,");
                cadena.AppendLine("       adp004.va_nom_atr, adp003.va_est_ado");
                cadena.AppendLine("  FROM adp003, adp004");
                cadena.AppendLine(" WHERE adp003.va_ide_tip = adp004.va_ide_tip");
                cadena.AppendLine("   AND adp003.va_atr_def = adp004.va_ide_atr");
                cadena.AppendLine("   AND adp003.va_ide_tip = " + ide_tip + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA TIPO DE ATRIBUTO POR NOMBRE"
        /// </summary>
        /// <param name="nom_tip">Nombre Ruta</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_tip, int ide_tip = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_nom_tip, va_atr_def, va_est_ado");
                cadena.AppendLine("  FROM adp003");
                cadena.AppendLine(" WHERE va_nom_tip = '" + nom_tip + "'");
                if (ide_tip > 0)
                    cadena.AppendLine(" AND va_ide_tip <> " + ide_tip + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA TIPO DE ATRIBUTO"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_tip; 1=va_nom_tip)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_nom_tip, va_atr_def, va_est_ado");
                cadena.AppendLine("  FROM adp003");

                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_ide_tip LIKE '" + cri_bus + "%' "); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_tip LIKE '" + cri_bus + "%' "); break;

                }
                switch (est_bus){
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND va_est_ado ='" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                     

        /// <summary>
        /// Funcion "LISTA TIPO DE ATRIBUTOS
        /// </summary>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tip(string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_nom_tip, va_atr_def, va_est_ado");
                cadena.AppendLine("  FROM adp003");
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" WHERE va_est_ado ='" + est_bus + "'");
                }
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Funcion "OBTIENE ULTIMO ID. TIPO DE ATRIBUTO"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_tip INT ");
                cadena.AppendLine(" SELECT @va_ide_tip = ISNULL(MAX(va_ide_tip), 0) FROM adp003");
                cadena.AppendLine(" SELECT @va_ide_tip + 1 AS va_ide_tip");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
