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
    public partial class cmr001_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_cmr001 o_cmr001 = new c_cmr001();
        //c_ads001 o_ads001 = new c_ads001();

        DataTable tabla = new DataTable();


        public cmr001_06()
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


        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }


        protected string Fi_val_dat()
        {
           
            //Verificar 
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_nro_lis.Text));
            if(tabla.Rows.Count ==0)
            {
                tb_nro_lis.Focus();
                return "La Lista de Precio que desea Eliminar ya NO se encuentra registrada";
            }
            if (tb_nom_bre.Text.Trim() == "")
            {
                tb_nom_bre.Focus();
                return "Debe proporcionar el Nombre para la Lista de Precio";
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
            msg_res = MessageBox.Show("Esta seguro de eliminar la informacion?", "Elimina Lista de Precio", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_cmr001.Fe_eli_lis(int.Parse(tb_nro_lis.Text));

                frm_pad.Fe_act_frm(int.Parse(tb_nro_lis.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Elimina Lista de Precio", MessageBoxButtons.OK);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
