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
using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads008_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads007 o_ads007 = new ads007();
        ads008 o_ads008 = new ads008();

        cmr001 o_cmr001 = new cmr001();

        // Variables
       // DataTable tab_cmr001 = new DataTable();
        DataTable tab_cmr001 = new DataTable();

        public ads008_05()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Permite dar permiso sobre Tipo de Usuario y Usuario
            if (frm_pad.Name == "ads007_01")    // Desde Usuario
            {
                tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
                tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
            }
            if (frm_pad.Name == "ads006_01")       // Desde Tipo Usuario
            {
                tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_tus"].ToString();
                tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();
            }

            ch_che_tod.Focus();
            ch_che_tod.Checked = false;

            // Obtiene Listas de precio
            tab_cmr001 = o_cmr001.Fe_bus_car("", 1, "T");
            for (int i = 0; i < tab_cmr001.Rows.Count ; i++)
            {
                dg_res_ult.Rows.Add();
                dg_res_ult.Rows[i].Cells["va_cod_lis"].Value = tab_cmr001.Rows[i]["va_cod_lis"].ToString();
                dg_res_ult.Rows[i].Cells["va_nom_lis"].Value = tab_cmr001.Rows[i]["va_nom_lis"].ToString();

                if (tab_cmr001.Rows[i]["va_est_ado"].ToString() == "H")
                    dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                //**** TIKEA LOS PERMITIDOS Y DESTIKEA LOS RESTRINGIDOS
                dg_res_ult.Rows[i].Cells["va_per_mis"].Value = o_ads008.Fe_ads008_02(tb_ide_usr.Text,"cmr001", tab_cmr001.Rows[i]["va_cod_lis"].ToString());
            }
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            
            DialogResult msg_res;
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Permiso sobre Lista de precio", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                for (int i = 0; i < dg_res_ult.RowCount ; i++)
                {
                    bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                    int cod_lis= int.Parse(tab_cmr001.Rows[i]["va_cod_lis"].ToString());

                    if (chk_val == true)
                    { 
                        o_ads008.Fe_ads008_04(tb_ide_usr.Text,"cmr001", cod_lis.ToString());
                        o_ads008.Fe_ads008_03(tb_ide_usr.Text, "cmr001", cod_lis.ToString());
                    }
                    if (chk_val == false)
                        o_ads008.Fe_ads008_04(tb_ide_usr.Text, "cmr001", cod_lis.ToString());
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
            if (e.ColumnIndex == 2)
            {
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
            if (tab_cmr001.Rows[e.RowIndex]["va_est_ado"].ToString() == "H")
                dg_res_ult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            else
                dg_res_ult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
        }
    }
}
