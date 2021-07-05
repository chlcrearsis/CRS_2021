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
using CRS_NEG;
using CRS_PRE.INV;

namespace CRS_PRE.CMR
{
    public partial class cmr002_05b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr001 o_cmr001 = new cmr001();
        cmr002 o_cmr002 = new cmr002();

        inv004 o_inv004 = new inv004();


        DataTable tabla = new DataTable();
        //int nro_dec = 0;

        /// <summary>
        /// Crea o Actualiza precio||  0 = Crea, 1= Actualiza
        /// </summary>
        //int ban_cre_act = 0;
        /// <summary>
        /// 0 = lista de precio inicial ; 1 = Lista de precio final
        /// </summary>
        int ban_ord_lis = 0;

        decimal val_pre = 0m;
        int nro_row = 0;
        int nro_cel = 0;

        public cmr002_05b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_lis_ini.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            lb_nom_lis_ini.Text = frm_dat.Rows[0]["va_nom_lis"].ToString();

            tb_nro_lis_fin.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            lb_nom_lis_fin.Text = frm_dat.Rows[0]["va_nom_lis"].ToString();

            //nro_dec = 0;

           
            tb_cod_pro.Focus();
        }


        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

      

      

        private void Fi_lim_pia()
        {
            
            tb_cod_pro.Clear(); 
            lb_nom_pro.Text = "";

            dg_res_ult.Rows.Clear();
            tb_cod_pro.Focus();
        }


        private void Bt_bus_pro_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_pro();
        }
        private void Tb_cod_pro_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_pro();
            }

        }

        void Fi_abr_bus_pro()
        {
            inv004_01 frm = new inv004_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_pro.Text = frm.tb_sel_ecc.Text;
                Fi_obt_pro();
            }
        }

        private void Tb_cod_pro_Validated(object sender, EventArgs e)
        {
            Fi_obt_pro();
        }

        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_pro()
        {
            // Obtiene ide y nombre documento
            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_pro.Text="";
            }
            else
            {
                tb_cod_pro.Text = tabla.Rows[0]["va_cod_pro"].ToString();
                lb_nom_pro.Text = tabla.Rows[0]["va_nom_pro"].ToString();
                
            }
        }


        decimal Fi_for_dec(decimal valor, int nro_dec)
        {
            decimal val_res = 0m;

            //Formatea decimales
            val_res = decimal.Round(valor, nro_dec);

            switch (nro_dec)
            {
                case 0:
                    val_res = decimal.Parse(val_res.ToString("N0"));
                    break;

                case 1:
                    val_res = decimal.Parse(val_res.ToString("N1"));
                    break;
                case 2:
                    val_res = decimal.Parse(val_res.ToString("N2"));
                    break;
                case 3:
                    val_res = decimal.Parse(val_res.ToString("N3"));
                    break;
                case 4:
                    val_res = decimal.Parse(val_res.ToString("N4"));
                    break;
            }

            //tb_des_max.Text = decimal.Round(decimal.Parse(tb_des_max.Text), 2).ToString();
            //tb_des_max.Text = decimal.Parse(tb_des_max.Text).ToString("N2");

            //tb_inc_max.Text = decimal.Round(decimal.Parse(tb_inc_max.Text), 2).ToString();
            //tb_inc_max.Text = decimal.Parse(tb_inc_max.Text).ToString("N2");
            return val_res;
        }


        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        //******* LISTA DE PRECIO *******\\
        private void Bt_bus_lis_Click(object sender, EventArgs e)
        {
            ban_ord_lis = 0;
            Fi_abr_bus_lis();
        }
        private void Bt_bus_lis_ini_Click(object sender, EventArgs e)
        {
            ban_ord_lis = 0;
            Fi_abr_bus_lis();
        }
        private void Bt_bus_lis_fin_Click(object sender, EventArgs e)
        {
            ban_ord_lis = 1;
            Fi_abr_bus_lis();
        }
        private void Tb_cod_lis_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_lis();
            }
        }
        void Fi_abr_bus_lis()
        {
            cmr001_01 frm = new cmr001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                if(ban_ord_lis == 0)
                    tb_nro_lis_ini.Text = frm.tb_sel_bus.Text;
                else
                    tb_nro_lis_fin.Text = frm.tb_sel_bus.Text;
                
                Fi_obt_lis();
            }
        }
        private void Tb_cod_lis_Validated(object sender, EventArgs e)
        {
            Fi_obt_lis();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_lis()
        {
            int val = 0;
            try
            {
                if (ban_ord_lis == 0)
                    val = int.Parse(tb_nro_lis_ini.Text);
                else
                    val = int.Parse(tb_nro_lis_fin.Text);
            }
            catch (Exception)
            {
                if (ban_ord_lis == 0)
                    lb_nom_lis_ini.Text = "";
                else
                    lb_nom_lis_fin.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            if (ban_ord_lis == 0)
                tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis_ini.Text));
            else
                tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis_fin.Text));

            if (tabla.Rows.Count == 0)
            {
                if (ban_ord_lis == 0)
                    lb_nom_lis_ini.Text = "";
                else
                    lb_nom_lis_fin.Text = "";
            }
            else
            {
                if (ban_ord_lis == 0)
                {
                    tb_nro_lis_ini.Text = tabla.Rows[0]["va_cod_lis"].ToString();
                    lb_nom_lis_ini.Text = tabla.Rows[0]["va_nom_lis"].ToString();
                }
                else
                {
                    tb_nro_lis_fin.Text = tabla.Rows[0]["va_cod_lis"].ToString();
                    lb_nom_lis_fin.Text = tabla.Rows[0]["va_nom_lis"].ToString();
                }
            }
        }

        private void tb_nro_lis_ini_Enter(object sender, EventArgs e)
        {
            ban_ord_lis = 0;
        }

        private void tb_nro_lis_fin_Enter(object sender, EventArgs e)
        {
            ban_ord_lis = 1;
        }

        private void bt_bus_car_Click(object sender, EventArgs e)
        {
            try
            {

            
            // Verifica 
            if (tb_nro_lis_ini.Text == "")
                return;

            if (int.Parse(tb_nro_lis_ini.Text) > int.Parse(tb_nro_lis_fin.Text))
            {
                MessageBox.Show("La lista de precios final debe ser mayor igual a la inicial", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

                tabla = o_cmr002.Fe_bus_var(tb_cod_pro.Text, int.Parse(tb_nro_lis_ini.Text), int.Parse(tb_nro_lis_fin.Text));
            

                dg_res_ult.Rows.Clear();
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_lis"].Value = tabla.Rows[i]["va_cod_lis"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_lis"].Value = tabla.Rows[i]["va_nom_lis"].ToString();

                    if(tabla.Rows[i]["va_mon_lis"].ToString()== "B")
                        dg_res_ult.Rows[i].Cells["va_mon_lis"].Value ="Bs.";
                    else
                        dg_res_ult.Rows[i].Cells["va_mon_lis"].Value = "Us.";


                    dg_res_ult.Rows[i].Cells["va_pmx_des"].Value = tabla.Rows[i]["va_pmx_des"].ToString();
                    dg_res_ult.Rows[i].Cells["va_pmx_inc"].Value = tabla.Rows[i]["va_pmx_inc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nro_dec"].Value = tabla.Rows[i]["va_nro_dec"].ToString();


                    // Formatea valor precio
                    decimal pre_cio = decimal.Parse(tabla.Rows[i]["va_pre_cio"].ToString());
                    int nro_dec = int.Parse(tabla.Rows[i]["va_nro_dec"].ToString());

                    dg_res_ult.Rows[i].Cells["va_pre_cio"].Value = Fi_for_dec(pre_cio, nro_dec).ToString();
                }

                if (dg_res_ult.Rows.Count > 0)
                {
                    dg_res_ult.CurrentRow.Cells["va_pre_cio"].Selected = true;
                    dg_res_ult.BeginEdit(true);
                }

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        
        private void dg_res_ult_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           
            
        }

       
        private void dg_res_ult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
