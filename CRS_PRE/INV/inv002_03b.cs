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
using Microsoft.VisualBasic;

namespace CRS_PRE.INV
{
    public partial class inv002_03b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        inv002 o_inv002 = new inv002();
        inv001 o_inv001 = new inv001();

        DataTable tabla = new DataTable();
        int ide_gru = 0;

        public inv002_03b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            ide_gru =int.Parse(frm_dat.Rows[0]["va_ide_gru"].ToString());
            tb_cod_bod.Text = frm_dat.Rows[0]["va_cod_bod"].ToString();
            tb_nom_bod.Text = frm_dat.Rows[0]["va_nom_bod"].ToString();
            tb_des_bod.Text = frm_dat.Rows[0]["va_des_bod"].ToString();
            tb_fec_ult.Text = DateTime.Parse(frm_dat.Rows[0]["va_fec_ctr"].ToString()).ToString("d");
            tb_mon_inv.Text = frm_dat.Rows[0]["va_dir_ecg"].ToString();

            if ( frm_dat.Rows[0]["va_mon_inv"].ToString() == "B")
                tb_mon_inv.Text = "Bolivianos";
            else
                tb_mon_inv.Text = "Dolares";

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

        }


        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }


        protected string Fi_val_dat()
        {
            
            tabla = new DataTable();
            tabla = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
            if(tabla.Rows.Count == 0)
            {
                return "La Bodega NO se encuentra registrada";
            }


            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_fec_ape.Focus();
                return "La Bodega se encuentra Deshabilitada";
            }

            //** Valida las fechas
            long dias = DateAndTime.DateDiff(DateInterval.Day, DateTime.Parse(tb_fec_ult.Text), tb_fec_ape.Value);

            if (dias <= 0 )
            {
                tb_fec_ape.Focus();
                return "La fecha de apertura debe ser mayor a la ultima fecha aperturada";
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

            msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Apertura Bodega", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Apertura dia bodega
                o_inv002.Fe_ape_fec( int.Parse(tb_cod_bod.Text),tb_fec_ape.Value);

                
                frm_pad.Fe_act_frm(ide_gru, int.Parse(tb_cod_bod.Text));
                cl_glo_frm.Cerrar(this);
            }
        }
       
    }
}
