using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads004 - Talonarios                                   */
    /*      Opción: Informe R02 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 31-03-2023         */
    /**********************************************************************/
    public partial class ads004_R02p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads001 o_ads001 = new ads001();
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        DataTable Tabla = new DataTable();

        public ads004_R02p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Desplega Información inicial
            tb_ide_mod.Text = string.Empty;
            lb_nom_mod.Text = string.Empty;
            tb_doc_ini.Text = string.Empty;
            tb_doc_fin.Text = string.Empty;

            // Inicializa Campos en Pantalla
            tb_ide_mod.Text = "0";
            lb_nom_mod.Text = "...";
            tb_doc_ini.Text = "AAA";
            lb_ndo_ini.Text = "...";
            tb_doc_fin.Text = "ZZZ";
            lb_ndo_fin.Text = "...";
        }

        /// <summary>
        /// Valida los datos proporcionados en pantalla
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            try
            {
                if (lb_nom_mod.Text == "..." || lb_nom_mod.Text == "")
                    return "Debe selecciónar el ID. Módulo";

                if (tb_doc_ini.Text.Trim() == "")
                    return "Debe proporcionar el ID. Documento Inicial";

                if (tb_doc_fin.Text.Trim() == "")
                    return "Debe proporcionar el ID. Documento Final";

                if (tb_doc_fin.Text.Trim().CompareTo(tb_doc_ini.Text.Trim()) < 0)
                    return "El ID. Documento Inicial DEBE ser menor al ID. Documento Final";

                return "OK";
            }
            catch (Exception)
            {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }
        }

        /// <summary>
        /// Obtiene el nombre del Módulo
        /// </summary>
        void Fi_obt_mod(int ide_mod)
        {
            Tabla = new DataTable();
            Tabla = o_ads001.Fe_con_mod(ide_mod);
            if (Tabla.Rows.Count == 0){
                lb_nom_mod.Text = "...";
            }else{
                lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString();
            }
        }

        /// <summary>
        /// Obtiene el nombre del Documento
        /// </summary>
        void Fi_obt_doc(int ini_fin, string ide_doc)
        {
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_con_doc(ide_doc);
            if (Tabla.Rows.Count == 0){
                if (ini_fin == 1)
                    lb_ndo_ini.Text = "...";
                else
                    lb_ndo_fin.Text = "...";
            }else{
                if (ini_fin == 1)
                    lb_ndo_ini.Text = Tabla.Rows[0]["va_nom_doc"].ToString();
                else
                    lb_ndo_fin.Text = Tabla.Rows[0]["va_nom_doc"].ToString();
            }
        }

        /// <summary>
        /// Buscar el Módulo
        /// </summary>
        private void Fi_bus_mod()
        {
            ads001_01 frm = new ads001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                tb_ide_mod.Text = frm.tb_ide_mod.Text;
                Fi_obt_mod(int.Parse(tb_ide_mod.Text));
            }
        }

        /// <summary>
        /// Buscar Documentos
        /// </summary>
        /// <param name="ini_fin">Inidicador de Campos</param>
        private void Fi_bus_doc(int ini_fin)
        {
            if (tb_ide_mod.Text.Trim().CompareTo("") == 0) {
                MessageBox.Show("DEBE seleccionar el ID. Módulo", "Error", MessageBoxButtons.OK);
                return;
            }

            // Verifica si el módulo seleccionado
            Fi_obt_mod(int.Parse(tb_ide_mod.Text));
            if (lb_nom_mod.Text.CompareTo("...") == 0) {
                MessageBox.Show("El Módulo seleccionado es Incorrecto o NO existe", "Error", MessageBoxButtons.OK);
                return;
            }


            ads003_01b frm = new ads003_01b();
            frm.vp_ide_mod = int.Parse(tb_ide_mod.Text.Trim());
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK)
            {
                if (ini_fin == 1){
                    tb_doc_ini.Text = frm.tb_ide_doc.Text;
                    Fi_obt_doc(1, tb_doc_ini.Text);
                }else{
                    tb_doc_fin.Text = frm.tb_ide_doc.Text;
                    Fi_obt_doc(2, tb_doc_fin.Text);
                }
            }
        }

        // Button: Buscar Módulo
        private void bt_bus_mod_Click(object sender, EventArgs e)
        {
            Fi_bus_mod();
        }

        private void bt_doc_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_doc(1);
        }

        private void bt_doc_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_doc(2);
        }

        private void tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                Fi_bus_mod();
            }
        }

        private void tb_doc_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_doc(1);
            }
        }

        private void tb_doc_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_doc(2);
            }
        }

        private void tb_ide_mod_Leave(object sender, EventArgs e)
        {
            // Obtiene datos del modulo      
            Fi_obt_mod(int.Parse(tb_ide_mod.Text));
        }

        private void tb_doc_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene ID. Documento Inicial           
            Fi_obt_doc(1, tb_doc_ini.Text.Trim());
        }

        private void tb_doc_fin_Leave(object sender, EventArgs e)
        {
            // Obtiene ID. Documento Final           
            Fi_obt_doc(2, tb_doc_ini.Text.Trim());
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            string doc_ini = "";
            string doc_fin = "";  
               int ide_mod;

            if (msg_val != "OK"){
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene parametros de pantalla
            ide_mod = int.Parse(tb_ide_mod.Text);
            doc_ini = tb_doc_ini.Text.Trim();
            doc_fin = tb_doc_fin.Text.Trim();

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads004.Fe_inf_R02(ide_mod, doc_ini, doc_fin);

            // Genera el Informe
            ads004_R02w frm = new ads004_R02w();            
            frm.vp_ide_mod = ide_mod;
            frm.vp_doc_ini = doc_ini;
            frm.vp_doc_fin = doc_fin;
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
