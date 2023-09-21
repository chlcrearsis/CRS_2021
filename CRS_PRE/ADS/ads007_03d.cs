using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007d - Usuario                                     */
    /*      Opción: Cambia Tipo de Usuario                                */
    /*       Autor: JEJR - Crearsis             Fecha: 03-08-2023         */
    /**********************************************************************/
    public partial class ads007_03d : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads006 o_ads006 = new ads006();
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();        

        public ads007_03d()
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

            // Despliega los Tipos de Usuario al Combobox
            cb_tip_usr.DataSource = o_ads006.Fe_lis_tus();
            cb_tip_usr.ValueMember = "va_ide_tus";
            cb_tip_usr.DisplayMember = "va_nom_tus";
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
                return "El Usuario se encuentra Deshabilitado";

            // Verifica que el Tipo de Usuario Nuevo este definido
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_tus(int.Parse(cb_tip_usr.SelectedValue.ToString()));
            if (Tabla.Rows.Count == 0)
                return "El Tipo de Usuario Nuevo NO está definido en el sistema (ads006)";

            // Valida que el Usuario NO esté deshabilitado
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("H") != 0)
                return "El Tipo de Usuario Nuevo se encuentra Deshabilitado";

            // Valida que el nuevo Tipo de Usuario NO sea el mismo que tiene
            if (tb_tip_usr.Text.Trim() == cb_tip_usr.Text.Trim())            
                return "El Tipo de Usuario seleecionado DEBE ser diferente al actual que tiene el Usuario.";

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
                msg_res = MessageBox.Show("Está seguro de cambiar el Tipo de Usuario del Usuario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    // Edita el registro
                    o_ads007.Fe_cam_tus(tb_ide_usr.Text.Trim(), int.Parse(cb_tip_usr.SelectedValue.ToString()));
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
