using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads010 - Tipos de Imagen                              */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-09-2023         */
    /**********************************************************************/
    public partial class ads010_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias 
        ads010 o_ads010 = new ads010();
        DataTable Tabla = new DataTable();

        public ads010_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Campos
            Fi_lim_pia();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_tip.Text = string.Empty;
            tb_nom_tip.Text = string.Empty;
            cb_ide_tab.SelectedIndex = 0;
        }


        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo ID. Tipo Imagen NO este vacio
            if (tb_ide_tip.Text.Trim() == ""){
                tb_ide_tip.Focus();
                return "DEBE proporcionar el ID. Tipo de Imagen";
            }

            // Valida que la longitud del ID. Tipo Imagen sea MAYOR a 1 digitos
            if (tb_ide_tip.Text.Length < 2){
                tb_ide_tip.Focus();
                return "El ID. Tipo de Imagen DEBE tener dos digitos";
            }

            // Valida que el campo Descripcion NO este vacio
            if (tb_nom_tip.Text.Trim() == ""){
                tb_nom_tip.Focus();
                return "DEBE proporcionar la Descripción";
            }

            // Valida que no exista otro registro con el mismo ID
            Tabla = o_ads010.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Focus();
                return "YA existe un Tipo de Imagen con el mismo Código";
            }
            // Valida que no exista otro registro con el mismo nombre
            Tabla = o_ads010.Fe_con_nom(tb_nom_tip.Text.Trim(), tb_ide_tip.Text);
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
                    MessageBox.Show("Error: " + msg_val, Text, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){                   
                    if (cb_ide_tab.SelectedIndex == 0)
                        ide_tab = "adp002";
                    if (cb_ide_tab.SelectedIndex == 1)
                        ide_tab = "inv004";

                    // Graba el registro en la BD.
                    o_ads010.Fe_nue_tip(tb_ide_tip.Text, tb_nom_tip.Text, ide_tab);
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_tip.Text);
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    // Inicializa Campos
                    Fi_lim_pia();
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
