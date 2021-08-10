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
    public partial class ads016_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();


        public ads016_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            cb_ges_per.SelectedIndex = 0;
            tb_ges_tio.Focus();
        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }

        protected string Fi_val_dat()
        {

            int val = 0;
            int.TryParse(tb_ges_tio.Text.Trim(), out val );

            if (val == 0)
            {
                tb_ges_tio.Focus();
                return "Debe proporcionar una gestion Valida";
            }
            if (val <1000)
            {
                tb_ges_tio.Focus();
                return "Debe proporcionar una gestion Valida";
            }

            //Verificar 
            tabla = o_ads016.Fe_obt_ges();
            if(tabla.Rows.Count >0)
            {
                tb_ges_tio.Focus();
                return "No puede usar esta opcion por que ya hay gestiones creadas, debe usar 'Prepara siguiente gestion'";
            }

            return "";
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
            msg_res = MessageBox.Show("Esta seguro crear la gestion?", "Error", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar periodo
                o_ads016.Fe_crea(int.Parse(tb_ges_tio.Text),cb_ges_per.SelectedIndex +1);
                MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Usuario", MessageBoxButtons.OK);
                frm_pad.fi_bus_car(0);
            }

        }
    }
}
