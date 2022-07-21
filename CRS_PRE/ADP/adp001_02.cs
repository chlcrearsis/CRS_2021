using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp001 - Grupo Persona                                */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-07-2020         */
    /**********************************************************************/
    public partial class adp001_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;

        // Instancias        
        adp001 o_adp001 = new adp001();
        DataTable Tabla = new DataTable();
        string Titulo = "Nuevo Grupo de Persona";

        public adp001_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_gru.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_cod_gru.Text = string.Empty;
            tb_nom_gru.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_cod_gru.Text = Tabla.Rows[0]["va_cod_gru"].ToString();
            }else{
                tb_cod_gru.Text = "0";
            }            
            tb_nom_gru.Focus();
        }


        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            if (tb_cod_gru.Text.Trim() == ""){
                tb_cod_gru.Focus();
                return "DEBE proporcionar el Código Grupo Persona";
            }

            // Valida que el campo código NO este vacio
            int.TryParse(tb_cod_gru.Text, out int cod_gru);
            if (cod_gru == 0){
                tb_cod_gru.Focus();
                return "El Código Grupo Persona NO es valido";
            }

            // Valida que el campo Nombre del Grupo Persona NO este vacio
            if (tb_nom_gru.Text.Trim() == ""){
                tb_nom_gru.Focus();
                return "DEBE proporcionar el Nombre para el Grupo Persona";
            }
                       
            // Verifica SI existe otro registro con el mismo Código
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count > 0){
                tb_cod_gru.Focus();
                return "Ya existe otro Grupo Persona con el mismo Código";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_nom(tb_nom_gru.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_gru.Focus();
                return "YA existe otra Grupo Persona con el mismo nombre";
            }

            return "";
        }

        // Evento KeyPress : ID. Tipo Atributo
        private void tb_cod_gru_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            // funcion para validar datos
            string msg_val = Fi_val_dat();
            if (msg_val != ""){
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                // Graba Registro
                o_adp001.Fe_nue_reg(int.Parse(tb_cod_gru.Text), tb_nom_gru.Text);
                frm_pad.Fe_act_frm(int.Parse(tb_cod_gru.Text));
                MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                Fi_lim_pia();
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
