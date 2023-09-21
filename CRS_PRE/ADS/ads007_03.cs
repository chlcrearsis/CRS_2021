using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads007 - Usuario                                      */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 29-07-2023         */
    /**********************************************************************/
    public partial class ads007_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        ads006 o_ads006 = new ads006();
        ads007 o_ads007 = new ads007();
        adp002 o_adp002 = new adp002();
        DataTable Tabla = new DataTable();

        public ads007_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Carga los Tipos de Usuario a la lista
            cb_tip_usr.Items.Clear();
            cb_tip_usr.DataSource = o_ads006.Fe_lis_tus("H");
            cb_tip_usr.ValueMember = "va_ide_tus";
            cb_tip_usr.DisplayMember = "va_nom_tus";
            cb_tip_usr.SelectedIndex = 0;

            // Despliega Informacion del Usuario
            tb_ide_usr.Text = frm_dat.Rows[0]["va_ide_usr"].ToString();
            cb_tip_usr.SelectedValue = frm_dat.Rows[0]["va_ide_tus"].ToString();
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

            /* Verifica que el código de Persona sea DISTINTO A vacio */
            if (tb_ide_per.Text.Trim() == "" || tb_ide_per.Text.Trim() == "0"){
                lb_raz_soc.Text = "...";
                tb_ide_per.Focus();
                MessageBox.Show("DEBE proporcionar un código de persona válido", Text, MessageBoxButtons.OK);
                return;
            }
            /* Valida que el codigo de persona sea Numerico */
            if (!cl_glo_bal.IsNumeric(tb_ide_per.Text.Trim())){
                lb_raz_soc.Text = "...";
                tb_ide_per.Focus();
                MessageBox.Show("DEBE proporcionar un codigo de persona válido", Text, MessageBoxButtons.OK);
                return;
            }

            /* Obtiene datos de la persona */
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_ide_per.Text.Trim()));
            if (Tabla.Rows.Count == 0){
                lb_raz_soc.Text = "...";
            }else{
                lb_raz_soc.Text = Tabla.Rows[0]["va_raz_soc"].ToString();
            }
        }

        /// <summary>
        /// Función: Busca Persona
        /// </summary>
        private void Fi_bus_per()
        {
            adp002_01 frm = new adp002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_per.Text = frm.tb_cod_per.Text;
                Fi_obt_per();
            }
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el ID. Usuario NO este vacio
            if (tb_ide_usr.Text.Trim() == "")
            {
                tb_ide_usr.Focus();
                return "DEBE proporcionar el ID. Usuario";
            }

            // Valida que el ID. Usuario tenga MAYOR a 4 digitos
            if (tb_ide_usr.Text.Trim().Length < 4)
            {
                tb_ide_usr.Focus();
                return "El ID. Usuario DEBE contener al menos 4 caracteres como mínimo";
            }

            // Valida que el Nombre Usuario NO este vacio
            if (tb_nom_usr.Text.Trim() == "")
            {
                tb_nom_usr.Focus();
                return "DEBE proporcionar el nombre del Usuario";
            }

            // Valida que el Cargo del Usuario NO este vacio
            if (tb_car_usr.Text.Trim() == "")
            {
                tb_car_usr.Focus();
                return "DEBE proporcionar el cargo del Usuario";
            }

            // Verifica que el maximo de ventas abierta sea Numerico
            if (!cl_glo_bal.IsNumeric(tb_ven_max.Text.Trim()))
            {
                tb_ven_max.Focus();
                return "El Campo de Máximo de Ventas abiertas DEBE ser numerico";
            }

            // Valida que el máximo de ventanas abiertas sea mayor a 1
            if (int.Parse(tb_ven_max.Text.Trim()) == 0)
            {
                tb_ven_max.Focus();
                return "Las Ventanas máximas abiertas DEBE ser MAYOR a 1";
            }

            // Verifica si la persona se encuentra creada
            if (tb_ide_per.Text.CompareTo("0") != 0)
            {
                Tabla = new DataTable();
                Tabla = o_adp002.Fe_con_per(int.Parse(tb_ide_per.Text.Trim()));
                if (Tabla.Rows.Count == 0)
                {
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

        // Evento Click: Buscar Persona
        private void bt_bus_per_Click(object sender, EventArgs e)
        {
            Fi_bus_per();
        }

        // Evento Validated: ID. Persona
        private void tb_ide_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_per();
        }

        // Evento KeyDown: ID. Persona
        private void tb_ide_per_KeyDown(object sender, KeyEventArgs e)
        {
            // Al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                // Abre la ventana Busca Persona
                Fi_bus_per();
            }
        }        

        // Evento Click: Aceptar
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
                msg_res = MessageBox.Show("Está seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita el registro
                    o_ads007.Fe_edi_tar(tb_ide_usr.Text.Trim(), tb_nom_usr.Text.Trim(), tb_tel_usr.Text.Trim(),
                                        tb_car_usr.Text.Trim(), tb_dir_tra.Text.Trim(), tb_ema_usr.Text.Trim(),
                                        int.Parse(tb_ven_max.Text.Trim()), int.Parse(tb_ide_per.Text.Trim()),
                                        int.Parse(cb_tip_usr.SelectedValue.ToString()));
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

        // Evento Click: Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
