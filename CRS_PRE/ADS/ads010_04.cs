using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads010_04 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads010 o_ads010 = new ads010();     
        DataTable Tabla = new DataTable();


        public ads010_04()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString();

            switch (frm_dat.Rows[0]["va_ide_tab"].ToString()){
                case "adp002":
                    tb_ide_tab.Text = "Persona";
                    break;
                case "inv004":
                    tb_ide_tab.Text = "Producto";
                    break;
            }

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";            
        }

        protected string Fi_val_dat()
        {
            if (tb_ide_tip.Text.Trim() == ""){
                tb_ide_tip.Focus();
                return "DEBE proporcionar el ID. Tipo de Imagen";
            }

            // Valida que no exista otro registro con el mismo ID
            Tabla = o_ads010.Fe_con_tip(tb_ide_tip.Text);
            if (Tabla.Rows.Count == 0)
            {
                tb_ide_tip.Focus();
                return "No Existe ningún Tipo de Imagen con ese ID.";
            }

            return "";
        }

        // Limpia Campos en Pantalla
        private void Fi_lim_pia()
        {          
            tb_ide_tip.Clear(); 
            tb_ide_tab.Clear();
            tb_nom_tip.Clear();
            tb_ide_tab.Clear();
        }
       
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {

            try
            {
                string msg_val = "";
                DialogResult msg_res;

                // funcion para validar datos
                msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Tipo de Imagen?", "Habilita/Deshabilita Tipo de Imagen", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Esta seguro de Habilitar el Tipo de Imagen?", "Habilita/Deshabilita Tipo de Imagen", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK)
                {
                    if (tb_est_ado.Text == "Habilitado")
                        o_ads010.Fe_hab_des(tb_ide_tip.Text, "N");
                    else
                        o_ads010.Fe_hab_des(tb_ide_tip.Text, "H");

                    MessageBox.Show("Los datos se grabaron correctamente", "Habilita/Deshabilita Tipo de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualiza ventana buscar
                    frm_pad.Fe_act_frm(tb_ide_tip.Text);

                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
