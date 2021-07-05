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

namespace CRS_PRE.CMR
{
    public partial class cmr001_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        cmr001 o_cmr001 = new cmr001();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr001_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
           
            tb_nro_lis.Focus();
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

            if (tb_nro_lis.Text.Trim() == "")
            {
                tb_nro_lis.Focus();
                return "Debe proporcionar el Codigo de la Lista de Precio";
            }

            //Verificar 
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis.Text));
            if (tabla.Rows.Count > 0)
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio que desea crear ya se encuentra registrada";
            }
            if (tb_nom_bre.Text.Trim() == "")
            {
                tb_nom_bre.Focus();
                return "Debe proporcionar el Nombre para la Lista de Precio";
            }



            int val;
            try
            {
                val = int.Parse(tb_nro_dec.Text);
            }
            catch (Exception)
            {
                tb_nro_dec.Focus();
                return "El numero de decimales con el que trabajara la lista de precios es incorrecto";
            }
            
            if (val < 0 || val > 4)
            {
                tb_nro_dec.Focus();
                return "El numero de decimales con el que trabajara la lista de precios debe estar entre 0-4";
            }

            if (tb_fec_ini.Value > tb_fec_fin.Value)
            {
                tb_fec_fin.Focus();
                return "La fecha final debe ser mayor igual a la fecha inicial";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            cb_mon_lis.SelectedIndex = 0;
            tb_nro_lis.Clear(); 
            tb_nom_bre.Clear();
            tb_nom_bre.Clear();

            tb_nro_lis.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nueva lista", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                string mon_lis = "B";
                if (cb_mon_lis.SelectedIndex==1)
                    mon_lis = "U";

                //Registrar usuario
                o_cmr001.Fe_crea(int.Parse(tb_nro_lis.Text), tb_nom_bre.Text, mon_lis, tb_fec_ini.Value, tb_fec_fin.Value, int.Parse(tb_nro_dec.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Nueva lista", MessageBoxButtons.OK);
                Fi_lim_pia();
            }

        }
    }
}
