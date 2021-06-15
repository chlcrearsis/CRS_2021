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
using CRS_NEG.INV;
using CRS_NEG.CMR;

namespace CRS_PRE.ADS
{
    public partial class ads008_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_ads007 o_ads007 = new c_ads007();
        c_ads008 o_ads008 = new c_ads008();

        c_ads002 o_ads002 = new c_ads002();

        // Variables
       // DataTable tab_ads002 = new DataTable();
        DataTable tab_ads002 = new DataTable();

        public ads008_01()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
         
            ch_che_tod.Focus();
            ch_che_tod.Checked = false;

            // Obtiene aplicaciones
            tab_ads002 = o_ads002.Fe_bus_car("",1 ,"T");
            for (int i = 0; i < tab_ads002.Rows.Count ; i++)
            {
                dg_res_ult.Rows.Add();
                dg_res_ult.Rows[i].Cells["va_ide_apl"].Value = tab_ads002.Rows[i]["va_ide_apl"].ToString();
                dg_res_ult.Rows[i].Cells["va_nom_apl"].Value = tab_ads002.Rows[i]["va_nom_apl"].ToString();
                //dg_res_ult.Rows[i].Cells["va_des_apl"].Value = tab_ads002.Rows[i]["va_des_apl"].ToString();

                if (tab_ads002.Rows[i]["va_est_ado"].ToString() == "V")
                    dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                //**** TIKEA LOS PERMITIDOS Y DESTIKEA LOS RESTRINGIDOS
                dg_res_ult.Rows[i].Cells["va_per_mis"].Value = o_ads008.Fe_ads008_02(tb_ide_usr.Text, tab_ads002.Rows[i]["va_ide_apl"].ToString());
            }
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            
            DialogResult msg_res;
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Permiso sobre Plantilla de ventas", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                for (int i = 0; i < dg_res_ult.RowCount ; i++)
                {
                    bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                    string ide_apl= tab_ads002.Rows[i]["va_ide_apl"].ToString();

                    if (chk_val == true)
                    { 
                        o_ads008.Fe_ads008_04(tb_ide_usr.Text, ide_apl);
                        o_ads008.Fe_ads008_03(tb_ide_usr.Text, ide_apl);
                    }
                    if (chk_val == false)
                        o_ads008.Fe_ads008_04(tb_ide_usr.Text, ide_apl);
                }

                cl_glo_frm.Cerrar(this);
            }

        }

        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_res_ult.RowCount ; i++)
            {
                dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;

            }
        }

        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool chk = false;
            if (e.ColumnIndex == 3)
            {
                if (dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value == null)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

               chk = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;
                
                if (chk == false)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                else
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;
            }

            chk = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void dg_res_ult_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (tab_ads002.Rows[e.RowIndex]["va_est_ado"].ToString() == "V")
                dg_res_ult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            else
                dg_res_ult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
        }
    }
}
