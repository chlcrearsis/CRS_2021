using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads010 - Tipos de Imagen                              */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-09-2023         */
    /**********************************************************************/
    public partial class ads010_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads010 o_ads010 = new ads010();
        DataTable Tabla = new DataTable();

        public ads010_03()
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
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";

            switch (frm_dat.Rows[0]["va_ide_tab"].ToString()) {
                case "adp002":
                    cb_ide_tab.SelectedIndex = 0;
                    break;
                case "inv004":
                    cb_ide_tab.SelectedIndex = 1;
                    break;
            }

            tb_ide_tip.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_tip.Text = string.Empty;
            tb_nom_tip.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_ide_tip.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Tipo Visita NO este vacio
            if (tb_ide_tip.Text.Trim() == ""){
                tb_ide_tip.Focus();
                return "DEBE proporcionar el ID. Tipo de Imagen";
            }
            // Valida que el campo ID. Tipo Visita sea MAYOR a 1 dgitos
            if (tb_ide_tip.Text.Length < 2){
                tb_ide_tip.Focus();
                return "El ID. Tipo de Imagen DEBE tener dos digitos";
            }
            // Valida que el campo Descripción NO este vacio
            if (tb_nom_tip.Text.Trim() == ""){
                tb_nom_tip.Focus();
                return "DEBE proporcionar la Descripción";
            }

            // Valida que no exista otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_ads010.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count == 0){
                tb_ide_tip.Focus();
                return "No Existe ningún Tipo de Imagen con ese Código";
            }
            // Valida que no exista otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_ads010.Fe_con_nom(tb_nom_tip.Text.Trim(), tb_ide_tip.Text);
            Tabla = new DataTable();
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Focus();
                return "YA existe un Tipo de Imagen con el misma descripción";
            }

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
                string ide_tab = "";
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){                    
                    if (cb_ide_tab.SelectedIndex == 0)
                        ide_tab = "adp002";
                    if (cb_ide_tab.SelectedIndex == 1)
                        ide_tab = "inv004";

                    // Edita el registro
                    o_ads010.Fe_edi_tip(tb_ide_tip.Text, tb_nom_tip.Text.Trim(), ide_tab);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_tip.Text);
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
