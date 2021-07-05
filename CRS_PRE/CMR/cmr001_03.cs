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
    public partial class cmr001_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_cmr001 o_cmr001 = new c_cmr001();
        //ads001 o_ads001 = new ads001();

        DataTable tabla = new DataTable();


        public cmr001_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_nro_lis.Text = frm_dat.Rows[0]["va_cod_lis"].ToString();
            tb_nom_bre.Text = frm_dat.Rows[0]["va_nom_lis"].ToString();
            tb_nro_dec.Text = frm_dat.Rows[0]["va_nro_dec"].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();
            if (frm_dat.Rows[0]["va_mon_lis"].ToString() == "B")
                cb_mon_lis.SelectedIndex = 0;
            if (frm_dat.Rows[0]["va_mon_lis"].ToString() == "U")
                cb_mon_lis.SelectedIndex = 1;

            tb_nom_bre.Focus();
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
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis.Text));
            if(tabla.Rows.Count ==0)
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio que desea crear ya NO se encuentra registrada";
            }
            if (tb_nom_bre.Text.Trim() == "")
            {
                tb_nom_bre.Focus();
                return "Debe proporcionar el Nombre para la Lista de Precio";
            }

            int val;
            int.TryParse(tb_nro_dec.Text, out val);
            if (tb_nro_dec.Text != "0")
            {
                if(val==0)
                {
                    tb_nro_dec.Focus();
                    return "El numero de decimales con el que trabajara la lista de precios es incorrecto";
                }
            }

            if (val < 1 || val > 4)
            {
                tb_nro_dec.Focus();
                return "El numero de decimales con el que trabajara la lista de precios debe estar entre 0-4";
            }

            if(tb_fec_ini.Value > tb_fec_fin.Value)
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
            //tb_des_cri.Clear();
           

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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Documento", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_cmr001.Fe_edi_lis(int.Parse(tb_nro_lis.Text), tb_nom_bre.Text, tb_fec_ini.Value, tb_fec_fin.Value, int.Parse(tb_nro_dec.Text));

                frm_pad.Fe_act_frm(int.Parse(tb_nro_lis.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Edita Documento", MessageBoxButtons.OK);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
