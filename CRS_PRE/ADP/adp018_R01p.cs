using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp018 - Grupo Empresarial                            */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 30-08-2021         */
    /**********************************************************************/
    public partial class adp018_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        private DataTable Tabla;
        private adp018 o_adp018 = new adp018();

        public adp018_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            cb_ban_fac.DataSource = null;
            // Crea la Tabla Dinamica
            Tabla = new DataTable();
            Tabla.Columns.Add("va_ide_ban");
            Tabla.Columns.Add("va_nom_ban");
            // Adiciona los Items
            Tabla.Rows.Add("0", "Registro Cliente");
            Tabla.Rows.Add("1", "Grupo Empresarial");
            Tabla.Rows.Add("2", "Todos");
            // Carga los Item
            cb_ban_fac.DataSource = Tabla;
            cb_ban_fac.DisplayMember = "va_nom_ban";
            cb_ban_fac.ValueMember = "va_ide_ban";

            // Desplega Información inicial
            cb_ban_fac.SelectedValue = 2;
            cb_est_ado.SelectedIndex = 0;
            rb_ord_tip.Checked = true;
            rb_ord_des.Checked = false;            
        }

        protected string Fi_val_dat()
        {
            try
            {                
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
            string ban_fac = "";
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

            // Obtiene la bandera facturacion
            if (cb_ban_fac.SelectedIndex == 0)
                ban_fac = "Registro Cliente";
            if (cb_ban_fac.SelectedIndex == 1)
                ban_fac = "Grupo Empresarial";
            if (cb_ban_fac.SelectedIndex == 2)
                ban_fac = "Todos";

            // Obtiene el criterio de ordenamiento
            if (rb_ord_tip.Checked)
                ord_dat = "T";
            if (rb_ord_des.Checked)
                ord_dat = "D";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_adp018.Fe_inf_R01(est_ado, ord_dat, cb_ban_fac.SelectedIndex);

            // Genera el Informe
            adp018_R01w frm = new adp018_R01w{
                vp_est_ado = est_ado,
                vp_ban_fac = ban_fac
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
