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
    public partial class adp001_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp001 o_adp001 = new adp001();

        DataTable tabla = new DataTable();

        public adp001_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString();
            tb_ide_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString();
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

            tabla = o_adp001.Fe_con_gru(int.Parse(tb_ide_gru.Text));
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
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Grupo de Persona", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita usuario
                o_adp001.Fe_edi_gru(int.Parse(tb_ide_gru.Text),tb_nom_gru.Text);
                MessageBox.Show("Los datos se grabaron correctamente", "Edita Grupo de Persona", MessageBoxButtons.OK,MessageBoxIcon.Information);

                frm_pad.Fe_act_frm(int.Parse(tb_ide_gru.Text));
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
