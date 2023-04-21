using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /*      Opción: Crear Siguiente Gestión                               */
    /*       Autor: JEJR - Crearsis             Fecha: 18-04-2023         */
    /**********************************************************************/
    public partial class ads016_02c : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads016 o_ads016 = new ads016();
        DataTable Tabla = new DataTable();

        public ads016_02c()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {           
            // Inicializa Campos
            Fi_lim_pia();
            // Establece el focus
            tb_nue_ges.Focus();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ult_ges.Text = string.Empty;
            tb_nue_ges.Text = string.Empty;
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan()
        {
            // Obtiene la ultima Gestion
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_ult_ges();
            if (Tabla.Rows.Count > 0)
                tb_ult_ges.Text = Tabla.Rows[0]["va_ges_tio"].ToString();

            // Inicializa la siguiente Gestion
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_nue_ges();
            if (Tabla.Rows.Count > 0)
                tb_nue_ges.Text = Tabla.Rows[0]["va_ges_tio"].ToString();
            tb_nue_ges.Focus();
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que se haya proporcionado una Gestión válida
            int.TryParse(tb_nue_ges.Text.Trim(), out int ges_tio);
            if (ges_tio == 0)
            {
                tb_nue_ges.Focus();
                return "Proporcione la Gestión";
            }
            if (ges_tio < 1900 && ges_tio > 2900)
            {
                tb_nue_ges.Focus();
                return "DEBE proporcionar una Gestión Valida";
            }
            // Valida que la Nueva Gestion sea mayor al ultima gestion
            if (int.Parse(tb_ult_ges.Text) > int.Parse(tb_nue_ges.Text))
            {
                tb_nue_ges.Focus();
                return "La Nueva Gestión DEBE ser MAYOR a la última Gestión";
            }

            // Verifica si ya existe una Gestión en el Sistema
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_lis_ges();
            if (Tabla.Rows.Count == 0)
            {
                tb_nue_ges.Focus();
                return "NO puede usar esta Opción por que NO hay gestiones creadas, DEBE usar la opción: 'Crea Gestión Inicial'";
            }

            // Verifica si la Gestión YA eta creada en el sistema
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_ges(int.Parse(tb_nue_ges.Text));
            if (Tabla.Rows.Count == 0)
            {
                tb_nue_ges.Focus();
                return "La Gestión YA se encuentra creada";
            }

            return "OK";
        }

        // Evento KeyPress: Gestión
        private void tb_nue_ges_KeyPress(object sender, KeyPressEventArgs e)
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
            msg_res = MessageBox.Show("¿Está seguro de preparar la Siguiente Gestión?", Name, MessageBoxButtons.OKCancel);
            if (msg_res == DialogResult.OK)
            {
                //Registrar usuario
                o_ads016.Fe_sig_ges(int.Parse(tb_nue_ges.Text));
                MessageBox.Show("Los datos se grabaron correctamente", Name, MessageBoxButtons.OK);
                frm_pad.Fi_bus_car();
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
