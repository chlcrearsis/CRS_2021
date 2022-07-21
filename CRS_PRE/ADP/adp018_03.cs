using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp018_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp018 o_adp018 = new adp018();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Grupo Empresarial";

        public adp018_03(){
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos en Pantalla
            Fi_lim_pia();
            Fi_ban_fac();

            // Despliega Datos
            tb_gru_emp.Text = frm_dat.Rows[0]["va_gru_emp"].ToString();
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();          
            tb_nom_fac.Text = frm_dat.Rows[0]["va_nom_fac"].ToString();            
            tb_dir_ent.Text = frm_dat.Rows[0]["va_dir_ent"].ToString();

            if (frm_dat.Rows[0]["va_ban_fac"].ToString() == "0") { 
                cb_ban_fac.Text = "Registro Cliente";
                tb_ruc_nit.ReadOnly = true;
                tb_nom_fac.ReadOnly = true;
                tb_dir_ent.ReadOnly = true;
            }else{ 
                cb_ban_fac.Text = "Grupo Empresarial";
                tb_ruc_nit.ReadOnly = false;
                tb_nom_fac.ReadOnly = false;
                tb_dir_ent.ReadOnly = false;
            }

            if (frm_dat.Rows[0]["va_ruc_nit"].ToString().CompareTo("0") != 0)
                tb_ruc_nit.Text = frm_dat.Rows[0]["va_ruc_nit"].ToString();

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

        // Obtiene las Bandera de Facturación
        private void Fi_ban_fac()
        {
            cb_ban_fac.DataSource = null;
            // Crea la Tabla Dinamica
            Tabla = new DataTable();
            Tabla.Columns.Add("va_ide_ban");
            Tabla.Columns.Add("va_nom_ban");
            // Adiciona los Items
            Tabla.Rows.Add("0", "Registro Cliente");
            Tabla.Rows.Add("1", "Grupo Empresarial");
            // Carga los Item
            cb_ban_fac.DataSource = Tabla;
            cb_ban_fac.DisplayMember = "va_nom_ban";
            cb_ban_fac.ValueMember = "va_ide_ban";
            cb_ban_fac.SelectedValue = int.Parse(Tabla.Rows[0]["va_ide_ban"].ToString());
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

            // Valida que el campo Nombre NO este vacio
            if (tb_nom_gru.Text.Trim() == ""){
                tb_nom_gru.Focus();
                return "DEBE proporcionar el Nombre p/Grupo Empresarial";
            }

            if (cb_ban_fac.SelectedValue.ToString() == "1"){
                // Valida que el campo RUC/NIT NO este vacio
                if (tb_ruc_nit.Text.Trim() == ""){
                    tb_ruc_nit.Focus();
                    return "DEBE proporcionar el RUC/NIT a Facturar";
                }
                // Valida que el campo Nombre a Facturar NO este vacio
                if (tb_nom_fac.Text.Trim() == ""){
                    tb_nom_fac.Focus();
                    return "DEBE proporcionar el Nombre a Facturar";
                }
            }
            
            // Verifica SI existe el registro en la base de datos
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_con_cod(int.Parse(tb_gru_emp.Text));
            if (Tabla.Rows.Count == 0){
                tb_gru_emp.Focus();
                return "NO Existe el Grupo Empresarial registrado en el sistema";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_nom_gru(tb_nom_gru.Text.Trim(), int.Parse(tb_gru_emp.Text));
            if (Tabla.Rows.Count > 0){
                tb_nom_gru.Focus();
                return "YA existe otra Grupo Empresarial con el mismo nombre";
            }

            return "";
        }

        // Evento KeyPress : RUC/NIT
        private void tb_ruc_nit_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento SelectionChangeCommitted : Datos de Facturación
        private void cb_ban_fac_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_ban_fac.Items.Count > 0)
            {
                tb_ruc_nit.Text = string.Empty;
                tb_nom_fac.Text = string.Empty;
                tb_dir_ent.Text = string.Empty;
                if (cb_ban_fac.SelectedValue.ToString() == "0"){
                    tb_ruc_nit.ReadOnly = true;
                    tb_nom_fac.ReadOnly = true;
                    tb_dir_ent.ReadOnly = true;
                }else{
                    tb_ruc_nit.ReadOnly = false;
                    tb_nom_fac.ReadOnly = false;
                    tb_dir_ent.ReadOnly = false;
                }
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Titulo, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Graba el registro en la BD.
                    long ruc_nit = 0;
                    if (tb_ruc_nit.Text != ""){
                        ruc_nit = long.Parse(tb_ruc_nit.Text);
                    }
                    o_adp018.Fe_edi_tar(int.Parse(tb_gru_emp.Text), tb_nom_gru.Text.Trim(), int.Parse(cb_ban_fac.SelectedValue.ToString()), tb_nom_fac.Text.Trim(), ruc_nit, tb_dir_ent.Text.Trim());
                    frm_pad.Fe_act_frm(int.Parse(tb_gru_emp.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
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
