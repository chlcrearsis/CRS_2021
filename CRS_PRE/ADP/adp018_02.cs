using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp018 - Grupo Empresarial                            */
    /*      Opción: Crea Registro                                         */
    /*       Autor: JEJR - Crearsis             Fecha: 30-08-2021         */
    /**********************************************************************/
    public partial class adp018_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias        
        adp018 o_adp018 = new adp018();
        DataTable Tabla = new DataTable();

        public adp018_02(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
            Fi_ban_fac();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_gru_emp.Text = string.Empty;
            tb_nom_gru.Text = string.Empty;
            tb_ruc_nit.Text = string.Empty;
            tb_nom_fac.Text = string.Empty;
            tb_dir_ent.Text = string.Empty;
            Fi_ini_pan();            
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {            
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_obt_ide();
            if (Tabla.Rows.Count > 0){
                tb_gru_emp.Text = Tabla.Rows[0]["va_gru_emp"].ToString();
            }else {
                tb_gru_emp.Text = "0";
            }            
            tb_nom_gru.Focus();
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
            tb_ruc_nit.ReadOnly = true;
            tb_nom_fac.ReadOnly = true;
            tb_dir_ent.ReadOnly = true;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_gru_emp.Text.Trim() == ""){
                tb_gru_emp.Focus();
                return "DEBE proporcionar el Código para el Grupo Empresarial";
            }

            int ide_rel;
            // Valida que el campo código NO este vacio
            int.TryParse(tb_gru_emp.Text, out ide_rel);
            if (ide_rel == 0){
                tb_gru_emp.Focus();
                return "Código del Grupo Epresarial NO es valido";
            }

            // Valida que el campo Nombre NO este vacio
            if (tb_nom_gru.Text.Trim() == ""){
                tb_nom_gru.Focus();
                return "DEBE proporcionar el Nombre p/Grupo Empresarial";
            }                               

            // Verifica SI existe otro registro con el mismo Código
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_con_cod(int.Parse(tb_gru_emp.Text));
            if(Tabla.Rows.Count > 0){
                tb_gru_emp.Focus();
                return "Ya existe otro Grupo Empresarial con el mismo Código";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_nom_gru(tb_nom_gru.Text.Trim());
            if (Tabla.Rows.Count > 0){
                tb_nom_gru.Focus();
                return "YA existe otra Grupo Empresarial con el mismo nombre";
            }
           
            return "";
        }

        // Evento KeyPress : ID. Tipo Atributo
        private void tb_gru_emp_KeyPress(object sender, KeyPressEventArgs e){
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : RUC/NIT
        private void tb_ruc_nit_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento SelectionChangeCommitted : Datos de Facturación
        private void cb_ban_fac_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_ban_fac.Items.Count > 0) {
                tb_ruc_nit.Text = string.Empty;
                tb_nom_fac.Text = string.Empty;
                tb_dir_ent.Text = string.Empty;
                if (cb_ban_fac.SelectedValue.ToString() == "0")
                {
                    tb_ruc_nit.ReadOnly = true;
                    tb_nom_fac.ReadOnly = true;
                    tb_dir_ent.ReadOnly = true;
                }
                else {
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
                // Valida los datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Text, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Graba Registro
                    long ruc_nit = 0;
                    if (tb_ruc_nit.Text != "") { 
                        ruc_nit = long.Parse(tb_ruc_nit.Text);
                    }
                    o_adp018.Fe_nue_reg(int.Parse(tb_gru_emp.Text), tb_nom_gru.Text.Trim(), int.Parse(cb_ban_fac.SelectedValue.ToString()), tb_nom_fac.Text.Trim(), ruc_nit, tb_dir_ent.Text.Trim());
                    frm_pad.Fe_act_frm(int.Parse(tb_gru_emp.Text));
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
