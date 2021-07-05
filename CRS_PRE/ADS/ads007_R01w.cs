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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using CrystalDecisions.ReportAppServer;

namespace CRS_PRE.ADS
{
    public partial class ads007_R01w : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public string vp_est_ado;
       


        //Instancias
        ads013 o_ads013 = new ads013();
        DataTable tabla = new DataTable();
        DataTable tab_ads013 = new DataTable();
        string va_nom_emp="";
        int va_nro_pag;



        public ads007_R01w()
        {
            InitializeComponent();
            
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Hacer grande la pantalla
            this.Dock = DockStyle.Fill;

            DataSet ds_dat_set = new DataSet();


            //obtener nombre de la empresa
            tab_ads013 = o_ads013.Fe_obt_glo(1, 4);
            va_nom_emp = tab_ads013.Rows[0]["va_glo_car"].ToString();

            //Logueo manual el ReportDocument asociado al crystal report
            ads007_R011.SetDatabaseLogon(o_ads013.va_ide_usr, o_ads013.va_pas_usr, o_ads013.va_ser_bda + "\\" + o_ads013.va_ins_bda, o_ads013.va_nom_bda);

            //frm_dat.TableName = "ads007_R01";

            //ads007_R011.Database.Tables["ads007_R01"].SetDataSource(frm_dat);
           
            
            //ads007_R011.SetParameterValue("vc_ide_usr", o_ads013.va_ide_usr);
            //ads007_R011.SetParameterValue("vc_nom_emp", va_nom_emp);
            //ads007_R011.SetParameterValue("vc_est_ado", "(" + vp_est_ado + ")");

            // Paso los datos obtenidos del procedimiento en la anterior ventana
            /*ads007_R011.DataDefinition.FormulaFields["vc_ide_usr"].Text = o_ads013.va_ide_usr;
            ads007_R011.DataDefinition.FormulaFields["vc_nom_emp"].Text =  va_nom_emp;
            ads007_R011.DataDefinition.FormulaFields["vc_est_ado"].Text = "(" + vp_est_ado + ")";
            */

            //carga tabla a dataset
            //ds_dat_set.Tables.Add(frm_dat);
            //----------------------------------------
            //--* Aqui poblamos el reporte con los datos
            ads007_R011.SetDataSource(frm_dat);
            cr_rep_ort.ReportSource = ads007_R011;

            // Obtiene nro de paginas
            va_nro_pag = cr_rep_ort.GetCurrentPageNumber();

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
