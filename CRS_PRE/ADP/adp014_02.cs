using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp014 - Tipo de Documento                            */
    /*      Opción: Crea Registro                                         */
    /*       Autor: JEJR - Crearsis             Fecha: 15-09-2021         */
    /**********************************************************************/
    public partial class adp014_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias        
        adp014 o_adp014 = new adp014();
        DataTable Tabla = new DataTable();

        public adp014_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_ide_tip.Clear();
            tb_des_tip.Clear();
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {            
            tb_ide_tip.Text = "";
            tb_des_tip.Text = "";
            tb_des_tip.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_ide_tip.Text.Trim() == ""){
                tb_ide_tip.Focus();
                return "DEBE proporcionar el Id para el Tipo de Documento";
            }            

            // Valida que el campo Nombre del Tipo NO este vacio
            if (tb_des_tip.Text.Trim() == ""){
                tb_des_tip.Focus();
                return "DEBE proporcionar la Descripción para el Tipo de Documento";
            }         

            // Verifica SI existe otro registro con el mismo ID
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip(tb_ide_tip.Text.Trim());
            if(Tabla.Rows.Count > 0){
                tb_ide_tip.Focus();
                return "Ya existe otro Tipo de Documento con el mismo ID.";
            }

            // Verifica SI existe otro registro con el mismo descripción
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_nom(tb_des_tip.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_des_tip.Focus();
                return "YA existe otra Tipo de Documento con el misma descripción";
            }

            return "";
        }


        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
                  string ext_doc;
            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Text, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){                    
                    // Obtiene la bandera si usa la extensión documento
                    if (cb_ext_doc.Checked){
                        ext_doc = "S";
                    }else {
                        ext_doc = "N";
                    }
                    // Graba el registro en la BD.
                    o_adp014.Fe_nue_reg(tb_ide_tip.Text.Trim(), tb_des_tip.Text.Trim(), ext_doc);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex) {
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
