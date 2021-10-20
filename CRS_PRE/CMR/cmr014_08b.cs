using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr014_08b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        ads008 o_ads008 = new ads008();

        // Variables
        DataTable Tabla = new DataTable();        

        public cmr014_08b()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Obtiene Datos del Vendedor
            tb_cod_cob.Text = frm_dat.Rows[0]["va_cod_ide"].ToString();
            tb_nom_cob.Text = frm_dat.Rows[0]["va_nom_bre"].ToString();
            // Desplega Lista de Usuario
            Fi_lis_usr();
        }

        /// <summary>
        /// Desplega Lista de Usuario
        /// </summary>
        private void Fi_lis_usr()
        {
            // Obtiene Lista de Validacion Registro Persona
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_lis_usr(2, int.Parse(tb_cod_cob.Text));
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    // Obtiene Datos del Tipo Atributo
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_usr"].Value = Tabla.Rows[i]["va_ide_usr"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_usr"].Value = Tabla.Rows[i]["va_nom_usr"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_tip"].Value = Tabla.Rows[i]["va_nom_tip"].ToString().Trim();

                    // Determina que el primer registro no se pueda editar
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dg_res_ult.Rows[i].Cells["va_per_mis"];
                    if (i == 0)
                        cell.ReadOnly = true;
                    else
                        cell.ReadOnly = false;

                    // Determina el Color del Item
                    if (Tabla.Rows[i]["va_per_mis"].ToString().CompareTo("S") == 0){
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = true;
                        dg_res_ult.Rows[i].Cells["va_ide_usr"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_nom_usr"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_nom_tip"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    }else{
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = false;
                        dg_res_ult.Rows[i].Cells["va_ide_usr"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_nom_usr"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_nom_tip"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_res_ult.RowCount; i++){
                dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;
            }
        }

        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool per_mis;
            if (e.ColumnIndex == 3){
                per_mis = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;

                if (per_mis == false)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                else
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {            
            DialogResult msg_res;
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Permiso Usuario p/Vendedor", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK){                
                for (int i = 0; i < dg_res_ult.RowCount ; i++){
                    bool chk_val = (bool) dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                    string ide_usr = Tabla.Rows[i]["va_ide_usr"].ToString();

                    // Elimina el permiso
                    o_ads008.Fe_ads008_04(ide_usr, "cmr014", "2", tb_cod_cob.Text);

                    // Habilita Permiso s/Usuario SI esta autorizado
                    if (chk_val == true){
                        o_ads008.Fe_ads008_03(ide_usr, "cmr014", "2", tb_cod_cob.Text, "");
                    }                    
                }
                cl_glo_frm.Cerrar(this);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }              
    }
}
