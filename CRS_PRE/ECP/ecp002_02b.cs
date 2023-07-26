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
    public partial class ecp002_02b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ecp002 o_ecp002 = new ecp002();

        DataTable tabla = new DataTable();


        public ecp002_02b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_lib.Text = "0";
            tb_nom_lib.Text = "";
            cb_tip_lib.SelectedIndex = 0;
            cb_mon_lib.SelectedIndex = 0;

            Fi_obt_cod();

            tb_nro_lib.Focus();
        }


        /// <summary>
        /// Obtiene codigo para la libreta
        /// </summary>
        private void Fi_obt_cod()
        {
            int tip_lib = cb_tip_lib.SelectedIndex + 1;
            tip_lib = tip_lib + 2;
            int mon_lib = cb_mon_lib.SelectedIndex + 1;
            int nro_lib = int.Parse(tb_nro_lib.Text);
            int cod_lib = int.Parse(tip_lib.ToString() + mon_lib.ToString());

            
            cod_lib = cod_lib * 1000;
            cod_lib = cod_lib + nro_lib;

            tb_cod_lib.Text = cod_lib.ToString();
        }

        protected string Fi_val_dat()
        {

            if (tb_nro_lib.Text.Trim() == "")
            {
                tb_nro_lib.Focus();
                return "Debe proporcionar el numero de la libreta";
            }

            //Verificar 
            tabla = o_ecp002.Fe_con_lib(int.Parse(tb_cod_lib.Text));
            if (tabla.Rows.Count > 0)
            {
                tb_nro_lib.Focus();
                return "La libreta que desea crear ya se encuentra registrada";
            }
            if (tb_nom_lib.Text.Trim() == "")
            {
                tb_nom_lib.Focus();
                return "Debe proporcionar la descripción";
            }


            if (!cl_glo_bal.IsNumeric(tb_nro_lib.Text.Trim()))
            {
                tb_nro_lib.Focus();
                return "El numero de la libreta es incorrecto";
            }

            
            return "";
        }

        private void Fi_lim_pia()
        {
           
            tb_nro_lib.Text = "0"; 
            tb_nom_lib.Clear();
           
            tb_nro_lib.Focus();
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string mon_lib = "";
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nueva libreta", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                if (cb_mon_lib.SelectedIndex == 0)
                    mon_lib = "B";
                if (cb_mon_lib.SelectedIndex == 1)
                    mon_lib = "U";

                //Registrar 
                o_ecp002.Fe_nue_lib(int.Parse(tb_cod_lib.Text), tb_nom_lib.Text, cb_tip_lib.SelectedIndex + 3 , mon_lib);
                Fi_lim_pia();
                frm_pad.Fe_act_frm(int.Parse(tb_cod_lib.Text));
            }

        }
        private void tb_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void cb_tip_lib_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fi_obt_cod();
        }

        private void cb_mon_lib_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fi_obt_cod();
        }

        private void tb_nro_lib_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_nro_lib_Validated(object sender, EventArgs e)
        {
            Fi_obt_cod();
        }
    }
}
