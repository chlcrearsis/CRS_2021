using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp004 - Definición de Atributos                      */
    /*      Opción: Buscar Registro                                       */
    /*       Autor: JEJR - Crearsis             Fecha: 01-09-2021         */
    /**********************************************************************/
    public partial class adp004_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable Tabla;
        public dynamic frm_MDI;
        // Instancia        
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        // Variables
        string est_bus = "H";
        public int vp_ide_tip = 0;

        public adp004_01()
        {
            InitializeComponent();
        }             

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        private void fi_ini_frm()
        {
            tb_ide_tip.Text = string.Empty;
            lb_nom_tip.Text = string.Empty;
            tb_ide_atr.Text = string.Empty;
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 1;
            fi_obt_tip("");
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }       

        /// <summary>
        /// Función: Obtiene el tipo de atributo
        /// </summary>
        private void fi_obt_tip(string ide_tip){
            Tabla = new DataTable();            
            Tabla = o_adp003.Fe_bus_car(ide_tip, 0, "0");
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                lb_nom_tip.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
                vp_ide_tip = int.Parse(tb_ide_tip.Text.ToString());
            }else {
                lb_nom_tip.Text = "NO Existe";
                vp_ide_tip = 0;
            }        
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
            tb_ide_atr.Text = string.Empty;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            Tabla = new DataTable();
            Tabla = o_adp004.Fe_bus_car(vp_ide_tip, tex_bus, prm_bus, est_bus);           
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_atr"].Value = Tabla.Rows[i]["va_ide_atr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_atr"].Value = Tabla.Rows[i]["va_nom_atr"].ToString();

                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_ide_atr.Text = Tabla.Rows[0]["va_ide_atr"].ToString();               
            }
        }

        /// <summary>
        /// Función : Consulta Registro Seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_tip.Text.Trim() == ""){
                lb_nom_tip.Text = "NO Existe";
                return;
            }

            Tabla = o_adp004.Fe_con_atr(int.Parse(tb_ide_tip.Text), int.Parse(tb_ide_atr.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_tip.Text = "NO Existe";
                return;
            }
        }
        /// <summary>
        /// Función : Selecciona la fila en el Datagrid
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
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_gru.ToUpper())
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

        /// <summary>
        /// Función : Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act(){
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_ide_atr.Text = "";
                }else{
                    tb_ide_atr.Text = dg_res_ult.SelectedRows[0].Cells["va_ide_atr"].Value.ToString().Trim();
                }
            }
        }

        /// <summary>
        /// Método : Verifica concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat(string sel_ecc)
        {
            string res_fun;
            if (sel_ecc.Trim() == ""){
                res_fun = "El Atributo que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Edita Tipo de Atributo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_tip.Focus();
                return false;
            }


            Tabla = o_adp004.Fe_con_atr(int.Parse(tb_ide_tip.Text.Trim()), int.Parse(sel_ecc));
            if (Tabla.Rows.Count == 0)
            {
                res_fun = "El Atributo que desea editar, no se encuentra registrado";
                MessageBox.Show(res_fun, "Edita Tipo de Atributo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_ide_tip.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Función: Obtiene Datos del Tipo de Atributo
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        private void Fi_obt_tip(int ide_tip){
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(ide_tip);
            if (Tabla.Rows.Count > 0){
                tb_ide_tip.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                lb_nom_tip.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
                vp_ide_tip = int.Parse(tb_ide_tip.Text);
                fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
            }
            else{
                lb_nom_tip.Text = "NO Existe";
                vp_ide_tip = 0;
                MessageBox.Show("El Tipo de Atributo NO está definido en la base de datos", Text, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Función: Buscar Tipo de Atributo
        /// </summary>
        void Fi_bus_tip(){
            adp003_01 frm = new adp003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_tip.Text = frm.tb_ide_tip.Text;
                Fi_obt_tip(Int32.Parse(tb_ide_tip.Text));
            }
        }

        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int ide_gru){
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_gru.ToString() != null){
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++){
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_gru.ToString()){
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

        private void tb_ide_tip_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_sel_bus_Validated(object sender, EventArgs e)
        {                       
            lb_nom_tip.Text = string.Empty;
            tb_ide_atr.Text = string.Empty;
            fi_obt_tip(tb_ide_tip.Text);
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
        }

        private void bt_bus_tip_Click(object sender, EventArgs e)
        {
            Fi_bus_tip();
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
            if (bt_ace_pta.Enabled == true) {
                this.DialogResult = DialogResult.OK;
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

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
        }                        

        private void mn_nue_reg_Click(object sender, EventArgs e)
        {
            adp004_02 frm = new adp004_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat(tb_ide_atr.Text) == false)
                return;

            adp004_03 frm = new adp004_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }       
        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            if (fi_ver_dat(tb_ide_atr.Text) == false)
                return;

            adp004_04 frm = new adp004_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_atr.Text) == false)
                return;

            adp004_05 frm = new adp004_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat(tb_ide_atr.Text) == false)
                return;

            adp004_06 frm = new adp004_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void mn_lis_atr_Click(object sender, EventArgs e)
        {           
            adp004_R01p frm = new adp004_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void mn_cer_rar_Click(object sender, EventArgs e){
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e){
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }        
    }
}
