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
using System.Drawing.Printing;

namespace CRS_PRE.ADS
{
    /// <summary>
    /// CAJA QUE MUESTRA IMPRESORAS DE LA PC
    /// </summary>
    public partial class ads000_12 : Form
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

        public ads000_12()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            fu_obt_imp();
        }

        void fu_obt_imp()
        {
            PrintDocument vv_pri_doc = new PrintDocument();
            string vv_imp_def = "";

            dg_res_ult.Rows.Clear();

            //Impresora por defecto
            vv_imp_def = vv_pri_doc.PrinterSettings.PrinterName;

            //Agrega todas las impresoras al Listbox
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                dg_res_ult.Rows.Add();
                dg_res_ult.Rows[i].Cells[0].Value = PrinterSettings.InstalledPrinters[i].ToString();
            }

            for (int i = 0; i < dg_res_ult.Rows.Count; i++)
            {
                if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == vv_imp_def.ToUpper())
                {
                    dg_res_ult.Rows[i].Selected = true;
                    dg_res_ult.FirstDisplayedScrollingRowIndex = i;

                    return;
                }
            }
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
             
            cl_glo_frm.Cerrar(this);
        }
    }
}
