using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr014_07b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        //ads001 o_ads001 = new ads001();

        DataTable Tabla = new DataTable();
        string Titulo = "Edita Cobrador";

        public cmr014_07b()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia Campos
            Fi_lim_pia();
            // Desplega Datos en Pantalla
            tb_cod_cob.Text = frm_dat.Rows[0]["va_cod_ide"].ToString();
            tb_nom_cob.Text = frm_dat.Rows[0]["va_nom_bre"].ToString();
            tb_cms_cre.Text = frm_dat.Rows[0]["va_cms_cre"].ToString();

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_cod_cob.Text = string.Empty;
            tb_nom_cob.Text = string.Empty;
            tb_cms_cre.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Valida Datos en Pantalla
        protected string Fi_val_dat()
        {
            // Valida si existe el registro
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_cob.Text), 2);
            if (Tabla.Rows.Count == 0){
                return "El Cobrador que desea editar NO se encuentra registrado";
            }

            if (tb_est_ado.Text == "Deshabilitado") {
                return "El Cobrador está Deshabilitado, No se puede modificar la comisión";
            }
            
            // Revisa Porcentaje al crédito
            if (cl_glo_bal.IsDecimal(tb_cms_cre.Text) == false){
                tb_cms_cre.Focus();
                return "El porcentaje de comisión al crédito es incorrecto";
            }

            // Valida que los porcentaje sea mayor a cero
           
            if (decimal.Parse(tb_cms_cre.Text) < 0m){
                tb_cms_cre.Focus();
                return "El porcentaje de comisión al crédito DEBE ser MAYOR a CERO";
            }           

            return "";
        }

        private void tb_cms_cre_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotDecimal(e, tb_cms_cre.Text);
        }
     

        private void tb_cms_cre_Validated(object sender, EventArgs e)
        {
            // Valida que el porcentahe sea valido
            if (cl_glo_bal.IsDecimal(tb_cms_cre.Text) == false){
                MessageBox.Show("El porcentaje de comision al crédito no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_cms_cre.Focus();
            }

            // Formatea para mostrar decimal
            tb_cms_cre.Text = decimal.Round(decimal.Parse(tb_cms_cre.Text), 2).ToString();
            tb_cms_cre.Text = decimal.Parse(tb_cms_cre.Text).ToString("N2");
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;
            try {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != ""){
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }
                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK){
                    int ide_tip = 2;    // Cobrador
                    int cod_cob = int.Parse(tb_cod_cob.Text);
                    int tip_cms = 1;
                    decimal cms_con = 0m;
                    decimal cms_cre = decimal.Parse(tb_cms_cre.Text);
                    // Actualiza Comision Cobrador
                    o_cmr014.Fe_edi_com(ide_tip, cod_cob, tip_cms, cms_con, cms_cre);
                    frm_pad.Fe_act_frm(int.Parse(tb_cod_cob.Text));

                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    cl_glo_frm.Cerrar(this);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
