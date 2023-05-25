using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads000 - Actualiza Contraseña                         */
    /* Descripción: Actualiza la Contraseña del Usuario                   */
    /*       Autor: JEJR - Crearsis             Fecha: 23-03-2021         */
    /**********************************************************************/
    public partial class ads000_01 : Form
    {
        public string vp_ide_usr = "";  // ID. Usuario
        public string vp_pas_usr = "";  // Contraseña Actual
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;
        ads007 o_ads007 = new ads007();
        ads013 o_ads013 = new ads013();
        DataTable Tabla = new DataTable();

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
            FormBorderStyle = FormBorderStyle.None;
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
            if (va_est_ven){
                Left = Left + (e.X - va_coo_pox);
                Top = Top + (e.Y - va_coo_poy);
            }
        }
        private void ads000_01_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left){
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
        }
        private void ads000_01_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)            
                va_est_ven = false;            
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

        /// <summary>
        /// Función: Valida Datos Proporcionado
        /// </summary>
        /// <returns></returns>
        private string Fi_val_dat()
        {
            string nue_pas = tb_nue_pas.Text.Trim();
            string rep_pas = tb_rep_pas.Text.Trim();

            if (nue_pas == "Contraseña")
                nue_pas = "";

            if (rep_pas == "Contraseña")
                rep_pas = "";

            // Obtiene la Longitud Minima que DEBE tener una contraseña de usuario
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 0);
            if (Tabla.Rows.Count == 0)
                return "NO está definido la Clave (1-0) : Longitud Mínima Contraseña Usuario";

            int lon_min = int.Parse(Tabla.Rows[0]["va_glo_ent"].ToString());
            
            // Validacion Datos Proporcionados
            if (nue_pas == "")
                return "DEBE proporcionar la Contraseña Nueva";            
            if (nue_pas == vp_pas_usr)
                return "DEBE proporcionar una Contraseña DISTINTA a la Actual";                        
            if (nue_pas.Length <= lon_min)
                return "La Contraseña DEBE ser MAYOR a " + lon_min + " digitos";            
            if (rep_pas == "")
                return "DEBE repetir la Contraseña Nueva";            
            if (nue_pas != rep_pas)
                return "Las Contraseñas NO coiciden, Verifique los datos proporcionados";            

            return "OK";
        }

        private void ads000_01_Load(object sender, EventArgs e)
        {
            tb_ide_usr.Text = vp_ide_usr;
            tb_nue_pas.Focus();
        }

        // Evento Enter: Text Repetir Contraseña
        private void tb_nue_pas_Enter(object sender, EventArgs e)
        {
            if (tb_nue_pas.Text == "Contraseña")
                tb_nue_pas.Clear();

            ps_sel_pas.Visible = true;
            ps_sel_rep.Visible = false;
        }

        // Evento Validated: Text Nueva Contraseña
        private void tb_nue_pas_Validated(object sender, EventArgs e)
        {
            if (tb_nue_pas.Text.Trim() == "")
                tb_nue_pas.Text = "Contraseña";

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = false;
        }

        // Evento Enter: Text Repetir Contraseña
        private void tb_rep_pas_Enter(object sender, EventArgs e)
        {
            if (tb_rep_pas.Text == "Contraseña")
                tb_rep_pas.Clear();

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = true;
        }

        // Evento Validated: Text Repetir Contraseña
        private void tb_rep_pas_Validated(object sender, EventArgs e)
        {
            if (tb_rep_pas.Text.Trim() == "")
                tb_rep_pas.Text = "Contraseña";

            ps_sel_pas.Visible = false;
            ps_sel_rep.Visible = false;
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string ide_usr = vp_ide_usr;
            string nue_pas = tb_nue_pas.Text.Trim();

            try
            {
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                // Actualiza la contraseña del usuario
                o_ads007.Fe_edi_psw(ide_usr, nue_pas);
                // Devuelve OK Como resultado
                MessageBox.Show("Su contraseña se ha actualizado correctamente", Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.OK;
        }        
    }
}
