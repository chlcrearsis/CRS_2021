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
    public partial class ads001_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public ads001_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_abr_mod.Text = frm_dat.Rows[0]["va_abr_mod"].ToString();

               


            tb_ide_mod.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_ide_mod.Text.Trim() == "")
            {
                tb_ide_mod.Focus();
                return "Debe proporcionar el Codigo";
            }

            //Verificar 
            tabla = o_ads001.Fe_con_mod(tb_ide_mod.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_ide_mod.Focus();
                return "El Modulo no se encuentra registrado";
            }
            if (tb_abr_mod.Text.Trim() == "")
            {
                tb_nom_mod.Focus();
                return "Debe proporcionar la abreviatura";
            }
            if (tb_nom_mod.Text.Trim() == "")
            {
                tb_nom_mod.Focus();
                return "Debe proporcionar el Nombre";
            }

            return "";
        }

        private void Fi_lim_pia()
        {          
            tb_ide_mod.Clear(); 
            tb_nom_mod.Clear();
            tb_abr_mod.Clear();
           
            tb_ide_mod.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Modulo", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar 
                o_ads001.Fe_edi_mod(int.Parse(tb_ide_mod.Text), tb_nom_mod.Text, tb_abr_mod.Text);
                MessageBox.Show("Los datos se grabaron correctamente", "Modulo", MessageBoxButtons.OK);

                frm_pad.Fe_act_frm(int.Parse(tb_ide_mod.Text));

                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
