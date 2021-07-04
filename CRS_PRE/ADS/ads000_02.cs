using System;
using System.Data;
using System.Windows.Forms;

//using System.Runtime.InteropServices;
using System.Threading;
using CRS_NEG.ADS;
using CRS_PRE.INV;
using CRS_PRE.CMR;

namespace CRS_PRE.ADS
{
    public partial class ads000_02 : Form
    {        
        DataTable Tabla = new DataTable();
        c_ads007 o_ads007 = new c_ads007();
        c_ads013 o_ads013 = new c_ads013();
        c_ads008 o_ads008 = new c_ads008();
        ToolTip va_tol_tip = new ToolTip();

        public ads000_02()
        {
            InitializeComponent();
        }

        private void ads000_02_Load(object sender, EventArgs e)
        {
            //** INICIALIZA FORMULARIO DE CARGA INICIAL PARA REPORTES
            bt_men_rpt_Click();

            lb_ide_usr.Text = "";
            lb_nom_usr.Text = "";
            lb_nom_equ.Text = "";

            // Lee datos del Usuario Logueado
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_usu(o_ads007.va_ide_usr);
            if (Tabla.Rows.Count > 0)
            {
                lb_ide_usr.Text = Tabla.Rows[0]["va_ide_usr"].ToString();
                lb_nom_usr.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
            }            

            // Obtiene nombre de la empresa (1-4)
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 4);
            this.Text = this.Text + Tabla.Rows[0]["va_glo_car"].ToString();         

            // Obtiene Nombre del Equipo
            lb_nom_equ.Text = SystemInformation.ComputerName;
           
            // Envia a funcion que verifica y desplega aplicaciones permitidas
            fi_apl_per(lb_ide_usr.Text);
        }

