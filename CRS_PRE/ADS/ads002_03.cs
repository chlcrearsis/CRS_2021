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
    public partial class ads002_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads001 o_ads001 = new ads001();
        ads002 o_ads002 = new ads002();

        DataTable tabla = new DataTable();

        public ads002_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            tb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
            tb_ide_apl.Text = frm_dat.Rows[0]["va_ide_apl"].ToString();
            tb_nom_apl.Text = frm_dat.Rows[0]["va_nom_apl"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }




        protected string Fi_val_dat()
        {
            if (tb_nom_mod.Text.Trim()=="")
            {
                tb_nom_mod.Focus();
                return "Debe proporcionar el nombre para el Modulo";
            }

            tabla = new DataTable();
            tabla = o_ads001.Fe_con_mod(tb_ide_mod.Text);
            if (tabla.Rows.Count == 0)
            {
                return "EL Modulo no se encuentra en la base de datos";
            }

            tabla = new DataTable();
            tabla = o_ads002.Fe_con_apl( tb_ide_apl.Text);
            if (tabla.Rows.Count == 0)
            {
                return "EL Aplicacion No se encuentra registrado";
            }

            if ((tb_ide_apl.Text.ToString().CompareTo("ads200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("inv200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("cmr200") == 0) ||
                (tb_ide_apl.Text.ToString().CompareTo("res200") == 0)) {
                return "No se puede modificar esta Aplicación, es indespensable para el sistema";
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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Aplicacion", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita usuario
                o_ads002.Fe_edi_apl(int.Parse(tb_ide_mod.Text),tb_ide_apl.Text,tb_nom_apl.Text);
                MessageBox.Show("Los datos se grabaron correctamente", "Edita Aplicacion", MessageBoxButtons.OK,MessageBoxIcon.Information);

                frm_pad.Fe_act_frm(tb_ide_apl.Text);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
