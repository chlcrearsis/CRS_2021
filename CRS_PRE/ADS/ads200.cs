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
using CRS_PRE.INV;
using CRS_PRE.CMR;

namespace CRS_PRE
{
    public partial class ads200 : Form
    {
        public ads200()
        {
            InitializeComponent();
        }

        // Instancia
        ads013 o_ads013 = new ads013();

        dynamic o_frm;
        public dynamic frm_pad;

        private void M_ads100_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            switch (e.ClickedItem.Name)
            {
                case "mn_usu_ari":
                    o_frm = new ads007_01();
                    cl_glo_frm.abrir(this, o_frm);

                    break;
                case "mn_ges_tio":
                    o_frm = new ads016_01();
                    cl_glo_frm.abrir(this, o_frm);

                    break;
               

                default:
                    break;
            }
        }

        private void Ads100_Load(object sender, EventArgs e)
        {
            ts_usr_usr.Text = o_ads013.va_ide_usr;
            ts_bas_dat.Text = o_ads013.va_nom_bda;
            ts_ide_app.Text = this.Name;
            ts_rut_app.Text = this.Text;
        }

        private void Mn_doc_ume_Click(object sender, EventArgs e)
        {
            o_frm = new ads003_01();
            cl_glo_frm.abrir(this, o_frm);
        }
        private void TalonarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_frm = new ads004_01();
            cl_glo_frm.abrir(this, o_frm);
        }
        private void Ads100_MdiChildActivate(object sender, EventArgs e)
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
            o_frm = new ads005_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_gru_bod_Click(object sender, EventArgs e)
        {
            o_frm = new inv001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_bod_ega_Click(object sender, EventArgs e)
        {
            o_frm = new inv002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_fam_pro_Click(object sender, EventArgs e)
        {
            o_frm = new inv003_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_lis_pre_Click(object sender, EventArgs e)
        {
            o_frm = new cmr001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_pre_cio_Click(object sender, EventArgs e)
        {
            o_frm = new cmr002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_del_ive_Click(object sender, EventArgs e)
        {
            o_frm = new cmr015_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_pro_duc_Click(object sender, EventArgs e)
        {
            o_frm = new inv004_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_mar_ca_Click(object sender, EventArgs e)
        {
            o_frm = new inv006_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_und_med_Click(object sender, EventArgs e)
        {
            o_frm = new inv005_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_ven_ded_Click(object sender, EventArgs e)
        {
            o_frm = new cmr014_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_gru_per_Click(object sender, EventArgs e)
        {
            o_frm = new adp001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_per_son1_Click(object sender, EventArgs e)
        {
            o_frm = new adp002_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_tip_atr_Click(object sender, EventArgs e)
        {
            o_frm = new adp003_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_tip_doc_Click(object sender, EventArgs e)
        {
            o_frm = new adp014_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_def_atr_Click(object sender, EventArgs e)
        {
            o_frm = new adp004_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_def_rut_Click(object sender, EventArgs e)
        {
            o_frm = new adp007_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_pla_vta_Click(object sender, EventArgs e)
        {
            o_frm = new cmr004_01();
            cl_glo_frm.abrir(this, o_frm);
        }
        private void mn_tal_pro_Click(object sender, EventArgs e)
        {
           
        }
        private void mn_col_pro_Click(object sender, EventArgs e)
        {
           
        }

        private void mn_tip_bus_Click(object sender, EventArgs e)
        {
            o_frm = new ads022_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_mod_ulo_Click(object sender, EventArgs e)
        {
            o_frm = new ads001_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_apl_ica_Click(object sender, EventArgs e)
        {
            o_frm = new ads002_01();
            cl_glo_frm.abrir(this, o_frm);
        }      

        private void mn_bit_ope_Click(object sender, EventArgs e)
        {

        }

        private void mn_bit_doc_Click(object sender, EventArgs e)
        {

        }

        private void mn_reg_ini_Click(object sender, EventArgs e)
        {
            o_frm = new ads024_R01p();
            cl_glo_frm.abrir(this, o_frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
        }

        private void mn_tip_ima_Click(object sender, EventArgs e)
        {
            o_frm = new ads010_01();
            cl_glo_frm.abrir(this, o_frm);
        }

        private void mn_dos_ifi_Click(object sender, EventArgs e)
        {
            o_frm = new ctb007_01();
            cl_glo_frm.abrir(this, o_frm);
        }
    }
}
