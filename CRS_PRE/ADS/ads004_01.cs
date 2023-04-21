using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonario                                    */
    /* Descripción: Buscar Registro                                       */
    /*       Autor: JEJR - Crearsis             Fecha: 31-08-2022         */
    /**********************************************************************/
    public partial class ads004_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        ads004 o_ads004 = new ads004();
        ads001 o_ads001 = new ads001();
        DataTable Tabla = new DataTable();
        // Variables
        string est_bus = "H";
        public int vp_ide_mod = 0;  // TODOS LOS MÓDULOS 

        public ads004_01()
        {
            InitializeComponent();
        }
               
        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }
        
        /// <summary>
        /// Inicializa Formulario
        /// </summary>
        private void fi_ini_frm()
        {
            tb_ide_doc.Text = "";
            tb_nro_tal.Text = "";
            lb_nom_tal.Text = "...";
            lb_nom_mod.Text = "TODOS";
            // Obtiene el nombre del Módulo
            if (vp_ide_mod != 0){
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
                if (Tabla.Rows.Count > 0)
                    lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
            // Inicializa los paramatros de busqueda
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="tex_bus">Texto a buscar</param>
        /// <param name="prm_bus">Parametro a buscar</param>
        /// <param name="est_bus">Estado a buscar</param>
        private void fi_bus_car(string tex_bus = "", int prm_bus = 0, string est_bus = "T")
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();
            // Obtiene el estado de la busqueda
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";
            
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_bus_car(tex_bus, prm_bus, est_bus, vp_ide_mod);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = Tabla.Rows[i]["va_ide_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = Tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nro_tal"].Value = Tabla.Rows[i]["va_nro_tal"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tal"].Value = Tabla.Rows[i]["va_nom_tal"].ToString();
                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_ide_doc.Text = Tabla.Rows[0]["va_ide_doc"].ToString();
                tb_nro_tal.Text = Tabla.Rows[0]["va_nro_tal"].ToString();
                lb_nom_tal.Text = Tabla.Rows[0]["va_nom_tal"].ToString();
            }
            tb_tex_bus.Focus();
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_doc.Text.Trim() == "" || tb_nro_tal.Text.Trim() == ""){
                lb_nom_tal.Text = "NO Existe";
                return;
            }

            // Verifica si la aplicación está registrado en el sistema
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count == 0)
            {
                lb_nom_tal.Text = "NO Existe";
                return;
            }

            lb_nom_tal.Text = Tabla.Rows[0]["va_nom_tal"].ToString();
        }

        /// <summary>
        /// Función que selecciona la fila en el Datagrid que el talonario Modificó
        /// </summary>
        private void fi_sel_fil(string ide_doc, int nro_tal)
        {
            // Obtiene el estado de la búsqueda
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_doc != null && nro_tal != 0)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_doc.ToUpper() && 
                            dg_res_ult.Rows[i].Cells[2].Value.ToString().ToUpper() == nro_tal.ToString()){
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
                    tb_ide_doc.Text = string.Empty;
                    tb_nro_tal.Text = string.Empty;
                    lb_nom_tal.Text = string.Empty;
                }
                else
                {
                    tb_ide_doc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                    tb_nro_tal.Text = dg_res_ult.SelectedRows[0].Cells[2].Value.ToString();
                    lb_nom_tal.Text = dg_res_ult.SelectedRows[0].Cells[3].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat(string ide_doc, int nro_tal)
        {
            string res_fun;
            if (ide_doc.Trim() == ""){
                res_fun = "El Talonario que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_doc.Focus();
                return false;
            }
            

            // Obtiene datos del registro seleccionado
            tab_dat = new DataTable();
            tab_dat = o_ads004.Fe_con_tal(ide_doc, nro_tal);
            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "El Talonario que desea editar, no se encuentra registrada";
                MessageBox.Show(res_fun, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_nro_tal.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string ide_doc, int nro_tal)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_doc != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_doc.ToUpper() &&
                            dg_res_ult.Rows[i].Cells[2].Value.ToString().ToUpper() == nro_tal.ToString())
                        {
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

        private void tb_nro_tal_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_tal.Text != "NO Existe")
            {
                fi_sel_fil(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            }
        }

        private void tb_nro_tal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bt_cam_mod_Click(object sender, EventArgs e)
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                vp_ide_mod = int.Parse(frm.tb_ide_mod.Text);

                /* Desplega el nombre del modulo seleccionado */
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
                if (Tabla.Rows.Count > 0)
                    lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();

                /* Realiza el filtro de registro de acuerpo al modulo */
                if (cb_est_bus.SelectedIndex == 0)
                    est_bus = "T";
                if (cb_est_bus.SelectedIndex == 1)
                    est_bus = "H";
                if (cb_est_bus.SelectedIndex == 2)
                    est_bus = "N";

                fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
            }
        }

        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            ads004_02 frm = new ads004_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_nue_tal_Click(object sender, EventArgs e)
        {
            ads004_02b frm = new ads004_02b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para modificar
            if (fi_ver_dat(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text)) == false)
                return;

            ads003_03 frm = new ads003_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text)) == false)
                return;

            ads004_04 frm = new ads004_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text)) == false)
                return;

            ads004_05 frm = new ads004_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text)) == false)
                return;

            ads004_06 frm = new ads004_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_lis_tal_Click(object sender, EventArgs e)
        {
            ads004_R01p frm = new ads004_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_for_fir_Click(object sender, EventArgs e)
        {
            ads004_R02p frm = new ads004_R02p();
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
