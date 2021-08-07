﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG;
using CRS_NEG;

namespace CRS_PRE.INV
{
    public partial class inv003_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        inv003 o_inv003 = new inv003();

        DataTable tabla = new DataTable();

        public inv003_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_fam.Text = frm_dat.Rows[0]["va_cod_fam"].ToString();
            tb_nom_fam.Text = frm_dat.Rows[0]["va_nom_fam"].ToString();

            if (frm_dat.Rows[0]["va_tip_fam"].ToString() == "M")
                tb_tip_fam.Text = "Matriz";
            if (frm_dat.Rows[0]["va_tip_fam"].ToString() == "D")
                tb_tip_fam.Text = "Detalle";
            if (frm_dat.Rows[0]["va_tip_fam"].ToString() == "S")
                tb_tip_fam.Text = "Servicio";
            if (frm_dat.Rows[0]["va_tip_fam"].ToString() == "C")
                tb_tip_fam.Text = "Combo";


            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            if (tb_nom_fam.Text.Trim()=="")
            {
                tb_nom_fam.Focus();
                return "Debe proporcionar el nombre para la Familia de producto";
            }

            tabla = o_inv003.Fe_con_fam(tb_cod_fam.Text);
            if (tabla.Rows.Count == 0)
            {
                return "la Familia de producto no se encuentra en la base de datos";
            }

            return "";

        }
             
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
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

            msg_res = MessageBox.Show("Esta seguro de Eliminar la Familia de producto?", "Familia de producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (msg_res == DialogResult.OK)
            {
                o_inv003.Fe_eli_fam(tb_cod_fam.Text);
               
                MessageBox.Show("Los datos se Eliminaron correctamente", "Familia de producto", MessageBoxButtons.OK,MessageBoxIcon.Information);

                //Actualiza ventana buscar
                frm_pad.Fe_act_frm(tb_cod_fam.Text);

                cl_glo_frm.Cerrar(this);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
