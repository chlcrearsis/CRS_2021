using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007e - Usuario                                     */
    /*      Opción: Restablece los Permisos del Usuario                   */
    /*       Autor: JEJR - Crearsis             Fecha: 03-08-2023         */
    /**********************************************************************/
    public partial class ads007_03e : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads006 o_ads006 = new ads006();
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();
        private int vp_ide_tus = 0;  // ID. Tipo de Usuario

        public ads007_03e()
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
            tb_tip_usr.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            // Obtiene el Tipo de Usuario
            vp_ide_tus = int.Parse(frm_dat.Rows[0]["va_ide_tus"].ToString());
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_usr.Text = string.Empty;
            tb_nom_usr.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_tip_usr.Text = string.Empty;
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

            // Verifica que el Tipo de Usuario Nuevo este definido
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_tus(vp_ide_tus);
            if (Tabla.Rows.Count == 0)
                return "El Tipo de Usuario NO está definido en el sistema (ads006)";

            // Valida que el Usuario NO esté deshabilitado
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("H") != 0)
                return "El Tipo de Usuario se encuentra Deshabilitado";

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
                msg_res = MessageBox.Show("Está seguro de restablecer los permisos del Usuario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita el registro
                    o_ads007.Fe_rei_per(tb_ide_usr.Text.Trim());
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
