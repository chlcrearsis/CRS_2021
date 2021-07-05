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
    public partial class ads016_R02p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();


        public ads016_R02p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

        }

        protected string Fi_val_dat()
        {

           
            return "";
        }
      
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
           
            //Registrar usuario
            tabla = new DataTable();
            tabla = o_ads016.Fe_ads016_R02();
            ads016_R02w frm = new ads016_R02w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }
    }
}
