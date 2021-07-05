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
using CRS_NEG;

namespace CRS_PRE.INV
{
    public partial class inv001_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads003 o_ads003 = new ads003();
        ads001 o_ads001 = new ads001();
        c_inv001 o_inv001 = new c_inv001();

        DataTable tabla = new DataTable();


        public inv001_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_gru.Focus();
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
            int val = 0;

            if (tb_ide_gru.Text.Trim()=="")
            {
                tb_ide_gru.Focus();
                return "Debe proporcionar el Id para el Grupo de Bodega";
            }

            int.TryParse(tb_ide_gru.Text, out val);
            if (val == 0)
            {
                tb_ide_gru.Focus();
                return "Id de grupo de bodega no es valido";
            }

            //Verificar 
            tabla = o_inv001.Fe_con_gru(int.Parse(tb_ide_gru.Text) );
            if(tabla.Rows.Count >0)
            {
                tb_ide_gru.Focus();
                return "El Grupo de Bodega que desea crear ya se encuentra registrado";
            }
            if (tb_nom_gru.Text.Trim() == "")
            {
                tb_nom_gru.Focus();
                return "Debe proporcionar el Nombre para el Grupo de Bodega";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            tb_ide_gru.Clear(); 
            tb_nom_gru.Clear();
            tb_des_gru.Clear();
           

            tb_ide_gru.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo Grupo de Bodega", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar
                o_inv001.Fe_crea(int.Parse(tb_ide_gru.Text), tb_nom_gru.Text, tb_des_gru.Text,"H");
                frm_pad.Fe_act_frm( int.Parse(tb_ide_gru.Text));
                //MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Grupo de Bodega", MessageBoxButtons.OK);
                Fi_lim_pia();
            }

        }
    }
}
