using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG.ADS;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
//using System.Runtime.InteropServices;

namespace CRS_PRE.ADS
{
    public partial class ads000_00 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public ads000_00()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pn_sel_usr.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_sel_usr.Width, pn_sel_usr.Height, 10, 10));
            pn_sel_pas.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_sel_pas.Width, pn_sel_pas.Height, 10, 10));
            pn_sel_bda.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_sel_bda.Width, pn_sel_bda.Height, 10, 10));
        }

        //[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();
        //[DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        c_ads007 ObjUsuario = new c_ads007();
        c_ads013 o_ads013 = new c_ads013();

        //ObjLicencia = New _02.Negocio.se010_01
        //ObjGlobal = New _02.Negocio.se012_01

        string va_ser_bda; //Servidor
        string va_ins_bda;//Instancia
        string va_nom_bda; //Nombre de la BD
        string va_usu_bda; //Usuario
        string va_pas_bda;//P=sword

        DataTable Tabla = new DataTable();
        private string Titulo  = "Inicio Sesión";

        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;

        private ToolTip va_tool_tip = new ToolTip();


        private void ads000_00_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (va_est_ven)
            {
                this.Left = this.Left + (e.X - va_coo_pox);
                this.Top = this.Top + (e.Y - va_coo_poy);
            }
        }
        private void ads000_00_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
        }

        private void ads000_00_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = false;
            }
        }


        private void ads000_00_Load(object sender, EventArgs e)
        {
            va_tool_tip.SetToolTip(bt_cer_apl, "Cerrar");
            va_tool_tip.SetToolTip(pb_ima_usu, "");
            va_tool_tip.SetToolTip(pb_ima_pas, "Cambiar contraseña");
            va_tool_tip.SetToolTip(pb_log_sis, "");
            va_tool_tip.SetToolTip(pb_wha_sap, "Whatsapp");
            va_tool_tip.SetToolTip(pb_fac_bok, "Facebook");
            va_tool_tip.SetToolTip(pb_ins_gra, "Instagran");
            va_tool_tip.SetToolTip(pb_tel_gra, "Telegram");

            // Recuperar BD
            fi_rec_bdo();

            tb_ide_usr.Focus();
            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = false;

        }

        private void tb_ide_usr_Enter(object sender, EventArgs e)
        {
            if (tb_ide_usr.Text == "Usuario")
                tb_ide_usr.Clear();

            ps_sel_usr.Visible = true;
            ps_sel_pas.Visible = false;

        }
        private void tb_ide_usr_Validated(object sender, EventArgs e)
        {
            if (tb_ide_usr.Text.Trim() == "")
                tb_ide_usr.Text= "Usuario";

            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = false;
        }

        private void tb_pas_usr_Enter(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text == "Contraseña")
                tb_pas_usr.Clear();

            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = true;
        }

        private void tb_pas_usr_Validated(object sender, EventArgs e)
        {
            if (tb_pas_usr.Text.Trim() == "")
                tb_pas_usr.Text = "Contraseña";

            ps_sel_usr.Visible = false;
            ps_sel_pas.Visible = false;
        }

        private void bt_cer_apl_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void fi_rec_bdo()
        {
            string linea = "";
            int contador = 1;

            // Lea el archivo y lo muestra línea por línea.  
            //Dim archivo As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\iSoft\bd.txt")
            StreamReader archivo = File.OpenText("C:\\CREARSIS\\CREARSISbd.txt");
            linea = archivo.ReadLine();
            

            while (linea != null)
            {
                if (contador >= 2)
                {  // Leer la lista de la base de datos
                    
                    va_ser_bda = linea.Substring(1, linea.Length - 1);
                    //linea = archivo.ReadLine();
                    // Adiciona a la lista de BD
                    cb_nom_bda.Items.Add(va_ser_bda);
                }
                // Lee la siguiente linea        
                linea = archivo.ReadLine();
                contador = contador + 1;
            }
            // Cerramos el archivo
            archivo.Close();
            cb_nom_bda.SelectedIndex = 0;

        }


        private bool ValidaDatos()
        {
            string ide_usr = tb_ide_usr.Text;
            string pas_usr = tb_pas_usr.Text;

            if (ide_usr.Trim() == "Usuario")
                ide_usr = "";
            if (pas_usr.Trim() == "Contraseña")
                pas_usr = "";

            // Verifica si los campos esta vacio
            if (ide_usr == "")
            {
                MessageBox.Show("Debe proporcionar el usuario", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (pas_usr == "")
            {
                MessageBox.Show("Debe proporcionar la contraseña", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

        }

         void bt_ace_pta_Click(object sender, EventArgs e)
        {
            Fi_ing_res();
        }
        void Fi_ing_res()
        {
            try
            {

            
            // Verifica que el usuario y contraseña sean correcta
            if (ValidaDatos() == true)
            {
                string va_pas_def = ""; // Contraseña por Defector

                // Verifica que el usuario sea un usuario válido
                Tabla = new DataTable();
                string mensaje = ObjUsuario.Login(cb_nom_bda.SelectedItem.ToString(), tb_ide_usr.Text, tb_pas_usr.Text);
                if (mensaje == "OK")
                {
                    //Guarda datos en la aplicacion
                    Program.gl_usr_usr = tb_ide_usr.Text;

                    //        'Obtiene: (SG-100) -> Contraseña por Defecto
                    Tabla = o_ads013.Fe_obt_glo(1,1);
                    if(Tabla.Rows.Count != 0)
                    {
                        va_pas_def = Tabla.Rows[0]["va_glo_car"].ToString().Trim();
                        if(va_pas_def == tb_pas_usr.Text)
                        {
                            // Exige cambiar contraseña - Abre ventana cambia contraseña
                            MessageBox.Show("Debe cambiar su contraseña", "Inicio de sesión", MessageBoxButtons.OK);
                        }
                    }
                  
                    this.Visible = false;
                    ads000_02 frm = new ads000_02();
                    frm.ShowDialog();
                    Close();
                }
                else
                    MessageBox.Show(mensaje, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tb_ide_usr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Fi_ing_res();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            string mensaje = ObjUsuario.Login(cb_nom_bda.SelectedItem.ToString(), tb_ide_usr.Text, tb_pas_usr.Text);
            if (mensaje == "OK")
            {
                cl_glo_frm bb = new cl_glo_frm();
                string aa=   bb.fg_obt_cla();
                tb_ide_usr.Text = aa;
                MessageBox.Show(aa);
            }
            else
            {

            }
            
        }

        private void pb_ima_pas_Click(object sender, EventArgs e)
        {

        }

        private void pb_ver_pss_MouseHover(object sender, EventArgs e)
        {
            tb_pas_usr.UseSystemPasswordChar = false;
        }

        private void pb_ver_pss_MouseLeave(object sender, EventArgs e)
        {
            tb_pas_usr.UseSystemPasswordChar = true;
        }

        private void Pb_fac_bok_Click(object sender, EventArgs e)
        {
            // Abre la pagina de facebook para contacto
            System.Diagnostics.Process.Start("https://www.facebook.com/crearsis/");
        }

        private void Pb_wha_sap_Click(object sender, EventArgs e)
        {
            // Abre la pagina de Whatsaap para contacto
            System.Diagnostics.Process.Start("https://www.facebook.com/crearsis/");
        }

        private void Pb_wha_sap_MouseLeave(object sender, EventArgs e)
        {
            pb_wha_sap.Location = new Point(21, 279);
        }


        private void Pb_wha_sap_MouseEnter(object sender, EventArgs e)
        {
            pb_wha_sap.Location = new Point(21, 269);
        }

        private void Pb_ins_gra_Click(object sender, EventArgs e)
        {
            // Abre la pagina de Instagram para contacto
            System.Diagnostics.Process.Start("https://www.facebook.com/crearsis/");
        }

        private void Pb_tel_gra_Click(object sender, EventArgs e)
        {
            // Abre la pagina de Telegran para contacto
            System.Diagnostics.Process.Start("https://www.facebook.com/crearsis/");
        }

    }
}
