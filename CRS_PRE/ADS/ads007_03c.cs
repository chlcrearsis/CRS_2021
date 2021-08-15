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
    public partial class ads007_03c : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads007 o_ads007 = new ads007();

        DataTable tabla = new DataTable();

        public ads007_03c()
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
            msg_res = MessageBox.Show("Esta seguro de inicializar la contraseña?", "Usuario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                o_ads007.Fe_ini_psw(tb_ide_usr.Text);
                MessageBox.Show("Se inicializo la contraseña para el usuario satisfactoriamente", "Usuario", MessageBoxButtons.OK,MessageBoxIcon.Information);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
