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
    public partial class ads016_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();

        public ads016_05()
        {
            InitializeComponent();
        }
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ges_tio.Text = frm_dat.Rows[0][0].ToString();
            tb_ges_per.Text = frm_dat.Rows[0][1].ToString();
            tb_nom_per.Text = frm_dat.Rows[0][2].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0][3].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0][4].ToString();

            tb_nom_per.Focus();
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
