using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads010 - Tipos de Imagen                              */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 22-09-2023         */
    /**********************************************************************/
    public partial class ads010_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        private DataTable Tabla;
        private ads010 o_ads010 = new ads010();

        public ads010_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {     
            // Desplega Información inicial            
            cb_est_ado.SelectedIndex = 0;
            rb_ord_cod.Checked = true;
            rb_ord_des.Checked = false;             
        }

        protected string Fi_val_dat()
        {
            try
            {   // Verifica si hay algún módulo registrado
                Tabla = new DataTable();
                Tabla = o_ads010.Fe_lis_tip("T");
                if (Tabla.Rows.Count == 0)
                    return "NO hay ningún Tipo de Imagen registrado en la Base de Datos";

                return "OK";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
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
            if (rb_ord_des.Checked)
                ord_dat = "D";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads010.Fe_inf_R01(est_ado, ord_dat);

            // Genera el Informe
            ads010_R01w frm = new ads010_R01w{
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
