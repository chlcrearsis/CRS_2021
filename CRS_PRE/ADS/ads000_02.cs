using System;
using System.Data;
using System.Windows.Forms;

//using System.Runtime.InteropServices;
using System.Threading;
using CRS_NEG;
using CRS_PRE.INV;
using CRS_PRE.CMR;
using CRS_PRE.ADS;

namespace CRS_PRE
{
    public partial class ads000_02 : Form
    {
        DataTable Tabla = new DataTable();
        ads002 o_ads002 = new ads002();
        ads007 o_ads007 = new ads007();
        ads013 o_ads013 = new ads013();
        ads008 o_ads008 = new ads008();
        adp002 o_adp002 = new adp002();
        ToolTip va_tol_tip = new ToolTip();
        General o_general = new General();

        string Titulo = "Menú Principal";
        int vg_lic_sis = 0; // Licencia del Sistema (0=Sin Licencia; 1=Con Licencia)

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
            if (Tabla.Rows.Count > 0){
                lb_ide_usr.Text = Tabla.Rows[0]["va_ide_usr"].ToString();
                lb_nom_usr.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
            }

            // Obtiene Datos de la Persona Usuario
            /*Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(ide_per);
            if (Tabla.Rows.Count > 0)
            {
                
            }  */          

            // Obtiene nombre de la empresa (1-4)
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 4);
            this.Text = this.Text + Tabla.Rows[0]["va_glo_car"].ToString();         

            // Despliega el nombre del Equipo
            lb_nom_equ.Text = SystemInformation.ComputerName;

            // Lee datos de la licencia del Sistema
            fi_lic_sis();

            // Despliega las aplicaciones permitidas al usuario
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
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0){
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", "Seguridad");
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false){                  
                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl("res200");
                    if (Tabla.Rows.Count == 0){
                        MessageBox.Show("La aplicación Restaurante (res200) NO está definida", "Seguridad");
                        return;
                    }                       
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H"){
                        MessageBox.Show("La aplicación Restaurante (res200) NO está habilitada", "Seguridad");
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_ads008_02(lb_ide_usr.Text, "ads002", "res200") == false){
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Restaurante (res200)", "Seguridad");
                        return;
                    }

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
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0){
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", "Seguridad");
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false){
                    
                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl("cmr200");
                    if (Tabla.Rows.Count == 0){
                        MessageBox.Show("La aplicación Comercialización NO está definida", "Seguridad");
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H"){
                        MessageBox.Show("La aplicación Comercialización NO está habilitada", "Seguridad");
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_ads008_02(lb_ide_usr.Text, "ads002", "cmr200") == false){
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Comercialización.", "Seguridad");
                        return;
                    }

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
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0){
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", "Seguridad");
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false)
                {
                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl("inv200");
                    if (Tabla.Rows.Count == 0){
                        MessageBox.Show("La aplicación Inventario NO está definida", "Seguridad");
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H"){
                        MessageBox.Show("La aplicación Inventario NO está habilitada", "Seguridad");
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_ads008_02(lb_ide_usr.Text, "ads002", "inv200") == false){
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Inventario.", "Seguridad");
                        return;
                    }

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
                // Desplega Informacion de la Licencia
                fi_lic_sis();

                // Verifica Si tiene una licencia valida activada
                if (vg_lic_sis == 0){
                    MessageBox.Show("El Sistema NO tiene un licencia válida activada, comuniquese con su proveedor", "Seguridad");
                    return;
                }

                // Verifica si el usuario tiene abiertas el maximo de ventanas permitidas
                if (fi_ven_max(o_ads007.va_ide_usr) == false){

                    // Verifica que la aplicación este registrada y habilitada 
                    Tabla = new DataTable();
                    Tabla = o_ads002.Fe_con_apl("ads200");
                    if (Tabla.Rows.Count == 0){
                        MessageBox.Show("La aplicación Administrador NO está definida", "Seguridad");
                        return;
                    }
                    if (Tabla.Rows[0]["va_est_ado"].ToString() != "H"){
                        MessageBox.Show("La aplicación Administrador NO está habilitada", "Seguridad");
                        return;
                    }

                    // Verifica que el usuario tenga los permisos sobre la aplicacion
                    if (o_ads008.Fe_ads008_02(lb_ide_usr.Text, "ads002", "ads200") == false){
                        MessageBox.Show("El Usuario NO tiene permiso sobre el Módulo de Administrador.", "Seguridad");
                        return;
                    }

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

        // Licencia y Autorizaciones del Sistema
        private void fi_lic_sis() {
            try
            {
                lb_val_lic.Text = string.Empty;
                string fec_act = o_general.Fe_fec_act().ToString();

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
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Aplicaciones Permitidas
        private void fi_apl_per(string ide_usr)
        {
            bt_men_adm.Visible = false;
            bt_men_inv.Visible = false;
            bt_men_com.Visible = false;
            bt_men_res.Visible = false;

            // Obtiene las aplicaciones autorizadas al usuario
            Tabla = new DataTable();
            Tabla = o_ads008.Fe_ads008_00(ide_usr);

            // Habilita/Deshabilita las aplicaciones autorizadas
            for (int i = 0; i < Tabla.Rows.Count; i++){
                if (Tabla.Rows[i]["va_ide_apl"].ToString().Trim() == "ads200")
                    bt_men_adm.Visible = true;
                if (Tabla.Rows[i]["va_ide_apl"].ToString().Trim() == "inv200")
                    bt_men_inv.Visible = true;
                if (Tabla.Rows[i]["va_ide_apl"].ToString().Trim() == "cmr200")
                    bt_men_com.Visible = true;
                if (Tabla.Rows[i]["va_ide_apl"].ToString().Trim() == "res200")
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
                pb_lic_act.Location = new System.Drawing.Point(54, 461);
                lb_lic_act.Location = new System.Drawing.Point(75, 463);
                lb_val_lic.Location = new System.Drawing.Point(51, 481);
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
                pb_lic_act.Location = new System.Drawing.Point(212, 461);
                lb_lic_act.Location = new System.Drawing.Point(233, 463);
                lb_val_lic.Location = new System.Drawing.Point(209, 481);
                va_tol_tip.SetToolTip(bt_men_res, "");
                va_tol_tip.SetToolTip(bt_men_com, "");
                va_tol_tip.SetToolTip(bt_men_inv, "");
                va_tol_tip.SetToolTip(bt_men_adm, "");
            }
        }

        private void lb_nom_equ_Click(object sender, EventArgs e)
        {
            ads000_03 frm = new ads000_03();
            //frm.Show();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, null);
        }

        private void ads000_02_Resize(object sender, EventArgs e)
        {
            //lb_nom_equ.Location = new System.Drawing.Point(0,  this.Size.Height - 50);
            //lb_nom_equ.ForeColor = BackColor;
        }

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
    }
}
