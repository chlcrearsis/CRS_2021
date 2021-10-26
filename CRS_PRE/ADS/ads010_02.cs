using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads010_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads010 o_ads010 = new ads010();
        DataTable Tabla = new DataTable();
        string Titulo = "Nuevo Tipo de Imagen";

        public ads010_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            Fi_lim_pia();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_tip.Clear();
            tb_nom_tip.Clear();
            cb_ide_tab.SelectedIndex = 0;
            tb_ide_tip.Focus();
        }


        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            if (tb_ide_tip.Text.Trim() == ""){
                tb_ide_tip.Focus();
                return "DEBE proporcionar el ID. Tipo de Imagen";
            }

            if (tb_ide_tip.Text.Length < 2){
                tb_ide_tip.Focus();
                return "El ID. Tipo de Imagen DEBE tener dos digitos";
            }

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
            if (Tabla.Rows.Count > 0)
            {
                tb_ide_tip.Focus();
                return "YA existe un Tipo de Imagen con el misma descripción";
            }            
           
            return "";
        }              

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Titulo, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    string ide_tab = "";

                    if (cb_ide_tab.SelectedIndex == 0)
                        ide_tab = "adp002";
                    if (cb_ide_tab.SelectedIndex == 1)
                        ide_tab = "inv004";

                    // Graba el registro en la BD.
                    o_ads010.Fe_nue_tip(tb_ide_tip.Text, tb_nom_tip.Text, ide_tab);
                    frm_pad.Fe_act_frm(tb_ide_tip.Text);
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
