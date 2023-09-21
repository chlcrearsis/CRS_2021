using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Consulta Registro                                     */
    /*       Autor: JEJR - Crearsis             Fecha: 31-07-2023         */
    /**********************************************************************/
    public partial class ads007_05 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp002 o_adp002 = new adp002();
        DataTable Tabla = new DataTable();
      
        public ads007_05()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Informacion del Usuario
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            tb_nom_tus.Text = frm_dat.Rows[0]["va_nom_tus"].ToString();
            tb_nom_usr.Text = frm_dat.Rows[0]["va_nom_usr"].ToString();
            tb_tel_usr.Text = frm_dat.Rows[0]["va_tel_usr"].ToString();
            tb_car_usr.Text = frm_dat.Rows[0]["va_car_usr"].ToString();
            tb_ema_usr.Text = frm_dat.Rows[0]["va_ema_usr"].ToString();
            tb_dir_tra.Text = frm_dat.Rows[0]["va_dir_tra"].ToString();
            tb_ven_max.Text = frm_dat.Rows[0]["va_ven_max"].ToString();
            tb_ide_per.Text = frm_dat.Rows[0]["va_ide_per"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            // Obtiene Persona
            Fi_obt_per();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_usr.Text = string.Empty;
            tb_nom_tus.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
            tb_nom_usr.Text = string.Empty;
            tb_tel_usr.Text = string.Empty;
            tb_car_usr.Text = string.Empty;
            tb_ema_usr.Text = string.Empty;
            tb_dir_tra.Text = string.Empty;
            tb_ven_max.Text = string.Empty;
            tb_ide_per.Text = string.Empty;
            tb_nom_usr.Focus();
        }

        /// <summary>
        /// Función: Obtiene Datos de la Persona
        /// </summary>
        private void Fi_obt_per()
        {
            /* Obtiene datos de la persona */
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_ide_per.Text.Trim()));
            if (Tabla.Rows.Count == 0){
                lb_raz_soc.Text = "...";
            }else{
                lb_raz_soc.Text = Tabla.Rows[0]["va_raz_soc"].ToString();
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
