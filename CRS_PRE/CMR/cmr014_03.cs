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
    public partial class cmr014_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr014_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ide"].ToString();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_bre"].ToString();
            tb_tel_cel.Text = frm_dat.Rows[0]["va_tel_cel"].ToString();
            tb_ema_ail.Text = frm_dat.Rows[0]["va_ema_ail"].ToString();

            tb_cms_con.Text = frm_dat.Rows[0]["va_cms_con"].ToString();
            tb_cms_cre.Text = frm_dat.Rows[0]["va_cms_cre"].ToString();

            cb_tip_cms.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_cms"].ToString()) - 1;
            cb_pro_ced.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_pro_ced"].ToString()) - 1;

            tb_tel_cel.Focus(); frm_dat.Rows[0]["va_tel_cel"].ToString();
            tb_ema_ail.Focus(); frm_dat.Rows[0]["va_ema_ail"].ToString();
        }


      

        protected string Fi_val_dat()
        {

            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text), 1);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_ven.Focus();
                return "El Vendedor que desea editar NO se encuentra registrado";
            }
            if (tb_nom_ven.Text.Trim() == "")
            {
                tb_nom_ven.Focus();
                return "Debe proporcionar el Nombre del vendedor";
            }

            // Revisa Porcentaje al contado
            if (cl_glo_bal.IsDecimal(tb_cms_con.Text) == false)
            {
                tb_cms_con.Focus();
                return "El porcentaje de comisión al contado es incorrecto";
            }
            // Revisa Porcentaje al crédito
            if (cl_glo_bal.IsDecimal(tb_cms_cre.Text) == false)
            {
                tb_cms_cre.Focus();
                return "El porcentaje de comisión al crédito es incorrecto";
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Vendedor", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_cmr014.Fe_edi_ven(int.Parse(tb_cod_ven.Text), tb_nom_ven.Text,decimal.Parse(tb_cms_con.Text), 
                    decimal.Parse(tb_cms_cre.Text),(cb_tip_cms.SelectedIndex +1), (cb_pro_ced.SelectedIndex +1), 1);

                frm_pad.Fe_act_frm(int.Parse(tb_cod_ven.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Edita Vendedor", MessageBoxButtons.OK);
                cl_glo_frm.Cerrar(this);
            }

        }

        private void tb_cod_ven_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_cms_con_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotDecimal(e, tb_cms_con.Text);
        }

        private void tb_cms_cre_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotDecimal(e, tb_cms_cre.Text);
        }

        private void tb_cms_con_Validated(object sender, EventArgs e)
        {
            if (cl_glo_bal.IsDecimal(tb_cms_con.Text) == false)
            {
                MessageBox.Show("El porcentaje de comision al contado no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cms_con.Focus();
            }

            // Formatea para mostrar decimal
            tb_cms_con.Text = decimal.Round(decimal.Parse(tb_cms_con.Text), 2).ToString();
            tb_cms_con.Text = decimal.Parse(tb_cms_con.Text).ToString("N2");

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
