using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;
using CRS_PRE.CMR;

namespace CRS_PRE
{
    public partial class ads007_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads007 o_ads007 = new ads007();
        cmr013 o_cmr013 = new cmr013();     // Persona
        ads006 o_ads006 = new ads006();     // Persona

        DataTable tabla = new DataTable();
        DataTable tab_ads006 = new DataTable();

        public DataTable tab_cmr013 = new DataTable();  // Tabla Persona

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
           

            cb_tip_usr.DataSource = o_ads006.Fe_lis_tus();
            cb_tip_usr.ValueMember = "va_ide_tus";
            cb_tip_usr.DisplayMember = "va_nom_tus";

            cb_tip_usr.SelectedIndex = 0;


            tb_dir_ect.Text = "C:\\Temp";
            tb_cod_per.Text = "0";
            lb_raz_soc.Text = "";
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
                return "Debe proporcionar el codigo para el nuevo usuario";
            }
            if (tb_ide_usr.Text.Trim().Length < 4)
            {
                tb_ide_usr.Focus();
                return "El codigo de usuario debe contener al menos 4 caracteres como minimo";
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
                        tb_dir_ect.Text, tb_ema_usr.Text, 3, int.Parse(tb_cod_per.Text), 
                        int.Parse(cb_tip_usr.SelectedValue.ToString()) , usr_new);

                    MessageBox.Show("Los datos se grabaron correctamente", "Nuevo Usuario", MessageBoxButtons.OK);
                    frm_pad.Fe_act_frm(tb_ide_usr.Text);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nuevo Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //** BUSCAR PERSONA
        private void Bt_bus_per_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_per();
        }
        private void Tb_cod_per_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_per();
            }
        }
        void Fi_abr_bus_per()
        {
            cmr013_01 frm = new cmr013_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_per.Text = frm.tb_sel_bus.Text;

                Fi_obt_per();
            }

        }
        private void Tb_cod_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_per();

        }
        private void Fi_obt_per()
        {
            if (tb_cod_per.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar un codigo de proveedor valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
            }
            int val = 0;
            if (int.TryParse(tb_cod_per.Text, out val) == false)
            {
                //MessageBox.Show("Debe proporcionar un codigo de proveedor valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
                lb_raz_soc.Text = "No Existe";
            }

            tab_cmr013 = o_cmr013.Fe_con_per(val);
            if (tab_cmr013.Rows.Count == 0)
            {
                lb_raz_soc.Text = "No Existe";
            }
            else
            {
                lb_raz_soc.Text = tab_cmr013.Rows[0]["va_raz_soc"].ToString();
            }
        }


    }
}
