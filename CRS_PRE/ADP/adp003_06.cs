using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp003_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        DataTable Tabla = new DataTable();
        string Titulo = "Elimina Tipo de Atributo";

        public adp003_06()
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
        protected string Fi_val_dat()
        {            
            Tabla = o_adp003.Fe_con_tip(int.Parse(tb_ide_tip.Text));
            if (Tabla.Rows.Count == 0){
                return "EL Tipo de Atributo NO se encuentra en la base de datos";
            }

            if (tb_est_ado.Text.CompareTo("Habilitado") == 0) {
                return "EL Tipo de Atributo se encuentra Habilitado";
            }

            Tabla = o_adp004.Fe_lis_tip(int.Parse(tb_ide_tip.Text), "T");
            if (Tabla.Rows.Count > 0){
                return "Existen '" + Tabla.Rows.Count + "' registro en Definiciones de Atributos que dependen del Tipo de Atributo";
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
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    // Elimina Tipo de Atributo
                    o_adp003.Fe_eli_tip(int.Parse(tb_ide_tip.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
    
