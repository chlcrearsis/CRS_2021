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
    public partial class ads010_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        
        //Instancias
        ads010 o_ads010 = new ads010();

        DataTable tabla = new DataTable();


        public ads010_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString();
            tb_ide_tab.Text = frm_dat.Rows[0]["va_ide_tab"].ToString();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";


        }

     
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
