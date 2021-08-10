using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;


namespace CRS_PRE
{
    public partial class ads000_05 : Form
    {

        #region "Mover y cerrar pantalla"

            private int va_coo_pox = 0;
            private int va_coo_poy = 0;
            private bool va_est_ven = false;

            private ToolTip va_tool_tip = new ToolTip();

            private void pn_tit_ulo_MouseMove(object sender, MouseEventArgs e)
            {
                if (va_est_ven)
                {
                    this.Left = this.Left + (e.X - va_coo_pox);
                    this.Top = this.Top + (e.Y - va_coo_poy);
                }
            }
            private void pn_tit_ulo_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    va_est_ven = true;
                    va_coo_pox = e.X;
                    va_coo_poy = e.Y;
                }
                Cursor = Cursors.SizeAll;
                cl_glo_frm.Activar(this);
            }
            private void pn_tit_ulo_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    va_est_ven = false;
                }
                Cursor = Cursors.Default;
            }


            private void pn_tit_ulo_MouseLeave(object sender, EventArgs e)
            {
                Cursor = Cursors.Default;
            }

            private void pn_tit_ulo_Click(object sender, EventArgs e)
            {
                cl_glo_frm.Activar(this);
            }


        private void pb_min_pan_MouseEnter(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Hand;
            }

            private void pb_min_pan_MouseLeave(object sender, EventArgs e)
            {
                this.Cursor = Cursors.Default;
            }

            private void pb_cer_pan_Click(object sender, EventArgs e)
            {
                cl_glo_frm.Cerrar( this);
            }

           
        #endregion

        public dynamic frm_pad;
        public int frm_tip;
        public ads000_05()
        {
            InitializeComponent();
        }
        private void frm_Load(object sender, EventArgs e)
        {

        }
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar( this);
        }
        private void mn_cre_ar_Click(object sender, EventArgs e)
        {

           

        }
        private void mn_edi_tar_Click(object sender, EventArgs e)
        {

        }

       
    }
}
