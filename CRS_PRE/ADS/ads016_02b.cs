using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /*      Opción: Crear Primera Gestión                                 */
    /*       Autor: JEJR - Crearsis             Fecha: 18-04-2023         */
    /**********************************************************************/
    public partial class ads016_02b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads016 o_ads016 = new ads016();
        DataTable Tabla = new DataTable();

        public ads016_02b()
        {
            InitializeComponent();
        }       

        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los campos
            Fi_lim_pia();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ges_tio.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            cb_ges_per.SelectedIndex = 0;
            tb_ges_tio.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que se haya proporcionado una Gestión válida
            int.TryParse(tb_ges_tio.Text.Trim(), out int ges_tio);
            if (ges_tio == 0){
                tb_ges_tio.Focus();
                return "Proporcione la Gestión";
            }
            if (ges_tio < 1900 && ges_tio > 2900)
            {
                tb_ges_tio.Focus();
                return "DEBE proporcionar una Gestión Valida";
            }

            // Verifica si ya existe una Gestión en el Sistema
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_lis_ges();
            if(Tabla.Rows.Count > 0){
                tb_ges_tio.Focus();
                return "NO puede usar esta Opción por que ya hay gestiones creadas, DEBE usar la opción: 'Prepara Siguiente Gestion'";
            }

            return "OK";
        }

        // Evento KeyPress: Gestión
        private void tb_ges_tio_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            // funcion para validar datos
            string msg_val = Fi_val_dat();
            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de Crear la Gestión?", "Nueva Gestión", MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                // Registra
                o_ads016.Fe_nue_ges(int.Parse(tb_ges_tio.Text), cb_ges_per.SelectedIndex + 1);
                MessageBox.Show("Los datos se grabaron correctamente", "Nueva Gestión", MessageBoxButtons.OK);
                frm_pad.fi_bus_car(0);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
