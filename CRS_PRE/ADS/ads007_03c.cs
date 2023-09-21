using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007b - Usuario                                     */
    /*      Opción: Inicializa Contraseña                                 */
    /*       Autor: JEJR - Crearsis             Fecha: 01-08-2023         */
    /**********************************************************************/
    public partial class ads007_03c : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads007 o_ads007 = new ads007();
        ads013 o_ads013 = new ads013();
        DataTable Tabla = new DataTable();

        public ads007_03c()
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

            // Despliega la Clave por Defecto
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 1);
            if (Tabla.Rows.Count > 0)
                tb_cla_def.Text = Tabla.Rows[0]["va_glo_car"].ToString().Trim();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_usr.Text = string.Empty;            
            tb_nom_usr.Text = string.Empty;
            tb_cla_def.Text = string.Empty;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
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
                return "No se puede inicializar la contraseña. El Usuario está Deshabilitado";

            // Verifica si esta definido la contraseña por defecto
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 1);
            if (Tabla.Rows.Count == 0)
                return "La contraseña por defecto NO está definida en el sistema";

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
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de Inicializar la Contraseña del Usuario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita el registro
                    o_ads007.Fe_ini_con(tb_ide_usr.Text.Trim());
                    // Actualiza el Formulario Principal
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
