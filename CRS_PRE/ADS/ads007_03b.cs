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

namespace CRS_PRE.ADS
{
    public partial class ads007_03b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads007 o_ads007 = new ads007();

        DataTable tabla = new DataTable();

        public ads007_03b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
           
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            if (tb_usr_psw.Text != tb_usr_psw2.Text )
            {
                tb_usr_psw.Focus();
                return "Las contraseñas no coinciden";
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
            msg_res = MessageBox.Show("Esta seguro de Cambiar la contraseña?", "Edita Usuario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                o_ads007.Fe_edi_psw(tb_ide_usr.Text,tb_usr_psw.Text);
                MessageBox.Show("Se cambio la contraseña para el usuario satisfactoriamente", "Edita Usuario", MessageBoxButtons.OK,MessageBoxIcon.Information);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
