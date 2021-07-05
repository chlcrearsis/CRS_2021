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
using CRS_NEG.INV;
using CRS_NEG;

namespace CRS_PRE.INV
{
    public partial class inv005_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
         
        c_inv005 o_inv005 = new c_inv005();

        DataTable tabla = new DataTable();


        public inv005_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_umd.Focus();
        }


        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }

        private void Cb_ini_ses_SelectionChangeCommitted(object sender, EventArgs e)
        {
          
            
        }

        protected string Fi_val_dat()
        {
            
            if (tb_cod_umd.Text.Trim()=="")
            {
                tb_cod_umd.Focus();
                return "Debe proporcionar el codigo";
            }
 
            //Verificar 
            tabla = o_inv005.Fe_con_umd(tb_cod_umd.Text );
            if(tabla.Rows.Count > 0)
            {
                tb_cod_umd.Focus();
                return "El Unidad que desea crear ya se encuentra registrada";
            }
            if (tb_nom_umd.Text.Trim() == "")
            {
                tb_nom_umd.Focus();
                return "Debe proporcionar el Nombre para el Unidad";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            tb_cod_umd.Clear();
            tb_nom_umd.Clear();
            tb_cod_umd.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nueva Unidad", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar
                o_inv005.Fe_crea(tb_cod_umd.Text, tb_nom_umd.Text );
                frm_pad.Fe_act_frm(tb_cod_umd.Text);
                
                Fi_lim_pia();
            }

        }
    }
}
