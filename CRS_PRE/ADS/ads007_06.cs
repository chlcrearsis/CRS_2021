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
using CRS_NEG.ADS;

namespace CRS_PRE.ADS
{
    public partial class ads007_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        c_ads007 o_ads007 = new c_ads007();

        DataTable tabla = new DataTable();

        public ads007_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
            tb_tel_usr.Text = frm_dat.Rows[0]["va_tel_usr"].ToString();
            tb_car_usr.Text = frm_dat.Rows[0]["va_car_usr"].ToString();
            tb_ema_usr.Text = frm_dat.Rows[0]["va_ema_usr"].ToString();
            tb_win_max.Text = frm_dat.Rows[0]["va_win_max"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            return o_ads007.Fe_ver_hds(tb_ide_usr.Text);
        }
             
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res = DialogResult.OK;
            string msg_fun = Fi_val_dat();
            if( msg_fun != "")
                MessageBox.Show(msg_fun, "Edita Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar al usuario?", "Edita Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                msg_res = MessageBox.Show("Esta seguro de Habilitar al usuario?", "Edita Usuario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (msg_res == DialogResult.OK)
            {
                //Edita usuario
                if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                    o_ads007.Fe_exe_hds(tb_ide_usr.Text,"H");
                if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                    o_ads007.Fe_exe_hds(tb_ide_usr.Text, "N");

                MessageBox.Show("Los datos se grabaron correctamente", "Edita Usuario", MessageBoxButtons.OK,MessageBoxIcon.Information);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
