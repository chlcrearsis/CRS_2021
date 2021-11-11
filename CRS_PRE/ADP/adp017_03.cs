using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp017_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias

        adp017 o_adp017 = new adp017();
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Relación Contacto de Persona";

        public adp017_03(){
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos en Pantalla
            Fi_lim_pia();

            // Despliega Datos
            tb_ide_rel.Text = frm_dat.Rows[0]["va_ide_rel"].ToString();
            tb_nre_hom.Text = frm_dat.Rows[0]["va_nre_hom"].ToString();
            tb_nre_muj.Text = frm_dat.Rows[0]["va_nre_muj"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";

            tb_nre_hom.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_rel.Text = string.Empty;
            tb_nre_hom.Text = string.Empty;
            tb_nre_muj.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }
       

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_ide_rel.Text.Trim() == ""){
                tb_ide_rel.Focus();
                return "DEBE proporcionar el Id para la Relación Contacto de Persona";
            }

            int ide_rel;
            // Valida que el campo ID. Relacion NO este vacio
            int.TryParse(tb_ide_rel.Text, out ide_rel);
            if (ide_rel == 0){
                tb_ide_rel.Focus();
                return "ID de Relación Contacto de Persona NO es valido";
            }

            // Valida que el campo Nombre p/Hombre NO este vacio
            if (tb_nre_hom.Text.Trim() == ""){
                tb_nre_hom.Focus();
                return "DEBE proporcionar el Nombre p/Hombre de Relación de Persona";
            }

            // Valida que el campo Nombre p/Mujer NO este vacio
            if (tb_nre_muj.Text.Trim() == ""){
                tb_nre_muj.Focus();
                return "DEBE proporcionar el Nombre p/Mujer de Relación de Persona";
            }                                 

            // Verifica SI existe otro registro con el mismo nombre p/Hombre
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_nre_hom(tb_nre_hom.Text.Trim(), int.Parse(tb_ide_rel.Text));
            if (Tabla.Rows.Count > 0){
                tb_nre_hom.Focus();
                return "YA existe otra Relación de Persona con el mismo nombre p/Hombre.";
            }

            // Verifica SI existe otro registro con el mismo nombre p/Mujer
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_nre_hom(tb_nre_muj.Text.Trim(), int.Parse(tb_ide_rel.Text));
            if (Tabla.Rows.Count > 0)
            {
                tb_nre_hom.Focus();
                return "YA existe otra Relación de Persona con el mismo nombre p/Mujer.";
            }

            return "";
        }       

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Titulo, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Graba el registro en la BD.
                    o_adp017.Fe_nue_rel(int.Parse(tb_ide_rel.Text), tb_nre_hom.Text.Trim(), tb_nre_muj.Text.Trim());
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_rel.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
            
    }
}
