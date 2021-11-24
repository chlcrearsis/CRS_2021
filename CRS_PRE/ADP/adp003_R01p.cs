using System;
using System.Windows.Forms;

namespace CRS_PRE
{
    public partial class adp003_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;

        public adp003_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {     
            // Desplega Información inicial            
            cb_est_ado.SelectedIndex = 0;
            rb_ord_cod.Checked = true;
            rb_ord_nom.Checked = false;            
        }

        protected string Fi_val_dat()
        {
            try
            {                
                return "OK";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            //Registrar usuario
            /*Tabla = new DataTable();
            Tabla = o_ads016.Fe_ads016_R01(int.Parse(tb_ges_tio.Text));
            ads016_R01w frm = new ads016_R01w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);*/
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }
    }
}
