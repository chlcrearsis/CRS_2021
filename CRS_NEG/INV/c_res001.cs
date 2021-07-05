using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
using CRS_NEG;

namespace CRS_NEG.INV
{
    /// <summary>
    /// Clase: VENTAS RESTAURANT
    /// </summary>
    public class c_res001
    {
        //######################################################################
        //##       Tabla: res001                                              ##
        //##      Nombre: VENTAS RESTAURANT                                   ##
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
        string DateFornat = "dd.MM.yyyy hh:mm:ss";

        ads005 o_ads005 = new ads005();
        DataTable Tab_ads005;


        public c_res001()
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

        public DataTable Fe_crea(string _cod_usr, DateTime _cod_tmp, int _pla_vta, int _tip_vta, string _ide_doc,
    int _nro_tal, int _cod_bod, string _cod_per, string _nit_cli, string _raz_soc, string _mon_vta,
    DateTime _fec_vta, int _for_pag, int _ven_ded, int _lis_pre, int _cod_caj, int _cod_lcr,
     decimal _tip_cam, decimal _des_cue, string _obs_vta,string _vta_par, int _cod_del, string _ref_vta, decimal _mto_pag, decimal _cam_bio, long _nro_aut)
        {
            try
            {
                StringBuilder vv_str_sql = new StringBuilder();
                vv_str_sql.AppendFormat(" EXECUTE res001_02a_p01 ");
                vv_str_sql.AppendFormat(" '{0}', ", _cod_usr);
                vv_str_sql.AppendFormat(" '{0}', ", _cod_tmp.ToString(DateFornat));
                vv_str_sql.AppendFormat(" {0}, ", _pla_vta);
                vv_str_sql.AppendFormat("  {0} , ", _tip_vta);
                vv_str_sql.AppendFormat("  '{0}' , ", _ide_doc);
                vv_str_sql.AppendFormat("  {0} , ", _nro_tal);
                vv_str_sql.AppendFormat("  '{0}' , ", _cod_bod);
                vv_str_sql.AppendFormat("  {0} , ", _cod_per);
                vv_str_sql.AppendFormat("  '{0}' , ", _nit_cli);
                vv_str_sql.AppendFormat("  '{0}' , ", _raz_soc);
                vv_str_sql.AppendFormat(" '{0}' , ", _mon_vta);
                vv_str_sql.AppendFormat(" '{0}' , ", _fec_vta.ToShortDateString());
                vv_str_sql.AppendFormat("  {0} , ", _for_pag);

                vv_str_sql.AppendFormat("  {0} , ", _ven_ded);
                vv_str_sql.AppendFormat("  {0} , ", _lis_pre);

                vv_str_sql.AppendFormat("  {0} , ", _cod_caj);
                vv_str_sql.AppendFormat("  {0} , ", _cod_lcr);
                vv_str_sql.AppendFormat(" '{0}' , ", _tip_cam);
                vv_str_sql.AppendFormat(" '{0}' , ", _des_cue);
                vv_str_sql.AppendFormat(" '{0}' , ", _obs_vta);
                vv_str_sql.AppendFormat(" '{0}' , ", _vta_par);

                vv_str_sql.AppendFormat(" {0} , ", _cod_del);


                vv_str_sql.AppendFormat(" '{0}' , ", _ref_vta);
                vv_str_sql.AppendFormat(" '{0}' , ", _mto_pag);
                vv_str_sql.AppendFormat(" '{0}' , ", _cam_bio);
                vv_str_sql.AppendFormat(" '{0}'  ", _nro_aut);

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


        private int Fi_obt_nvt(string ar_doc_vta, int ar_nro_tal, int ar_ges_vta)
        {
            int nro_vta = 0;

            Tab_ads005 =  o_ads005.Fe_con_num(ar_doc_vta, ar_nro_tal, ar_ges_vta);
          
            if (Tab_ads005.Rows.Count == 0)
                nro_vta = 0;
            else
            {
                if (Tab_ads005.Rows[0].IsNull(0) == true)
                {
                    nro_vta = 0;
                }
                else
                    nro_vta = int.Parse(Tab_ads005.Rows[0]["va_con_Tad"].ToString());
            }

            nro_vta = nro_vta + 1;

            return nro_vta;
        }

      
        public void Fe_edi_vta(string ar_ide_vta, int ar_ges_vta, string ar_vta_par, int ar_cod_del, string ar_obs_vta)
        {
            cadena = " UPDATE res001 SET va_vta_par = '" + ar_vta_par + "', va_cod_del = " + ar_cod_del + ", va_obs_vta = '" + ar_obs_vta + "'" + 
                     " WHERE va_ide_vta = '" + ar_ide_vta + "' AND va_ges_vta = " + ar_ges_vta;
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public void Fe_anu_vta(string ar_ide_vta, int ar_ges_vta)
        {
            cadena = " EXECUTE res001_04a_p01 '" + ar_ide_vta + "', " + ar_ges_vta;
            ob_con_ecA.fe_exe_sql(cadena);
        }
      

        public void Fe_eli_vta(int ar_ide_gru )
        {
            cadena = " res001_06a_p01 '" + ar_ide_gru + "'";
            ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_con_vta( string ar_ide_vta, int ar_ges_vta)
        {
            if (ar_ges_vta == 0)
                ar_ges_vta = 2020;

            cadena = "res001_05a_p01 '"+ ar_ide_vta + "',"+ ar_ges_vta;
            
            return ob_con_ecA.fe_exe_sql(cadena);
        }


         /// <summary>
        /// Consulta aviso
        /// </summary>
        /// <param name="ar_ide_vta">ID venta</param>
        /// <param name="ar_ges_vta">gestion</param>
        /// <returns></returns>
        public DataTable Fe_con_avi(string ar_ide_vta, int ar_ges_vta)
        {
            if (ar_ges_vta == 0)
                ar_ges_vta = 2020;

            cadena = "res001_05b_p01 '" + ar_ide_vta + "'," + ar_ges_vta;

            return ob_con_ecA.fe_exe_sql(cadena);
        }


        /// <summary>
        /// Consulta que exista la venta
        /// </summary>
        /// <param name="ar_ide_vta">ide de venta</param>
        /// <param name="ar_ges_vta">gestion</param>
        /// <returns> retorna tabla con valores de encabezado de venta</returns>
        public DataTable Fe_con_exi_vta(string ar_ide_vta, int ar_ges_vta)
        {

            cadena = "SELECT * " +
                "FROM res001 " +
                "WHERE va_ide_vta = '" + ar_ide_vta + "' AND va_ges_vta = " + ar_ges_vta;
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        public DataTable Fe_bus_car(int ar_cod_cli ,string ar_cod_bod, DateTime ar_fec_ini, DateTime ar_fec_fin,string ar_tex_bus, int ar_par_ame ,string ar_est_ado )
        {

            //res001_01a_p01  0,0,'01/01/2020', '10/08/2020','venta','T','V'

            cadena = " res001_01a_p01 " + ar_cod_cli +",'" + int.Parse(ar_cod_bod) + "','" + ar_fec_ini + "','" + ar_fec_fin + "','" + ar_tex_bus + "', " + ar_par_ame + ",'" + ar_est_ado + "', 'V'";

           
            return ob_con_ecA.fe_exe_sql(cadena);
        }


        //** FUNCIONES DE REPORTES

        /// <summary>
        /// Funcion externa reporte: LISTADO DE VENTAS
        /// </summary>
        /// <param name="ar_ide_gru"> Ide Modulo</param>
        /// <param name="ar_est_ado"> Estado</param>
        /// <returns></returns>
        public DataTable Fe_res001_R01( int ar_cod_bod, DateTime ar_fec_ini , DateTime ar_fec_fin, string ar_est_ado)
        {   
            cadena = "res001_R01p "+ ar_cod_bod  + ",'"+ ar_fec_ini  + "','"+ ar_fec_fin + "','"+ ar_est_ado  + "',0 " ;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Funcion externa reporte: VENTAS DE UN DELIVERY CON PORCENTAJE
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_res001_R02(int ar_cod_bod, DateTime ar_fec_ini, DateTime ar_fec_fin, int ar_cod_del)
        {
            cadena = "res001_R02 " + ar_cod_bod + ",'" + ar_fec_ini + "','" + ar_fec_fin + "'," + ar_cod_del;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

        /// <summary>
        /// Funcion externa reporte: RESUMEN DE VENTAS POR DELIVERY
        /// </summary>
        /// <returns></returns>
        public DataTable Fe_res001_R03(int ar_cod_bod, DateTime ar_fec_ini, DateTime ar_fec_fin, int ar_cod_de1, int va_cod_de2)
        {
            cadena = "res001_R03 " + ar_cod_bod + ",'" + ar_fec_ini + "','" + ar_fec_fin + "'," + ar_cod_de1 + ", " + va_cod_de2;

            return ob_con_ecA.fe_exe_sql(cadena);
        }

    }
}
