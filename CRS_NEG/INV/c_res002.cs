using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;

namespace CRS_NEG.INV
{
    /// <summary>
    /// Clase: GRUPO VENTAS RESTAURANT
    /// </summary>
    public class c_res002
    {
        //######################################################################
        //##       Tabla: res001                                              ##
        //##      Nombre: DETALLE VENTAS RESTAURANT                           ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (22-07-2020)                                 ##
        //######################################################################

         conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
        StringBuilder cadena_stb = new StringBuilder();

        string fto_fecha_hora = "dd/MM/yyyy hh:mm:ss";
        string fto_fecha = "dd/MM/yyyy";


        public c_res002()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        /// <summary>
        /// Graba tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_ITM_VTA">Tabla de detalle de Venta</param>
        public int fu_gra_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ITM_VTA,
            string _cod_und, decimal _can_tid, decimal _pre_uni, decimal _pre_tot, decimal _pre_lis,
            decimal _des_cue, decimal _por_cen)
        {
            try
            {
                cadena_stb.Clear();

                for (int i = 0; i <= _ITM_VTA.Rows.Count - 1; i++)
                {

                    cadena_stb.AppendLine(" Insert into res002tmp ");
                    cadena_stb.AppendFormat(" values('{0}', ", _cod_usr);
                    cadena_stb.AppendFormat(" '{0}', ", _cod_tmp.ToString(fto_fecha_hora));
                    cadena_stb.AppendFormat("  {0} , ", _ITM_VTA.Rows[i]["va_nro_itm"].ToString());
                    cadena_stb.AppendFormat(" '{0}' , ", _ITM_VTA.Rows[i]["va_cod_pro"].ToString());
                    cadena_stb.AppendFormat(" '{0}' , ", "");// _ITM_VTA.Rows[i]["va_nom_pro"].ToString());
                    cadena_stb.AppendFormat("  {0}  , ",0);
                    cadena_stb.AppendFormat(" '{0}' , ", _can_tid);
                    cadena_stb.AppendFormat(" '{0}' , ", _pre_uni);
                    cadena_stb.AppendFormat(" '{0}' , ", _pre_tot);
                    cadena_stb.AppendFormat(" '{0}' , ", _pre_lis);
                    cadena_stb.AppendFormat(" '{0}' , ", _des_cue);
                    cadena_stb.AppendFormat(" '{0}' ) ", _por_cen);
                    cadena_stb.AppendLine("");
                }
                ob_con_ecA.fe_exe_sql(cadena_stb.ToString());
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        /// <summary>
        /// Edita tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_ITM_vta">Tabla de detalle de Venta</param>
        public int fu_edi_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ITM_VTA)
        {
            try
            {
                cadena = "";

                for (int i = 0; i <= _ITM_VTA.Rows.Count - 1; i++)
                {
                    cadena = " UPDATE res002tmp SET ";

                    cadena += " va_cod_pro = '"+ _ITM_VTA.Rows[i]["va_cod_pro"].ToString() + "', ";
                    cadena += " va_des_pro = '"+ _ITM_VTA.Rows[i]["va_not_itm"].ToString() + "', ";
                    cadena += " va_opc_und = "+ 0 + "," ;
                   
                    cadena += " va_can_tid = '" + decimal.Parse(_ITM_VTA.Rows[i]["va_can_uni"].ToString()) + "', ";
                    cadena += " va_pre_uni = '" + decimal.Parse(_ITM_VTA.Rows[i]["va_pre_uni"].ToString()) + "', ";

                    cadena += " va_pre_tot = '"+ decimal.Parse(_ITM_VTA.Rows[i]["va_tot_bru"].ToString()) + "', ";

                    cadena +=" va_pre_lis = '"+ decimal.Parse(_ITM_VTA.Rows[i]["va_pre_uni"].ToString()) + "', ";
                    cadena +=" va_des_cue = '"+ 0 +"', ";
                    cadena +=" va_por_cen = '"+ 0 +"' ";

                    cadena +=" WHERE va_cod_usr = '"+ _cod_usr +"' ";
                    cadena +=" AND va_cod_tmp = '"+_cod_tmp.ToString(fto_fecha_hora)+"'";
                    cadena +=" AND va_nro_itm = '"+ _ITM_VTA.Rows[i]["va_nro_itm"].ToString()+"'";
                
                }
                ob_con_ecA.fe_exe_sql(cadena);
                return 1;
            }
            catch (Exception)
            {
                // return 0;
                throw;
            }
        }

        /// <summary>
        /// Elimina tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_nro_itm">Nro de item que desea eliminar [0= elimina todos los items] </param>
        public int fu_eli_tmp(string _cod_usr, DateTime _cod_tmp, int _nro_itm = 0)
        {
            try
            {
                cadena_stb = new StringBuilder();

                cadena_stb.AppendFormat(" DELETE FROM res002tmp ");
                cadena_stb.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                cadena_stb.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(fto_fecha_hora));
                if (_nro_itm != 0)
                    cadena_stb.AppendFormat(" AND va_nro_itm = {0} ", _nro_itm);

                cadena_stb.AppendLine("");

                ob_con_ecA.fe_exe_sql(cadena_stb.ToString());
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        /// <summary>
        /// Edita item de la temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_nro_itm">Nro de item que desea editar </param>
        /// <param name="_new_val">Nuevo valor a asignar al item</param>
        public int fu_edi_itm_tmp(string _cod_usr, DateTime _cod_tmp, int _nro_itm, int _new_val)
        {
            try
            {
                cadena_stb = new StringBuilder();

                cadena_stb.AppendFormat(" UPDATE res002tmp ");
                cadena_stb.AppendFormat(" SET va_nro_itm = {0} ", _new_val);
                cadena_stb.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                cadena_stb.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(fto_fecha_hora));
                cadena_stb.AppendFormat(" AND va_nro_itm = {0} ", _nro_itm);

                cadena_stb.AppendLine("");

                ob_con_ecA.fe_exe_sql(cadena_stb.ToString());
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

    }
}
