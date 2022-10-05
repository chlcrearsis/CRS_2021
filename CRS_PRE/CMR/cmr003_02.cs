using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;
using CRS_PRE;

namespace CRS_PRE
{
    public partial class cmr003_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        cmr003 o_cmr003 = new cmr003();
       
        DataTable tabla = new DataTable();
        DataTable tab_cmr003 = new DataTable();

        public DataTable tab_adp002 = new DataTable();  // Tabla Persona

        public cmr003_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_suc.Focus();
        }

        protected string Fi_val_dat()
        {
            if (tb_ide_suc.Text.Trim()=="")
            {
                tb_ide_suc.Focus();
                return "Debe proporcionar el codigo para la nueva sucursal";
            }

            //Verificar 
            tabla = o_cmr003.Fe_con_suc(tb_ide_suc.Text);
            if(tabla.Rows.Count >0)
            {
                tb_ide_suc.Focus();
                return "La sucursal que desea crear ya se encuentra registrado";
            }
            if (tb_nom_suc.Text.Trim() == "")
            {
                tb_nom_suc.Focus();
                return "Debe proporcionar el Nombre para la nueva sucursal";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            tb_ide_suc.Clear(); 
            tb_nom_suc.Clear();
            tb_des_suc.Clear();

            tb_ciu_suc.Clear();
            tb_dto_suc.Clear();
            tb_dir_suc.Clear();
            tb_enc_suc.Clear();
            tb_tel_suc.Clear();
            tb_cel_suc.Clear();
            tb_cla_wif.Clear();

            tb_ide_suc.Focus();
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
                    //Registrar sucursal
                    o_cmr003.Fe_crea(tb_ide_suc.Text, tb_nom_suc.Text, tb_des_suc.Text, tb_dto_suc.Text,tb_ciu_suc.Text,tb_dir_suc.Text,
                        tb_enc_suc.Text, tb_tel_suc.Text, tb_cel_suc.Text,tb_cla_wif.Text);

                    MessageBox.Show("Los datos se grabaron correctamente", "Nueva sucursal", MessageBoxButtons.OK);
                    frm_pad.Fe_act_frm(tb_ide_suc.Text);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nuevo sucursal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_ide_suc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }
    }
}
