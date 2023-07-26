using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads005 - Numeración                                   */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 17-04-2023         */
    /**********************************************************************/
    public partial class ads005_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ads005 o_ads005 = new ads005();
        ads016 o_ads016 = new ads016();
        DataTable Tabla = new DataTable();

        public ads005_03()
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
            tb_ide_mod.Text = frm_dat.Rows[0]["va_ide_mod"].ToString();
            lb_nom_mod.Text = frm_dat.Rows[0]["va_nom_mod"].ToString();
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

        /// <summary>
        /// Valida los datos proporcionados en Pantalla
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            // Verificar Documento
            if (tb_ide_doc.Text.Trim().CompareTo("") == 0){
                tb_ide_doc.Focus();
                return "DEBE proporcionar el Documento";
            }

            // Valida que el Documento este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0){
                tb_ide_doc.Focus();
                return "El Documento NO se encuentra registrado";
            }            

            // Verificar el Nro. de Talonario
            if (tb_nro_tal.Text.Trim().CompareTo("") == 0){
                tb_nro_tal.Focus();
                return "DEBE proporcionar el Nro. de Talonario";
            }

            // Verifica que el Nro. de Talonario sea numerico
            if (!cl_glo_bal.IsNumeric(tb_nro_tal.Text.Trim())){
                tb_nro_tal.Focus();
                return "El Nro. de Talonario DEBE ser Numerico";
            }

            // Valida que el Nro. de Talonario este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count == 0){
                tb_nro_tal.Focus();
                return "El Talonario NO se encuentra registrado";
            }            

            // Verificar el Nro. de Talonario
            if (tb_ges_tio.Text.Trim().CompareTo("") == 0){
                tb_ges_tio.Focus();
                return "DEBE proporcionar la Gestión";
            }

            // Verifica que el Nro. de Talonario sea numerico
            if (!cl_glo_bal.IsNumeric(tb_ges_tio.Text.Trim())){
                tb_ges_tio.Focus();
                return "La Gestión DEBE ser Numerico";
            }

            // Valida que la Gestión este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_ges(int.Parse(tb_ges_tio.Text));
            if (Tabla.Rows.Count == 0){
                tb_nro_tal.Focus();
                return "La Gestión NO se encuentra registrado";
            }

            // Verificar el Nro. Actual
            if (tb_con_act.Text.Trim().CompareTo("") == 0){
                tb_con_act.Focus();
                return "DEBE proporcionar Nro. Actual";
            }

            // Verifica que el Nro. Actual sea Numerico
            if (!cl_glo_bal.IsNumeric(tb_con_act.Text.Trim())){
                tb_con_act.Focus();
                return "El Nro. Actual DEBE ser Numerico";
            }

            // Verificar el Nro. Final
            if (tb_con_fin.Text.Trim().CompareTo("") == 0){
                tb_con_fin.Focus();
                return "DEBE proporcionar Nro. Final";
            }

            // Verifica que el Nro. Final sea Numerico
            if (!cl_glo_bal.IsNumeric(tb_con_fin.Text.Trim())){
                tb_con_fin.Focus();
                return "El Nro. Final DEBE ser Numerico";
            }

            // Valida que el Nro. Actual sea menor que el nro final
            if (int.Parse(tb_con_act.Text) > int.Parse(tb_con_fin.Text))
            {
                tb_con_fin.Focus();
                return "El Nro. Final DEBE ser MAYOR al Nro. Actual";
            }

            // Valida la fecha inicial sea una fecha valida
            DateTime.TryParse(tb_fec_ini.Text, out DateTime fec_ini);
            if (!cl_glo_bal.IsDateTime(tb_fec_ini.Text.Trim())){
                tb_fec_ini.Focus();
                return "DEBE proporcionar una Fecha Inicial Válida";
            }

            // Valida la fecha Final sea una fecha valida
            if (!cl_glo_bal.IsDateTime(tb_fec_fin.Text.Trim())){                
                tb_fec_fin.Focus();
                return "DEBE proporcionar una Fecha Final Válida";
            }

            // Valida la fecha Final sea MAYOR que la fecha inicial
            if (DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text))
            {
                tb_fec_fin.Focus();
                return "La Fecha Final DEBE ser MAYOR a la Fecha I nicial";
            }

            // Verifica que la fecha inicial este dentro del rango de fechas de la gestion
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_per(int.Parse(tb_ges_tio.Text), 1);
            if (Tabla.Rows.Count > 0){
                DateTime fch_ini = DateTime.Parse(Tabla.Rows[0]["va_fec_ini"].ToString());
                DateTime ini_fch = DateTime.Parse(tb_fec_ini.Text);
                if (ini_fch < fch_ini)
                {
                    tb_fec_ini.Focus();
                    return "La Fecha Inicial NO pertenece a la Gestión";
                }
            }

            // Verifica que la fecha inicial este dentro del rango de fechas de la gestion
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_per(int.Parse(tb_ges_tio.Text), 12);
            if (Tabla.Rows.Count > 0){
                DateTime fch_fin = DateTime.Parse(Tabla.Rows[0]["va_fec_fin"].ToString());
                DateTime fin_fch = DateTime.Parse(tb_fec_fin.Text);
                if (fin_fch > fch_fin){
                    tb_fec_fin.Focus();
                    return "La Fecha Final NO pertenece a la Gestión";
                }
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_doc.Text = tb_ide_doc.Text.Replace("'", "");
            tb_nro_tal.Text = tb_nro_tal.Text.Replace("'", "");
            tb_ges_tio.Text = tb_ges_tio.Text.Replace("'", "");
            tb_con_act.Text = tb_con_act.Text.Replace("'", "");
            tb_con_fin.Text = tb_con_fin.Text.Replace("'", "");
            tb_fec_ini.Text = tb_fec_ini.Text.Replace("'", "");
            tb_fec_fin.Text = tb_fec_fin.Text.Replace("'", "");

            return "OK";
        }

        // Evento Click : Aceptar
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
                    o_ads005.Fe_edi_tar(int.Parse(tb_ges_tio.Text), tb_ide_doc.Text, int.Parse(tb_nro_tal.Text),
                                        tb_fec_ini.Text, tb_fec_fin.Text, int.Parse(tb_con_act.Text), int.Parse(tb_con_fin.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_ges_tio.Text), tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click : Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
