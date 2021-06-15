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
using CRS_NEG.INV;

namespace CRS_PRE.INV
{
    public partial class inv002_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_inv002 o_inv002 = new c_inv002();
        c_inv001 o_inv001 = new c_inv001();

        DataTable tabla = new DataTable();
        int ide_gru = 0;

        public inv002_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            ide_gru =int.Parse(frm_dat.Rows[0]["va_ide_gru"].ToString());
            tb_cod_bod.Text = frm_dat.Rows[0]["va_cod_bod"].ToString();
            tb_nom_bod.Text = frm_dat.Rows[0]["va_nom_bod"].ToString();
            tb_des_bod.Text = frm_dat.Rows[0]["va_des_bod"].ToString();
            tb_dir_bod.Text = frm_dat.Rows[0]["va_dir_bod"].ToString();
            
            if( frm_dat.Rows[0]["va_mon_inv"].ToString() == "B")
                cb_mon_inv.SelectedIndex = 0;
            else
                cb_mon_inv.SelectedIndex = 1;

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }


        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }


        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
