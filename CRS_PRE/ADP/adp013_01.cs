using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp013_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public dynamic frm_MDI;

        string est_bus = "T";
        string Titulo = "Contacto Persona";

        //Form frm_mdi;
        public adp013_01()
        {
            InitializeComponent();
        }

        // Instancia
        adp013 o_adp013 = new adp013();

        // Variables
        DataTable Tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }
        
        private void fi_ini_frm()
        {
            // Iniciliza Campos en Pantalla            
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_cod_con.Text = string.Empty;

            // Desplega Datos del Cliente
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();

            // Obtiene datos de la consulta
            fi_bus_car(int.Parse(tb_cod_per.Text), tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
            
            // Limpia el texto a buscar
            tb_tex_bus.Focus();
            tb_tex_bus.SelectAll();
            SelectNextControl(tb_tex_bus, true, true, false, true);
        }

        /// <summary>
        /// Funcion : Filtra lista de persona de acuerdo a los criterios de búsqueda
        /// </summary>
        /// <param name="cod_per">Código Persona</param>
        /// <param name="tex_bus">Texto a ser buscado</param>
        /// <param name="prm_bus">Criterio de Busqueda (0=Cod. Persona; 1=Razon Social; 2=Nombre; 3=Ape. Paterno; 4=Ape. Materno; 5=NIT; 6=Documento; 7=Teléfono)</param>
        /// <param name="est_bus">Estado (H=Habilitado; N=Deshabilitado; T=Todos)</param>
        private void fi_bus_car(int cod_per = 0, string tex_bus = "", int prm_bus = 0, string est_bus = "T")
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();            

            // Obtiene el Estado de la Persona
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitados
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado

            // Obtiene Datos de la consulta
            Tabla = new DataTable();
            Tabla = o_adp013.Fe_bus_car(cod_per, tex_bus, prm_bus, est_bus);
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_con"].Value = Tabla.Rows[i]["va_cod_con"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_bre"].Value = Tabla.Rows[i]["va_nom_bre"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ape_pat"].Value = Tabla.Rows[i]["va_ape_pat"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ape_mat"].Value = Tabla.Rows[i]["va_ape_mat"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_par_con"].Value = Tabla.Rows[i]["va_par_con"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nro_cid"].Value = Tabla.Rows[i]["va_nro_cid"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_tel_per"].Value = Tabla.Rows[i]["va_tel_per"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_cel_ula"].Value = Tabla.Rows[i]["va_cel_ula"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_dir_ubi"].Value = Tabla.Rows[i]["va_dir_ubi"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_ema_ail"].Value = Tabla.Rows[i]["va_ema_ail"].ToString().Trim();                    
                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_cod_con.Text = Tabla.Rows[0]["va_cod_con"].ToString().Trim();
                lb_nom_con.Text = Tabla.Rows[0]["va_nom_bre"].ToString().Trim() + " " +
                                  Tabla.Rows[0]["va_ape_pat"].ToString().Trim() + " " +
                                  Tabla.Rows[0]["va_ape_mat"].ToString().Trim();
                tb_tex_bus.Focus();
                tb_tex_bus.SelectAll();
            }
        }
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_cod_con.Text.Trim() == "") {
                tb_cod_con.Text = "0";
                lb_nom_con.Text = "Ningún Registro";
                return;
            }

            Tabla = new DataTable();
            Tabla = o_adp013.Fe_con_con(int.Parse(tb_cod_per.Text), int.Parse(tb_cod_con.Text));
            if (Tabla.Rows.Count == 0) {
                tb_cod_con.Text = "0";
                lb_nom_con.Text = "Ningún Registro";
                return;
            }
            
            lb_nom_con.Text = Tabla.Rows[0]["va_nom_bre"].ToString().Trim() + " " +
                              Tabla.Rows[0]["va_ape_pat"].ToString().Trim() + " " +
                              Tabla.Rows[0]["va_ape_mat"].ToString().Trim();
        }

        /// <summary>
        /// Función : Selecciona la fila en el Datagrid
        /// </summary>
        private void fi_sel_fil(string cod_per)
        {            
            // Obtiene el Estado de la Persona
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitado
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado            

            Tabla = new DataTable();
            fi_bus_car(int.Parse(tb_cod_per.Text), tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
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
                    tb_cod_con.Text = "";
                    lb_nom_con.Text = "";
                } else {
                    tb_cod_con.Text = dg_res_ult.SelectedRows[0].Cells["va_cod_con"].Value.ToString();
                    lb_nom_con.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_bre"].Value.ToString() + " " +
                                      dg_res_ult.SelectedRows[0].Cells["va_ape_pat"].Value.ToString() + " " +
                                      dg_res_ult.SelectedRows[0].Cells["va_ape_mat"].Value.ToString();
                }
            }
        }

        /// <summary>
        /// Método : Verifica concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat(string cod_per, string cod_con)
        {
            string res_fun;
            if (cod_per.Trim() == ""){
                res_fun = "La Persona del Contacto que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cod_per.Trim() == ""){
                res_fun = "El Contacto de la Persona que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Tabla = new DataTable();
            Tabla = o_adp013.Fe_con_con(int.Parse(cod_per), int.Parse(cod_con));
            if (Tabla.Rows.Count == 0){
                res_fun = "El Contacto de Persona que desea editar, NO se encuentra registrado";
                MessageBox.Show(res_fun, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cod_con.Focus();
                return false;
            }
            return true;
        }        

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

        private void tb_cod_con_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_con.Text != "Ningún Registro"){
                fi_sel_fil(tb_cod_con.Text);
            }
        }

        private void tb_cod_con_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
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

        private void bt_bus_car_Click(object sender, EventArgs e)
        {            
            // Obtiene el Estado de la Persona
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitado
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado 

            fi_bus_car(int.Parse(tb_cod_per.Text), tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string cod_con)
        {    
            // Obtiene el Estado del Filtro
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";  // Todos
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";  // Habilitado
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";  // Deshabilitado 

            fi_bus_car(int.Parse(tb_cod_per.Text), tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (cod_con.ToString() != null){
                try{
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++){
                        if ( dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_con.ToString()){
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

        private void Mn_cre_ar_Click(object sender, EventArgs e)
        {
            adp013_02 frm = new adp013_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, frm_dat);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_cod_per.Text, tb_cod_con.Text) == false)
                return;

            adp013_03 frm = new adp013_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
       
        private void Mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_cod_per.Text, tb_cod_con.Text) == false)
                return;

            adp013_04 frm = new adp013_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_cod_per.Text, tb_cod_con.Text) == false)
                return;

            adp013_05 frm = new adp013_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para eliminar
            if (fi_ver_dat(tb_cod_per.Text, tb_cod_con.Text) == false)
                return;

            adp013_06 frm = new adp013_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }        

        private void Mn_cer_rar_Click(object sender, EventArgs e)
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
