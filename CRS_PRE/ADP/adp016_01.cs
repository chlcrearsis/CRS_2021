using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp016_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp001 o_adp001 = new adp001();
        adp016 o_adp016 = new adp016();
        // Variables
        DataTable Tabla = new DataTable();        

        public adp016_01()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Obtiene Datos del Grupo de Persona
            tb_cod_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString();
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString().CompareTo("H") == 0)
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
            // Desplega Lista de Libretas
            Fi_lis_lib();
        }

        /// <summary>
        /// Desplega Lista de Libretas Autorizadas al Grupo
        /// </summary>
        private void Fi_lis_lib()
        {
            // Obtiene Lista de Libretas
            Tabla = new DataTable();
            Tabla = o_adp016.Fe_lis_lib(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count > 0){
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    // Obtiene Datos del Tipo Atributo
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_lib"].Value = Tabla.Rows[i]["va_cod_lib"].ToString().Trim();
                    dg_res_ult.Rows[i].Cells["va_des_lib"].Value = Tabla.Rows[i]["va_des_lib"].ToString().Trim();

                    if (Tabla.Rows[i]["va_tip_lib"].ToString().CompareTo("B") == 0)
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Ctas. p/Cobrar";
                    else
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Ctas. p/Pagar";

                    if (Tabla.Rows[i]["va_mon_lib"].ToString().CompareTo("B") == 0)
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Value = "Bs.";
                    else
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Value = "Us.";             

                    // Determina el Color del Item
                    if (Tabla.Rows[i]["va_per_mis"].ToString().CompareTo("S") == 0){
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = true;
                        dg_res_ult.Rows[i].Cells["va_cod_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_des_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    }else{
                        dg_res_ult.Rows[i].Cells["va_per_mis"].Value = false;
                        dg_res_ult.Rows[i].Cells["va_cod_lib"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_des_lib"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){
            if (tb_cod_gru.Text.Trim() == ""){
                return "DEBE proporcionar el Código del Grupo de Persona";
            }

            // Valida que el campo Código NO este vacio
            int cod_gru;
            int.TryParse(tb_cod_gru.Text, out cod_gru);
            if (cod_gru == 0){
                return "El Código del Grupo de Persona NO es válido";
            }

            // Verifica si esta definido en el sistema
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count == 0){
                return "El Grupo de Persona NO esta definido en el Sistema";
            }

            // Verifica si el registro esta habilitado
            if (tb_est_ado.Text == "Deshabilitado"){
                return "El Grupo de Persona se encuentra Deshabilitado";
            }

            return "";
        }

        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dg_res_ult.RowCount; i++){
                dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;

                if (ch_che_tod.Checked) { 
                    dg_res_ult.Rows[i].Cells["va_cod_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[i].Cells["va_des_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[i].Cells["va_tip_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[i].Cells["va_mon_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                }else{
                    dg_res_ult.Rows[i].Cells["va_cod_lib"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[i].Cells["va_des_lib"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[i].Cells["va_tip_lib"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[i].Cells["va_mon_lib"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool per_mis;
            if (e.ColumnIndex == 4){
                per_mis = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;

                if (per_mis == false) { 
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_cod_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[e.RowIndex].Cells["va_des_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[e.RowIndex].Cells["va_tip_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    dg_res_ult.Rows[e.RowIndex].Cells["va_mon_lib"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                }else { 
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_cod_lib"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_des_lib"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_tip_lib"].Style.ForeColor = Color.Black;
                    dg_res_ult.Rows[e.RowIndex].Cells["va_mon_lib"].Style.ForeColor = Color.Black;
                }
            }
        }

        // Evento Click: Button Aceptar
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

                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Inscripción Automática p/Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK){
                    for (int i = 0; i < dg_res_ult.RowCount; i++)
                    {
                        bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                        int cod_lib = int.Parse(dg_res_ult.Rows[i].Cells["va_cod_lib"].Value.ToString());

                        // Elimina inscripción automatica
                        o_adp016.Fe_eli_min(int.Parse(tb_cod_gru.Text), cod_lib);

                        // Registra inscripción automatica
                        if (chk_val == true)
                        {
                            o_adp016.Fe_nue_reg(int.Parse(tb_cod_gru.Text), cod_lib);
                        }
                    }
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Inscripción Automática p/Grupo de Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }              
    }
}
