using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase GRUPO DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp001
    {
        //######################################################################
        //##       Tabla: adp001                                              ##
        //##      Nombre: GRUPO DE PERSONAS                                   ##
        //## Descripcion: Definición de Grupos de Persona                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################

        conexion_a ob_con_ecA = new conexion_a();       
        StringBuilder cadena;      

        /// <summary>
        /// Funcion "Registrar Grupo de Persona"
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de persona</param>
        /// <param name="nom_gru">nombre del GRUPO de persona</param>
        /// <returns></returns>
        public void Fe_nue_reg(int cod_gru, string nom_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp001 VALUES (" + cod_gru + ", '" + nom_gru + "','H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Grupo de Persona"
        /// </summary>
        /// <param name="cod_gru">Codigo de actividad</param>
        /// <param name="nom_gru">nombre de actividad</param>
        /// <returns></returns>
        public void Fe_edi_tar(int cod_gru, string nom_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp001 SET va_nom_gru = '" + nom_gru + "' WHERE va_cod_gru =" + cod_gru +"");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Grupo de Persona"
        /// </summary>
        /// <param name="cod_per">Codigo de Actividad</param>
        /// <param name="est_ado">Estado de Actividad</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int cod_gru, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp001 SET va_est_ado='" + est_ado + "' WHERE  va_cod_gru = " + cod_gru + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina GRUPO DE PERSONA DEL SISTEMA"
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de persona</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp001 WHERE va_cod_gru ='" + cod_gru + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
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
        /// <param name="prm_bus">Parametros de Busqueda (0=va_cod_gru; 1=va_nom_gru)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_cod_gru, va_nom_gru, va_est_ado");
                cadena.AppendLine("  FROM adp001");
                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_cod_gru like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_gru like '" + cri_bus + "%'"); break;

                }
                switch (est_bus){
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T"){
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
        /// Funcion consultar "GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_gru">codigo del GRUPO de persona</param>
        /// <returns></returns>
        public DataTable Fe_con_gru(int cod_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_cod_gru, va_nom_gru, va_est_ado");
                cadena.AppendLine("  FROM adp001");
                cadena.AppendLine(" WHERE va_cod_gru = " + cod_gru + "");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "CONSULTA GRUPO DE PERSONA POR NOMBRE"
        /// </summary>
        /// <param name="nom_gru">Nombre Grupo Persona</param>
        /// <param name="cod_gru">Código Grupo Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_gru, int cod_gru = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_cod_gru, va_nom_gru, va_est_ado");
                cadena.AppendLine("  FROM adp001");
                cadena.AppendLine(" WHERE va_nom_gru = '" + nom_gru + "'");
                if (cod_gru > 0)
                    cadena.AppendLine(" AND va_cod_gru <> " + cod_gru + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "LISTA GRUPO DE PERSONA"
        /// </summary>
        /// <param name="est_ado">est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_gru(string est_ado = "0")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_cod_gru, va_nom_gru, va_est_ado");
                cadena.AppendLine("  FROM adp001");
                switch (est_ado){
                    case "0": est_ado = "T"; break;
                    case "1": est_ado = "H"; break;
                    case "2": est_ado = "N"; break;
                }

                if (est_ado != "T")
                    cadena.AppendLine(" WHERE va_est_ado = '" + est_ado + "'");
                
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }        

        /// <summary>
        /// Funcion "OBTIENE ULTIMO ID. GRUPO PERSONA"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_ide()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_cod_gru INT ");
                cadena.AppendLine(" SELECT @va_cod_gru = ISNULL(MAX(va_cod_gru), 0) FROM adp001");
                cadena.AppendLine(" SELECT @va_cod_gru + 1 AS va_cod_gru");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Grupo Persona 
        /// </summary>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp001_R01 '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
