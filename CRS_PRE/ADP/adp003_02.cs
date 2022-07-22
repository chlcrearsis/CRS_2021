using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp003 - Tipo de Atributos                            */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 30-08-2021         */
    /**********************************************************************/
    public partial class adp003_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia  
        adp003 o_adp003 = new adp003();
        DataTable Tabla = new DataTable();

        public adp003_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_tip.Clear();
            tb_nom_tip.Clear();
            tb_ide_atr.Clear();
            tb_nom_atr.Clear();
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {            
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Text = Tabla.Rows[0]["va_ide_tip"].ToString();
            }else {
                tb_ide_tip.Text = "0";
            }
            tb_nom_tip.Text = "";
            tb_ide_atr.Text = "99";
            tb_nom_atr.Text = "N/A";
            tb_nom_tip.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_ide_tip.Text.Trim() == ""){
                tb_ide_tip.Focus();
                return "DEBE proporcionar el Id para el Tipo de Atributo";
            }

            int ide_tip;
            // Valida que el campo ID. Tipo NO este vacio
            int.TryParse(tb_ide_tip.Text, out ide_tip);
            if (ide_tip == 0){
                tb_ide_tip.Focus();
                return "ID del Tipo de Atributo no es valido";
            }

            // Valida que el campo Nombre del Tipo NO este vacio
            if (tb_nom_tip.Text.Trim() == ""){
                tb_nom_tip.Focus();
                return "DEBE proporcionar el Nombre para el Tipo de Atributo";
            }

            int ide_atr;
            // Valida que el campo ID. Atributo NO este vacio
            int.TryParse(tb_ide_atr.Text, out ide_atr);
            if (ide_tip == 0){
                tb_ide_atr.Focus();
                return "ID del Atributo p/Defecto no es valido";
            }

            // Valida que el campo Nombre del Atributo NO este vacio
            if (tb_nom_atr.Text.Trim() == ""){
                tb_nom_atr.Focus();
                return "DEBE proporcionar el Nombre para el Atributo p/Defecto";
            }

            // Verifica SI existe otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(int.Parse(tb_ide_tip.Text) );
            if(Tabla.Rows.Count > 0){
                tb_ide_tip.Focus();
                return "Ya existe otro Tipo de Atributo con el mismo ID.";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_nom(tb_nom_tip.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_tip.Focus();
                return "YA existe otra Tipo de Atributo con el mismo nombre";
            }

            return "";
        }

        // Evento KeyPress : ID. Tipo Atributo
        private void tb_ide_tip_KeyPress(object sender, KeyPressEventArgs e){
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : ID. Atributo
        private void tb_ide_atr_KeyPress(object sender, KeyPressEventArgs e){
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
                    o_adp003.Fe_nue_reg(int.Parse(tb_ide_tip.Text), tb_nom_tip.Text,
                                        int.Parse(tb_ide_atr.Text), tb_nom_atr.Text);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));
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
