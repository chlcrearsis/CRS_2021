using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr014_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Vendedor";

        public cmr014_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los datos en pantalla
            Fi_lim_pia();

            // Despliega Informacion
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ide"].ToString();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_bre"].ToString();
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
            tb_cod_ven.Text = string.Empty;
            tb_nom_ven.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            cb_pro_ced.SelectedIndex = 0;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            if (tb_cod_ven.Text.Trim() == ""){
                tb_cod_ven.Focus();
                return "DEBE proporcionar el Código del Venddor";
            }

            // Valida que el campo Código NO este vacio
            int cod_ven;            
            int.TryParse(tb_cod_ven.Text, out cod_ven);
            if (cod_ven == 0){
                tb_cod_ven.Focus();
                return "ID del Código del Vendedor NO es valido";
            }

            // Verifica si el registro esta habilitado
            if (tb_est_ado.Text == "Deshabilitado"){
                return "El Vendedor se encuentra Deshabilitado";
            }

            // Valida que el campo Nombre del Vendedor NO este vacio
            if (tb_nom_ven.Text.Trim() == ""){
                tb_nom_ven.Focus();
                return "DEBE proporcionar el Nombre del Vendedor";
            }            

            // Verifica SI existe otro vendedor con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_con_nom(1, tb_nom_ven.Text.Trim(), int.Parse(tb_cod_ven.Text));
            if (Tabla.Rows.Count > 0){
                tb_nom_ven.Focus();
                return "YA existe otro Vendedor con el mismo nombre";
            }

            return "";
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {
                string nom_ven = tb_nom_ven.Text.Trim();
                string tel_cel = tb_tel_cel.Text.Trim();
                string ema_ail = tb_ema_ail.Text.Trim();
                   int ide_tip = 1; // Vendedor
                   int cod_ven = int.Parse(tb_cod_ven.Text);
                   int pro_ced = cb_pro_ced.SelectedIndex + 1;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Edita Vendedor
                    o_cmr014.Fe_edi_reg(ide_tip, cod_ven, nom_ven, tel_cel, ema_ail, pro_ced);
                    frm_pad.Fe_act_frm(int.Parse(tb_cod_ven.Text));

                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
                }
            }catch (Exception ex){
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
