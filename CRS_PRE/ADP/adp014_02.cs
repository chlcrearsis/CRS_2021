using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp014_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        
        adp014 o_adp014 = new adp014();
        DataTable Tabla = new DataTable();
        string Titulo = "Crea Tipo de Documento";

        public adp014_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_tip.Clear();
            tb_nom_tip.Clear();
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {            
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Text = Tabla.Rows[0]["va_ide_tip"].ToString();
            }else {
                tb_ide_tip.Text = "0";
            }
            tb_nom_tip.Text = "";
            tb_nom_tip.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_ide_tip.Text.Trim() == ""){
                tb_ide_tip.Focus();
                return "DEBE proporcionar el Id para el Tipo de Documento";
            }

            int ide_tip;
            // Valida que el campo ID. Tipo NO este vacio
            int.TryParse(tb_ide_tip.Text, out ide_tip);
            if (ide_tip == 0){
                tb_ide_tip.Focus();
                return "ID del Tipo de Documento no es valido";
            }

            // Valida que el campo Nombre del Tipo NO este vacio
            if (tb_nom_tip.Text.Trim() == ""){
                tb_nom_tip.Focus();
                return "DEBE proporcionar el Nombre para el Tipo de Documento";
            }         

            // Verifica SI existe otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip(int.Parse(tb_ide_tip.Text) );
            if(Tabla.Rows.Count > 0){
                tb_ide_tip.Focus();
                return "Ya existe otro Tipo de Documento con el mismo ID.";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_nom(tb_nom_tip.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_tip.Focus();
                return "YA existe otra Tipo de Documento con el mismo nombre";
            }

            return "";
        }

        // Evento KeyPress : ID. Tipo Atributo
        private void tb_ide_tip_KeyPress(object sender, KeyPressEventArgs e){
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
                    MessageBox.Show("Error: " + msg_val, Titulo, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Graba el registro en la BD.
                    o_adp014.Fe_nue_tip(int.Parse(tb_ide_tip.Text), tb_nom_tip.Text);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    Fi_lim_pia();
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
