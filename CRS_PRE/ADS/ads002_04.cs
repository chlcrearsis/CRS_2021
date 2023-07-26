using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads002 - Aplicaciones del Sistema                     */
    /*      Opción: Habilita/Deshabilita Registro                         */
    /*       Autor: JEJR - Crearsis             Fecha: 20-04-2023         */
    /**********************************************************************/
    public partial class ads002_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads002 o_ads002 = new ads002();
        DataTable Tabla = new DataTable();

        public ads002_04()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            lb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_ide_apl.Text = frm_dat.Rows[0]["va_ide_apl"].ToString();
            tb_nom_apl.Text = frm_dat.Rows[0]["va_nom_apl"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_ide_apl.Text = string.Empty;
            tb_nom_apl.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == "")
                return "DEBE proporcionar el Código del Módulo";

            // Valida que el campo aplicacion NO este vacio
            if (tb_ide_apl.Text.Trim() == "")
                return "DEBE proporcionar el ID. de Aplicación";

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim()))
                return "El Código del Módulo NO es válido";

            // Verifica SI el Módulo se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo NO se encuentra registrado";

            // Verifica SI la Aplicacion se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_ads002.Fe_con_apl(int.Parse(tb_ide_mod.Text), tb_ide_apl.Text);
            if (Tabla.Rows.Count == 0)
                return "La Aplicación NO se encuentra registrado";

            // Verifica SI la aplicación a editar es reservado por el sistema
            if ((tb_ide_apl.Text.ToString().CompareTo("ads200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("inv200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("cmr200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("res200") == 0))
                return "No se puede modificar esta Aplicación, es reservado para el sistema";

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

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Está seguro de Deshabilitar la Aplicación?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Está seguro de Habilitar la Aplicación?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK)
                {
                    // Habilita/Deshabilita el registro
                    if (tb_est_ado.Text == "Habilitado")
                        o_ads002.Fe_hab_des(int.Parse(tb_ide_mod.Text), tb_ide_apl.Text, "N");
                    else
                        o_ads002.Fe_hab_des(int.Parse(tb_ide_mod.Text), tb_ide_apl.Text, "H");                    
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_apl.Text);
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
