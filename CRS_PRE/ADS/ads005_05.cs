using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads005 - Numeración                                   */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 17-04-2023         */
    /**********************************************************************/
    public partial class ads005_05 : Form
    {

        public dynamic frm_pad;
        public DataTable frm_dat;
        public int frm_tip;

        public ads005_05()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            lb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            lb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();
            tb_ges_tio.Text = frm_dat.Rows[0]["va_ges_tio"].ToString();
            tb_con_act.Text = frm_dat.Rows[0]["va_con_act"].ToString();
            tb_con_fin.Text = frm_dat.Rows[0]["va_con_fin"].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_doc.Text = string.Empty;
            lb_nom_doc.Text = string.Empty;
            tb_nro_tal.Text = string.Empty;
            lb_nom_tal.Text = string.Empty;
            tb_ges_tio.Text = string.Empty;
            tb_con_act.Text = string.Empty;
            tb_con_fin.Text = string.Empty;
            tb_fec_ini.Text = string.Empty;
            tb_fec_fin.Text = string.Empty;
            tb_con_act.Focus();
        }

        // Evento Click : Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
