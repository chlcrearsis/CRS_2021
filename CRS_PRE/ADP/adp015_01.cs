using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp015_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias        
        adp015 o_adp015 = new adp015();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Valida Registro Persona";

        public adp015_01()
        {
            InitializeComponent();
        }      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Datos
            Fi_des_dat();
        }

        /// <summary>
        /// Desplega Información en Pantalla
        /// </summary>
        private void Fi_des_dat() {
            // Obtiene Lista de Validacion Registro Persona
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_lis_val();
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    // Obtiene Datos del Tipo Atributo
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_nom_col"].Value = Tabla.Rows[i]["va_nom_col"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_des_col"].Value = Tabla.Rows[i]["va_des_col"].ToString().Trim();

                    // Determina que el primer registro no se pueda editar
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dg_res_ult.Rows[i].Cells["va_dat_req"];
                    if (i == 0)                    
                        cell.ReadOnly = true;                    
                    else
                    
                        cell.ReadOnly = false;                    

                    // Determina el Color del Item
                    if (Tabla.Rows[i]["va_dat_req"].ToString().CompareTo("S") == 0){
                        dg_res_ult.Rows[i].Cells["va_dat_req"].Value = true;
                        dg_res_ult.Rows[i].Cells["va_des_col"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    }else{
                        dg_res_ult.Rows[i].Cells["va_dat_req"].Value = false;
                        dg_res_ult.Rows[i].Cells["va_des_col"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > 0)
                dg_res_ult.CommitEdit(DataGridViewDataErrorContexts.Commit);

            // Determina el Color del Item
            if ((bool)dg_res_ult.CurrentCell.Value == true){
                dg_res_ult.Rows[e.RowIndex].Cells["va_dat_req"].Value = true;
                dg_res_ult.Rows[e.RowIndex].Cells["va_des_col"].Style.ForeColor = Color.FromArgb(0, 0, 192);
            }
            else{
                dg_res_ult.Rows[e.RowIndex].Cells["va_dat_req"].Value = false;
                dg_res_ult.Rows[e.RowIndex].Cells["va_des_col"].Style.ForeColor = Color.Black;
            }           
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try
            {
                // funcion para validar datos            
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    for (int i = 0; i < dg_res_ult.Rows.Count - 1; i++){
                        // Obtiene Datos del datagrid
                        DataGridViewCheckBoxCell cell = dg_res_ult.Rows[i].Cells["va_dat_req"] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(cell.Value))                        
                            o_adp015.Fe_hab_des(dg_res_ult.Rows[i].Cells["va_nom_col"].Value.ToString(), "S");                        
                        else                        
                            o_adp015.Fe_hab_des(dg_res_ult.Rows[i].Cells["va_nom_col"].Value.ToString(), "N");                        
                    }
                    MessageBox.Show("Los Datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
