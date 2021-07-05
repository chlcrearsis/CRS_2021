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

namespace CRS_PRE.INV
{
    public partial class inv001_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        inv001 o_inv001 = new inv001();

        DataTable tabla = new DataTable();


        public inv001_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            cb_est_ado.SelectedIndex = 0;
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            
            //Obtiene datos
            tabla = new DataTable();
            string va_est_ado = "T";

            if (cb_est_ado.Text == "Todos")
                va_est_ado = "T";
            if (cb_est_ado.Text == "Habilitado")
                va_est_ado = "H";
            if (cb_est_ado.Text == "Deshabilitado")
                va_est_ado = "N";

           
            tabla= o_inv001.Fe_inv001_R01( va_est_ado);

            inv001_R01w frm = new inv001_R01w();

            frm.vp_est_ado = cb_est_ado.Text;
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
