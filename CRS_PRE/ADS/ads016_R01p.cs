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
    public partial class ads016_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();


        public ads016_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            int va_ult_ges = o_ads016.Fe_ult_ges();
            tb_ges_tio.Text = va_ult_ges.ToString();

        }

        protected string Fi_val_dat()
        {

            int val = 0;
            int.TryParse(tb_ges_tio.Text.Trim(), out val );

            if (int.Parse(tb_ges_tio.Text) == 0)
            {
                return "Debe proporcionar una gestion valida";
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

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            //Registrar usuario
            tabla = new DataTable();
            tabla = o_ads016.Fe_ads016_R01(int.Parse(tb_ges_tio.Text));
            ads016_R01w frm = new ads016_R01w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }
    }
}
