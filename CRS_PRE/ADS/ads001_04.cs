using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads001 - Módulo del Sistema                           */
    /*      Opción: Habilita/Deshabilita Registro                         */
    /*       Autor: JEJR - Crearsis             Fecha: 20-04-2023         */
    /**********************************************************************/
    public partial class ads001_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads002 o_ads002 = new ads002();
        DataTable Tabla = new DataTable();

        public ads001_04()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_abr_mod.Text = frm_dat.Rows[0]["va_abr_mod"].ToString();
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";            
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            tb_nom_mod.Text = string.Empty;
            tb_abr_mod.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida Datos proporcionado en pantalla
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == "")
                return "DEBE proporcionar el Código del Módulo";            

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim()))
                return "El Código del Módulo NO es válido";            

            // Valida que el registro este en el sistema
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo no se encuentra registrado";            

            // Si el registro se va a deshabilitar, verifica que no exista ninguna aplicacion Habilitada
            if (tb_est_ado.Text == "Habilitado") {
                Tabla = new DataTable();
                Tabla = o_ads002.Fe_con_mod(int.Parse(tb_ide_mod.Text), "H");
                if (Tabla.Rows.Count > 0)
                    return "Existe " + Tabla.Rows.Count + " aplicaciones habilitadas, que depende de " + tb_nom_mod.Text;                
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
                        o_ads001.Fe_hab_des(int.Parse(tb_ide_mod.Text), "N");
                    else
                        o_ads001.Fe_hab_des(int.Parse(tb_ide_mod.Text), "H");
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_mod.Text));
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
