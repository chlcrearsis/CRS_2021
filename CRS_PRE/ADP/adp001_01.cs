using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp001 - Grupo Persona                                */
    /* Descripción: Buscar Grupo Persona                                  */
    /*       Autor: JEJR - Crearsis             Fecha: 22-07-2020         */
    /**********************************************************************/
    public partial class adp001_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Variables
        string est_bus = "T";
        
        public adp001_01()
        {
            InitializeComponent();
        }

        // instancia        
        adp001 o_adp001 = new adp001();

        // Variables
        DataTable Tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }
        
        private void fi_ini_frm()
        {
            tb_cod_gru.Text = "";           
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }       

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        private void fi_bus_car(string ar_tex_bus = "", int ar_prm_bus = 0, string ar_est_bus = "T")
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            Tabla = o_adp001.Fe_bus_car(ar_tex_bus, ar_prm_bus, ar_est_bus);

            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_gru"].Value = Tabla.Rows[i]["va_cod_gru"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_gru"].Value = Tabla.Rows[i]["va_nom_gru"].ToString();
                    
                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_cod_gru.Text = Tabla.Rows[0]["va_cod_gru"].ToString();
                lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString();
            }

        }
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_cod_gru.Text.Trim() == ""){
                lb_nom_gru.Text = "NO Existe";
                return;
            }
            // Verifica si el grupo esta registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_gru.Text = "NO Existe";
                return;
            }

            lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString();
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Grupo de persona Modificó
        /// </summary>
        private void fi_sel_fil(string ide_gru)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_gru != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_gru.ToUpper()){
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }catch (Exception ex){
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
                    // Al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1){
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();
                        }
                    }
                    // Al presionar tecla para ARRIBA
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
                }catch (Exception ex){
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
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_cod_gru.Text = string.Empty;
                    lb_nom_gru.Text = string.Empty;
                }else{
                    tb_cod_gru.Text = dg_res_ult.SelectedRows[0].Cells["va_cod_gru"].Value.ToString().Trim();
                    lb_nom_gru.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_gru"].Value.ToString().Trim();
                }
            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos
        /// </summary>
        public bool fi_ver_dat(string sel_ecc)
        {
            string res_fun;
            if (sel_ecc.Trim() == ""){
                res_fun = "El Grupo de Persona que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_gru.Focus();
                return false;
            }
            // Obtiene datos del registro seleccionado
            tab_dat = new DataTable();
            tab_dat = o_adp001.Fe_con_gru(int.Parse(sel_ecc));
            if (Tabla.Rows.Count == 0){
                res_fun = "El Grupo de persona que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_gru.Focus();
                return false;
            }

            return true;
        }                       

        private void tb_cod_gru_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_gru.Text != "NO Existe"){
                fi_sel_fil(tb_cod_gru.Text);
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
            if (bt_ace_pta.Enabled == true) { 
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        private void dg_res_ult_Enter(object sender, EventArgs e)
        {
            if (bt_ace_pta.Enabled == true)
            {
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        private void bt_bus_car_Click(object sender, EventArgs e)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int cod_gru)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (cod_gru.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_cod_gru"].Value.ToString() == cod_gru.ToString())
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

        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            adp001_02 frm = new adp001_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_cod_gru.Text) == false)
                return;

            adp001_03 frm = new adp001_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }       
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_cod_gru.Text) == false)
                return;

            adp001_04 frm = new adp001_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_cod_gru.Text) == false)
                return;

            adp001_05 frm = new adp001_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_cod_gru.Text) == false)
                return;

            adp001_06 frm = new adp001_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_ins_aut_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_gru.Text) == false)
                return;

            adp016_01 frm = new adp016_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_lis_gru_Click(object sender, EventArgs e)
        {
            adp001_R01p frm = new adp001_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }        
    }
}
