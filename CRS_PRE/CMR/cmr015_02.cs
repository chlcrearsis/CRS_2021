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
using CRS_NEG.CMR;

namespace CRS_PRE.CMR
{
    public partial class cmr015_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        c_cmr015 o_cmr015 = new c_cmr015();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr015_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
           
            tb_cod_del.Focus();
        }

        protected string Fi_val_dat()
        {

            if (tb_cod_del.Text.Trim() == "")
            {
                tb_cod_del.Focus();
                return "Debe proporcionar el Codigo";
            }

            //Verificar 
            tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_del.Text));
            if (tabla.Rows.Count > 0)
            {
                tb_cod_del.Focus();
                return "El Delivery que desea crear ya se encuentra registrado";
            }
            if (tb_nom_del.Text.Trim() == "")
            {
                tb_nom_del.Focus();
                return "Debe proporcionar el Nombre";
            }

            int val;
            int.TryParse(tb_por_cms.Text, out val);
            if (tb_por_cms.Text != "0")
            {
                if (val == 0)
                {
                    tb_por_cms.Focus();
                    return "El porcentaje correspondiente es incorrecto";
                }
            }

            if (val < 0 || val > 30)
            {
                tb_por_cms.Focus();
                return "El porcentaje correspondiente debe estar entre 0-30";
            }

           return "";
        }

        private void Fi_lim_pia()
        {
           
            tb_cod_del.Clear(); 
            tb_nom_del.Clear();
            tb_por_cms.Clear();
           
            tb_cod_del.Focus();
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
            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Nuevo Delivery", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar 
                o_cmr015.Fe_crea(int.Parse(tb_cod_del.Text), tb_nom_del.Text, decimal.Parse(tb_por_cms.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Delivery", MessageBoxButtons.OK);
                Fi_lim_pia();
            }

        }
    }
}
