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
using CRS_NEG;

namespace CRS_PRE.INV
{
    public partial class inv005_06 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        inv005 o_inv005 = new inv005();

        DataTable tabla = new DataTable();


        public inv005_06()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_cod_umd.Text = frm_dat.Rows[0]["va_cod_umd"].ToString();
            tb_nom_umd.Text = frm_dat.Rows[0]["va_nom_umd"].ToString();
            tb_cod_umd.Focus();
        }


        protected string Fi_val_dat()
        {
            
            if (tb_cod_umd.Text.Trim()=="")
            {
                tb_cod_umd.Focus();
                return "Debe proporcionar el codigo";
            }
 
            //Verificar 
            tabla = o_inv005.Fe_con_umd(tb_cod_umd.Text );
            if(tabla.Rows.Count == 0)
            {
                tb_cod_umd.Focus();
                return "El Unidad que desea eliminar NO se encuentra registrada";
            }
            

            return "";
        }
 
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
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
            msg_res = MessageBox.Show("Esta seguro de Eliminar la informacion?", "Elimina Unidad", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar
                o_inv005.Fe_eli_umd(tb_cod_umd.Text.Trim());
                frm_pad.Fe_act_frm(tb_cod_umd.Text);
                cl_glo_frm.Cerrar(this);

            }
        }
    }
}
