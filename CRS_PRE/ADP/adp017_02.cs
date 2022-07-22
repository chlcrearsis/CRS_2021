using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp017 - Relación Contacto de Persona                 */
    /*      Opción: Crea Registro                                         */
    /*       Autor: JEJR - Crearsis             Fecha: 30-08-2021         */
    /**********************************************************************/
    public partial class adp017_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias        
        adp017 o_adp017 = new adp017();
        DataTable Tabla = new DataTable();

        public adp017_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_rel.Text = string.Empty;
            tb_nre_hom.Text = string.Empty;
            tb_nre_muj.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {            
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_ide_rel.Text = Tabla.Rows[0]["va_ide_rel"].ToString();
            }else {
                tb_ide_rel.Text = "0";
            }            
            tb_nre_hom.Focus();
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

            // Verifica SI existe otro registro con el mismo Código
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_con_cod(int.Parse(tb_ide_rel.Text));
            if(Tabla.Rows.Count > 0){
                tb_ide_rel.Focus();
                return "Ya existe otra Relación de Persona con el mismo Código";
            }

            // Verifica SI existe otro registro con el mismo nombre p/Hombre
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_nre_hom(tb_nre_hom.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nre_hom.Focus();
                return "YA existe otra Relación de Persona con el mismo nombre p/Hombre.";
            }

            // Verifica SI existe otro registro con el mismo nombre p/Mujer
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_nre_hom(tb_nre_muj.Text.Trim());
            if (Tabla.Rows.Count > 0)
            {
                tb_nre_hom.Focus();
                return "YA existe otra Relación de Persona con el mismo nombre p/Mujer.";
            }

            return "";
        }

        // Evento KeyPress : ID. Tipo Atributo
        private void tb_ide_rel_KeyPress(object sender, KeyPressEventArgs e){
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Text, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Graba el registro en la BD.
                    o_adp017.Fe_nue_reg(int.Parse(tb_ide_rel.Text), tb_nre_hom.Text.Trim(), tb_nre_muj.Text.Trim());
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_rel.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }            
    }
}
