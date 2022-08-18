using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp001 - Grupo Persona                                */
    /*      Opción: Edita Registro                                        */
    /*       Autor: JEJR - Crearsis             Fecha: 22-07-2020         */
    /**********************************************************************/
    public partial class adp001_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp001 o_adp001 = new adp001();
        DataTable Tabla = new DataTable();

        public adp001_03()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();

            // Despliega Datos en Pantalla
            tb_cod_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString().Trim();
            tb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString().Trim();                        
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_cod_gru.Text = string.Empty;
            tb_nom_gru.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat()
        {
            // Valida que el campo código NO este vacio
            if (tb_cod_gru.Text.Trim() == "")
                return "DEBE proporcionar el Código Grupo Persona";            

            // Valida que el campo código NO este vacio
            int.TryParse(tb_cod_gru.Text, out int cod_gru);
            if (cod_gru == 0)
                return "El Código Grupo Persona NO es valido";            

            // Valida que el campo Nombre del Grupo Persona NO este vacio
            if (tb_nom_gru.Text.Trim() == ""){
                return "DEBE proporcionar el Nombre para el Grupo Persona";
            }

            // Valida que el campo Nombre del Grupo Persona NO este vacio
            if (tb_est_ado.Text.Trim() == "Deshabilitado"){
                return "El Grupo de Persona se encuentra Deshabilitado";
            }

            // Verifica SI el grupo de persona se encuentra registrado
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count == 0){
                return "El Grupo Persona NO se encuentra registrado en el Sistema";
            }

            // Valida que el modulo no esta deshabilitado
            if (tb_est_ado.Text.Trim() == "Deshabilitado"){
                return "El Grupo Persona se encuentra Deshabilitado";
            }

            // Verifica SI existe otro registro con el mismo nombre
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_nom(tb_nom_gru.Text.Trim(), int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count > 0){
                return "YA existe otra Grupo Persona con el mismo nombre";
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
                if (msg_val != "OK")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (msg_res == DialogResult.OK)
                {
                    // Edita Tipo de Atributo
                    o_adp001.Fe_edi_tar(int.Parse(tb_cod_gru.Text), tb_nom_gru.Text);
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_cod_gru.Text));
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
