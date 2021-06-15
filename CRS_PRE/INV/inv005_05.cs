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
using CRS_NEG.INV;
using CRS_NEG.ADS;

namespace CRS_PRE.INV
{
    public partial class inv005_05 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        c_inv005 o_inv005 = new c_inv005();

        DataTable tabla = new DataTable();


        public inv005_05()
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
            if(tabla.Rows.Count > 0)
            {
                tb_cod_umd.Focus();
                return "El Unidad que desea crear ya se encuentra registrada";
            }
            if (tb_nom_umd.Text.Trim() == "")
            {
                tb_nom_umd.Focus();
                return "Debe proporcionar el Nombre para el Unidad";
            }


            return "";
        }
 
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
 
    }
}
