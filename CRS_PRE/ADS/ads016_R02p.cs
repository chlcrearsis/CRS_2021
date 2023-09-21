using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /*      Opción: Informe R02 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 19-04-2023         */
    /**********************************************************************/
    public partial class ads016_R02p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        private DataTable Tabla;
        private ads016 o_ads016 = new ads016();

        public ads016_R02p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
                        
        }

        protected string Fi_val_dat()
        {
            try
            {
                // Valida si ya existe al menos una gestión registrada
                Tabla = new DataTable();
                Tabla = o_ads016.Fe_lis_ges();
                if (Tabla.Rows.Count == 0)
                    return "NO existe ningúna Gestión registrada en el sistema";

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
            string pri_ges = "";    // Primera Gestion
            string ult_ges = "";    // Ultima Gestion
            string ges_tio = "";    // Ultima Gestion
            string msg_val = Fi_val_dat();
            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene la primera Gestión
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_pri_ges();
            if (Tabla.Rows.Count > 0)
                pri_ges = Tabla.Rows[0]["va_ges_tio"].ToString();

            // Obtiene la última Gestión
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_ult_ges();
            if (Tabla.Rows.Count > 0)
                ult_ges = Tabla.Rows[0]["va_ges_tio"].ToString();

            if (pri_ges.CompareTo(ult_ges) == 0)
                ges_tio = pri_ges;
            else
                ges_tio = pri_ges + " - " + ult_ges;

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_inf_R02();

            // Genera el Informe
            ads016_R02w frm = new ads016_R02w{
                vp_ges_tio = ges_tio
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
