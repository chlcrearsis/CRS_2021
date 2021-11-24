﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp007_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp007 o_adp007 = new adp007();
        // Variables
        DataTable Tabla = new DataTable();
        string Titulo = "Edita Tipo de Atributo";

        public adp007_04()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_rut.Text = frm_dat.Rows[0]["va_ide_rut"].ToString().Trim();
            tb_nom_rut.Text = frm_dat.Rows[0]["va_nom_rut"].ToString().Trim();
            tb_nom_cor.Text = frm_dat.Rows[0]["va_nom_cor"].ToString().Trim();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Función: Valida Datos
        protected string Fi_val_dat(){
            Tabla = new DataTable();
            Tabla = o_adp007.Fe_con_rut(int.Parse(tb_ide_rut.Text));
            if (Tabla.Rows.Count == 0){
                return "La Definición de Ruta NO se encuentra en la base de datos";
            }

            return "";
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e){
            DialogResult msg_res;

            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Esta seguro de Deshabilitar la Definición de Ruta?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Esta seguro de Habilitar la Definición de Ruta?", Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK){
                    if (tb_est_ado.Text == "Habilitado")
                        o_adp007.Fe_hab_des(int.Parse(tb_ide_rut.Text), "N");
                    else
                        o_adp007.Fe_hab_des(int.Parse(tb_ide_rut.Text), "H");

                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualiza Ventana Buscar
                    frm_pad.Fe_act_frm(int.Parse(tb_ide_rut.Text));
                    // Cierra la Ventana
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra la Ventana
            cl_glo_frm.Cerrar(this);
        }
    }
}
    
