using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp002 - Registro Persona                             */
    /*      Opción: Informe R00 - Reporte View                            */
    /*       Autor: JEJR - Crearsis             Fecha: 08-08-2022         */
    /**********************************************************************/
    public partial class adp002_R00w : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp002 o_adp002 = new adp002();
        adp009 o_adp009 = new adp009();
        ads013 o_ads013 = new ads013();
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();
        // Variable
        string va_nom_emp = "";
        public int vp_cod_per;

        public adp002_R00w()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Hacer grande la pantalla
            this.Dock = DockStyle.Fill;
            string va_cod_per = "";
            string va_cod_gru = "";
            string va_nom_gru = "";
            string va_tip_per = "";
            string va_est_ado = "";
            string va_raz_soc = "";
            string va_nom_fac = "";
            string va_ruc_nit = "";
            string va_nom_bre = "";
            string va_ape_pat = "";
            string va_ape_mat = "";
            string va_tip_doc = "";
            string va_nro_doc = "";
            string va_ext_doc = "";
            string va_fec_nac = "";
            string va_sex_per = "";
            string va_tel_per = "";
            string va_cel_ula = "";
            string va_tel_fij = "";
            string va_ema_ail = "";
            string va_dir_pri = "";
            string va_dir_ent = "";
            string va_nom_ven = "";
            string va_nom_cob = "";
            string va_tip_atr = "";
            string va_nom_atr = "";            

            // Obtiene Datos de la persona
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_inf_R00(vp_cod_per);
            if (Tabla.Rows.Count > 0){
                va_cod_per = Tabla.Rows[0]["va_cod_per"].ToString().Trim();
                va_cod_gru = Tabla.Rows[0]["va_cod_gru"].ToString().Trim();
                va_nom_gru = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
                va_tip_per = Tabla.Rows[0]["va_tip_per"].ToString().Trim();
                va_est_ado = Tabla.Rows[0]["va_est_ado"].ToString().Trim();
                va_raz_soc = Tabla.Rows[0]["va_raz_soc"].ToString().Trim();
                va_nom_fac = Tabla.Rows[0]["va_nom_fac"].ToString().Trim();
                va_ruc_nit = Tabla.Rows[0]["va_ruc_nit"].ToString().Trim();
                va_nom_bre = Tabla.Rows[0]["va_nom_bre"].ToString().Trim();
                va_ape_pat = Tabla.Rows[0]["va_ape_pat"].ToString().Trim();
                va_ape_mat = Tabla.Rows[0]["va_ape_mat"].ToString().Trim();
                va_tip_doc = Tabla.Rows[0]["va_tip_doc"].ToString().Trim();
                va_nro_doc = Tabla.Rows[0]["va_nro_doc"].ToString().Trim();
                va_ext_doc = Tabla.Rows[0]["va_ext_doc"].ToString().Trim();
                va_fec_nac = Tabla.Rows[0]["va_fec_nac"].ToString().Trim();
                va_sex_per = Tabla.Rows[0]["va_sex_per"].ToString().Trim();
                va_tel_per = Tabla.Rows[0]["va_tel_per"].ToString().Trim();
                va_cel_ula = Tabla.Rows[0]["va_cel_ula"].ToString().Trim();
                va_tel_fij = Tabla.Rows[0]["va_tel_fij"].ToString().Trim();
                va_ema_ail = Tabla.Rows[0]["va_ema_ail"].ToString().Trim();
                va_dir_pri = Tabla.Rows[0]["va_dir_pri"].ToString().Trim();
                va_dir_ent = Tabla.Rows[0]["va_dir_ent"].ToString().Trim();
                va_nom_ven = Tabla.Rows[0]["va_nom_ven"].ToString().Trim();
                va_nom_cob = Tabla.Rows[0]["va_nom_cob"].ToString().Trim();
                va_tip_atr = Tabla.Rows[0]["va_tip_atr"].ToString().Trim();
                va_nom_atr = Tabla.Rows[0]["va_nom_atr"].ToString().Trim();
            }

            // Obtiene lista de precios asignadas al cliente
            Tabla = new DataTable();
            frm_dat = o_adp009.Fe_inf_R01(vp_cod_per);

            // Obtener nombre de la empresa
            Tabla = o_ads013.Fe_obt_glo(1, 4);
            va_nom_emp = Tabla.Rows[0]["va_glo_car"].ToString().Trim();
            // Logueo Manual el ReportDocument asociado al Crystal Report
            adp002_R00.SetDatabaseLogon(o_ads007.va_ide_usr, o_ads007.va_pas_usr, o_ads007.va_ser_bda + "\\" + o_ads007.va_ins_bda, o_ads007.va_nom_bda);
            // Paso los datos obtenidos del procedimiento en la anterior ventana
            adp002_R00.SetDataSource(frm_dat);
            // Para enviar parametros directos al reporte (nombre del parametro en crystal report, valor que se enviara)
            adp002_R00.SetParameterValue("vc_nom_emp", va_nom_emp);
            adp002_R00.SetParameterValue("vc_cod_per", va_cod_per);
            adp002_R00.SetParameterValue("vc_cod_gru", va_cod_gru);
            adp002_R00.SetParameterValue("vc_nom_gru", va_nom_gru);
            adp002_R00.SetParameterValue("vc_tip_per", va_tip_per);
            adp002_R00.SetParameterValue("vc_est_ado", va_est_ado);
            adp002_R00.SetParameterValue("vc_raz_soc", va_raz_soc);
            adp002_R00.SetParameterValue("vc_nom_fac", va_nom_fac);
            adp002_R00.SetParameterValue("vc_ruc_nit", va_ruc_nit);
            adp002_R00.SetParameterValue("vc_nom_bre", va_nom_bre);
            adp002_R00.SetParameterValue("vc_ape_pat", va_ape_pat);
            adp002_R00.SetParameterValue("vc_ape_mat", va_ape_mat);
            adp002_R00.SetParameterValue("vc_tip_doc", va_tip_doc);
            adp002_R00.SetParameterValue("vc_nro_doc", va_nro_doc);
            adp002_R00.SetParameterValue("vc_ext_doc", va_ext_doc);
            adp002_R00.SetParameterValue("vc_fec_nac", va_fec_nac);
            adp002_R00.SetParameterValue("vc_sex_per", va_sex_per);
            adp002_R00.SetParameterValue("vc_tel_per", va_tel_per);
            adp002_R00.SetParameterValue("vc_cel_ula", va_cel_ula);
            adp002_R00.SetParameterValue("vc_tel_fij", va_tel_fij);
            adp002_R00.SetParameterValue("vc_ema_ail", va_ema_ail);
            adp002_R00.SetParameterValue("vc_dir_pri", va_dir_pri);
            adp002_R00.SetParameterValue("vc_dir_ent", va_dir_ent);
            adp002_R00.SetParameterValue("vc_nom_ven", va_nom_ven);
            adp002_R00.SetParameterValue("vc_nom_cob", va_nom_cob);
            adp002_R00.SetParameterValue("vc_tip_atr", va_tip_atr);
            adp002_R00.SetParameterValue("vc_nom_atr", va_nom_atr);
            adp002_R00.SetParameterValue("vc_ide_usr", o_ads007.va_ide_usr);
        }

        private void Mn_imp_rim_Click(object sender, EventArgs e)
        {
            cr_rep_ort.PrintReport();
        }

        private void Mn_exp_ort_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ExportReport();
        }

        private void Mn_bus_car_Click(object sender, EventArgs e)
        {
            ads000_10 frm = new ads000_10();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.no);
        }
        
        public void Fe_bus_txt(string ar_bus_txt)
        {
            cr_rep_ort.SearchForText(ar_bus_txt);
        }

        private void Mn_zoo_anc_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(200);
        }

        private void Mn_zoo_tod_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(200);
        }

        private void Mn_zoo_200_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(200);
        }

        private void Mn_zoo_150_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(150);
        }

        private void Mn_zoo_100_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(100);
        }

        private void Mn_zoo_075_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(75);
        }

        private void Mn_zoo_025_Click(object sender, EventArgs e)
        {
            cr_rep_ort.Zoom(25);
        }

        private void Mn_pri_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowFirstPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_ant_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowPreviousPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_sig_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowNextPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_ult_pag_Click(object sender, EventArgs e)
        {
            cr_rep_ort.ShowLastPage();
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_nro_pag_Leave(object sender, EventArgs e)
        {
            cr_rep_ort.ShowNthPage(int.Parse(mn_nro_pag.Text));
            mn_nro_pag.Text = cr_rep_ort.GetCurrentPageNumber().ToString();
        }

        private void Mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
