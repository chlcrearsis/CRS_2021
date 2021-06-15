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
    public partial class cmr015_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_cmr015 o_cmr015 = new c_cmr015();
        //c_ads001 o_ads001 = new c_ads001();

        DataTable tabla = new DataTable();


        public cmr015_04()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_del.Text = frm_dat.Rows[0]["va_cod_del"].ToString();
            tb_nom_del.Text = frm_dat.Rows[0]["va_nom_del"].ToString();
            tb_por_del.Text = frm_dat.Rows[0]["va_por_del"].ToString();
            
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            tb_nom_del.Focus();
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
            
            //Verificar 
            tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_del.Text));
            if(tabla.Rows.Count ==0)
            {
                tb_cod_del.Focus();
                return "el Delivery que desea crear ya NO se encuentra registrada";
            }
            if (tb_nom_del.Text.Trim() == "")
            {
                tb_nom_del.Focus();
                return "Debe proporcionar el Nombre para el Delivery";
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
                msg_res = MessageBox.Show("Esta seguro de Deshabilitar el Delivery?", "Deshabilita Delivery", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    //Deshabilita Delivery
                    o_cmr015.Fe_des_hab(int.Parse(tb_cod_del.Text));
                }
            }
            else
            {
                msg_res = MessageBox.Show("Esta seguro de Habilitar el Delivery?", "Habilita Delivery", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    //Habilita Delivery
                    o_cmr015.Fe_hab_ili(int.Parse(tb_cod_del.Text));
                }
            }
            //MessageBox.Show("Los datos se grabaron correctamente", "Delivery de Precio", MessageBoxButtons.OK);
            frm_pad.Fe_act_frm(int.Parse(tb_cod_del.Text));
            cl_glo_frm.Cerrar(this);

        }
    }
}
