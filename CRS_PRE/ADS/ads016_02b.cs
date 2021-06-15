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
    public partial class ads016_02b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        c_ads016 o_ads016 = new c_ads016();

        DataTable tabla = new DataTable();


        public ads016_02b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            int va_ult_ges = o_ads016.Fe_ult_ges();
            if (va_ult_ges!= 0)
                va_ult_ges = va_ult_ges + 1;

            tb_ges_tio.Text = va_ult_ges.ToString();

        }

        protected string Fi_val_dat()
        {

            int val = 0;
            int.TryParse(tb_ges_tio.Text.Trim(), out val );

            if (int.Parse(tb_ges_tio.Text) == 0)
            {
                
                return "No existe ninguna gestion creada, debe de crear antes una gestion";
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
            msg_res = MessageBox.Show("Esta seguro de preparar la siguiente gestion ?", "Prepara siguiente gestion", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_ads016.Fe_sig_ges(int.Parse(tb_ges_tio.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Prepara gestion", MessageBoxButtons.OK);
                frm_pad.Fi_bus_car();
            }

        }
    }
}
