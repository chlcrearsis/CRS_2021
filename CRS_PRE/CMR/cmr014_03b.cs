using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr014_03b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Cobrador";

        public cmr014_03b()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los datos en pantalla
            Fi_lim_pia();

            // Despliega Informacion
            tb_cod_cob.Text = frm_dat.Rows[0]["va_cod_ide"].ToString();
            tb_nom_cob.Text = frm_dat.Rows[0]["va_nom_bre"].ToString();
            tb_tel_cel.Text = frm_dat.Rows[0]["va_tel_cel"].ToString();
            tb_ema_ail.Text = frm_dat.Rows[0]["va_ema_ail"].ToString();
            cb_pro_ced.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_pro_ced"].ToString()) - 1;

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {            
            tb_cod_cob.Text = string.Empty;
            tb_nom_cob.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            cb_pro_ced.SelectedIndex = 0;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            if (tb_cod_cob.Text.Trim() == ""){
                tb_cod_cob.Focus();
                return "DEBE proporcionar el Código del Cobrador";
            }

            // Valida que el campo Código NO este vacio
            int cod_cob;            
            int.TryParse(tb_cod_cob.Text, out cod_cob);
            if (cod_cob == 0){
                tb_cod_cob.Focus();
                return "ID del Código del Cobrador NO es valido";
            }

            // Verifica si el registro esta habilitado
            if (tb_est_ado.Text == "Deshabilitado") {
                return "El Cobrador se encuentra Deshabilitado";
            }

            // Valida que el campo Nombre del cobrador NO este vacio
            if (tb_nom_cob.Text.Trim() == ""){
                tb_nom_cob.Focus();
                return "DEBE proporcionar el Nombre del Cobrador";
            }

            // Verifica SI existe otro cobrador con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_con_nom(2, tb_nom_cob.Text.Trim(), int.Parse(tb_cod_cob.Text));
            if (Tabla.Rows.Count > 0){
                tb_nom_cob.Focus();
                return "YA existe otro Cobrador con el mismo nombre";
            }

            return "";
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
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Edita Cobrador
                    o_cmr014.Fe_edi_reg(ide_tip, cod_cob, nom_cob, tel_cel, ema_ail, pro_ced);
                    frm_pad.Fe_act_frm(int.Parse(tb_cod_cob.Text));

                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
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
