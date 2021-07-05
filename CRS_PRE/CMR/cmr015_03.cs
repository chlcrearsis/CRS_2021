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
    public partial class cmr015_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_cmr015 o_cmr015 = new c_cmr015();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr015_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_del.Text = frm_dat.Rows[0]["va_cod_del"].ToString();
            tb_nom_del.Text = frm_dat.Rows[0]["va_nom_del"].ToString();
            tb_por_del.Text = frm_dat.Rows[0]["va_por_del"].ToString();
            

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
            //if (tb_ide_doc.Text.Trim()=="")
            //{
            //    tb_ide_doc.Focus();
            //    return "Debe proporcionar el Codigo de la Lista de Precio";
            //}

            //Verificar 
            tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_del.Text));
            if(tabla.Rows.Count ==0)
            {
                tb_cod_del.Focus();
                return "El Delivery que desea crear ya NO se encuentra registrado";
            }
            if (tb_nom_del.Text.Trim() == "")
            {
                tb_nom_del.Focus();
                return "Debe proporcionar el Nombre";
            }

            decimal val;
            decimal.TryParse(tb_por_del.Text, out val);
            if (tb_por_del.Text != "0")
            {
                if(val==0)
                {
                    tb_por_del.Focus();
                    return "El porcentaje es incorrecto";
                }
            }

            if (val <0 || val > 26)
            {
                tb_por_del.Focus();
                return "El porcentaje debe estar entre 0-26";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
           
            tb_cod_del.Clear(); 
            tb_nom_del.Clear();
            //tb_des_cri.Clear();
           

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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Delivery", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_cmr015.Fe_edi_del(int.Parse(tb_cod_del.Text), tb_nom_del.Text, decimal.Parse(tb_por_del.Text));

                frm_pad.Fe_act_frm(int.Parse(tb_cod_del.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Edita Delivery", MessageBoxButtons.OK);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
