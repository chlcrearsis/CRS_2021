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
    public partial class ads016_02c : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();


        public ads016_02c()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ges_per.Focus();
        }
        void Fi_lim_frm()
        {
            tb_ges_tio.Clear();
            tb_ges_per.Clear();
            tb_nom_per.Clear();
            tb_fec_ini.Clear();
            tb_fec_fin.Clear();
        }

        protected string Fi_val_dat()
        {

            int val = 0;
            int.TryParse(tb_ges_per.Text.Trim(), out val );
            if (val <= 0)
            {
                return "Debe proporcionar un periodo valido";
            }

            if (val > 12)
            {
                return "Debe proporcionar un periodo valido (1-12)";
            }

            int.TryParse(tb_ges_tio.Text.Trim(), out val);
            if (val <= 2010)
            {
                return "Debe proporcionar una gestion valida";
            }

            if(tb_nom_per.Text.Trim()=="")
                return "Debe proporcionar el nombre del periodo";

            DateTime dval;
            DateTime.TryParse(tb_fec_ini.Text, out dval);
            if(dval == DateTime.Parse("01/01/0001"))
            {
                tb_fec_ini.Focus();
                return "Debe proporcionar una fecha inicial valida";
            }
            DateTime.TryParse(tb_fec_fin.Text, out dval);
            if (dval == DateTime.Parse("01/01/0001"))
            {
                tb_fec_fin.Focus();
                return "Debe proporcionar una fecha final valida";
            }

            if (DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text))
            {
                tb_fec_fin.Focus();
                return "La fecha final debe ser mayor a la inicial";
            }

            // Valida si ya existe ese periodo en la base de datos
            tabla = new DataTable();
            tabla = o_ads016.Fe_con_per(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
            if (tabla.Rows.Count > 0)
                return "El periodo que intenta crear ya esta registrado";

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
            msg_res = MessageBox.Show("Esta seguro de crear el periodo ?", "Crea periodo", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_ads016.Fe_cre_per(int.Parse(tb_ges_tio.Text),int.Parse(tb_ges_per.Text),tb_nom_per.Text,
                    DateTime.Parse(tb_fec_ini.Text), DateTime.Parse(tb_fec_fin.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Crea periodo", MessageBoxButtons.OK);
                frm_pad.fi_bus_car(int.Parse(tb_ges_tio.Text));
                
                //Limpiar formulario

            }

        }
    }
}
