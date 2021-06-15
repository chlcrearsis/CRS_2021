using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG.ADS
{
    /// <summary>
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// Clase T.C. Bs/Us
    /// ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class c_ads022
    {
        //######################################################################
        //##       Tabla: ads022                                              ##
        //##      Nombre: Tipo de cambio bs/us                                ##
        //## Descripcion: Tipo de cambio Bs/Us                                ##         
        //##       Autor: CHL - (22-04-2021)                                  ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";


        public c_ads022()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }




        /// <summary>
        /// Cadena de Comando SQL
        /// </summary>
        StringBuilder vv_str_sql = new StringBuilder();

        /// <summary>
        ///  Busca tipos de cambio de un mes en el año
        /// </summary>
        /// <param name="val_mes">Numero de mes</param>
        /// <param name="val_año">año</param>
        /// <returns></returns>
        public DataTable Fe_fil_tic(int val_mes, int val_año)
        {
            try
            {
                DateTime fec_ini;
                DateTime fec_fin;

                fec_ini = Convert.ToDateTime("01/" + val_mes + "/" + val_año);
                fec_fin = fec_ini.AddMonths(1);
                fec_fin = fec_fin.AddDays(-1);

                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" select * from ads022  ");
                vv_str_sql.AppendLine(" where va_fec_bus BETWEEN '" + fec_ini.ToShortDateString() + "' AND '" + fec_fin.ToShortDateString() + "'");

                return ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Funcion "inserta nueva T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">Fecha de T.C. Bs</param>
        /// <param name="val_bus">Valor de T.C. Bs</param>
        /// <returns></returns>
        public void Fe_reg_tic(DateTime fec_bus, string val_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" INSERT INTO ads022 VALUES ");
                vv_str_sql.AppendLine(" ('" + fec_bus.ToShortDateString() + "', '" + val_bus + "')");

                ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">Fecha de T.C. Bs</param>
        /// <param name="val_bus">Valor de T.C. Bs</param>
        /// <returns></returns>
        public void Fe_reg_ran(DateTime fec_ini, DateTime fec_fin, string val_bus)
        {
            try
            {
                int nro_dia = 0;
                DateTime fec_aux;

                //intervalo de dias
                nro_dia = (fec_fin - fec_ini).Days;

                vv_str_sql = new StringBuilder();

                for (int i = 0; i <= nro_dia; i++)
                {
                    vv_str_sql.AppendLine(" INSERT INTO ads022 VALUES ");

                    fec_aux = fec_ini.AddDays(i);
                    vv_str_sql.AppendLine(" ('" + fec_aux.ToShortDateString() + "', '" + val_bus + "')");
                }
                ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Consulta T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">Fecha de la T.C. Bs/Us</param>
        /// <returns></returns>
        public DataTable Fe_con_tic(string fec_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" SELECT * FROM ads022 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_bus ='" + fec_bus + "'");

                return ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina T.C. Bs/Us"
        /// </summary>
        /// <param name="fec_bus">>Codigo de T.C. Bs/Us</param>
        /// <returns></returns>
        public void Fe_eli_tic(string fec_bus)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ads022 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_bus = '" + fec_bus + "'");

                ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina T.C. Bs/Us por rango de fecha
        /// </summary>
        /// <param name="fec_ini">Fecha inicial</param>
        /// <param name="fec_fin">Fecha Final</param>
        /// <returns></returns>
        public void Fe_eli_tic(DateTime fec_ini, DateTime fec_fin)
        {
            try
            {
                vv_str_sql = new StringBuilder();
                vv_str_sql.AppendLine(" DELETE ads022 ");
                vv_str_sql.AppendLine(" WHERE  va_fec_bus BETWEEN '" + fec_ini.ToShortDateString() + "' AND '" + fec_fin.ToShortDateString() + "'");

                ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
