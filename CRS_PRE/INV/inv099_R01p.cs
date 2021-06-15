using CRS_NEG.INV;
using CRS_PRE.INV;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE.INV
{
    public partial class inv099_R01p : Form
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

        public inv099_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_cod_pro.Text = frm_dat.Rows[0]["va_cod_pro"].ToString();
            lb_nom_pro.Text = frm_dat.Rows[0]["va_nom_pro"].ToString();

            // Obtiene primer almacen
            //tabla = o_inv002.ob
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
            tabla= o_inv099.Fe_inv099_R01(int.Parse(tb_cod_bod.Text),tb_cod_pro.Text,tb_fec_ini.Value,tb_fec_fin.Value);

            inv099_R01w frm = new inv099_R01w();
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
                lb_nom_bod.Text = "";
            }
            int val = 0;
            if (tb_cod_bod.Text.Trim() == "0" || tb_cod_bod.Text.Trim() == "00")
            {
                lb_nom_bod.Text = "";
            }
            else
            {
                int.TryParse(tb_cod_bod.Text, out val);
                if (val == 0)
                {
                    lb_nom_bod.Text = "";
                }
                tabla = o_inv002.Fe_con_bod(val);
                if (tabla.Rows.Count == 0)
                {
                    lb_nom_bod.Text = "";
                }
                else
                {
                    lb_nom_bod.Text = tabla.Rows[0]["va_nom_bod"].ToString();
                }
            }
        }

        //** BUSCAR PRODUCTO
        private void Bt_bus_pro_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_pro();
        }
        private void Tb_cod_pro_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
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
        private void Fi_obt_pro()
        {
            if (tb_cod_pro.Text.Trim() == "")
            {
                lb_nom_pro.Text = " No existe";
                
                return;
            }

            tab_pro = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tab_pro.Rows.Count == 0)
            {
                lb_nom_pro.Text = " No existe";

            }
            else
            {
                lb_nom_pro.Text = tab_pro.Rows[0]["va_nom_pro"].ToString();
                
            }
        }
    }
}
