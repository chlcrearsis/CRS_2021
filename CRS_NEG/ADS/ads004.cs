using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads004                                              ##
    //##      Nombre: Talonarios                                          ##
    //## Descripcion: Talonarios (Control Numeración)                     ##         
    //##       Autor: CHL  - (15-05-2020)                                 ##
    //######################################################################
    public class ads004
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;


        /// <summary>
        /// Funcion "Registrar Talonarios"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="nom_tal">Nombre Talonario</param>
        /// <param name="tip_tal">Tipo de Talonario (0=Manual; 1=Automatico)</param>
        /// <param name="nro_aut">Número de Autorización</param>
        /// <param name="for_mat">Formato de Impresión</param>
        /// <param name="nro_cop">Nro. de Copias a Imprimir</param>
        /// <param name="fir_ma1">Firma Nro. 1</param>
        /// <param name="fir_ma2">Firma Nro. 2</param>
        /// <param name="fir_ma3">Firma Nro. 3</param>
        /// <param name="fir_ma4">Firma Nro. 4</param>
        /// <param name="for_log">Formato de Logo (0=Razon Social de Empresa; 1=Logotipo 1; 2=Logotipo 2 ;3=Logotipo 3</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_doc,    int nro_tal, string nom_tal,    int tip_tal, int nro_aut, int for_mat, int nro_cop, 
                               string fir_ma1, string fir_ma2, string fir_ma3, string fir_ma4, int for_log){
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads004 VALUES ('" + ide_doc + "', " + nro_tal + ", '" + nom_tal + "', " + tip_tal + ",");
                cadena.AppendLine("                            " + nro_aut + ",  " + for_mat + ",  " + nro_cop + ", '" + fir_ma1 + "',");
                cadena.AppendLine("                           '" + fir_ma2 + "','" + fir_ma3 + "','" + fir_ma4 + "', " + for_log + ", 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Créa Talonario y numeracion (Anual/Mensual)
        /// </summary>

        /// <summary>
        /// Funcion "Registrar Talonarios y Control Numeración (Anual/Mensual)"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="nom_tal">Nombre Talonario</param>
        /// <param name="tip_tal">Tipo de Talonario (0=Manual; 1=Automatico)</param>
        /// <param name="nro_aut">Número de Autorización</param>
        /// <param name="for_mat">Formato de Impresión</param>
        /// <param name="nro_cop">Nro. de Copias a Imprimir</param>
        /// <param name="fir_ma1">Firma Nro. 1</param>
        /// <param name="fir_ma2">Firma Nro. 2</param>
        /// <param name="fir_ma3">Firma Nro. 3</param>
        /// <param name="fir_ma4">Firma Nro. 4</param>
        /// <param name="for_log">Formato de Logo (0=Razon Social de Empresa; 1=Logotipo 1; 2=Logotipo 2 ;3=Logotipo 3</param>
        /// <param name="ges_tio">Gestion Año</param>
        /// <param name="anu_mes">(0=Anual ; 1=Mensual)</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_doc,    int nro_tal, string nom_tal,    int tip_tal, int nro_aut, int for_mat, int nro_cop, 
                               string fir_ma1, string fir_ma2, string fir_ma3, string fir_ma4, int for_log, int ges_tio, int anu_mes)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_02a_p01 '" + ide_doc + "', " + nro_tal + ", '" + nom_tal + "', " + tip_tal + ",");
                cadena.AppendLine("                        " + nro_aut + ",  " + for_mat + ",  " + nro_cop + ", '" + fir_ma1 + "',");
                cadena.AppendLine("                       '" + fir_ma2 + "','" + fir_ma3 + "','" + fir_ma4 + "', " + for_log + ", " + ges_tio + ", " + anu_mes + ", 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="nom_tal">Nombre Talonario</param>
        /// <param name="tip_tal">Tipo de Talonario (0=Manual; 1=Automatico)</param>
        /// <param name="nro_aut">Número de Autorización</param>
        /// <param name="for_mat">Formato de Impresión</param>
        /// <param name="nro_cop">Nro. de Copias a Imprimir</param>
        /// <param name="fir_ma1">Firma Nro. 1</param>
        /// <param name="fir_ma2">Firma Nro. 2</param>
        /// <param name="fir_ma3">Firma Nro. 3</param>
        /// <param name="fir_ma4">Firma Nro. 4</param>
        /// <param name="for_log">Formato de Logo (0=Razon Social de Empresa; 1=Logotipo 1; 2=Logotipo 2 ;3=Logotipo 3</param>
        /// <returns></returns>
        public void Fe_edi_tar(string ide_doc, int nro_tal, string nom_tal, int tip_tal, int nro_aut, int for_mat, int nro_cop,
                               string fir_ma1, string fir_ma2, string fir_ma3, string fir_ma4, int for_log)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads004 SET va_nom_tal = '" + nom_tal + "', va_tip_tal =  " + tip_tal + ",");
                cadena.AppendLine("                  va_nro_aut =  " + nro_aut + ",  va_for_mat =  " + for_mat + ",");
                cadena.AppendLine("                  va_nro_cop =  " + nro_cop + ",  va_fir_ma1 = '" + fir_ma1 + "',");
                cadena.AppendLine("                  va_fir_ma2 = '" + fir_ma2 + "', va_fir_ma3 = '" + fir_ma3 + "',");
                cadena.AppendLine("                  va_fir_ma4 = '" + fir_ma4 + "', va_for_log =  " + for_log + "");
                cadena.AppendLine("            WHERE va_ide_doc =  " + ide_doc + "");
                cadena.AppendLine("              AND va_nro_tal =  " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <remarks></remarks>
        public void Fe_hab_des(string ide_doc, int nro_tal, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads004 SET va_est_ado = '" + est_ado + "' WHERE va_ide_doc = '" + ide_doc + "' AND va_nro_tal = " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Talonario"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads004 WHERE va_ide_doc = '" + ide_doc + "' AND va_nro_tal = " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA TALONARIO"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_doc; 1=va_nom_doc; 2=va_des_doc)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>       
        public DataTable Fe_bus_car(string cri_bus, int prm_bus, string est_bus, int ide_mod = 0)
        {            
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                if (ide_mod != 0)
                {
                    cadena.AppendLine(" AND ads003.va_ide_mod = " + ide_mod + "");
                }
                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" AND ads004.va_nom_tal like '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND ads003.va_nom_doc like '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" AND ads003.va_ide_doc like '" + cri_bus + "%'"); break;
                }
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND ads004.va_est_ado = '" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "TALONARIO"
        /// </summary>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>
        public DataTable Fe_con_tal(string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                cadena.AppendLine("   AND ads004.va_ide_doc = '" + ide_doc + "'");
                cadena.AppendLine("   AND ads004.va_nro_tal =  " + nro_tal + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA TALONARIO POR ID. DOCUMENTOS"
        /// </summary>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <returns></returns>
        public DataTable Fe_con_doc(string ide_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                cadena.AppendLine("   AND ads004.va_ide_doc = '" + ide_doc + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "CONSULTA TALONARIO POR NOMBRE"
        /// </summary>
        /// <param name="nom_doc">Nombre</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>
        public DataTable Fe_con_nom(string nom_doc, string ide_doc, int nro_tal = 9999)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = '" + ide_doc + "'");
                if (nro_tal != 9999)
                    cadena.AppendLine("   AND ads004.va_nro_tal <> " + nro_tal + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "LISTA TALONARIO"
        /// </summary>
        /// <param name="est_ado">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tal(string est_ado = "0")
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads004.va_ide_doc, ads003.va_nom_doc, ads004.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads004.va_tip_tal, ads004.va_nro_aut, ads004.va_for_mat, ads004.va_nro_cop,");
                cadena.AppendLine("       ads004.va_fir_ma1, ads004.va_fir_ma2, ads004.va_fir_ma3, ads004.va_fir_ma4,");
                cadena.AppendLine("       ads004.va_for_log, ads004.va_est_ado");
                cadena.AppendLine("  FROM ads004, ads003");
                cadena.AppendLine(" WHERE ads004.va_ide_doc = ads003.va_ide_doc");
                switch (est_ado)
                {
                    case "0": est_ado = "T"; break;
                    case "1": est_ado = "H"; break;
                    case "2": est_ado = "N"; break;
                }

                if (est_ado != "T")
                    cadena.AppendLine(" AND ads004.va_est_ado = '" + est_ado + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "PERMISO SOBRE TALONARIO AL USUARIO"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="est_tal">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_per_tal(string ide_usr, string ide_doc, int nro_tal, string est_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_05a_p02 '" + ide_usr + "', '" + ide_doc + "', " + nro_tal + ", '" + est_tal + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "PERMISO SOBRE TALONARIO AL USUARIO"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="est_tal">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_per_tal(string ide_usr, string ide_doc, string est_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_05a_p02 '" + ide_usr + "', '" + ide_doc + "', '" + est_tal + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion consultar "BUSCA TALONARIO CON PERMISO PARA EL USUARIO"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <param name="tex_bus">Texto a Buscar</param>
        /// <param name="est_tal">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>       
        public DataTable Fe_per_tal(string ide_usr, string ide_doc, string tex_bus, string est_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_01b_p01 '" + ide_usr + "', '" + ide_doc + "', '" + tex_bus + "', '" + est_tal + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                      

        /// <summary>
        /// Informe: Talonarios
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int ide_mod, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads004_R01 " + ide_mod + ", '" + est_ado + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
