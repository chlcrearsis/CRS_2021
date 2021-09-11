using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp003_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp003 o_adp003 = new adp003();
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Tipo de Atributo";

        public adp003_04()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString().Trim();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString().Trim();
            tb_ide_atr.Text = frm_dat.Rows[0]["va_atr_def"].ToString().Trim();
            tb_nom_atr.Text = frm_dat.Rows[0]["va_nom_atr"].ToString().Trim();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Función: Valida Datos
        protected string Fi_val_dat(){
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(int.Parse(tb_ide_tip.Text));
            if (Tabla.Rows.Count == 0){
                return "EL Tipo de Atributo NO se encuentra en la base de datos";
            }

            return "";
        }


        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Tipo de Atributo?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Esta seguro de Habilitar el Tipo de Atributo?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK){
                    if (tb_est_ado.Text == "Habilitado")
                        o_adp003.Fe_hab_des(int.Parse(tb_ide_tip.Text), "N");
                    else
                        o_adp003.Fe_hab_des(int.Parse(tb_ide_tip.Text), "H");

                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualiza Ventana Buscar
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));
                    // Cierra la Ventana
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
            // Cierra la Ventana
            cl_glo_frm.Cerrar(this);
        }
    }
}
    
