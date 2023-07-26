using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads005                                              ##
    //##      Nombre: Numeración                                          ##
    //## Descripcion: Numerador de Talonario                              ##                 
    //##       Autor: EJR  - (28-05-2020)                                 ##
    //######################################################################
    public class ads005
    {
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar Numeración"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <param name="con_act">Contador Actual</param>
        /// <param name="con_fin">Contador Final</param>
        public void Fe_nue_reg(int ges_tio, string ide_doc, int nro_tal, string fec_ini, string fec_fin, int con_act, int con_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads005 VALUES(" + ges_tio + ", '" + ide_doc + "', " + nro_tal + ", '" + fec_ini + "','" + fec_fin + "', " + con_act + ", " + con_fin + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Numeración"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <param name="fec_ini">Fecha Inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <param name="con_act">Contador Actual</param>
        /// <param name="con_fin">Contador Final</param>
        public void Fe_edi_tar(int ges_tio, string ide_doc, int nro_tal, string fec_ini, string fec_fin,
                               int con_act,    int con_fin){
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads005 SET va_fec_ini = '" + fec_ini + "',");
                cadena.AppendLine("                  va_fec_fin = '" + fec_fin + "',");
                cadena.AppendLine("                  va_con_act =  " + con_act + ",");
                cadena.AppendLine("                  va_con_fin =  " + con_fin + "");
                cadena.AppendLine("            WHERE va_ges_tio =  " + ges_tio + "");
                cadena.AppendLine("              AND va_ide_doc = '" + ide_doc + "'");
                cadena.AppendLine("              AND va_nro_tal =  " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina Numeración"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        public void Fe_eli_min(int ges_tio, string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads005 WHERE va_ges_tio =  " + ges_tio + "");
                cadena.AppendLine("                AND va_ide_doc = '" + ide_doc + "'");
                cadena.AppendLine("                AND va_nro_tal =  " + nro_tal + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA NUMERACIÓN"
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="tex_bus">Texto a Buscar</param>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="est_doc">Estado Documento (H=Habilitado; N=Deshabilitado; T=Todos)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(int ide_mod, int ges_tio, string tex_bus, int cri_bus, string est_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads005_01a_p01 " + ide_mod + ", " + ges_tio + ", '" + tex_bus + "', " + cri_bus + ", '" + est_doc + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Funcion "CONSULTAR NUMERACIÓN"
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="ide_doc">ID. Documento</param>
        /// <param name="nro_tal">Nro. Talonario</param>
        /// <returns></returns>
        public DataTable Fe_con_nta(int ges_tio, string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads005_05a_p01 " + ges_tio + ", '" + ide_doc + "', " + nro_tal + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Funcion "CONSULTA NUMERACIÓN POR ID. DOCUMENTOS"
        /// </summary>
        /// <param name="ide_doc">ID. Documentos</param>
        /// <returns></returns>
        public DataTable Fe_con_tal(string ide_doc, int nro_tal)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads005.va_ges_tio, ads005.va_ide_doc, ads005.va_nro_tal, ads004.va_nom_tal,");
                cadena.AppendLine("       ads005.va_fec_ini, ads005.va_fec_fin, ads005.va_con_act, ads005.va_con_fin");
                cadena.AppendLine("  FROM ads005, ads004");
                cadena.AppendLine(" WHERE ads005.va_ide_doc = ads004.va_ide_doc");
                cadena.AppendLine("   AND ads005.va_nro_tal = ads004.va_nro_tal");
                cadena.AppendLine("   AND ads005.va_ide_doc = '" + ide_doc + "'");
                cadena.AppendLine("   AND ads005.va_nro_tal =  " + nro_tal + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Informe: Numeración de Talonarios
        /// </summary>
        /// <param name="ges_tio">Gestión</param>
        /// <param name="doc_ini">ID. Documento Inicial</param>
        /// <param name="doc_fin">ID. Documento Final</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int ges_tio, string doc_ini, string doc_fin)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads005_R01 " + ges_tio + ", '" + doc_ini + "', '" + doc_fin + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
    }
}
