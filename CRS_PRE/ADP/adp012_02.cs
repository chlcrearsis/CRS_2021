using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp012_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp002 o_adp002 = new adp002();
        adp012 o_adp012 = new adp012();
        adp018 o_adp018 = new adp018();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Asig. a Grupo Empresarial";

        public adp012_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            // Limpia los datos en Pantalla
            Fi_lim_cam();

            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString().Trim();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString().Trim();

            // Obtiene la Asig. Grupo Empresarial
            Tabla = new DataTable();
            Tabla = o_adp012.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count > 0) {
                tb_gru_emp.Text = Tabla.Rows[0]["va_gru_emp"].ToString().Trim();
                tb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
            }
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_cam(){
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_gru_emp.Text = string.Empty;
            tb_nom_gru.Text = string.Empty;
        }

        /// <summary>
        /// Metodo : Obtiene el Tipo de Documento
        /// </summary>
        /// <param name="gru_emp">Código Grupo Empresarial</param>
        private void Fi_obt_gru(string gru_emp)
        {
            tb_nom_gru.Text = "...";

            // Valida que el grupo empresarial sea DISTINTO a vacio
            if (gru_emp.CompareTo("") == 0){
                tb_gru_emp.Focus();
                MessageBox.Show("El Grupo Empresarial DEBE ser distinto de Vacío", Titulo);
                return;
            }

            // Obtiene datos del grupo empresarial
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_con_cod(int.Parse(gru_emp));
            if (Tabla.Rows.Count > 0){
                tb_gru_emp.Text = Tabla.Rows[0]["va_gru_emp"].ToString().Trim();
                tb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
            }
        }

        /// <summary>
        /// Metodo : Buscar Grupo Empresarial
        /// </summary>
        private void Fi_bus_gru()
        {
            adp018_01 frm = new adp018_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                Fi_obt_gru(frm.tb_gru_emp.Text);
            }
        }


        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_cod_per.Text.Trim() == ""){
                tb_cod_per.Focus();
                return "DEBE proporcionar el Código de Persona";
            }

            if (tb_gru_emp.Text.Trim() == ""){
                tb_gru_emp.Focus();
                return "DEBE proporcionar el Código Grupo Empresarial";
            }

            // Valida que el campo Grupo Empresrial NO este vacio
            int.TryParse(tb_gru_emp.Text, out int gru_emp);
            if (gru_emp == 0){
                tb_cod_per.Focus();
                return "El Código Grupo Empresarial NO es valido";
            }
            
            // Verifica SI existe el registro de persona
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if(Tabla.Rows.Count == 0){
                return "No existe registrado la persona en la Base de Datos";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("N") == 0){
                tb_gru_emp.Focus();
                return "La Persona seleccionado se encuentra Deshabilitada";
            }

            // Verifica SI existe el registro de grupo empresarial
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_con_cod(int.Parse(tb_gru_emp.Text));
            if (Tabla.Rows.Count == 0){
                tb_gru_emp.Focus();
                return "No existe registrado el Grupo Empresarial en la Base de Datos";
            }

            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("N") == 0) {
                tb_gru_emp.Focus();
                return "El Grupo Empresarial seleccionado se encuentra Deshabilitado";
            }
           
            return "";
        }

        // Evento KeyPress : Grupo Empresarial
        private void tb_gru_emp_KeyPress(object sender, KeyPressEventArgs e){
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Validated : Grupo Empresarial
        private void tb_gru_emp_Validated(object sender, EventArgs e)
        {
            Fi_obt_gru(tb_gru_emp.Text);
        }

        // Evento Click: Button Grupo Empresarial
        private void bt_bus_gru_Click(object sender, EventArgs e)
        {
            Fi_bus_gru();
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
                    // Elimina registro en la BD.
                    o_adp012.Fe_eli_min(int.Parse(tb_cod_per.Text));
                    // Graba registro en la BD.
                    o_adp012.Fe_nue_reg(int.Parse(tb_cod_per.Text), int.Parse(tb_gru_emp.Text));                    
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
