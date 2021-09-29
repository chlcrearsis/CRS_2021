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
    public partial class cmr016_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        
        //Instancias
        cmr016 o_cmr016 = new cmr016();

        DataTable tabla = new DataTable();


        public cmr016_05()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_act.Text = frm_dat.Rows[0]["va_cod_act"].ToString();
            tb_nom_act.Text = frm_dat.Rows[0]["va_nom_act"].ToString();
        }

     
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
