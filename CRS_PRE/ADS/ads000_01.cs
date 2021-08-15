using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CRS_NEG;


namespace CRS_PRE
{
    public partial class ads000_01 : Form
    {
        private string Titulo = "Inicio Sesión";
        public string vp_ide_usr = "";  // ID. Usuario
        public string vp_pas_usr = "";  // Contraseña Actual
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;
        ads007 ObjUsuario = new ads007();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public ads000_01()
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
            tb_nue_pas.UseSystemPasswordChar = false;
        }
        private void pb_mos_pas_MouseLeave(object sender, EventArgs e)
        {
            tb_nue_pas.UseSystemPasswordChar = true;
        }
        private void pb_mos_rep_MouseHover(object sender, EventArgs e)
        {
            tb_rep_pas.UseSystemPasswordChar = false;
        }
        private void pb_mos_rep_MouseLeave(object sender, EventArgs e)
        {
            tb_rep_pas.UseSystemPasswordChar = true;
        }

        private bool ValidaDatos()
        {
            string nue_pas = tb_nue_pas.Text.Trim();
            string rep_pas = tb_rep_pas.Text.Trim();

            if (nue_pas == "Contraseña")
                nue_pas = "";

            if (rep_pas == "Contraseña")
                rep_pas = "";

            // Validacion de contraseña
            if (nue_pas == ""){
                MessageBox.Show("Debe proporcionar la contraseña nueva", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nue_pas == vp_pas_usr){
                MessageBox.Show("Debe proporcionar una contraseña distinta a la actual", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            if (nue_pas.Length <= 3){
                MessageBox.Show("La contraseña DEBE ser mayor a 3 digitos", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rep_pas == ""){
                MessageBox.Show("Debe repetir la contraseña nueva", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nue_pas != rep_pas){
                MessageBox.Show("La contraseña no coiciden, Verifique los datos proporcionados", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ads000_01_Load(object sender, EventArgs e)
        {
            tb_ide_usr.Text = vp_ide_usr;
            tb_nue_pas.Focus();
        }

        private void tb_nue_pas_Enter(object sender, EventArgs e)
        {
            if (tb_nue_pas.Text == "Contraseña")
                tb_nue_pas.Clear();

            ps_sel_pas.Visible = true;
            ps_sel_rep.Visible = false;
        }

        private void tb_nue_pas_Validated(object sender, EventArgs e)
        {
            if (tb_nue_pas.Text.Trim() == "")
                tb_nue_pas.Text = "Contraseña";

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = false;
        }

        private void tb_rep_pas_Enter(object sender, EventArgs e)
        {
            if (tb_rep_pas.Text == "Contraseña")
                tb_rep_pas.Clear();

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = true;
        }

        private void tb_rep_pas_Validated(object sender, EventArgs e)
        {
            if (tb_rep_pas.Text.Trim() == "")
                tb_rep_pas.Text = "Contraseña";

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = false;
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string ide_usr = vp_ide_usr;
            string nue_pas = tb_nue_pas.Text.Trim();

            try
            {
                // Valida los datos de proporcionado por el usuario
                if (ValidaDatos() == true){
                    // Actualiza la contraseña del usuario
                    DataTable Tabla = new DataTable();
                    ObjUsuario.Fe_edi_psw(ide_usr,  nue_pas);
                    // Devuelve OK Como resultado
                    MessageBox.Show("Su contraseña se ha actualizado correctamente", "Inicio de sesión");
                    DialogResult = DialogResult.OK;
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
            DialogResult = DialogResult.OK;
        }
        
    }
}
