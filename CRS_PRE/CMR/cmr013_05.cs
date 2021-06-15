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

using CRS_NEG.CMR;

namespace CRS_PRE.CMR
{
    public partial class cmr013_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        c_cmr012 o_cmr012 = new c_cmr012();
        c_cmr013 o_cmr013 = new c_cmr013();

        DataTable tabla = new DataTable();

        public cmr013_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            
            tb_cod_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString();
            lb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();
            tb_nom_com.Text = frm_dat.Rows[0]["va_nom_com"].ToString();
            tb_nit_per.Text = frm_dat.Rows[0]["va_nit_per"].ToString();
            tb_car_net.Text = frm_dat.Rows[0]["va_car_net"].ToString();
            tb_dir_per.Text = frm_dat.Rows[0]["va_dir_per"].ToString();
            tb_tel_per.Text = frm_dat.Rows[0]["va_tel_per"].ToString();
            tb_cel_per.Text = frm_dat.Rows[0]["va_cel_per"].ToString();
            tb_ema_per.Text = frm_dat.Rows[0]["va_ema_per"].ToString();

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
