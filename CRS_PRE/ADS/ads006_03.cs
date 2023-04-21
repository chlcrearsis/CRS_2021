using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads006 - Tipo de Usuario                              */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 10-04-2023         */
    /**********************************************************************/
    public partial class ads006_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads006 o_ads006 = new ads006();
        DataTable Tabla = new DataTable();

        public ads006_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_tus.Text = frm_dat.Rows[0]["va_ide_tus"].ToString();
            tb_nom_tus.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();
            tb_des_tus.Text = frm_dat.Rows[0]["va_des_tus"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_tus.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_tus.Text = string.Empty;
            tb_nom_tus.Text = string.Empty;
            tb_des_tus.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_nom_tus.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_tus.Text.Trim() == "")
                return "DEBE proporcionar el Código del Tipo de Usuario";            

            // Valida que el campo código NO este vacio
            int.TryParse(tb_ide_tus.Text, out int ide_tus);
            if (ide_tus == 0)
                return "El Código del Tipo de Usuario NO es válido";            

            // Valida que el campo Nombre NO este vacio
            if (tb_nom_tus.Text.Trim() == ""){
                tb_nom_tus.Focus();
                return "DEBE proporcionar el Nombre del Tipo de Usuario";
            }

            // Valida que el campo Nombre NO este vacio
            if (tb_des_tus.Text.Trim() == ""){
                tb_des_tus.Focus();
                return "DEBE proporcionar la Descripción del Tipo de Usuario";
            }            

            // Valida que el registro este en el sistema
            Tabla = o_ads006.Fe_con_tus(int.Parse(tb_ide_tus.Text));
            if (Tabla.Rows.Count == 0){
                return "El Tipo de Usuario NO se encuentra registrado";
            }

            // Valida que el modulo no esta deshabilitado
            if (tb_est_ado.Text.Trim() == "Deshabilitado"){
                return "El Módulo se encuentra Deshabilitado";
            }

            // Verifica SI existe otro registro con la misma Nombre
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_nom(tb_nom_tus.Text.Trim(), int.Parse(tb_ide_tus.Text));
            if (Tabla.Rows.Count > 0){
                tb_nom_tus.Focus();
                return "YA existe otro Tipo de Usuario con el mismo Nombre";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_des(tb_des_tus.Text.Trim(), int.Parse(tb_ide_tus.Text));
            if (Tabla.Rows.Count > 0){
                tb_des_tus.Focus();
                return "YA existe otra Tipo de Usuario con la misma Descripción";
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
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita Tipo de Atributo
                    o_ads006.Fe_edi_tar(int.Parse(tb_ide_tus.Text), tb_nom_tus.Text, tb_des_tus.Text);
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tus.Text));
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
