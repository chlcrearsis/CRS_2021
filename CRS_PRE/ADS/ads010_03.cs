using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads010_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads010 o_ads010 = new ads010();
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Tipo de Imagen";

        public ads010_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString();
            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";

            switch (frm_dat.Rows[0]["va_ide_tab"].ToString()) {
                case "adp002":
                    cb_ide_tab.SelectedIndex = 0;
                    break;
                case "inv004":
                    cb_ide_tab.SelectedIndex = 1;
                    break;
            }

            tb_nom_tip.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            if (tb_ide_tip.Text.Trim() == "")
            {
                tb_ide_tip.Focus();
                return "DEBE proporcionar el ID. Tipo de Imagen";
            }

            if (tb_ide_tip.Text.Length < 2)
            {
                tb_ide_tip.Focus();
                return "El ID. Tipo de Imagen DEBE tener dos digitos";
            }

            if (tb_nom_tip.Text.Trim() == "")
            {
                tb_nom_tip.Focus();
                return "DEBE proporcionar la Descripción";
            }

            // Valida que no exista otro registro con el mismo ID
            Tabla = o_ads010.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count == 0){
                tb_ide_tip.Focus();
                return "No Existe ningún Tipo de Imagen con ese ID.";
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
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    string ide_tab = "";

                    if (cb_ide_tab.SelectedIndex == 0)
                        ide_tab = "adp002";
                    if (cb_ide_tab.SelectedIndex == 1)
                        ide_tab = "inv004";

                    // Edita Tipo de Atributo
                    o_ads010.Fe_edi_tip(tb_ide_tip.Text, tb_nom_tip.Text.Trim(), ide_tab);
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(tb_ide_tip.Text);
                    cl_glo_frm.Cerrar(this);
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
