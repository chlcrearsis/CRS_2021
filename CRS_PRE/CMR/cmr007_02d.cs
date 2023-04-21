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
    public partial class cmr007_02d : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        decimal des_cue = 0m;
        decimal tot_bru = 0m;
        decimal tot_net = 0m;

        DataTable tabla = new DataTable();

        public cmr007_02d()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            this.Text = "Completa pedido ";
            tb_cod_per.Text = frm_pad.tb_cod_per.Text;
            lb_raz_soc.Text = frm_pad.tab_cmr013.Rows[0]["va_raz_soc"].ToString() ;
            tb_nit_vta.Text = frm_pad.tab_cmr013.Rows[0]["va_nit_per"].ToString();
            tb_raz_soc.Text = lb_raz_soc.Text;

            tb_for_pag.Text = frm_pad.cb_for_pag.Text;
            lb_mon_vta.Text = frm_pad.cb_mon_vta.Text;

            tb_tot_bru.Text = frm_pad.tb_tot_bru.Text;
            tot_bru = decimal.Parse(tb_tot_bru.Text);
            tb_des_cue.Text = "0";
            des_cue = 0m;
            tb_tot_net.Text = frm_pad.tb_tot_bru.Text;
            tot_net = tot_bru;
            

            tb_nit_vta.Focus();

        }
    
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }


        private int Fi_ver_ifi()
        {
            int res_ult = 1;
            // Pregunta si el monto pagado no sea menor que el monto a pagar
            //if(decimal.Parse(tb_tot_net.Text) > decimal.Parse(tb_mto_pag.Text))
            //{
            //    MessageBox.Show("El Mto. a pagar debe ser igual o mayor al Total Neto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //    tb_mto_pag.Focus();
            //    return 0;
            //}


            return res_ult;
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (Fi_ver_ifi() == 0)
                return;

            DialogResult  res_ult = MessageBox.Show("Esta seguro de grabar la pedido?", "Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res_ult == DialogResult.Cancel)
                return;

            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        private void tb_des_cue_Validated(object sender, EventArgs e)
        {
            // Verifica que el dato proporcionado sea numerico
           
            try
            {
                des_cue = decimal.Parse(tb_des_cue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe proporcionar un descuento valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_des_cue.Focus();
            }

            //Formatea a 2 decimales el descuento
            des_cue = decimal.Round(des_cue, 2);
            tb_des_cue.Text = des_cue.ToString("N2");

            //Calcula descuento
            tot_bru = decimal.Parse(tb_tot_bru.Text);
            tot_net = tot_bru - des_cue;

            tb_tot_net.Text = tot_net.ToString("N2");

        }

    }
}
