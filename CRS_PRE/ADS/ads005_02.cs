using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads005 - Numeración                                   */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 14-04-2023         */
    /**********************************************************************/
    public partial class ads005_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ads005 o_ads005 = new ads005();
        ads016 o_ads016 = new ads016();
        ads013 o_ads013 = new ads013();
        DataTable Tabla = new DataTable();

        public ads005_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();
            // Inicializa Campos
            lb_nom_doc.Text = "...";
            lb_nom_tal.Text = "...";
            tb_ges_tio.Text = "";
            tb_nro_tal.Text = "";
            tb_con_act.Text = "0";
            tb_con_fin.Text = "99999";
            // Obtiene la Gestión Actual
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 2);
            if (Tabla.Rows.Count > 0)
                tb_ges_tio.Text = Tabla.Rows[0]["va_glo_ent"].ToString();
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_doc.Text = string.Empty;
            lb_nom_doc.Text = "...";
            tb_nro_tal.Text = "";
            lb_nom_tal.Text = "...";
            tb_ide_mod.Text = "";
            lb_nom_mod.Text = "...";
            tb_con_act.Text = "0";
            tb_con_fin.Text = "99999";
            tb_fec_ini.Text = string.Empty;
            tb_fec_fin.Text = string.Empty;
            tb_ide_doc.Focus();
        }

        // Funcion: Buscar Documento
        private void Fi_bus_doc()
        {
            ads003_01 frm = new ads003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_doc.Text = frm.tb_ide_doc.Text;
                Fi_obt_doc();
            }
        }

        /// <summary>
        /// Obtiene datos del Documento
        /// </summary>
        private void Fi_obt_doc()
        {
            // Obtiene y desplega datos del Documento
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0){
                lb_nom_doc.Text = "...";
                tb_ide_mod.Text = "";
                lb_nom_mod.Text = "...";
            }else{
                tb_ide_doc.Text = Tabla.Rows[0]["va_ide_doc"].ToString().Trim();
                lb_nom_doc.Text = Tabla.Rows[0]["va_nom_doc"].ToString().Trim();
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString().Trim();
                lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString().Trim();
            }
        }

        // Funcion: Buscar Talonario
        private void Fi_bus_tal()
        {
            // Verificar Documento
            if (tb_ide_doc.Text.Trim().CompareTo("") == 0){
                tb_ide_doc.Focus();
                MessageBox.Show("DEBE proporcionar el Documento", Text, MessageBoxButtons.OK);
            }

            // Valida que el Documento este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (Tabla.Rows.Count == 0){
                tb_ide_doc.Focus();
                MessageBox.Show("El Documento NO se encuentra registrado", Text, MessageBoxButtons.OK);
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N"){
                tb_ide_doc.Focus();
                MessageBox.Show("El Documento se encuentra Deshabilitado", Text, MessageBoxButtons.OK);
            }

            ads004_01b frm = new ads004_01b();
            frm.vp_ide_doc = tb_ide_doc.Text.ToString();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_nro_tal.Text = frm.vp_nro_tal;
                Fi_obt_tal();
            }
        }

        /// <summary>
        /// Obtiene datos del Talonario
        /// </summary>
        private void Fi_obt_tal()
        {
            // Obtiene y desplega datos del Talonario
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_tal.Text = "...";
            }else{
                tb_nro_tal.Text = Tabla.Rows[0]["va_nro_tal"].ToString();
                lb_nom_tal.Text = Tabla.Rows[0]["va_nom_tal"].ToString();
            }
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
            if(Tabla.Rows.Count==0){
                tb_ide_doc.Focus();
                return "El Documento NO se encuentra registrado";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N"){
                tb_ide_doc.Focus();
                return "El Documento se encuentra Deshabilitado";
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
            if(Tabla.Rows.Count == 0){
                tb_nro_tal.Focus();
                return "El Talonario NO se encuentra registrado";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N"){
                tb_ide_doc.Focus();
                return "El Talonario se encuentra Deshabilitado";
            }
            
            // Verificar la Gestión sea distinto a cero
            if (tb_ges_tio.Text.Trim().CompareTo("") == 0){
                tb_ges_tio.Focus();
                return "DEBE proporcionar la Gestión";
            }

            // Verifica que la Gestión sea numerico
            if (!cl_glo_bal.IsNumeric(tb_ges_tio.Text.Trim())){
                tb_ges_tio.Focus();
                return "La Gestión DEBE ser Numerico";
            }

            // Valida que la Gestión este registrada y habilitada
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_ges(int.Parse(tb_ges_tio.Text));
            if (Tabla.Rows.Count == 0){
                tb_ges_tio.Focus();
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
            if (int.Parse(tb_con_act.Text.Trim()) > int.Parse(tb_con_fin.Text.Trim())){
                tb_con_fin.Focus();
                return "El Nro. Final DEBE ser MAYOR al Nro. Actual";
            }

            // Valida la fecha inicial sea una fecha valida           
            if (!cl_glo_bal.IsDateTime(tb_fec_ini.Text)){             
                tb_fec_ini.Focus();
                return "DEBE proporcionar una Fecha Inicial Válida";
            }

            // Valida la fecha Final sea una fecha valida
            if (!cl_glo_bal.IsDateTime(tb_fec_fin.Text)){                 
                tb_fec_fin.Focus();
                return "DEBE proporcionar una Fecha Final Válida";
            }

            // Valida la fecha Final sea MAYOR que la fecha inicial
            if (DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text)){
                tb_fec_fin.Focus();
                return "La Fecha Final DEBE ser MAYOR a la Fecha Inicial";
            }

            // Inicializa Variable
            DateTime fec_ini = DateTime.Parse(tb_fec_ini.Text);
            DateTime fec_fin = DateTime.Parse(tb_fec_fin.Text);
            DateTime fch_ini = new DateTime();
            DateTime fch_fin = new DateTime();
            
            // Obtiene el rango de fecha de la Gestion proporcionada            
            Tabla = new DataTable();
            Tabla = o_ads016.Fe_con_ges(int.Parse(tb_ges_tio.Text));
            if (Tabla.Rows.Count > 0) {
                fch_ini = DateTime.Parse(Tabla.Rows[0]["va_fec_ini"].ToString());
                fch_fin = DateTime.Parse(Tabla.Rows[Tabla.Rows.Count - 1]["va_fec_fin"].ToString());
            }

            // Verifica que la fecha inicial este dentro del rango de fechas de la gestion
            if (fec_ini < fch_ini || fec_ini > fch_fin){
                tb_fec_ini.Focus();
                return "La Fecha Inicial NO pertenece a la Gestión";
            }

            // Verifica que la fecha Final este dentro del rango de fechas de la gestion
            if (fec_fin < fch_ini || fec_fin > fch_fin){
                tb_fec_fin.Focus();
                return "La Fecha Final NO pertenece a la Gestión";
            }            

            // Verifica que la numeración NO esté registrada 
            Tabla = new DataTable();
            Tabla = o_ads005.Fe_con_nta(int.Parse(tb_ges_tio.Text), tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if (Tabla.Rows.Count > 0){
                tb_nro_tal.Focus();
                return "La Numeración para Talonario del Documento, YA se encuentra registrada";
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

        // Evento Click : Buscar Documento
        private void bt_bus_doc_Click(object sender, EventArgs e)
        {
            Fi_bus_doc();
        }

        // Evento Click : Buscar Talonario
        private void bt_bus_tal_Click(object sender, EventArgs e)
        {
            Fi_bus_tal();
        }

        // Evento Validated : ID. Documento
        private void tb_ide_doc_Validated(object sender, EventArgs e)
        {
            Fi_obt_doc();
        }

        // Evento Validated : Nro. Talonario
        private void tb_nro_tal_Validated(object sender, EventArgs e)
        {
            if (tb_nro_tal.Text.CompareTo("") != 0)
                Fi_obt_tal();
        }

        // Evento KeyDown : ID. Documento
        private void tb_ide_doc_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_bus_doc();
            }
        }

        // Evento KeyDown : Nro. Talonario
        private void tb_nro_tal_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_bus_tal();
            }
        }

        // Evento KeyPress : Nro. Talonario
        private void tb_nro_tal_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : Gestión
        private void tb_ges_tio_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : Nro. Inicial
        private void tb_con_act_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress : Nro. Final
        private void tb_con_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Click : Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msg_res;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK"){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    // Registrar 
                    o_ads005.Fe_nue_reg(int.Parse(tb_ges_tio.Text), tb_ide_doc.Text.Trim(), int.Parse(tb_nro_tal.Text),
                                            tb_fec_ini.Text.Trim(), tb_fec_fin.Text.Trim(), int.Parse(tb_con_act.Text), 
                                        int.Parse(tb_con_fin.Text));
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    Fi_lim_pia();
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
