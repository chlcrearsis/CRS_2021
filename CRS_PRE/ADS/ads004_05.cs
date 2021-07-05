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
    public partial class ads004_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();

        DataTable tabla = new DataTable();

        public ads004_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();
            cb_tip_tal.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_tal"].ToString());
            tb_for_mat.Text = frm_dat.Rows[0]["va_for_mat"].ToString();
            tb_nro_cop.Text = frm_dat.Rows[0]["va_nro_cop"].ToString();
            cb_for_log.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_for_log"].ToString());

            tb_fir_ma1.Text = frm_dat.Rows[0]["va_fir_ma1"].ToString();
            tb_fir_ma2.Text = frm_dat.Rows[0]["va_fir_ma2"].ToString();
            tb_fir_ma3.Text = frm_dat.Rows[0]["va_fir_ma3"].ToString();
            tb_fir_ma4.Text = frm_dat.Rows[0]["va_fir_ma4"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }
       
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
