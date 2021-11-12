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
        /// Funcion "REGISTRA LIBRETA"
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Documento</param>
        /// <param name="nom_tip">Nombre Tipo de Documento</param>
        /// <returns></returns>
        public void Fe_nue_lib(int cod_lib, string des_pgl, int tip_lib, string mon_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ecp002 VALUES (" + cod_lib + ", '" + des_pgl + "','', " + tip_lib + ", '" + mon_lib + "', 'H')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Modifica Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo del Libreta</param>
        /// <param name="des_pgl">Descripcion</param>
        /// <returns></returns>
        public void Fe_edi_lib(int cod_lib, string des_pgl)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ecp002 SET " +
                    " va_des_lib='" + des_pgl + "' " +
                    " WHERE va_cod_lib = '" + cod_lib + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// funcion "Habilita Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo del Libreta</param>
        /// <returns></returns>
        public void Fe_hab_lib(int cod_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE ecp002 SET va_est_ado = 'H'");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib );

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
        /// <param name="cod_lib">Codigo del Libreta</param>
        /// <returns></returns>
        public void Fe_dhb_lib(int cod_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE ecp002 SET va_est_ado = 'N'");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib );

                //ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// funcion "Elimina Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo del Libreta</param>
        /// <returns></returns>
        public void Fe_eli_lib(int cod_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" DELETE ecp002 ");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib );
                
                //ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }


        /// <summary>
        /// funcion "Consulta Libreta"
        /// </summary>
        /// <param name="cod_lib">Codigo del Libreta</param>
        /// <returns></returns>
        public DataTable Fe_con_lib(int cod_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT * FROM ecp002 ");
                cadena.AppendLine(" WHERE  va_cod_lib = " + cod_lib  );

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }catch (Exception ex){
                throw ex;
            }
        }

        /// <summary>
        /// Función: "FILTRA LIBRETA"
        /// </summary>
        /// <param name="cri_bus">Criterio de Busqueda</param>
        /// <param name="prm_bus">Parametros de Busqueda (1=va_cod_lib; 2=va_des_lib)</param>
        /// <param name="est_bus">Estado (0=Todos; 1=Habilitado; 2=Deshabilitado)</param>
        /// <returns></returns>
        public DataTable Fe_bus_car(string val_bus, int prm_bus, string est_bus, int tip_lib)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" select * from ecp002 ");

                switch (prm_bus)
                {
                    case 1: cadena.AppendLine(" where va_cod_lib like '" + val_bus + "%' "); break;
                    case 2: cadena.AppendLine(" where va_des_lib like '" + val_bus + "%' "); break;
                }

                if (tip_lib != 0)
                    cadena.AppendLine(" and va_tip_lib = " + tip_lib );

                if (est_bus != "T")
                    cadena.AppendLine(" and va_est_ado ='" + est_bus + "'");
              
            

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                     

    }
}
