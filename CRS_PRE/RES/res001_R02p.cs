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
using CRS_NEG.ADS;
using CRS_PRE.INV;
using CRS_NEG.INV;
using CRS_NEG.CMR;

namespace CRS_PRE.CMR
{
    public partial class res001_R02p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
      

        c_inv002 o_inv002 = new c_inv002();
        c_cmr015 o_cmr015 = new c_cmr015();
        c_res001 o_res001 = new c_res001();
        DataTable tabla = new DataTable();


        public res001_R02p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_bod.Text = "0";
            tb_cod_del.Text = "0";

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
            tabla = o_res001.Fe_res001_R02(int.Parse(tb_cod_bod.Text),tb_fec_ini.Value,tb_fec_fin.Value, int.Parse(tb_cod_del.Text));

            res001_R02w frm = new res001_R02w();
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


        private void Bt_bus_del_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_del();
        }
        private void Tb_cod_del_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_del();
            }
        }
        void Fi_abr_bus_del()
        {
            cmr015_01 frm = new cmr015_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_del.Text = frm.tb_sel_bus.Text;
                lb_nom_del.Text = frm.lb_des_bus.Text;
            }
        }
        private void Tb_cod_del_Validated(object sender, EventArgs e)
        {
            Fi_obt_del();
        }
        private void Fi_obt_del()
        {
            if (tb_cod_del.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar un delivery valido", "Error", MessageBoxButtons.OK);
                tb_cod_del.Focus();
            }
            int val = 0;
           
            int.TryParse(tb_cod_del.Text, out val);
            if (val == 0)
            {
                MessageBox.Show("Debe proporcionar un delivery valido", "Error", MessageBoxButtons.OK);
                tb_cod_del.Focus();
            }
            tabla = o_cmr015.Fe_con_del(val);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_del.Text = "No Existe";
            }
            else
            {
                lb_nom_del.Text = tabla.Rows[0]["va_nom_del"].ToString();
            }
         
        }

    }
}
