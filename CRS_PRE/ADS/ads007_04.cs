using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Habilita/Deshabilita Registro                         */
    /*       Autor: JEJR - Crearsis             Fecha: 29-07-2023         */
    /**********************************************************************/
    public partial class ads007_04 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads007 o_ads007 = new ads007();
        adp002 o_adp002 = new adp002();

        DataTable Tabla = new DataTable();

        public ads007_04()
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

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el ID. Usuario NO este vacio
            if (tb_ide_usr.Text.Trim() == "")
                return "DEBE proporcionar el ID. Usuario";                                    

            /* Verifica que exista el usuario en el sistema */
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim());
            if (Tabla.Rows.Count == 0) {
                return "El Usuario NO se encuentra registrado";
            }

            return "OK";
        }       

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                if (tb_est_ado.Text == "Habilitado")
                    msg_res = MessageBox.Show("Está seguro de Deshabilitar el Usuario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                else
                    msg_res = MessageBox.Show("Está seguro de Habilitar el Usuario?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg_res == DialogResult.OK){
                    // Habilita/Deshabilita el registro
                    if (tb_est_ado.Text == "Habilitado")
                        o_ads007.Fe_hab_des(tb_ide_usr.Text.Trim(), "N");
                    else
                        o_ads007.Fe_hab_des(tb_ide_usr.Text.Trim(), "H");
                    // Actualiza el Formulario Principal
                    frm_pad.Fe_act_frm(tb_ide_usr.Text.Trim());
                    // Despliega Mensaje
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cierra Formulario
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
