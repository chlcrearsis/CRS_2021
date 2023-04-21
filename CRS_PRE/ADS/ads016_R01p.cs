using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 18-04-2023         */
    /**********************************************************************/
    public partial class ads016_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        private DataTable Tabla;
        private ads016 o_ads016 = new ads016();

        public ads016_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            tb_ges_tio.Text = string.Empty;
            // Obtiene la ultima Gestion
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_ult_ges();
            if (Tabla.Rows.Count > 0)
                tb_ges_tio.Text = Tabla.Rows[0]["va_ges_tio"].ToString();
            // Desplega Información inicial                       
            rb_ord_per.Checked = true;
            rb_ord_nom.Checked = false;            
        }

        protected string Fi_val_dat()
        {
            try
            {
                // Valida que el campo código NO este vacio                
                if (tb_ges_tio.Text.Trim() == ""){
                    tb_ges_tio.Focus();
                    return "DEBE proporcionar la Gestión";
                }

                // Valida que la Gestion sea una Gestion valida
                int.TryParse(tb_ges_tio.Text.Trim(), out int ges_tio);
                if (ges_tio < 1900 && ges_tio > 2900){
                    tb_ges_tio.Focus();
                    return "DEBE proporcionar una Gestión Válida";
                }

                // Valida si ya existe ese nombre de periodo en la base de datos
                Tabla = new DataTable();
                Tabla = o_ads016.Fe_con_ges(int.Parse(tb_ges_tio.Text));
                if (Tabla.Rows.Count == 0)
                    return "La Gestión proporcionada NO se encuentra registrada";

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
            string ord_dat = "";
            string msg_val = Fi_val_dat();
            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }         

            // Obtiene el criterio de ordenamiento
            if (rb_ord_per.Checked)
                ord_dat = "P";
            if (rb_ord_nom.Checked)
                ord_dat = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_inf_R01(int.Parse(tb_ges_tio.Text), ord_dat);

            // Genera el Informe
            ads016_R01w frm = new ads016_R01w();
            frm.vp_ges_tio = tb_ges_tio.Text;
            frm.vp_ord_dat = ord_dat;
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
