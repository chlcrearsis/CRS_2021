using System;
using System.Data;
using System.Text;
using CRS_DAT;

using Microsoft.SqlServer.Types;

namespace CRS_NEG
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp002 - Persona                                      */
    /* Descripción: Registro de Persona                                   */
    /*       Autor: JEJR - Crearsis             Fecha: 22-07-2020         */
    /**********************************************************************/
    public class adp002
    {                        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Registrar "PERSONA"
        /// </summary>        
        /// <param name="cod_per">Codigo Persona</param>
        /// <param name="cod_gru">Cod Grupo Persona</param>
        /// <param name="tip_per">Tipo de Cliente(P=Particular; E=Empresa)</param>
        /// <param name="nom_bre">Nombre</param>
        /// <param name="ape_pat">Apellido Paterno</param>
        /// <param name="ape_mat">Apellido Materno</param>
        /// <param name="raz_soc">Razon Social</param>
        /// <param name="nom_fac">Nombre a Facturar</param>
        /// <param name="ruc_nit">RUC/NIT</param>
        /// <param name="sex_per">Sexo(H= Hombre; M=Mujer)</param>
        /// <param name="fec_nac">Fecha de Nacimiento</param>
        /// <param name="tip_doc">Tipo Documento</param>
        /// <param name="nro_doc">Carnet de Identidad</param>
        /// <param name="tel_per">Telefono Personal</param>
        /// <param name="cel_ula">Telefono Celular</param>
        /// <param name="tel_fij">Telefono Fijo</param>
        /// <param name="dir_pri">Direccion Principal</param>
        /// <param name="dir_ent">Direccion de Entrega</param>
        /// <param name="ema_ail">Email</param>
        /// <param name="ubi_gps">Ubicación Geografica</param>
        /// <param name="cod_ven">Código de Vendedor Asignado</param>
        /// <param name="cod_cob">Código de Cobrador Asignado</param>
        /// <param name="tip_atr">Array Tipo de Atributo</param>
        /// <param name="ide_atr">Array tributo Seleccionado</param>        
        /// <returns></returns>
        public void Fe_nue_reg(int cod_per,    int cod_gru, string tip_per, string nom_bre, string ape_pat,
                            string ape_mat, string raz_soc, string nom_fac,   long ruc_nit, string sex_per,
                            string fec_nac, string tip_doc, double nro_doc, string ext_doc, string tel_per, 
                            string cel_ula, string tel_fij, string dir_pri, string dir_ent, string ema_ail, SqlGeography ubi_gps, 
                               int cod_ven,    int cod_cob, string tip_atr, string ide_atr){
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" EXECUTE adp002_02a_p01 ");
                cadena.AppendFormat(""  + cod_per + ",  " + cod_gru + ", '" + tip_per + "','" + nom_bre + "','" + ape_pat + "',");
                cadena.AppendFormat("'" + ape_mat + "','" + raz_soc + "','" + nom_fac + "', " + ruc_nit + ", '" + sex_per + "',");
                cadena.AppendFormat(" " + fec_nac + ", '" + tip_doc + "', " + nro_doc + ", '" + ext_doc + "','" + tel_per + "',");
                cadena.AppendFormat("'" + cel_ula + "','" + tel_fij + "','" + dir_pri + "','" + dir_ent + "','" + ema_ail + "',");
                cadena.AppendFormat("'" + ubi_gps + "', " + cod_ven + ",  " + cod_cob + ", '" + tip_atr + "','" + ide_atr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());

            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Habilita/Deshabilita persona"
        /// </summary>
        /// <param name="cod_per">Codigo del persona</param>
        /// <param name="est_ado">Estado (H=Habilitado; N=Deshabilitado)</param>
        /// <returns></returns>
        public void Fe_hab_des(int cod_per, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE adp002 SET va_est_ado = '" + est_ado + "'");
                cadena.AppendLine("            WHERE va_cod_per =  " + cod_per + "");

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza "PERSONA"
        /// </summary>
        /// <param name="cod_per">Codigo Persona</param>
        /// <param name="nom_bre">Nombre</param>
        /// <param name="ape_pat">Apellido Paterno</param>
        /// <param name="ape_mat">Apellido Materno</param>
        /// <param name="raz_soc">Razon Social</param>
        /// <param name="nom_fac">Nombre a Facturar</param>
        /// <param name="ruc_nit">RUC/NIT</param>
        /// <param name="sex_per">Sexo(H= Hombre; M=Mujer)</param>
        /// <param name="fec_nac">Fecha de Nacimiento</param>
        /// <param name="tip_doc">Tipo Documento</param>
        /// <param name="nro_doc">Carnet de Identidad</param>
        /// <param name="tel_per">Telefono Personal</param>
        /// <param name="cel_ula">Telefono Celular</param>
        /// <param name="tel_fij">Telefono Fijo</param>
        /// <param name="dir_pri">Direccion Principal</param>
        /// <param name="dir_ent">Direccion de Entrega</param>
        /// <param name="ema_ail">Email</param>
        /// <param name="cod_ven">Código de Vendedor Asignado</param>
        /// <param name="cod_cob">Código de Cobrador Asignado</param>
        /// <param name="tip_atr">Array Tipo de Atributo</param>
        /// <param name="ide_atr">Array tributo Seleccionado</param> 
        /// <returns></returns>
        public void Fe_edi_tar(int cod_per, string nom_bre, string ape_pat, string ape_mat, string raz_soc, 
                            string nom_fac, double ruc_nit, string sex_per, string fec_nac, string tip_doc,   
                              long nro_doc, string ext_doc, string tel_per, string cel_ula, string tel_fij, 
                            string dir_pri, string dir_ent, string ema_ail,    int cod_ven,    int cod_cob, 
                            string tip_atr, string ide_atr){
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" EXECUTE adp002_03a_p01 ");
                cadena.AppendFormat(""  + cod_per + ", '" + nom_bre + "','" + ape_pat + "','" + ape_mat + "','" + raz_soc + "',");
                cadena.AppendFormat("'" + nom_fac + "', " + ruc_nit + ", '" + sex_per + "', " + fec_nac + ", '" + tip_doc + "',");
                cadena.AppendFormat(" " + nro_doc + ", '" + ext_doc + "','" + tel_per + "','" + cel_ula + "','" + tel_fij + "',");
                cadena.AppendFormat("'" + dir_pri + "','" + dir_ent + "','" + ema_ail + "', " + cod_ven + ",  " + cod_cob + ",");
                cadena.AppendFormat("'" + tip_atr + "','" + ide_atr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina persona"
        /// </summary>
        /// <param name="cod_per">Codigo del persona</param>
        /// <returns></returns>
        public void Fe_eli_min(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp002_06a_p01 " + cod_per + "");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        /// <summary>
        /// Funcion "Buscar PERSONAS"
        /// </summary>
        /// <param name="cod_gru">Código Grupo</param>
        /// <param name="tip_per">Tipo de Cliente (P=Particular; E=Empresa; T=Todos)</param>
        /// <param name="tex_bus">Texto a ser buscado(</param>
        /// <param name="cri_bus">Criterio de Busqueda (0=Cod. Persona; 1=Razon Social; 2=Nombre; 3=Ape. Paterno; 4=Ape. Materno; 5=NIT; 6=Documento; 7=Teléfono)</param>
        /// <param name="est_bus">Estado (H=Habilitado; N=Deshabilitado; T=Todos)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(int cod_gru, string tip_per, string tex_bus, int cri_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp002_01a_p01 " + cod_gru + ", '" + tip_per + "', '" + tex_bus + "', " + cri_bus + ", '" + est_bus + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona"
        /// </summary>
        /// <param name="cod_per">Codigo del persona</param>
        /// <returns></returns>
        public DataTable Fe_con_per(int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp002_05a_p01 " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por Grupo de Persona"
        /// </summary>
        /// <param name="cod_gru">Código Grupo de Persoa</param>
        /// <returns></returns>
        public DataTable Fe_con_gru(int cod_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT * FROM adp002");
                cadena.AppendLine(" WHERE va_cod_gru = " + cod_gru + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por Razón Social"
        /// </summary>
        /// <param name="raz_soc">Razón Social</param>
        /// <param name="cod_per">Código de persona</param>
        /// <returns></returns>
        public DataTable Fe_con_raz(string raz_soc, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT * FROM adp002");
                cadena.AppendLine(" WHERE va_raz_soc = '" + raz_soc + "'");
                cadena.AppendLine("   AND va_cod_per <> " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por RUC/NIT"
        /// </summary>
        /// <param name="ruc_nit">RUC/NIT</param>
        /// <param name="cod_per">Código de persona</param>
        /// <returns></returns>
        public DataTable Fe_con_nit(long ruc_nit, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT * FROM adp002");
                cadena.AppendLine(" WHERE va_ruc_nit = " + ruc_nit + "");
                cadena.AppendLine("   AND va_cod_per <> " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por Nro. Documento"
        /// </summary>
        /// <param name="tip_doc">ID. Tipo de Docuemento</param>
        /// <param name="nro_doc">Nro. Documento</param>
        /// <param name="cod_per">Código de Persona</param>
        /// <returns></returns>
        public DataTable Fe_con_doc(string tip_doc, long nro_doc, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT * FROM adp002");
                cadena.AppendLine(" WHERE va_tip_doc = '" + tip_doc + "'");
                cadena.AppendLine("   AND va_nro_doc = " + nro_doc + "");
                cadena.AppendLine("   AND va_cod_per <> " + cod_per + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por Tipo Documento"
        /// </summary>
        /// <param name="tip_doc">ID. Tipo de Docuemento</param>
        /// <returns></returns>
        public DataTable Fe_con_tip(string tip_doc)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT * FROM adp002");
                cadena.AppendLine(" WHERE va_tip_doc = '" + tip_doc + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por Vendedor"
        /// </summary>
        /// <param name="cod_ven">Codigo Vendedor</param>
        /// <returns></returns>
        public DataTable Fe_con_ven(int cod_ven)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT * FROM adp002");
                cadena.AppendLine(" WHERE va_cod_ven = " + cod_ven + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta persona por Cobrador"
        /// </summary>
        /// <param name="cod_cob">Codigo Cobrador</param>
        /// <returns></returns>
        public DataTable Fe_con_cob(int cod_cob)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT * FROM adp002");
                cadena.AppendLine(" WHERE va_cod_cob = " + cod_cob + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion : Obtiene el Codigo de Persona según el Grupo de Persona
        /// </summary>
        /// <param name="cod_gru">Codigo del Grupo de persona</param>
        /// <returns></returns>
        public DataTable Fe_obt_cod(int cod_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DECLARE @va_nro_per INT ");
                cadena.AppendLine(" SELECT @va_nro_per = ISNULL(MAX(va_cod_per), " + cod_gru + " * 10000) FROM adp002 WHERE va_cod_gru = " + cod_gru + "");
                cadena.AppendLine(" SELECT (@va_nro_per + 1) - (" + cod_gru + " * 10000) AS va_nro_per");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Registro Persona 
        /// </summary>
        /// <param name="gru_ini">Grupo Inicial</param>
        /// <param name="gru_fin">Grupo Final</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R01(int gru_ini, int gru_fin, string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp002_R01 " + gru_ini + ", " + gru_fin + ", '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Registro Persona por Criterio 
        /// </summary>
        /// <param name="gru_ini">Grupo Inicial</param>
        /// <param name="gru_fin">Grupo Final</param>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="atr_ini">ID. Atributo Inicial</param>
        /// <param name="atr_fin">ID. Atributo Final</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R02(int gru_ini, int gru_fin, int ide_tip, int atr_ini, int atr_fin, string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp002_R02 " + gru_ini + ", " + gru_fin + ", " + ide_tip + ", " + atr_ini + ", " + atr_fin + ", '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Registro Persona por 2 Criterio 
        /// </summary>
        /// <param name="gru_ini">Grupo Inicial</param>
        /// <param name="gru_fin">Grupo Final</param>
        /// <param name="ide_ti1">ID. 1 Tipo de Atributo</param>
        /// <param name="atr_in1">ID. 1 Atributo Inicial</param>
        /// <param name="atr_fi1">ID. 1 Atributo Final</param>
        /// <param name="ide_ti2">ID. 2 Tipo de Atributo</param>
        /// <param name="atr_in2">ID. 2 Atributo Inicial</param>
        /// <param name="atr_fi2">ID. 2 Atributo Final</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R03(int gru_ini, int gru_fin, int ide_ti1, int atr_in1, int atr_fi1, int ide_ti2, int atr_in2, int atr_fi2, string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp002_R03 " + gru_ini + ", " + gru_fin + ", " + ide_ti1 + ", " + atr_in1 + ", " + atr_fi1 + ", " + ide_ti2 + ", " + atr_in2 + ", " + atr_fi2 + ", '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Informe: Registro Persona p/Criterio y Ruteo
        /// </summary>
        /// <param name="gru_ini">Grupo Inicial</param>
        /// <param name="gru_fin">Grupo Final</param>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="atr_ini">ID. Atributo Inicial</param>
        /// <param name="atr_fin">ID. Atributo Final</param>
        /// <param name="rut_ini">ID. Ruta Inicial</param>
        /// <param name="rut_fin">ID. Ruta Final</param>
        /// <param name="est_ado">Estado (T=Todos; H=Habilitado; N=Deshabilitado)</param>
        /// <param name="ord_dat">Ordenar Por (C=Código; N=Nombre)</param>
        /// <returns></returns>
        public DataTable Fe_inf_R04(int gru_ini, int gru_fin, int ide_tip, int atr_ini, int atr_fin, int rut_ini, int rut_fin, string est_ado, string ord_dat)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE adp002_R04 " + gru_ini + ", " + gru_fin + ", " + ide_tip + ", " + atr_ini + ", " + atr_fin + ", " + rut_ini + ", " + rut_fin + ", '" + est_ado + "', '" + ord_dat + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
   
