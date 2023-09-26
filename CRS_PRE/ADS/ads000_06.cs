using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CRS_NEG;
using System.Windows.Forms.DataVisualization.Charting;


namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads000 - Control de Acceso                            */
    /*      Opción: Seguridad - Control del Acceso                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-09-2023         */
    /**********************************************************************/
    public partial class ads000_06 : Form
    {
        /* Variables */        
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;
        /* Objetos */
        DataTable Tabla = new DataTable();
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
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pn_usr_adm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_usr_adm.Width, pn_usr_adm.Height, 15, 15));
            pn_fon_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_usr.Width, pn_fon_usr.Height, 15, 15));
            pn_pas_adm.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_pas_adm.Width, pn_pas_adm.Height, 15, 15));
            pn_fon_pas.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_pas.Width, pn_fon_pas.Height, 15, 15));
            pn_ide_usr.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_ide_usr.Width, pn_ide_usr.Height, 15, 15));
            pn_fon_rep.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_fon_rep.Width, pn_fon_rep.Height, 15, 15));
        }

        private void ads000_01_Load(object sender, EventArgs e)
        {
            //tb_ide_usr.Text = vp_ide_usr;
            tb_usr_adm.Focus();
            // Inicializa Datos
            tb_ide_usr.Text = cl_glo_bal.glo_ide_usr;
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_usr_adm.Text = string.Empty;
            tb_pas_adm.Text = string.Empty;
            tb_ide_usr.Text = string.Empty;
            tb_usr_adm.Focus();
        }

        // Funcion: Buscar Usuario
        private void Fi_bus_usr()
        {
            ads007_01 frm = new ads007_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
                tb_ide_usr.Text = frm.tb_ide_usr.Text;
        }

        // Evento MouseMove : Formulario Principal
        private void ads000_06_MouseMove(object sender, MouseEventArgs e)
        {            
            if (va_est_ven)
            {
                Left = Left + (e.X - va_coo_pox);
                Top = Top + (e.Y - va_coo_poy);
            }
        }
        // Evento MouseDown : Formulario Principal
        private void ads000_06_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
        }
        // Evento MouseUp : Formulario Principal
        private void ads000_06_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = false;
            }
        }
        // Evento MouseHover : Mostrar Pasword
        private void pb_mos_pas_MouseHover(object sender, EventArgs e)
        {
            tb_pas_adm.UseSystemPasswordChar = false;
        }
        // Evento MouseLeave : Mostrar Pasword
        private void pb_mos_pas_MouseLeave(object sender, EventArgs e)
        {
            tb_pas_adm.UseSystemPasswordChar = true;
        }
        // Evento Enter : Usuario Administrador
        private void tb_usr_adm_Enter(object sender, EventArgs e)
        {            
            ps_usr_adm.Visible = true;
            ps_pas_adm.Visible = false;
        }
        // Evento Validated : Usuario Administrador
        private void tb_usr_adm_Validated(object sender, EventArgs e)
        {
            ps_usr_adm.Visible = false;
            ps_pas_adm.Visible = false;
        }
        // Evento Enter : Contraseña Administrador
        private void tb_pas_adm_Enter(object sender, EventArgs e)
        {
            if (tb_pas_adm.Text.Trim() == "Contraseña")
                tb_pas_adm.Clear();

            ps_usr_adm.Visible = false;
            ps_pas_adm.Visible = true;
        }
        // Evento Validated : Contraseña Administrador
        private void tb_pas_adm_Validated(object sender, EventArgs e)
        {
            if (tb_pas_adm.Text.Trim() == "")
                tb_pas_adm.Text = "Contraseña";

            ps_usr_adm.Visible = false;
            ps_pas_adm.Visible = false;
        }
        // Evento KeyDown : ID. Usuario
        private void tb_ide_usr_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
                Fi_bus_usr();
        }
        // Evento Click : Button Buscar Usuario
        private void bt_bus_usr_Click(object sender, EventArgs e)
        {
            Fi_bus_usr();
        }

        // Valida los datos proporcionados
        private string Fi_val_dat()
        {
            // Valida que el campo ID. Usuario Administrador NO este vacio
            if (tb_usr_adm.Text.Trim() == ""){
                tb_usr_adm.Focus();
                return "DEBE proporcionar el ID. Usuario Administrador";
            }

            // Valida que el campo la Contraseña Administrador NO este vacio
            if (tb_pas_adm.Text.Trim() == "" || tb_pas_adm.Text.Trim() == "Contraseña")
            {
                tb_pas_adm.Focus();
                return "DEBE proporcionar la Contraseña del del Usuario Administrador";
            }

            // Valida que el campo ID. Usuario NO este vacio
            if (tb_ide_usr.Text.Trim() == ""){
                tb_ide_usr.Focus();
                return "DEBE proporcionar el ID. Usuario a Gestionar";
            }            

            // Verifica SI existe el Usuario Administrador
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_usr_adm.Text.Trim());
            if (Tabla.Rows.Count == 0){
                tb_usr_adm.Focus();
                return "NO existe registrado el Usuario Administrador (" + tb_usr_adm.Text.Trim() + ")";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("H") != 0) {
                tb_usr_adm.Focus();
                return "El ID. Usuario Administrador (" + tb_usr_adm.Text.Trim()  + ") está Deshabilitado";
            }

            // Verifica SI la contraseña del Usuario Administrador
            string res_ini = o_ads007.Fe_ing_sis(tb_usr_adm.Text.Trim(), tb_pas_adm.Text.Trim());
            if (res_ini != "OK"){
                tb_usr_adm.Focus();
                return "La Contraseña del Usuario Administrador (" + tb_usr_adm.Text.Trim() + ") es incorrecta";
            }

            // Verifica SI existe el Usuario a Gestionar
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count == 0){
                tb_ide_usr.Focus();
                return "NO existe registrado el ID. Usuario a Gestionar";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString().CompareTo("H") != 0){
                tb_usr_adm.Focus();
                return "El ID. Usuario a Gestionar está Deshabilitado";
            }

            return "OK";
        }

        // Evento Click : Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }                
                // Devuelve Estado de Resultado
                DialogResult = DialogResult.OK;
                // Inicializa Campos
                Fi_lim_pia();
                // Cierra Formulario
                cl_glo_frm.Cerrar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }              
        }
        // Evento Click : Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Devuelve Estado de Respuesta
            DialogResult = DialogResult.Cancel;
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }      
    }
}
