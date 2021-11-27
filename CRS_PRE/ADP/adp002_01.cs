using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp002_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        adp002 o_adp002 = new adp002();
        adp001 o_adp001 = new adp001();
        // Variables
        DataTable Tabla = new DataTable();
        string tip_per = "T";
        string est_bus = "T";
        string Titulo = "Registro de Persona";

        public adp002_01()
        {
            InitializeComponent();
        }        

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }
        
        private void fi_ini_frm()
        {
            // Iniciliza Campos en Pantalla
            tb_cod_per.Text = "";
            tb_cod_gru.Text = "0";
            lb_nom_gru.Text = "TODOS";
            cb_tip_per.Text = "TODOS";
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;

            // Obtiene datos de la consulta
            fi_bus_car(int.Parse(tb_cod_gru.Text), tip_per, tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
            
            // Limpia el texto a buscar
            tb_tex_bus.Focus();
            tb_tex_bus.SelectAll();
            SelectNextControl(tb_tex_bus, true, true, false, true);
        }

        /// <summary>
        /// Funcion : Filtra lista de persona de acuerdo a los criterios de búsqueda
        /// </summary>
        /// <param name="gru_per">Código Grupo</param>
        /// <param name="tip_per">Tipo de Cliente (P=Particular; E=Empresa; T=Todos)</param>
        /// <param name="tex_bus">Texto a ser buscado</param>
        /// <param name="prm_bus">Criterio de Busqueda (0=Cod. Persona; 1=Razon Social; 2=Nombre; 3=Ape. Paterno; 4=Ape. Materno; 5=NIT; 6=Documento; 7=Teléfono)</param>
        /// <param name="est_bus">Estado (H=Habilitado; N=Deshabilitado; T=Todos)</param>
        private void fi_bus_car(int gru_per = 0, string tip_per = "T", string tex_bus = "", int prm_bus = 0, string est_bus = "T")
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();

            // Obtiene el Tipo de Persona
            if (cb_tip_per.SelectedIndex == 0)
                tip_per = "T";  // Todos
            if (cb_tip_per.SelectedIndex == 1)
                tip_per = "P";  // Particular
            if (cb_tip_per.SelectedIndex == 2)
                tip_per = "E";  // Empresa

            // Obtiene el Estado de la Persona
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitados
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado

            // Obtiene Datos de la consulta
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_bus_car(gru_per, tip_per, tex_bus, prm_bus, est_bus);
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_per"].Value = Tabla.Rows[i]["va_cod_per"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_raz_soc"].Value = Tabla.Rows[i]["va_raz_soc"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ruc_nit"].Value = Tabla.Rows[i]["va_ruc_nit"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_bre"].Value = Tabla.Rows[i]["va_nom_bre"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ape_pat"].Value = Tabla.Rows[i]["va_ape_pat"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ape_mat"].Value = Tabla.Rows[i]["va_ape_mat"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_tip_doc"].Value = Tabla.Rows[i]["va_tip_doc"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nro_doc"].Value = Tabla.Rows[i]["va_nro_doc"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_tel_per"].Value = Tabla.Rows[i]["va_tel_per"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_cel_ula"].Value = Tabla.Rows[i]["va_cel_ula"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_tel_fij"].Value = Tabla.Rows[i]["va_tel_fij"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_dir_pri"].Value = Tabla.Rows[i]["va_dir_pri"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ema_ail"].Value = Tabla.Rows[i]["va_ema_ail"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_ven"].Value = Tabla.Rows[i]["va_nom_ven"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_cob"].Value = Tabla.Rows[i]["va_nom_cob"].ToString().Trim();
                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_cod_per.Text = Tabla.Rows[0]["va_cod_per"].ToString().Trim();
                lb_raz_soc.Text = Tabla.Rows[0]["va_raz_soc"].ToString().Trim();
                tb_tex_bus.Focus();
                tb_tex_bus.SelectAll();
            }
        }
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_cod_per.Text.Trim() == "") {
                lb_raz_soc.Text = "No Existe";
                return;
            }

            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count == 0) {
                lb_raz_soc.Text = "No Existe";
                return;
            }
            
            lb_raz_soc.Text = Tabla.Rows[0]["va_raz_soc"].ToString().Trim();
        }

        /// <summary>
        /// Función : Selecciona la fila en el Datagrid
        /// </summary>
        private void fi_sel_fil(string cod_per)
        {
            // Obtiene el Tipo de Persona
            if (cb_tip_per.SelectedIndex == 0)
                tip_per = "T";  // Todos
            if (cb_tip_per.SelectedIndex == 1)
                tip_per = "P";  // Particular
            if (cb_tip_per.SelectedIndex == 2)
                tip_per = "E";  // Empresa

            // Obtiene el Estado de la Persona
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitado
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado            

            Tabla = new DataTable();
            fi_bus_car(int.Parse(tb_cod_gru.Text), tip_per, tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
            if (cod_per != null){
                try{
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++){
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_per.ToUpper()) {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            tb_tex_bus.Focus();
        }
       
        /// <summary>
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0) {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null) {
                    tb_cod_per.Text = "";
                    lb_raz_soc.Text = "";
                } else {
                    tb_cod_per.Text = dg_res_ult.SelectedRows[0].Cells["va_cod_per"].Value.ToString();
                    lb_raz_soc.Text = dg_res_ult.SelectedRows[0].Cells["va_raz_soc"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Método : Verifica concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat(string cod_per)
        {
            string res_fun;
            if (cod_per.Trim() == ""){
                res_fun = "La Persona que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_per.Focus();
                return false;
            }

            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(cod_per));
            if (Tabla.Rows.Count == 0){
                res_fun = "La Persona que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_per.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Método : Obtiene Datos del Grupo de Persona
        /// </summary>
        private void Fi_obt_gru()
        {
            if (tb_cod_gru.Text.Trim() == ""){
                MessageBox.Show("DEBE proporcionar un Grupo de Persona válido", Titulo, MessageBoxButtons.OK);
                tb_cod_gru.Focus();
            }

            if (tb_cod_gru.Text.Trim() == "" || tb_cod_gru.Text.Trim() == "0" || tb_cod_gru.Text.Trim() == "00"){
                tb_cod_gru.Text = "0";
                lb_nom_gru.Text = "TODOS";
            }else{
                int dat_num;
                int.TryParse(tb_cod_gru.Text, out dat_num);
                if (dat_num == 0){
                    MessageBox.Show("DEBE proporcionar un Grupo de persona valido", Titulo, MessageBoxButtons.OK);
                    tb_cod_gru.Focus();
                }

                Tabla = new DataTable();
                Tabla = o_adp001.Fe_con_gru(dat_num);
                if (Tabla.Rows.Count == 0)
                    lb_nom_gru.Text = "No Existe";
                else
                    lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString();
            }
        }

        // Evento KeyDown: Texto a Buscar
        private void tb_tex_bus_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0){
                try{
                    // Al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down){
                        dg_res_ult.Show();
                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1){
                            // Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];
                            // Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();
                        }
                    }
                    //al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up){
                        dg_res_ult.Show();
                        if (dg_res_ult.SelectedRows[0].Index != 0){
                            // Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];
                            // Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK);
                }
            }
        }

        // Evento Validated: Codigo de Persona
        private void tb_cod_per_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_raz_soc.Text != "No Existe"){
                fi_sel_fil(tb_cod_per.Text);
            }
        }

        // Evento KeyPress: Codigo de Persona
        private void tb_cod_per_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown: Codigo Grupo Persona
        private void tb_cod_gru_KeyDown(object sender, KeyEventArgs e)
        {
            // Al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down){
                // Abre la ventana Busca Persona
                Fi_bus_gru();
            }
        }

        // Evento KeyPress: Codigo Grupo Persona
        private void tb_cod_gru_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Validated: Codigo Grupo Persona
        private void tb_cod_gru_Validated(object sender, EventArgs e)
        {
            Fi_obt_gru();
        }

        // Evento Click: Buscar Grupo Persona
        private void bt_bus_gru_Click(object sender, EventArgs e)
        {
            Fi_bus_gru();
        }

        /// <summary>
        /// Función : Buscar Grupo Persona
        /// </summary>
        private void Fi_bus_gru()
        {
            adp001_01 frm = new adp001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_cod_gru.Text = frm.tb_cod_gru.Text;
                lb_nom_gru.Text = frm.lb_nom_gru.Text;
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e){
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e){
            fi_fil_act();
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e){
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Buscar
        private void bt_bus_car_Click(object sender, EventArgs e)
        {
            // Obtiene el Tipo de Persona
            if (cb_tip_per.SelectedIndex == 0)
                tip_per = "T";  // Todos
            if (cb_tip_per.SelectedIndex == 1)
                tip_per = "P";  // Particular
            if (cb_tip_per.SelectedIndex == 2)
                tip_per = "E";  // Empresa

            // Obtiene el Estado de la Persona
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitado
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado 

            fi_bus_car(int.Parse(tb_cod_gru.Text), tip_per, tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int cod_per)
        {
            // Obtiene el Tipo de Persona
            if (cb_tip_per.SelectedIndex == 0)
                tip_per = "T";  // Todos
            if (cb_tip_per.SelectedIndex == 1)
                tip_per = "P";  // Particular
            if (cb_tip_per.SelectedIndex == 2)
                tip_per = "E";  // Empresa

            // Obtiene el Estado de la Persona
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitado
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado 

            fi_bus_car(int.Parse(tb_cod_gru.Text), tip_per, tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (cod_per.ToString() != null){
                try{
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++){
                        if ( dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_per.ToString()){
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            adp002_02 frm = new adp002_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp002_03 frm = new adp002_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }       
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp002_04 frm = new adp002_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp002_05 frm = new adp002_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp002_06 frm = new adp002_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_act_rut_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp008_01 frm = new adp008_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_per_lis_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp009_01 frm = new adp009_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_ima_per_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp006_01 frm = new adp006_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);
        }
        private void mn_con_per_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp013_01 frm = new adp013_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);
        }
      
        private void mn_ins_lib_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            ecp003_01 frm = new ecp003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);
        }
        private void mn_asi_emp_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_per.Text) == false)
                return;

            adp012_02 frm = new adp012_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_list_per_Click(object sender, EventArgs e)
        {
            //adp002_R01p frm = new adp002_R01p();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Evento Enter: Lista de Resultado
        private void dg_res_ult_Enter(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
