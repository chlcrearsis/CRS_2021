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
    ///  Clase ATRIBUTO DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp004
    {
        //######################################################################
        //##       Tabla: adp004                                              ##
        //##      Nombre: ATRIBUTO DE PERSONA                                 ##
        //## Descripcion: Atributos de Segmentación de Persona                ##         
        //##       Autor: JEJR  - (01-09-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <param name="nom_atr">Nombre Atributo</param>
        /// <returns></returns>
        public void Fe_nue_atr(int ide_tip, int ide_atr, string nom_atr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp004 VALUES (" + ide_tip + ", " + ide_atr + ", '" + nom_atr + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <param name="nom_atr">Nombre Atributo</param>
        /// <returns></returns>
        public void Fe_edi_atr(int ide_tip, int ide_atr, string nom_atr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp004 SET va_nom_atr = '" + nom_atr + "' WHERE va_ide_tip = " + ide_tip + " AND va_ide_atr = " + ide_atr + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <param name="est_ado">Estado de Tipo de Atributo</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_tip, int ide_atr, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp004 SET va_est_ado = '" + est_ado + "' WHERE va_ide_tip = " + ide_tip + " AND va_ide_atr = " + ide_atr + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <returns></returns>
        public void Fe_eli_atr(int ide_tip, int ide_atr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp004 WHERE va_ide_tip = " + ide_tip + " AND va_ide_atr = " + ide_atr + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="ide_atr">ID. Atributo</param>
        /// <returns></returns>
        public DataTable Fe_con_atr(int ide_tip, int ide_atr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp003.va_ide_tip, adp003.va_nom_tip, adp004.va_ide_atr,");
                cadena.AppendLine("       adp004.va_nom_atr, adp004.va_est_ado");
                cadena.AppendLine("  FROM adp003, adp004");
                cadena.AppendLine(" WHERE adp003.va_ide_tip = adp004.va_ide_tip");
                cadena.AppendLine("   AND adp004.va_ide_tip = " + ide_tip + "");
                cadena.AppendLine("   AND adp004.va_ide_atr = " + ide_atr + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA DEFINICIÓN DE ATRIBUTO POR NOMBRE"
        /// </summary>
        /// <param name="nom_atr">Nombre Atributo</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(int ide_tip, string nom_atr, int ide_atr = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tip, va_ide_atr, va_nom_tip, va_est_ado");
                cadena.AppendLine("  FROM adp004");
                cadena.AppendLine(" WHERE va_ide_tip =  " + ide_tip + "");
                cadena.AppendLine("   AND va_nom_atr = '" + nom_atr + "'");
                if (ide_atr > 0)
                    cadena.AppendLine(" AND va_ide_atr <> " + ide_atr + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA ATRIBUTO DE PERSONA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(int ide_tip, string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp003.va_ide_tip, adp003.va_nom_tip, adp004.va_ide_atr,");
                cadena.AppendLine("       adp004.va_nom_atr, adp004.va_est_ado");
                cadena.AppendLine("  FROM adp004, adp003");
                cadena.AppendLine(" WHERE adp004.va_ide_tip = adp003.va_ide_tip");
                cadena.AppendLine("   AND adp004.va_ide_tip = " + ide_tip + "");
                switch (prm_bus){
                    case 0: cadena.AppendLine(" AND adp004.va_ide_atr LIKE '" + cri_bus + "%' "); break;
                    case 1: cadena.AppendLine(" AND adp004.va_nom_atr LIKE '" + cri_bus + "%' "); break;
                }
                switch (est_bus){
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND adp004.va_est_ado = '" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA ATRIBUTOS DE PERSONA
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tip(int ide_tip, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp003.va_ide_tip, adp003.va_nom_tip, adp004.va_ide_atr,");
                cadena.AppendLine("       adp004.va_nom_atr, adp004.va_est_ado");
                cadena.AppendLine("  FROM adp004, adp003");
                cadena.AppendLine(" WHERE adp004.va_ide_tip = adp003.va_ide_tip");
                cadena.AppendLine("   AND adp004.va_ide_tip = " + ide_tip + "");
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND adp004.va_est_ado = '" + est_bus + "'");
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
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <returns></returns>
        public DataTable Fe_obt_ide(int ide_tip)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_atr INT ");
                cadena.AppendLine(" SELECT @va_ide_atr = ISNULL(MAX(va_ide_atr), 0) FROM adp004 WHERE va_ide_tip = " + ide_tip + "");
                cadena.AppendLine(" SELECT @va_ide_atr + 1 AS va_ide_atr");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
