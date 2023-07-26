using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CRS_NEG;


namespace CRS_PRE
{
    public partial class ads000_07 : Form
    {
        private string Titulo = "PIN de Acceso";
        //public string vp_ide_usr = "";  // ID. Usuario
        public string vp_pas_usr = "";  // Contraseña Actual
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;

        ads007 o_ads007 = new ads007();
        ads017 o_ads017 = new ads017();
        cl_glo_frm o_glo_bal = new cl_glo_frm();

        DataTable tabla;
        string ide_usr = "";
        string pas_usr = "";
        string pin_usr = "";
        DateTime fec_exp;
        DateTime fec_act;

        int err_ror = 0;


         [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public ads000_07()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pn_con_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_con_usr.Width, pn_con_usr.Height, 15, 15));
            pn_fon_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_usr.Width, pn_fon_usr.Height, 15, 15));
            pn_con_pas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_con_pas.Width, pn_con_pas.Height, 15, 15));
            pn_fon_pas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_pas.Width, pn_fon_pas.Height, 15, 15));
            pn_rep_pas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_rep_pas.Width, pn_rep_pas.Height, 15, 15));
            pn_fon_rep.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_rep.Width, pn_fon_rep.Height, 15, 15));
        }

        private void ads000_01_MouseMove(object sender, MouseEventArgs e)
        {            
            if (va_est_ven)
            {
                this.Left = this.Left + (e.X - va_coo_pox);
                this.Top = this.Top + (e.Y - va_coo_poy);
            }
        }
        private void ads000_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
        }
        private void ads000_01_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = false;
            }
        }
        private void pb_mos_pas_MouseHover(object sender, EventArgs e)
        {
            tb_pas_usr.UseSystemPasswordChar = false;
        }
        private void pb_mos_pas_MouseLeave(object sender, EventArgs e)
        {
            tb_pas_usr.UseSystemPasswordChar = true;
        }
       
        private bool ValidaDatos()
        {
            string msn_res = "";

            ide_usr = tb_ide_usr.Text;
            pas_usr = tb_pas_usr.Text.Trim();
            pin_usr = tb_pin_usr.Text;


            if (tb_ide_usr.Text.Trim() == "")
            {
                tb_ide_usr.Focus();
                MessageBox.Show("ERROR: Debe proporcionar el usuario.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            tabla = o_ads007.Fe_con_usu(ide_usr);
            if (tabla.Rows.Count == 0)
            {
                tb_ide_usr.Focus();
                MessageBox.Show("ERROR: El Usuario no se encuentra registrado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            //Valida campo contraseña
            if (pas_usr == "Contraseña")
                pas_usr = "";

            if (pas_usr == "")
            {
                tb_pas_usr.Focus();
                MessageBox.Show("ERROR: Debe proporcionar su contraseña.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Valida campo PIN
            if (pin_usr == "Contraseña")
                pin_usr = "";

            if (pin_usr == ""){
                MessageBox.Show("Debe de proporcionar su PIN", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // VALIDA LOGUIN DEL USUARIO
            msn_res = o_ads007.Fe_ing_sis(tb_ide_usr.Text, tb_pas_usr.Text);
            if (msn_res != "OK")
            {
                tb_pas_usr.Focus();
                MessageBox.Show("ERROR '" + msn_res + "'", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Valida PIN 
            tabla = o_ads017.Fe_con_pin(ide_usr);
            if (tabla.Rows.Count == 0)
            {

                tb_pin_usr.Focus();
                MessageBox.Show("ERROR: El usuario NO tiene PIN registrado", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string pin_act = tabla.Rows[0]["va_pin_usr"].ToString();

            if (pin_usr == pin_act)
            {
                // Verifica fecha de expiración
                fec_act = o_glo_bal.fg_fec_act();
                fec_exp = DateTime.Parse(tabla.Rows[0]["va_fec_exp"].ToString());
                if (fec_act > fec_exp)
                {
                    tb_pin_usr.Focus();
                    MessageBox.Show("ERROR: El PIN del usuario ah expirado!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                tb_pin_usr.Focus();
                MessageBox.Show("ERROR: El PIN del usuario es incorrecto!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }







        private bool Fi_val_cam_pin()
        {
            string msn_res = "";

            ide_usr = tb_ide_usr.Text;
            pas_usr = tb_pas_usr.Text.Trim();
            pin_usr = tb_pin_usr.Text;

            if(tb_ide_usr.Text.Trim() == "")
            {
                tb_ide_usr.Focus();
                MessageBox.Show("ERROR: Debe proporcionar el usuario.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            tabla = o_ads007.Fe_con_usu(ide_usr);
            if(tabla.Rows.Count == 0)
            {
                tb_ide_usr.Focus();
                MessageBox.Show("ERROR: El Usuario no se encuentra registrado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            //Valida campo contraseña
            if (pas_usr == "Contraseña")
                pas_usr = "";

            if (pas_usr == "")
            {
                tb_pas_usr.Focus();
                MessageBox.Show("ERROR: Debe proporcionar su contraseña.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // VALIDA LOGUIN DEL USUARIO
            msn_res = o_ads007.Fe_ing_sis(tb_ide_usr.Text, tb_pas_usr.Text);
            if (msn_res != "OK")
            {
                tb_pas_usr.Focus();
                MessageBox.Show("ERROR '" + msn_res + "'", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

           
            return true;
        }




        private void ads000_01_Load(object sender, EventArgs e)
        {
            tb_ide_usr.Focus();
        }

        private void tb_pas_usr_Enter(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text == "Contraseña")
                tb_pas_usr.Clear();

            ps_sel_pas.Visible = true;
            ps_sel_rep.Visible = false;
        }
        private void tb_pin_usr_Enter(object sender, EventArgs e)
        {
            if (tb_pin_usr.Text == "Contraseña")
                tb_pin_usr.Clear();

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = true;
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
          
            try
            {
                err_ror = 0;

                // Valida los datos de proporcionado por el usuario
                if (ValidaDatos() == true){
                  
                    this.DialogResult = DialogResult.OK;
                    cl_glo_frm.Cerrar(this);

                }
                else
                {
                    err_ror = 1;
                }
            }
            catch (Exception ex)
            {
                err_ror = 1;
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Devuelve Cancel Como resultado
            DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }

        private void pb_ima_pin_DoubleClick(object sender, EventArgs e)
        {
            if (Fi_val_cam_pin() == false)
                return;

            Fi_abr_bus_pin();
        }
 
        void Fi_abr_bus_pin()
        {
            ads007_03f frm = new ads007_03f();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si,tabla);
        }

        private void ads000_07_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (err_ror == 1)
            {
                e.Cancel = true;
            }
        }

        private void tb_pas_usr_Validated(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text.Trim() == "")
                tb_pas_usr.Text = "Contraseña";
        }

        private void tb_pin_usr_Validated(object sender, EventArgs e)
        {
            if (tb_pin_usr.Text.Trim() == "")
                tb_pin_usr.Text = "Contraseña";
        }

        private void tb_pin_usr_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }
    }
}
