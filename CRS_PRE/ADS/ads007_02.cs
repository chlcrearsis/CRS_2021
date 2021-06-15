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
    public partial class ads007_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        c_ads007 o_ads007 = new c_ads007();

        DataTable tabla = new DataTable();


        public ads007_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // obtiene lista de inicios de sesion de SQL
            cb_ini_ses.Items.Clear();
            cb_ini_ses.Items.Add("(Nuevo)");

            tabla = o_ads007.Fe_lis_usu();
            if (tabla.Rows.Count > 0)
            {
                
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    cb_ini_ses.Items.Add(tabla.Rows[i]["name"].ToString());
                }
            }
            cb_ini_ses.SelectedIndex = 0;
            tb_ide_usr.Focus();
        }


        private void creaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }

        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }

        private void Cb_ini_ses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_ini_ses.SelectedIndex == 0)
            {
                tb_ide_usr.Clear();
                tb_ide_usr.Enabled = true;
                tb_ide_usr.Focus();
            }
            else
            {
                tb_ide_usr.Clear();
                tb_ide_usr.Enabled = false;
                tb_ide_usr.Text = cb_ini_ses.SelectedItem.ToString();
                tb_nom_usr.Focus();
            }
            
        }

        protected string Fi_val_dat()
        {
            if (tb_ide_usr.Text.Trim()=="")
            {
                tb_ide_usr.Focus();
                return "Debe proporcionar el Id para el nuevo usuario";
            }

            //Verificar 
            tabla = o_ads007.Fe_con_usu(tb_ide_usr.Text);
            if(tabla.Rows.Count >0)
            {
                tb_ide_usr.Focus();
                return "El usuario que desea crear ya se encuentra registrado";
            }
            if (tb_nom_usr.Text.Trim() == "")
            {
                tb_nom_usr.Focus();
                return "Debe proporcionar el Nombre para el nuevo usuario";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            cb_ini_ses.SelectedIndex = 0;
            tb_ide_usr.Clear(); 
            tb_nom_usr.Clear();
            tb_tel_usr.Clear();
            tb_car_usr.Clear();
            tb_ema_usr.Clear();

            tb_ide_usr.Focus();
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            try
            {

           
                int usr_new = 1;    // Inicializa como usuario nuevo

                if (cb_ini_ses.SelectedIndex > 0)
                    usr_new = 0; // Usuario ya creado en el motor SQL

                // funcion para validar datos
                msg_val = Fi_val_dat();
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", "Error", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    //Registrar usuario
                    o_ads007.Fe_exe_nue(tb_ide_usr.Text, tb_nom_usr.Text, tb_tel_usr.Text, tb_car_usr.Text,
                        tb_ema_usr.Text,4,usr_new);
                    MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Usuario", MessageBoxButtons.OK);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
