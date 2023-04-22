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
    public partial class inv004_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        inv003 o_inv003 = new inv003();
        inv004 o_inv004 = new inv004();
        inv005 o_inv005 = new inv005();
        inv006 o_inv006 = new inv006();

        ads008 o_ads008 = new ads008();     // Permisos del usuario

        DataTable tabla = new DataTable();
        DataTable tab_ads008 = new DataTable();


        public inv004_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_eqv_cmp.Text = "1";
            tb_eqv_vta.Text = "1";
            tb_nro_dec.Text = "2";

            tb_cod_fam.Focus();
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
            if (tabla.Rows.Count != 0)
            {
                tb_cod_pro.Focus();
                return "El codigo proporcionado para el producto ya se encuentra registrado";
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

      

        private void bt_bus_fam_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_fam();
        }
        private void Tb_cod_fam_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_fam();
            }
        }

        void Fi_abr_bus_fam()
        {
            inv003_01 frm = new inv003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_fam.Text = frm.tb_sel_bus.Text;

                Fi_obt_fam();
              
            }
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
        private void tb_cod_fam_bus_Validated(object sender, EventArgs e)
        {
            Fi_obt_fam();
        }







        private void bt_bus_mar_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_mar();
        }
        private void Tb_cod_mar_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_mar();
            }
        }

        void Fi_abr_bus_mar()
        {
            inv006_01 frm = new inv006_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_mar.Text = frm.tb_sel_bus.Text;
                Fi_obt_mar();
            }
        }      

        /// <summary>
        /// Obtiene ide y nombre Familia para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_mar()
        {
            int val = 0;
            int.TryParse(tb_cod_mar.Text.Trim(), out val);
            if (val == 0)
            {
                lb_nom_mar.Text = "** No existe";
            }
            else
            {
                // Obtiene ide y nombre 
                tabla = o_inv006.Fe_con_mar(int.Parse(tb_cod_mar.Text));
                if (tabla.Rows.Count == 0)
                {
                    lb_nom_mar.Text = "** No existe";
                }
                else
                {
                    tb_cod_mar.Text = tabla.Rows[0]["va_cod_mar"].ToString();
                    lb_nom_mar.Text = tabla.Rows[0]["va_nom_mar"].ToString();
                }
            }

        }
        private void tb_cod_mar_Validated(object sender, EventArgs e)
        {
            Fi_obt_mar();
        }



        int und_med = 0;        // Variable unidad de medida que elije (1= umd; 2=cmp ; 3=vta)

        private void bt_bus_umd_Click(object sender, EventArgs e)
        {
            und_med = 1;
            Fi_abr_bus_umd();
        }
        private void bt_bus_und_cmp_Click(object sender, EventArgs e)
        {
            und_med = 2;
            Fi_abr_bus_umd();
        }
        private void bt_bus_und_vta_Click(object sender, EventArgs e)
        {
            und_med = 3;
            Fi_abr_bus_umd();
        }

        private void Tb_cod_umd_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_umd();
            }
        }

        void Fi_abr_bus_umd()
        {
            inv005_01 frm = new inv005_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                if (und_med == 1)
                {
                    tb_und_med.Text = frm.tb_sel_bus.Text;

                    if(tb_und_cmp.Text.Trim() =="" )
                        tb_und_cmp.Text = frm.tb_sel_bus.Text;
                    if (tb_und_vta.Text.Trim() == "")
                        tb_und_vta.Text = frm.tb_sel_bus.Text;
                }
                if (und_med == 2)
                    tb_und_cmp.Text = frm.tb_sel_bus.Text;
                if (und_med == 3)
                    tb_und_vta.Text = frm.tb_sel_bus.Text;

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

            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo Producto", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {


                //Registrar Producto
                o_inv004.Fe_crea(tb_cod_pro.Text.Trim(), tb_cod_fam.Text, tb_und_med.Text, tb_und_cmp.Text, tb_und_vta.Text, int.Parse(tb_cod_mar.Text), tb_nom_pro.Text.Trim(),
                    tb_des_pro.Text.Trim(), tb_cod_bar.Text.Trim(), tb_fab_ric.Text.Trim(), int.Parse(tb_eqv_cmp.Text), int.Parse(tb_eqv_vta.Text), int.Parse(tb_nro_dec.Text), 0, 0);


                // Verifica que el usuario tenga lista de precios permitidas
                tab_ads008 = o_ads008.Fe_ads008_01(Program.gl_ide_usr, "cmr001");
                if(tab_ads008 == null)
                    MessageBox.Show("El Producto se creo correctamente", "Nuevo Producto", MessageBoxButtons.OK);
                else if(tab_ads008.Rows.Count==0)
                {
                    MessageBox.Show("El Producto se creo correctamente", "Nuevo Producto", MessageBoxButtons.OK);
                }else
                {
                    // Pregunta si desea registrar precio al producto creado
                    msg_res = new DialogResult();
                    msg_res = MessageBox.Show("El Producto se creo correctamente, desea registrar los precios de este producto?", "Nuevo Producto", MessageBoxButtons.YesNo);
                    if (msg_res == DialogResult.Yes)
                    {
                        cmr002_02c frm = new cmr002_02c();
                        frm.tb_cod_pro.Text = tb_cod_pro.Text;
                        cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

                    }
                }

                Fi_lim_pia();
                frm_pad.Fe_act_frm(tb_cod_pro.Text);
            }
        }

        private void tb_und_med_Enter(object sender, EventArgs e)
        {
            und_med = 1;
        }

        private void tb_und_cmp_Enter(object sender, EventArgs e)
        {
            und_med = 2;
        }

        private void tb_und_vta_Enter(object sender, EventArgs e)
        {
            und_med = 3;
        }

        private void tb_cod_pro_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tb_cod_pro.Text.Trim() != "")
                    return;

                if (tb_cod_fam.Text == "000000")
                {
                    MessageBox.Show("Debe de seleccionar una familia para la codificacion automatica", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tb_cod_pro.Text = o_inv004.Fe_con_cod_max(tb_cod_fam.Text);
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
