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
    public partial class ads003_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads003 o_ads003 = new ads003();

        DataTable tabla = new DataTable();

        public ads003_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_des_doc.Text = frm_dat.Rows[0]["va_des_doc"].ToString();
            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            if (tb_nom_doc.Text.Trim()=="")
            {
                tb_nom_doc.Focus();
                return "Debe proporcionar el nombre para el Documento";
            }

            tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (tabla.Rows.Count == 0)
            {
                return "EL documento no se encuentra en la base de datos";
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
            {
                MessageBox.Show("No puede Eliminar, el documento debe de estar Deshabilitado", "Edita Documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return;
            }
            else
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar el documento?", "Edita Documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (msg_res == DialogResult.OK)
            {
                o_ads003.Fe_eli_doc(int.Parse(tb_ide_mod.Text), tb_ide_doc.Text);

                MessageBox.Show("Los datos se grabaron correctamente", "Elimina Documento", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(tb_ide_doc.Text);
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
