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
    public partial class cmr016_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        cmr016 o_cmr016 = new cmr016();

        DataTable tabla = new DataTable();


        public cmr016_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
           
            tb_cod_act.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_cod_act.Text.Trim() == "")
            {
                tb_cod_act.Focus();
                return "Debe proporcionar el Codigo";
            }

            if (!cl_glo_bal.IsNumeric(tb_cod_act.Text.Trim()))
            {
                tb_cod_act.Focus();
                return "El codigo no es valido";
            }

            //Verificar 
            tabla = o_cmr016.Fe_con_act(tb_cod_act.Text);
            if (tabla.Rows.Count > 0)
            {
                tb_cod_act.Focus();
                return "El Actividad económica que desea crear ya se encuentra registrado";
            }
            if (tb_nom_act.Text.Trim() == "")
            {
                tb_nom_act.Focus();
                return "Debe proporcionar el Nombre";
            }

            
           return "";
        }

        private void Fi_lim_pia()
        {
           
            tb_cod_act.Clear(); 
            tb_nom_act.Clear();
           
            tb_cod_act.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nueva Actividad económica", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar 
                o_cmr016.Fe_nue_reg(int.Parse(tb_cod_act.Text), tb_nom_act.Text);
                frm_pad.Fe_act_frm(int.Parse(tb_cod_act.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Nueva Actividad económica", MessageBoxButtons.OK);
                Fi_lim_pia();
            }

        }

        private void tb_cod_act_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }
    }
}
