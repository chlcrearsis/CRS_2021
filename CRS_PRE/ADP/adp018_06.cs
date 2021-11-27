using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp018_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp012 o_adp012 = new adp012();
        adp018 o_adp018 = new adp018();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Elimina Grupo Empresarial";

        public adp018_06(){
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos en Pantalla
            Fi_lim_pia();

            // Despliega Datos
            tb_gru_emp.Text = frm_dat.Rows[0]["va_gru_emp"].ToString();
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();
            tb_nom_fac.Text = frm_dat.Rows[0]["va_nom_fac"].ToString();
            tb_dir_ent.Text = frm_dat.Rows[0]["va_dir_ent"].ToString();

            if (frm_dat.Rows[0]["va_ruc_nit"].ToString().CompareTo("0") != 0)
                tb_ruc_nit.Text = frm_dat.Rows[0]["va_ruc_nit"].ToString();

            if (frm_dat.Rows[0]["va_ide_ban"].ToString() == "0")
                tb_ban_fac.Text = "Cliente";
            else
                tb_ban_fac.Text = "Grupo Empresarial";

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_gru.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_gru_emp.Text = string.Empty;
            tb_nom_gru.Text = string.Empty;
            tb_ruc_nit.Text = string.Empty;
            tb_nom_fac.Text = string.Empty;
            tb_dir_ent.Text = string.Empty;
        }       

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            if (tb_gru_emp.Text.Trim() == "")
            {
                tb_gru_emp.Focus();
                return "DEBE proporcionar el Código para el Grupo Empresarial";
            }

            int ide_rel;
            // Valida que el campo código NO este vacio
            int.TryParse(tb_gru_emp.Text, out ide_rel);
            if (ide_rel == 0)
            {
                tb_gru_emp.Focus();
                return "Código del Grupo Epresarial NO es valido";
            }           

            // Verifica SI existe el registro en la base de datos
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_con_cod(int.Parse(tb_gru_emp.Text));
            if (Tabla.Rows.Count == 0){
                tb_gru_emp.Focus();
                return "NO Existe el Grupo Empresarial registrado en el sistema";
            }

            // Verifica Cuantas Persona estan asociadas al Grupo Empresarial
            Tabla = new DataTable();
            Tabla = o_adp012.Fe_con_gru(int.Parse(tb_gru_emp.Text));
            if (Tabla.Rows.Count > 0){
                DialogResult res;
                res = MessageBox.Show("Existe Persona asignada al Grupo Empresarial, desea registrar de todos modos ?", Titulo, MessageBoxButtons.YesNo);
                if (res == DialogResult.No){
                    return "Revise las persona asociadas al Grupo Empresarial";
                }
            }

            return "";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {
                // Valida los datos
                string msg_val = Fi_val_dat();
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Registro
                    o_adp018.Fe_eli_min(int.Parse(tb_gru_emp.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_gru_emp.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
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
