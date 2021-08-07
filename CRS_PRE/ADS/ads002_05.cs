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

namespace CRS_PRE
{
    public partial class ads002_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();

        DataTable tabla = new DataTable();

        public ads002_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_ide_apl.Text = frm_dat.Rows[0]["va_ide_apl"].ToString();
            tb_nom_apl.Text = frm_dat.Rows[0]["va_nom_apl"].ToString();
           
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
