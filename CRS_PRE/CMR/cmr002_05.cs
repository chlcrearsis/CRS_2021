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
using CRS_NEG.CMR;
using CRS_NEG.INV;
using CRS_PRE.INV;
namespace CRS_PRE.CMR
{
    public partial class cmr002_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_cmr001 o_cmr001 = new c_cmr001();
        c_cmr002 o_cmr002 = new c_cmr002();
        c_inv004 o_inv004 = new c_inv004();

        DataTable tabla = new DataTable();
        string pro_aux = "";
        int nro_dec = 0;

        public cmr002_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_lis.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            lb_nom_lis.Text = frm_dat.Rows[0]["va_nom_lis"].ToString();
            nro_dec = int.Parse(frm_dat.Rows[0]["va_nro_dec"].ToString());

            tb_pre_cio.Text = "0";
            tb_pmx_des.Text = "0";
            tb_pmx_inc.Text = "0";

            Fi_for_dec();

            tb_pre_cio.Focus();
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

            Fi_for_dec();

        }

        void Fi_for_dec()
        {
            //Formatea decimales
            tb_pre_cio.Text = decimal.Round(decimal.Parse(tb_pre_cio.Text), nro_dec).ToString();
            switch (nro_dec)
            {
                case 0:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N0");
                    break;

                case 1:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N1");
                    break;
                case 2:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N2");
                    break;
                case 3:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N3");
                    break;
                case 4:
                    tb_pre_cio.Text = decimal.Parse(tb_pre_cio.Text).ToString("N4");
                    break;
            }

            tb_pmx_des.Text = decimal.Round(decimal.Parse(tb_pmx_des.Text), 2).ToString();
            tb_pmx_des.Text = decimal.Parse(tb_pmx_des.Text).ToString("N2");

            tb_pmx_inc.Text = decimal.Round(decimal.Parse(tb_pmx_inc.Text), 2).ToString();
            tb_pmx_inc.Text = decimal.Parse(tb_pmx_inc.Text).ToString("N2");

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
        

        }

    }
}
