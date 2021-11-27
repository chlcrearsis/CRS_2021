using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp017_06 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp017 o_adp017 = new adp017();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Elimina Relación Contacto de Persona";

        public adp017_06(){
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
           
            // Verifica SI existe otro registro con el mismo nombre p/Mujer
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_con_cod(int.Parse(tb_ide_rel.Text));
            if (Tabla.Rows.Count == 0)
                return "No hay niguna Relación de Persona registrado con ese código.";

            // Verifica si el estado esta deshabilitado
            if (tb_est_ado.Text == "Habilitado")
                return "La Relación de Persona se encuentra Habilitado.";

            return "";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Tipo de Documento
                    o_adp017.Fe_eli_min(int.Parse(tb_ide_rel.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_rel.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
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
