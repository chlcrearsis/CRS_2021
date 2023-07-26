using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonario                                    */
    /*      Opción: Autorización p/Usuario                                */
    /*       Autor: JEJR - Crearsis             Fecha: 28-06-2023         */
    /**********************************************************************/
    public partial class ads004_10 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        DataTable Tabla = new DataTable();
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ads006 o_ads006 = new ads006();
        ads008 o_ads008 = new ads008();
        // Variables        
        public int vp_ide_tus = 0;  // TIPO USUARIOS (0=Todos)
        string est_bus = "H";   // Estado (H=Habilitado; N=Deshabilitado)

        public ads004_10()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Datos
            tb_ide_doc.Text = "";
            lb_nom_doc.Text = "...";
            tb_nro_tal.Text = "0";
            lb_nom_tus.Text = "...";
            lb_nom_tus.Text = "TODOS";
            cb_sel_tod.Checked = false;
            cb_est_bus.SelectedIndex = 0;
            // Despliega Datos en Pantalla
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            lb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            lb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();
            // Obtiene el nombre del Tipo de Usuario
            if (vp_ide_tus != 0){
                Tabla = new DataTable();
                Tabla = o_ads006.Fe_con_tus(vp_ide_tus);
                if (Tabla.Rows.Count > 0)
                    lb_nom_tus.Text = Tabla.Rows[0]["va_nom_tus"].ToString();
            }else { 
                lb_nom_tus.Text = "TODOS";
            }
            // Lista Usuario
            fi_lis_usr();
        }

        /// <summary>
        /// Funcion Lista Usuario Autorizado p/Talonario
        /// </summary>
        private void fi_lis_usr()
        {
            // Obtiene el estado de la busqueda
            if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";
            // Limpia Grilla
            dg_res_ult.Rows.Clear();            
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_usr_tal(vp_ide_tus, est_bus, tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_usr"].Value = Tabla.Rows[i]["va_ide_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_usr"].Value = Tabla.Rows[i]["va_nom_usr"].ToString();
                    // Verifica si esta habilitado o no
                    if (Tabla.Rows[i]["va_opc_sel"].ToString() == "S")
                        dg_res_ult.Rows[i].Cells["va_opc_sel"].Value = true;
                    else
                        dg_res_ult.Rows[i].Cells["va_opc_sel"].Value = false;
                }                
            }
        }

        // Funcion: Buscar Tipo de Usuario
        private void Fi_bus_tus()
        {
            ads006_01 frm = new ads006_01();
            frm.AccessibleName = "1";
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                vp_ide_tus = int.Parse(frm.tb_ide_tus.Text);
                Fi_obt_tus();
            }
        }

        /// <summary>
        /// Obtiene datos del Tipo de Usuario
        /// </summary>
        private void Fi_obt_tus()
        {
            // Obtiene y desplega datos del Tipo de Usuario
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_tus(vp_ide_tus);
            if (Tabla.Rows.Count == 0){
                lb_nom_tus.Text = "TODOS";
            }else{
                lb_nom_tus.Text = Tabla.Rows[0]["va_nom_tus"].ToString();
            }
            // Lista Usuario
            fi_lis_usr();
        }

        // Evento SelectedIndexChanged : Estado Usuario
        private void cb_est_bus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lista Usuario
            cb_sel_tod.Checked = false;
            fi_lis_usr();
        }

        // Evento CellContentClick : DataGridView Resultado
        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool opc_sel;   // Opcion Seleccionado
            if (e.ColumnIndex == 2)
            {
                if (dg_res_ult.Rows[e.RowIndex].Cells["va_opc_sel"].Value == null)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_opc_sel"].Value = false;

                opc_sel = (bool) dg_res_ult.Rows[e.RowIndex].Cells["va_opc_sel"].Value;

                if (opc_sel == false)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_opc_sel"].Value = true;
                else
                    dg_res_ult.Rows[e.RowIndex].Cells["va_opc_sel"].Value = false;
            }
        }                          

        // Evento Click : Button Buscar Modulo
        private void bt_tod_tus_Click(object sender, EventArgs e)
        {
            Fi_bus_tus();
        }

        // Evento CheckedChanged: Seleccionar Todos
        private void cb_sel_tod_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_res_ult.RowCount; i++)
                dg_res_ult.Rows[i].Cells["va_opc_sel"].Value = cb_sel_tod.Checked;
        }       

        // Evento Click : Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string ide_usr; // ID. Usuario

            DialogResult msg_res;
            msg_res = MessageBox.Show("Esta seguro de grabar la Información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                for (int i = 0; i < dg_res_ult.RowCount; i++)
                {                    
                    ide_usr = dg_res_ult.Rows[i].Cells["va_ide_usr"].Value.ToString();

                    // Elimina Autorizacion
                    o_ads008.Fe_eli_min(ide_usr, "ads004", tb_ide_doc.Text.Trim(), tb_nro_tal.Text.Trim());

                    // Registra Autorizacion
                    if ((bool)dg_res_ult.Rows[i].Cells["va_opc_sel"].Value)
                        o_ads008.Fe_nue_reg(ide_usr, "ads004", tb_ide_doc.Text.Trim(), tb_nro_tal.Text.Trim());
                }
                // Despliega Mensaje
                MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                // Cierra Fomulario
                cl_glo_frm.Cerrar(this);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
