using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using CRS_NEG;
using CRS_PRE.INV;
using CRS_PRE.ADS;
using System.IO;
using System.Drawing;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads000_02 - Menú Principal                            */
    /* Descripción: Opciones Habilitada al Usuario Logeado                */
    /*       Autor: JEJR - Crearsis             Fecha: 23-03-2021         */
    /**********************************************************************/
    public partial class ads000_02 : Form
    {
        ToolTip va_tol_tip = new ToolTip();
        DataTable Tabla = new DataTable();
        adp002 o_adp002 = new adp002();
        adp006 o_adp006 = new adp006();
        ads002 o_ads002 = new ads002();        
        ads007 o_ads007 = new ads007();
        ads013 o_ads013 = new ads013();
        ads008 o_ads008 = new ads008();        
        ads024 o_ads024 = new ads024();        
        General general = new General();

        int vg_lic_sis = 0; // Licencia del Sistema (0=Sin Licencia; 1=Con Licencia)

        public ads000_02()
        {
            InitializeComponent();
        }

        private void ads000_02_Load(object sender, EventArgs e)
        {
            // Inicializa Formulario de Carga Inicial para Reportes
            bt_men_rpt_Click();
            
            lb_ide_usr.Text = "";
            lb_nom_usr.Text = "";
            lb_nom_equ.Text = "";
             string sex_per = "H";
                int per_ide = 0;

            // Lee datos del Usuario Logueado
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_usu(Program.gl_ide_usr);
            if (Tabla.Rows.Count > 0){
                lb_ide_usr.Text = Tabla.Rows[0]["va_ide_usr"].ToString();
                lb_nom_usr.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
                per_ide = int.Parse(Tabla.Rows[0]["va_ide_per"].ToString());
            }

            // Lee Datos de la Perona
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(per_ide);
            if (Tabla.Rows.Count > 0){
                sex_per = Tabla.Rows[0]["va_sex_per"].ToString();
            }
       
            // Despliega Imagen de la Persona
            Tabla = new DataTable();
            Tabla = o_adp006.Fe_con_ima(per_ide, "FP");
            if (Tabla.Rows.Count > 0){
                byte[] byt_ima = new byte[0];
                byt_ima = (byte[])Tabla.Rows[0]["va_img_arc"];
                MemoryStream men_str = new MemoryStream(byt_ima);
                pb_ima_usr.Image = Image.FromStream(men_str);
            }
            else {
                if (sex_per.CompareTo("H") == 0)
                    pb_ima_usr.Image = Properties.Resources.im_usr_hom;
                else
                    pb_ima_usr.Image = Properties.Resources.im_usr_muj;
            }                     

            // Obtiene nombre de la empresa (1-4)
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 4);
            Text = Text + ": " + Tabla.Rows[0]["va_glo_car"].ToString();         

            // Despliega el nombre del Equipo
            lb_nom_equ.Text = SystemInformation.ComputerName;

            // Lee datos de la licencia del Sistema
            fi_lic_sis();

            // Despliega las aplicaciones permitidas al usuario
            fi_apl_per(lb_ide_usr.Text);
        }

        /*****************************************************
        /*    Crea el Hilo para abrir la venta mas rapido   */
        /* Aplicacion (crm200 : Comercialización)           */
        /* Aplicacion (res200 : Restaurante)                */
        /* Aplicacion (tes200 : Tesorería)                  */
        /* Aplicacion (ctb200 : Contabilidad)               */
        /* Aplicacion (inv200 : Inventario)                 */
        /* Aplicacion (ads200 : Administración y Seguridad) */
        /****************************************************/        
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
        public static void fi_run_res()
        {
            try
            {
                Application.Run(new res200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        public static void fi_run_tes()
        {
            try
            {
                //Application.Run(new tes200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        public static void fi_run_ctb()
        {
            try
            {
                //Application.Run(new ctb200());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error: " + Convert.ToChar(10) + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
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

        /// <summary>
        /// Verifica las ventanas abierta por el usuario sea menor al permitidas
        /// Retorna True si llego al maximo permitido
        /// Retorna False si esta dento del parametro permitido
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        private bool fi_ven_max(string ide_usr)
        {
            // Lee datos del Usuario Logueado
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_usu(ide_usr);

            // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
            if (Convert.ToInt32(Tabla.Rows[0]["va_win_max"]) <= Program.gl_nro_win)
            {
                MessageBox.Show("El Usuario YA tiene abierta sus: " + Program.gl_nro_win + " ventanas permitidas ", Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return true;
            }
            return false;
        }                                  

        // Licencia y Autorizaciones del Sistema
        private void fi_lic_sis() {
            try
            {
                lb_val_lic.Text = string.Empty;
                string fec_act = general.Fe_fec_act().ToString();

                // Lee datos de la licencia
                Tabla = new DataTable();
                Tabla = o_ads013.Fe_obt_lic();
                if (Tabla.Rows.Count > 0)
                {                    
                    string fec_exp = Tabla.Rows[0]["va_fec_exp"].ToString().Trim();
                    if (fec_exp.CompareTo("") == 0) {
                        vg_lic_sis = 0; // 0=Sin Licencia
                        lb_val_lic.Text = "Validez de la Licencia: Sin Licencia";                        
                        return;
                    }
                               
                    DateTime exp_fec = DateTime.Parse(fec_exp);
                    DateTime act_fec = DateTime.Parse(fec_act);
                    TimeSpan dif_fch = exp_fec - act_fec;
                    int nro_dia = dif_fch.Days;
                    if (dif_fch.Hours > 0){
                        nro_dia += 1;
                    }

                    if (nro_dia == 0) {
                        vg_lic_sis = 1; // 1=Con Licencia
                        lb_val_lic.Text = "Validez de la Licencia: Vence Hoy a las 23:59 pm";
                        return;
                    }
                    
                    if (nro_dia >= 0 && nro_dia <= 7){
                        vg_lic_sis = 1; // 1=Con Licencia                        
                        lb_val_lic.Text = "Validez de la Licencia: Próximo a Vencerse en " + nro_dia + " días.";
                        return;
                    }

                    if (nro_dia < 0) {
                        vg_lic_sis = 0; // 0=Sin Licencia
                        lb_val_lic.Text = "Validez de la Licencia: Licencia Expirada";
                        return;
                    }

                    vg_lic_sis = 1; // 1=Con Licencia
                    lb_val_lic.Text = "Validez de la Licencia: " + fec_exp;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Menú Principal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Aplicaciones Permitidas
        private void fi_apl_per(string ide_usr)
        {
            bt_men_cmr.Visible = false;
            bt_men_res.Visible = false;
            bt_men_tes.Visible = false;
            bt_men_ctb.Visible = false;
            bt_men_inv.Visible = false;
            bt_men_ads.Visible = false;                                              

            // Obtiene las aplicaciones autorizadas al usuario
            Tabla = new DataTable();
            Tabla = o_ads008.Fe_apl_aut(ide_usr);

            // Habilita/Deshabilita las aplicaciones autorizadas
            for (int i = 0; i < Tabla.Rows.Count; i++){                
                switch (Tabla.Rows[i]["va_ide_apl"].ToString().Trim()) {
                    case "cmr200":  // Comercialización
                        bt_men_cmr.Visible = true;
                        break;
                    case "res200":  // Restaurant
                        bt_men_res.Visible = true;
                        break;
                    case "tes200":  // Tesoreria
                        bt_men_tes.Visible = true;
                        break;
                    case "ctb200":  // Contabilidad
                        bt_men_ctb.Visible = true;
                        break;
                    case "inv200":  // Inventario
                        bt_men_inv.Visible = true;
                        break;
                    case "ads200":  // Administración
                        bt_men_ads.Visible = true;
                        break;
                }
            }
        }

        // Button: Oculta/Muestra Menú Principal
        private void bt_men_pri_Click(object sender, EventArgs e)
        {
            if (pn_men_pri.Width == 200)
            {
                pn_men_pri.Width = 40;
                bt_men_pri.Location = new Point(4, 7);
                lb_ide_usr.Visible = false;
                lb_nom_usr.Visible = false;
                lb_nom_equ.Visible = false;
                lp_con_apl.Width = 45;
                pb_lic_act.Location = new Point(54, 447);
                lb_lic_act.Location = new Point(75, 447);
                lb_val_lic.Location = new Point(51, 465);
                va_tol_tip.SetToolTip(bt_men_cmr, "Comercialización");
                va_tol_tip.SetToolTip(bt_men_res, "Restaurant");
                va_tol_tip.SetToolTip(bt_men_tes, "Tesorería");
                va_tol_tip.SetToolTip(bt_men_ctb, "Contabilidad");
                va_tol_tip.SetToolTip(bt_men_inv, "Inventario");
                va_tol_tip.SetToolTip(bt_men_ads, "Administración");
            }else{
                pn_men_pri.Width = 200;
                bt_men_pri.Location = new Point(164, 7);
                lb_ide_usr.Visible = true;
                lb_nom_usr.Visible = true;
                lb_nom_equ.Visible = true;
                lp_con_apl.Width = 205;
                pb_lic_act.Location = new Point(207, 447);
                lb_lic_act.Location = new Point(228, 447);
                lb_val_lic.Location = new Point(204, 465);
                va_tol_tip.SetToolTip(bt_men_cmr, "");
                va_tol_tip.SetToolTip(bt_men_res, "");
                va_tol_tip.SetToolTip(bt_men_tes, "");
                va_tol_tip.SetToolTip(bt_men_ctb, "");
                va_tol_tip.SetToolTip(bt_men_inv, "");
                va_tol_tip.SetToolTip(bt_men_ads, "");
            }
        }

        // Button: Comercialización
        private void bt_men_cmr_MouseHover(object sender, EventArgs e)
        {
            bt_men_cmr.BackColor = Color.DodgerBlue;
        }
        private void bt_men_cmr_MouseEnter(object sender, EventArgs e)
        {
            bt_men_cmr.BackColor = Color.DodgerBlue;
        }
        private void bt_men_cmr_MouseLeave(object sender, EventArgs e)
        {
            bt_men_cmr.BackColor = Color.FromArgb(23, 43, 76);
        }
        private void bt_men_cmr_Click(object sender, EventArgs e)
        {
            try
            {
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0)
                {
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", Text, MessageBoxButtons.OK);
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(Program.gl_ide_usr) == false)
                {

                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl(3, "cmr200");
                    if (Tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("La aplicación Comercialización NO está definida", Text, MessageBoxButtons.OK);
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H")
                    {
                        MessageBox.Show("La aplicación Comercialización NO está habilitada", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_aut_usr(lb_ide_usr.Text, "ads002", "cmr200") == false)
                    {
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Comercialización.", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Crea el hilo del menu Comercializacion
                    Thread thread = new Thread(fi_run_cmr);
                    thread.SetApartmentState(ApartmentState.STA);

                    // Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 100: " + ex.Message, Text, MessageBoxButtons.OK);
            }
        }

        // Button: Restaurant
        private void bt_men_res_MouseHover(object sender, EventArgs e)
        {
            bt_men_res.BackColor = Color.DodgerBlue;
        }
        private void bt_men_res_MouseEnter(object sender, EventArgs e)
        {
            bt_men_res.BackColor = Color.DodgerBlue;
        }
        private void bt_men_res_MouseLeave(object sender, EventArgs e)
        {
            bt_men_res.BackColor = Color.FromArgb(23, 43, 76);
        }
        private void bt_men_res_Click(object sender, EventArgs e)
        {
            try
            {
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0)
                {
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", Text, MessageBoxButtons.OK);
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(Program.gl_ide_usr) == false)
                {
                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl(3, "res200");
                    if (Tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("La aplicación Restaurante (res200) NO está definida", Text, MessageBoxButtons.OK);
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H")
                    {
                        MessageBox.Show("La aplicación Restaurante (res200) NO está habilitada", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_aut_usr(lb_ide_usr.Text, "ads002", "res200") == false)
                    {
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Restaurante (res200)", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Crea el hilo del menu Restaurant
                    Thread thread = new Thread(fi_run_res);
                    thread.SetApartmentState(ApartmentState.STA);

                    // Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 101: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // Button: Tesorería
        private void bt_men_tes_MouseHover(object sender, EventArgs e)
        {
            bt_men_tes.BackColor = Color.DodgerBlue;
        }
        private void bt_men_tes_MouseEnter(object sender, EventArgs e)
        {
            bt_men_tes.BackColor = Color.DodgerBlue;
        }
        private void bt_men_tes_MouseLeave(object sender, EventArgs e)
        {
            bt_men_tes.BackColor = Color.FromArgb(23, 43, 76);
        }
        private void bt_men_tes_Click(object sender, EventArgs e)
        {
            try
            {
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0)
                {
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", Text, MessageBoxButtons.OK);
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(Program.gl_ide_usr) == false)
                {
                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl(5, "tes200");
                    if (Tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("La aplicación Tesorería (tes200) NO está definida", Text, MessageBoxButtons.OK);
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H")
                    {
                        MessageBox.Show("La aplicación Tesorería (tes200) NO está habilitada", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_aut_usr(lb_ide_usr.Text, "ads002", "tes200") == false)
                    {
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Tesorería (tes200)", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Crea el hilo del menu Tesoreria
                    Thread thread = new Thread(fi_run_tes);
                    thread.SetApartmentState(ApartmentState.STA);

                    // Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 102: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // Button: Contabilidad
        private void bt_men_ctb_MouseHover(object sender, EventArgs e)
        {
            bt_men_ctb.BackColor = Color.DodgerBlue;
        }
        private void bt_men_ctb_MouseEnter(object sender, EventArgs e)
        {
            bt_men_ctb.BackColor = Color.DodgerBlue;
        }
        private void bt_men_ctb_MouseLeave(object sender, EventArgs e)
        {
            bt_men_ctb.BackColor = Color.FromArgb(23, 43, 76);
        }
        private void bt_men_ctb_Click(object sender, EventArgs e)
        {
            try
            {
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0)
                {
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", Text, MessageBoxButtons.OK);
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(Program.gl_ide_usr) == false)
                {
                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl(4, "ctb200");
                    if (Tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("La aplicación Contabilidad (ctb200) NO está definida", Text, MessageBoxButtons.OK);
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H")
                    {
                        MessageBox.Show("La aplicación Contabilidad (ctb200) NO está habilitada", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_aut_usr(lb_ide_usr.Text, "ads002", "ctb200") == false)
                    {
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Contabilidad (ctb200)", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Crea el hilo del menu Contabilidad
                    Thread thread = new Thread(fi_run_ctb);
                    thread.SetApartmentState(ApartmentState.STA);

                    // Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 103: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // Button: Inventario
        private void bt_men_inv_MouseHover(object sender, EventArgs e)
        {
            bt_men_inv.BackColor = Color.DodgerBlue;
        }
        private void bt_men_inv_MouseEnter(object sender, EventArgs e)
        {
            bt_men_inv.BackColor = Color.DodgerBlue;
        }
        private void bt_men_inv_MouseLeave(object sender, EventArgs e)
        {
            bt_men_inv.BackColor = Color.FromArgb(23, 43, 76);
        }
        private void bt_men_inv_Click(object sender, EventArgs e)
        {
            try
            {
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0)
                {
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", Text, MessageBoxButtons.OK);
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(Program.gl_ide_usr) == false)
                {
                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl(2, "inv200");
                    if (Tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("La aplicación Inventario (inv200) NO está definida", Text, MessageBoxButtons.OK);
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H")
                    {
                        MessageBox.Show("La aplicación Inventario (inv200) NO está habilitada", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_aut_usr(lb_ide_usr.Text, "ads002", "inv200") == false)
                    {
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Inventario (inv200).", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Crea el hilo del menu Inventario
                    Thread thread = new Thread(fi_run_inv);
                    thread.SetApartmentState(ApartmentState.STA);

                    // Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 104: " + ex.Message, Text, MessageBoxButtons.OK);
            }
        }

        // Button: Administración
        private void bt_men_ads_MouseHover(object sender, EventArgs e)
        {
            bt_men_ads.BackColor = Color.DodgerBlue;
        }
        private void bt_men_ads_MouseEnter(object sender, EventArgs e)
        {
            bt_men_ads.BackColor = Color.DodgerBlue;
        }
        private void bt_men_ads_MouseLeave(object sender, EventArgs e)
        {
            bt_men_ads.BackColor = Color.FromArgb(23, 43, 76);
        }
        private void bt_men_ads_Click(object sender, EventArgs e)
        {
            try
            {
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0)
                {
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", Text, MessageBoxButtons.OK);
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(Program.gl_ide_usr) == false)
                {

                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl(1, "ads200");
                    if (Tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("La aplicación Administrador (ads200) NO está definida", Text, MessageBoxButtons.OK);
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H")
                    {
                        MessageBox.Show("La aplicación Administrador (ads200) NO está habilitada", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_aut_usr(lb_ide_usr.Text, "ads002", "ads200") == false)
                    {
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Administrador  (ads200).", Text, MessageBoxButtons.OK);
                        return;
                    }

                    // Crea el hilo del menu Administrador
                    Thread thread = new Thread(fi_run_ads);
                    thread.SetApartmentState(ApartmentState.STA);

                    // Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 105: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        // Button: Reportes
        private void bt_men_rpt_Click()
        {
            try
            {
                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(Program.gl_ide_usr) == false)
                {
                    // Crea el hilo del menu Administrador
                    Thread thread = new Thread(fi_run_rpt);
                    thread.SetApartmentState(ApartmentState.STA);

                    // Inicia el hilo
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 103: " + ex.Message, Text, MessageBoxButtons.OK);
            }
        }


        // Button: Nombre de Equipo
        private void lb_nom_equ_Click(object sender, EventArgs e)
        {
            ads000_03 frm = new ads000_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, null);
        }
        
        // PictureBox: Licencia Actual
        private void pb_lic_act_Click(object sender, EventArgs e)
        {                       
            ads000_04 frm_pin = new ads000_04();
            ads000_05 frm_lic = new ads000_05();

            // Abre la ventana que verifica el PIN para lincenciar
            if (frm_pin.ShowDialog() == DialogResult.OK){
                frm_pin.Close();

                // Abre la ventana que licencia el sistema
                if (frm_lic.ShowDialog() == DialogResult.OK){
                    fi_apl_per(lb_ide_usr.Text);
                    fi_lic_sis();
                }
            }
        }

        // Label: Licencia Actual
        private void lb_lic_act_Click(object sender, EventArgs e)
        {
            ads000_04 frm_pin = new ads000_04();
            ads000_05 frm_lic = new ads000_05();

            // Abre la ventana que verifica el PIN para lincenciar
            if (frm_pin.ShowDialog() == DialogResult.OK)
            {
                frm_pin.Close();

                // Abre la ventana que licencia el sistema
                if (frm_lic.ShowDialog() == DialogResult.OK){                                        
                    fi_apl_per(lb_ide_usr.Text);
                    fi_lic_sis();
                }
            }
        }        

        // Formulario: Cierra Formulario
        private void ads000_02_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Registra Finaliza Sesión en Bitacora de Inicio de Sesion            
            o_ads024.Fe_fin_ses(Program.gl_ide_uni);
        }        
    }
}
