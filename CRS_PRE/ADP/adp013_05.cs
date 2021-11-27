using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp013_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public adp013_05()
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

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
