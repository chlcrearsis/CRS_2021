using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE.INV;

namespace CRS_PRE
{
    public partial class cmr002_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr001 o_cmr001 = new cmr001();
        cmr002 o_cmr002 = new cmr002();
        inv004 o_inv004 = new inv004();

        DataTable tabla = new DataTable();
        string pro_aux = "";

        public cmr002_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_lis.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            lb_nom_lis.Text = frm_dat.Rows[0]["va_nom_lis"].ToString();
            //tb_cod_pro.Text = frm_dat.Rows[0]["va_cod_pro"].ToString();
            //lb_nom_pro.Text = frm_dat.Rows[0]["va_nom_pro"].ToString();
            //tb_pre_cio.Text = frm_dat.Rows[0]["va_pre_cio"].ToString();
            //tb_pmx_des.Text = frm_dat.Rows[0]["va_pmx_des"].ToString();
            //tb_pmx_inc.Text = frm_dat.Rows[0]["va_pmx_inc"].ToString();
            tb_pre_cio.Text = "0";
            tb_pmx_des.Text = "0";
            tb_pmx_inc.Text = "0";

            tb_pre_cio.Focus();
        }
   

        protected string Fi_val_dat()
        {

            //Verificar Lista de precio
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio NO se encuentra registrada";
            }

            if (tabla.Rows[0]["va_Est_ado"].ToString() == "N")
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio se encuentra Deshabilitada";
            }

            //Verifica Producto
            if (tb_cod_pro.Text == "")
            {
                tb_cod_pro.Focus();
                return "Debe proporcionar el producto";
            }

            tabla = new DataTable();
            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_pro.Focus();
                return "El producto no se encuentra registrado";
            }
     
            return "";
        }


        private void Bt_bus_pro_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_pro();
        }
        private void Tb_cod_pro_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_pro();
            }

        }

        void Fi_abr_bus_pro()
        {
            inv004_01 frm = new inv004_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_pro.Text = frm.tb_sel_ecc.Text;
                Fi_obt_pro();
            }


        }

        private void Tb_cod_pro_Validated(object sender, EventArgs e)
        {
            Fi_obt_pro();
        }

        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_pro()
        {
            if (pro_aux.ToUpper() == tb_cod_pro.Text.ToUpper())
                return;

            // Obtiene ide y nombre documento
            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_pro.Text = "";
                tb_pre_cio.Text = "0";
                tb_pmx_des.Text = "0";
                tb_pmx_inc.Text = "0";
            }
            else
            {
                tb_cod_pro.Text = tabla.Rows[0]["va_cod_pro"].ToString();
                lb_nom_pro.Text = tabla.Rows[0]["va_nom_pro"].ToString();

                // Obtiene precio
                tabla = new DataTable();
                tabla = o_cmr002.Fe_con_pre(int.Parse(tb_nro_lis.Text), tb_cod_pro.Text);
                if (tabla.Rows.Count != 0)
                {
                    tb_pre_cio.Text = tabla.Rows[0]["va_pre_cio"].ToString();
                    tb_pmx_des.Text = tabla.Rows[0]["va_pmx_des"].ToString();
                    tb_pmx_inc.Text = tabla.Rows[0]["va_pmx_inc"].ToString();
                }
                else
                {
                    tb_pre_cio.Text = "0";
                    tb_pmx_des.Text = "0";
                    tb_pmx_inc.Text = "0";
                    MessageBox.Show("El producto no tiene precio registrado en la lista de precio", "Detalle de Precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void tb_cod_pro_Enter(object sender, EventArgs e)
        {
            pro_aux = tb_cod_pro.Text ;
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
            msg_res = MessageBox.Show("Esta seguro de eliminar la informacion?", "Elimina Documento", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_cmr002.Fe_eli_lis(int.Parse(tb_nro_lis.Text), tb_cod_pro.Text);

               // MessageBox.Show("Los datos se grabaron correctamente", "Edita Documento", MessageBoxButtons.OK);
                cl_glo_frm.Cerrar(this);
            }

        }

    }
}
