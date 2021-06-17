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
    public partial class ads007_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        c_ads007 o_ads007 = new c_ads007();

        DataTable tabla = new DataTable();

        public ads007_03()
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
            if (tb_nom_usr.Text.Trim()=="")
            {
                tb_nom_usr.Focus();
                return "Debe proporcionar el nombre para el usuario";
            }
            
            
            if (cl_glo_bal.IsNumeric(tb_win_max.Text) == false)
            {
                tb_win_max.Focus();
                return "El campo Maximo de ventanas debe ser numerico";
            }

          return  o_ads007.Fe_ver_edi(tb_ide_usr.Text);

        }
             
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Usuario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita usuario
                o_ads007.Fe_exe_edi(tb_ide_usr.Text, tb_nom_usr.Text, tb_tel_usr.Text, tb_car_usr.Text,
                                       tb_ema_usr.Text, int.Parse(tb_win_max.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Edita Usuario", MessageBoxButtons.OK,MessageBoxIcon.Information);
                frm_pad.Fe_act_frm(tb_ide_usr.Text);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
