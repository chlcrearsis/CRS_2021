using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp007_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;

        // Instancias        
        adp007 o_adp007 = new adp007();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Crea Definición de Ruta";

        public adp007_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_rut.Clear();
            tb_nom_rut.Clear();
            tb_nom_cor.Clear();
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {            
            Tabla = new DataTable();
            Tabla = o_adp007.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_ide_rut.Text = Tabla.Rows[0]["va_ide_rut"].ToString();
            }else {
                tb_ide_rut.Text = "1";
            }
            tb_nom_rut.Text = string.Empty;
            tb_nom_cor.Text = string.Empty;
            tb_nom_rut.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_ide_rut.Text.Trim() == "")
            {
                tb_ide_rut.Focus();
                return "DEBE proporcionar el Id para la Definición de Ruta";
            }

            int ide_rut;
            // Valida que el campo ID. Tipo NO este vacio
            int.TryParse(tb_ide_rut.Text, out ide_rut);
            if (ide_rut == 0){
                tb_ide_rut.Focus();
                return "ID del Ruta no es valido";
            }

            // Valida que el campo Nombre del Tipo NO este vacio
            if (tb_nom_rut.Text.Trim() == ""){
                tb_nom_rut.Focus();
                return "DEBE proporcionar el Nombre para la Ruta";
            }

            // Valida que el campo Nombre del Tipo NO este vacio
            if (tb_nom_cor.Text.Trim() == ""){
                tb_nom_cor.Focus();
                return "DEBE proporcionar el Nombre corto para la Ruta";
            }                    

            // Verifica SI existe otro registro con el mismo ID
            Tabla = o_adp007.Fe_con_rut(int.Parse(tb_ide_rut.Text) );
            if(Tabla.Rows.Count > 0){
                tb_ide_rut.Focus();
                return "Ya existe otro registro con el mismo ID.";
            }

            Tabla = new DataTable();
            Tabla = o_adp007.Fe_con_nom(tb_nom_rut.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_cor.Focus();
                return "YA existe otra Ruta con el mismo nombre";
            }

            return "";
        }

        // Evento KeyPress : ID. Ruta
        private void tb_ide_rut_KeyPress(object sender, KeyPressEventArgs e){
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
                    o_adp007.Fe_nue_reg(int.Parse(tb_ide_rut.Text), tb_nom_rut.Text, tb_nom_cor.Text);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_rut.Text));
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
