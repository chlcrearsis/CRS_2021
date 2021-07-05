using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
using CRS_NEG;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: pedido
    /// </summary>
    public class cmr007
    {
        //######################################################################
        //##       Tabla: cmr007                                              ##
        //##      Nombre: pedido                                              ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (12-03-2021)                                 ##
        //######################################################################

 
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";
        string fto_fecha_hora = "dd/MM/yyyy hh:mm:ss";
        string fto_fecha = "dd/MM/yyyy";
        ads005 o_ads005 = new ads005();
        DataTable Tab_ads005;


        public cmr007()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }



        private DateTime Fi_fec_act()
        {
            DateTime fec_act;
            cadena = "SELECT GETDATE()";
            DataTable tabla = ob_con_ecA.fe_exe_sql(cadena);
            fec_act = DateTime.Parse(tabla.Rows[0][0].ToString());

            return fec_act;
        }

        /// <summary>
        /// Procedimiento que verifica datos antes de grabarlos
        /// </summary>
        /// <param name="ar_cod_tmp">Codigo de la temporal</param>
        /// <param name="ar_pla_ped">Plantilla de pedido</param>
        /// <param name="ar_cod_bod">Bodega</param>
        /// <param name="ar_cod_cli">codigo Cliente</param>
        /// <param name="ar_nit_cli">Nit del cliente</param>
        /// <param name="ar_raz_soc">Razon Social del cliente</param>
        /// <param name="ar_fec_ped">Fecha de pedido</param>
        /// <param name="ar_for_pag">Forma de pago(0 = Contado; 1 = Credito)</param>
        /// <param name="ar_lis_pre">Lista de precio usada en la pedido</param>
        /// <param name="ar_cod_caj">Codigo de caja</param>
        /// <param name="ar_lin_cxc"></param>
        /// <returns> Si no pasa alguna validacion retorna mensaje del error </returns>
        public string Fi_ver_dat( DateTime ar_cod_tmp, int ar_pla_ped, int ar_cod_bod, int ar_cod_cli, 
                DateTime ar_fec_ped, int ar_for_pag, int ar_lis_pre)
        {
            try
            {
                
                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendFormat(" EXECUTE cmr007_02a_p02 ");
                vv_str_sql.AppendFormat(" '{0}', ", ar_cod_tmp.ToString(fto_fecha_hora));
                vv_str_sql.AppendFormat(" {0}, ", ar_pla_ped);
                vv_str_sql.AppendFormat(" {0}, ", ar_cod_bod);
                vv_str_sql.AppendFormat(" {0}, ", ar_cod_cli);
                vv_str_sql.AppendFormat(" '{0}', ", ar_fec_ped);
                vv_str_sql.AppendFormat(" {0}, ", ar_for_pag);
                vv_str_sql.AppendFormat(" {0} ", ar_lis_pre);

                ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;             
            }
        }

        public DataTable Fe_crea(string _cod_usr, DateTime _cod_tmp, int _pla_ped,
            int _cod_bod, string _cod_per, string _nit_cli, string _raz_soc, string _mon_ped,
            DateTime _fec_ped, int _for_pag, int _ven_ded, int _lis_pre, int _cod_caj, int _cod_lcr,
            decimal _des_cue, string _obs_ped,string _ped_par, int _cod_del, string _ref_ped, decimal _mto_pag, decimal _cam_bio)
        {
            try
            {
                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendFormat(" EXECUTE cmr007_02a_p01 ");
                vv_str_sql.AppendFormat(" '{0}', ", _cod_usr);
                vv_str_sql.AppendFormat(" '{0}', ", _cod_tmp.ToString(fto_fecha_hora));
                vv_str_sql.AppendFormat(" {0}, ", _pla_ped);
                vv_str_sql.AppendFormat("  '{0}' , ", _cod_bod);
                vv_str_sql.AppendFormat("  {0} , ", _cod_per);
                vv_str_sql.AppendFormat("  '{0}' , ", _nit_cli);
                vv_str_sql.AppendFormat("  '{0}' , ", _raz_soc);
                vv_str_sql.AppendFormat(" '{0}' , ", _mon_ped);
                vv_str_sql.AppendFormat(" '{0}' , ", _fec_ped.ToShortDateString());
                vv_str_sql.AppendFormat("  {0} , ", _for_pag);

                vv_str_sql.AppendFormat("  {0} , ", _ven_ded);
                vv_str_sql.AppendFormat("  {0} , ", _lis_pre);

                vv_str_sql.AppendFormat("  {0} , ", _cod_caj);
                vv_str_sql.AppendFormat("  {0} , ", _cod_lcr);
                vv_str_sql.AppendFormat(" '{0}' , ", _des_cue);
                vv_str_sql.AppendFormat(" '{0}' , ", _obs_ped);
                vv_str_sql.AppendFormat(" '{0}' , ", _ped_par);

                vv_str_sql.AppendFormat(" {0} , ", _cod_del);


                vv_str_sql.AppendFormat(" '{0}' , ", _ref_ped);
                vv_str_sql.AppendFormat(" '{0}' , ", _mto_pag);
                vv_str_sql.AppendFormat(" '{0}'  ", _cam_bio);

                vv_str_sql.AppendLine("");
                DataTable tabla = new DataTable();
                tabla = ob_con_ecA.fe_exe_sql(vv_str_sql.ToString());
                return tabla;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int Fi_obt_nvt(string ar_doc_ped, int ar_nro_tal, int ar_ges_ped)
        {
            int nro_ped = 0;

            Tab_ads005 =  o_ads005.Fe_con_num(ar_doc_ped, ar_nro_tal, ar_ges_ped);
          
            if (Tab_ads005.Rows.Count == 0)
                nro_ped = 0;
            else
            {
                if (Tab_ads005.Rows[0].IsNull(0) == true)
                {
                    nro_ped = 0;
                }
                else
                    nro_ped = int.Parse(Tab_ads005.Rows[0]["va_con_Tad"].ToString());
            }

            nro_ped = nro_ped + 1;

            return nro_ped;
        }

      
        public void Fe_edi_ped(string ar_ide_ped, int ar_ges_ped, string ar_ped_par, int ar_cod_del, string ar_obs_ped)
        {
            cadena = " UPDATE cmr007 SET va_ped_par = '" + ar_ped_par + "', va_cod_del = " + ar_cod_del + ", va_obs_ped = '" + ar_obs_ped + "'" + 
                     " WHERE va_ide_ped = '" + ar_ide_ped + "' AND va_ges_ped = " + ar_ges_ped;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_anu_ped(string ar_ide_ped, int ar_ges_ped)
        {
            cadena = " EXECUTE cmr007_04a_p01 '" + ar_ide_ped + "', " + ar_ges_ped;
            ob_con_ecA.fe_exe_sql(cadena);
        }
      

        public void Fe_eli_ped(int ar_ide_gru )
        {
            cadena = " cmr007_06a_p01 '" + ar_ide_gru + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_ped( string ar_ide_ped, int ar_ges_ped)
        {
            //if (ar_ges_ped == 0)
            //    ar_ges_ped = 2020;

            cadena = "cmr007_05a_p01 '"+ ar_ide_ped + "',"+ ar_ges_ped;
            
            return ob_con_ecA.fe_exe_sql(cadena);
        }
        public DataTable Fe_cmr007_05i_p01(string ar_ide_ped, int ar_ges_ped)
        {
            //if (ar_ges_ped == 0)
            //    ar_ges_ped = 2020;

            cadena = "cmr007_05i_p01 '" + ar_ide_ped + "'," + ar_ges_ped;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Consulta aviso
        /// </summary>
        /// <param name="ar_ide_ped">ID pedido</param>
        /// <param name="ar_ges_ped">gestion</param>
        /// <returns></returns>
        public DataTable Fe_con_avi(string ar_ide_ped, int ar_ges_ped)
        {
            if (ar_ges_ped == 0)
                ar_ges_ped = 2020;

            cadena = "cmr007_05b_p01 '" + ar_ide_ped + "'," + ar_ges_ped;

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// Consulta que exista la pedido
        /// </summary>
        /// <param name="ar_ide_ped">ide de pedido</param>
        /// <param name="ar_ges_ped">gestion</param>
        /// <returns> retorna tabla con valores de encabezado de pedido</returns>
        public DataTable Fe_con_exi_ped(string ar_ide_ped, int ar_ges_ped)
        {

            cadena = "SELECT * " +
                "FROM cmr007 " +
                "WHERE va_ide_ped = '" + ar_ide_ped + "' AND va_ges_ped = " + ar_ges_ped;
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(int ar_cod_cli ,string ar_cod_bod, DateTime ar_fec_ini, DateTime ar_fec_fin,string ar_tex_bus, int ar_par_ame ,string ar_est_ado )
        {

            cadena = " cmr007_01a_p01 " + ar_cod_cli +",'" + int.Parse(ar_cod_bod) + "','" + ar_fec_ini.ToString(fto_fecha) + "','" + ar_fec_fin.ToString(fto_fecha) + "','" + ar_tex_bus + "', " + ar_par_ame + ",'" + ar_est_ado + "'";

           
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: LISTADO DE pedido
        /// </summary>
        /// <param name="ar_ide_gru"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_cmr007_R01( int ar_cod_bod, DateTime ar_fec_ini , DateTime ar_fec_fin, string ar_est_ado)
        {   
            cadena = "cmr007_R01p "+ ar_cod_bod  + ",'"+ ar_fec_ini.ToString(fto_fecha) + "','"+ ar_fec_fin.ToString(fto_fecha) + "','"+ ar_est_ado  + "',0 " ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Funcion externa reporte: pedido DE UN DELIVERY CON PORCENTAJE
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_cmr007_R02(int ar_cod_bod, DateTime ar_fec_ini, DateTime ar_fec_fin, int ar_cod_del)
        {
            cadena = "cmr007_R02 " + ar_cod_bod + ",'" + ar_fec_ini.ToString(fto_fecha) + "','" + ar_fec_fin.ToString(fto_fecha) + "'," + ar_cod_del;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Funcion externa reporte: RESUMEN DE pedido POR DELIVERY
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_cmr007_R03(int ar_cod_bod, DateTime ar_fec_ini, DateTime ar_fec_fin, int ar_cod_de1, int va_cod_de2)
        {
            cadena = "cmr007_R03 " + ar_cod_bod + ",'" + ar_fec_ini.ToString(fto_fecha) + "','" + ar_fec_fin.ToString(fto_fecha) + "'," + ar_cod_de1 + ", " + va_cod_de2;

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: LISTADO DE pedido
        /// </summary>
        /// <param name="ar_ide_gru"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fr_cmr007_R01(int ar_cod_bod, DateTime ar_fec_ini, DateTime ar_fec_fin, string ar_est_ado)
        {
            cadena = "cmr007_R01 " + ar_cod_bod + ",'" + ar_fec_ini + "','" + ar_fec_fin + "','" + ar_est_ado + "',0 ";

            return ob_con_ecA.fe_exe_sql(cadena);
        }

    }
}
