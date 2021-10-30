using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class ecp001_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ecp001 o_ecp001 = new ecp001();

        DataTable tabla = new DataTable();


        public ecp001_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_plg.Text = frm_dat.Rows[0]["va_cod_plg"].ToString();
            tb_nom_plg.Text = frm_dat.Rows[0]["va_des_plg"].ToString();
            tb_nro_cuo.Text = frm_dat.Rows[0]["va_nro_cuo"].ToString();
            tb_int_dia.Text = frm_dat.Rows[0]["va_int_dia"].ToString();
            tb_dia_ini.Text = frm_dat.Rows[0]["va_dia_ini"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "HABILITADO";
            else
                tb_est_ado.Text = "DESHABILITADO";

            tb_cod_plg.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_cod_plg.Text.Trim() == "")
            {
                tb_cod_plg.Focus();
                return "Debe proporcionar el Codigo";
            }

            //Verificar 
            tabla = o_ecp001.Fe_con_plg(int.Parse(tb_cod_plg.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_cod_plg.Focus();
                return "El plan de pago que desea crear NO se encuentra registrado";
            }
           
            return "";
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
        private void tb_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }
    }
}
