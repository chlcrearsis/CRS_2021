using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Edita PIN de Usuario                                  */
    /*       Autor: JEJR - Crearsis             Fecha: 03-08-2023         */
    /**********************************************************************/
    public partial class ads007_03f : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads007 o_ads007 = new ads007();
        ads017 o_ads017 = new ads017();        
        DataTable Tabla = new DataTable();
        private int vp_tip_ope = 0;  // Tipo de Operacion (0=Nuevo; 1=Editar)

        public ads007_03f()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Informacion del Usuario
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();           
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";


            // Obtiene datos del PIN del Usuario
            Tabla = new DataTable();
            Tabla = o_ads017.Fe_con_pin(tb_ide_usr.Text);
            if (Tabla.Rows.Count > 0) {
                tb_fec_reg.Text = Tabla.Rows[0]["va_fec_reg"].ToString().Trim();
                tb_fec_exp.Text = Tabla.Rows[0]["va_fec_exp"].ToString().Trim();
            }else{
                tb_pin_act.Enabled = false;
                tb_fec_reg.Text = "01/01/1900 00:00";
                tb_fec_exp.Text = "01/01/1900 00:00";
            }

            // Establece datos por defecto
            tb_pas_usr.Text = "Contraseña";
            tb_pin_act.Text = "Contraseña";
            tb_pin_nue.Text = "Contraseña";
            tb_pin_rep.Text = "Contraseña";
            tb_exp_fec.Text = DateTime.Now.AddMonths(3).ToString();
            tb_pas_usr.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_usr.Text = string.Empty;
            tb_nom_usr.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_pas_usr.Text = string.Empty;
            tb_pin_act.Text = string.Empty;
            tb_fec_reg.Text = string.Empty;
            tb_fec_exp.Text = string.Empty;
            tb_pin_nue.Text = string.Empty;
            tb_pin_rep.Text = string.Empty;
            tb_exp_fec.Text = string.Empty;
        }


        // Valida los datos proporcionados
        private string Fi_val_dat()
        {
            vp_tip_ope = 0; // Nuevo

            // Valida que el ID. Usuario NO este vacio
            if (tb_ide_usr.Text.Trim() == "")
                return "DEBE proporcionar el ID. Usuario";

            // Verifica que el Usuario este definido
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count == 0)
                return "El Usuario NO está definido en el sistema (ads007)";

            // Valida que el Usuario NO esté deshabilitado
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("H") != 0)
                return "El Usuario se encuentra Deshabilitado";

            // Valida que la contraseña del usuario sea correcto
            if (tb_pas_usr.Text.Trim() == ""){
                tb_pas_usr.Focus();
                return "DEBE proporcionar su contraseña.";
            }

            // Valida que el Login del usuario sea correcto
            string msn_err = o_ads007.Fe_ing_sis(tb_ide_usr.Text.Trim(), tb_pas_usr.Text.Trim());
            if (msn_err != "OK"){
                tb_pas_usr.Focus();
                return msn_err;
            }

            // Valida que el PIN Actual sea el correcto
            Tabla = new DataTable();
            Tabla = o_ads017.Fe_con_pin(tb_ide_usr.Text);
            if (Tabla.Rows.Count > 0){
                vp_tip_ope = 1; // Editar
                if (tb_pin_act.Text.Trim() != Tabla.Rows[0]["va_pin_usr"].ToString()){
                    tb_pin_act.Focus();
                    return "El PIN actual proporcionado es incorrecto.";
                }
            }

            // Valida el PIN Actual que este definido
            if (tb_pin_nue.Text.Trim() == ""){
                tb_pin_nue.Focus();
                return "DEBE proporcionar el nuevo PIN.";
            }

            // Valida el PIN Actual tenga mas de 3 digitos
            if (tb_pin_nue.Text.Trim().Length <= 3){
                tb_pin_nue.Focus();
                return "El PIN Nuevo DEBE Contener al menos 4 digitos.";
            }

            // Valida que el PIN nuevo sea el mismo que el PIN repetido
            if (tb_pin_nue.Text.Trim() != tb_pin_rep.Text.Trim()) { 
                tb_pin_nue.Focus();
                return "La confirmación del PIN NO coincide con el nuevo PIN Proporcionado.";
            }

            // Valida que la fecha de expiracion sea correcta
            if (tb_exp_fec.Text.Length != 16) {
                tb_exp_fec.Focus();
                return "La Fecha y Hora de Expiración proporcionada NO es válida.";
            }
            if (!cl_glo_bal.IsDateTime(tb_exp_fec.Text.Substring(0,10))) {
                tb_exp_fec.Focus();
                return "La Fecha de Expiración proporcionada NO es válida.";
            }
            if (!cl_glo_bal.IsHourTime(tb_exp_fec.Text.Substring(11, 5))){
                tb_exp_fec.Focus();
                return "La Hora de Expiración proporcionada NO es válida.";
            }

            // Valida que la fecha de expiración sea MAYOR a la fecha actual
            if (DateTime.Parse(tb_exp_fec.Text) <= DateTime.Now){
                tb_exp_fec.Focus();
                return "La Fecha y Hora de Expiración DEBE ser MAYOR a la fecha actual.";
            }

            return "OK";
        }

        // Evento KeyPress: PIN Actual
        private void tb_pin_act_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress: PIN Nuev
        private void tb_pin_nue_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress: PIN Repetir
        private void tb_pin_rep_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Enter: Password Usuario
        private void tb_pas_usr_Enter(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text == "Contraseña")
                tb_pas_usr.Text = string.Empty;
        }

        // Evento Enter: PIN Actual
        private void tb_pin_act_Enter(object sender, EventArgs e)
        {
            if (tb_pin_act.Text == "Contraseña")
                tb_pin_act.Text = string.Empty;
        }

        // Evento Enter: PIN Nuevo
        private void tb_pin_nue_Enter(object sender, EventArgs e)
        {
            if (tb_pin_nue.Text == "Contraseña")
                tb_pin_nue.Text = string.Empty;
        }

        // Evento Enter: PIN Repetir
        private void tb_pin_rep_Enter(object sender, EventArgs e)
        {
            if (tb_pin_rep.Text == "Contraseña")
                tb_pin_rep.Text = string.Empty;
        }

        // Evento Validated: Password Usuario
        private void tb_pas_usr_Validated(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text.Trim() == "")
                tb_pas_usr.Text = "Contraseña";
        }

        // Evento Validated: PIN Actual
        private void tb_pin_act_Validated(object sender, EventArgs e)
        {
            if (tb_pin_act.Text.Trim() == "")
                tb_pin_act.Text = "Contraseña";
        }

        // Evento Validated: PIN Nuevo
        private void tb_pin_nue_Validated(object sender, EventArgs e)
        {
            if (tb_pin_nue.Text.Trim() == "")
                tb_pin_nue.Text = "Contraseña";
        }

        // Evento Validated: PIN Repetir
        private void tb_pin_rep_Validated(object sender, EventArgs e)
        {
            if (tb_pin_rep.Text.Trim() == "")
                tb_pin_rep.Text = "Contraseña";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {            
            DialogResult msg_res;
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de editar el PIN del Usuario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita el registro
                    if (vp_tip_ope == 0)
                        o_ads017.Fe_nue_reg(tb_ide_usr.Text.Trim(), int.Parse(tb_pin_nue.Text.Trim()), tb_exp_fec.Text.Trim(), cl_glo_bal.glo_ide_usr, SystemInformation.ComputerName);
                    else
                        o_ads017.Fe_edi_tar(tb_ide_usr.Text.Trim(), int.Parse(tb_pin_nue.Text.Trim()), tb_exp_fec.Text.Trim(), cl_glo_bal.glo_ide_usr, SystemInformation.ComputerName);
                    // Actualiza el Formulario Padre
                    frm_pad.Fe_act_frm(tb_ide_usr.Text.Trim());
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cierra Formulario
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
