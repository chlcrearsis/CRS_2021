using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp002 - Registro Persona                             */
    /*      Opción: Informe R02 - Reporte View                            */
    /*       Autor: JEJR - Crearsis             Fecha: 29-07-2022         */
    /**********************************************************************/
    public partial class adp002_R02w : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp001 o_adp001 = new adp001();
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        ads013 o_ads013 = new ads013();
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();
        // Variable
        string va_nom_emp = "";
        public string vp_gru_ini;
        public string vp_gru_fin;
        public string vp_tip_atr;
        public string vp_atr_ini;
        public string vp_atr_fin;
        public string vp_est_ado;

        public adp002_R02w()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Hacer grande la pantalla
            this.Dock = DockStyle.Fill;
            // Castea la descripcion del estado
            if (vp_est_ado.CompareTo("T") == 0)
                vp_est_ado = "Todos";
            if (vp_est_ado.CompareTo("H") == 0)
                vp_est_ado = "Habilitados";
            if (vp_est_ado.CompareTo("N") == 0)
                vp_est_ado = "Deshabilitados";

            // Obtiene la descripcion del grupo inicial
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(vp_gru_ini));
            if (Tabla.Rows.Count > 0) { 
                vp_gru_ini = Tabla.Rows[0]["va_cod_gru"].ToString() + "  -  " +
                             Tabla.Rows[0]["va_nom_gru"].ToString();
            }
            // Obtiene la descripcion del grupo final
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(vp_gru_fin));
            if (Tabla.Rows.Count > 0)
            {
                vp_gru_fin = Tabla.Rows[0]["va_cod_gru"].ToString() + "  -  " +
                             Tabla.Rows[0]["va_nom_gru"].ToString();
            }

            // Obtiene la descripcion del Tipo de Atributo inicial y final
            string va_tip_ini = vp_tip_atr;
            string va_tip_fin = vp_tip_atr;
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(int.Parse(vp_tip_atr));
            if (Tabla.Rows.Count > 0)
            {
                va_tip_ini = Tabla.Rows[0]["va_nom_tip"].ToString() + " Inicial : ";
                va_tip_fin = Tabla.Rows[0]["va_nom_tip"].ToString() + " Final : ";
            }

            // Obtiene la descripcion del atributo inicial
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_con_atr(int.Parse(vp_tip_atr), int.Parse(vp_atr_ini));
            if (Tabla.Rows.Count > 0)
            {
                vp_atr_ini = Tabla.Rows[0]["va_ide_atr"].ToString() + "  -  " +
                             Tabla.Rows[0]["va_nom_atr"].ToString();
            }

            // Obtiene la descripcion del atributo final
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_con_atr(int.Parse(vp_tip_atr), int.Parse(vp_atr_fin));
            if (Tabla.Rows.Count > 0)
            {
                vp_atr_fin = Tabla.Rows[0]["va_ide_atr"].ToString() + "  -  " +
                             Tabla.Rows[0]["va_nom_atr"].ToString();
            }

            // Obtener nombre de la empresa
            Tabla = o_ads013.Fe_obt_glo(1, 4);
            va_nom_emp = Tabla.Rows[0]["va_glo_car"].ToString().Trim();
            // Logueo Manual el ReportDocument asociado al Crystal Report
            adp002_R02.SetDatabaseLogon(Program.gl_ide_usr, Program.gl_pas_usr, Program.gl_ser_bdo + "\\" + Program.gl_ins_bdo, Program.gl_nom_bdo);

            // Paso los datos obtenidos del procedimiento en la anterior ventana
            adp002_R02.SetDataSource(frm_dat);
            // Para enviar parametros directos al reporte (nombre del parametro en crystal report, valor que se enviara)
            adp002_R02.SetParameterValue("vc_nom_emp", va_nom_emp);
            adp002_R02.SetParameterValue("vc_gru_ini", vp_gru_ini);
            adp002_R02.SetParameterValue("vc_gru_fin", vp_gru_fin);
            adp002_R02.SetParameterValue("vc_tip_ini", va_tip_ini);
            adp002_R02.SetParameterValue("vc_tip_fin", va_tip_fin);
            adp002_R02.SetParameterValue("vc_atr_ini", vp_atr_ini);
            adp002_R02.SetParameterValue("vc_atr_fin", vp_atr_fin);
            adp002_R02.SetParameterValue("vc_est_ado", vp_est_ado);
            adp002_R02.SetParameterValue("vc_ide_usr", Program.gl_ide_usr);
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
