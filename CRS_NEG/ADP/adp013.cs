using System;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase CONTACTO P/PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class adp013
    {
        //######################################################################
        //##       Tabla: adp013                                              ##
        //##      Nombre: CONTACTO P/PERSONA                                  ##
        //## Descripcion: Lista de Contactos p/Persona                        ##         
        //##       Autor: JEJR  - (04-11-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código Persona</param>
        /// <param name="cod_con">Código Contacto</param>
        /// <param name="nom_bre">Nombre</param>
        /// <param name="ape_pat">Apellido Paterno</param>
        /// <param name="ape_mat">Apellido Materno</param>
        /// <param name="nro_cid">Nro. Carnet de Identida</param>
        /// <param name="ext_doc">Extensión Documento</param>
        /// <param name="sex_con">Sexo (H=Hombre; M=Mujer)</param>
        /// <param name="par_con">Parentesco</param>
        /// <param name="tel_per">Telefono Personal</param>
        /// <param name="cel_ula">Telefono Celular</param>
        /// <param name="ema_ail">Email</param>
        /// <param name="dir_ubi">Direccion Ubicación</param>
        /// <param name="obs_con">Observación</param>
        /// <param name="est_ado">Estado(H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public void Fe_nue_reg(int cod_per, int cod_con, string nom_bre, string ape_pat, string ape_mat,
                            string nro_cid, string ext_doc, string sex_con, string par_con, string tel_per,
                            string cel_ula, string ema_ail, string dir_ubi, string obs_con, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO adp013 VALUES (" + cod_per + ",  " + cod_con + ", '" + nom_bre + "','" + ape_pat + "','" + ape_mat + "',");
                cadena.AppendLine("                          '" + nro_cid + "','" + ext_doc + "','" + sex_con + "','" + par_con + "','" + tel_per + "',");
                cadena.AppendLine("                          '" + cel_ula + "','" + ema_ail + "','" + dir_ubi + "','" + obs_con + "','" + est_ado + "')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "MODIFICA CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código Persona</param>
        /// <param name="cod_con">Código Contacto</param>
        /// <param name="nom_bre">Nombre</param>
        /// <param name="ape_pat">Apellido Paterno</param>
        /// <param name="ape_mat">Apellido Materno</param>
        /// <param name="nro_cid">Nro. Carnet de Identida</param>
        /// <param name="ext_doc">Extensión Documento</param>
        /// <param name="sex_con">Sexo (H=Hombre; M=Mujer)</param>
        /// <param name="par_con">Parentesco</param>
        /// <param name="tel_per">Telefono Personal</param>
        /// <param name="cel_ula">Telefono Celular</param>
        /// <param name="ema_ail">Email</param>
        /// <param name="dir_ubi">Direccion Ubicación</param>
        /// <param name="obs_con">Observación</param>
        /// <returns></returns>
        public void Fe_edi_reg(int cod_per,    int cod_con, string nom_bre, string ape_pat, string ape_mat,
                            string nro_cid, string ext_doc, string sex_con, string par_con, string tel_per,
                            string cel_ula, string ema_ail, string dir_ubi, string obs_con)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp013 SET va_nom_bre = '" + nom_bre + "', va_ape_pat = '" + ape_pat + "'");
                cadena.AppendLine("                  va_ape_mat = '" + ape_mat + "', va_nro_cid = '" + nro_cid + "'");
                cadena.AppendLine("                  va_ext_doc = '" + ext_doc + "', va_sex_con = '" + sex_con + "'");
                cadena.AppendLine("                  va_par_con = '" + par_con + "', va_tel_per = '" + tel_per + "'");
                cadena.AppendLine("                  va_cel_ula = '" + cel_ula + "', va_ema_ail = '" + ema_ail + "'");
                cadena.AppendLine("                  va_dir_ubi = '" + dir_ubi + "', va_obs_con = '" + obs_con + "'");
                cadena.AppendLine("            WHERE va_cod_per =  " + cod_per + "");
                cadena.AppendLine("              AND va_cod_con =  " + cod_con + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "HABILITA/DESHABILITA CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código Persona</param>
        /// <param name="cod_con">Código Contacto</param>
        /// <param name="est_ado">Estado(H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public void Fe_eli_tip(int cod_per, int cod_con, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp013 SET va_est_ado = '" + est_ado + "'");
                cadena.AppendLine("            WHERE va_cod_per =  " + cod_per + "");
                cadena.AppendLine("              AND va_cod_con =  " + cod_con + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "ELIMINA CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código Persona</param>
        /// <param name="cod_con">Código Contacto</param>
        /// <returns></returns>
        public void Fe_eli_tip(int cod_per, int cod_con)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE adp013 WHERE va_cod_per = " + cod_per + " AND va_cod_con = " + cod_con + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }


        /// <summary>
        /// Funcion "CONSULTA CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código Persona</param>
        /// <param name="cod_con">Código Contacto</param>     
        /// <returns></returns>
        public DataTable Fe_con_reg(int cod_per, int cod_con)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp013.va_cod_per, adp002.va_raz_soc, adp013.va_cod_con, adp013.va_nom_bre,");
                cadena.AppendLine("       adp013.va_ape_pat, adp013.va_ape_mat, adp013.va_nro_cid, adp013.va_ext_doc,");
                cadena.AppendLine("       adp013.va_sex_con, adp013.va_par_con, adp013.va_tel_per, adp013.va_cel_ula,");
                cadena.AppendLine("       adp013.va_ema_ail, adp013.va_dir_ubi, adp013.va_obs_con, adp013.va_est_ado");
                cadena.AppendLine("  FROM adp013, adp002");
                cadena.AppendLine(" WHERE adp013.va_cod_per = adp002.va_cod_per");
                cadena.AppendLine("   AND adp013.va_cod_per = " + cod_per + "");
                cadena.AppendLine("   AND adp013.va_cod_con = " + cod_con + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "LISTA CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_per(int cod_per, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp013.va_cod_per, adp002.va_raz_soc, adp013.va_cod_con, adp013.va_nom_bre,");
                cadena.AppendLine("       adp013.va_ape_pat, adp013.va_ape_mat, adp013.va_nro_cid, adp013.va_ext_doc,");
                cadena.AppendLine("       adp013.va_sex_con, adp013.va_par_con, adp013.va_tel_per, adp013.va_cel_ula,");
                cadena.AppendLine("       adp013.va_ema_ail, adp013.va_dir_ubi, adp013.va_obs_con, adp013.va_est_ado");
                cadena.AppendLine("  FROM adp013, adp002");
                cadena.AppendLine(" WHERE adp013.va_cod_per = adp002.va_cod_per");
                cadena.AppendLine("   AND adp013.va_cod_per = " + cod_per + "");
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND adp013.va_est_ado = '" + est_bus + "'");
                }
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(int cod_per, string cri_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT adp013.va_cod_per, adp002.va_raz_soc, adp013.va_cod_con, adp013.va_nom_bre,");
                cadena.AppendLine("       adp013.va_ape_pat, adp013.va_ape_mat, adp013.va_nro_cid, adp013.va_ext_doc,");
                cadena.AppendLine("       adp013.va_sex_con, adp013.va_par_con, adp013.va_tel_per, adp013.va_cel_ula,");
                cadena.AppendLine("       adp013.va_ema_ail, adp013.va_dir_ubi, adp013.va_obs_con, adp013.va_est_ado");
                cadena.AppendLine("  FROM adp013, adp002");
                cadena.AppendLine(" WHERE adp013.va_cod_per = adp002.va_cod_per");
                cadena.AppendLine("   AND adp013.va_cod_per = " + cod_per + "");
                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" AND adp013.va_cod_con LIKE '" + cri_bus + "%'"); break;
                    case 1: cadena.AppendLine(" AND adp013.va_nom_bre LIKE '" + cri_bus + "%'"); break;
                    case 2: cadena.AppendLine(" AND adp013.va_ape_pat LIKE '" + cri_bus + "%'"); break;
                    case 3: cadena.AppendLine(" AND adp013.va_ape_mat LIKE '" + cri_bus + "%'"); break;
                    case 4: cadena.AppendLine(" AND adp013.va_nro_cid LIKE '" + cri_bus + "%'"); break;
                }
                switch (est_bus)
                {
                    case "0": est_bus = "T"; break;
                    case "1": est_bus = "H"; break;
                    case "2": est_bus = "N"; break;
                }

                if (est_bus != "T")
                {
                    cadena.AppendLine(" AND adp013.va_est_ado = '" + est_bus + "'");
                }

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "OBTIENE ULTIMO ID. CONTACTO P/PERSONA"
        /// </summary>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public DataTable Fe_obt_ide(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_cod_con INT ");
                cadena.AppendLine(" SELECT @va_cod_con = ISNULL(MAX(va_cod_con), 0) FROM adp013 WHERE va_cod_per = " + cod_per + "");
                cadena.AppendLine(" SELECT @va_cod_con + 1 AS va_cod_con");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
