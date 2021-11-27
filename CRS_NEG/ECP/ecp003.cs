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
    ///  Clase INSCRIPCION PERSONA-LIBRETA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class ecp003
    {
        //######################################################################
        //##       Tabla: ecp003                                              ##
        //##      Nombre: INSCRIPCION PERSONA-LIBRETA                         ##
        //## Descripcion: Inscripcion de Persona-Libreta                      ##         
        //##       Autor: CHL  - (11-10-2021)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA SUSCRIPCION LIBRETA"
        /// </summary>
        /// <param name="cod_lib">Codigo de libreta</param>
        /// <param name="cod_per">Codigo de persona</param>
        /// <param name="cod_plg">Codigo de plan de pago</param>
        /// <param name="mto_lim">Monto limite de credito</param>
        /// <param name="sal_act">Saldo actual del monto limite</param>
        /// <param name="max_cuo">Maximo de cuotas vencidas</param>
        /// <param name="fec_exp">Fecha de expiración de la suscripcion de la libreta</param>
        public void Fe_nue_sus(int cod_lib, int cod_per, int cod_plg, decimal mto_lim, decimal sal_act, int max_cuo, DateTime fec_exp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ecp003 VALUES (" + cod_lib + ", " + cod_per + ", '" + mto_lim + "', '" + sal_act + "', " + max_cuo + ", '" + fec_exp + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "EDITA SUSCRIPCION LIBRETA"
        /// </summary>
        /// <param name="cod_lib">Codigo de libreta</param>
        /// <param name="cod_per">Codigo de persona</param>
        /// <param name="cod_plg">Codigo de plan de pago</param>
        /// <param name="mto_lim">Monto limite de credito</param>
        /// <param name="sal_act">Saldo actual del monto limite</param>
        /// <param name="max_cuo">Maximo de cuotas vencidas</param>
        /// <param name="fec_exp">Fecha de expiración de la suscripcion de la libreta</param>
        public void Fe_edi_sus(int cod_lib, int cod_per, int cod_plg, decimal mto_lim, decimal sal_act, int max_cuo, DateTime fec_exp)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ecp003 SET va_cod_plg = " + cod_plg + ", va_mto_lim = '" + mto_lim + "',  va_sal_act = '" + sal_act + "',  va_max_cuo = '" + max_cuo + "',  va_fec_exp = '" + fec_exp + "' ");
                cadena.AppendLine(" WHERE va_cod_lib = '" + cod_lib + "' AND va_cod_per = " + cod_per ); 

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cod_lib">Codigo del Libreta</param>
        /// <returns></returns>
        /// 
        //--asdfasd



        /// <summary>
        /// funcion "Habilita SUSCRIPCION PERSONA"
        /// </summary>
        /// <param name="cod_lib">Codigo de Libreta</param>
        /// <param name="cod_per">Codigo de persona</param>
        public void Fe_hab_sus(int cod_lib, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE ecp003 SET va_est_ado = 'H'");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib + " AND  va_cod_per = " + cod_per  );

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// funcion "Deshabilita Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo de Libreta</param>
        /// <param name="cod_per">Codigo de persona</param>
        /// <returns></returns>
        public void Fe_dhb_sus(int cod_lib, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE ecp003 SET va_est_ado = 'N'");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib + " AND  va_cod_per = " + cod_per);

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// funcion "Elimina Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo de Libreta</param>
        /// <param name="cod_per">Codigo de persona</param>
        /// <returns></returns>
        public void Fe_eli_sus(int cod_lib, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" DELETE ecp003 ");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib + " AND  va_cod_per = " + cod_per);
                //ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex){
                throw ex;
            }
        }


        /// <summary>
        /// funcion "Consulta Suscripcion Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo de Libreta</param>
        /// <param name="cod_per">Codigo de persona</param>
        /// <returns></returns>
        public DataTable Fe_con_sus(int cod_lib, int cod_per)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT * FROM ecp003 ");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib + " AND  va_cod_per = " + cod_per);

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Función: "LISTA SUSCRIPCION LIBRETA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (1=va_cod_lib; 2=va_des_lib)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_lis_tar( int cod_per, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" EXEC ecp003_01a_p01 ");
                cadena.AppendLine(cod_per + ", '" + est_ado + "'");
               
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                     

    }
}
