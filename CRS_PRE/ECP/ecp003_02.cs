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
    public partial class ecp003_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ecp001 o_ecp001 = new ecp001();
        ecp002 o_ecp002 = new ecp002();
        ecp003 o_ecp003 = new ecp003();

        DataTable tabla = new DataTable();
        int cod_per = 0;

        public ecp003_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
             
            string raz_soc = "";
            string nom_bre = "";
            int ced_per = 0;

            cod_per = int.Parse(frm_dat.Rows[0]["va_cod_per"].ToString());
            raz_soc = frm_dat.Rows[0]["va_raz_soc"].ToString();
            nom_bre = frm_dat.Rows[0]["va_ape_pat"].ToString() + " " + frm_dat.Rows[0]["va_ape_mat"].ToString() + ", " + frm_dat.Rows[0]["va_nom_bre"].ToString();
            ced_per = int.Parse(frm_dat.Rows[0]["va_ced_per"].ToString());

            lb_raz_soc.Text = raz_soc + "  (" + cod_per + ")";
            lb_nom_bre.Text = nom_bre;


            tb_cod_lib.Text = "0";
            tb_des_lib.Text = "";
            
            tb_cod_lib.Focus();
        }


        protected string Fi_val_dat()
        {

            if (tb_cod_lib.Text.Trim() == "")
            {
                tb_cod_lib.Focus();
                return "Debe proporcionar el numero de la libreta";
            }

            //Verificar 
            //tabla = o_ecp002_01.Fe_con_lib(int.Parse(tb_cod_lib.Text));
            if (tabla.Rows.Count > 0)
            {
                tb_cod_lib.Focus();
                return "La libreta que desea crear ya se encuentra registrada";
            }
            if (tb_des_lib.Text.Trim() == "")
            {
                tb_des_lib.Focus();
                return "Debe proporcionar la descripción";
            }


            if (cl_glo_bal.IsNumeric(tb_cod_lib.Text) == false)
            {
                tb_cod_lib.Focus();
                return "El numero de la libreta es incorrecto";
            }

            
            return "";
        }





        private void Bt_bus_lib_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_lib();
        }
        private void Tb_cod_lib_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_lib();
            }

        }

        void Fi_abr_bus_lib()
        {
            ecp002_01 frm = new ecp002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_lib.Text = frm.tb_sel_ecc.Text;
                Fi_obt_lib();
            }
        }

        private void Tb_cod_lib_Validated(object sender, EventArgs e)
        {
            Fi_obt_lib();
        }

        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_lib()
        {
            // Obtiene ide y nombre de libreta
            tabla = o_ecp002.Fe_con_lib(int.Parse(tb_cod_lib.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_des_lib.Text = "";
            }
            else
            {
                tb_cod_lib.Text = tabla.Rows[0]["va_cod_lib"].ToString();
                tb_des_lib.Text = tabla.Rows[0]["va_des_lib"].ToString();
            }
        }















        private void Fi_lim_pia()
        {
           
            tb_cod_lib.Text = "0"; 
            tb_des_lib.Clear();
           
            tb_cod_lib.Focus();
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

                //Registrar 
                //o_ecp003.Fe_nue_sus(int.Parse(tb_cod_lib.Text), cod_per, int.Parse(tb_cod_plg.Text), decimal.Parse("0"), tb_fec_exp.Text);
                Fi_lim_pia();
                frm_pad.Fe_act_frm(int.Parse(tb_cod_lib.Text));
            }

        }
        private void tb_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }


    }
}
