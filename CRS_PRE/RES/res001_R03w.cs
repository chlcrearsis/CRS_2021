using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRS_NEG;
using CRS_PRE.ADS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CRS_PRE.CMR
{
    public partial class res001_R03w : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //public string vp_est_ado;
        //Instancias
        ads016 o_ads016 = new ads016();
        ads013 o_ads013 = new ads013();
        ads004 o_ads004 = new ads004();

        DataTable tabla = new DataTable();
        DataTable tab_ads013 = new DataTable();
        DataTable tab_ads004 = new DataTable();

        string va_nom_emp="";
        string va_dir_emp = "";
        string va_tel_emp = "";
        string va_cla_wif = "";

        int va_nro_pag;
        public res001_R03w()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            Fe_pob_rep();
        }

        public void Fe_pob_rep()
        {
            // Hacer grande la pantalla
            this.Dock = DockStyle.Fill;



            //obtener nombre de la empresa
            tab_ads013 = o_ads013.Fe_obt_glo(1, 4);
            va_nom_emp = tab_ads013.Rows[0]["va_glo_car"].ToString();

            //Logueo manual el ReportDocument asociado al crystal report
            res001_R03.SetDatabaseLogon(o_ads016.va_ide_usr, o_ads016.va_pas_usr, o_ads016.va_ser_bda + "\\" + o_ads016.va_ins_bda, o_ads016.va_nom_bda);
            // Paso los datos obtenidos del procedimiento en la anterior ventana
            res001_R03.SetDataSource(frm_dat);
            // Para enviar parametros directos al reporte (nombre del parametro en crystal report, valor que se enviara)
            res001_R03.SetParameterValue("vc_ide_usr", o_ads016.va_ide_usr);
            res001_R03.SetParameterValue("vc_nom_emp", va_nom_emp);

            

            res001_R03.SetParameterValue("vc_cod_bod", int.Parse(frm_pad.tb_cod_bod.Text));
            res001_R03.SetParameterValue("vc_nom_bod", frm_pad.lb_nom_bod.Text);
            res001_R03.SetParameterValue("vc_fec_ini", frm_pad.tb_fec_ini.Value);
            res001_R03.SetParameterValue("vc_fec_fin", frm_pad.tb_fec_fin.Value);

            res001_R03.SetParameterValue("vc_del_ini",  frm_pad.lb_nom_de1.Text + " (" + frm_pad.tb_cod_de1.Text + ")");
            res001_R03.SetParameterValue("vc_del_fin", frm_pad.lb_nom_de2.Text + " (" + frm_pad.tb_cod_de2.Text + ")");

            // Obtiene nro de paginas
            va_nro_pag = cr_rep_ort.GetCurrentPageNumber();
        }

        public void Fe_imp_doc(string ide_doc, int nro_tal)
        {
            int nro_cop = 0;
            //** Obtiene cuantas copias imprimira
            //    - Obtiene 
            tab_ads004 = o_ads004.Fe_con_tal(ide_doc, nro_tal);


            nro_cop = int.Parse(tab_ads004.Rows[0]["va_nro_cop"].ToString());

            res001_R03.PrintOptions.PrinterName = "PDF24";
            res001_R03.PrintToPrinter(1, false, 0, 0);

            for (int i = 0; i < nro_cop; i++)
            {
                res001_R03.PrintToPrinter(1, false, 0, 0);
            }
        }



        private void Mn_imp_rim_Click(object sender, EventArgs e)
        {
            cr_rep_ort.PrintReport();
        }

        private void Mn_exp_ort_Click(object sender, EventArgs e)
        {
           // ExportOptions exp_opc = new ExportOptions();
            
            cr_rep_ort.ExportReport();
        }

        private void Mn_bus_car_Click(object sender, EventArgs e)
        {
            ads000_10 frm = new ads000_10();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.no);

        }
        // Funcion activada desde Formulario: ads000_10 (buscar texto en reporte)
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
