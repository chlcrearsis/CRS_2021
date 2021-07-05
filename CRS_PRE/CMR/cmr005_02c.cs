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

namespace CRS_PRE.CMR
{
    public partial class cmr005_02c : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;


        public cmr005_02c()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            this.Text = "Descipción de producto/servicio";
            tb_cod_pro.Text = frm_dat.Rows[0]["va_cod_pro"].ToString();
            tb_nom_pro.Text = frm_dat.Rows[0]["va_nom_pro"].ToString();
            tb_des_cri.Text = frm_dat.Rows[0]["va_des_cri"].ToString();
           
            tb_des_cri.Focus();
            tb_des_cri.SelectAll();
        }
    
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }


        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

    }
}
