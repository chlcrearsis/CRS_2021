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
    public partial class res001_02e : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public int nro_itm;
        public string not_itm;


        DataTable tabla = new DataTable();

        adp002 o_adp002 = new adp002();


        public res001_02e()
        {
            InitializeComponent();
        }


        private void frm_Load(object sender, EventArgs e)
        {
            // Obtiene Monto Total a cancelar
            tb_raz_soc.Text = frm_pad.tb_raz_soc.Text;
            tb_nit_per.Text = frm_pad.nit_per.ToString();
            tb_pre_tot.Text = frm_pad.pre_tot.ToString();
            tb_obs_vta.Text = frm_pad.obs_ope;
            tb_mto_can.Text = frm_pad.mto_can.ToString();
            tb_cam_bio.Text = frm_pad.cam_bio.ToString();


            // SI LA VENTA ES AL CREDITO NO PERMITE CAMBIAR RAZON SOCIAL DEL CLIENTE
            if (frm_pad.va_for_pag == 2) //Si es al credito
            {
                tb_nit_per.ReadOnly = true;
                tb_raz_soc.ReadOnly = true;

                tb_mto_can.Text = tb_pre_tot.Text;
                tb_mto_can.ReadOnly = true;

                tb_obs_vta.Focus();
                tb_obs_vta.SelectAll();
                tb_obs_vta.HideSelection = true;
            }
            else
            {
                tb_raz_soc.ReadOnly = false;
                tb_mto_can.ReadOnly = false;

                tb_raz_soc.Focus();
                tb_raz_soc.SelectAll();
                tb_raz_soc.HideSelection = true;
            }

        }

        /// <summary>
        /// Calcula Cambio
        /// </summary>
        private void Fi_cal_cam()
        {
            decimal pre_tot = decimal.Parse(tb_pre_tot.Text);
            decimal mto_can = decimal.Parse(tb_mto_can.Text);
            decimal cam_bio = decimal.Parse(tb_cam_bio.Text);

            if (mto_can < pre_tot)
            {
                cam_bio = 0.00m;
                tb_cam_bio.Text = cam_bio.ToString();
                return;
            }
            cam_bio = mto_can - pre_tot;
            tb_cam_bio.Text = cam_bio.ToString();

        }


        protected string Fi_val_dat()
        {
            // VERIFICA PLANTILLA DE VENTA *****************
            if (tb_raz_soc.Text.Trim() == "")
            {
                tb_raz_soc.Focus();
                return "Debe de proporcionar la razon social del cliente";
            }

            if (frm_pad.va_for_pag == 1 ) //si es al contado, verifica monto recibido
            {
                if(cl_glo_bal.IsDecimal(tb_mto_can.Text)== false)
                {
                    tb_mto_can.Focus();
                    return "El monto cancelado no es valido";
                }

                if(decimal.Parse(tb_mto_can.Text) < decimal.Parse(tb_pre_tot.Text))
                {
                    tb_mto_can.Focus();
                    return "El monto cancelado es menor al precio total de la venta";
                }

            }

            return "";
        }

       

        private void tb_mto_can_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotDecimal(e, tb_mto_can.Text);
        }
        private void tb_mto_can_Validated(object sender, EventArgs e)
        {
            tb_mto_can.Text = decimal.Round(decimal.Parse(tb_mto_can.Text), 2).ToString();
            tb_mto_can.Text = decimal.Parse(tb_mto_can.Text).ToString("N2");

            tb_mto_can.SelectAll();
            Fi_cal_cam();
        }



        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
            this.DialogResult = DialogResult.Cancel;
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_res = Fi_val_dat();
            if (msg_res != "")
            {
                MessageBox.Show(msg_res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Esta seguro de grabar la Nota de Venta ?", "Nota de Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.DialogResult = DialogResult.OK;

        }
    }
}
