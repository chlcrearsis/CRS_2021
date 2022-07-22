using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp004 - Definición de Atributos                      */
    /*      Opción: Busca Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 01-09-2021         */
    /**********************************************************************/
    public partial class adp004_07 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public dynamic frm_MDI;
        // Instancia                
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        DataTable Tabla = new DataTable();
        // Variables
        string est_bus = "T";
        public int vp_ide_tip = 0;

        public adp004_07()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }
    
        private void fi_ini_frm(){
            tb_ide_atr.Text = "";
            lb_nom_atr.Text = "";
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            Text = "Busca Atributo : " + fi_obt_tip();
            fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);          
        }

        public enum parametro
        {
            codigo = 1, nombre = 2
        }
        protected enum estado
        {
            Todos = 0, Habilitado = 1, Deshabilitado = 2
        }

        /// <summary>
        /// Obtiene el nombre del Tipo de Atributo
        /// </summary>
        /// <returns></returns>
        private string fi_obt_tip() {
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(vp_ide_tip);
            if (Tabla.Rows.Count > 0){
                return Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
            }else {
                return string.Empty;
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

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            // Obtiene registros
            o_adp004 = new adp004();
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
                lb_nom_atr.Text = Tabla.Rows[0]["va_nom_atr"].ToString();
            }
        }

        /// <summary>
        /// Función: Consulta registro seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            // Verifica que los datos en pantallas sean correctos
            if (tb_ide_atr.Text.Trim() == ""){
                lb_nom_atr.Text = "** NO Existe";
                return;
            }

            Tabla = o_adp004.Fe_con_atr(vp_ide_tip, int.Parse(tb_ide_atr.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_atr.Text = "** NO Existe";
                return;
            }
            tb_ide_atr.Text = Tabla.Rows[0]["va_ide_atr"].ToString();
            lb_nom_atr.Text = Tabla.Rows[0]["va_nom_atr"].ToString();
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
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
                    tb_ide_atr.Text = "0";
                    lb_nom_atr.Text = "";
                }else{
                    tb_ide_atr.Text = dg_res_ult.SelectedRows[0].Cells["va_ide_atr"].Value.ToString().Trim();
                    lb_nom_atr.Text = dg_res_ult.SelectedRows[0].Cells["va_nom_atr"].Value.ToString().Trim();
                }
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

        private void Bt_bus_car_Click(object sender, EventArgs e){
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);
        }        

        private void tb_ide_atr_KeyPress(object sender, KeyPressEventArgs e){
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_ide_atr_Leave(object sender, EventArgs e){
            
        }

        private void tb_ide_atr_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_nom_atr.Text != "S/N")
            {
                fi_sel_fil(tb_ide_atr.Text);
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
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
