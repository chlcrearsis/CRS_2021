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
    /// Clase: GRUPO VENTAS
    /// </summary>
    public class cmr006
    {
        //######################################################################
        //##       Tabla: res001                                              ##
        //##      Nombre: DETALLE VENTAS                                       ##
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

        string ft_fch_hor = "dd/MM/yyyy hh:mm:ss";

        public cmr006()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 
        //public void Fe_crea(string ar_doc_vta, int ar_nro_tal, int ar_nro_vta, int ar_ges_vta, int ar_ite_vta, string ar_cod_pro, string ar_des_pro, int ar_can_uni, 
        //    decimal ar_pre_lis, decimal ar_mto_brB)
        //{
        //    string ide_vta = "";
         
        //    string nro_tal;
        //    string nro_doc;
        //    nro_tal = (1000 + ar_nro_tal).ToString();
        //    nro_tal = nro_tal.Substring(1, 3);

        //    nro_doc = (1000000 + ar_nro_vta).ToString();
        //    nro_doc = nro_doc.Substring(1, 6);

        //    //** Componer el identificador de la venta
        //    ide_vta = ar_doc_vta + "-" + nro_tal + "-" + nro_doc.ToString();

        //    cadena = " INSERT INTO cmr006 VALUES('" + ar_doc_vta + "', " + ar_nro_tal + ", " + ar_nro_vta + ", " +
        //        " " + ar_ges_vta + ",'" + ide_vta + "'," + ar_ite_vta + ", '" + ar_cod_pro + "', '" + ar_des_pro + "','1','UND','UND',1, " +
        //        " '" + ar_can_uni + "', '" + ar_can_uni + "', '" + ar_pre_lis + "', '" + ar_pre_lis + "','" + ar_pre_lis + "','0','0', " +
        //        " 0 , '" + ar_mto_brB + "','" + ar_mto_brB + "', 0, 0, 0,0,0,0 )";

        //    ob_con_ecA.fe_exe_sql(cadena);
            
        //}








        /// <summary>
        /// Graba tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_ite_VTA">Tabla de detalle de Venta</param>
        public int fu_gra_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ite_VTA)
            //string _cod_und, decimal _can_tid, decimal _pre_uni, decimal _pre_tot, decimal _pre_lis,
            //decimal _des_cue, decimal _por_cen)
        {
            try
            {
                cadena_stb.Clear();

                for (int i = 0; i <= _ite_VTA.Rows.Count - 1; i++)
                {

                    cadena_stb.AppendLine(" Insert into cmr006tmp ");
                    cadena_stb.AppendFormat(" values('{0}', ", _cod_usr);
                    cadena_stb.AppendFormat(" '{0}', ", _cod_tmp.ToString(ft_fch_hor));
                    cadena_stb.AppendFormat("  {0} , ", _ite_VTA.Rows[i]["va_nro_ite"].ToString());
                    cadena_stb.AppendFormat(" '{0}' , ", _ite_VTA.Rows[i]["va_cod_pro"].ToString());
                    cadena_stb.AppendFormat(" '{0}' , ", _ite_VTA.Rows[i]["va_des_pro"].ToString());// _ite_VTA.Rows[i]["va_nom_pro"].ToString());
                    cadena_stb.AppendFormat("  {0}  , ",0); // 0 = siempre unidad de venta
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_VTA.Rows[i]["va_can_tid"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_VTA.Rows[i]["va_pre_uni"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_VTA.Rows[i]["va_pre_tot"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_VTA.Rows[i]["va_pre_lis"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' , ", decimal.Parse(_ite_VTA.Rows[i]["va_des_cue"].ToString()));
                    cadena_stb.AppendFormat(" '{0}' )  ", decimal.Parse(_ite_VTA.Rows[i]["va_por_des"].ToString()));

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
        /// <param name="_ite_vta">Tabla de detalle de Venta</param>
        public int fu_edi_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ite_VTA)
        {
            try
            {
                cadena = "";

                for (int i = 0; i <= _ite_VTA.Rows.Count - 1; i++)
                {
                    cadena = " UPDATE cmr006tmp SET ";

                    cadena += " va_cod_pro = '"+ _ite_VTA.Rows[i]["va_cod_pro"].ToString() + "', ";
                    //cadena += " va_des_pro = '"+ _ite_VTA.Rows[i]["va_not_ite"].ToString() + "', ";
                    cadena += " va_opc_und = "+ 0 + "," ;
                   
                    cadena += " va_can_tid = '" + decimal.Parse(_ite_VTA.Rows[i]["va_can_tid"].ToString()) + "', ";
                    cadena += " va_pre_uni = '" + decimal.Parse(_ite_VTA.Rows[i]["va_pre_uni"].ToString()) + "', ";

                    cadena += " va_pre_tot = '"+ decimal.Parse(_ite_VTA.Rows[i]["va_pre_tot"].ToString()) + "', ";

                    cadena +=" va_pre_lis = '"+ decimal.Parse(_ite_VTA.Rows[i]["va_pre_lis"].ToString()) + "', ";
                    cadena +=" va_des_cue = '"+ decimal.Parse(_ite_VTA.Rows[i]["va_des_cue"].ToString()) + "', ";
                    cadena +=" va_por_cen = '"+ decimal.Parse(_ite_VTA.Rows[i]["va_por_des"].ToString()) + "' ";
                    

                    cadena += " WHERE va_cod_usr = '"+ _cod_usr +"' ";
                    cadena +=" AND va_cod_tmp = '"+ _cod_tmp.ToString(ft_fch_hor)+"'";
                    cadena +=" AND va_nro_itm = '"+ _ite_VTA.Rows[i]["va_nro_ite"].ToString()+"'";
                
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
        /// <param name="_nro_ite">Nro de item que desea eliminar [0= elimina todos los items] </param>
        public int fu_eli_tmp(string _cod_usr, DateTime _cod_tmp, int _nro_ite = 0)
        {
            try
            {
                cadena_stb = new StringBuilder();

                cadena_stb.AppendFormat(" DELETE FROM cmr006tmp ");
                cadena_stb.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                cadena_stb.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(ft_fch_hor));
                if ((_nro_ite ) != 0)
                    cadena_stb.AppendFormat(" AND va_nro_itm = {0} ", _nro_ite );

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
        /// <param name="_nro_ite">Nro de item que desea editar </param>
        /// <param name="_new_val">Nuevo valor a asignar al item</param>
        public int fu_edi_ite_tmp(string _cod_usr, DateTime _cod_tmp, int _nro_ite, int _new_val)
        {
            try
            {
                cadena_stb = new StringBuilder();

                cadena_stb.AppendFormat(" UPDATE cmr006tmp ");
                cadena_stb.AppendFormat(" SET va_nro_ite = {0} ", _new_val);
                cadena_stb.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                cadena_stb.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(ft_fch_hor));
                cadena_stb.AppendFormat(" AND va_nro_ite = {0} ", _nro_ite);

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
