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
    public partial class ads000_10 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();


        public ads000_10()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_bus_txt.Focus();
        }

      
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            frm_pad.Fe_bus_txt(tb_bus_txt.Text);
            tb_bus_txt.Focus();
        }
    }
}
