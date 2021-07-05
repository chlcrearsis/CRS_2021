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
using CRS_PRE.INV;
using CRS_NEG.INV;
using CRS_NEG.CMR;

namespace CRS_PRE.CMR
{
    public partial class cmr005_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
      

        c_inv002 o_inv002 = new c_inv002();
        
        c_cmr005 o_cmr005 = new c_cmr005();
        DataTable tabla = new DataTable();


        public cmr005_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
           
            cb_est_ado.SelectedIndex = 0;
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            // Valida datos
            if(tb_cod_bod.Text.Trim()== "")
            {
                tb_cod_bod.Focus();
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
            int val = 0;
            int.TryParse(tb_cod_bod.Text, out val);
            if(val == 0)
            {
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_bod.Focus();
                return;
            }

            // Valida que la bodega exista
            tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
            if(tabla.Rows.Count==0)
            {
                MessageBox.Show("La bodega no se encuentra registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_bod.Focus();
                return;
            }

            //Obtiene datos
            tabla = new DataTable();
            string va_est_ado = "T";

            if (cb_est_ado.Text == "Todos")
                va_est_ado = "T";
            if (cb_est_ado.Text == "Validos")
                va_est_ado = "V";
            if (cb_est_ado.Text == "Anulados")
                va_est_ado = "N";

            tabla = o_cmr005.Fr_cmr005_R01(int.Parse(tb_cod_bod.Text),tb_fec_ini.Value,tb_fec_fin.Value, va_est_ado);

            cmr005_R01w frm = new cmr005_R01w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }



        private void Bt_bus_bod_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_bod();
        }
        private void Tb_cod_bod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_bod();
            }
        }
        void Fi_abr_bus_bod()
        {
            inv002_01 frm = new inv002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_bod.Text = frm.tb_sel_bus.Text;
                lb_nom_bod.Text = frm.lb_des_bus.Text;
            }
        }
        private void Tb_cod_bod_Validated(object sender, EventArgs e)
        {
            Fi_obt_bod();
        }
        private void Fi_obt_bod()
        {
            if (tb_cod_bod.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar una bodega valida", "Error", MessageBoxButtons.OK);
                tb_cod_bod.Focus();
            }
            int val = 0;
            if (tb_cod_bod.Text.Trim() == "0" || tb_cod_bod.Text.Trim() == "00")
            {
                lb_nom_bod.Text = "Todos";
            }
            else
            {
                int.TryParse(tb_cod_bod.Text, out val);
                if (val == 0)
                {
                    MessageBox.Show("Debe proporcionar una bodega valida", "Error", MessageBoxButtons.OK);
                    tb_cod_bod.Focus();
                }
                tabla = o_inv002.Fe_con_bod(val);
                if (tabla.Rows.Count == 0)
                {
                    lb_nom_bod.Text = "No Existe";
                }
                else
                {
                    lb_nom_bod.Text = tabla.Rows[0]["va_nom_bod"].ToString();
                }
            }
        }
       
       
    }
}
