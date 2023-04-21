using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /*      Opción: Elimina Registro                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 18-04-2023         */
    /**********************************************************************/
    public partial class ads016_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads016 o_ads016 = new ads016();
        ads002 o_ads002 = new ads002();
        DataTable Tabla = new DataTable();

        public ads016_06()
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
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida si ya existe ese nombre de periodo en la base de datos
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_per(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
            if (Tabla.Rows.Count == 0)
                return "El Periodo que intenta eliminar NO se encuentra registrado en la base de datos, verifique por favor";


            return "OK";
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Está seguro de eliminar la información?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Tipo de Atributo
                    o_ads016.Fe_eli_min(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
