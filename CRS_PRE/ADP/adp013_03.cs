using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp013_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp002 o_adp002 = new adp002();
        adp013 o_adp013 = new adp013();
        adp017 o_adp017 = new adp017();
        DataTable Tabla = new DataTable();
        General general = new General();
        string Titulo = "Edita Contacto Persona";

        public adp013_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los campos en pantalla
            Fi_lim_cam();

            // Despliega Datos de Parentesco
            Fi_obt_par(frm_dat.Rows[0]["va_sex_con"].ToString());

            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString().Trim();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString().Trim();
            tb_cod_con.Text = frm_dat.Rows[0]["va_cod_con"].ToString().Trim();
            tb_nom_bre.Text = frm_dat.Rows[0]["va_nom_bre"].ToString().Trim();
            tb_ape_pat.Text = frm_dat.Rows[0]["va_ape_pat"].ToString().Trim();
            tb_ape_mat.Text = frm_dat.Rows[0]["va_ape_mat"].ToString().Trim();
            tb_nro_cid.Text = frm_dat.Rows[0]["va_nro_cid"].ToString().Trim();
            cb_ext_doc.Text = frm_dat.Rows[0]["va_ext_doc"].ToString().Trim();
            cb_par_con.Text = frm_dat.Rows[0]["va_par_con"].ToString().Trim();
            tb_tel_per.Text = frm_dat.Rows[0]["va_tel_per"].ToString().Trim();
            tb_tel_cel.Text = frm_dat.Rows[0]["va_cel_ula"].ToString().Trim();
            tb_ema_ail.Text = frm_dat.Rows[0]["va_ema_ail"].ToString().Trim();
            tb_dir_ubi.Text = frm_dat.Rows[0]["va_dir_ubi"].ToString().Trim();
            tb_obs_con.Text = frm_dat.Rows[0]["va_obs_con"].ToString().Trim();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            if (frm_dat.Rows[0]["va_fec_nac"].ToString() != "")
                tb_fec_nac.Text = frm_dat.Rows[0]["va_fec_nac"].ToString().Substring(0, 10);

            if (frm_dat.Rows[0]["va_sex_con"].ToString() == "H")
                cb_sex_per.Text = "Hombre";
            if (frm_dat.Rows[0]["va_sex_con"].ToString() == "M")
                cb_sex_per.Text = "Hombre";
        }

        /// <summary>
        /// Limpia los Campos en pantalla
        /// </summary>
        private void Fi_lim_cam() {
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_cod_con.Text = string.Empty;
            tb_nom_bre.Text = string.Empty;
            tb_ape_pat.Text = string.Empty;
            tb_ape_mat.Text = string.Empty;
            tb_nro_cid.Text = string.Empty;
            tb_fec_nac.Text = string.Empty;
            tb_tel_per.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            tb_dir_ubi.Text = string.Empty;            
        }

        /// <summary>
        /// Funcion: Obtiene Lista de Parentesco
        /// </summary>
        /// <param name="sex_per"></param>
        private void Fi_obt_par(string sex_per)
        {
            // Limpia Datos del Combobox
            cb_par_con.DataSource = null;

            // Obtiene la Lista de Relacion de Persona
            Tabla = new DataTable();
            Tabla = o_adp017.Fe_lis_rel("1");

            // Lista de Parentesco Masculino
            if (sex_per.CompareTo("H") == 0)
            {
                cb_par_con.DataSource = Tabla;
                cb_par_con.DisplayMember = "va_nre_hom";
                cb_par_con.ValueMember = "va_ide_rel";
                cb_par_con.SelectedValue = int.Parse(Tabla.Rows[0]["va_ide_rel"].ToString());
            }

            // Lista de Parentesco Femenina
            if (sex_per.CompareTo("M") == 0)
            {
                cb_par_con.DataSource = Tabla;
                cb_par_con.DisplayMember = "va_nre_muj";
                cb_par_con.ValueMember = "va_ide_rel";
                cb_par_con.SelectedValue = int.Parse(Tabla.Rows[0]["va_ide_rel"].ToString());
            }
        }


        /// <summary>
        /// Metodo : Valida datos proporcionados por el usuario
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            // Variable usada para verificar datos numericos
            if (tb_cod_per.Text.Trim() == "0")
                return "El Código de Persona DEBE ser distinto de Cero (0)";
            
            if (tb_cod_con.Text.Trim() == "0")
                return "El Código del Contacto DEBE ser distinto de Cero (0)";
            
            int val;
            int.TryParse(tb_cod_per.Text.Trim(), out val);
            if (val == 0)
                return "El Código de Persona DEBE ser Númerico";

            int.TryParse(tb_cod_con.Text.Trim(), out val);
            if (val == 0)
                return "El Código del Contacto DEBE ser Númerico";

            if (tb_nom_bre.Text.Trim() == "") { 
                tb_nom_bre.Focus();
                return "DEBE proporcionar datos en el campo Nombre";
            }

            if (tb_ape_pat.Text.Trim() == ""){
                tb_ape_pat.Focus();
                return "DEBE proporcionar datos en el Apellido Paterno";
            }

            if (tb_ape_mat.Text.Trim() == ""){
                tb_ape_mat.Focus();
                return "DEBE proporcionar datos en el Apellido Materno";
            }

            if (tb_tel_per.Text.Trim() == "" && tb_tel_cel.Text.Trim() == ""){
                tb_tel_per.Focus();
                return "DEBE proporcionar datos en el campo Tel. Personal o Tel. Celular";
            }


            // Verificar Registro de Persona
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if(Tabla.Rows.Count == 0)
                return "La Persona NO se encuentra registrado";
            
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N")
                return "La Persona se encuentra Deshabilitado";

            // Verificar Registro del Contacto
            Tabla = new DataTable();
            Tabla = o_adp013.Fe_con_con(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_con.Text));
            if (Tabla.Rows.Count == 0)
                return "El Contacto NO se encuentra registrado";

            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N")
                return "El Contacto se encuentra Deshabilitado";


            // Verifica RUC/NIT
            long val_num;
            try
            {
                val_num = long.Parse(tb_nro_cid.Text);
            }catch (Exception){
                tb_nro_cid.Focus();
                return "El N° de CI del Contacto DEBE ser un valor numérico";
            }

            // Verifica Nro. Documento
            try{
                val_num = long.Parse(tb_nro_cid.Text);
            }catch (Exception){
                tb_nro_cid.Focus();
                return "El Nro. Documento de la Persona DEBE ser un valor numérico";
            }

            // Verifica que la fecha sea una fecha valida
            if (tb_fec_nac.Text.CompareTo("  /  /") != 0){
                if (cl_glo_bal.IsDateTime(tb_fec_nac.Text) == false) {
                    tb_fec_nac.Focus();
                    return "La Fecha de Nacimiento de la Persona DEBE ser una fecha válida";
                }
            }            

            // Verifica si ya existe otra contacto con el mismo nombre y apellidos
            Tabla = new DataTable();
            Tabla = o_adp013.Fe_con_nom(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_con.Text), tb_nom_bre.Text.Trim(), tb_ape_pat.Text.Trim(), tb_ape_mat.Text.Trim());
            if (Tabla.Rows.Count > 0)
                return "Ya existe otro Contacto de la Persona con el mismo Nombre y Apellido";

            // Verifica si ya existe otra contacto con el mismo N° CI.
            if (tb_nro_cid.Text.Trim().CompareTo("") != 0 && tb_nro_cid.Text.Trim().CompareTo("0") != 0){
                Tabla = new DataTable();
                Tabla = o_adp013.Fe_con_cid(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_con.Text), int.Parse(tb_nro_cid.Text));
                if (Tabla.Rows.Count > 0)
                    return "Ya existe otro Contacto de la Persona con el mismo N° C.I.";
            }

            // Verifica si ya existe otra contacto con el mismo telefono Personal
            if (tb_tel_per.Text.Trim().CompareTo("") != 0 && tb_tel_per.Text.Trim().CompareTo("0") != 0){
                Tabla = new DataTable();
                Tabla = o_adp013.Fe_con_tel(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_con.Text), tb_tel_per.Text.Trim());
                if (Tabla.Rows.Count > 0)
                    return "Ya existe otro Contacto de la Persona con el mismo Teléfono Personal";
            }

            // Verifica si ya existe otra contacto con el mismo telefono Celular
            if (tb_tel_cel.Text.Trim().CompareTo("") != 0 && tb_tel_cel.Text.Trim().CompareTo("0") != 0){
                Tabla = new DataTable();
                Tabla = o_adp013.Fe_con_tel(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_con.Text), tb_tel_cel.Text.Trim());
                if (Tabla.Rows.Count > 0)
                    return "Ya existe otro Contacto de la Persona con el mismo Teléfono Célular";
            }
            return "";
        }                        

        private void tb_nro_cid_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_fec_nac_Validated(object sender, EventArgs e)
        {
            // Verifica que la fecha sea una fecha valida
            if (tb_fec_nac.Text.CompareTo("  /  /") != 0){
                if (cl_glo_bal.IsDateTime(tb_fec_nac.Text) == false){
                    tb_fec_nac.Focus();
                    MessageBox.Show("La Fecha Digitada NO corresponde a una Fecha Válida", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cb_sex_per_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Despliega Datos de Parentesco
            Fi_obt_par(cb_sex_per.Text.Substring(0, 1));
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

                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {                    
                    string nom_bre = tb_nom_bre.Text.Trim();
                    string ape_pat = tb_ape_pat.Text.Trim();
                    string ape_mat = tb_ape_mat.Text.Trim();
                    string nro_cid = tb_nro_cid.Text.Trim();
                    string ext_doc = cb_ext_doc.Text.Trim();
                    string sex_per = cb_sex_per.Text.Substring(0, 1);
                    string fec_nac = "NULL";
                    string par_con = cb_par_con.Text.Trim();
                    string tel_per = tb_tel_per.Text.Trim();
                    string cel_ula = tb_tel_per.Text.Trim();
                    string ema_ail = tb_ema_ail.Text.Trim();
                    string dir_ubi = tb_dir_ubi.Text.Trim();
                    string obs_con = tb_obs_con.Text.Trim();                    
                      int cod_per = int.Parse(tb_cod_per.Text);
                       int cod_con = int.Parse(tb_cod_con.Text);

                    if (tb_fec_nac.Text.CompareTo("  /  /") != 0)
                        fec_nac = "'" + tb_fec_nac.Text + "'";

                    if (cb_ext_doc.Enabled == false)
                        ext_doc = "";

                    // Edita Contacto Persona
                    o_adp013.Fe_edi_con(cod_per, cod_con, nom_bre, ape_pat, ape_mat, nro_cid,
                                        ext_doc, sex_per, fec_nac, par_con, tel_per, cel_ula,
                                        ema_ail, dir_ubi, obs_con);

                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    frm_pad.Fe_act_frm(tb_cod_con.Text);
                    cl_glo_frm.Cerrar(this);
                }
            }catch (Exception ex){
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
