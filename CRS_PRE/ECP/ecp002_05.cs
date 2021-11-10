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
    public partial class ecp002_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ecp002 o_ecp002 = new ecp002();

        DataTable tabla = new DataTable();


        public ecp002_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            switch (frm_dat.Rows[0]["va_tip_lib"].ToString())
            {
                case "1":
                    tb_tip_lib.Text = "Ctas. x Cobrar";
                    break;
                case "2":
                    tb_tip_lib.Text = "Ctas. x Pagar";
                    break;
                case "3":
                    tb_tip_lib.Text = "Tesoreria";
                    break;
                default:
                    break;
            }

            switch (frm_dat.Rows[0]["va_mon_lib"].ToString())
            {
                case "B":
                    tb_mon_lib.Text = "Bs.";
                    break;
                case "U":
                    tb_mon_lib.Text = "Us.";
                    break;
                default:
                    break;
            }

            switch (frm_dat.Rows[0]["va_est_ado"].ToString())
            {
                case "H":
                    tb_est_ado.Text = "Habilitado";
                    break;
                case "N":
                    tb_est_ado.Text = "Deshabilitado";
                    break;
                default:
                    break;
            }
            tb_cod_lib.Text = frm_dat.Rows[0]["va_cod_lib"].ToString();
            tb_nom_lib.Text = frm_dat.Rows[0]["va_des_lib"].ToString();
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
