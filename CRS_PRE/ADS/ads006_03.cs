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
    public partial class ads006_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads006 o_ads006 = new ads006();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public ads006_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
           
            tb_cod_tus.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_cod_tus.Text.Trim() == "")
            {
                tb_cod_tus.Focus();
                return "Debe proporcionar el Codigo";
            }

            //Verificar 
            tabla = o_ads006.Fe_con_tus(tb_cod_tus.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_cod_tus.Focus();
                return "El Tipo de usuario no se encuentra registrado";
            }
            if (tb_nom_tus.Text.Trim() == "")
            {
                tb_nom_tus.Focus();
                return "Debe proporcionar el Nombre";
            }

            
           return "";
        }

        private void Fi_lim_pia()
        {          
            tb_cod_tus.Clear(); 
            tb_nom_tus.Clear();
            tb_des_tus.Clear();
           
            tb_cod_tus.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Tipo de usuario", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar 
                o_ads006.Fe_crea(int.Parse(tb_cod_tus.Text), tb_nom_tus.Text, tb_des_tus.Text,"H");
                MessageBox.Show("Los datos se grabaron correctamente", "Tipo de usuario", MessageBoxButtons.OK);

                frm_pad.Fe_act_frm(int.Parse(tb_cod_tus.Text));

                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
