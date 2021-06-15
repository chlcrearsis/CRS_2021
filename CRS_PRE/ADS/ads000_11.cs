using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG.ADS;
using CRS_PRE.CMR;
using CRS_NEG.INV;

namespace CRS_PRE.ADS
{
    public partial class ads000_11 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public string frm_ide_doc;
        public int frm_nro_tal;
        public int frm_nro_doc;
        public int frm_ges_doc;
       

        //Instancias
        c_ads016 o_ads016 = new c_ads016();

        //DataTable tabla = new DataTable();
        DataTable tab_dat = new DataTable();

        public ads000_11()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            string nro_tal;
            string nro_doc;
            nro_tal = (1000 + frm_nro_tal).ToString();
            nro_tal = nro_tal.Substring(1, 3);

            nro_doc = (1000000 + frm_nro_doc).ToString();
            nro_doc = nro_doc.Substring(1, 6);


            lb_ide_doc.Text = frm_ide_doc + "  " + nro_tal + "-" + nro_doc;

            //** Envia a imprimir


        }

        


        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        //** Crea tabla con parametros para enviar



        private void bt_imp_rim_Click(object sender, EventArgs e)
        {
            //tab_dat = c_res001.Fe_con_vta(lb_ide_doc.Text, frm_ges_doc);

            //** Imprime documento
            res001_05w frm = new res001_05w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tab_dat);
        }
    }
}
