using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Informe R02 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 09-08-2023         */
    /**********************************************************************/
    public partial class ads007_R02p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        private DataTable Tabla;
        private ads006 o_ads006 = new ads006();
        private ads007 o_ads007 = new ads007();


        public ads007_R02p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información inicial            
            cb_est_ado.SelectedIndex = 0;
            rb_ord_cod.Checked = true;
            rb_ord_nom.Checked = false;
        }

        // Valida los datos de pantalla
        protected string Fi_val_dat()
        {
            try
            {
                // Valida que el Tipo de Usuario no esten vacio
                if (tb_tus_ini.Text.Trim().CompareTo("") == 0){
                    tb_tus_ini.Focus();
                    return "DEBE proporcionar el Tipo de Usuario Inicial";
                }
                if (tb_tus_fin.Text.Trim().CompareTo("") == 0){
                    tb_tus_fin.Focus();
                    return "DEBE proporcionar el Tipo de Usuario Final";
                }

                // Valida que el Tipo de Usuario sea numerico
                if (!cl_glo_bal.IsNumeric(tb_tus_ini.Text.Trim())){
                    tb_tus_ini.Focus();
                    return "El campo Tipo de Usuario Inicial DEBE ser numérico";
                }
                if (!cl_glo_bal.IsNumeric(tb_tus_fin.Text.Trim())){
                    tb_tus_fin.Focus();
                    return "El campo Tipo de Usuario Final DEBE ser numérico";
                }

                // Valida que el Tipo de Usuario inicial sea menor que el final
                if (int.Parse(tb_tus_fin.Text.Trim()) < int.Parse(tb_tus_ini.Text.Trim())){
                    tb_tus_ini.Focus();
                    return "El Tipo de Usuario Final DEBE menor que el Tipo de Usuario Inicial";
                }

                // Verifica si existe el tipo de Usuario Inicial
                Tabla = new DataTable();
                Tabla = o_ads006.Fe_con_tus(int.Parse(tb_tus_ini.Text.Trim()));
                if (Tabla.Rows.Count == 0){
                    tb_tus_ini.Focus();
                    return "El Tipo de Usuario Inicial NO esta registrado en el sistema";
                }

                // Verifica si existe el tipo de Usuario Final
                Tabla = new DataTable();
                Tabla = o_ads006.Fe_con_tus(int.Parse(tb_tus_fin.Text.Trim()));
                if (Tabla.Rows.Count == 0){
                    tb_tus_fin.Focus();
                    return "El Tipo de Usuario Final NO esta registrado en el sistema";
                }

                return "OK";
            }
            catch (Exception)
            {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }
        }

        /// <summary>
        /// Obtiene el nombre del Tipo de Usuario
        /// </summary>
        void Fi_obt_tus(int ini_fin, int ide_tus)
        {
            // Obtiene y Desplega datos del Tipo de Usuario
            Tabla = new DataTable();
            Tabla = o_ads006.Fe_con_tus(ide_tus);
            if (Tabla.Rows.Count == 0)
            {
                if (ini_fin == 1)
                    lb_ntu_ini.Text = "...";
                else
                    lb_ntu_fin.Text = "...";
            }
            else
            {
                if (ini_fin == 1)
                    lb_ntu_ini.Text = Tabla.Rows[0]["va_nom_tus"].ToString();
                else
                    lb_ntu_fin.Text = Tabla.Rows[0]["va_nom_tus"].ToString();
            }
        }

        /// <summary>
        /// Función: Abre Formulario para Buscar el Tipo de Usuario
        /// </summary>
        /// <param name="ini_fin">1=Tipo de Usuario Inicial; 2=Tipo de Usuario Final</param>
        private void Fi_bus_tus(int ini_fin)
        {
            ads006_01 frm = new ads006_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                if (ini_fin == 1)
                {
                    tb_tus_ini.Text = frm.tb_ide_tus.Text;
                    Fi_obt_tus(1, int.Parse(tb_tus_ini.Text));
                }
                else
                {
                    tb_tus_fin.Text = frm.tb_ide_tus.Text;
                    Fi_obt_tus(2, int.Parse(tb_tus_fin.Text));
                }
            }
        }

        // Evento KeyPress : Tipo de Usuario Inicial
        private void tb_tus_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : Tipo de Usuario Inicial
        private void tb_tus_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown: Tipo de Usuario Inicial
        private void tb_tus_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Tipo de Usuario
                Fi_bus_tus(1);
            }
        }

        // Evento KeyDown: Tipo de Usuario Final
        private void tb_tus_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Tipo de Usuario
                Fi_bus_tus(2);
            }
        }

        // Evento Leave: Tipo de Usuario Inicial
        private void tb_tus_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene el Tipo de Usuario Inicial
            if (tb_tus_ini.Text.Trim().CompareTo("") != 0)
                Fi_obt_tus(1, int.Parse(tb_tus_ini.Text));
        }

        // Evento Leave: Tipo de Usuario Final
        private void tb_tus_fin_Leave(object sender, EventArgs e)
        {
            // Obtiene el Tipo de Usuario Inicial           
            if (tb_tus_fin.Text.Trim().CompareTo("") != 0)
                Fi_obt_tus(2, int.Parse(tb_tus_fin.Text));
        }

        // Evento Click: Button Tipo de Usuario Inicial
        private void bt_tus_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_tus(1);
        }

        // Evento Click: Button Tipo de Usuario Final
        private void bt_tus_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_tus(2);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string est_ado = "";
            string ord_dat = "";
            string msg_val = Fi_val_dat();

            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene el estado del reporte
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            // Obtiene el criterio de ordenamiento
            if (rb_ord_cod.Checked)
                ord_dat = "C";
            if (rb_ord_nom.Checked)
                ord_dat = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_inf_R01(est_ado, ord_dat);

            // Genera el Informe
            ads007_R02w frm = new ads007_R02w{
                vp_tus_ini = tb_tus_ini.Text.Trim(),
                vp_tus_fin = tb_tus_fin.Text.Trim(),
                vp_est_ado = est_ado,
                vp_ord_dat = ord_dat
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
