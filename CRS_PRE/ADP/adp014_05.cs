using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    public partial class adp014_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public adp014_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString().Trim();
            tb_des_tip.Text = frm_dat.Rows[0]["va_des_tip"].ToString().Trim();

            if (frm_dat.Rows[0]["va_ext_doc"].ToString() == "S")
                cb_ext_doc.Checked = true;
            else
                cb_ext_doc.Checked = false;

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Evento Click: Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
