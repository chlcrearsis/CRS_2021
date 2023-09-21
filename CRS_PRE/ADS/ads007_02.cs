using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Crear Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 28-07-2023         */
    /**********************************************************************/
    public partial class ads007_02 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads007 o_ads007 = new ads007();
        adp002 o_adp002 = new adp002();
        ads006 o_ads006 = new ads006();
        DataTable Tabla = new DataTable();

        public ads007_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Inicializa Campos
            tb_dir_tra.Text = "C:/Temp";
            tb_ven_max.Text = "999";

            // Adiciona a la lista usuario (Nuevo)
            cb_ini_ses.Items.Clear();
            cb_ini_ses.Items.Add("(Nuevo)");

            // Carga los Inicio de Sesion de SQL-Server
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_usr_sql();
            if (Tabla.Rows.Count > 0){                
                for (int i = 0; i < Tabla.Rows.Count; i++){
                    cb_ini_ses.Items.Add(Tabla.Rows[i]["va_ide_usr"].ToString());
                }
            }
            cb_ini_ses.SelectedIndex = 0;

            // Carga los Tipos de Usuario a la lista
            cb_tip_usr.Items.Clear();
            cb_tip_usr.DataSource = o_ads006.Fe_lis_tus("H");
            cb_tip_usr.ValueMember = "va_ide_tus";
            cb_tip_usr.DisplayMember = "va_nom_tus";
            cb_tip_usr.SelectedIndex = 0;
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_ide_usr.Text = string.Empty;
            tb_nom_usr.Text = string.Empty;
            tb_tel_usr.Text = string.Empty;
            tb_car_usr.Text = string.Empty;
            tb_ema_usr.Text = string.Empty;
            tb_ide_per.Text = "0";
            lb_raz_soc.Text = "...";
            tb_ide_usr.Focus();
        }

        // Función: Buscar Persona
        private void Fi_bus_per()
        {
            adp002_01 frm = new adp002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_per.Text = frm.tb_cod_per.Text;
                Fi_obt_per();
            }
        }

        // Función: Obtener Datos de la Persona
        private void Fi_obt_per()
        {
            // Valida que el Código de Persona sea válido
            if (tb_ide_per.Text.CompareTo("") == 0 &&
                tb_ide_per.Text.CompareTo("0") == 0){
                tb_ide_per.Focus();
                MessageBox.Show("DEBE proporcionar un codigo de persona valido", "Error", MessageBoxButtons.OK);
            }

            // Válida que el Código de Persona sea numerico
            if (!cl_glo_bal.IsNumeric(tb_ide_per.Text)){
                tb_ide_per.Focus();
                MessageBox.Show("El código del Cliente DEBE ser numérico", "Error", MessageBoxButtons.OK);
            }

            // Obtiene los datos del cliente
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_ide_per.Text));
            if (Tabla.Rows.Count == 0)
            {
                tb_ide_per.Focus();
                lb_raz_soc.Text = "...";
                MessageBox.Show("NO existe ningúna Persona con ese código", "Error", MessageBoxButtons.OK);
            }else {
                // Despliega los datos de la persona
                tb_ide_per.Text = Tabla.Rows[0]["va_cod_per"].ToString();
                lb_raz_soc.Text = Tabla.Rows[0]["va_raz_soc"].ToString();
            }            
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el ID. Usuario NO este vacio
            if (tb_ide_usr.Text.Trim() == ""){
                tb_ide_usr.Focus();
                return "DEBE proporcionar el ID. Usuario";
            }

            // Valida que el ID. Usuario tenga MAYOR a 4 digitos
            if (tb_ide_usr.Text.Trim().Length < 4){
                tb_ide_usr.Focus();
                return "El ID. Usuario DEBE contener al menos 4 caracteres como mínimo";
            }

            // Valida que el Nombre Usuario NO este vacio
            if (tb_nom_usr.Text.Trim() == ""){
                tb_nom_usr.Focus();
                return "DEBE proporcionar el nombre del Usuario";
            }

            // Valida que el Cargo del Usuario NO este vacio
            if (tb_car_usr.Text.Trim() == ""){
                tb_car_usr.Focus();
                return "DEBE proporcionar el cargo del Usuario";
            }

            // Verifica que el maximo de ventas abierta sea Numerico
            if (!cl_glo_bal.IsNumeric(tb_ven_max.Text.Trim())){
                tb_ven_max.Focus();
                return "El Campo de Máximo de Ventas abiertas DEBE ser numerico";
            }

            // Valida que el máximo de ventanas abiertas sea mayor a 1
            if (int.Parse(tb_ven_max.Text.Trim()) == 0){
                tb_ven_max.Focus();
                return "Las Ventanas máximas abiertas DEBE ser MAYOR a 1";
            }

            // Verifica si el Usuario YA está creado en el Sistema
            Tabla = new DataTable();
            Tabla = o_ads007.Fe_con_ide(tb_ide_usr.Text.Trim(), "T");
            if (Tabla.Rows.Count > 0){
                tb_ide_usr.Focus();
                return "El Usuario que desea crear YA se encuentra registrado";
            }

            // Verifica si la persona se encuentra creada
            if (tb_ide_per.Text.CompareTo("0") != 0) {
                Tabla = new DataTable();
                Tabla = o_adp002.Fe_con_per(int.Parse(tb_ide_per.Text.Trim()));
                if (Tabla.Rows.Count == 0){
                    tb_ide_per.Focus();
                    return "La Persona que desea asociar al Usuario NO se encuentra registrado";
                }
            }

            // Quita caracteres especiales de SQL-Trans
            tb_ide_usr.Text = tb_ide_usr.Text.ToString().Replace("'", "");
            tb_nom_usr.Text = tb_nom_usr.Text.ToString().Replace("'", "");
            tb_tel_usr.Text = tb_tel_usr.Text.ToString().Replace("'", "");
            tb_car_usr.Text = tb_car_usr.Text.ToString().Replace("'", "");
            tb_dir_tra.Text = tb_dir_tra.Text.ToString().Replace("'", "");
            tb_ven_max.Text = tb_ven_max.Text.ToString().Replace("'", "");
            tb_ide_per.Text = tb_ide_per.Text.ToString().Replace("'", "");

            return "OK";
        }

        // Evento SelectionChangeCommitted : Combobox Inicio de Sesion
        private void cb_ini_ses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_ini_ses.SelectedIndex == 0){
                tb_ide_usr.Clear();
                tb_ide_usr.Enabled = true;
                tb_ide_usr.Focus();
            }else{
                tb_ide_usr.Clear();
                tb_ide_usr.Enabled = false;
                tb_ide_usr.Text = cb_ini_ses.SelectedItem.ToString();
                tb_nom_usr.Focus();
            }            
        }

        // Evento KeyPress: Ventana Maxima Abiertas
        private void tb_ven_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyPress: ID. Persona
        private void tb_ide_per_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown: ID. Persona
        private void tb_ide_per_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_bus_per();
            }
        }

        // Evento Validated: ID. Persona
        private void tb_ide_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_per();
        }

        // Evento Click: Buscar Persona
        private void bt_bus_per_Click(object sender, EventArgs e)
        {
            Fi_bus_per();
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {            
            try
            {
                DialogResult msg_res;

                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    // Registrar usuario
                    o_ads007.Fe_nue_reg(tb_ide_usr.Text.Trim(), tb_nom_usr.Text.Trim(), tb_tel_usr.Text.Trim(), 
                                        tb_car_usr.Text.Trim(), tb_dir_tra.Text.Trim(), tb_ema_usr.Text.Trim(), 
                                        int.Parse(tb_ven_max.Text.Trim()), int.Parse(tb_ide_per.Text.Trim()), 
                                        int.Parse(cb_tip_usr.SelectedValue.ToString()), cb_ini_ses.SelectedIndex);

                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    frm_pad.Fe_act_frm(tb_ide_usr.Text);
                    Fi_lim_pia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
               
    }
}
