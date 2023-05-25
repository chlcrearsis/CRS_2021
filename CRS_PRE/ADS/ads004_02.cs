using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonario                                    */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 26-08-2022         */
    /**********************************************************************/
    public partial class ads004_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();        
        DataTable Tabla = new DataTable();

        public ads004_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();
            // Inicializa Campos
            tb_ide_doc.Text = string.Empty;
            tb_nom_doc.Text = string.Empty;
            tb_for_mat.Text = "0";
            tb_nro_cop.Text = "0";
            tb_fir_ma1.Text = "Elaborado por";
            tb_fir_ma2.Text = "Revisado por";
            tb_fir_ma3.Text = "Aprobado por";
            tb_fir_ma4.Text = "";
            cb_tip_tal.SelectedIndex = 0;
            cb_for_log.SelectedIndex = 0;
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {            
            tb_nro_tal.Text = string.Empty;
            tb_nom_tal.Text = string.Empty;            
            tb_nro_tal.Focus();
        }

        // Funcion: Buscar Documento
        private void Fi_bus_doc()
        {
            ads003_01 frm = new ads003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_ide_doc.Text = frm.tb_ide_doc.Text;
                Fi_obt_doc();
            }
        }

        /// <summary>
        /// Obtiene datos del Documento
        /// </summary>
        private void Fi_obt_doc()
        {
            // Obtiene y desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0){
                tb_nom_doc.Clear();
            }else{
                tb_ide_doc.Text = Tabla.Rows[0]["va_ide_doc"].ToString();
                tb_nom_doc.Text = Tabla.Rows[0]["va_nom_doc"].ToString();
            }
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Documento NO este vacio
            if (tb_ide_doc.Text.Trim() == ""){
                tb_ide_doc.Focus();
                return "DEBE proporcionar el ID. Documento";
            }

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0){
                tb_ide_doc.Focus();
                return "El Documento seleccionado NO se encuentra registrado";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N"){
                tb_ide_doc.Focus();
                return "El Documento seleccionado se encuentra Deshabilitado";
            }

            // Valida que el campo Nro. Talonario
            if (tb_nro_tal.Text.Trim() == ""){
                tb_nro_tal.Focus();
                return "DEBE proporcionar el Nro. Talonario";
            }

            // Valida que el campo código sea un valor válido
            int.TryParse(tb_nro_tal.Text, out int nro_tal);
            if (nro_tal < 0){
                tb_nro_tal.Focus();
                return "El Nro. Talonario NO es valido";
            }

            // Valida que el campo Nombre Talonario
            if (tb_nom_tal.Text.Trim() == ""){
                tb_nom_tal.Focus();
                return "DEBE proporcionar el Nombre del Talonario";
            }

            // Verifica SI el Talonario se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count > 0){
                tb_nro_tal.Focus();
                return "El Talonario que desea crear ya se encuentra registrado " + tb_ide_doc.Text + " : " + tb_nro_tal.Text;
            }

            // Valida que el campo Formato de Impresión no este en blanco
            if (tb_for_mat.Text.Trim() == ""){
                tb_for_mat.Focus();
                return "DEBE proporcionar el Formato de Impresion";
            }

            // Valida que el campo Formato de Impresión sea un valor válido
            int.TryParse(tb_for_mat.Text, out int for_mat);
            if (for_mat < 0){
                tb_for_mat.Focus();
                return "El Nro. de Formato de Impresion DEBE ser numérico";
            }

            // Valida que el campo Nro. de Copias no este en blanco
            if (tb_nro_cop.Text.Trim() == ""){
                tb_nro_cop.Focus();
                return "DEBE proporcionar el Nro. de Copia(s)";
            }

            // Valida que el campo Nro. de Copias sea un valor válido
            int.TryParse(tb_nro_cop.Text, out int nro_cop);
            if (nro_cop < 0)
            {
                tb_nro_cop.Focus();
                return "El Nro. de Copia(s) DEBE ser numérico";
            }

            return "OK";
        }

        // Evento KeyDown : ID. Documento
        private void tb_ide_doc_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ABAJO
            if (e.KeyData == Keys.Down)
            {
                // Abre la ventana Busca Documento
                Fi_bus_doc();
            }
        }

        // Evento Validated : ID. Documento
        private void tb_ide_doc_Validated(object sender, EventArgs e)
        {
            Fi_obt_doc();
        }

        // Evento Click : Buscar Documento
        private void bt_bus_doc_Click(object sender, EventArgs e)
        {
            Fi_bus_doc();
        }

        // Evento KeyPress : Nro. Talonario
        private void tb_nro_tal_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : Formato de Impresion
        private void tb_for_mat_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : Nro. de Copias
        private void tb_nro_cop_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Click : Aceptar
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
                    o_ads004.Fe_nue_reg(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text), tb_nom_tal.Text, 0, cb_tip_tal.SelectedIndex, int.Parse(tb_for_mat.Text), int.Parse(tb_nro_cop.Text),
                                        tb_fir_ma1.Text, tb_fir_ma2.Text, tb_fir_ma3.Text, tb_fir_ma4.Text, cb_for_log.SelectedIndex);
                    frm_pad.Fe_act_frm(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click : Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
