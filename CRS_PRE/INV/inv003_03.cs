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
using CRS_NEG.ADS;
using CRS_NEG.INV;

namespace CRS_PRE.INV
{
    public partial class inv003_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        c_inv003 o_inv003 = new c_inv003();

        DataTable tabla = new DataTable();

        public inv003_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            
            tb_cod_fam.Text = frm_dat.Rows[0]["va_cod_fam"].ToString();
            tb_nom_fam.Text = frm_dat.Rows[0]["va_nom_fam"].ToString();
            tb_tip_fam.Text = frm_dat.Rows[0]["va_tip_fam"].ToString();

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

            tb_nom_fam.Focus();

        }




        protected string Fi_val_dat()
        {
            if (tb_nom_fam.Text.Trim()=="")
            {
                tb_nom_fam.Focus();
                return "Debe proporcionar el nombre para la familia de producto";
            }

            tabla = o_inv003.Fe_con_fam(tb_cod_fam.Text);
            if (tabla.Rows.Count == 0)
            {
                return "la familia de producto no se encuentra en la base de datos";
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Grupo de Bodega", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita usuario
               
                o_inv003.Fe_edi_fam(tb_cod_fam.Text,tb_nom_fam.Text);
                MessageBox.Show("Los datos se grabaron correctamente", "Edita Grupo de Bodega", MessageBoxButtons.OK,MessageBoxIcon.Information);

                frm_pad.Fe_act_frm(tb_cod_fam.Text);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
