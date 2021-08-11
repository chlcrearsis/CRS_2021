using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads002_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias

        ads002 o_ads002 = new ads002();
        ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();

        public ads002_02()
        {
            InitializeComponent();
        }

     
        private void frm_Load(object sender, EventArgs e)
        {
            // obtiene lista de 
            tb_ide_mod.Text = "0";
            tb_ide_mod.Focus();
           
        }

        protected string Fi_val_dat()
        {
            
            // Variable usada para verificar datos numericos
           int val = 0;

            //Verificar Modulo
            if (tb_ide_mod.Text.Trim()=="")
            {
                tb_ide_mod.Focus();
                return "Debe proporcionar el Modulo";
            }

            try
            {
                int.TryParse(tb_ide_mod.Text,out val);
            }
            catch (Exception)
            {
                tb_ide_mod.Focus();
                return "El Modulo no es valido";
            }

            tabla = new DataTable();
            tabla = o_ads001.Fe_con_mod(tb_ide_mod.Text);
            if(tabla.Rows.Count==0)
            {
                tb_ide_mod.Focus();
                return "El Modulo no se encuentra registrado";
            }

            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_ide_mod.Focus();
                return "El Modulo se encuentra Deshabilitado";
            }

            //Verificar Aplicacion
            if (tb_ide_apl.Text.Trim() == "")
            {
                tb_ide_apl.Focus();
                return "Debe proporcionar el nro de Aplicacion";
            }

            tabla = new DataTable();
            tabla = o_ads002.Fe_con_apl(tb_ide_apl.Text);
            if(tabla.Rows.Count > 0)
            {
                tb_ide_apl.Focus();
                return "El Aplicacion que desea crear ya se encuentra registrado";
            }

            if (tb_nom_app.Text.Trim() == "")
            {
                tb_nom_app.Focus();
                return "Debe proporcionar el Nombre para el Aplicacion";
            }

            return "";
        }

        private void Fi_lim_pia()
        {
            tb_ide_apl.Clear();
            tb_nom_app.Clear();

            tb_ide_apl.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo Aplicacion", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar Aplicacion
                o_ads002.Fe_crea(int.Parse(tb_ide_mod.Text),tb_ide_apl.Text,tb_nom_app.Text);

                MessageBox.Show("Los datos se grabaron correctamente", "Nueva aplicacion", MessageBoxButtons.OK);
                frm_pad.Fe_act_frm(tb_ide_apl.Text);
                Fi_lim_pia();
                
            }
        }

        private void Bt_bus_mod_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_mod();
        }
      
        private void Tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Modulo
                Fi_abr_bus_mod();
            }
        }

        void Fi_abr_bus_mod()
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK )
            {
                tb_ide_mod.Text = frm.tb_sel_bus.Text;
                Fi_obt_mod();
            }
        }

        private void Tb_ide_mod_Validated(object sender, EventArgs e)
        {
            Fi_obt_mod();
        }
        /// <summary>
        /// Obtiene ide y nombre Modulo para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_mod()
        {
            // Obtiene ide y nombre Modulo
            tabla = o_ads001.Fe_con_mod(tb_ide_mod.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_mod.Clear();
            }
            else
            {
                tb_ide_mod.Text = tabla.Rows[0]["va_ide_mod"].ToString();
                tb_nom_mod.Text = tabla.Rows[0]["va_nom_mod"].ToString();
            }
        }
    }
}
