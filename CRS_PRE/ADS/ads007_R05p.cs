using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Informe R05 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 14-09-2023         */
    /**********************************************************************/
    public partial class ads007_R05p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancia
        private DataTable Tabla;
        private ads001 o_ads001 = new ads001();
        private ads007 o_ads007 = new ads007();

        public ads007_R05p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información Usuario Inicial y Final         
            tb_usr_ini.Text = "";
            lb_nus_ini.Text = "...";
            tb_usr_fin.Text = "";            
            lb_nus_fin.Text = "...";
            tb_mod_ini.Text = "0";
            lb_nmo_ini.Text = "...";
            tb_mod_fin.Text = "999";
            lb_nmo_fin.Text = "...";

            // Desplega Información Usuario Inicial y Final         
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_lis_usr("H");
            if (Tabla.Rows.Count > 0){
                tb_usr_ini.Text = Tabla.Rows[0]["va_ide_usr"].ToString();
                lb_nus_ini.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
                tb_usr_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_usr"].ToString();
                lb_nus_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_usr"].ToString();
            }

            // Desplega Información Módulo Inicial y Final         
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_lis_mod("H");
            if (Tabla.Rows.Count > 0){
                tb_mod_ini.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
                lb_nmo_ini.Text = Tabla.Rows[0]["va_abr_mod"].ToString() + " - " + 
                                  Tabla.Rows[0]["va_nom_mod"].ToString();
                tb_mod_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_mod"].ToString();
                lb_nmo_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_abr_mod"].ToString() + " - " +
                                  Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_mod"].ToString();
            }
        }

        // Valida los datos de pantalla
        protected string Fi_val_dat()
        {
            try
            {
                // Valida que el Usuario Inicial no esten vacio
                if (tb_usr_ini.Text.Trim().CompareTo("") == 0){
                    return "DEBE proporcionar el Usuario Inicial";
                }

                // Valida que el Usuario Inicial no esten vacio
                if (tb_usr_fin.Text.Trim().CompareTo("") == 0){
                    return "DEBE proporcionar el Usuario Final";
                }

                // Verifica si existe el Usuario Inicial
                Tabla = new DataTable();
                Tabla = o_ads007.Fe_con_ide(tb_usr_ini.Text.Trim());
                if (Tabla.Rows.Count == 0){
                    return "El Usuario Inicial NO esta registrado en el sistema";
                }

                // Verifica si existe el Usuario Final
                Tabla = new DataTable();
                Tabla = o_ads007.Fe_con_ide(tb_usr_fin.Text.Trim());
                if (Tabla.Rows.Count == 0){
                    return "El Usuario Final NO esta registrado en el sistema";
                }

                // Valida que el Módulo no esten vacio
                if (tb_mod_ini.Text.Trim().CompareTo("") == 0){
                    tb_mod_ini.Focus();
                    return "DEBE proporcionar el Módulo Inicial";
                }
                if (tb_mod_fin.Text.Trim().CompareTo("") == 0){
                    tb_mod_fin.Focus();
                    return "DEBE proporcionar el Módulo Final";
                }

                // Valida que el Módulo sea numerico
                if (!cl_glo_bal.IsNumeric(tb_mod_ini.Text.Trim())){
                    tb_mod_ini.Focus();
                    return "El campo Módulo Inicial DEBE ser numérico";
                }
                if (!cl_glo_bal.IsNumeric(tb_mod_fin.Text.Trim())){
                    tb_mod_fin.Focus();
                    return "El campo Módulo Final DEBE ser numérico";
                }

                // Valida que el Módulo inicial sea menor que el final
                if (int.Parse(tb_mod_fin.Text.Trim()) < int.Parse(tb_mod_ini.Text.Trim())){
                    tb_mod_ini.Focus();
                    return "El Módulo Final DEBE menor que el Módulo Inicial";
                }

                // Verifica si existe el Módulo Inicial
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(int.Parse(tb_mod_ini.Text.Trim()));
                if (Tabla.Rows.Count == 0){
                    tb_mod_ini.Focus();
                    return "El Módulo Inicial NO esta registrado en el sistema";
                }

                // Verifica si existe el Módulo Final
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(int.Parse(tb_mod_fin.Text.Trim()));
                if (Tabla.Rows.Count == 0){
                    tb_mod_fin.Focus();
                    return "El Módulo Final NO esta registrado en el sistema";
                }

                return "OK";
            }
            catch (Exception)
            {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }
        }

        /// <summary>
        /// Obtiene el nombre del Usuario
        /// </summary>
        void Fi_obt_usr(int ini_fin, string ide_usr)
        {
            // Obtiene y Desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(ide_usr);
            if (Tabla.Rows.Count == 0){
                if (ini_fin == 1)
                    lb_nus_ini.Text = "...";
                else
                    lb_nus_fin.Text = "...";
            }else{
                if (ini_fin == 1)
                    lb_nus_ini.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
                else
                    lb_nus_fin.Text = Tabla.Rows[0]["va_nom_usr"].ToString();
            }
        }

        /// <summary>
        /// Obtiene el nombre del Módulo
        /// </summary>
        void Fi_obt_mod(int ini_fin, int ide_mod)
        {
            // Obtiene y Desplega datos del Módulo
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(ide_mod);
            if (Tabla.Rows.Count == 0){
                if (ini_fin == 1)
                    lb_nmo_ini.Text = "...";
                else
                    lb_nmo_fin.Text = "...";
            }else{
                if (ini_fin == 1)
                    lb_nmo_ini.Text = Tabla.Rows[0]["va_abr_mod"].ToString() + " - " +
                                      Tabla.Rows[0]["va_nom_mod"].ToString();
                else
                    lb_nmo_fin.Text = Tabla.Rows[0]["va_abr_mod"].ToString() + " - " +
                                      Tabla.Rows[0]["va_nom_mod"].ToString();
            }
        }

        /// <summary>
        /// Función: Abre Formulario para Buscar el Usuario
        /// </summary>
        /// <param name="ini_fin">1=Usuario Inicial; 2=Usuario Final</param>
        private void Fi_bus_usr(int ini_fin)
        {
            ads007_01b frm = new ads007_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                if (ini_fin == 1){
                    tb_usr_ini.Text = frm.tb_ide_usr.Text;
                    Fi_obt_usr(1, tb_usr_ini.Text.Trim());
                }else{
                    tb_usr_fin.Text = frm.tb_ide_usr.Text;
                    Fi_obt_usr(2, tb_usr_fin.Text.Trim());
                }
            }
        }

        /// <summary>
        /// Función: Abre Formulario para Buscar el Módulo
        /// </summary>
        /// <param name="ini_fin">1=Módulo Inicial; 2=Módulo Final</param>
        private void Fi_bus_mod(int ini_fin)
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                if (ini_fin == 1){
                    tb_mod_ini.Text = frm.tb_ide_mod.Text;
                    Fi_obt_mod(1, int.Parse(tb_mod_ini.Text));
                }else{
                    tb_mod_fin.Text = frm.tb_ide_mod.Text;
                    Fi_obt_mod(2, int.Parse(tb_mod_fin.Text));
                }
            }
        }

        // Evento KeyPress : Módulo Inicial
        private void tb_mod_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : Módulo Inicial
        private void tb_mod_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown: Usuario Inicial
        private void tb_usr_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                // Abre la ventana Busca Módulo
                Fi_bus_usr(1);
            }
        }

        // Evento KeyDown: Usuario Final
        private void tb_usr_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                // Abre la ventana Busca Módulo
                Fi_bus_usr(2);
            }
        }

        // Evento KeyDown: Módulo Inicial
        private void tb_mod_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Módulo
                Fi_bus_mod(1);
            }
        }

        // Evento KeyDown: Módulo Final
        private void tb_mod_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Módulo
                Fi_bus_mod(2);
            }
        }

        // Evento Leave: Usuario Inicial
        private void tb_usr_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene el Usuario Inicial
            if (tb_usr_ini.Text.Trim().CompareTo("") != 0)
                Fi_obt_usr(1, tb_usr_ini.Text.Trim());
        }

        // Evento Leave: Usuario Final
        private void tb_usr_fin_Leave(object sender, EventArgs e)
        {
            // Obtiene el Usuario Inicial
            if (tb_usr_ini.Text.Trim().CompareTo("") != 0)
                Fi_obt_usr(2, tb_usr_ini.Text.Trim());
        }

        // Evento Leave: Módulo Inicial
        private void tb_mod_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene el Módulo Inicial
            if (tb_mod_ini.Text.Trim().CompareTo("") != 0)
                Fi_obt_mod(1, int.Parse(tb_mod_ini.Text));
        }

        // Evento Leave: Módulo Final
        private void tb_mod_fin_Leave(object sender, EventArgs e)
        {
            // Obtiene el Módulo Final
            if (tb_mod_fin.Text.Trim().CompareTo("") != 0)
                Fi_obt_mod(2, int.Parse(tb_mod_fin.Text));
        }

        // Evento Click: Button Usuario Inicial
        private void bt_usr_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_usr(1);
        }

        // Evento Click: Button Usuario Final
        private void bt_usr_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_usr(2);
        }

        // Evento Click: Button Módulo Inicial
        private void bt_mod_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_mod(1);
        }

        // Evento Click: Button Módulo Final
        private void bt_mod_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_mod(2);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos            
            string msg_val = Fi_val_dat();

            if (msg_val != "OK"){
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            
            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_inf_R05(tb_usr_ini.Text.Trim(), tb_usr_fin.Text.Trim(), int.Parse(tb_mod_ini.Text), int.Parse(tb_mod_fin.Text));

            // Genera el Informe
            ads007_R05w frm = new ads007_R05w{
                vp_usr_ini = tb_usr_ini.Text.Trim(),
                vp_nus_ini = lb_nus_ini.Text.Trim(),
                vp_usr_fin = tb_usr_fin.Text.Trim(),
                vp_nus_fin = lb_nus_fin.Text.Trim(),
                vp_mod_ini = tb_mod_ini.Text.Trim(),
                vp_nmo_ini = lb_nmo_ini.Text.Trim(),
                vp_mod_fin = tb_mod_fin.Text.Trim(),
                vp_nmo_fin = lb_nmo_fin.Text.Trim()
            };
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }        
    }
}
