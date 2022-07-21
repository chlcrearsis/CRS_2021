﻿using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;


namespace CRS_PRE
{
    public partial class adp018_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public dynamic frm_MDI;
        // Instancia        
        adp018 o_adp018 = new adp018();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Grupo Empresarial";
        string est_bus = "T";
        
        public adp018_01()
        {
            InitializeComponent();
        }        

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        private void fi_ini_frm()
        {
            tb_gru_emp.Text = "";           
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
        private void fi_bus_car(string tex_bus = "", int prm_bus = 0, string est_bus = "T")
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            Tabla = new DataTable();
            Tabla = o_adp018.Fe_bus_car(tex_bus, prm_bus, est_bus);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_gru_emp"].Value = Tabla.Rows[i]["va_gru_emp"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_gru"].Value = Tabla.Rows[i]["va_nom_gru"].ToString();

                    if (Tabla.Rows[i]["va_ban_fac"].ToString() == "0")
                        dg_res_ult.Rows[i].Cells["va_ban_fac"].Value = "Registro Cliente";
                    if (Tabla.Rows[i]["va_ban_fac"].ToString() == "1")
                        dg_res_ult.Rows[i].Cells["va_ban_fac"].Value = "Grupo Empresarial";

                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_gru_emp.Text = Tabla.Rows[0]["va_gru_emp"].ToString();
                lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString();
            }
        }

        /// <summary>
        /// Consulta Registro Seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_gru_emp.Text.Trim() == ""){
                lb_nom_gru.Text = "NO Existe";
                return;
            }

            // Obtiene Datos del Grupo Empresarial
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_con_cod(int.Parse(tb_gru_emp.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_gru.Text = "NO Existe";
                return;
            }

            lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
        }

        /// <summary>
        /// Función : Selecciona la fila en el Datagrid
        /// </summary>
        private void fi_sel_fil(string ide_rel)
        {
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
            if (ide_rel != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_rel.ToUpper())
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
                    // Al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                        {
                            // Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            // Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();
                        }
                    }
                    // Al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != 0){
                            // Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];

                            // Llama a función que actualiza datos en Textbox de Selección
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
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_gru_emp.Text = "";
                    lb_nom_gru.Text = "";
                }else{
                    tb_gru_emp.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                    lb_nom_gru.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
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
                res_fun = "El Grupo Empresarial que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_gru_emp.Focus();
                return false;
            }

            // Obtiene Datos del Grupo Empresarial
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_con_cod(int.Parse(sel_ecc));
            if (Tabla.Rows.Count == 0)
            {
                res_fun = "El Grupo Empresarial Persona que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_gru_emp.Focus();
                return false;
            }

            return true;
        }                

        private void tb_ide_rel_Validated(object sender, EventArgs e){
            fi_con_sel();
            if (lb_nom_gru.Text != "NO Existe") {
                fi_sel_fil(tb_gru_emp.Text);
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e){
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e){
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
            if (bt_ace_pta.Enabled == true) {
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
        /// Funcion Externa : Actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int ide_rel)
        {
         if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_rel.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_rel.ToString()){
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            adp018_02 frm = new adp018_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_gru_emp.Text) == false)
                return;

            adp018_03 frm = new adp018_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }       
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_gru_emp.Text) == false)
                return;

            adp018_04 frm = new adp018_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_gru_emp.Text) == false)
                return;

            adp018_05 frm = new adp018_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_gru_emp.Text) == false)
                return;

            adp018_06 frm = new adp018_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_rep_gru_Click(object sender, EventArgs e)
        {
            adp018_R01p frm = new adp018_R01p();
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
