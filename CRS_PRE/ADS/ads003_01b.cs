using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads003 - Definición de Documento                      */
    /* Descripción: Buscar Registro de acuerdo al Módulo                  */
    /*       Autor: JEJR - Crearsis             Fecha: 19-08-2022         */
    /**********************************************************************/
    public partial class ads003_01b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;
        // Instancia
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        DataTable Tabla = new DataTable();
        // Variables
        public int vp_ide_mod = 0;
        public string vp_ide_doc = "";

        public ads003_01b()
        {
            InitializeComponent();
        }        

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        private void fi_ini_frm()
        {
            tb_ide_doc.Text = string.Empty;
            // Obtiene el nombre del módulo a buscar
            Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
            if (Tabla.Rows.Count > 0)
                Text = "Documentos por Módulos : " + Tabla.Rows[0]["va_nom_mod"];
            else
                Text = "Documentos por Módulos : No Identificado";

            fi_bus_car(vp_ide_mod);
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ide_mod">ID. Módulo</param>
        private void fi_bus_car(int ide_mod)
        {
            // Limpia Grilla
            dg_res_ult.Rows.Clear();
           
            // Obtiene datos de la busqueda
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_mod(ide_mod, "H");
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = Tabla.Rows[i]["va_ide_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = Tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_des_doc"].Value = Tabla.Rows[i]["va_des_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_mod"].Value = Tabla.Rows[i]["va_nom_mod"].ToString();
                }
                tb_ide_doc.Text = Tabla.Rows[0]["va_ide_doc"].ToString();
            }
        }        

        private void fi_sub_baj_fil_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null) {                 
                    tb_ide_doc.Text = string.Empty;
                } else { 
                    tb_ide_doc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();                    
                }
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
            if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dg_res_ult_Enter(object sender, EventArgs e)
        {
            /*if (bt_ace_pta.Enabled == true && dg_res_ult.Rows.Count > 0){
                this.DialogResult = DialogResult.OK;
            }*/
        }

        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string ide_doc)
        {
     
            if (ide_doc != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_doc.ToUpper()){
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
