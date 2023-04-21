﻿using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE;

namespace CRS_PRE
{
    public partial class cmr003_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        cmr003 o_cmr003 = new cmr003();
        
        DataTable tab_cmr003 = new DataTable();  // Tabla Persona

        public cmr003_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_suc.Text = frm_dat.Rows[0]["va_ide_suc"].ToString();
            tb_nom_suc.Text = frm_dat.Rows[0]["va_nom_suc"].ToString();
            tb_des_suc.Text = frm_dat.Rows[0]["va_des_suc"].ToString();
            tb_ciu_suc.Text = frm_dat.Rows[0]["va_ciu_suc"].ToString();
            tb_dto_suc.Text = frm_dat.Rows[0]["va_dto_suc"].ToString();
            tb_dir_suc.Text = frm_dat.Rows[0]["va_dir_suc"].ToString();
            tb_enc_suc.Text = frm_dat.Rows[0]["va_enc_suc"].ToString();
            tb_tel_suc.Text = frm_dat.Rows[0]["va_tel_suc"].ToString();
            tb_cel_suc.Text = frm_dat.Rows[0]["va_cel_suc"].ToString();

            tb_cla_wif.Text = frm_dat.Rows[0]["va_cla_wif"].ToString();
           

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_suc.Focus();
        }

        protected string Fi_val_dat()
        {
            if (tb_nom_suc.Text.Trim()=="")
            {
                tb_nom_suc.Focus();
                return "Debe proporcionar el nombre para la sucursal";
            }
           

          return  "";

        }
             
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita sucursal", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita sucursal
                o_cmr003.Fe_edi_suc(tb_ide_suc.Text, tb_nom_suc.Text, tb_des_suc.Text, tb_dto_suc.Text, tb_ciu_suc.Text,
                    tb_dir_suc.Text, tb_enc_suc.Text,tb_tel_suc.Text, tb_cel_suc.Text, tb_cla_wif.Text);

                MessageBox.Show("Los datos se grabaron correctamente", "Edita sucursal", MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                frm_pad.Fe_act_frm(tb_ide_suc.Text);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
