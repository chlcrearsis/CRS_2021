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
    /// Clase:  pedido 
    /// </summary>
    public class cmr008
    {
        //######################################################################
        //##       Tabla: cmr008                                              ##
        //##      Nombre: DETALLE PEDIDO                                      ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (12-03-2021)                                 ##
        //######################################################################

         conexion_a ob_con_ecA = new conexion_a();

        //public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        //public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        //public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        //public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        //public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
        StringBuilder cadena_stb = new StringBuilder();

        string ft_fch_hor = "dd/MM/yyyy hh:mm:ss";

        /// <summary>
        /// Graba tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_ite_ped">Tabla de detalle de pedido</param>
        public int fu_gra_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ite_ped)
            //string _cod_und, decimal _can_tid, decimal _pre_uni, decimal _pre_tot, decimal _pre_lis,
            //decimal _des_cue, decimal _por_cen)
        {
            try
            {
                cadena_stb.Clear();

                for (int i = 0; i <= _ite_ped.Rows.Count - 1; i++)
                {

                    cadena_stb.AppendLine(" Insert into cmr008tmp ");
                    cadena_stb.AppendFormat(" values('{0}', ", _cod_usr);
                    cadena_stb.AppendFormat(" '{0}', ", _cod_tmp.ToString(ft_fch_hor));
                    cadena_stb.AppendFormat("  {0} , ", _ite_ped.Rows[i]["va_nro_ite"].ToString());
                    cadena_stb.AppendFormat(" '{0}' , ", _ite_ped.Rows[i]["va_cod_pro"].ToString());
                    cadena_stb.AppendFormat(" '{0}' , ", _ite_ped.Rows[i]["va_des_pro"].ToString());// _ite_ped.Rows[i]["va_nom_pro"].ToString());
                    cadena_stb.AppendFormat("  {0}  , ",0); // 0 = siempre unidad de pedido
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_ped.Rows[i]["va_can_tid"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_ped.Rows[i]["va_pre_uni"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_ped.Rows[i]["va_pre_tot"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_ped.Rows[i]["va_pre_lis"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_ped.Rows[i]["va_des_cue"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' )  ", decimal.Parse(_ite_ped.Rows[i]["va_por_des"].ToString()));

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
        /// <param name="_ite_ped">Tabla de detalle de pedido</param>
        public int fu_edi_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ite_ped)
        {
            try
            {
                cadena = "";

                for (int i = 0; i <= _ite_ped.Rows.Count - 1; i++)
                {
                    cadena = " UPDATE cmr008tmp SET ";

                    cadena += " va_cod_pro = '"+ _ite_ped.Rows[i]["va_cod_pro"].ToString() + "', ";
                    //cadena += " va_des_pro = '"+ _ite_ped.Rows[i]["va_not_ite"].ToString() + "', ";
                    cadena += " va_opc_und = "+ 0 + "," ;
                   
                    cadena += " va_can_tid = '" + decimal.Parse(_ite_ped.Rows[i]["va_can_tid"].ToString()) + "', ";
                    cadena += " va_pre_uni = '" + decimal.Parse(_ite_ped.Rows[i]["va_pre_uni"].ToString()) + "', ";

                    cadena += " va_pre_tot = '"+ decimal.Parse(_ite_ped.Rows[i]["va_pre_tot"].ToString()) + "', ";

                    cadena +=" va_pre_lis = '"+ decimal.Parse(_ite_ped.Rows[i]["va_pre_lis"].ToString()) + "', ";
                    cadena +=" va_des_cue = '"+ decimal.Parse(_ite_ped.Rows[i]["va_des_cue"].ToString()) + "', ";
                    cadena +=" va_por_cen = '"+ decimal.Parse(_ite_ped.Rows[i]["va_por_des"].ToString()) + "' ";
                    

                    cadena += " WHERE va_cod_usr = '"+ _cod_usr +"' ";
                    cadena +=" AND va_cod_tmp = '"+ _cod_tmp.ToString(ft_fch_hor)+"'";
                    cadena +=" AND va_nro_itm = '"+ _ite_ped.Rows[i]["va_nro_ite"].ToString()+"'";
                
                }
                ob_con_ecA.fe_exe_sql(cadena);
                return 1;
            }
            catch (Exception ex)
            {
                // return 0;
                throw ex;
            }
        }

        /// <summary>
        /// Elimina tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_nro_ite">Nro de item que desea eliminar [0= elimina todos los items] </param>
        public int fu_eli_tmp(string _cod_usr, DateTime _cod_tmp, int _nro_ite = 0)
        {
            try
            {
                cadena_stb = new StringBuilder();

                cadena_stb.AppendFormat(" DELETE FROM cmr008tmp ");
                cadena_stb.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                cadena_stb.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(ft_fch_hor));
                if ((_nro_ite ) != 0)
                    cadena_stb.AppendFormat(" AND va_nro_itm = {0} ", _nro_ite );

                cadena_stb.AppendLine("");

                ob_con_ecA.fe_exe_sql(cadena_stb.ToString());
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// Edita item de la temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_nro_ite">Nro de item que desea editar </param>
        /// <param name="_new_val">Nuevo valor a asignar al item</param>
        public int fu_edi_ite_tmp(string _cod_usr, DateTime _cod_tmp, int _nro_ite, int _new_val)
        {
            try
            {
                cadena_stb = new StringBuilder();

                cadena_stb.AppendFormat(" UPDATE cmr008tmp ");
                cadena_stb.AppendFormat(" SET va_nro_ite = {0} ", _new_val);
                cadena_stb.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                cadena_stb.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(ft_fch_hor));
                cadena_stb.AppendFormat(" AND va_nro_ite = {0} ", _nro_ite);

                cadena_stb.AppendLine("");

                ob_con_ecA.fe_exe_sql(cadena_stb.ToString());
                return 1;
            }
            catch (Exception ex )
            {
                return 0;
                throw ex;
            }
        }

    }
}
