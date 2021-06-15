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

namespace CRS_PRE.ADS
{
    public partial class ads003_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        c_ads003 o_ads003 = new c_ads003();
        c_ads001 o_ads001 = new c_ads001();

        DataTable tabla = new DataTable();


        public ads003_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // obtiene lista de 
            cb_mod_ulo.DataSource = o_ads001.Fe_obt_mod();
            cb_mod_ulo.ValueMember = "va_ide_mod";
            cb_mod_ulo.DisplayMember = "va_nom_mod";

            tb_ide_doc.Focus();
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
            if (tb_ide_doc.Text.Trim()=="")
            {
                tb_ide_doc.Focus();
                return "Debe proporcionar el Id para el Documento";
            }

            //Verificar 
            tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if(tabla.Rows.Count >0)
            {
                tb_ide_doc.Focus();
                return "El Documento que desea crear ya se encuentra registrado";
            }
            if (tb_nom_bre.Text.Trim() == "")
            {
                tb_nom_bre.Focus();
                return "Debe proporcionar el Nombre para el Documento";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            cb_mod_ulo.SelectedIndex = 0;
            tb_ide_doc.Clear(); 
            tb_nom_bre.Clear();
            tb_des_cri.Clear();
           

            tb_ide_doc.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo Documento", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_ads003.Fe_crea(int.Parse(cb_mod_ulo.SelectedValue.ToString()),tb_ide_doc.Text, tb_nom_bre.Text, tb_des_cri.Text,"H");
                MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Documento", MessageBoxButtons.OK);
                Fi_lim_pia();
            }

        }
    }
}
