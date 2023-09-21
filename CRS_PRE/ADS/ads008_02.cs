using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads008 - Permiso Usuario Talonario                    */
    /* Descripción: Permiso sobre Aplicación                              */
    /*       Autor: JEJR - Crearsis             Fecha: 30-08-2023         */
    /**********************************************************************/
    public partial class ads008_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        // Instancias
        ads008 o_ads008 = new ads008();
        ads001 o_ads001 = new ads001();

        // Variables
        DataTable Tabla = new DataTable();
        public int vp_ide_mod = 0;  // TODOS LOS MÓDULOS 
        bool vp_chk_reg = true;

        public ads008_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {            
            // Despliega Información
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            lb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
            lb_nom_mod.Text = "TODOS";
            // Obtiene el nombre del Módulo
            if (vp_ide_mod != 0){
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
                if (Tabla.Rows.Count > 0)
                    lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
            // Despliega Talonarios
            Fi_des_tal();
        }

        /// <summary>
        /// Desplega Lista de Talonarios con y sin permisos
        /// </summary>
        private void Fi_des_tal() {
            bool per_mis = true;
            dg_res_ult.Rows.Clear();
            // Obtiene Lista de Talonario
            Tabla = new DataTable();
            Tabla = o_ads008.Fe_usr_tal(tb_ide_usr.Text, vp_ide_mod);
            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                dg_res_ult.Rows.Add();
                dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = Tabla.Rows[i]["va_ide_doc"].ToString().Trim();
                dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = Tabla.Rows[i]["va_nom_doc"].ToString().Trim();
                dg_res_ult.Rows[i].Cells["va_nro_tal"].Value = Tabla.Rows[i]["va_nro_tal"].ToString().Trim();
                dg_res_ult.Rows[i].Cells["va_nom_tal"].Value = Tabla.Rows[i]["va_nom_tal"].ToString().Trim();
                if (Tabla.Rows[i]["va_per_mis"].ToString() == "S"){
                    dg_res_ult.Rows[i].Cells["va_per_mis"].Value = true;
                }else{
                    per_mis = false;
                    dg_res_ult.Rows[i].Cells["va_per_mis"].Value = false;
                }
            }

            ch_che_tod.Focus();
            ch_che_tod.Checked = per_mis;
        }

        // Verifica si todos los registros estan Checkeado
        private void Fi_ver_chk()
        {
            vp_chk_reg = true;
            for (int i = 0; i < dg_res_ult.Rows.Count; i++){
                bool chk = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                if (chk == false){
                    vp_chk_reg = false;
                    break;
                }
            }

            if (ch_che_tod.Checked != vp_chk_reg)
                ch_che_tod.Checked = vp_chk_reg;
            else
                vp_chk_reg = true;
        }

        // Evento CellContentClick: Lista de Resultado
        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value == null)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

                bool chk = (bool)dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value;

                if (chk == false)
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = true;
                else
                    dg_res_ult.Rows[e.RowIndex].Cells["va_per_mis"].Value = false;

                Fi_ver_chk();
            }
        }

        // Evento CheckedChanged: Todos los permisos
        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            if (vp_chk_reg){
                for (int i = 0; i < dg_res_ult.RowCount; i++) { 
                    dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;
                }
            }else{
                vp_chk_reg = true;
            }
        }

        // Evento Click: Cambia Módulo
        private void bt_cam_mod_Click(object sender, EventArgs e)
        {
            ads001_01 frm = new ads001_01();
            frm.AccessibleName = "1";
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                vp_ide_mod = int.Parse(frm.tb_ide_mod.Text);

                /* Desplega el nombre del modulo seleccionado */
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(vp_ide_mod);
                if (Tabla.Rows.Count > 0)
                    lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                else
                    lb_nom_mod.Text = "TODOS";

                // Despliega Talonarios
                Fi_des_tal();
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina los permisos que tiene el Usuario
                    o_ads008.Fe_eli_min(tb_ide_usr.Text.Trim(), "ads004");
                    // Asigna los permisos que el usuario ha seleccionado
                    for (int i = 0; i < dg_res_ult.RowCount; i++)
                    {
                        bool chk_val = (bool)dg_res_ult.Rows[i].Cells["va_per_mis"].Value;
                        string ide_doc = dg_res_ult.Rows[i].Cells["va_ide_doc"].Value.ToString().Trim();
                        string nro_tal = dg_res_ult.Rows[i].Cells["va_nro_tal"].Value.ToString().Trim();

                        if (chk_val == true)
                            o_ads008.Fe_nue_reg(tb_ide_usr.Text.Trim(), "ads004", ide_doc, nro_tal);
                    }
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
