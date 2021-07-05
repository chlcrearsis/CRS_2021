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

namespace CRS_PRE.ADS
{
    public partial class ads016_06 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();

        public ads016_06()
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

            // Valida que aun exista el periodo en la base de datos
            tabla = new DataTable();
            tabla = o_ads016.Fe_con_per(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
            if (tabla.Rows.Count == 0)
                return "El periodo que intenta eliminar no se encuentra registrado en la base de datos, verifique por favor";

            return "";
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
            msg_res = MessageBox.Show("Esta seguro Eliminar el periodo ?", "Elimina periodo", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_ads016.Fe_eli_per(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
                MessageBox.Show("Los datos se grabaron correctamente", "Elimina periodo", MessageBoxButtons.OK);
                frm_pad.fi_bus_car(int.Parse(tb_ges_tio.Text));

                cl_glo_frm.Cerrar(this);
            }
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }



    }
}
