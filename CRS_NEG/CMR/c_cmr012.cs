using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG.CMR
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase GRUPO DE PERSONA
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_cmr012
    {
        //######################################################################
        //##       Tabla: cmr012                                              ##
        //##      Nombre: GRUPO DE PERSONAS                                   ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        StringBuilder cadena;



        public c_cmr012()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        public DataTable Fe_bus_car(string val_bus, int prm_bus, string est_bus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" select * from cmr012  ");

                switch (prm_bus)
                {
                    case 0: cadena.AppendLine(" where va_cod_gru like '" + val_bus + "%' "); break;
                    case 1: cadena.AppendLine(" where va_nom_gru like '" + val_bus + "%' "); break;

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

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //}
        /// <summary>
        /// Funcion "Registrar GRUPO DE PERSONA"
        /// </summary>
        /// <param name="cod_gru">Codigo del GRUPO de persona</param>
        /// <param name="nom_gru">nombre del GRUPO de persona</param>
        /// <returns></returns>
        public void Fe_crea(int cod_gru, string nom_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" INSERT INTO cmr012 VALUES ");
                cadena.AppendLine(" (" + cod_gru + ", '" + nom_gru + "','H')");

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
        public void Fe_edi_gru(int cod_gru, string nom_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" UPDATE cmr012 SET ");
                cadena.AppendLine(" va_nom_gru='" + nom_gru + "'");
                cadena.AppendLine(" WHERE va_cod_gru =" + cod_gru);

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
                cadena.AppendLine(" UPDATE cmr012 SET ");
                cadena.AppendLine(" va_est_ado='" + est_ado + "' ");
                cadena.AppendLine(" WHERE  va_cod_gru = '" + cod_gru + "'");

                ob_con_ecA.fe_exe_sql(cadena.ToString());

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
                cadena.AppendLine(" SELECT * FROM cmr012   ");
                cadena.AppendLine(" WHERE va_cod_gru =" + cod_gru + " ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Fe_obt_gru()
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" SELECT * FROM cmr012   ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
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
        public void Fe_eli_gru(int cod_gru)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine(" DELETE cmr012 ");
                cadena.AppendLine(" WHERE va_cod_gru ='" + cod_gru + "' ");

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
