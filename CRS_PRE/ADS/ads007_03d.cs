using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE;

namespace CRS_PRE
{
    public partial class ads007_03d : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        ads006 o_ads006 = new ads006();
        ads007 o_ads007 = new ads007();
        adp002 o_adp002 = new adp002();     // Persona

        DataTable tabla = new DataTable();
         DataTable tab_adp002 = new DataTable();  // Tabla Persona

        public ads007_03d()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {

            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
            tb_tel_usr.Text = frm_dat.Rows[0]["va_tel_usr"].ToString();
            tb_car_usr.Text = frm_dat.Rows[0]["va_car_usr"].ToString();
            tb_dir_ect.Text = frm_dat.Rows[0]["va_dir_ect"].ToString();
            tb_ema_usr.Text = frm_dat.Rows[0]["va_ema_usr"].ToString();
            tb_cod_per.Text = frm_dat.Rows[0]["va_ide_per"].ToString();
            tb_win_max.Text = frm_dat.Rows[0]["va_win_max"].ToString();

            cb_tip_usr.DataSource = o_ads006.Fe_lis_tus();
            cb_tip_usr.ValueMember = "va_ide_tus";
            cb_tip_usr.DisplayMember = "va_nom_tus";

            tabla = o_ads006.Fe_con_tus(frm_dat.Rows[0]["va_tip_usr"].ToString());
            if(tabla.Rows.Count == 0)
                tb_tip_usr.Text = "??";
            else
                tb_tip_usr.Text = tabla.Rows[0]["va_nom_tus"].ToString();


            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            // Obtiene persona
            Fi_obt_per();


            tb_nom_usr.Focus();
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
            adp002_01 frm = new adp002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_per.Text = frm.tb_cod_per.Text;

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

            tab_adp002 = o_adp002.Fe_con_per(val);
            if (tab_adp002.Rows.Count == 0)
            {
                lb_raz_soc.Text = "No Existe";
            }
            else
            {
                lb_raz_soc.Text = tab_adp002.Rows[0]["va_raz_soc"].ToString();
            }
        }

        protected string Fi_val_dat()
        {
            if (tb_nom_usr.Text.Trim()=="")
            {
                tb_nom_usr.Focus();
                return "Debe proporcionar el nombre para el usuario";
            }
            
            if(tb_tip_usr.Text.Trim() == cb_tip_usr.Text.Trim())
            {
                tb_nom_usr.Focus();
                return "El tipo de usuario seleecionado debe ser diferente al actual que tiene el usuario.";
            }


            if (cl_glo_bal.IsNumeric(tb_win_max.Text) == false)
            {
                tb_win_max.Focus();
                return "El campo Maximo de ventanas debe ser numerico";
            }

          return  o_ads007.Fe_ver_edi(tb_ide_usr.Text);

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
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Usuario", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita usuario
                o_ads007.Fe_cam_tus(tb_ide_usr.Text,cb_tip_usr.SelectedValue.ToString() );
                MessageBox.Show("Los datos se grabaron correctamente", "Usuario", MessageBoxButtons.OK,MessageBoxIcon.Information);
                frm_pad.Fe_act_frm(tb_ide_usr.Text);
                cl_glo_frm.Cerrar(this);
            }

        }
    }
}
