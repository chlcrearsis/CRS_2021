using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads004_02c : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        DataTable Tabla = new DataTable();
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        // Variables
        public int vp_ide_mod = 0;  // TODOS LOS MÓDULOS

        public ads004_02c()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Inicializa Datos
            tb_ide_mod.Text = "0";
            lb_nom_mod.Text = "TODOS";                     
            cb_tod_mes.Checked = false;
            cb_tod_año.Checked = false;
            // Obtiene el nombre del Módulo
            if (vp_ide_mod != 0){
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
                if (Tabla.Rows.Count > 0) { 
                    tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
                    lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                }
            }
            // Lista Documentos
            fi_lis_doc();
        }

        /// <summary>
        /// Funcion Lista Documento Sin Talonario
        /// </summary>
        private void fi_lis_doc()
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();            
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_lis_dst(vp_ide_mod, "1");
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = Tabla.Rows[i]["va_ide_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = Tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_sel_año"].Value = false;
                    dg_res_ult.Rows[i].Cells["va_sel_mes"].Value = false;
                }                
            }
        }

        // Funcion: Buscar Módulo
        private void Fi_bus_mod()
        {
            ads001_01 frm = new ads001_01();
            frm.AccessibleName = "1";
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                vp_ide_mod = int.Parse(frm.tb_ide_mod.Text);
                Fi_obt_mod();
            }
        }

        /// <summary>
        /// Obtiene datos del Módulo
        /// </summary>
        private void Fi_obt_mod()
        {
            // Obtiene y desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
            if (Tabla.Rows.Count == 0){
                tb_ide_mod.Text = "0";
                lb_nom_mod.Text = "TODOS";
            }else{
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
                lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
            // Lista Documentos
            fi_lis_doc();
        }

        // Evento CellContentClick : DataGridView Resultado
        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool sel_mes;   // Seleccionar Mes
            bool sel_año;   // Seleccionar Año
            switch (e.ColumnIndex) {
                case 2: // Celda Año
                    if (dg_res_ult.Rows[e.RowIndex].Cells["va_sel_año"].Value == null)
                        dg_res_ult.Rows[e.RowIndex].Cells["va_sel_año"].Value = false;

                    sel_año = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_sel_año"].Value;

                    if (sel_año == false)
                        dg_res_ult.Rows[e.RowIndex].Cells["va_sel_año"].Value = true;
                    else
                        dg_res_ult.Rows[e.RowIndex].Cells["va_sel_año"].Value = false;
                    break;
                case 3: // Celda Mes
                    if (dg_res_ult.Rows[e.RowIndex].Cells["va_sel_mes"].Value == null)
                        dg_res_ult.Rows[e.RowIndex].Cells["va_sel_mes"].Value = false;

                    sel_mes = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_sel_mes"].Value;

                    if (sel_mes == false)
                        dg_res_ult.Rows[e.RowIndex].Cells["va_sel_mes"].Value = true;
                    else
                        dg_res_ult.Rows[e.RowIndex].Cells["va_sel_mes"].Value = false;
                    break;
                
            }
        }
                      
        // Evento Validated : ID. Módulo
        private void tb_ide_mod_Validated(object sender, EventArgs e)
        {
            if (tb_ide_mod.Text != "0")            
                vp_ide_mod = int.Parse(tb_ide_mod.Text);
            else 
                vp_ide_mod = 0;

            Fi_obt_mod();
        }

        // Evento KeyPress : ID. Módulo
        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown : ID. Módulo
        private void tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                // Abre la ventana Busca Modulo
                Fi_bus_mod();
            }
        }

        // Evento Click : Button Buscar Modulo
        private void bt_bus_mod_Click(object sender, EventArgs e)
        {
            // Abre la ventana Busca Modulo
            Fi_bus_mod();
        }

        // Evento CheckedChanged: Todos Mes
        private void cb_tod_mes_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_res_ult.RowCount; i++)
                dg_res_ult.Rows[i].Cells["va_sel_mes"].Value = cb_tod_mes.Checked;
        }

        // Evento CheckedChanged: Todos Año
        private void cb_tod_año_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_res_ult.RowCount; i++)
                dg_res_ult.Rows[i].Cells["va_sel_año"].Value = cb_tod_año.Checked;
        }

        // Evento Click : Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string tal_anu; // Talonario Anual
            string tal_men; // Talonraio Mensual
            string ide_doc; // ID. Documento
              bool sel_año; // Sel. Año
              bool sel_mes; // Sel. Mensual

            DialogResult msg_res;
            msg_res = MessageBox.Show("Esta seguro de grabar la Información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                for (int i = 0; i < dg_res_ult.RowCount; i++)
                {                    
                    ide_doc = dg_res_ult.Rows[i].Cells["va_ide_doc"].Value.ToString();                    
                    sel_año = (bool) dg_res_ult.Rows[i].Cells["va_sel_año"].Value;
                    sel_mes = (bool) dg_res_ult.Rows[i].Cells["va_sel_mes"].Value;

                    if (sel_año)
                        tal_anu = "S";
                    else
                        tal_anu = "N";

                    if (sel_mes)
                        tal_men = "S";
                    else
                        tal_men = "N";

                    // Graba registro
                    o_ads004.Fe_nue_aut(ide_doc, tal_anu, tal_men);
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
