using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp013 - Contacto p/Persona                           */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 04-11-2021         */
    /**********************************************************************/
    public partial class adp013_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp002 o_adp002 = new adp002();
        adp013 o_adp013 = new adp013();
        General general = new General();
        DataTable Tabla = new DataTable();

        public adp013_06()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los campos en pantalla
            Fi_lim_cam();

            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString().Trim();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString().Trim();
            tb_cod_con.Text = frm_dat.Rows[0]["va_cod_con"].ToString().Trim();
            tb_nom_bre.Text = frm_dat.Rows[0]["va_nom_bre"].ToString().Trim();
            tb_ape_pat.Text = frm_dat.Rows[0]["va_ape_pat"].ToString().Trim();
            tb_ape_mat.Text = frm_dat.Rows[0]["va_ape_mat"].ToString().Trim();
            tb_nro_cid.Text = frm_dat.Rows[0]["va_nro_cid"].ToString().Trim();
            tb_ext_doc.Text = frm_dat.Rows[0]["va_ext_doc"].ToString().Trim();
            tb_par_con.Text = frm_dat.Rows[0]["va_par_con"].ToString().Trim();
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

            if (frm_dat.Rows[0]["va_sex_per"].ToString() == "H")
                tb_sex_per.Text = "Hombre";
            if (frm_dat.Rows[0]["va_sex_per"].ToString() == "M")
                tb_sex_per.Text = "Hombre";
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
                return "El Contacto de Persona NO se encuentra registrado";

            if (Tabla.Rows[0]["va_est_ado"].ToString() == "H")
                return "El Contacto de Persona se encuentra Habilitado";

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
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Contacto Persona
                    o_adp013.Fe_eli_min(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_con.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(tb_cod_con.Text);
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
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
