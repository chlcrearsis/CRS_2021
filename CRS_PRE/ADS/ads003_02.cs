using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads003 - Definición de Documento                      */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-08-2022         */
    /**********************************************************************/
    public partial class ads003_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();        
        DataTable Tabla = new DataTable();

        public ads003_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            Fi_lim_pia();
            tb_ide_mod.Text = "0";
            tb_nom_mod.Text = "...";

        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {            
            tb_ide_doc.Text = string.Empty;
            tb_nom_doc.Text = string.Empty;
            tb_des_doc.Text = string.Empty;
            tb_ide_mod.Focus();
        }

        // Funcion: Buscar Módulo
        private void Fi_bus_mod()
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_mod.Text = frm.tb_ide_mod.Text;
                Fi_obt_mod();
            }
        }

        /// <summary>
        /// Obtiene datos del Módulo
        /// </summary>
        private void Fi_obt_mod()
        {            
            // Obtiene y desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0){
                tb_nom_mod.Clear();
            }else{
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
                tb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }            
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Módulo NO este vacio
            if (tb_ide_mod.Text.Trim() == ""){
                tb_ide_mod.Focus();
                return "DEBE proporcionar el ID. Módulo";
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim())){
                tb_ide_mod.Focus();
                return "El ID. Módulo NO es valido";
            }

            // Valida que el campo ID. Documento NO este vacio
            if (tb_ide_doc.Text.Trim() == ""){
                tb_ide_doc.Focus();
                return "DEBE proporcionar el ID. Documento";
            }

            // Valida que el campo Nombre del Documento NO este vacio
            if (tb_nom_doc.Text.Trim() == ""){
                tb_nom_doc.Focus();
                return "DEBE proporcionar el Nombre del Documento";
            }

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0){
                tb_ide_mod.Focus();
                return "El Módulo seleccionado NO se encuentra registrado";
            }

            // Verifica SI el Módulo se encuentra habilitado
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N"){
                tb_ide_mod.Focus();
                return "El Módulo seleccionado se encuentra Deshabilitado";
            }

            // Verifica SI existe otro registro con el mismo ID. de Aplicación
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count > 0){
                tb_ide_mod.Focus();
                return "Ya existe otro Documento con los mismo ID. Documento";
            }

            // Verifica SI existe otro registro con el mismo Nombre de Aplicación
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_nom(tb_nom_doc.Text);
            if (Tabla.Rows.Count > 0){
                tb_ide_mod.Focus();
                return "Ya existe otro Documento con los mismo Nombre Documento";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_doc.Text = tb_ide_doc.Text.ToString().Replace("'", "");
            tb_nom_doc.Text = tb_nom_doc.Text.ToString().Replace("'", "");
            tb_des_doc.Text = tb_des_doc.Text.ToString().Replace("'", "");

            return "OK";
        }

        // Evento Validated : ID. Módulo
        private void tb_ide_mod_Validated(object sender, EventArgs e)
        {
            Fi_obt_mod();
        }

        // Evento KeyPress : ID. Módulo
        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown : ID. Módulo
        private void Tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Modulo
                Fi_bus_mod();
            }
        }

        private void tb_nom_doc_Leave(object sender, EventArgs e)
        {
            if (tb_nom_doc.Text.Trim().CompareTo("") != 0 &&
                tb_des_doc.Text.Trim().CompareTo("") == 0) {
                tb_des_doc.Text = tb_nom_doc.Text.Trim();                
            }
        }

        private void bt_bus_mod_Click(object sender, EventArgs e)
        {
            // Abre la ventana Busca Modulo
            Fi_bus_mod();
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    //Registrar 
                    o_ads003.Fe_nue_reg(int.Parse(tb_ide_mod.Text), tb_ide_doc.Text.Trim(), tb_nom_doc.Text.Trim(), tb_des_doc.Text.Trim());
                    frm_pad.Fe_act_frm(tb_ide_doc.Text.Trim());
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
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
