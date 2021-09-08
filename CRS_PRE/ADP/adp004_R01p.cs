using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp004_R01p : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        General general = new General();
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        DataTable Tabla = new DataTable();


        public adp004_R01p()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {     
            // Desplega Información inicial
            tb_tip_ini.Text = string.Empty;
            tb_tip_fin.Text = string.Empty;
            lb_nta_ini.Text = string.Empty;
            lb_nta_fin.Text = string.Empty;
            cb_est_ado.SelectedIndex = 0;
            rb_ord_cod.Checked = true;
            rb_ord_nom.Checked = false;

            // Obtiene y Desplega el tipo de atributo inicial y final
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_lis_tip("0");
            if (Tabla.Rows.Count > 0){
                // Obtiene el Tipo de Atributo Inicial
                tb_tip_ini.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                lb_nta_ini.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
                // Obtiene el Tipo de Atributo Final
                tb_tip_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_tip"].ToString().Trim();
                lb_nta_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_tip"].ToString().Trim();
            }else {
                // Obtiene el Tipo de Atributo Inicial
                tb_tip_ini.Text = "0";
                lb_nta_ini.Text = "Tipo Inicial";
                // Obtiene el Tipo de Atributo Final
                tb_tip_fin.Text = "999";
                lb_nta_fin.Text = "Tipo Final";
            }
        }

        protected string Fi_val_dat()
        {
            try
            {
                if (tb_tip_ini.Text == ""){
                    return "Debe proporcionar el Tipo de Atributo Inicial";
                }
                if (tb_tip_fin.Text == ""){
                    return "Debe proporcionar el Tipo de Atributo Final";
                }
                                
                if (rb_ord_cod.Checked == false && rb_ord_nom.Checked == false) {
                    return "Tiene que establecer un tipo de ordenamiento para general el informe";
                }

                return "OK";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }                  

        /// <summary>
        /// Obtiene ide y nombre del usuario
        /// </summary>
        void Fi_obt_tip(int ini_fin, int ide_tip)
        {
            // Obtiene ide y nombre del usuario
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(ide_tip);
            if (Tabla.Rows.Count == 0){
                if (ini_fin == 1)
                    lb_nta_ini.Text = "";
                else
                    lb_nta_fin.Text = "";
            }else{
                if (ini_fin == 1){
                    lb_nta_ini.Text = Tabla.Rows[0]["va_nom_tip"].ToString();
                }else{
                    lb_nta_fin.Text = Tabla.Rows[0]["va_nom_tip"].ToString();
                }
            }
        }

        private void bt_tip_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_tip(1);
        }

        private void bt_tip_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_tip(2);
        }


        private void Fi_bus_tip(int ini_fin)
        {
            adp003_01 frm = new adp003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                if (ini_fin == 1){
                    tb_tip_ini.Text = frm.tb_sel_bus.Text;
                    Fi_obt_tip(1, int.Parse(tb_tip_ini.Text));
                }else{
                    tb_tip_fin.Text = frm.tb_sel_bus.Text;
                    Fi_obt_tip(2, int.Parse(tb_tip_fin.Text));
                }
            }
        }

        private void tb_tip_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_tip(1);
            }
        }

        private void tb_tip_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_tip(2);
            }
        }

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

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }
    }
}
