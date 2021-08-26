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
    public partial class adp002_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;

        string est_bus = "T";

        //Form frm_mdi;
        public adp002_01()
        {
            InitializeComponent();
        }

        // instancia
        adp002 o_adp002 = new adp002();
        adp001 o_adp001 = new adp001();



        // Variables
        DataTable tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_bus.Text = "";

            // obtiene lista de 
            tb_cod_gru.Text = "0";
            lb_nom_gru.Text = "Todos";

            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus, int.Parse(tb_cod_gru.Text));

            tb_tex_bus.Focus();
            tb_tex_bus.SelectAll();

            SelectNextControl(tb_tex_bus,true,true,false,true);

        }

        //public enum parametro
        //{
        //    codigo = 1, nombre = 2
        //}
        //protected enum estado
        //{
        //    Todos = 0, Habilitado = 1, Deshabilitado = 2
        //}

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        private void fi_bus_car(string ar_tex_bus = "", int ar_prm_bus = 0, string ar_est_bus = "T", int ar_gru_per =0)
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

           

            tabla = o_adp002.Fe_bus_car(ar_tex_bus, ar_prm_bus, ar_est_bus, ar_gru_per );

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_gru"].Value = tabla.Rows[i]["va_cod_gru"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_gru"].Value = tabla.Rows[i]["va_nom_gru"].ToString();
                    dg_res_ult.Rows[i].Cells["va_cod_per"].Value = tabla.Rows[i]["va_cod_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_raz_soc"].Value = tabla.Rows[i]["va_raz_soc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_com"].Value = tabla.Rows[i]["va_nom_com"].ToString();

                    dg_res_ult.Rows[i].Cells["va_nit_per"].Value = tabla.Rows[i]["va_nit_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_car_net"].Value = tabla.Rows[i]["va_car_net"].ToString();


                    dg_res_ult.Rows[i].Cells["va_dir_per"].Value = tabla.Rows[i]["va_dir_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_tel_per"].Value = tabla.Rows[i]["va_tel_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_cel_per"].Value = tabla.Rows[i]["va_cel_per"].ToString();
                    //dg_res_ult.Rows[i].Cells["va_ema_per"].Value = tabla.Rows[i]["va_ema_per"].ToString();

                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_sel_bus.Text = tabla.Rows[0]["va_cod_per"].ToString();
                lb_des_bus.Text = tabla.Rows[0]["va_raz_soc"].ToString();

                tb_tex_bus.Focus();
                tb_tex_bus.SelectAll();
            }

        }
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_bus.Text.Trim() == "")
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            tabla = o_adp002.Fe_con_per(int.Parse(tb_sel_bus.Text));
             if (tabla.Rows.Count == 0)
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_com"].ToString());
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que la persona Modificó
        /// </summary>
        private void fi_sel_fil(string cod_per)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, int.Parse(tb_cod_gru.Text));

            if (cod_per != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_per.ToUpper())
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

            tb_tex_bus.Focus();
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
                    tb_sel_bus.Text = "";
                    lb_des_bus.Text = "";
                }
                else
                {
                    tb_sel_bus.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                    lb_des_bus.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
                }

            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi(int sel_ecc)
        {
            string res_fun = "";
            tab_dat = o_adp002.Fe_con_per(sel_ecc);
            if (tabla.Rows.Count == 0)
            {
                res_fun = "La persona que desea editar, NO se encuentra registrada";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }


            return true;
        }
        public bool fi_ver_hds(string sel_ecc)
        {
          
            tab_dat = o_adp002.Fe_con_per(int.Parse(sel_ecc));
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("la persona ya no se encuentra registrada en la base de datos.", "Consulta persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            return true;
        }
        public bool fi_ver_con(string sel_ecc)
        {
            tab_dat = o_adp002.Fe_con_per(int.Parse(sel_ecc));
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("la persona ya no se encuentra registrada en la base de datos.", "Consulta persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            return true;
        }



        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_des_bus.Text != "** NO existe")
            {
                fi_sel_fil(tb_sel_bus.Text);
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bt_ace_pta.Enabled == false)
                return;

            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }
        private void Bt_bus_car_Click(object sender, EventArgs e)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, int.Parse(tb_cod_gru.Text));

        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm( int cod_per)
        {
         if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, int.Parse(tb_cod_gru.Text));

            if (cod_per.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if ( dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_per.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;

                            return;
                        }
                    }
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void Mn_cre_ar_Click(object sender, EventArgs e)
        {
            adp002_02 frm = new adp002_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi(int.Parse(tb_sel_bus.Text)) == false)
                return;

            adp002_03 frm = new adp002_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
        private void Mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_hds(tb_sel_bus.Text) == false)
                return;

            adp002_04 frm = new adp002_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con(tb_sel_bus.Text) == false)
                return;

            adp002_05 frm = new adp002_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con(tb_sel_bus.Text) == false)
                return;

            //adp002_06 frm = new adp002_06();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }

        private void mn_list_per_Click(object sender, EventArgs e)
        {
            //adp002_R01p frm = new adp002_R01p();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

 
        private void Bt_bus_gru_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_gru();
        }

        private void Tb_cod_gru_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_gru();
            }

        }


        void Fi_abr_bus_gru()
        {
            adp001_01 frm = new adp001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_gru.Text = frm.tb_sel_bus.Text;
                lb_nom_gru.Text = frm.lb_des_bus.Text;
            }


        }


        private void Tb_cod_gru_Validated(object sender, EventArgs e)
        {
            Fi_obt_gru();
        }
        private void Fi_obt_gru()
        {
            if(tb_cod_gru.Text.Trim() == "")
            {
                MessageBox.Show("DEbe proporcionar un Grupo de persona valido", "Error", MessageBoxButtons.OK);
                tb_cod_gru.Focus();
            }
            int val = 0;
            if (tb_cod_gru.Text.Trim() == "0" || tb_cod_gru.Text.Trim() == "00")
            {
                lb_nom_gru.Text = "Todos";
            }
            else
            {
                int.TryParse(tb_cod_gru.Text, out val);
                if(val == 0)
                {
                    MessageBox.Show("DEbe proporcionar un Grupo de persona valido", "Error", MessageBoxButtons.OK);
                    tb_cod_gru.Focus();
                }

                tabla = o_adp001.Fe_con_gru(val);
                if(tabla.Rows.Count== 0)
                {
                    lb_nom_gru.Text = "No Existe";
                }
                else
                {
                    lb_nom_gru.Text = tabla.Rows[0]["va_nom_gru"].ToString();
                }
            }
            


        }

        private void dg_res_ult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;

                if (bt_ace_pta.Enabled == false)
                    return;
                
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }
    }
}
