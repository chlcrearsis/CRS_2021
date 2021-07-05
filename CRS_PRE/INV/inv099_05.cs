using CRS_NEG;
using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;


namespace CRS_PRE.INV
{
    public partial class inv099_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public dynamic frm_MDI;

        string est_bus = "T";
        DataTable tab_dat = new DataTable();

        //Form frm_mdi;
        public inv099_05()
        {
            InitializeComponent();
        }

        // instancia
        //c_inv004 o_inv004 = new c_inv004();
        inv099 o_inv099 = new inv099();

        // Variables
        DataTable tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tab_dat = o_inv099.Fe_con_exi(frm_dat.Rows[0]["va_cod_pro"].ToString());

            tb_cod_pro.Text = frm_dat.Rows[0]["va_cod_pro"].ToString();
            tb_nom_pro.Text = frm_dat.Rows[0]["va_nom_pro"].ToString();
            tb_cod_fam.Text = frm_dat.Rows[0]["va_cod_fam"].ToString();
            tb_nom_fam.Text = frm_dat.Rows[0]["va_nom_fam"].ToString();
            tb_cod_umd.Text = frm_dat.Rows[0]["va_cod_umd"].ToString();

            int nro_dec = 0;
            decimal sal_can = 0;

            nro_dec = int.Parse(frm_dat.Rows[0]["va_nro_dec"].ToString());

            for (int i = 0; i < tab_dat.Rows.Count  ; i++)
            {
                dg_res_ult.Rows.Add();
                dg_res_ult.Rows[i].Cells["va_cod_bod"].Value = tab_dat.Rows[i]["va_cod_bod"].ToString();
                dg_res_ult.Rows[i].Cells["va_nom_bod"].Value = tab_dat.Rows[i]["va_nom_bod"].ToString();

                // Formatea Saldo segun numero de decimales del producto
                sal_can = decimal.Parse(tab_dat.Rows[i]["va_sal_can"].ToString());
                sal_can = decimal.Round(sal_can,nro_dec);

                switch(nro_dec)
                {
                    case 0:
                        dg_res_ult.Rows[i].Cells["va_sal_can"].Value = sal_can.ToString("N0");
                        break;
                    case 1:
                        dg_res_ult.Rows[i].Cells["va_sal_can"].Value = sal_can.ToString("N1");
                        break;
                    case 2:
                        dg_res_ult.Rows[i].Cells["va_sal_can"].Value = sal_can.ToString("N2");
                        break;
                    case 3:
                        dg_res_ult.Rows[i].Cells["va_sal_can"].Value = sal_can.ToString("N3");
                        break;
                    case 4:
                        dg_res_ult.Rows[i].Cells["va_sal_can"].Value = sal_can.ToString("N4");
                        break;
                }
            }
        }

 
    
        #endregion

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
             
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }

    }
}
