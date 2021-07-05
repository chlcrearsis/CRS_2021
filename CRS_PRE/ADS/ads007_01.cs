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


namespace CRS_PRE.ADS
{
    public partial class ads007_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        //Form frm_mdi;
        public ads007_01()
        {
            InitializeComponent();
        }

        // instancia
        ads006 o_ads006 = new ads006();
        ads007 o_ads007 = new ads007();

        // Variables
        DataTable tabla = new DataTable();
        DataTable tab_ads006 = new DataTable();


        private void ads007_01_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_bus.Text = "";
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            
            // Obtiene tipo de usuarios
            Fi_obt_tus();

            cb_tip_usr.SelectedIndex = 0;


            fi_bus_car("", parametro.codigo, estado.Todos);  
        }

        private void Fi_obt_tus()
        {
            tab_ads006 = new DataTable();

            tab_ads006.Columns.Add("va_ide_tus");
            tab_ads006.Columns.Add("va_nom_tus");

            tab_ads006.Rows.Add();
            tab_ads006.Rows[0][0] = "0";
            tab_ads006.Rows[0][1] = "Todos";

            tabla = o_ads006.Fe_lis_tus();
            
            for (int i = 0; i < tabla.Rows.Count ; i++)
            {
                tab_ads006.Rows.Add();
                tab_ads006.Rows[i + 1][0] = tabla.Rows[i][0].ToString();
                tab_ads006.Rows[i + 1][1] = tabla.Rows[i][1].ToString();
            }

            cb_tip_usr.DataSource = tab_ads006;
            cb_tip_usr.DisplayMember = "va_nom_tus";
            cb_tip_usr.ValueMember = "va_ide_tus";
            cb_tip_usr.Refresh();


        }

        protected enum parametro
        {
            codigo = 1, nombre = 2
        }
        protected enum estado
        {
            Todos = 0, Habilitado = 1, Deshabilitado = 2
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        private void fi_bus_car(string ar_tex_bus = "", parametro ar_prm_bus = 0, estado ar_est_bus = 0)
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            tabla = o_ads007.Fe_bus_usu(ar_tex_bus, (int)ar_prm_bus, (int)ar_est_bus,int.Parse(cb_tip_usr.SelectedValue.ToString()));
            
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_usr"].Value = tabla.Rows[i]["va_ide_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_usr"].Value = tabla.Rows[i]["va_nom_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_tel_usr"].Value = tabla.Rows[i]["va_tel_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_car_usr"].Value = tabla.Rows[i]["va_car_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tus"].Value = tabla.Rows[i]["va_nom_tus"].ToString();

                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_sel_bus.Text = tabla.Rows[0]["va_ide_usr"].ToString();
                lb_des_bus.Text = tabla.Rows[0]["va_nom_usr"].ToString();
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

            tabla = o_ads007.Fe_con_usu(tb_sel_bus.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_usr"].ToString());
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        private void fi_sel_fil(string cod_usr)
        {
            parametro prm_bus = new parametro();
            estado est_bus = new estado();

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = estado.Todos;
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = estado.Habilitado;
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = estado.Deshabilitado;

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);

            if (cod_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_usr.ToUpper())
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
        public bool fi_ver_edi(string sel_ecc)
        {
            string res_fun ;
            res_fun =  o_ads007.Fe_ver_edi(sel_ecc);
            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            // Obtiene datos seleccionado
            tab_dat = o_ads007.Fe_con_usu(sel_ecc);

            return true;
        }
        public bool fi_ver_hds(string sel_ecc)
        {
            string res_fun;
            res_fun = o_ads007.Fe_ver_hds(sel_ecc);
            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            // Obtiene datos seleccionado
            tab_dat = o_ads007.Fe_con_usu(sel_ecc);

            return true;
        }
        public bool fi_ver_con(string sel_ecc)
        {
            string res_fun;
            res_fun = o_ads007.Fe_ver_con(sel_ecc);
            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_bus.Focus();
                return false;
            }

            // Obtiene datos seleccionado
            tab_dat = o_ads007.Fe_con_usu(sel_ecc);

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

        private void Bt_bus_car_Click(object sender, EventArgs e)
        {
            parametro prm_bus = new parametro();
            estado est_bus = new estado();

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = estado.Todos;
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = estado.Habilitado;
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = estado.Deshabilitado;

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);

        }



        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string cod_usr)
        {
            parametro prm_bus = new parametro();
            estado est_bus = new estado();

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = estado.Todos;
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = estado.Habilitado;
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = estado.Deshabilitado;

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);


            if (cod_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_usr.ToUpper())
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
            ads007_02 frm = new ads007_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            ads007_03 frm = new ads007_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
        private void Mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_hds(tb_sel_bus.Text) == false)
                return;

            ads007_04 frm = new ads007_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con(tb_sel_bus.Text) == false)
                return;

            ads007_05 frm = new ads007_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Mn_list_usr_Click(object sender, EventArgs e)
        {
            ads007_R01p frm = new ads007_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_per_tal_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            ads009_01 frm = new ads009_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void mn_per_plv_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            ads017_01 frm = new ads017_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void mn_per_plv_res_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            ads018_01 frm = new ads018_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void mn_per_apl_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            ads008_01 frm = new ads008_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void mn_per_lis_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_edi(tb_sel_bus.Text) == false)
                return;

            ads019_01 frm = new ads019_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_tip_usu_Click(object sender, EventArgs e)
        {
            ads006_01 frm = new ads006_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.ocul);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {

        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {

        }

    }
}
