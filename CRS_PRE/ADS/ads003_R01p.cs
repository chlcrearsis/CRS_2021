using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads003_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();

        DataTable tabla = new DataTable();


        public ads003_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Obtiene Modulos
            //tabla = o_ads001.Fe_obt_mod();
            cb_mod_ulo.DataSource = o_ads001.Fe_obt_mod();
            cb_mod_ulo.ValueMember = "va_ide_mod";
            cb_mod_ulo.DisplayMember = "va_nom_mod";

            cb_est_ado.SelectedIndex = 0;
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            
            //Obtiene datos
            tabla = new DataTable();
            string va_est_ado = "T";

            if (cb_est_ado.Text == "Todos")
                va_est_ado = "T";
            if (cb_est_ado.Text == "Habilitado")
                va_est_ado = "H";
            if (cb_est_ado.Text == "Deshabilitado")
                va_est_ado = "N";

           
            tabla= o_ads003.Fe_ads003_R01(int.Parse(cb_mod_ulo.SelectedValue.ToString()), va_est_ado);

            ads003_R01w frm = new ads003_R01w();

            frm.vp_est_ado = cb_est_ado.Text;
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tabla);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
