using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads010 - Tipo de Imagen                               */
    /* Descripción: Buscar Tipo de Imagen                                 */
    /*       Autor: JEJR - Crearsis             Fecha: 21-09-2022         */
    /**********************************************************************/
    public partial class ads010_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        ads010 o_ads010 = new ads010();
        DataTable Tabla = new DataTable();
        // Variables
        string est_bus = "T";
        string ide_tab = "";

        public ads010_01()
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
            tb_ide_tip.Text = "";
            cb_ide_tab.SelectedIndex = 0;
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="tex_bus">Texto a buscar</param>
        /// <param name="prm_bus">Parámetros a buscar</param>
        /// <param name="est_bus">Estado a buscar</param>
        /// <param name="ide_tab">ID. Relacion (Tabla)</param>
        private void fi_bus_car(string tex_bus = "", int prm_bus = 0, string est_bus = "T", string ide_tab = "")
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            Tabla = o_ads010.Fe_bus_car(tex_bus, prm_bus, est_bus, ide_tab);

            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_tip"].Value = Tabla.Rows[i]["va_ide_tip"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tip"].Value = Tabla.Rows[i]["va_nom_tip"].ToString();

                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";


                    switch (Tabla.Rows[i]["va_ide_tab"].ToString()) {
                        case "adp002":
                            dg_res_ult.Rows[i].Cells["va_ide_tab"].Value = "Persona";
                            break;
                        case "inv004":
                            dg_res_ult.Rows[i].Cells["va_ide_tab"].Value = "Producto";
                            break;
                    }
                }
                tb_ide_tip.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                lb_nom_tip.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
            }
        }

        /// <summary>
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0){
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_ide_tip.Text = string.Empty;
                    lb_nom_tip.Text = string.Empty;
                }else{
                    tb_ide_tip.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString().Trim();
                    lb_nom_tip.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString().Trim();
                }
            }
        }

        /// <summary>
        /// Función: Consulta registro seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_tip.Text.Trim() == ""){
                lb_nom_tip.Text = "NO Existe";
                return;
            }

            Tabla = o_ads010.Fe_con_tip(tb_ide_tip.Text.Trim());
            if (Tabla.Rows.Count == 0){
                lb_nom_tip.Text = "NO Existe";
                return;
            }

            lb_nom_tip.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
        }

        /// <summary>
        /// Función: Selecciona la fila en el Datagrid del registro que se modifico
        /// </summary>
        private void fi_sel_fil(string ide_tip)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            if (cb_ide_tab.SelectedIndex == 0)
                ide_tab = string.Empty;
            if (cb_ide_tab.SelectedIndex == 1)
                ide_tab = "adp002";
            if (cb_ide_tab.SelectedIndex == 2)
                ide_tab = "inv004";

            Tabla = new DataTable();
            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, ide_tab);

            if (ide_tip != null){
                try{
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++){
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_tip.ToUpper())
                        {
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

        /// <summary>
        /// Función: Verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat(string sel_ecc)
        {
            string res_fun;
            if (sel_ecc.Trim() == "")
            {
                res_fun = "El Tipo de Imagen que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Edita Tipo de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_tip.Focus();
                return false;
            }

            Tabla = new DataTable();
            Tabla = o_ads010.Fe_con_tip(sel_ecc);
            if (Tabla.Rows.Count == 0)
            {
                res_fun = "El Tipo de Imagen que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Edita Tipo de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_tip.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Funcion : Actualiza la ventana despues de realizar alguna operación
        /// </summary>
        public void Fe_act_frm(string ide_tip)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            if (cb_ide_tab.SelectedIndex == 0)
                ide_tab = string.Empty;
            if (cb_ide_tab.SelectedIndex == 1)
                ide_tab = "adp002";
            if (cb_ide_tab.SelectedIndex == 2)
                ide_tab = "inv004";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, ide_tab);

            if (ide_tip.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_tip.ToString())
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

        // Evento KeyDown: Preciona Teclado
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

        // Evento Validated: ID. Tipo Imagen  
        private void tb_ide_tip_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_tip.Text != "NO Existe")            
                fi_sel_fil(tb_ide_tip.Text);            
        }

        // Evento SelectedIndexChanged: Combobox ID. Tabla
        private void cb_ide_tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            if (cb_ide_tab.SelectedIndex == 0)
                ide_tab = "";
            if (cb_ide_tab.SelectedIndex == 1)
                ide_tab = "adp002";
            if (cb_ide_tab.SelectedIndex == 2)
                ide_tab = "inv004";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, ide_tab);
        }

        // Evento SelectionChanged: DataGridView 
        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fi_fil_act();
        }

        // Evento CellClick: DataGridView
        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        // Evento CellDoubleClick: DataGridView
        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        // Evento Enter: DataGridView
        private void dg_res_ult_Enter(object sender, EventArgs e)
        {
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        // Evento Click: Button Buscar
        private void bt_bus_car_Click(object sender, EventArgs e)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            if (cb_ide_tab.SelectedIndex == 0)
                ide_tab = "";
            if (cb_ide_tab.SelectedIndex == 1)
                ide_tab = "adp002";
            if (cb_ide_tab.SelectedIndex == 2)
                ide_tab = "inv004";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus, ide_tab);
        }

        // Evento Click: Nuevo Registro
        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            ads010_02 frm = new ads010_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Modifica Registro
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            ads010_03 frm = new ads010_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }

        // Evento Click: Habilita/Deshabilita
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            ads010_04 frm = new ads010_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }

        // Evento Click: Consulta Registro
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            ads010_05 frm = new ads010_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }

        // Evento Click: Elimina Registro
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_tip.Text) == false)
                return;

            ads010_06 frm = new ads010_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }

        // Evento Click: Lista Tipo de Imagen
        private void mn_lis_tip_Click(object sender, EventArgs e)
        {
            ads010_R01p frm = new ads010_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        // Evento Click: Salir
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }        
    }
}
