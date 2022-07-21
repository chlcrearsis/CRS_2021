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
        // Instancias
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

                if (int.Parse(tb_tip_ini.Text) < int.Parse(tb_tip_fin.Text)){
                    return "El Tipo Atributo Inicial DEBE ser mayor al Tipo de Atributo Final";
                }

                return "";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }                  

        /// <summary>
        /// Obtiene la descripcion del tipo de atributo
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
                    tb_tip_ini.Text = frm.tb_ide_tip.Text;
                    Fi_obt_tip(1, int.Parse(tb_tip_ini.Text));
                }else{
                    tb_tip_fin.Text = frm.tb_ide_tip.Text;
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

        private void tb_tip_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene el Tipo de Atributo Inicial           
            Fi_obt_tip(1, int.Parse(tb_tip_ini.Text));
        }       

        private void tb_tip_fin_Leave(object sender, EventArgs e)
        {
            Fi_obt_tip(2, int.Parse(tb_tip_fin.Text));
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            string est_ado = "";
               int tip_ini = 0;
               int tip_fin = 0;            

            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene parametros de pantalla
            tip_ini = int.Parse(tb_tip_ini.Text);
            tip_fin = int.Parse(tb_tip_fin.Text);

            // Obtiene el estado del reporte
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_inf_R01(est_ado, tip_ini, tip_fin);

            // Genera el Informe
            adp004_R01w frm = new adp004_R01w();
            frm.vp_est_ado = est_ado;
            frm.vp_tip_ini = tip_ini;
            frm.vp_tip_fin = tip_fin;
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }

        
    }
}