        // CREA EL HILO PARA ABRIR LA VENTANA (ads000_R00w)
        public static void fi_run_rpt()
        {
            try
            {
                ads000_R00w frm = new ads000_R00w();
                frm.Visible = false;

                Application.Run(frm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // CREA EL HILO PARA ABRIR LA VENTANA (ads200)
        public static void fi_run_ads()
        {
            try
            {
                Application.Run(new ads200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // CREA EL HILO PARA ABRIR LA VENTANA (cmr200)
        public static void fi_run_cmr()
        {
            try
            {
                Application.Run(new cmr200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // CREA EL HILO PARA ABRIR LA VENTANA (res200)
        public static void fi_run_res()
        {
            try{
                // Llama el Hilo para abrir la ventana de Restaurant
                Application.Run(new res200());
            }catch (Exception ex){
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }


        // CREA EL HILO PARA ABRIR LA VENTANA (inv200)
        public static void fi_run_inv()
        {
            try
            {
                Application.Run(new inv200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        
        /// <summary>
        /// Verifica las ventanas abierta por el usuario sea menor al permitidas
        /// Retorna True si llego al maximo permitido
        /// Retorna False si esta dento del parametro permitido
        /// </summary>
        /// <param name="ide_usr"></param>
        /// <returns></returns>
        private Boolean fi_ven_max(string ide_usr)
        {
            // Lee datos del Usuario Logueado
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_usu(o_ads007.va_ide_usr);

            // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
            if (Convert.ToInt32(Tabla.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBox.Show("El usuario YA tiene abierta sus: " + Program.gl_nro_win + " ventanas permitidas ", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return true;
            }
            return false;
        }

        private void bt_men_res_Click(object sender, EventArgs e)
        {
            try {
                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false)
                {
                    // Crea el hilo del menu Restaurant
                    Thread thread = new Thread(fi_run_res);
                    thread.SetApartmentState(ApartmentState.STA);

                    //Inicia el hilo
                    thread.Start();
                }
            }catch (Exception ex){                
                MessageBox.Show("Error 100: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void bt_men_com_Click(object sender, EventArgs e)
        {            
            try
            {
                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false)
                {
                    // Crea el hilo del menu Comercializacion
                    Thread thread = new Thread(fi_run_cmr);
                    thread.SetApartmentState(ApartmentState.STA);

                    //Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 101: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void bt_men_inv_Click(object sender, EventArgs e)
        {         
            try
            {
                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false)
                {
                    // Crea el hilo del menu Inventario
                    Thread thread = new Thread(fi_run_inv);
                    thread.SetApartmentState(ApartmentState.STA);

                    //Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 102: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void bt_men_adm_Click(object sender, EventArgs e)
        {           
            try
            {
                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false)
                {
                    // Crea el hilo del menu Administrador
                    Thread thread = new Thread(fi_run_ads);
                    thread.SetApartmentState(ApartmentState.STA);

                    //Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 103: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void bt_men_rpt_Click()
        {            
            try
            {
                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false)
                {
                    // Crea el hilo del menu Administrador
                    Thread thread = new Thread(fi_run_rpt);
                    thread.SetApartmentState(ApartmentState.STA);

                    //Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 103: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // Aplicaciones Permitidas
        private void fi_apl_per(string ide_usr)
        {
            // Obtiene permisos del usuario sobre las aplicaciones
            Tabla = new DataTable();
            Tabla = o_ads008.Fe_ads008_01(ide_usr);

            // Habilita/Deshabilita las aplicaciones autorizadas
            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                if (Tabla.Rows[i]["va_ide_apl"].ToString() == "ads200")
                    bt_men_adm.Visible = true;
                if (Tabla.Rows[i]["va_ide_apl"].ToString() == "inv200")
                    bt_men_inv.Visible = true;
                if (Tabla.Rows[i]["va_ide_apl"].ToString() == "cmr200")
                    bt_men_com.Visible = true;
                if (Tabla.Rows[i]["va_ide_apl"].ToString() == "res200")
                    bt_men_res.Visible = true;
            }
        }

        // Cambia colores los botones cuando el mause se acerca y se aleja
        private void bt_men_res_MouseHover(object sender, EventArgs e)
        {
            bt_men_res.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_res_MouseEnter(object sender, EventArgs e)
        {
            bt_men_res.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_res_MouseLeave(object sender, EventArgs e)
        {
            bt_men_res.BackColor = System.Drawing.Color.FromArgb(23, 43, 76);
        }

        private void bt_men_com_MouseHover(object sender, EventArgs e)
        {
            bt_men_com.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_com_MouseEnter(object sender, EventArgs e)
        {
            bt_men_com.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_com_MouseLeave(object sender, EventArgs e)
        {
            bt_men_com.BackColor = System.Drawing.Color.FromArgb(23, 43, 76);
        }

        private void bt_men_inv_MouseHover(object sender, EventArgs e)
        {
            bt_men_inv.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_inv_MouseEnter(object sender, EventArgs e)
        {
            bt_men_inv.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_inv_MouseLeave(object sender, EventArgs e)
        {
            bt_men_inv.BackColor = System.Drawing.Color.FromArgb(23, 43, 76);
        }

        private void bt_men_adm_MouseHover(object sender, EventArgs e)
        {
            bt_men_adm.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_adm_MouseEnter(object sender, EventArgs e)
        {
            bt_men_adm.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void bt_men_adm_MouseLeave(object sender, EventArgs e)
        {
            bt_men_adm.BackColor = System.Drawing.Color.FromArgb(23, 43, 76);
        }

        private void bt_men_pri_Click(object sender, EventArgs e)
        {
            if (pn_men_pri.Width == 200)
            {
                pn_men_pri.Width = 40;
                bt_men_pri.Location = new System.Drawing.Point(4, 7);
                lb_ide_usr.Visible = false;
                lb_nom_usr.Visible = false;
                lb_nom_equ.Visible = false;
                lp_con_apl.Width = 45;
                va_tol_tip.SetToolTip(bt_men_res, "Restaurant");
                va_tol_tip.SetToolTip(bt_men_com, "Comercialización");
                va_tol_tip.SetToolTip(bt_men_inv, "Inventario");
                va_tol_tip.SetToolTip(bt_men_adm, "Administración");
            }
            else
            {
                pn_men_pri.Width = 200;
                bt_men_pri.Location = new System.Drawing.Point(164, 7);
                lb_ide_usr.Visible = true;
                lb_nom_usr.Visible = true;
                lb_nom_equ.Visible = true;
                lp_con_apl.Width = 205;
                va_tol_tip.SetToolTip(bt_men_res, "");
                va_tol_tip.SetToolTip(bt_men_com, "");
                va_tol_tip.SetToolTip(bt_men_inv, "");
                va_tol_tip.SetToolTip(bt_men_adm, "");
            }
        }

        private void lb_nom_equ_Click(object sender, EventArgs e)
        {
            ads000_03 frm = new ads000_03();
            frm.Show();
            //cl_glo_frm.abrir(this, form, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, null);
        }
    }
}
