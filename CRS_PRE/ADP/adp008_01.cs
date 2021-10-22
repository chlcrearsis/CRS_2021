using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp008_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        adp002 o_adp002 = new adp002();
        adp008 o_adp008 = new adp008();

        // Variables
        DataTable Tabla = new DataTable();        

        public adp008_01()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Obtiene Datos del Vendedor
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString().CompareTo("H") == 0)
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
            // Desplega Lista de Usuario
            Fi_lis_rut();
        }

        /// <summary>
        /// Desplega Lista de Rutas
        /// </summary>
        private void Fi_lis_rut()
        {
            // Obtiene Lista de Rutas p/Persona
            Tabla = new DataTable();
            Tabla = o_adp008.Fe_lis_per(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    // Obtiene Datos del Tipo Atributo
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_rut"].Value = Tabla.Rows[i]["va_ide_rut"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_rut"].Value = Tabla.Rows[i]["va_nom_rut"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_nom_cor"].Value = Tabla.Rows[i]["va_nom_cor"].ToString().Trim();                                       

                    // Determina el Color del Item
                    if (Tabla.Rows[i]["va_per_mis"].ToString().CompareTo("S") == 0){
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = true;
                        dg_res_ult.Rows[i].Cells["va_ide_rut"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_nom_rut"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_nom_cor"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    }else{
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = false;
                        dg_res_ult.Rows[i].Cells["va_ide_rut"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_nom_rut"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_nom_cor"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_cod_per.Text.Trim() == "")
            {
                return "DEBE proporcionar el Código de la Persona";
            }

            // Valida que el campo Código NO este vacio
            int cod_per;
            int.TryParse(tb_cod_per.Text, out cod_per);
            if (cod_per == 0)
            {
                return "El Código de la Persona NO es valido";
            }

            // Verifica si esta definido en el sistema
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count == 0){
                return "La Persona NO esta definido en el Sistema";
            }

            // Verifica si el registro esta habilitado
            if (tb_est_ado.Text == "Deshabilitado"){
                return "La Persona se encuentra Deshabilitado";
            }

            return "";
        }

        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_res_ult.RowCount; i++){
                dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;

                if (ch_che_tod.Checked)
                {
                    dg_res_ult.Rows[i].Cells["va_ide_rut"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[i].Cells["va_nom_rut"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[i].Cells["va_nom_cor"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                }else{
                    dg_res_ult.Rows[i].Cells["va_per_mis"].Value = false;
                    dg_res_ult.Rows[i].Cells["va_ide_rut"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[i].Cells["va_nom_rut"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[i].Cells["va_nom_cor"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool per_mis;
            if (e.ColumnIndex == 3){
                per_mis = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;

                if (per_mis == false){
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_ide_rut"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[e.RowIndex].Cells["va_nom_rut"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[e.RowIndex].Cells["va_nom_cor"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                }
                else{
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_ide_rut"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_nom_rut"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_nom_cor"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {            
            DialogResult msg_res;
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Rutas p/Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    for (int i = 0; i < dg_res_ult.RowCount; i++)
                    {
                        bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                        int ide_rut = int.Parse(dg_res_ult.Rows[i].Cells["va_ide_rut"].Value.ToString());

                        // Elimina Ruta p/Persona
                        o_adp008.Fe_eli_rut(int.Parse(tb_cod_per.Text), ide_rut);

                        // Registra Ruta p/Persona
                        if (chk_val == true){
                            o_adp008.Fe_reg_rut(int.Parse(tb_cod_per.Text), ide_rut);
                        }
                    }
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Rutas p/Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }              
    }
}
