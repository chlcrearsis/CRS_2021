using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonario                                    */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 31-08-2022         */
    /**********************************************************************/
    public partial class ads004_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        public ads004_05()
        {
            InitializeComponent();
        }


        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();
            tb_for_mat.Text = frm_dat.Rows[0]["va_for_mat"].ToString();
            tb_nro_cop.Text = frm_dat.Rows[0]["va_nro_cop"].ToString();
            tb_nro_aut.Text = frm_dat.Rows[0]["va_nro_aut"].ToString();
            tb_fir_ma1.Text = frm_dat.Rows[0]["va_fir_ma1"].ToString();
            tb_fir_ma2.Text = frm_dat.Rows[0]["va_fir_ma2"].ToString();
            tb_fir_ma3.Text = frm_dat.Rows[0]["va_fir_ma3"].ToString();
            tb_fir_ma4.Text = frm_dat.Rows[0]["va_fir_ma4"].ToString();
            switch (frm_dat.Rows[0]["va_tip_tal"].ToString()){
                case "0": tb_tip_tal.Text = "Manual"; break;
                case "1": tb_tip_tal.Text = "Automático"; break;
            }
            switch (frm_dat.Rows[0]["va_for_log"].ToString()){
                case "0": tb_for_log.Text = "Razon social de la empresa"; break;
                case "1": tb_for_log.Text = "Logo 1"; break;
                case "2": tb_for_log.Text = "Logo 2"; break;
                case "3": tb_for_log.Text = "Logo 3"; break;
            }
            switch (frm_dat.Rows[0]["va_est_ado"].ToString()){
                case "H": tb_est_ado.Text = "Habilitado"; break;
                case "N": tb_est_ado.Text = "Deshabilitado"; break;
            }
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_doc.Text = string.Empty;
            tb_nom_doc.Text = string.Empty;
            tb_nro_tal.Text = string.Empty;
            tb_nom_tal.Text = string.Empty;
            tb_for_mat.Text = string.Empty;
            tb_nro_cop.Text = string.Empty;
            tb_nro_aut.Text = string.Empty;
            tb_fir_ma1.Text = string.Empty;
            tb_fir_ma2.Text = string.Empty;
            tb_fir_ma3.Text = string.Empty;
            tb_fir_ma4.Text = string.Empty;
            tb_tip_tal.Text = string.Empty;
            tb_for_log.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

    }
}
