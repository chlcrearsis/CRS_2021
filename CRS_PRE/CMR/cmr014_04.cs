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
    public partial class cmr014_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_cmr014 o_cmr014 = new c_cmr014();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr014_04()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ven"].ToString();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_ven"].ToString();
            tb_por_cms.Text = frm_dat.Rows[0]["va_por_cms"].ToString();
            cb_tip_cms.SelectedIndex = int.Parse(frm_dat.Rows[0]["va_tip_cms"].ToString());

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_ven.Focus();
        }
 

        protected string Fi_val_dat()
        {
            
            //Verificar 
            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text));
            if(tabla.Rows.Count ==0)
            {
                tb_cod_ven.Focus();
                return "el Vendedor que desea crear ya NO se encuentra registrada";
            }
            if (tb_nom_ven.Text.Trim() == "")
            {
                tb_nom_ven.Focus();
                return "Debe proporcionar el Nombre para el Vendedor";
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

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
            {
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Vendedor?", "Deshabilita Vendedor", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    //Deshabilita Vendedor
                    o_cmr014.Fe_des_hab(int.Parse(tb_cod_ven.Text));
                }
            }
            else
            {
                msg_res = MessageBox.Show("Esta seguro de Habilitar el Vendedor?", "Habilita Vendedor", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    //Habilita Vendedor
                    o_cmr014.Fe_hab_ili(int.Parse(tb_cod_ven.Text));
                }
            }
            //MessageBox.Show("Los datos se grabaron correctamente", "Vendedor de Precio", MessageBoxButtons.OK);
            frm_pad.Fe_act_frm(int.Parse(tb_cod_ven.Text));
            cl_glo_frm.Cerrar(this);

        }
    }
}
