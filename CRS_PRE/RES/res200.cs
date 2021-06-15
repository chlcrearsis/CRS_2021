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
using CRS_PRE.INV;

namespace CRS_PRE.CMR
{
    public partial class res200 : Form
    {
        public res200()
        {
            InitializeComponent();
        }

        // Instancia
        c_ads013 o_ads013 = new c_ads013();

        dynamic o_frm;
        public dynamic frm_pad;

        private void M_res100_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            switch (e.ClickedItem.Name)
            {
                case "mn_usu_ari":
                    //o_frm = new ads007_01();
                    //cl_glo_frm.abrir(this, o_frm);

                    break;
                case "mn_ges_tio":
                    //o_frm = new ads016_01();
                    //cl_glo_frm.abrir(this, o_frm);

                    break;
               

                default:
                    break;
            }
        }

        private void res100_Load(object sender, EventArgs e)
        {
            ts_usr_usr.Text = o_ads013.va_ide_usr;
            ts_bas_dat.Text = o_ads013.va_nom_bda;
            ts_ide_app.Text = this.Name;
            ts_rut_app.Text = this.Text;

            //o_frm = new res001_02b();
            //cl_glo_frm.abrir(this, o_frm);
        }

        private void TalonarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //o_frm = new ads004_01();
            //cl_glo_frm.abrir(this, o_frm);
        }
        private void res100_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
            {
                ts_ide_app.Text = this.Name;
                ts_rut_app.Text = this.Text;
            }
            else
            {
                // Ide de la app
                ts_ide_app.Text = this.ActiveMdiChild.Name;

                // Ruta de la app
                ts_rut_app.Text = "";

                dynamic frm = this.ActiveMdiChild;
                dynamic[] ruta =new dynamic[100];
                
                int i = 0;
                do
                {
                   i = i + 1;
                   ruta[i] = frm.frm_pad.Text;
                   frm = frm.frm_pad;

                  
                    dynamic aa = frm.frm_pad;
                } while (frm.frm_pad != null);

                do
                {
                    ts_rut_app.Text = ts_rut_app.Text + ruta[i] + " -> ";
                    i = i - 1;
                    
                } while (i != 0);
                
                ts_rut_app.Text = ts_rut_app.Text + this.ActiveMdiChild.Text;
            }
            
        }

        private void Mn_num_era_Click(object sender, EventArgs e)
        {
            //o_frm = new ads005_01();
            //cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_gru_bod_Click(object sender, EventArgs e)
        {
            o_frm = new inv001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_ven_res_Click(object sender, EventArgs e)
        {
            o_frm = new res001_02b();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_inf_vta_Click(object sender, EventArgs e)
        {
            o_frm = new res001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_pla_vta_Click(object sender, EventArgs e)
        {
            o_frm = new res004_01();
            cl_glo_frm.abrir(this, o_frm);
        }
    }
}
