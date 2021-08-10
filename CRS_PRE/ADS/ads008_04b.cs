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
    public partial class ads008_04b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads007 o_ads007 = new ads007();
        ads009 o_ads009 = new ads009();

        c_res004 o_res004 = new c_res004();

        // Variables
       // DataTable tab_res004 = new DataTable();
        DataTable tab_res004 = new DataTable();

        public ads008_04b()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_tus"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();
           
            ch_che_tod.Focus();
            ch_che_tod.Checked = false;

            // Obtiene plantillas
            tab_res004 = o_res004.Fe_bus_car("", 1, "T");
            for (int i = 0; i < tab_res004.Rows.Count ; i++)
            {
                dg_res_ult.Rows.Add();
                dg_res_ult.Rows[i].Cells["va_cod_plv"].Value = tab_res004.Rows[i]["va_cod_plv"].ToString();
                dg_res_ult.Rows[i].Cells["va_nom_plv"].Value = tab_res004.Rows[i]["va_nom_plv"].ToString();
                dg_res_ult.Rows[i].Cells["va_des_plv"].Value = tab_res004.Rows[i]["va_des_plv"].ToString();

                if (tab_res004.Rows[i]["va_est_ado"].ToString() == "H")
                    dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                else
                    dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                //**** TIKEA LOS PERMITIDOS Y DESTIKEA LOS RESTRINGIDOS
                dg_res_ult.Rows[i].Cells["va_per_mis"].Value = o_ads009.Fe_ads009_02(tb_ide_usr.Text, "res004",tab_res004.Rows[i]["va_cod_plv"].ToString());
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
                    int cod_plv= int.Parse(tab_res004.Rows[i]["va_cod_plv"].ToString());

                    if (chk_val == true)
                    { 
                        o_ads009.Fe_ads009_04(tb_ide_usr.Text,"res004", cod_plv.ToString());
                        o_ads009.Fe_ads009_03(tb_ide_usr.Text,"res004", cod_plv.ToString());
                    }
                    if (chk_val == false)
                        o_ads009.Fe_ads009_04(tb_ide_usr.Text,"res004", cod_plv.ToString());
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
            if (tab_res004.Rows[e.RowIndex]["va_est_ado"].ToString() == "H")
                dg_res_ult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            else
                dg_res_ult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
        }
    }
}
