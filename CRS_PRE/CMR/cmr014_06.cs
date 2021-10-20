using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class cmr014_06 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        cmr014 o_cmr014 = new cmr014();
        DataTable Tabla = new DataTable();
        string Titulo = "Elimina Vendedor";

        public cmr014_06()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los datos en pantalla
            Fi_lim_pia();

            // Despliega Informacion
            tb_cod_ven.Text = frm_dat.Rows[0]["va_cod_ide"].ToString();
            tb_nom_ven.Text = frm_dat.Rows[0]["va_nom_bre"].ToString();
            tb_tel_cel.Text = frm_dat.Rows[0]["va_tel_cel"].ToString();
            tb_ema_ail.Text = frm_dat.Rows[0]["va_ema_ail"].ToString();

            if (frm_dat.Rows[0]["va_pro_ced"].ToString() == "1")
                tb_pro_ced.Text = "Interno";
            else
                tb_pro_ced.Text = "Externo";

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            else
                tb_est_ado.Text = "Deshabilitado";
        }

        // Limpia e Iniciliza los campos
        private void Fi_lim_pia()
        {
            tb_cod_ven.Text = string.Empty;
            tb_nom_ven.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            tb_pro_ced.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
        }

        // Función: Valida Datos
        protected string Fi_val_dat()
        {
            // Valida que este definido en la base de datos
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text), 1);
            if (Tabla.Rows.Count == 0)
                return "EL Vendedor NO se encuentra registado";
            
            // Valida que este Deshabilitado
            if (tb_est_ado.Text == "Habilitado")
                return "EL Vendedor se encuentra Habilitado, NO se puede Eliminar";

            // Valida que no se haya realizado ningun documento con ese vendedor


            return "";
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

                msg_res = MessageBox.Show("Esta seguro de Eliminar el Vendedor?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    // Elimina Vendedor
                    o_cmr014.Fe_eli_ven(1, int.Parse(tb_cod_ven.Text));
                }
                MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                frm_pad.Fe_act_frm(int.Parse(tb_cod_ven.Text));
                cl_glo_frm.Cerrar(this);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
