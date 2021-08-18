using System;
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

namespace CRS_PRE
{
    public partial class adp001_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp001 o_adp001 = new adp001();

        DataTable tabla = new DataTable();

        public adp001_04()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString();
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();
            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }


        protected string Fi_val_dat()
        {
            if (tb_nom_gru.Text.Trim()=="")
            {
                tb_nom_gru.Focus();
                return "Debe proporcionar el nombre para el Grupo de Persona";
            }

            tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (tabla.Rows.Count == 0)
            {
                return "EL Grupo de Persona no se encuentra en la base de datos";
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

            if (tb_est_ado.Text == "Habilitado")
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Grupo de Persona?", "Edita Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             else
                msg_res = MessageBox.Show("Esta seguro de Habilitar el Grupo de Persona?", "Edita Grupo de Persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msg_res == DialogResult.OK)
            {
                if (tb_est_ado.Text == "Habilitado")
                    o_adp001.Fe_hab_des(int.Parse(tb_cod_gru.Text),"N");
                else
                    o_adp001.Fe_hab_des(int.Parse(tb_cod_gru.Text),"H");


                MessageBox.Show("Los datos se grabaron correctamente", "Edita Grupo de Persona", MessageBoxButtons.OK,MessageBoxIcon.Information);

                //Actualiza ventana buscar
                frm_pad.Fe_act_frm(int.Parse(tb_cod_gru.Text));

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
