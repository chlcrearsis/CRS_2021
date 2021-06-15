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

namespace CRS_PRE.INV
{
    public partial class inv002_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        c_inv002 o_inv002 = new c_inv002();
        c_inv001 o_inv001 = new c_inv001();

        DataTable tabla = new DataTable();


        public inv002_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            cb_est_ado.SelectedIndex = 0;

            tb_ide_gr1.Text = "0";
            tb_ide_gr2.Text = "99";
            tb_nom_gr1.Text = "Bodega inicial";
            tb_nom_gr2.Text = "Bodega final";

            tb_ide_gr1.Focus();
        }

        protected string Fi_val_dat()
        {

           
            return "";
        }
      
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string est_ado = "";
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            tabla = new DataTable();
            tabla = o_inv002.Fe_inv002_R01(int.Parse(tb_ide_gr1.Text), int.Parse(tb_ide_gr2.Text), est_ado);
            inv002_R01w frm = new inv002_R01w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }

        private void tb_ide_gr1_Validated(object sender, EventArgs e)
        {
            int val;

            try
            {
                val = int.Parse(tb_ide_gr1.Text);
            }
            catch (Exception)
            {
                tb_nom_gr1.Clear();
                MessageBox.Show("El grupo inicial debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (int.Parse(tb_ide_gr1.Text) == 0)
            {
                tb_nom_gr1.Text = "Bodega inicial";
                return;
            }

            // Obtiene nombre del grupo
            Fi_obt_gru(1, int.Parse(tb_ide_gr1.Text));
           
           
        }

        private void tb_ide_gr2_Validated(object sender, EventArgs e)
        {
            int val;
            try
            {
                val = int.Parse(tb_ide_gr2.Text);
            }
            catch (Exception)
            {
                tb_nom_gr2.Clear();
                MessageBox.Show("El grupo final debe ser numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (int.Parse(tb_ide_gr2.Text) == 99)
            {
                tb_nom_gr2.Text = "Bodega Final";
                return;
            }

            Fi_obt_gru(2, int.Parse(tb_ide_gr2.Text));
             
        }

        /// <summary>
        /// Obtiene ide y nombre del grupo Bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_gru(int ini_fin, int ide_gru)
        {
            // Obtiene ide y nombre Bodega
            tabla = o_inv001.Fe_con_gru(ide_gru);
            if (tabla.Rows.Count == 0)
            {
                if(ini_fin == 1)
                    tb_nom_gr1.Clear();
                else
                    tb_nom_gr2.Clear();
            }
            else
            {
                if (ini_fin == 1)
                {
                   // tb_ide_gr1.Text = tabla.Rows[0]["va_ide_gru"].ToString();
                    tb_nom_gr1.Text = tabla.Rows[0]["va_nom_gru"].ToString();
                }
                else
                {
                   // tb_ide_gr2.Text = tabla.Rows[0]["va_ide_gru"].ToString();
                    tb_nom_gr2.Text = tabla.Rows[0]["va_nom_gru"].ToString();
                }

            }
        }

        void Fi_abr_bus_gru(int ini_fin)
        {
            inv001_01 frm = new inv001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                if (ini_fin == 1)
                {
                    tb_ide_gr1.Text = frm.tb_sel_bus.Text;
                    Fi_obt_gru(1, int.Parse(tb_ide_gr1.Text));
                }
                else
                {
                    tb_ide_gr2.Text = frm.tb_sel_bus.Text;
                    Fi_obt_gru(2, int.Parse(tb_ide_gr2.Text));
                }
            }
        }

        private void bt_bus_gr1_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_gru(1);
        }

        private void bt_bus_gr2_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_gru(2);
        }

        private void tb_ide_gr1_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Bodega
                Fi_abr_bus_gru(1);
            }
        }

        private void tb_ide_gr2_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Bodega
                Fi_abr_bus_gru(2);
            }
        }
    }
}
