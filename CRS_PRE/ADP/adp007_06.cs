using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp007_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp007 o_adp007 = new adp007();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Elimina Definición de Rutas";

        public adp007_06()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_rut.Text = frm_dat.Rows[0]["va_ide_rut"].ToString().Trim();
            tb_nom_rut.Text = frm_dat.Rows[0]["va_nom_rut"].ToString().Trim();
            tb_nom_cor.Text = frm_dat.Rows[0]["va_nom_cor"].ToString().Trim();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Función: Valida Datos
        protected string Fi_val_dat()
        {            
            Tabla = o_adp007.Fe_con_rut(int.Parse(tb_ide_rut.Text));
            if (Tabla.Rows.Count == 0){
                return "La Definición de Rutas NO se encuentra en la base de datos";
            }

            if (tb_est_ado.Text.CompareTo("Habilitado") == 0) {
                return "La Definición de Rutas se encuentra Habilitado";
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
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    // Elimina Tipo de Atributo
                    o_adp007.Fe_eli_min(int.Parse(tb_ide_rut.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_rut.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
    
