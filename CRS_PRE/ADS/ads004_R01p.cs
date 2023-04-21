using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonarios                                   */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 31-03-2023         */
    /**********************************************************************/
    public partial class ads004_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads004 o_ads004 = new ads004();
        DataTable Tabla = new DataTable();

        public ads004_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información inicial
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            cb_est_ado.SelectedIndex = 0;

            // Obtiene el Tipo de Atributo Inicial
            tb_ide_mod.Text = "0";
            lb_nom_mod.Text = "...";
        }

        /// <summary>
        /// Valida los datos proporcionados en pantalla
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            try
            {
                if (lb_nom_mod.Text == "..." || lb_nom_mod.Text == "")
                    return "Debe selecciónar el ID. Módulo";

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
        void Fi_obt_mod(int ide_mod)
        {
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(ide_mod);
            if (Tabla.Rows.Count == 0){
                lb_nom_mod.Text = "...";
            }else{
                lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
        }

        /// <summary>
        /// Buscar el Módulo
        /// </summary>
        private void Fi_bus_mod()
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_mod.Text = frm.tb_ide_mod.Text;
                Fi_obt_mod(int.Parse(tb_ide_mod.Text));
            }
        }

        // Button: Buscar Módulo
        private void bt_bus_mod_Click(object sender, EventArgs e)
        {
            Fi_bus_mod();
        }

        private void tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                Fi_bus_mod();
            }
        }

        private void tb_ide_mod_Leave(object sender, EventArgs e)
        {
            // Obtiene el Tipo de Atributo Inicial           
            Fi_obt_mod(int.Parse(tb_ide_mod.Text));
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            string est_ado = "";
               int ide_mod;

            if (msg_val != "OK"){
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene parametros de pantalla
            ide_mod = int.Parse(tb_ide_mod.Text);

            // Obtiene el estado del reporte
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_inf_R01(ide_mod, est_ado);

            // Genera el Informe
            ads004_R01w frm = new ads004_R01w();
            frm.vp_est_ado = est_ado;
            frm.vp_ide_mod = ide_mod;
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
