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
    ///  Clase PLAN DE PAGO
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class ecp001
    {
        //######################################################################
        //##       Tabla: ecp001                                              ##
        //##      Nombre: PLAN DE PAGO                                        ##
        //## Descripcion: Plan de pago de cuentas por cobrar/pagar            ##         
        //##       Autor: CHL  - (11-10-2021)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Documento</param>
        /// <param name="nom_tip">Nombre Tipo de Documento</param>
        /// <returns></returns>
        public void Fe_nue_plg(int cod_plg, string des_pgl, int nro_cuo, int int_dia, int dia_ini)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ecp001 VALUES ('" + cod_plg + "', '" + des_pgl + "', '" + nro_cuo + "', '" + int_dia + "', '" + dia_ini + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica Plan de Pago"
        /// </summary>
        /// <param name="cod_plg">Codigo del Plan de Pago</param>
        /// <param name="des_pgl">Descripcion</param>
        /// <returns></returns>
        public void Fe_edi_plg(int cod_plg, string des_pgl, int nro_cuo, int int_dia, int dia_ini)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ecp001 SET " +
                    " va_des_plg='" + des_pgl + "', va_nro_cuo='" + nro_cuo + "'," +
                    " va_int_dia='" + int_dia + "', va_dia_ini='" + dia_ini + "' " +
                    " WHERE va_cod_plg = '" + cod_plg + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }



        /// <summary>
        /// funcion "Elimina Plan de Pago"
        /// </summary>
        /// <param name="cod_plg">Codigo del Plan de Pago</param>
        /// <returns></returns>
        public void Fe_eli_plg(int cod_plg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" DELETE ecp005 ");
                cadena.AppendLine(" WHERE  va_cod_plg = '" + cod_plg + "'");
                
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }


        /// <summary>
        /// funcion "Consulta Plan de Pago"
        /// </summary>
        /// <param name="cod_plg">Codigo del Plan de Pago</param>
        /// <returns></returns>
        public DataTable Fe_con_plg(int cod_plg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT * FROM ecp005 ");
                cadena.AppendLine(" WHERE  va_cod_plg = " + "'" + cod_plg + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA TIPO DE DOCUMENTO"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (0=va_ide_tip; 1=va_nom_tip)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string val_bus, int prm_bus, string est_bus, int tipo = 1)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" select * from ecp005 ");

                if (tipo == 1)
                {
                    switch (prm_bus)
                    {
                        case 1: cadena.AppendLine(" where va_cod_plg like '" + val_bus + "%' "); break;
                        case 2: cadena.AppendLine(" where va_des_plg like '" + val_bus + "%' "); break;
                    }

                    switch (est_bus)
                    {
                        case "0": est_bus = "T"; break;
                        case "1": est_bus = "H"; break;
                        case "2": est_bus = "N"; break;
                    }

                    if (est_bus != "T")
                    {
                        cadena.AppendLine(" and va_est_ado ='" + est_bus + "'");
                    }
                }
                else if (tipo == 2)
                {
                    cadena.AppendLine(" where va_cod_plg = '" + val_bus + "' ");
                }


                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                     

    }
}
