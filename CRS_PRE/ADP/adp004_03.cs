using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp004_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        // Instancias
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();        
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Definición de Atributo";

        public adp004_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_tip.Text = frm_dat.Rows[0]["va_ide_tip"].ToString().Trim();
            tb_nom_tip.Text = frm_dat.Rows[0]["va_nom_tip"].ToString().Trim();
            tb_ide_atr.Text = frm_dat.Rows[0]["va_ide_atr"].ToString().Trim();
            tb_nom_atr.Text = frm_dat.Rows[0]["va_nom_atr"].ToString().Trim();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }


        // Función Valida datos proporcionado
        protected string Fi_val_dat()
        {
            if (tb_nom_tip.Text.Trim()==""){
                tb_nom_tip.Focus();
                return "DEBE proporcionar el nombre para el Atributo";
            }

            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(int.Parse(tb_ide_tip.Text));
            if (Tabla.Rows.Count == 0){
                return "El Tipo de Atributo NO se encuentra en la base de datos";
            }

            // Verifica SI existe otro registro con el mismo id
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_con_atr(int.Parse(tb_ide_tip.Text), int.Parse(tb_ide_atr.Text));
            if (Tabla.Rows.Count == 0){
                return "El Atributo NO se encuentra en la base de datos";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_con_nom(int.Parse(tb_ide_tip.Text), tb_nom_atr.Text.Trim(), int.Parse(tb_ide_atr.Text));
            if (Tabla.Rows.Count > 0){
                tb_nom_atr.Focus();
                return "YA existe otro Atributo con el mismo nombre";
            }

            return "";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e){
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita Tipo de Atributo
                    o_adp004.Fe_edi_tar(int.Parse(tb_ide_tip.Text), int.Parse(tb_ide_tip.Text), tb_nom_atr.Text);
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_tip.Text));
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
