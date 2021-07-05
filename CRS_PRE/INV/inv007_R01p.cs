using CRS_NEG;
using CRS_PRE.CMR;
using CRS_PRE.INV;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE.INV
{
    public partial class inv007_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;


        //Instancias
        inv002 o_inv002 = new inv002();
        inv004 o_inv004 = new inv004();
        inv007 o_inv007 = new inv007();

        DataTable tabla = new DataTable();
        DataTable tab_pro = new DataTable();
        int opc_bod = 0;
        int opc_per = 0;

        public inv007_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_pe1.Text = "000000";
            lb_nom_pe1.Text = "Proveedor inicial";

            tb_cod_pe2.Text = "999999";
            lb_nom_pe2.Text = "Proveedor Final";

            tb_cod_bo1.Text = "0000";
            lb_nom_bo1.Text = "Bodega inicial";
            tb_cod_bo2.Text = "9999";
            lb_nom_bo2.Text = "Bodega final";

            tb_fec_fin.Value = DateTime.Now;
            tb_fec_ini.Value = tb_fec_fin.Value.AddMonths(-1);

            tb_cod_pe1.Focus();


        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }


        private int Fi_ver_dat()
        {
            // Verifica Proveedor 1
            if (tb_cod_pe1.Text.Trim() == "")
            {
                tb_cod_pe1.Focus();
                MessageBox.Show("Debe de proporcionar un proveedor valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            int val = 0;
            try
            {
                val = int.Parse(tb_cod_pe1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe de proporcionar un proveedor valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_pe1.Focus();
                return 1;
            }

            if (val != 0 )
            {
                // Valida que la bodega exista
                tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_pe1.Text));
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El proveedor no se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_cod_pe1.Focus();
                    return 1;
                }
            }

            // Verifica Proveedor 2
            if (tb_cod_pe2.Text.Trim() == "")
            {
                tb_cod_pe2.Focus();
                MessageBox.Show("Debe de proporcionar un proveedor valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            val = 0;
            try
            {
                val = int.Parse(tb_cod_pe2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe de proporcionar un proveedor valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_pe2.Focus();
                return 1;
            }

            if (val != 999999)
            {
                // Valida que la bodega exista
                tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_pe2.Text));
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("El proveedor no se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_cod_pe2.Focus();
                    return 1;
                }
            }


            //Verifica bodega 1
            if (tb_cod_bo1.Text.Trim() == "")
            {
                tb_cod_bo1.Focus();
                MessageBox.Show("Debe de proporcionar una bodega valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }

            val = 0;
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

            if (val != 0)
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


            //Verifica fechas
            int nro_dias = 0;
            nro_dias = (tb_fec_fin.Value - tb_fec_ini.Value).Days;

            if(nro_dias < 0)
            {
                MessageBox.Show("La fecha inicial no puede ser debe ser menor a la final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_bo2.Focus();
                return 1;
            }

            return 0;

        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (Fi_ver_dat() == 1)
                return;

            //Obtiene datos
            tabla = new DataTable();
            tabla= o_inv007.Fe_inv007_R01(int.Parse(tb_cod_pe1.Text), int.Parse(tb_cod_pe2.Text), int.Parse(tb_cod_bo1.Text), int.Parse(tb_cod_bo2.Text), tb_fec_ini.Value, tb_fec_fin.Value);

            inv007_R01w frm = new inv007_R01w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }




        // Botones para proveedores
        private void Bt_bus_pe1_Click(object sender, EventArgs e)
        {
            opc_per = 1;
            Fi_abr_bus_per();
        }
        private void Bt_bus_pe2_Click(object sender, EventArgs e)
        {
            opc_per = 2;
            Fi_abr_bus_per();
        }
        private void Tb_cod_per_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_per();
            }
        }
        void Fi_abr_bus_per()
        {
            cmr013_01 frm = new cmr013_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                if (opc_per == 1)
                {
                    tb_cod_pe1.Text = frm.tb_sel_bus.Text;
                    lb_nom_pe1.Text = frm.lb_des_bus.Text;
                    tb_cod_pe1.Focus();
                }
                if (opc_per == 2)
                {
                    tb_cod_pe2.Text = frm.tb_sel_bus.Text;
                    lb_nom_pe2.Text = frm.lb_des_bus.Text;
                    tb_cod_pe2.Focus();
                }

            }
        }
        private void Tb_cod_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_per();
        }


        private void Fi_obt_per()
        {
            int val = 0;
            if (opc_per == 1)
            {
                if (tb_cod_pe1.Text.Trim() == "")
                {
                    lb_nom_pe1.Text = "";
                    return;
                }

                try
                {
                    val = int.Parse(tb_cod_pe1.Text);
                }
                catch (Exception)
                {
                    lb_nom_pe1.Text = "";
                    return;
                }

                if (val == 0)
                {
                    lb_nom_pe1.Text = "Proveedor inicial";
                    return;
                }
                tabla = o_inv002.Fe_con_bod(val);
                if (tabla.Rows.Count == 0)
                {
                    lb_nom_pe1.Text = "";
                }
                else
                {
                    lb_nom_pe1.Text = tabla.Rows[0]["va_nom_per"].ToString();
                }
            }
            if (opc_bod == 2)
            {
                if (tb_cod_pe2.Text.Trim() == "")
                {
                    lb_nom_pe2.Text = "";
                    return;
                }

                try
                {
                    val = int.Parse(tb_cod_pe2.Text);
                }
                catch (Exception)
                {
                    lb_nom_pe2.Text = "";
                    return;
                }

                if (val == 999999)
                {
                    lb_nom_pe2.Text = "Proveedor final";
                    return;
                }
                tabla = o_inv002.Fe_con_bod(val);
                if (tabla.Rows.Count == 0)
                {
                    lb_nom_pe2.Text = "";
                }
                else
                {
                    lb_nom_pe2.Text = tabla.Rows[0]["va_nom_per"].ToString();
                }
            }
        }

        private void tb_cod_pe1_Enter(object sender, EventArgs e)
        {
            opc_per = 1;
        }

        private void tb_cod_pe2_Enter(object sender, EventArgs e)
        {
            opc_per = 2;
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
            if (opc_bod == 1)
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
