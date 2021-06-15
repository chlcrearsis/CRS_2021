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
using CRS_NEG.ADS;

namespace CRS_PRE.ADS
{
    public partial class ads016_03 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        c_ads016 o_ads016 = new c_ads016();

        DataTable tabla = new DataTable();


        public ads016_03()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ges_tio.Text = frm_dat.Rows[0][0].ToString();
            tb_ges_per.Text = frm_dat.Rows[0][1].ToString();
            tb_nom_per.Text = frm_dat.Rows[0][2].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0][3].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0][4].ToString();

            tb_nom_per.Focus();
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

            // Valida que exista ese periodo en la base de datos
            tabla = new DataTable();
            tabla = o_ads016.Fe_con_per(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
            if (tabla.Rows.Count == 0)
                return "El periodo que intenta editar no se encuentra registrado en la base de datos, verifique por favor";

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
            msg_res = MessageBox.Show("Esta seguro Editar el periodo ?", "Edita periodo", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_ads016.Fe_edi_per(int.Parse(tb_ges_tio.Text),int.Parse(tb_ges_per.Text),tb_nom_per.Text,
                    DateTime.Parse(tb_fec_ini.Text), DateTime.Parse(tb_fec_fin.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Edita periodo", MessageBoxButtons.OK);
                frm_pad.fi_bus_car(int.Parse(tb_ges_tio.Text));
                
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
