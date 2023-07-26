using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonario                                    */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 26-08-2022         */
    /**********************************************************************/
    public partial class ads004_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ctb007 o_ctb007 = new ctb007();
        DataTable Tabla = new DataTable();

        public ads004_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            lb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();            
            tb_for_mat.Text = frm_dat.Rows[0]["va_for_mat"].ToString();
            tb_nro_cop.Text = frm_dat.Rows[0]["va_nro_cop"].ToString();
            tb_nro_aut.Text = frm_dat.Rows[0]["va_nro_aut"].ToString();            
            tb_fir_ma1.Text = frm_dat.Rows[0]["va_fir_ma1"].ToString();
            tb_fir_ma2.Text = frm_dat.Rows[0]["va_fir_ma2"].ToString();
            tb_fir_ma3.Text = frm_dat.Rows[0]["va_fir_ma3"].ToString();
            tb_fir_ma4.Text = frm_dat.Rows[0]["va_fir_ma4"].ToString();
            tb_obs_uno.Text = frm_dat.Rows[0]["va_obs_uno"].ToString();
            tb_obs_dos.Text = frm_dat.Rows[0]["va_obs_dos"].ToString();
            cb_tip_tal.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_tal"].ToString());
            cb_for_log.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_for_log"].ToString());
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }


        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_doc.Text = string.Empty;
            lb_nom_doc.Text = string.Empty;
            tb_nro_tal.Text = string.Empty;
            tb_nom_tal.Text = string.Empty;
            tb_for_mat.Text = string.Empty;
            tb_nro_cop.Text = string.Empty;
            tb_nro_aut.Text = string.Empty;
            tb_fir_ma1.Text = string.Empty;
            tb_fir_ma2.Text = string.Empty;
            tb_fir_ma3.Text = string.Empty;
            tb_fir_ma4.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_nom_tal.Focus();
        }

        // Funcion: Buscar Autorización
        private void Fi_bus_aut()
        {
            ctb007_01 frm = new ctb007_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_nro_aut.Text = frm.tb_sel_ecc.Text;
                Fi_obt_aut();
            }
        }

        /// <summary>
        /// Obtiene datos de la Autorización
        /// </summary>
        private void Fi_obt_aut()
        {
            // Obtiene y desplega datos de la Dosificacion
            Tabla = new DataTable();
            Tabla = o_ctb007.Fe_con_sul(long.Parse(tb_nro_aut.Text));
            if (Tabla.Rows.Count == 0){
                tb_nro_aut.Clear();
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
            if (!cl_glo_bal.IsNumeric(tb_nro_tal.Text.Trim())){
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
            if (Tabla.Rows.Count == 0){
                tb_nro_tal.Focus();
                return "El Talonario que desea modificar NO se encuentra registrado " + tb_ide_doc.Text + " : " + tb_nro_tal.Text;
            }

            // Valida que el campo Formato de Impresión no este en blanco
            if (tb_for_mat.Text.Trim() == ""){
                tb_for_mat.Focus();
                return "DEBE proporcionar el Formato de Impresion";
            }

            // Valida que el campo Formato de Impresión sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_for_mat.Text.Trim())){
                tb_for_mat.Focus();
                return "El Nro. de Formato de Impresion DEBE ser numérico";
            }

            // Valida que el campo Nro. de Copias no este en blanco
            if (tb_nro_cop.Text.Trim() == ""){
                tb_nro_cop.Focus();
                return "DEBE proporcionar el Nro. de Copia(s)";
            }

            // Valida que el campo Nro. de Copias sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_nro_cop.Text.Trim())){
                tb_nro_cop.Focus();
                return "El Nro. de Copia(s) DEBE ser numérico";
            }

            // Valida el Nro. de Autorización se encuentre registrado
            if (tb_nro_aut.Text != "0") {
                Tabla = new DataTable();
                Tabla = o_ctb007.Fe_con_sul(long.Parse(tb_nro_aut.Text));
                if (Tabla.Rows.Count == 0) {
                    tb_nro_tal.Focus();
                    return "El Nro. de Autorización " + tb_nro_aut.Text + " NO se encuentra registrado";
                }
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_doc.Text = tb_ide_doc.Text.ToString().Replace("'", "");
            tb_nro_tal.Text = tb_nro_tal.Text.ToString().Replace("'", "");
            tb_nom_tal.Text = tb_nom_tal.Text.ToString().Replace("'", "");
            tb_for_mat.Text = tb_for_mat.Text.ToString().Replace("'", "");
            tb_nro_cop.Text = tb_nro_cop.Text.ToString().Replace("'", "");
            tb_fir_ma1.Text = tb_fir_ma1.Text.ToString().Replace("'", "");
            tb_fir_ma2.Text = tb_fir_ma2.Text.ToString().Replace("'", "");
            tb_fir_ma3.Text = tb_fir_ma3.Text.ToString().Replace("'", "");
            tb_fir_ma4.Text = tb_fir_ma4.Text.ToString().Replace("'", "");
            tb_obs_uno.Text = tb_obs_uno.Text.ToString().Replace("'", "");
            tb_obs_dos.Text = tb_obs_dos.Text.ToString().Replace("'", "");

            return "OK";
        }

        private void bt_bus_aut_Click(object sender, EventArgs e)
        {
            Fi_bus_aut();
        }
       
        private void tb_nro_aut_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ABAJO
            if (e.KeyData == Keys.Down)
            {
                // Abre la ventana Busca Documento
                Fi_bus_aut();
            }
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

        // Evento KeyPress : Nro. de Autorización
        private void tb_nro_aut_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    // Edita Registra
                    o_ads004.Fe_edi_tar(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text), tb_nom_tal.Text, cb_tip_tal.SelectedIndex, int.Parse(tb_nro_aut.Text), 
                                        int.Parse(tb_for_mat.Text), int.Parse(tb_nro_cop.Text), tb_fir_ma1.Text, tb_fir_ma2.Text, 
                                        tb_fir_ma3.Text, tb_fir_ma4.Text, cb_for_log.SelectedIndex, tb_obs_uno.Text, tb_obs_dos.Text);
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
                    cl_glo_frm.Cerrar(this);
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
