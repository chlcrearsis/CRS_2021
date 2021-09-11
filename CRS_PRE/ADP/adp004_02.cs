using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp004_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        DataTable Tabla = new DataTable();
        string Titulo = "Crea Definición de Atributo";

        public adp004_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_tip.Text = string.Empty;
            lb_nom_tip.Text = string.Empty;
            tb_ide_atr.Text = string.Empty;
            tb_nom_atr.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {            
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(frm_pad.vp_ide_tip);
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                lb_nom_tip.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
            }
            else {
                tb_ide_tip.Text = "1";
                lb_nom_tip.Text = string.Empty;
            }

            Tabla = new DataTable();
            Tabla = o_adp004.Fe_obt_ide(frm_pad.vp_ide_tip);
            if (Tabla.Rows.Count > 0){
                tb_ide_atr.Text = Tabla.Rows[0]["va_ide_atr"].ToString().Trim();
            }else {
                tb_ide_atr.Text = "0";
            }            
            tb_nom_atr.Text = string.Empty;
            tb_nom_atr.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_ide_tip.Text.Trim() == "")
            {
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
            if (tb_nom_atr.Text.Trim() == ""){
                tb_nom_atr.Focus();
                return "DEBE proporcionar el Nombre para el Atributo";
            }

            int ide_atr;
            // Valida que el campo ID. Atributo NO este vacio
            int.TryParse(tb_ide_atr.Text, out ide_atr);
            if (ide_tip == 0){
                tb_ide_atr.Focus();
                return "ID del Atributo NO es valido";
            }

            // Verifica SI existe otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_con_atr(int.Parse(tb_ide_tip.Text), int.Parse(tb_ide_atr.Text));
            if(Tabla.Rows.Count > 0){
                tb_ide_tip.Focus();
                return "Ya existe otro Atributo con el mismo ID.";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_con_nom(int.Parse(tb_ide_tip.Text), tb_nom_atr.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_atr.Focus();
                return "YA existe otro Atributo con el mismo nombre";
            }

            return "";
        }

        // Obtiene el Tipo de Atributo
        private void fi_obt_tip(int ide_tip) {
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(ide_tip);
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                lb_nom_tip.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
            }else {
                lb_nom_tip.Text = string.Empty;
                MessageBox.Show("El Tipo de Atributo NO está definido en la base de datos", Titulo, MessageBoxButtons.OK);
            }
        }

        // Función: Buscar Atributo p/Defecto
        void Fi_bus_tip()
        {
            adp003_01 frm = new adp003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_ide_tip.Text = frm.tb_ide_tip.Text;
                fi_obt_tip(Int32.Parse(tb_ide_tip.Text));
            }
        }

        // Evento KeyPress : ID. Tipo Atributo
        private void tb_ide_tip_KeyPress(object sender, KeyPressEventArgs e){
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : ID. Atributo
        private void tb_ide_atr_KeyPress(object sender, KeyPressEventArgs e){
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_ide_tip_KeyDown(object sender, KeyEventArgs e){
            Fi_bus_tip();
        }

        private void tb_ide_tip_KeyUp(object sender, KeyEventArgs e){
            Fi_bus_tip();
        }

        private void bt_bus_tip_Click(object sender, EventArgs e){
            Fi_bus_tip();
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
                    o_adp004.Fe_nue_atr(int.Parse(tb_ide_tip.Text), int.Parse(tb_ide_atr.Text),
                                        tb_nom_atr.Text);
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
