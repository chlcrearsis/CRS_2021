using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads001 - Tipo de Usuario                              */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 10-04-2023         */
    /**********************************************************************/
    public partial class ads006_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads006 o_ads006 = new ads006();
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();

        public ads006_06()
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
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_tus.Text = string.Empty;
            tb_nom_tus.Text = string.Empty;
            tb_des_tus.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_tus.Text.Trim() == "")
                return "DEBE proporcionar el ID. Tipo de Usuario";            

            // Valida que el campo código NO este vacio
            if (!cl_glo_bal.IsNumeric(tb_ide_tus.Text.Trim()))
                return "El ID Tipo de Usuario NO tiene formato valido";            

            // Valida que el registro este en el sistema
            Tabla = o_ads006.Fe_con_tus(int.Parse(tb_ide_tus.Text));
            if (Tabla.Rows.Count == 0)
                return "El Tipo de Usuario NO se encuentra registrado";

            // Verifica SI el estado se encuentra Habilitado
            if (tb_est_ado.Text == "Habilitado")            
                return "El Tipo de Usuario se encuentra Habilitado";
            

            // Valida que NO este registrado ningun Usuario al Tipo de Usuario
            Tabla = o_ads007.Fe_con_tus(int.Parse(tb_ide_tus.Text), "T");
            if (Tabla.Rows.Count == 0)
                return "Hay " + Tabla.Rows.Count + " Usuarios relacionadas con el Tipo de Usuario " + tb_nom_tus.Text;


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
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar el registro?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina registro
                    o_ads006.Fe_eli_min(int.Parse(tb_ide_tus.Text));
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
