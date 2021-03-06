using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CRS_NEG;


namespace CRS_PRE
{
    public partial class ads000_06 : Form
    {
        private string Titulo = "Control de Acceso";
        //public string vp_ide_usr = "";  // ID. Usuario
        public string vp_pas_usr = "";  // Contraseña Actual
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;
        ads007 ObjUsuario = new ads007();

        DataTable tabla;
        ads007 o_ads007 = new ads007();


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public ads000_06()
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
            string nue_pas = tb_pas_usr.Text.Trim();
            string usr_ges = tb_usr_ges.Text.Trim();

            if (nue_pas == "Contraseña")
                nue_pas = "";

            // Validacion de contraseña
            if (nue_pas == ""){
                MessageBox.Show("Debe proporcionar la contraseña", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (usr_ges == ""){
                MessageBox.Show("Debe de seleccionar el usuario a gestionar", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void ads000_01_Load(object sender, EventArgs e)
        {
            //tb_ide_usr.Text = vp_ide_usr;
            tb_ide_usr.Focus();
        }

        private void tb_nue_pas_Enter(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text == "Contraseña")
                tb_pas_usr.Clear();

            ps_sel_pas.Visible = true;
            ps_sel_rep.Visible = false;
        }

        private void tb_nue_pas_Validated(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text.Trim() == "")
                tb_pas_usr.Text = "Contraseña";

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = false;
        }

        private void tb_rep_pas_Enter(object sender, EventArgs e)
        {
            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = true;
        }

        private void tb_rep_pas_Validated(object sender, EventArgs e)
        {
            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = false;
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string ide_usr = tb_ide_usr.Text;
            string pas_usr = tb_pas_usr.Text.Trim();
            string msn_res = "";
            try
            {
                // Valida los datos de proporcionado por el usuario
                if (ValidaDatos() == true){
                  
                    // VALIDA LOGUIN DEL USUARIO
                    if (tb_pas_usr.Text.Trim() == "")
                    {
                        tb_pas_usr.Focus();
                        MessageBox.Show("ERROR: Debe proporcionar su contraseña.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ;
                    }
                    msn_res = o_ads007.Login_2(tb_ide_usr.Text, tb_pas_usr.Text);
                    if (msn_res != "OK")
                    {
                        tb_pas_usr.Focus();
                        MessageBox.Show("ERROR '" + msn_res + "'", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ;
                    }



                    this.DialogResult = DialogResult.OK;
                    cl_glo_frm.Cerrar(this);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Devuelve Cancel Como resultado
            DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }

        private void bt_bus_usr_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_usr();
        }

        private void Tb_usr_ges_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_usr();
            }
        }
        void Fi_abr_bus_usr()
        {
            ads007_01 frm = new ads007_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_usr_ges.Text = frm.tb_sel_bus.Text;
            }
        }
   

    }
}
