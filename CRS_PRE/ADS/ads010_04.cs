using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads010 - Tipos de Visita                              */
    /*      Opción: Habilita/Deshabilita Registro                         */
    /*       Autor: JEJR - Crearsis             Fecha: 22-09-2023         */
    /**********************************************************************/
    public partial class ads010_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads010 o_ads010 = new ads010();
        ads002 o_ads002 = new ads002();
        DataTable Tabla = new DataTable();

        public ads010_04()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString();
            switch (frm_dat.Rows[0]["va_ide_tab"].ToString()){
                case "adp002":
                    tb_ide_tab.Text = "Persona";
                    break;
                case "inv004":
                    tb_ide_tab.Text = "Producto";
                    break;
            }
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";            
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_tip.Text = string.Empty;
            tb_ide_tab.Text = string.Empty;
            tb_nom_tip.Text = string.Empty;
            tb_ide_tab.Text = string.Empty;
        }

        // Valida los datos proporcionado por pantalla
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Tipo Imagen NO este vacio
            if (tb_ide_tip.Text.Trim() == "")
                return "DEBE proporcionar el ID. Tipo de Imagen";            

            // Valida que no exista otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_ads010.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count == 0)
                return "No Existe ningún Tipo de Imagen con ese ID.";
            

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
                    msg_res = MessageBox.Show("Está seguro de Deshabilitar el registro?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Está seguro de Habilitar el registro?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK)
                {
                    // Habilita/Deshabilita el registro
                    if (tb_est_ado.Text == "Habilitado")
                        o_ads010.Fe_hab_des(tb_ide_tip.Text.Trim(), "N");
                    else
                        o_ads010.Fe_hab_des(tb_ide_tip.Text.Trim(), "H");
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_tip.Text.Trim());
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
