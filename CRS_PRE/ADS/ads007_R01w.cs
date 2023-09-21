using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Informe R01 - Reporte View                            */
    /*       Autor: JEJR - Crearsis             Fecha: 07-08-2023         */
    /**********************************************************************/
    public partial class ads007_R01w : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;        
        // Instancias
        ads013 o_ads013 = new ads013();
        ads007 o_ads007 = new ads007();
        DataTable Tabla = new DataTable();
        // Variable
        string va_nom_emp = "";
        public string vp_est_ado;
        public string vp_ord_dat;

        public ads007_R01w()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Hacer grande la pantalla
            Dock = DockStyle.Fill;
            // Castea la descripcion del estado
            if (vp_est_ado.CompareTo("T") == 0)
                vp_est_ado = "Todos";
            if (vp_est_ado.CompareTo("H") == 0)
                vp_est_ado = "Habilitados";
            if (vp_est_ado.CompareTo("N") == 0)
                vp_est_ado = "Deshabilitados";
            // Castea la descripcion de ordenamiento
            if (vp_ord_dat.CompareTo("C") == 0)
                vp_ord_dat = "Código";
            if (vp_ord_dat.CompareTo("N") == 0)
                vp_ord_dat = "Nombre";

            // Obtener nombre de la empresa
            Tabla = o_ads013.Fe_obt_glo(1, 4);
            va_nom_emp = Tabla.Rows[0]["va_glo_car"].ToString().Trim();
            // Logueo Manual el ReportDocument asociado al Crystal Report
            ads007_R01.SetDatabaseLogon(Program.gl_ide_usr, Program.gl_pas_usr, Program.gl_ser_bdo + "\\" + Program.gl_ins_bdo, Program.gl_nom_bdo);
            // Paso los datos obtenidos del procedimiento en la anterior ventana
            ads007_R01.SetDataSource(frm_dat);
            // Para enviar parametros directos al reporte (nombre del parametro en crystal report, valor que se enviara)
            ads007_R01.SetParameterValue("vc_nom_emp", va_nom_emp);
            ads007_R01.SetParameterValue("vc_est_ado", vp_est_ado);
            ads007_R01.SetParameterValue("vc_ord_dat", vp_ord_dat);
            ads007_R01.SetParameterValue("vc_ide_usr", Program.gl_ide_usr);
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
