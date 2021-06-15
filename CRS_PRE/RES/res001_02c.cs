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

namespace CRS_PRE.CMR
{
    public partial class res001_02c : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public int nro_itm;
        public string not_itm;

        
        DataTable tabla = new DataTable();

        public res001_02c()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            this.Text = "Nota para el item # " + nro_itm;
            tb_not_itm.Text = not_itm;
            //tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            //tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            //tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            //tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            //tb_des_doc.Text = frm_dat.Rows[0]["va_des_doc"].ToString();
            
            //if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
            //    tb_est_ado.Text = "Habilitado";
            //if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
            //    tb_est_ado.Text = "Deshabilitado";
        }
    
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {

            not_itm = tb_not_itm.Text;
            frm_pad.Fe_obt_not(nro_itm,not_itm);
            cl_glo_frm.Cerrar(this);
        }
    }
}
