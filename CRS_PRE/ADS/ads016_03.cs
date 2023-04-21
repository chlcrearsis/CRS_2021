using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads016 - Gestión Periodo                              */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 18-04-2023         */
    /**********************************************************************/
    public partial class ads016_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads016 o_ads016 = new ads016();
        DataTable Tabla = new DataTable();

        public ads016_03()
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
            tb_nom_per.Focus();
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

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_ges_per.Text.Trim() == "")
            {
                tb_ges_per.Focus();
                return "DEBE proporcionar el Periodo";
            }
            if (tb_ges_tio.Text.Trim() == "")
            {
                tb_ges_tio.Focus();
                return "DEBE proporcionar la Gestión";
            }
            if (tb_nom_per.Text.Trim() == "")
            {
                tb_nom_per.Focus();
                return "DEBE proporcionar el Nombre del Periodo";
            }
            if (tb_fec_ini.Text.Trim() == "  /  /")
            {
                tb_fec_ini.Focus();
                return "DEBE proporcionar la Fecha Inicial";
            }
            if (tb_fec_fin.Text.Trim() == "  /  /")
            {
                tb_fec_fin.Focus();
                return "DEBE proporcionar la Fecha Inicial";
            }

            // Valida que el Periodo sea un periodo valido            
            int.TryParse(tb_ges_per.Text.Trim(), out int ges_per);
            if (ges_per <= 0 || ges_per > 12)
            {
                return "DEBE proporcionar un Periodo Válido (1-12)";
            }

            // Valida que la Gestion sea una Gestion valida
            int.TryParse(tb_ges_tio.Text.Trim(), out int ges_tio);
            if (ges_tio < 1900 && ges_tio > 2900)
            {
                tb_ges_tio.Focus();
                return "DEBE proporcionar una Gestión Válida";
            }

            // Valida que la fecha inicial sea una fecha valida
            DateTime.TryParse(tb_fec_ini.Text, out DateTime fec_ini);
            if (fec_ini == DateTime.Parse("01/01/0001"))
            {
                tb_fec_ini.Focus();
                return "DEBE proporcionar una Fecha Inicial Válida";
            }
            // Valida que la fecha final sea una fecha valida
            DateTime.TryParse(tb_fec_fin.Text, out DateTime fec_fin);
            if (fec_fin == DateTime.Parse("01/01/0001"))
            {
                tb_fec_fin.Focus();
                return "DEBE proporcionar una Fecha Final Válida";
            }

            // Válida que la fecha inicial sea menor que la fecha final
            if (DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text))
            {
                tb_fec_fin.Focus();
                return "La Fecha Final DEBE ser MAYOR a la Fecha Inicial";
            }

            // Valida si ya existe ese nombre de periodo en la base de datos
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_nom(tb_nom_per.Text, int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text));
            if (Tabla.Rows.Count > 0)
                return "YA existe un Periodo con el mismo nombre en la misma Gestión";


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
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita Tipo de Atributo
                    o_ads016.Fe_edi_tar(int.Parse(tb_ges_tio.Text), int.Parse(tb_ges_per.Text),
                                        tb_nom_per.Text, tb_fec_ini.Text, tb_fec_fin.Text);
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

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
