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
using CRS_NEG;
using CRS_NEG;

namespace CRS_PRE.CMR
{
    public partial class res001_R03p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
      

        inv002 o_inv002 = new inv002();
        cmr015 o_cmr015 = new cmr015();
        res001 o_res001 = new res001();
        DataTable tabla = new DataTable();
        DataTable tab_dat = new DataTable();


        public res001_R03p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            //Obtiene el primer almacen


            tb_cod_bod.Text = "0";
            tb_cod_de1.Text = "0";
            lb_nom_de1.Text = "Delivery inicial";
            tb_cod_de2.Text = "99";
            lb_nom_de2.Text = "Delivery final";

        }

        int Fi_val_dat()
        {
            // Valida datos
            if (tb_cod_bod.Text.Trim() == "")
            {
                tb_cod_bod.Focus();
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;

            }
            int val = 0;
            int.TryParse(tb_cod_bod.Text, out val);
            if (val == 0)
            {
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_bod.Focus();
                return 1;
            }

            // Valida que la bodega exista
            tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("La bodega no se encuentra registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_bod.Focus();
                return 1;
            }


            //Valida Deliverys
            val = 0;
            try
            {
                val = int.Parse(tb_cod_de1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El delivery no se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_de1.Focus();
                return 1;
            }
            if (val != 0)
            { // Valida que el delivery exista
                tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_de1.Text));
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El delivery no se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_cod_de1.Focus();
                    return 1;
                }
            }

            //Valida Deliverys 2
            val = 0;
            try
            {
                val = int.Parse(tb_cod_de2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El delivery no se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_de2.Focus();
                return 1;
            }
            if (val != 99)
            {// Valida que el delivery exista
                tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_de2.Text));
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El delivery no se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_cod_de2.Focus();
                    return 1;
                }
            }

            //Obtiene datos
            tab_dat = new DataTable();
            tab_dat = o_res001.Fe_res001_R03(int.Parse(tb_cod_bod.Text), tb_fec_ini.Value, tb_fec_fin.Value, int.Parse(tb_cod_de1.Text), int.Parse(tb_cod_de2.Text));

            return  0;
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {

            if (Fi_val_dat() == 0)
            {
                res001_R03w frm = new res001_R03w();
                cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tab_dat);
            }
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

        int opc_del = 0;
   
        private void Bt_bus_de1_Click(object sender, EventArgs e)
        {
            opc_del = 1;
            Fi_abr_bus_del();
        }
        private void Bt_bus_de2_Click(object sender, EventArgs e)
        {
            opc_del = 2;
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

        private void Tb_cod_de1_KeyDown(object sender, KeyEventArgs e)
        {
            opc_del = 1;
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_del();
            }
        }


        private void Tb_cod_de2_KeyDown(object sender, KeyEventArgs e)
        {
            opc_del = 2;
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

                if (opc_del == 1)
                {
                    tb_cod_de1.Text = frm.tb_sel_bus.Text;
                    lb_nom_de1.Text = frm.lb_des_bus.Text;
                }
                if (opc_del == 2)
                {
                    tb_cod_de2.Text = frm.tb_sel_bus.Text;
                    lb_nom_de2.Text = frm.lb_des_bus.Text;
                }
            }
        }
     
        private void Tb_cod_de1_Validated(object sender, EventArgs e)
        {
            opc_del = 1;
            Fi_obt_del();
        }
        private void Tb_cod_de2_Validated(object sender, EventArgs e)
        {
            opc_del = 2;
            Fi_obt_del();
        }
        private void Fi_obt_del()
        {
            if (opc_del == 1)
            {
                
                int val = 0;
                try
                {
                    val = int.Parse(tb_cod_de1.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe proporcionar un delivery valido", "Error", MessageBoxButtons.OK);
                    tb_cod_de1.Focus();
                }

                if (val != 0)
                {
                    tabla = o_cmr015.Fe_con_del(val);
                    if (tabla.Rows.Count == 0)
                    {
                        lb_nom_de1.Text = "No Existe";
                    }
                    else
                    {
                        lb_nom_de1.Text = tabla.Rows[0]["va_nom_del"].ToString();
                    }
                }
                else
                {
                    lb_nom_de1.Text = "Delivery inicial";
                }
            }
            if (opc_del == 2)
            {
                int val = 0;
                try
                {
                    val = int.Parse(tb_cod_de2.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe proporcionar un delivery valido", "Error", MessageBoxButtons.OK);
                    tb_cod_de2.Focus();
                }

                if (val != 99)
                {
                    tabla = o_cmr015.Fe_con_del(val);
                    if (tabla.Rows.Count == 0)
                    {
                        lb_nom_de2.Text = "No Existe";
                    }
                    else
                    {
                        lb_nom_de2.Text = tabla.Rows[0]["va_nom_del"].ToString();
                    }
                }
                else
                {
                    lb_nom_de2.Text = "Delivery Final";
                }
            }
        }

    }
}
