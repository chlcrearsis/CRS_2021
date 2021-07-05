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

namespace CRS_PRE.INV
{
    public partial class inv002_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;

        string est_bus = "T";

        //Form frm_mdi;
        public inv002_01()
        {
            InitializeComponent();
        }

        // instancia
        inv002 o_inv002 = new inv002();
        inv001 o_inv001 = new inv001();



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
            cb_gru_bod.DataSource = o_inv001.Fe_obt_gru();
            cb_gru_bod.ValueMember = "va_ide_gru";
            cb_gru_bod.DisplayMember = "va_nom_gru";

            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus, int.Parse(cb_gru_bod.SelectedValue.ToString()));
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
        private void fi_bus_car(string ar_tex_bus = "", int ar_prm_bus = 0, string ar_est_bus = "T", int ar_gru_bod =0)
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            tabla = o_inv002.Fe_bus_car(ar_tex_bus, ar_prm_bus, ar_est_bus, ar_gru_bod );

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    //dg_res_ult.Rows[i].Cells["va_ide_gru"].Value = tabla.Rows[i]["va_ide_gru"].ToString();
                    dg_res_ult.Rows[i].Cells["va_cod_bod"].Value = tabla.Rows[i]["va_cod_bod"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_bod"].Value = tabla.Rows[i]["va_nom_bod"].ToString();
                    dg_res_ult.Rows[i].Cells["va_mon_inv"].Value = tabla.Rows[i]["va_mon_inv"].ToString();
                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_sel_bus.Text = tabla.Rows[0]["va_cod_bod"].ToString();
                lb_des_bus.Text = tabla.Rows[0]["va_nom_bod"].ToString();
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

            tabla = o_inv002.Fe_con_bod(int.Parse(tb_sel_bus.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_bod"].ToString());
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que la bodega Modificó
        /// </summary>
        private void fi_sel_fil(string cod_bod)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, int.Parse(cb_gru_bod.SelectedValue.ToString()));

            if (cod_bod != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_bod.ToUpper())
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
            tab_dat = o_inv002.Fe_con_bod(sel_ecc);
            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "La bodega que desea editar, NO se encuentra registrada";
            }

            if (res_fun.ToString() != "")
            {
                MessageBox.Show(res_fun, "Edita bodega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }


            return true;
        }
        public bool fi_ver_hds(int sel_ecc)
        {
          
            tab_dat = o_inv002.Fe_con_bod(sel_ecc);
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("la bodega ya no se encuentra registrada en la base de datos.", "Consulta bodega", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            return true;
        }
        public bool fi_ver_con(int sel_ecc)
        {
            tab_dat = o_inv002.Fe_con_bod(sel_ecc);
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("la bodega ya no se encuentra registrada en la base de datos.", "Consulta bodega", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, int.Parse(cb_gru_bod.SelectedValue.ToString()));

        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int ide_gru, int cod_bod)
        {
         if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, ide_gru);

            if (ide_gru.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_gru.ToString() || dg_res_ult.Rows[i].Cells[1].Value.ToString() == cod_bod.ToString())
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
            inv002_02 frm = new inv002_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi(int.Parse(tb_sel_bus.Text)) == false)
                return;

            inv002_03 frm = new inv002_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
        private void Mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_hds(int.Parse(tb_sel_bus.Text)) == false)
                return;

            inv002_04 frm = new inv002_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con(int.Parse(tb_sel_bus.Text)) == false)
                return;

            inv002_05 frm = new inv002_05();
           cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con(int.Parse(tb_sel_bus.Text)) == false)
                return;

            inv002_06 frm = new inv002_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
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

        private void mn_list_bod_Click(object sender, EventArgs e)
        {
            inv002_R01p frm = new inv002_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
    }
}
