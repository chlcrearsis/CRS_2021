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
    public partial class ecp002_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ecp002 o_ecp002 = new ecp002();

        DataTable tabla = new DataTable();


        public ecp002_03()
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
                    tb_tip_lib.Text = "Caja General";
                    break;
                case "4":
                    tb_tip_lib.Text = "Caja Recaudación";
                    break;
                case "5":
                    tb_tip_lib.Text = "Banco";
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

            tb_nom_lib.Focus();
        }


        protected string Fi_val_dat()
        {
            if (tb_cod_lib.Text.Trim() == "")
            {
                tb_cod_lib.Focus();
                return "Debe proporcionar el codigo de la libreta";
            }

            //Verificar 
            tabla = o_ecp002.Fe_con_lib(int.Parse(tb_cod_lib.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_cod_lib.Focus();
                return "La libreta que desea Editar No se encuentra registrada";
            }
            if (tb_nom_lib.Text.Trim() == "")
            {
                tb_nom_lib.Focus();
                return "Debe proporcionar la descripción de la libreta";
            }


            if (cl_glo_bal.IsNumeric(tb_cod_lib.Text) == false)
            {
                tb_cod_lib.Focus();
                return "El numero de la libreta es incorrecto";
            }

            
            return "";
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de Editar la informacion?", "Edita libreta", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Edita
                o_ecp002.Fe_edi_lib(int.Parse(tb_cod_lib.Text), tb_nom_lib.Text);
                frm_pad.Fe_act_frm(int.Parse(tb_cod_lib.Text));
            }

        }
      
    }
}
