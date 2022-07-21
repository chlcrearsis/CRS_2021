using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp017 - Relación Contacto de Persona                 */
    /* Descripción: Definición Relación Contacto de Persona               */
    /*       Autor: JEJR - Crearsis             Fecha: 30-08-2021         */
    /**********************************************************************/
    public class adp017
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA RELACIÓN CONTACTO DE PERSONA"
        /// </summary>
        /// <param name="ide_rel">ID. Relacion Contacto</param>
        /// <param name="nre_hom">Nombre Relación p/Hombre</param>
        /// <param name="nre_muj">Nombre Relación p/Mujer</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ide_rel, string nre_hom, string nre_muj)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp017 VALUES (" + ide_rel + ", '" + nre_hom + "', '" + nre_muj + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA RELACIÓN CONTACTO DE PERSONA"
        /// </summary>
        /// <param name="ide_rel">ID. Relacion Contacto</param>
        /// <param name="nre_hom">Nombre Relación p/Hombre</param>
        /// <param name="nre_muj">Nombre Relación p/Mujer</param>
        /// <returns></returns>
        public void Fe_edi_tar(int ide_rel, string nre_hom, string nre_muj)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp017 SET va_nre_hom = '" + nre_hom + "', va_nre_muj = '" + nre_muj + "' WHERE va_ide_rel = " + ide_rel + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA RELACIÓN CONTACTO DE PERSONA"
        /// </summary>
        /// <param name="ide_rel">ID. Relacion Contacto</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_rel, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp017 SET va_est_ado = '" + est_ado + "' WHERE va_ide_rel = " + ide_rel + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA RELACIÓN CONTACTO DE PERSONAS"
        /// </summary>
        /// <param name="ide_rel">ID. RELACIÓN CONTACTO DE PERSONAs</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_rel)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp017 WHERE va_ide_rel = " + ide_rel + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA RELACIÓN CONTACTO DE PERSONA"
        /// </summary>
        /// <param name="ide_rel">ID. RELACIÓN CONTACTO DE PERSONA</param>
        /// <returns></returns>
        public DataTable Fe_con_cod(int ide_rel)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rel, va_nre_hom, va_nre_muj, va_est_ado");
                cadena.AppendLine("  FROM adp017");
                cadena.AppendLine(" WHERE va_ide_rel = " + ide_rel + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA RELACIÓN CONTACTO DE PERSONA POR NOMBRE P/HOMBRE"
        /// </summary>        
        /// <param name="nre_hom">Nombre Relación p/Hombre</param>
        /// <param name="ide_rel">ID. Relacion Contacto</param>
        /// <returns></returns>
        public DataTable Fe_nre_hom(string nre_hom, int ide_rel = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rel, va_nre_hom, va_nre_muj, va_est_ado");
                cadena.AppendLine("  FROM adp017");
                cadena.AppendLine(" WHERE va_nre_hom = '" + nre_hom + "'");
                if (ide_rel > 0)
                    cadena.AppendLine(" AND va_ide_rel <> " + ide_rel + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA RELACIÓN CONTACTO DE PERSONA POR NOMBRE P/MUJER"
        /// </summary>
        /// <param name="nre_muj">Nombre Relación p/Mujer</param>
        /// <param name="ide_rel">ID. Relacion Contacto</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nre_muj, int ide_rel = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rel, va_nre_hom, va_nre_muj, va_est_ado");
                cadena.AppendLine("  FROM adp017");
                cadena.AppendLine(" WHERE va_nre_muj = '" + nre_muj + "'");
                if (ide_rel > 0)
                    cadena.AppendLine(" AND va_ide_rel <> " + ide_rel + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA RELACIÓN CONTACTO DE PERSONA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_rel; 1=va_nre_hom)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rel, va_nre_hom, va_nre_muj, va_est_ado");
                cadena.AppendLine("  FROM adp017");

                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" WHERE va_ide_rel LIKE '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE (va_nre_hom LIKE '" + cri_bus + "%' OR va_nre_muj LIKE '" + cri_bus + "%')"); break;

                }
                switch (est_bus)
                {
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
        /// Funcion "LISTA RELACIÓN CONTACTO DE PERSONAS
        /// </summary>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_rel(string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rel, va_nre_hom, va_nre_muj, va_est_ado");
                cadena.AppendLine("  FROM adp017");
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" WHERE va_est_ado = '" + est_bus + "'");
                }
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "OBTIENE ULTIMO ID. RELACIÓN CONTACTO DE PERSONA"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_rel INT ");
                cadena.AppendLine(" SELECT @va_ide_rel = ISNULL(MAX(va_ide_rel), 0) FROM adp017");
                cadena.AppendLine(" SELECT @va_ide_rel + 1 AS va_ide_rel");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
