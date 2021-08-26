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
    public partial class cmr014_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        

        DataTable tabla = new DataTable();


        public cmr014_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ven"].ToString();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_ven"].ToString();
            tb_por_cms.Text = frm_dat.Rows[0]["va_por_cms"].ToString();
            cb_tip_cms.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_cms"].ToString());

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_ven.Focus();
        }



        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
