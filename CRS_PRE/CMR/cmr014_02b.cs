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
    public partial class cmr014_02b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        cmr014 o_cmr014 = new cmr014();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr014_02b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            cb_pro_ced.SelectedIndex = 0;
            tb_cms_cre.Text = "0.00";

            tb_cod_ven.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_cod_ven.Text.Trim() == "")
            {
                tb_cod_ven.Focus();
                return "Debe proporcionar el Codigo";
            }

            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text),1);
            if (tabla.Rows.Count > 0)
            {
                tb_cod_ven.Focus();
                return "El cobrador que desea crear ya se encuentra registrado";
            }
            if (tb_nom_ven.Text.Trim() == "")
            {
                tb_nom_ven.Focus();
                return "Debe proporcionar el Nombre del cobrador";
            }

            // Revisa Porcentaje al crédito
            if (cl_glo_bal.IsDecimal(tb_cms_cre.Text) == false)
            {
                tb_cms_cre.Focus();
                return "El porcentaje de comisión al crédito es incorrecto";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
           
            tb_cod_ven.Clear(); 
            tb_nom_ven.Clear();
            tb_cms_cre.Text = "0";

            tb_cod_ven.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo cobrador", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar 
                o_cmr014.Fe_crea(int.Parse(tb_cod_ven.Text), tb_nom_ven.Text, tb_tel_cel.Text, tb_ema_ail.Text,
                    (cb_pro_ced.SelectedIndex + 1), 2, 0m, 
                    decimal.Parse(tb_cms_cre.Text),2 );
                
                frm_pad.Fe_act_frm(int.Parse(tb_cod_ven.Text));
                Fi_lim_pia();
            }

        }

        private void tb_cod_ven_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }


        private void tb_cms_cre_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotDecimal(e, tb_cms_cre.Text);
        }

        private void tb_cms_cre_Validated(object sender, EventArgs e)
        {
            if (cl_glo_bal.IsDecimal(tb_cms_cre.Text) == false)
            {
                MessageBox.Show("El porcentaje de comision al crédito no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cms_cre.Focus();
            }

            // Formatea para mostrar decimal
            tb_cms_cre.Text = decimal.Round(decimal.Parse(tb_cms_cre.Text), 2).ToString();
            tb_cms_cre.Text = decimal.Parse(tb_cms_cre.Text).ToString("N2");

        }
    }
}
