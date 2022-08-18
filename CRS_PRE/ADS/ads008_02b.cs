using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads008_02b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads007 o_ads007 = new ads007();
        ads009 o_ads009 = new ads009();
        ads004 o_ads004 = new ads004();
        ads005 o_ads005 = new ads005();
        ads001 o_ads001 = new ads001();

        // Variables
        DataTable tabla = new DataTable();
        DataTable tab_ads001 = new DataTable();
        int val_mod = 0;
        public ads008_02b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_tus"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();

            // obtiene lista de Modulos
            tabla = o_ads001.Fe_lis_mod("1");

            tab_ads001.Columns.Add("va_ide_mod");
            tab_ads001.Columns.Add("va_nom_mod");

            tab_ads001.Rows.Add();
            tab_ads001.Rows[0]["va_ide_mod"] = 0;
            tab_ads001.Rows[0]["va_nom_mod"] = "Todos los modulos";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tab_ads001.Rows.Add();
                tab_ads001.Rows[i+1]["va_ide_mod"] = tabla.Rows[i]["va_ide_mod"].ToString();
                tab_ads001.Rows[i+1]["va_nom_mod"] = tabla.Rows[i]["va_nom_mod"].ToString();
            }

            cb_mod_ulo.DataSource = tab_ads001;
            cb_mod_ulo.ValueMember = "va_ide_mod";
            val_mod = 1;
            cb_mod_ulo.DisplayMember = "va_nom_mod";

            ch_che_tod.Focus();
            ch_che_tod.Checked = false;

        }

        private void Fi_bus_car(object sender, EventArgs e)
        {
            dg_res_ult.Rows.Clear();

            if (val_mod == 0 )
            {
                return;
            }


            // Obtiene talonarios
            string mod_ulo = cb_mod_ulo.SelectedValue.ToString(); 
            tabla = o_ads004.Fe_bus_car("", 2,"T",int.Parse(mod_ulo) );
            
            if (tabla.Rows.Count >0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    int nro_tal = int.Parse(tabla.Rows[i]["va_nro_tal"].ToString());
                    string ide_doc = tabla.Rows[i]["va_ide_doc"].ToString();

                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = ide_doc;
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nro_tal"].Value = nro_tal;
                    dg_res_ult.Rows[i].Cells["va_nom_tal"].Value = tabla.Rows[i]["va_nom_tal"].ToString();

                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        dg_res_ult.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                    //**** TIKEA LOS PERMITIDOS Y DESTIKEA LOS RESTRINGIDOS
                    //dg_res_ult.Rows[i].Cells[4].Value = false;
                    dg_res_ult.Rows[i].Cells[4].Value = o_ads009.Fe_ads009_02(tb_ide_usr.Text,"ads004", ide_doc, nro_tal.ToString());

                }

            }

        }


        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            
            DialogResult msg_res;
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Permiso de Talonario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                for (int i = 0; i < dg_res_ult.RowCount ; i++)
                {
                    bool chk_val = (bool)dg_res_ult.Rows[i].Cells[4].Value;
                    int nro_tal = int.Parse(tabla.Rows[i]["va_nro_tal"].ToString());

                   // bool aaa = (bool)dg_res_ult.Rows[i].Cells[4].Value;
                    string ide_doc = tabla.Rows[i]["va_ide_doc"].ToString();

                    if (chk_val == true)
                    { 
                        o_ads009.Fe_ads009_04(tb_ide_usr.Text,"ads004", ide_doc, nro_tal.ToString());
                        o_ads009.Fe_ads009_03(tb_ide_usr.Text,"ads004", ide_doc, nro_tal.ToString());
                    }
                    if (chk_val == false)
                        o_ads009.Fe_ads009_04(tb_ide_usr.Text, "ads004", ide_doc, nro_tal.ToString());
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
            if (e.ColumnIndex == 4)
            {
               chk = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;
                
                if (chk == false)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                else
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

            }


            chk = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;
        }
    }
}
