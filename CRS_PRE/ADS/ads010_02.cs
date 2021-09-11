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
    public partial class ads010_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads010 o_ads010 = new ads010();

        DataTable tabla = new DataTable();


        public ads010_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
           
            tb_ide_tip.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_ide_tip.Text.Trim() == "")
            {
                tb_ide_tip.Focus();
                return "Debe proporcionar el Codigo";
            }

            if (cl_glo_bal.IsNumeric(tb_ide_tip.Text) == false)
            {
                tb_ide_tip.Focus();
                return "El codigo no es valido";
            }

            //Verificar 
            tabla = o_ads010.Fe_con_mod(tb_ide_tip.Text);
            if (tabla.Rows.Count > 0)
            {
                tb_ide_tip.Focus();
                return "El Tipo de Imagen que desea crear ya se encuentra registrado";
            }
            if (tb_nom_tip.Text.Trim() == "")
            {
                tb_nom_tip.Focus();
                return "Debe proporcionar el Nombre";
            }

            if (tb_ide_tab.Text.Trim() == "")
            {
                tb_nom_tip.Focus();
                return "Debe proporcionar la Tabla";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
           
            tb_ide_tip.Clear(); 
            tb_nom_tip.Clear();
            tb_ide_tab.Clear();
           
            tb_ide_tip.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo Tipo de Imagen", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar 
                o_ads010.Fe_crea(int.Parse(tb_ide_tip.Text), tb_nom_tip.Text, tb_ide_tab.Text,"H");
                MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Tipo de Imagen", MessageBoxButtons.OK);
                Fi_lim_pia();
            }

        }

        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);          
        }
    }
}
