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
    public partial class cmr015_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr015 = new cmr014();
        

        DataTable tabla = new DataTable();


        public cmr015_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_del.Text = frm_dat.Rows[0]["va_cod_del"].ToString();
            tb_nom_del.Text = frm_dat.Rows[0]["va_nom_del"].ToString();
            tb_por_del.Text = frm_dat.Rows[0]["va_por_del"].ToString();
            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_del.Focus();
        }



        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
