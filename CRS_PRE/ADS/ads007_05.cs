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
using CRS_NEG;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads007_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads007 o_ads007 = new ads007();
        cmr013 o_cmr013 = new cmr013();
        ads006 o_ads006 = new ads006();

        DataTable tabla = new DataTable();
        DataTable tab_cmr013 = new DataTable();
      
        public ads007_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
            tb_tel_usr.Text = frm_dat.Rows[0]["va_tel_usr"].ToString();
            tb_car_usr.Text = frm_dat.Rows[0]["va_car_usr"].ToString();
            tb_dir_ect.Text = frm_dat.Rows[0]["va_dir_ect"].ToString();
            tb_ema_usr.Text = frm_dat.Rows[0]["va_ema_usr"].ToString();
            tb_cod_per.Text = frm_dat.Rows[0]["va_ide_per"].ToString();
            tb_win_max.Text = frm_dat.Rows[0]["va_win_max"].ToString();

            tabla = o_ads006.Fe_con_tus(frm_dat.Rows[0]["va_tip_usr"].ToString());
            tb_tip_usr.Text = tabla.Rows[0]["va_nom_tus"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            // Obtiene persona
            Fi_obt_per();
        }

        private void Fi_obt_per()
        {
            if (tb_cod_per.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar un codigo de proveedor valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
            }
            int val = 0;
            if (int.TryParse(tb_cod_per.Text, out val) == false) ;
            {
                //MessageBox.Show("Debe proporcionar un codigo de proveedor valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
                lb_raz_soc.Text = "No Existe";
            }

            tab_cmr013 = o_cmr013.Fe_con_per(val);
            if (tab_cmr013.Rows.Count == 0)
            {
                lb_raz_soc.Text = "No Existe";
            }
            else
            {
                lb_raz_soc.Text = tab_cmr013.Rows[0]["va_raz_soc"].ToString();
            }
        }



        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
