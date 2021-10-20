using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr014_02b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        cmr014 o_cmr014 = new cmr014();

        DataTable Tabla = new DataTable();
        string Titulo = "Nuevo Cobrador";

        public cmr014_02b()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            Fi_lim_pia();            
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            // Limpia Campos
            tb_cod_cob.Text = string.Empty;
            tb_nom_cob.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            cb_pro_ced.SelectedIndex = 0;
            tb_cod_cob.Focus();
            // Inicializa Datos
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            // Obtiene el Código que corresponde
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_obt_ide(2);
            if (Tabla.Rows.Count > 0)
                tb_cod_cob.Text = Tabla.Rows[0]["va_cod_ide"].ToString();
            else
                tb_cod_cob.Text = "0";
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            if (tb_cod_cob.Text.Trim() == ""){
                tb_cod_cob.Focus();
                return "DEBE proporcionar el Código del Cobrador";
            }

            int cod_cob;
            // Valida que el campo Código NO este vacio
            int.TryParse(tb_cod_cob.Text, out cod_cob);
            if (cod_cob == 0){
                tb_cod_cob.Focus();
                return "ID del Código del Cobrador NO es valido";
            }

            // Valida que el campo Nombre Cobrador NO este vacio
            if (tb_nom_cob.Text.Trim() == ""){
                tb_nom_cob.Focus();
                return "DEBE proporcionar el Nombre del Cobrador";
            }

            // Verifica SI existe otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_cob.Text), 2);
            if (Tabla.Rows.Count > 0){
                tb_cod_cob.Focus();
                return "Ya existe otro Cobrador con el mismo Código";
            }

            // Verifica SI existe otro Cobrador con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_con_nom(1, tb_nom_cob.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_cob.Focus();
                return "YA existe otro Cobrador con el mismo nombre";
            }

            return "";
        }

        private void tb_cod_cob_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {
                string nom_cob = tb_nom_cob.Text.Trim();
                string tel_cel = tb_tel_cel.Text.Trim();
                string ema_ail = tb_ema_ail.Text.Trim();
                   int ide_tip = 2; // Cobrador
                   int cod_cob = int.Parse(tb_cod_cob.Text);
                   int pro_ced = cb_pro_ced.SelectedIndex + 1;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    // Registra Nuevo Cobrador 
                    o_cmr014.Fe_nue_reg(ide_tip, cod_cob, nom_cob, tel_cel, ema_ail, pro_ced, 1, 0m, 0m);

                    frm_pad.Fe_act_frm(int.Parse(tb_cod_cob.Text));
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
