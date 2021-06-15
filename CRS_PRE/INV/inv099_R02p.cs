using CRS_NEG.INV;
using CRS_PRE.INV;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE.INV
{
    public partial class inv099_R02p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;


        //Instancias
        c_inv002 o_inv002 = new c_inv002();
        c_inv004 o_inv004 = new c_inv004();
        c_inv099 o_inv099 = new c_inv099();

        DataTable tabla = new DataTable();
        DataTable tab_pro = new DataTable();
        int opc_bod = 0;

        public inv099_R02p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_cod_bo1.Text = "0000";
            lb_nom_bo1.Text = "Bodega inicial";
            tb_cod_bo2.Text = "9999";
            lb_nom_bo2.Text = "Bodega final";

            // Obtiene primer almacen
            //tabla = o_inv002.ob
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }


        private int Fi_ver_dat()
        {
            // Valida datos
            if (tb_cod_bo1.Text.Trim() == "")
            {
                tb_cod_bo1.Focus();
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            int val = 0;
            try
            {
                val = int.Parse(tb_cod_bo1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_bo1.Focus();
                return 1;
            }

            if (val != 0 )
            {
                // Valida que la bodega exista
                tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bo1.Text));
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("La bodega no se encuentra registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_cod_bo1.Focus();
                    return 1;
                }
            }

            //Verifica bodega 2

            if (tb_cod_bo2.Text.Trim() == "")
            {
                tb_cod_bo2.Focus();
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;

            }

            val = 0;
            try
            {
                val = int.Parse(tb_cod_bo2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_bo2.Focus();
                return 1;
            }

            if (val != 9999)
            {
                // Valida que la bodega exista
                tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bo2.Text));
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("La bodega no se encuentra registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_cod_bo2.Focus();
                    return 1;
                }
            }

            return 0;

        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (Fi_ver_dat() == 1)
                return;

            //Obtiene datos
            tabla = new DataTable();
            tabla= o_inv099.Fe_inv099_R02(int.Parse(tb_cod_bo1.Text), int.Parse(tb_cod_bo2.Text), "000000","999999", tb_fec_exi.Value);

            inv099_R02w frm = new inv099_R02w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }


        private void Bt_bus_bo1_Click(object sender, EventArgs e)
        {
            opc_bod = 1;
            Fi_abr_bus_bod();
        }
        private void Bt_bus_bo2_Click(object sender, EventArgs e)
        {
            opc_bod = 2;
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
                if(opc_bod == 1)
                {
                    tb_cod_bo1.Text = frm.tb_sel_bus.Text;
                    lb_nom_bo1.Text = frm.lb_des_bus.Text;
                }
                if (opc_bod == 2)
                {
                    tb_cod_bo2.Text = frm.tb_sel_bus.Text;
                    lb_nom_bo2.Text = frm.lb_des_bus.Text;
                }

            }
        }
        private void Tb_cod_bod_Validated(object sender, EventArgs e)
        {
            Fi_obt_bod();
        }

        
        private void Fi_obt_bod()
        {
            if(opc_bod == 1)
            {
                if (tb_cod_bo1.Text.Trim() == "")
                {
                    lb_nom_bo1.Text = "";
                }
                int val = 0;
                try
                {
                    val = int.Parse(tb_cod_bo1.Text);
                }
                catch (Exception)
                {
                    lb_nom_bo1.Text = "";
                }

                if (val != 0)
                {
                    // Valida que la bodega exista
                    tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bo1.Text));
                    if (tabla.Rows.Count == 0)
                    {
                        lb_nom_bo1.Text = "";
                    }
                    else
                    {
                        lb_nom_bo1.Text = tabla.Rows[0]["va_nom_bod"].ToString();
                    }
                }
                else
                {
                    lb_nom_bo1.Text = "Bodega inicial";
                }


            }
            if (opc_bod == 2)
            {
                if (tb_cod_bo2.Text.Trim() == "")
                {
                    lb_nom_bo2.Text = "";
                }
                int val = 0;
                try
                {
                    val = int.Parse(tb_cod_bo2.Text);
                }
                catch (Exception)
                {
                    lb_nom_bo2.Text = "";
                }

                if (val != 9999)
                {
                    // Valida que la bodega exista
                    tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bo2.Text));
                    if (tabla.Rows.Count == 0)
                    {
                        lb_nom_bo2.Text = "";
                    }
                    else
                    {
                        lb_nom_bo2.Text = tabla.Rows[0]["va_nom_bod"].ToString();
                    }
                }
                else
                {
                    lb_nom_bo2.Text = "Bodega final";
                }
            }

        }

        private void tb_cod_bo1_Enter(object sender, EventArgs e)
        {
            opc_bod = 1;
        }

        private void tb_cod_bo2_Enter(object sender, EventArgs e)
        {
            opc_bod = 2;
        }

       
    }
}
