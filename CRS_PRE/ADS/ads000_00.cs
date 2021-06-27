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
        private string Titulo = "Inicio Sesión";
        private string va_ser_bda;  //Servidor
        private string va_ins_bda;  //Instancia
        private string va_nom_bda;  //Nombre de la BD
        private string va_usu_bda;  //Usuario
        private string va_pas_bda;  //P=sword               
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;
        private DataTable Tabla = new DataTable();
        private ToolTip va_tool_tip = new ToolTip();

        c_ads007 ObjUsuario = new c_ads007();
        c_ads013 o_ads013 = new c_ads013();
        //ObjLicencia = New _02.Negocio.se010_01
        //ObjGlobal = New _02.Negocio.se012_01

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
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
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));            
            pn_con_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_con_usr.Width, pn_con_usr.Height, 15, 15));
            pn_fon_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_usr.Width, pn_fon_usr.Height, 15, 15));
            pn_con_pas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_con_pas.Width, pn_con_pas.Height, 15, 15));
            pn_fon_pas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_pas.Width, pn_fon_pas.Height, 15, 15));
            pn_con_bda.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_con_bda.Width, pn_con_bda.Height, 15, 15));
            pn_fon_bda.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_bda.Width, pn_fon_bda.Height, 15, 15));
        }

        private void ads000_00_MouseMove(object sender, MouseEventArgs e)
        {            
            if (va_est_ven){
                this.Left = this.Left + (e.X - va_coo_pox);
                this.Top = this.Top + (e.Y - va_coo_poy);
            }
        }

        private void ads000_00_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left){
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
        }

        private void ads000_00_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left){
                va_est_ven = false;
            }
        }

        private void ads000_00_Load(object sender, EventArgs e)
        {
            va_tool_tip.SetToolTip(bt_cer_apl, "Cerrar");
            va_tool_tip.SetToolTip(pb_ima_pas, "Cambiar contraseña");            
            va_tool_tip.SetToolTip(pb_wha_sap, "Whatsapp");
            va_tool_tip.SetToolTip(pb_fac_bok, "Facebook");
            va_tool_tip.SetToolTip(pb_ins_gra, "Instagran");
            va_tool_tip.SetToolTip(pb_gma_ail, "Gmail");

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

        private void tb_pas_usr_Enter(object sender, EventArgs e){
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

        private void bt_cer_apl_Click(object sender, EventArgs e){
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

        private bool fi_val_dat(){
            string ide_usr = tb_ide_usr.Text;
            string pas_usr = tb_pas_usr.Text;

            if (ide_usr.Trim() == "Usuario")
                ide_usr = "";
            if (pas_usr.Trim() == "Contraseña")
                pas_usr = "";

            // Verifica si los campos esta vacio
            if (ide_usr == ""){
                MessageBox.Show("Debe proporcionar el usuario", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (pas_usr == ""){
                MessageBox.Show("Debe proporcionar la contraseña", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        void bt_ace_pta_Click(object sender, EventArgs e)
        {
            fi_ing_res();
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void fi_ing_res(){
            string pas_def = "";    // Contraseña por Defector

            try {            
                // Verifica que el usuario y contraseña sean correcta
                if (fi_val_dat() == true)
                {        
                    // Verifica que el usuario sea un usuario válido
                    Tabla = new DataTable();
                    string mensaje = ObjUsuario.Login(cb_nom_bda.SelectedItem.ToString(), tb_ide_usr.Text, tb_pas_usr.Text);
                    if (mensaje == "OK")
                    {
                        // Guarda datos en la aplicacion
                        Program.gl_usr_usr = tb_ide_usr.Text;

                        // 'Obtiene: (SG-100) -> Contraseña por Defecto
                        Tabla = o_ads013.Fe_obt_glo(1, 1);
                        if (Tabla.Rows.Count != 0)
                        {
                            pas_def = Tabla.Rows[0]["va_glo_car"].ToString().Trim();
                            if (pas_def == tb_pas_usr.Text)
                            {
                                // Exige cambiar contraseña - Abre ventana cambia contraseña
                                MessageBox.Show("Debe cambiar su contraseña", "Inicio de sesión", MessageBoxButtons.OK);
                            }
                        }

                        this.Visible = false;
                        ads000_02 frm = new ads000_02();
                        frm.ShowDialog();
                        Close();
                    } else { 
                        MessageBox.Show(mensaje, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch (Exception ex){
                MessageBox.Show(ex.Message, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tb_ide_usr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                fi_ing_res();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            string mensaje = ObjUsuario.Login(cb_nom_bda.SelectedItem.ToString(), tb_ide_usr.Text, tb_pas_usr.Text);
            if (mensaje == "OK"){
                cl_glo_frm bb = new cl_glo_frm();
                string aa = bb.fg_obt_cla();
                tb_ide_usr.Text = aa;
                MessageBox.Show(aa);
            }else{

            }            
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
