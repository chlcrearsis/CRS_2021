using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp014_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp014 o_adp014 = new adp014();
        adp004 o_adp004 = new adp004(); 
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Tipo de Documento";

        public adp014_03()
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
      
        // Función Valida datos proporcionado
        protected string Fi_val_dat()
        {
            if (tb_des_tip.Text.Trim()==""){
                tb_des_tip.Focus();
                return "DEBE proporcionar el nombre para el Tipo de Documento";
            }           

            // Verifica SI existe otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip(tb_ide_tip.Text.Trim());
            if (Tabla.Rows.Count == 0){
                return "EL Tipo de Documento NO se encuentra en la base de datos";
            }

            // Verifica SI existe otro registro con el mismo descripción
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_nom(tb_des_tip.Text.Trim(), tb_ide_tip.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_des_tip.Focus();
                return "YA existe otra Tipo de Documento con el misma descripción";
            }

            return "";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e){
            DialogResult msg_res;
                  string ext_doc;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    // Obtiene la bandera si usa la extensión documento
                    if (cb_ext_doc.Checked){
                        ext_doc = "S";
                    }else{
                        ext_doc = "N";
                    }
                    // Edita Tipo de Documento
                    o_adp014.Fe_edi_tar(tb_ide_tip.Text.Trim(), tb_des_tip.Text.Trim(), ext_doc);
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(tb_ide_tip.Text.Trim());
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e){
            cl_glo_frm.Cerrar(this);
        }       
    }
}
