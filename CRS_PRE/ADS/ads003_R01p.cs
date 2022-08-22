using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads003 - Definición de Documento                      */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 22-08-2022         */
    /**********************************************************************/
    public partial class ads003_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        DataTable Tabla = new DataTable();

        public ads003_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {     
            // Desplega Información inicial
            tb_mod_ini.Text = string.Empty;
            tb_mod_fin.Text = string.Empty;
            lb_nmo_ini.Text = string.Empty;
            lb_nmo_fin.Text = string.Empty;
            cb_est_ado.SelectedIndex = 0;

            // Obtiene y Desplega el tipo de atributo inicial y final
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_lis_mod("1");
            if (Tabla.Rows.Count > 0){
                // Obtiene el Tipo de Atributo Inicial
                tb_mod_ini.Text = Tabla.Rows[0]["va_ide_mod"].ToString().Trim();
                lb_nmo_ini.Text = Tabla.Rows[0]["va_nom_mod"].ToString().Trim();
                // Obtiene el Tipo de Atributo Final
                tb_mod_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_mod"].ToString().Trim();
                lb_nmo_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_mod"].ToString().Trim();
            }else {
                // Obtiene el Tipo de Atributo Inicial
                tb_mod_ini.Text = "0";
                lb_nmo_ini.Text = "Módulo Inicial";
                // Obtiene el Tipo de Atributo Final
                tb_mod_fin.Text = "99";
                lb_nmo_fin.Text = "Módulo Final";
            }
        }

        protected string Fi_val_dat()
        {
            try
            {
                if (tb_mod_ini.Text == "")
                    return "Debe proporcionar el Módulo Inicial";
                
                if (tb_mod_fin.Text == "")
                    return "Debe proporcionar el Módulo Final";                

                if (int.Parse(tb_mod_ini.Text) > int.Parse(tb_mod_fin.Text))
                    return "El Módulo Inicial DEBE ser menor al Módulo Final";                

                return "OK";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }                  

        /// <summary>
        /// Obtiene el nombre del Módulo
        /// </summary>
        void Fi_obt_mod(int ini_fin, int ide_mod)
        {
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(ide_mod);
            if (Tabla.Rows.Count == 0){
                if (ini_fin == 1)
                    lb_nmo_ini.Text = "";
                else
                    lb_nmo_fin.Text = "";
            }else{
                if (ini_fin == 1){
                    lb_nmo_ini.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                }else{
                    lb_nmo_fin.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
                }
            }
        }

        private void bt_mod_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_tip(1);
        }

        private void bt_mod_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_tip(2);
        }


        private void Fi_bus_tip(int ini_fin)
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                if (ini_fin == 1){
                    tb_mod_ini.Text = frm.tb_ide_mod.Text;
                    Fi_obt_mod(1, int.Parse(tb_mod_ini.Text));
                }else{
                    tb_mod_fin.Text = frm.tb_ide_mod.Text;
                    Fi_obt_mod(2, int.Parse(tb_mod_fin.Text));
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

        private void tb_mod_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene el Tipo de Atributo Inicial           
            Fi_obt_mod(1, int.Parse(tb_mod_ini.Text));
        }       

        private void tb_mod_fin_Leave(object sender, EventArgs e)
        {
            Fi_obt_mod(2, int.Parse(tb_mod_fin.Text));
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            string est_ado = "";          

            if (msg_val != "OK")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene parametros de pantalla
            int mod_ini = int.Parse(tb_mod_ini.Text);
            int mod_fin = int.Parse(tb_mod_fin.Text);

            // Obtiene el estado del reporte
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_inf_R01(est_ado, mod_ini, mod_fin);

            // Genera el Informe
            ads003_R01w frm = new ads003_R01w();
            frm.vp_est_ado = est_ado;
            frm.vp_mod_ini = mod_ini;
            frm.vp_mod_fin = mod_fin;
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
