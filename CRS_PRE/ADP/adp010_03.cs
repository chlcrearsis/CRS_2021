using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp010 - Descuento General p/Persona                  */
    /*      Opción: Registra Permiso                                      */
    /*       Autor: JEJR - Crearsis             Fecha: 21-10-2021         */
    /**********************************************************************/
    public partial class adp010_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        // Instancias
        adp010 o_adp010 = new adp010();
        DataTable Tabla = new DataTable();
        // Variables
        string va_tip_ope = "N"; 

        public adp010_03(){
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e){
            Fi_lim_pia();
        }       

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia(){
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_por_con.Text = "0.00";
            tb_por_cre.Text = "0.00";
            cb_tip_fac.Text = "No";
            cb_tip_ndv.Text = "No";
            Fi_ini_pan();
        }

        // Inicializa los campos en pantalla
        private void Fi_ini_pan() {
            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();

            // Despliega Informeacion del descuento
            Tabla = new DataTable();
            Tabla = o_adp010.Fe_con_sul(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count > 0){
                tb_por_con.Text = Tabla.Rows[0]["va_por_con"].ToString();
                tb_por_cre.Text = Tabla.Rows[0]["va_por_cre"].ToString();
                if (Tabla.Rows[0]["va_tip_fac"].ToString() == "S")
                    cb_tip_fac.Text = "Si";
                else
                    cb_tip_fac.Text = "No";

                if (Tabla.Rows[0]["va_tip_ndv"].ToString() == "S")
                    cb_tip_ndv.Text = "Si";
                else
                    cb_tip_ndv.Text = "No";
            }            
        }

        // Valida los datos proporcionados
        protected string Fi_val_dat(){          
            if (cb_tip_fac.Text.Trim() == "No" && cb_tip_ndv.Text.Trim() == "No")
                return "DEBE seleccionar al menos un Tipo de Venta (p/Factura; p/Nota de Venta)";
            

            // Verifica SI existe el descuento para esa persona
            Tabla = new DataTable();
            Tabla = o_adp010.Fe_con_reg(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count == 0){
                va_tip_ope = "N";
            }else {
                va_tip_ope = "E";
            }
            return "";
        }

        void Fi_for_dec(int tip_ctl)
        {
            // Formatea decimales
            switch (tip_ctl) {
                case 1: // Contado
                    tb_por_con.Text = decimal.Round(decimal.Parse(tb_por_con.Text), 2).ToString();
                    tb_por_con.Text = decimal.Parse(tb_por_con.Text).ToString("N2");
                    break;
                case 2: // Credito
                    tb_por_cre.Text = decimal.Round(decimal.Parse(tb_por_cre.Text), 2).ToString();
                    tb_por_cre.Text = decimal.Parse(tb_por_cre.Text).ToString("N2");
                    break;
            }                                     
        }

        private void tb_por_con_Validated(object sender, EventArgs e)
        {
            Fi_for_dec(1);
        }

        private void tb_por_cre_Validated(object sender, EventArgs e)
        {
            Fi_for_dec(2);
        }


        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try{
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show("Error: " + msg_val, Text, MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de actualizar la informacion?", Text, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    
                    // Graba el registro en la BD.
                    if (va_tip_ope.CompareTo("N") == 0) { 
                        o_adp010.Fe_nue_reg(int.Parse(tb_cod_per.Text), cb_tip_fac.Text.Substring(0, 1), cb_tip_ndv.Text.Substring(0, 1), decimal.Parse(tb_por_con.Text), decimal.Parse(tb_por_cre.Text));
                    }else{
                        o_adp010.Fe_edi_tar(int.Parse(tb_cod_per.Text), cb_tip_fac.Text.Substring(0, 1), cb_tip_ndv.Text.Substring(0, 1), decimal.Parse(tb_por_con.Text), decimal.Parse(tb_por_cre.Text));
                    }

                    // Retorna Atras */
                    MessageBox.Show("Los datos se grabaron correctamente", Text, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
                }
            }
            catch (Exception ex) {
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
