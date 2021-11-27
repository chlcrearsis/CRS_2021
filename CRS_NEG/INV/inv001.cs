using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: GRUPO BODEGAS
    /// </summary>
    public class inv001
    {
        //######################################################################
        //##       Tabla: inv001                                              ##
        //##      Nombre: GRUPO BODEGAS                                       ##
        //## Descripcion: Grupo Bodega                                        ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################

        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar GRUPO BODEGA"
        /// </summary>
        /// <param name="ide_gru">ID. Grupo Bodega</param>
        /// <param name="nom_gru">Nombre</param>
        /// <param name="des_gru">Descripción</param>
        public void Fe_nue_reg(int ide_gru, string nom_gru, string des_gru)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO inv001 VALUES(" + ide_gru + ", '" + nom_gru + "', '" + des_gru + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Grupo Bodega"
        /// </summary>
        /// <param name="ide_gru">ID. Grupo Bodega</param>
        /// <param name="nom_gru">Nombre</param>
        /// <param name="des_gru">Descripción</param>
        public void Fe_edi_tar(int ide_gru, string nom_gru, string des_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE inv001 SET va_nom_gru = '" + nom_gru + "', va_des_gru = '" + des_gru + "' WHERE va_ide_gru = " + ide_gru + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Grupo Bodega"
        /// </summary>
        /// <param name="ide_gru">ID. Grupo Bodega</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(int ide_gru, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE inv001 SET va_est_ado ='" + est_ado + "' WHERE va_ide_gru = " + ide_gru + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Funcion "Elimina Grupo Bodega"
        /// </summary>
        /// <param name="ide_gru">ID. Grupo Bodega</param>
        public void Fe_eli_min(int ide_gru )
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE inv001_06a_p01 '" + ide_gru + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta Grupo Bodega"
        /// </summary>
        /// <param name="ide_gru">ID. Grupo Bodega</param>
        /// <returns></returns>
        public DataTable Fe_con_gru(int ide_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE inv001_05a_p01 " + ide_gru + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Filtra Grupo Bodega"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_cod_gru; 1=va_nom_gru)</param>
        /// <param name="est_bus">Estado (T=Todos; H=Habilitado; D=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_gru, va_nom_gru, va_des_gru, va_est_ado");
                cadena.AppendLine("  FROM adp001");
                switch (prm_bus){
                    case 0: cadena.AppendLine(" WHERE va_ide_gru like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" WHERE va_nom_gru like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" WHERE va_des_gru like '" + cri_bus + "%'"); break;

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
        /// Función: "Lista Grupo Bodega"
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_obt_gru()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_gru, va_nom_gru, va_des_gru, va_est_ado");
                cadena.AppendLine("  FROM adp001");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "Reporte R01 : Lista Grupo Bodega"
        /// </summary>
        /// <param name="est_ado">Estado</param>
        /// <returns></returns>
        public DataTable Fe_inv001_R01(string est_ado)
        {   
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE inv001_R01 '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
