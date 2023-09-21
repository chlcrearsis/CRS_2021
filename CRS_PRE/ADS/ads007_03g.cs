using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Inicializa PIN de Usuario                             */
    /*       Autor: JEJR - Crearsis             Fecha: 04-08-2023         */
    /**********************************************************************/
    public partial class ads007_03g : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads007 o_ads007 = new ads007();
        ads017 o_ads017 = new ads017();
        DataTable Tabla = new DataTable();
        private string vp_usr_reg = ""; // ID. Usuario Registro

        public ads007_03g()
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
            if (Tabla.Rows.Count > 0){
                tb_fec_reg.Text = Tabla.Rows[0]["va_fec_reg"].ToString().Trim();
                tb_fec_exp.Text = Tabla.Rows[0]["va_fec_exp"].ToString().Trim();
                     vp_usr_reg = Tabla.Rows[0]["va_usr_reg"].ToString().Trim();
            }

            // Obtiene el Ult. Usuario que registro la operacion
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(vp_usr_reg);
            if (Tabla.Rows.Count > 0) {
                tb_usr_reg.Text = Tabla.Rows[0]["va_ide_usr"].ToString().Trim() + " - (" +
                                  Tabla.Rows[0]["va_nom_usr"].ToString().Trim() + ")";
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_usr.Text = string.Empty;
            tb_nom_usr.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_usr_reg.Text = string.Empty;
            tb_fec_reg.Text = string.Empty;
            tb_fec_exp.Text = string.Empty;
        }

        // Valida los datos proporcionados
        private string Fi_val_dat()
        {          
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
           

            // Valida que el PIN Actual sea el correcto
            Tabla = new DataTable();
            Tabla = o_ads017.Fe_con_pin(tb_ide_usr.Text);
            if (Tabla.Rows.Count == 0)
                return "El Usuario NO tiene PIN registrado.";
           
            return "OK";
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
                msg_res = MessageBox.Show("Está seguro de Inicializar el PIN del Usuario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita el registro
                    o_ads017.Fe_eli_min(tb_ide_usr.Text.Trim());
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
