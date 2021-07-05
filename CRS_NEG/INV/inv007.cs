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
    /// Clase: ENCABEZADO COMPRAS
    /// </summary>
    public class inv007
    {
        //######################################################################
        //##       Tabla: inv006                                              ##
        //##      Nombre: ENCABEZADO COMPRAS                                  ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (20-09-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        StringBuilder cadena = new StringBuilder();
        string fto_feca_hora = "dd/MM/yyyy hh:mm:ss";
        string fto_fecha = "dd/MM/yyyy";

        public inv007()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }
 

        #region Metodos

        /// <summary>
        /// GRABA DOCUMENTO DE COMPRA
        /// </summary>
        /// <param name="va_cod_tmp"></param>
        /// <param name="_doc_doc"></param>
        /// <param name="_nro_tal"></param>
        /// <param name="_ges_cmp"></param>
        /// <param name="_cod_alm"></param>
        /// <param name="_cod_per"></param>
        /// <param name="_mon_cmp"></param>
        /// <param name="_fec_cmp"></param>
        /// <param name="_for_pag"></param>
        /// <param name="_cod_caj"></param>
        /// <param name="_cod_lcr"></param>
        /// <param name="_tip_cmp"></param>
        /// <param name="_ban_fac"></param>
        /// <param name="_lib_cpr"></param>
        /// <param name="_tip_cam"></param>
        /// <param name="_des_cue"></param>
        /// <param name="_obs_cmp"></param>
        /// <param name="_ref_cmp"></param>
        /// <returns></returns>
        public DataTable fu_gra_cmp(DateTime va_cod_tmp, string _doc_doc, int _nro_tal, int _ges_cmp,
            int _cod_alm, string _cod_per, string _mon_cmp, DateTime _fec_cmp, int _for_pag,
            int _cod_caj, int _cod_lcr, int _tip_cmp, int _ban_fac, int _lib_cpr, decimal _tip_cam,
            decimal _des_cue, string _obs_cmp, string _ref_cmp, string _ide_usr)
        {
            try
            {

                cadena = new StringBuilder();
                cadena.AppendLine("");
                cadena.AppendFormat(" EXECUTE inv007_02a_p01 ");
                cadena.AppendFormat(" '{0}', ", _ide_usr);
                cadena.AppendFormat(" '{0}', ",  va_cod_tmp.ToString(fto_feca_hora));
                cadena.AppendFormat(" '{0}', ", _doc_doc);
                cadena.AppendFormat("  {0} , ", _nro_tal);
                cadena.AppendFormat("  {0} , ", _ges_cmp);
                cadena.AppendFormat("  {0} , ", _cod_alm);
                cadena.AppendFormat("  {0} , ", _cod_per);
                cadena.AppendFormat(" '{0}' , ", _mon_cmp);
                cadena.AppendFormat(" '{0}' , ", _fec_cmp.ToString(fto_fecha));
                cadena.AppendFormat("  {0} , ", _for_pag);
                cadena.AppendFormat("  {0} , ", _cod_caj);
                cadena.AppendFormat("  {0} , ", _cod_lcr);
                cadena.AppendFormat("  {0} , ", _tip_cmp);
                cadena.AppendFormat("  {0} , ", _ban_fac);
                cadena.AppendFormat("  {0} , ", _lib_cpr);
                cadena.AppendFormat(" '{0}' , ", _tip_cam);
                cadena.AppendFormat(" '{0}' , ", _des_cue);
                cadena.AppendFormat(" '{0}' , ", _obs_cmp);
                cadena.AppendFormat(" '{0}'  ", _ref_cmp);
                cadena.AppendLine("");
                DataTable tabla = new DataTable();
                tabla = ob_con_ecA.fe_exe_sql(cadena.ToString());
                return tabla;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Graba tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_ITM_CMP">Tabla de detalle de compra</param>
        public int fu_gra_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ITM_CMP)
        {
            try
            {
                cadena = new StringBuilder();

                for (int i = 0; i <= _ITM_CMP.Rows.Count - 1; i++)
                {
                    cadena = new StringBuilder();
                    cadena.AppendLine(" Insert into inv007tmp ");
                    cadena.AppendFormat(" values('{0}', ", _cod_usr);
                    cadena.AppendFormat(" '{0}', ", _cod_tmp.ToString(fto_feca_hora));
                    cadena.AppendFormat("  {0} , ", _ITM_CMP.Rows[i]["va_nro_ite"].ToString());
                    cadena.AppendFormat(" '{0}' , ", _ITM_CMP.Rows[i]["va_cod_pro"].ToString());
                    cadena.AppendFormat(" '{0}' , ", _ITM_CMP.Rows[i]["va_des_pro"].ToString());
                    cadena.AppendFormat(" '{0}' , ", _ITM_CMP.Rows[i]["va_und_cmp"].ToString());
                    cadena.AppendFormat(" '{0}' , ", decimal.Parse(_ITM_CMP.Rows[i]["va_can_cmp"].ToString()));
                    cadena.AppendFormat(" '{0}' , ", decimal.Parse(_ITM_CMP.Rows[i]["va_pre_cmp"].ToString()));
                    cadena.AppendFormat(" '{0}' , ", decimal.Parse(_ITM_CMP.Rows[i]["va_imp_tot"].ToString()));
                    cadena.AppendFormat(" '{0}' ) ", _ITM_CMP.Rows[i]["va_tip_fam"].ToString());
                    cadena.AppendLine(" ");

                    ob_con_ecA.fe_exe_sql(cadena.ToString());
                }

                return 1;
            }
            catch (Exception ex)
            {
                //return 0;
                throw ex;
            }
        }


        /// <summary>
        /// Edita tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        /// <param name="_ITM_CMP">Tabla de detalle de compra</param>
        public int fu_edi_tmp(string _cod_usr, DateTime _cod_tmp, DataTable _ITM_CMP)
        {
            try
            {
                cadena = new StringBuilder();

                for (int i = 0; i <= _ITM_CMP.Rows.Count - 1; i++)
                {
                    cadena = new StringBuilder();

                    cadena.AppendLine(" UPDATE inv007tmp SET ");

                    cadena.AppendFormat(" va_cod_pro = '{0}' , ", _ITM_CMP.Rows[i]["va_cod_pro"].ToString());
                    cadena.AppendFormat(" va_des_pro = '{0}' , ", _ITM_CMP.Rows[i]["va_des_pro"].ToString());
                    cadena.AppendFormat(" va_und_cmp = '{0}' , ", _ITM_CMP.Rows[i]["va_und_cmp"].ToString());
                    cadena.AppendLine("");
                    cadena.AppendFormat(" va_can_cmp = '{0}' , ", decimal.Parse(_ITM_CMP.Rows[i]["va_can_cmp"].ToString()));
                    cadena.AppendFormat(" va_pre_uni = '{0}' , ", decimal.Parse(_ITM_CMP.Rows[i]["va_pre_cmp"].ToString()));
                    cadena.AppendFormat(" va_imp_tot = '{0}' , ", decimal.Parse(_ITM_CMP.Rows[i]["va_imp_tot"].ToString()));
                    cadena.AppendFormat(" va_tip_fam = '{0}'  ", _ITM_CMP.Rows[i]["va_tip_fam"].ToString());
                    cadena.AppendLine("");
                    cadena.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                    cadena.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(fto_feca_hora));
                    cadena.AppendFormat(" AND va_nro_itm = '{0}' ", _ITM_CMP.Rows[i]["va_nro_ite"].ToString());
                    cadena.AppendLine("");
                }
                ob_con_ecA.fe_exe_sql(cadena.ToString());
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        /// <summary>
        /// Elimina tabla temporal de detalle
        /// </summary>
        /// <param name="_ide_cmp">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        public int fu_edi_obs(string _ide_cmp, int ges_cmp, string _obs_cmp)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" UPDATE inv007 SET");
                cadena.AppendFormat("  va_obs_cmp = '{0}' ", _obs_cmp);
                cadena.AppendFormat(" WHERE va_ide_cmp = '{0}' ", _ide_cmp);
                cadena.AppendFormat(" AND va_ges_cmp = {0} ", ges_cmp);

                cadena.AppendLine("");

                ob_con_ecA.fe_exe_sql(cadena.ToString());
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        /// <summary>
        /// Elimina tabla temporal de detalle
        /// </summary>
        /// <param name="_cod_usr">Codigo usuario</param>
        /// <param name="_cod_tmp">Codigo temporal(Fecha y hora</param>
        public int fu_eli_tmp(string _cod_usr, DateTime _cod_tmp, int _nro_itm = 0)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" DELETE FROM inv007tmp ");
                cadena.AppendFormat(" WHERE va_cod_usr = '{0}' ", _cod_usr);
                cadena.AppendFormat(" AND va_cod_tmp = '{0}' ", _cod_tmp.ToString(fto_feca_hora));
                if (_nro_itm != 0)
                    cadena.AppendFormat(" AND va_nro_itm = {0} ", _nro_itm);

                cadena.AppendLine("");

                ob_con_ecA.fe_exe_sql(cadena.ToString());
                return 1;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }


        public DataTable fu_bus_car(int cod_prv, int cod_alm, DateTime fec_ini, DateTime fec_fin, string obs_cmp, string est_ado)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" inv007_01a_p01 " + cod_prv + "," + cod_alm + ",'" + fec_ini.ToString(fto_fecha) + "','" + fec_fin.ToString(fto_fecha) + "','" + obs_cmp + "','" + est_ado + "' ");
                cadena.AppendLine("");

                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Fe_inv007_05a_p01(string ar_ide_cmp, int ar_ges_cmp)
        {
            try
            {

                cadena = new StringBuilder();

                cadena.AppendFormat(" EXECUTE inv007_05a_p01  ");
                cadena.AppendLine("'" + ar_ide_cmp + "' , " + ar_ges_cmp );

                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable fu_ver_cmp(string ide_cmp, int ges_cmp)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" SELECT * FROM inv007 ");
                cadena.AppendLine(" WHERE va_ide_cmp = '" + ide_cmp + "' AND va_ges_cmp=" + ges_cmp);

                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable fu_anu_cmp(string ide_cmp, string usr_anu)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" EXECUTE inv007_04p2 '" + ide_cmp + "', '" + usr_anu + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable fu_eli_cmp(string ide_cmp, string usr_anu)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" inv007_06p2 '" + ide_cmp + "', '" + usr_anu + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// verifica anulacion de compra
        /// </summary>
        /// <param name="ide_cmp">ide de compra</param>
        /// <returns></returns>
        public DataTable fu_anu_ver(string ide_cmp)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" EXECUTE inv007_04p1 '" + ide_cmp + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// verifica Eliminacion de compra
        /// </summary>
        /// <param name="ide_cmp">ide de compra</param>
        /// <returns></returns>
        public DataTable fu_eli_ver(string ide_cmp)
        {
            try
            {
                cadena = new StringBuilder();

                cadena.AppendFormat(" EXECUTE inv007_06p1  '" + ide_cmp + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable fr_inv007_01p2(int cod_alm, DateTime fec_ini, DateTime fec_fin, int est_ado)
        {
            try
            {
                string vv_est_ado = "";
                cadena = new StringBuilder();

                switch (est_ado)
                {
                    case 0: vv_est_ado = "T"; break;
                    case 1: vv_est_ado = "V"; break;
                    case 2: vv_est_ado = "N"; break;
                }

                cadena.AppendFormat(" EXECUTE inv007_01p2 ");
                cadena.AppendLine(" " + cod_alm + ", '" + fec_ini.ToString(fto_fecha) + "', '" + fec_fin.ToString(fto_fecha) + "', '" + vv_est_ado + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable Fe_inv007_R01(int cod_pe1, int cod_pe2, int cod_bo1, int cod_bo2,DateTime fec_ini, DateTime fec_fin)
        {
            try
            {

                cadena = new StringBuilder();

                cadena.AppendFormat(" EXECUTE inv007_R01 ");
                cadena.AppendLine(cod_pe1 + "," + cod_pe2 + "," + cod_bo1 + "," + cod_bo2 + ",'" + fec_ini.ToString(fto_fecha) + "', '" + fec_fin.ToString(fto_fecha) + "','T' ");

                return ob_con_ecA.fe_exe_sql(cadena.ToString()); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion


    }
}
