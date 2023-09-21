using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Informe R03 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 07-09-2023         */
    /**********************************************************************/
    public partial class ads007_R03p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancia
        private DataTable Tabla;
        private ads001 o_ads001 = new ads001();
        private ads007 o_ads007 = new ads007();


        public ads007_R03p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información Usuario Inicial y Final         
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString().Trim();
            lb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString().Trim();
            tb_mod_ini.Text = "0";
            lb_nmo_ini.Text = "...";
            tb_mod_fin.Text = "999";
            lb_nmo_fin.Text = "...";

            // Desplega Información Módulo Inicial y Final         
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_lis_mod("H");
            if (Tabla.Rows.Count > 0){
                tb_mod_ini.Text = Tabla.Rows[0]["va_ide_mod"].ToString();
                lb_nmo_ini.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                tb_mod_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_mod"].ToString();
                lb_nmo_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_mod"].ToString();
            }
        }

        // Valida los datos de pantalla
        protected string Fi_val_dat()
        {
            try
            {
                // Valida que el Tipo de Usuario no esten vacio
                if (tb_ide_usr.Text.Trim().CompareTo("") == 0){
                    return "DEBE proporcionar el Usuario";
                }                

                // Verifica si existe el Usuario
                Tabla = new DataTable();
                Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
                if (Tabla.Rows.Count == 0){
                    return "El Usuario NO esta registrado en el sistema";
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
                    lb_nmo_ini.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                else
                    lb_nmo_fin.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
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
            Tabla = o_ads007.Fe_inf_R03(tb_ide_usr.Text.Trim(), int.Parse(tb_mod_ini.Text), int.Parse(tb_mod_fin.Text));

            // Genera el Informe
            ads007_R03w frm = new ads007_R03w{
                vp_ide_usr = tb_ide_usr.Text.Trim(),
                vp_mod_ini = tb_mod_ini.Text.Trim(),
                vp_mod_fin = tb_mod_fin.Text.Trim()
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
