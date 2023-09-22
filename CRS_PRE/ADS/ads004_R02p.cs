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
                /* Verificar el Módulo sea distinto a cero */
                if (tb_ide_mod.Text.Trim().CompareTo("") == 0 ||
                    tb_ide_mod.Text.Trim().CompareTo("0") == 0){
                    tb_ide_mod.Focus();
                    return "DEBE proporcionar el Módulo";
                }

                /* Verifica que el ID. Módulo sea numerico */
                if (!cl_glo_bal.IsNumeric(tb_ide_mod.Text.Trim())){
                    tb_ide_mod.Focus();
                    return "El ID. Módulo DEBE ser Numerico";
                }

                /* Valida que el modulo este registrada */
                Tabla = new DataTable();
                Tabla = o_ads001.Fe_con_mod(int.Parse(tb_ide_mod.Text));
                if (Tabla.Rows.Count == 0){
                    tb_ide_mod.Focus();
                    return "La Módulo NO se encuentra registrado";
                }

                /* Valida que se proporcione el ID. Documento Inicial */
                if (tb_doc_ini.Text.Trim() == ""){
                    tb_doc_ini.Focus();
                    return "DEBE proporcionar el ID. Documento Inicial";
                }

                /* Valida si es que existe el documento Inicial */
                Tabla = new DataTable();
                Tabla = o_ads003.Fe_con_doc(tb_doc_ini.Text.Trim());
                if (Tabla.Rows.Count == 0){
                    tb_doc_ini.Focus();
                    return "El Documento Inicial NO se encuentra registrado";
                }

                /* Valida que se proporcione el ID. Documento Final */
                if (tb_doc_fin.Text.Trim() == ""){
                    tb_doc_fin.Focus();
                    return "DEBE proporcionar el ID. Documento Final";
                }

                /* Valida si es que existe el documento Final */
                Tabla = new DataTable();
                Tabla = o_ads003.Fe_con_doc(tb_doc_fin.Text.Trim());
                if (Tabla.Rows.Count == 0){
                    tb_doc_fin.Focus();
                    return "El Documento Final NO se encuentra registrado";
                }

                /* Valida que el Documento Inicial sea MENOR al documento Final */
                if (tb_doc_fin.Text.Trim().CompareTo(tb_doc_ini.Text.Trim()) < 0){
                    tb_doc_ini.Focus();
                    return "El ID. Documento Inicial DEBE ser menor al ID. Documento Final";
                }

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
                tb_ide_mod.Text = Tabla.Rows[0]["va_ide_mod"].ToString().Trim();
                lb_nom_mod.Text = Tabla.Rows[0]["va_nom_mod"].ToString().Trim();
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
                if (ini_fin == 1) { 
                    tb_doc_ini.Text = Tabla.Rows[0]["va_ide_doc"].ToString().Trim();
                    lb_ndo_ini.Text = Tabla.Rows[0]["va_nom_doc"].ToString().Trim();
                }else {
                    tb_doc_ini.Text = Tabla.Rows[0]["va_ide_doc"].ToString().Trim();
                    lb_ndo_fin.Text = Tabla.Rows[0]["va_nom_doc"].ToString().Trim();
                }
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

            /* Verifica si el módulo seleccionado */
            Fi_obt_mod(int.Parse(tb_ide_mod.Text));
            if (lb_nom_mod.Text.CompareTo("...") == 0) {
                MessageBox.Show("El Módulo seleccionado es Incorrecto o NO existe", "Error", MessageBoxButtons.OK);
                return;
            }

            /* Obtiene el Documento */
            ads003_01b frm = new ads003_01b();
            frm.vp_ide_mod = int.Parse(tb_ide_mod.Text.Trim());
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);
            if (frm.DialogResult == DialogResult.OK){
                if (ini_fin == 1){
                    tb_doc_ini.Text = frm.tb_ide_doc.Text;
                    Fi_obt_doc(1, tb_doc_ini.Text);
                }else{
                    tb_doc_fin.Text = frm.tb_ide_doc.Text;
                    Fi_obt_doc(2, tb_doc_fin.Text);
                }
            }
        }

        // Evento Click : Button Buscar Módulo
        private void bt_bus_mod_Click(object sender, EventArgs e)
        {
            Fi_bus_mod();
        }

        // Evento Click : Button Documento Inicial
        private void bt_doc_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_doc(1);
        }

        // Evento Click : Button Documento Final
        private void bt_doc_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_doc(2);
        }

        // Evento KeyPress : ID. Modulo
        private void tb_ide_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento KeyDown : ID. Modulo
        private void tb_ide_mod_KeyDown(object sender, KeyEventArgs e)
        {
            /* al presionar tecla para ARRIBA */
            if (e.KeyData == Keys.Up){
                Fi_bus_mod();
            }
        }

        // Evento KeyDown : Documento Inicial
        private void tb_doc_ini_KeyDown(object sender, KeyEventArgs e)
        {
            /* al presionar tecla para ARRIBA */
            if (e.KeyData == Keys.Up)
                Fi_bus_doc(1);            
        }

        // Evento KeyDown : Documento Final
        private void tb_doc_fin_KeyDown(object sender, KeyEventArgs e)
        {
            /* Al presionar tecla para ARRIBA */
            if (e.KeyData == Keys.Up)
                Fi_bus_doc(2);            
        }

        // Evento Leave : ID. Módulo
        private void tb_ide_mod_Leave(object sender, EventArgs e)
        {
            /* Obtiene datos del modulo */
            Fi_obt_mod(int.Parse(tb_ide_mod.Text));
        }

        // Evento Leave : Documento Inicial
        private void tb_doc_ini_Leave(object sender, EventArgs e)
        {
            /* Obtiene ID. Documento Inicial */ 
            Fi_obt_doc(1, tb_doc_ini.Text.Trim());
        }

        // Evento Leave : Documento Final
        private void tb_doc_fin_Leave(object sender, EventArgs e)
        {
            /* Obtiene ID. Documento Final */         
            Fi_obt_doc(2, tb_doc_ini.Text.Trim());
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            string doc_ini;  // Documento Inicial
            string doc_fin;  // Documento Final
               int ide_mod;  // ID. Módulo

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
