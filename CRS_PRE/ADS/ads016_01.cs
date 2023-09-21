using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /* Descripción: Buscar Módulo del Sistema                             */
    /*       Autor: JEJR - Crearsis             Fecha: 18-04-2023         */
    /**********************************************************************/
    public partial class ads016_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        ads016 o_ads016 = new ads016();
        DataTable Tabla = new DataTable();
        // Variables
        string est_bus = "H";

        public ads016_01()
        {
            InitializeComponent();
        }        

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        private void fi_ini_frm()
        {
            tb_ges_per.Text = "";
            tb_ges_tio.Text = "";
            lb_nom_per.Text = "...";
            cb_prm_bus.SelectedIndex = 0;
            fi_bus_car("", cb_prm_bus.SelectedIndex);
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        public void fi_bus_car(string tex_bus = "", int prm_bus = 0)
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();
            
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_bus_car(tex_bus, prm_bus);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ges_tio"].Value = Tabla.Rows[i]["va_ges_tio"].ToString();
                    dg_res_ult.Rows[i].Cells["va_ges_per"].Value = Tabla.Rows[i]["va_ges_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_per"].Value = Tabla.Rows[i]["va_nom_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_fec_ini"].Value = Tabla.Rows[i]["va_fec_ini"].ToString();
                    dg_res_ult.Rows[i].Cells["va_fec_fin"].Value = Tabla.Rows[i]["va_fec_fin"].ToString();
                }
                tb_ges_per.Text = Tabla.Rows[0]["va_ges_per"].ToString();
                tb_ges_tio.Text = Tabla.Rows[0]["va_ges_tio"].ToString();
                lb_nom_per.Text = Tabla.Rows[0]["va_nom_per"].ToString();
            }
            tb_tex_bus.Focus();
        }

        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ges_per.Text.Trim() == "" ||
                tb_ges_per.Text.Trim() == "0"){
                lb_nom_per.Text = "NO Existe";
                return;
            }
            // Verifica que los datos en pantallas sean correctos
            if (tb_ges_tio.Text.Trim() == "" ||
                tb_ges_tio.Text.Trim() == "0"){
                lb_nom_per.Text = "NO Existe";
                return;
            }
            // Verifica si el Periodo está registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_per(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_per.Text = "NO Existe";
                return;
            }
            lb_nom_per.Text = Tabla.Rows[0]["va_nom_per"].ToString();
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Modulo Modificó
        /// </summary>
        private void fi_sel_fil(string ges_per, string ges_tio)
        {            
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex);

            if (ges_per != null && ges_tio != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ges_tio"].Value.ToString() == ges_tio.ToString() &&
                            dg_res_ult.Rows[i].Cells["va_ges_per"].Value.ToString() == ges_per.ToString()){
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

        private void fi_pre_tec_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                try
                {
                    dg_res_ult.Show();
                    /* Verifica que tecla preciono */
                    switch (e.KeyData)
                    {
                        case Keys.Up:     // Flecha Arriba
                            if (dg_res_ult.SelectedRows[0].Index != 0)
                            {
                                // Establece el foco en el Datagrid
                                dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];
                                // Llama a función que actualiza datos en Pantalla
                                fi_fil_act();
                            }
                            break;
                        case Keys.Down:   // Flecha Abajo
                            if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                            {
                                // Establece el foco en el Datagrid
                                dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];
                                // Llama a función que actualiza datos en Pantalla
                                fi_fil_act();
                            }
                            break;
                        case Keys.Enter:  // Tecla Enter
                            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0)
                            {
                                DialogResult = DialogResult.OK;
                                cl_glo_frm.Cerrar(this);
                            }
                            break;
                        case Keys.Escape: // Tecla Esc
                            if (bt_ace_pta.Enabled == true)
                            {
                                DialogResult = DialogResult.Cancel;
                                cl_glo_frm.Cerrar(this);
                            }
                            break;
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
                    tb_ges_per.Text = string.Empty;
                    tb_ges_tio.Text = string.Empty;
                    lb_nom_per.Text = string.Empty;
                }else{
                    tb_ges_per.Text = dg_res_ult.SelectedRows[0].Cells["va_ges_per"].Value.ToString();
                    tb_ges_tio.Text = dg_res_ult.SelectedRows[0].Cells["va_ges_tio"].Value.ToString();
                    lb_nom_per.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_per"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat(string ges_tio, string ges_per)
        {
            string res_fun;
            if (ges_tio.Trim() == "" || ges_per.Trim() == "")
            {
                res_fun = "El Periodo Gestión que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ges_per.Focus();
                return false;
            }

            // Obtiene datos del registro seleccionado
            tab_dat = new DataTable();
            tab_dat = o_ads016.Fe_con_per(int.Parse(ges_tio), int.Parse(ges_per));
            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "El Periodo Gestión que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ges_per.Focus();
                return false;
            }

            return true;
        }

        // Evento Validated : Periodo
        private void tb_ges_per_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_per.Text != "NO Existe"){
                fi_sel_fil(tb_ges_tio.Text, tb_ges_per.Text);
            }
        }

        // Evento KeyPress : Periodo
        private void tb_ges_per_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Validated : Gestión
        private void tb_ges_tio_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_per.Text != "NO Existe")
            {
                fi_sel_fil(tb_ges_tio.Text, tb_ges_per.Text);
            }
        }

        // Evento KeyPress : Gestión
        private void tb_ges_tio_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
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
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        private void dg_res_ult_Enter(object sender, EventArgs e)
        {
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        // Evento Click : Buscar
        private void bt_bus_car_Click(object sender, EventArgs e)
        {           
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex);
        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int ges_tio, int ges_per)
        {         
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex);

            if (ges_tio.ToString() != null || ges_per.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ges_tio"].Value.ToString() == ges_tio.ToString() &&
                            dg_res_ult.Rows[i].Cells["va_ges_per"].Value.ToString() == ges_per.ToString()){
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                    tb_tex_bus.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            ads016_02b frm = new ads016_02b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para modificar
            if (fi_ver_dat(tb_ges_tio.Text, tb_ges_per.Text) == false)
                return;

            ads016_03 frm = new ads016_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
               
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ges_tio.Text, tb_ges_per.Text) == false)
                return;

            ads016_05 frm = new ads016_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_ges_tio.Text, tb_ges_per.Text) == false)
                return;

            ads016_06 frm = new ads016_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }        

        private void mn_lis_ges_Click(object sender, EventArgs e)
        {
            ads016_R01p frm = new ads016_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_lis_tod_Click(object sender, EventArgs e)
        {
            ads016_R02p frm = new ads016_R02p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }

        
    }
}
