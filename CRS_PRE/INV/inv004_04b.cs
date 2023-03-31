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

namespace CRS_PRE.INV
{
    public partial class inv004_04b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        inv003 o_inv003 = new inv003();
        inv004 o_inv004 = new inv004();
        inv005 o_inv005 = new inv005();
        inv006 o_inv006 = new inv006();

        DataTable tabla = new DataTable();


        public inv004_04b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_fam.Text = frm_dat.Rows[0]["va_cod_fam"].ToString();
            tb_nom_fam.Text = frm_dat.Rows[0]["va_nom_fam"].ToString();
            tb_cod_pro.Text = frm_dat.Rows[0]["va_cod_pro"].ToString();
            tb_nom_pro.Text = frm_dat.Rows[0]["va_nom_pro"].ToString();
            tb_des_pro.Text = frm_dat.Rows[0]["va_des_pro"].ToString();
            tb_cod_mar.Text = frm_dat.Rows[0]["va_cod_mar"].ToString();
            lb_nom_mar.Text = frm_dat.Rows[0]["va_nom_mar"].ToString();
            tb_und_med.Text = frm_dat.Rows[0]["va_cod_umd"].ToString();
            tb_und_cmp.Text = frm_dat.Rows[0]["va_und_cmp"].ToString();
            tb_und_vta.Text = frm_dat.Rows[0]["va_und_vta"].ToString();

            tb_eqv_cmp.Text = double.Parse(frm_dat.Rows[0]["va_eqv_cmp"].ToString()).ToString();
            tb_eqv_vta.Text = double.Parse(frm_dat.Rows[0]["va_eqv_vta"].ToString()).ToString();

            tb_cod_bar.Text = frm_dat.Rows[0]["va_cod_bar"].ToString();
            tb_fab_ric.Text = frm_dat.Rows[0]["va_fab_ric"].ToString();

            tb_nro_dec.Text = frm_dat.Rows[0]["va_nro_dec"].ToString();

            if(frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
            {
                tb_est_ado.Text = "Habilitado";
            }
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_est_ado.Text = "Deshabilitado";
            }

        }


        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }


        protected string Fi_val_dat()
        {
           // Valida Familia
           if (tb_cod_fam.Text == "000000" || tb_cod_fam.Text=="")
            {
                tb_cod_fam.Focus();
                return "Debe proporcionar la Familia";
            }
            tabla = new DataTable();
            tabla = o_inv003.Fe_con_fam(tb_cod_fam.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_fam.Focus();
                return "La familia NO se encuetra registrada";
            }

            if(tb_est_ado.Text == "Deshabilitado")
            {
                if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    tb_cod_fam.Focus();
                    return "No puede Habilitar el producto, la familia a la que pertenece se encuentra deshabilitada";
                }
            }
          


            return "";
        }

        private void Fi_lim_pia()
        {
            tb_cod_pro.Clear();
            tb_nom_pro.Clear();
            tb_des_pro.Clear();
            tb_cod_bar.Clear();
            tb_fab_ric.Clear();
        }

        /// <summary>
        /// Obtiene ide y nombre Familia para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_fam()
        {
            // Obtiene ide y nombre 
            tabla = o_inv003.Fe_con_fam(tb_cod_fam.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_fam.Text = "";
            }
            else
            {
                tb_cod_fam.Text = tabla.Rows[0]["va_cod_fam"].ToString();
                tb_nom_fam.Text = tabla.Rows[0]["va_nom_fam"].ToString();
            }
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
            if (tb_est_ado.Text == "Habilitado")
            {
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar la informacion?", "Producto", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {

                    o_inv004.Fe_hab_des(tb_cod_pro.Text.Trim(), "N");

                    cl_glo_frm.Cerrar(this);
                    frm_pad.Fe_act_frm(tb_cod_pro.Text);
                }
            }

            if (tb_est_ado.Text == "Deshabilitado")
            {
                msg_res = MessageBox.Show("Esta seguro de Habilitar la informacion?", "Producto", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {

                    o_inv004.Fe_hab_des(tb_cod_pro.Text.Trim(), "H");

                    cl_glo_frm.Cerrar(this);
                    frm_pad.Fe_act_frm(tb_cod_pro.Text);
                }
            }

        }


    }
}
