using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp014 - Tipo de Documento                            */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 15-09-2021         */
    /**********************************************************************/
    public partial class adp014_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp002 o_adp002 = new adp002();
        adp014 o_adp014 = new adp014();
        adp004 o_adp004 = new adp004();
        DataTable Tabla = new DataTable();

        public adp014_06()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString().Trim();
            tb_des_tip.Text = frm_dat.Rows[0]["va_des_tip"].ToString().Trim();

            if (frm_dat.Rows[0]["va_ext_doc"].ToString() == "S")
                cb_ext_doc.Checked = true;
            else
                cb_ext_doc.Checked = false;

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Función: Valida Datos
        protected string Fi_val_dat()
        {
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count == 0){
                return "EL Tipo de Documento NO se encuentra en la base de datos";
            }

            if (tb_est_ado.Text.CompareTo("Habilitado") == 0) {
                return "EL Tipo de Documento se encuentra Habilitado";
            }

            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count > 0){
                return "Existen '" + Tabla.Rows.Count + "' registro de Persona que dependen del Tipo de Documento";
            }

            return "";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    // Elimina Tipo de Documento
                    o_adp014.Fe_eli_min(tb_ide_tip.Text.Trim());
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(tb_ide_tip.Text.Trim());
                    cl_glo_frm.Cerrar(this);
                }
            }catch (Exception ex){
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
    
