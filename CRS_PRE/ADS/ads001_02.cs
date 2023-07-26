using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads001 - Módulo del Sistema                           */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 18-08-2022         */
    /**********************************************************************/
    public partial class ads001_02 : Form
    {        
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias 
        ads001 o_ads001 = new ads001();
        DataTable Tabla = new DataTable();

        public ads001_02()
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
            tb_ide_mod.Text = string.Empty;
            tb_abr_mod.Text = string.Empty;
            tb_nom_mod.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            // Obtiene el ID. Correspondiente
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
            }else{
                tb_ide_mod.Text = "0";
            }
            // Establece el focus
            tb_abr_mod.Focus();
        }

        // Valida los datos proporcionados
        private string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == ""){
                tb_ide_mod.Focus();
                return "DEBE proporcionar el Código del Módulo";
            }

            // Valida que el campo código sea un valor válido
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim())){
                tb_ide_mod.Focus();
                return "El Código del Módulo NO es valido";
            }

            // Valida que el campo Abreviado del Módulo NO este vacio
            if (tb_abr_mod.Text.Trim() == ""){
                tb_abr_mod.Focus();
                return "DEBE proporcionar la Abreviacion del Módulo";
            }

            // Valida que el campo Nombre del Grupo Persona NO este vacio
            if (tb_nom_mod.Text.Trim() == ""){
                tb_nom_mod.Focus();
                return "DEBE proporcionar el Nombre del Módulo";
            }

            // Verifica SI existe otro registro con el mismo Código
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count > 0){
                tb_ide_mod.Focus();
                return "Ya existe otro Módulo con el mismo Código";
            }

            // Verifica SI existe otro registro con la misma abreviación
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_abr(tb_abr_mod.Text);
            if (Tabla.Rows.Count > 0){
                tb_abr_mod.Focus();
                return "Ya existe otro Módulo con la misma Abreviación";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_nom(tb_nom_mod.Text);
            if (Tabla.Rows.Count > 0){
                tb_nom_mod.Focus();
                return "Ya existe otro Módulo con la misma Nombre";
            }

            // Quita caracteres especiales de SQL-Trans
            tb_abr_mod.Text = tb_abr_mod.Text.Replace("'", "");
            tb_nom_mod.Text = tb_nom_mod.Text.Replace("'", "");

            return "OK";
        }        

        // Evento KeyPress : ID. Módulo
        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }        

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    // Graba registro
                    o_ads001.Fe_nue_reg(int.Parse(tb_ide_mod.Text), tb_nom_mod.Text.Trim(), tb_abr_mod.Text.Trim());
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_mod.Text));
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
