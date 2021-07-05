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
    public partial class inv004_05 : Form
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


        public inv004_05()
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

        }


        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

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
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_fam.Focus();
                return "La familia se encuetra Deshabilitada";
            }
            if (tabla.Rows[0]["va_tip_fam"].ToString() == "M")
            {
                tb_cod_fam.Focus();
                return "La familia no debe ser de tipo Matriz";
            }


            // Verifica codigo producto
            if (tb_cod_pro.Text.Trim() =="")
            {
                tb_cod_pro.Focus();
                return "Debe proporcionar el codigo de producto";
            }

            tabla = new DataTable();
            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_pro.Focus();
                return "El producto proporcionado NO se encuentra registrado";
            }


            // Verifica Nombre producto
            if (tb_nom_pro.Text.Trim() == "")
            {
                tb_nom_pro.Focus();
                return "Debe proporcionar el nombre del producto";
            }

            // Verifica marca
            if (tb_cod_mar.Text.Trim() == "")
            {
                tb_cod_mar.Focus();
                return "Debe proporcionar la marca del producto";
            }

            tabla = new DataTable();
            tabla = o_inv006.Fe_con_mar(int.Parse(tb_cod_mar.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_cod_mar.Focus();
                return "La marca no se encuentra registrada";
            }

            // Verifica Unidad de Medida
            if (tb_und_med.Text.Trim() == "")
            {
                tb_und_med.Focus();
                return "Debe proporcionar la Unidad de medida del producto";
            }

            tabla = new DataTable();
            tabla = o_inv005.Fe_con_umd(tb_und_med.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_und_med.Focus();
                return "La unidad de medida no se encuentra registrada";
            }

            // Verifica Unidad de Compra
            if (tb_und_cmp.Text.Trim() == "")
            {
                tb_und_cmp.Focus();
                return "Debe proporcionar la Unidad de compra del producto";
            }

            tabla = new DataTable();
            tabla = o_inv005.Fe_con_umd(tb_und_cmp.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_und_cmp.Focus();
                return "La unidad de compra no se encuentra registrada";
            }

            if (tb_eqv_cmp.Text.Trim() =="" )
            {
                tb_eqv_cmp.Focus();
                return "Debe proporcionar la equivalencia con la unidad de compra";
            }
            if (int.Parse(tb_eqv_cmp.Text) == 0 )
            {
                tb_und_cmp.Focus();
                return "La equivalencia de la unidad de compra debe ser mayor a 0 ";
            }

            // Verifica Unidad de Venta
            if (tb_und_vta.Text.Trim() == "")
            {
                tb_und_vta.Focus();
                return "Debe proporcionar la Unidad de venta del producto";
            }

            tabla = new DataTable();
            tabla = o_inv005.Fe_con_umd(tb_und_vta.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_und_vta.Focus();
                return "La unidad de venta no se encuentra registrada";
            }

            if (tb_eqv_vta.Text.Trim() == "")
            {
                tb_eqv_vta.Focus();
                return "Debe proporcionar la equivalencia con la unidad de venta";
            }
            if (int.Parse(tb_eqv_vta.Text) == 0)
            {
                tb_eqv_vta.Focus();
                return "La equivalencia de la unidad de venta debe ser mayor a 0";
            }

            //** Verifica Nro de decimales 
            if (tb_nro_dec.Text.Trim() == "")
            {
                tb_nro_dec.Focus();
                return "Debe proporcionar el numero de decimales con el que trabajara el producto";
            }
            if (int.Parse(tb_nro_dec.Text) > 3)
            {
                tb_nro_dec.Focus();
                return "El numero de decimales debe estar entre 0 y 3";
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

     
    }
}
