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
    ///  Clase DEFINICIÓN DE RUTAS
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp007
    {
        //######################################################################
        //##       Tabla: adp007                                              ##
        //##      Nombre: DEFINICIÓN DE RUTAS                                 ##
        //## Descripcion: Rutas p/Asignar al Cliente                          ##         
        //##       Autor: JEJR  - (30-08-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "NUEVA DEFINICIÓN DE RUTAS"
        /// </summary>
        /// <param name="ide_rut">ID. Ruta</param>
        /// <param name="nom_rut">Nombre Ruta</param>
        /// <param name="nom_cor">Nombre Corto</param>
        /// <returns></returns>
        public void Fe_nue_rut(int ide_rut, string nom_rut, string nom_cor)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp007 VALUES (" + ide_rut + ", '" + nom_rut + "', '" + nom_cor + "', 'V'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA DEFINICIÓN DE RUTA"
        /// </summary>
        /// <param name="ide_rut">ID. Ruta</param>
        /// <param name="nom_rut">Nombre Ruta</param>
        /// <param name="nom_cor">Nombre Corto</param>
        /// <returns></returns>
        public void Fe_edi_rut(int ide_rut, string nom_rut, string nom_cor)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp007 SET va_nom_rut = '" + nom_rut + "', va_nom_cor = '" + nom_cor + "' WHERE va_ide_rut = " + ide_rut + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA DEFINICIÓN DE RUTA"
        /// </summary>
        /// <param name="ide_rut">ID. Ruta</param>
        /// <param name="est_ado">Estado de la Ruta</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_rut, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp007 SET va_est_ado = '" + est_ado + "' WHERE va_ide_rut = " + ide_rut + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA DEFINICIÓN DE RUTA"
        /// </summary>
        /// <param name="ide_rut">ID. Ruta</param>
        /// <returns></returns>
        public void Fe_eli_rut(int ide_rut)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp007 WHERE va_ide_rut = " + ide_rut + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA DEFINICIÓN DE RUTA"
        /// </summary>
        /// <param name="ide_rut">ID. Ruta</param>
        /// <returns></returns>
        public DataTable Fe_con_rut(int ide_rut)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rut, va_nom_rut, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM adp007");
                cadena.AppendLine(" WHERE va_ide_rut = " + ide_rut + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA DEFINICIÓN DE RUTA POR NOMBRE"
        /// </summary>
        /// <param name="nom_rut">Nombre Ruta</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_rut, int ide_rut = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rut, va_nom_rut, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM adp007");
                cadena.AppendLine(" WHERE va_nom_rut = '" + nom_rut + "'");
                if (ide_rut > 0)
                    cadena.AppendLine(" AND va_ide_rut <> " + ide_rut + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA DEFINICIÓN DE RUTA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_rut; 1=va_nom_rut)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rut, va_nom_rut, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM adp007");

                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_ide_rut LIKE '" + cri_bus + "%' "); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_rut LIKE '" + cri_bus + "%' "); break;

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
        /// Funcion "LISTA DEFINICIÓN DE RUTA
        /// </summary>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_rut(string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_rut, va_nom_rut, va_nom_cor, va_est_ado");
                cadena.AppendLine("  FROM adp007");
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
        /// Funcion "OBTIENE ULTIMO ID. DEFINICIÓN DE RUTA"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_ide_rut INT ");
                cadena.AppendLine(" SELECT @va_ide_rut = ISNULL(MAX(va_ide_rut), 0) FROM adp007");
                cadena.AppendLine(" SELECT @va_ide_rut + 1 AS va_ide_rut");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
