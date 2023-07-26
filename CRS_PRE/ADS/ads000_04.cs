using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.VisualBasic.Devices;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads000_04 - Clave Licencia                            */
    /* Descripción: Licencia del Sistema                                  */
    /*       Autor: JEJR - Crearsis             Fecha: 23-03-2021         */
    /**********************************************************************/
    public partial class ads000_04 : Form
    {        
        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;
        General ob_gen_ral = new General();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public ads000_04()
        {
            InitializeComponent();
        }        

        private void ads000_04_MouseMove(object sender, MouseEventArgs e)
        {            
            if (va_est_ven){
                Left += e.X - va_coo_pox;
                Top += e.Y - va_coo_poy;
            }
        }
        private void ads000_04_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left){
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
        }

        private void ads000_04_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                va_est_ven = false;
        }

        private void ads000_04_Load(object sender, EventArgs e)
        {
            lb_lic_mos.Text = ob_gen_ral.Fu_obt_pin();
        }

        // Evento Leave: Clave Licencia
        private void tb_cla_lic_Leave(object sender, EventArgs e)
        {
            if (tb_cla_lic.Text.CompareTo("") == 0)
                tb_cla_lic.Text = "Llave123.";
        }

        // Evento Enter: Clave Licencia
        private void tb_cla_lic_Enter(object sender, EventArgs e)
        {
            if (tb_cla_lic.Text.CompareTo("Llave123.") == 0){
                tb_cla_lic.Text = "";
                tb_cla_lic.Focus();
            }
        }

        // Evento KeyPress: Clave Licencia
        private void tb_cla_lic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                string cla_pin = ob_gen_ral.Fu_obt_pin();
                if (tb_cla_lic.Text == "Llave123."){
                    MessageBox.Show("NO ha digitado ninguna clave", "Error");
                }else if (tb_cla_lic.Text == cla_pin){
                    DialogResult = DialogResult.OK;
                }else{
                    MessageBox.Show("La clave digitada es incorrecta", "Error");
                }
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            string cla_pin = ob_gen_ral.Fu_obt_pin();
            if (tb_cla_lic.Text == "Llave123.")
            {
                MessageBox.Show("NO ha digitado ninguna clave", "Error");
            }
            else if (tb_cla_lic.Text == cla_pin)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("La clave digitada es incorrecta", "Error");
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
