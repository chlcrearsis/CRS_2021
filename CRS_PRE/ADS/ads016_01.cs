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

namespace CRS_PRE.ADS
{
    public partial class ads016_01 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        //Form frm_mdi;
        public ads016_01()
        {
            InitializeComponent();
        }

        // instancia
        c_ads016 o_ads016 = new c_ads016();

        // Variables
        DataTable tabla = new DataTable();

        private void ads007_01_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {

            Fi_obt_ges();
            // Obtener listado de gestion 
            cb_ges_tio.SelectedIndex = 0;

            

            if(cb_ges_tio.Items.Count > 0)
                fi_bus_car(int.Parse(cb_ges_tio.Text));  

        }

        private void Fi_obt_ges()
        {
            tabla = o_ads016.Fe_obt_ges();
            if (tabla.Rows.Count == 0)
                return;

            cb_ges_tio.DataSource = tabla;
            cb_ges_tio.ValueMember = "va_ges_tio";
            cb_ges_tio.DisplayMember = "va_ges_tio";
            cb_ges_tio.Refresh();
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        public void fi_bus_car(int ar_ges_tio)
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();
            tabla = new DataTable();

            tabla = o_ads016.Fe_bus_car(ar_ges_tio);
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ges_tio"].Value = tabla.Rows[i]["va_ges_tio"].ToString();
                    dg_res_ult.Rows[i].Cells["va_ges_per"].Value = tabla.Rows[i]["va_ges_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_per"].Value = tabla.Rows[i]["va_nom_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_fec_ini"].Value = Convert.ToDateTime(tabla.Rows[i]["va_fec_ini"].ToString()).ToString("dd/MM/yyyy");
                    dg_res_ult.Rows[i].Cells["va_fec_fin"].Value = Convert.ToDateTime(tabla.Rows[i]["va_fec_fin"].ToString()).ToString("dd/MM/yyyy");
            }
                tb_sel_ges.Text = tabla.Rows[0]["va_ges_tio"].ToString();
                tb_sel_per.Text = tabla.Rows[0]["va_ges_per"].ToString();
                
            }

        }
       
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        private void fi_sel_fil(int ges_tio, int ges_per)
        {
            fi_bus_car(int.Parse(cb_ges_tio.Text));

            if ((ges_tio != 0) && (ges_per != 0))
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if ((int.Parse(dg_res_ult.Rows[i].Cells[0].Value.ToString()) == ges_tio) && (int.Parse(dg_res_ult.Rows[i].Cells[1].Value.ToString()) == ges_per))
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void fi_sub_baj_fil_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                try
                {
                    //al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();

                        }
                    }
                    //al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != 0)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }


        /// <summary>
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null)
                {
                    //tb_sel_ges.Text = "";
                    //tb_sel_per.Text = "";
                }
                else
                {
                    tb_sel_ges.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                    tb_sel_per.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
                }

            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi(string sel_ecc)
        {
            tab_dat = o_ads016.Fe_con_per(int.Parse(tb_sel_ges.Text), int.Parse(tb_sel_per.Text));
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("El periodo que esta intentando editar no se encuentra registrado en la base de datos" +
                    "verifique por favor", "Edita Periodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ges.Focus();
                return false;
            }

            return true;
        }
     
        public bool fi_ver_con()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_sel_ges.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("La gestion no se encuentra registrada en la base de datos" +
                                    "verifique por favor", "Consulta Periodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ges.Focus();
                return false;
            }

            try
            {
                val = int.Parse(tb_sel_per.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El periodo no se encuentra registrado en la base de datos" +
                                    "verifique por favor", "Consulta Periodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ges.Focus();
                return false;
            }
            tab_dat = o_ads016.Fe_con_per(int.Parse(tb_sel_ges.Text), int.Parse(tb_sel_per.Text));
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("El periodo no se encuentra registrado en la base de datos" +
                    "verifique por favor", "Consulta Periodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ges.Focus();
                return false;
            }

            return true;
        }

   public bool fi_ver_eli()
        {
            tab_dat = o_ads016.Fe_con_per(int.Parse(tb_sel_ges.Text), int.Parse(tb_sel_per.Text));
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("El periodo no se encuentra registrado en la base de datos" +
                    "verifique por favor", "Elimina Periodo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ges.Focus();
                return false;
            }

            return true;
        }


        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
           
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        private void Bt_bus_car_Click(object sender, EventArgs e)
        {
            if(cb_ges_tio.Text == "")
                fi_bus_car(0);
            else
                fi_bus_car(int.Parse(cb_ges_tio.Text));

        }
      

        private void Mn_ini_ges_Click(object sender, EventArgs e)
        {
            ads016_02 frm = new ads016_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void Mn_sig_ges_Click(object sender, EventArgs e)
        {
            ads016_02b frm = new ads016_02b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void Mn_nue_per_Click(object sender, EventArgs e)
        {
            ads016_02c frm = new ads016_02c();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi(tb_sel_ges.Text) == false)
                return;

            ads016_03 frm = new ads016_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
      
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con() == false)
                return;

            ads016_05 frm = new ads016_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_eli() == false)
                return;

            ads016_06 frm = new ads016_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        
        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Mn_per_ges_Click(object sender, EventArgs e)
        {
            ads016_R01p frm = new ads016_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada,cl_glo_frm.ctr_btn.si);
        }

        private void Mn_lis_ges_Click(object sender, EventArgs e)
        {
            ads016_R02p frm = new ads016_R02p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

       
    }
}
