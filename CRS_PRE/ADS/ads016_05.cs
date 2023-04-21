using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 18-04-2023         */
    /**********************************************************************/
    public partial class ads016_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public ads016_05()
        {
            InitializeComponent();
        }
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ges_tio.Text = frm_dat.Rows[0]["va_ges_tio"].ToString();
            tb_ges_per.Text = frm_dat.Rows[0]["va_ges_per"].ToString();
            tb_nom_per.Text = frm_dat.Rows[0]["va_nom_per"].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ges_tio.Text = string.Empty;
            tb_ges_per.Text = string.Empty;
            tb_nom_per.Text = string.Empty;
            tb_fec_ini.Text = string.Empty;
            tb_fec_fin.Text = string.Empty;
            tb_nom_per.Focus();
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
