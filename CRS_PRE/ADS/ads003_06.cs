using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads003 - Definición de Documento                      */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 22-08-2022         */
    /**********************************************************************/
    public partial class ads003_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        DataTable Tabla = new DataTable();

        public ads003_06()
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
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_des_doc.Text = frm_dat.Rows[0]["va_des_doc"].ToString();            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_mod.Text = string.Empty;
            tb_nom_mod.Text = string.Empty;
            tb_ide_doc.Text = string.Empty;
            tb_nom_doc.Text = string.Empty;
            tb_des_doc.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }


        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ide_mod.Text.Trim() == "")
                return "DEBE proporcionar el Codigo del Módulo";

            // Valida que el campo código NO este vacio
            int.TryParse(tb_ide_mod.Text, out int ide_mod);
            if (ide_mod == 0)
                return "El Código del Módulo NO tiene formato valido";

            // Valida que el Módulo este registrado en el sistema
            Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
            if (Tabla.Rows.Count == 0)
                return "El Módulo NO se encuentra registrado";

            // Valida que el Documento este registrado en el sistema
            Tabla = o_ads003.Fe_con_doc(int.Parse(tb_ide_mod.Text), tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0)
                return "El Documento NO se encuentra registrado";

            // Valida que la Aplicacion NO este habilitado
            if (tb_est_ado.Text == "Habilitado")
                return "No se puede eliminar, el Documento se encuentra Habilitada";

            // Verifica SI existen Talonarios que hacen referencia al Documento            
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0)
                return "No se puede Eliminar. Existen " + Tabla.Rows.Count + " Talonarios que hacen referencia al Documento";
            

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
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Tipo de Atributo
                    o_ads003.Fe_eli_min(int.Parse(tb_ide_mod.Text), tb_ide_doc.Text);
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_doc.Text));
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
