using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADS - ADMINISTRACIÓN Y SEGURIDAD                      */
    /*  Aplicación: ads005 - Numeración                                   */
    /*      Opción: Informe R01 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 22-06-2023         */
    /**********************************************************************/
    public partial class ads005_R01p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancias
        ads003 o_ads003 = new ads003();
        ads005 o_ads005 = new ads005();
        ads013 o_ads013 = new ads013();
        ads016 o_ads016 = new ads016();
        DataTable Tabla = new DataTable();

        public ads005_R01p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            /* Desplega Información inicial */
            tb_ges_tio.Text = string.Empty;
            tb_doc_ini.Text = string.Empty;
            tb_doc_fin.Text = string.Empty;

            /* Inicializa Campos en Pantalla */
            tb_ges_tio.Text = "0";
            tb_doc_ini.Text = "AAA";
            lb_ndo_ini.Text = "...";
            tb_doc_fin.Text = "ZZZ";
            lb_ndo_fin.Text = "...";

            /* Obtiene la Gestion Actual */
            Tabla = new DataTable();
            Tabla = o_ads013.Fe_obt_glo(1, 2);
            if (Tabla.Rows.Count > 0)
                tb_ges_tio.Text = Tabla.Rows[0]["va_glo_ent"].ToString();

            /* Obtiene el Documento Incial y Final */
            Tabla = new DataTable();
            Tabla = o_ads003.Fe_lis_doc("1");
            if (Tabla.Rows.Count > 0){
                tb_doc_ini.Text = Tabla.Rows[0]["va_ide_doc"].ToString().Trim();
                lb_ndo_ini.Text = Tabla.Rows[0]["va_nom_doc"].ToString().Trim();
                tb_doc_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_doc"].ToString().Trim();
                lb_ndo_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_doc"].ToString().Trim();
            }
        }

        /// <summary>
        /// Valida los datos proporcionados en pantalla
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            try
            {
                /* Verificar la Gestión sea distinto a cero */
                if (tb_ges_tio.Text.Trim().CompareTo("") == 0 ||
                    tb_ges_tio.Text.Trim().CompareTo("0") == 0){
                    tb_ges_tio.Focus();
                    return "DEBE proporcionar la Gestión";
                }

                /* Verifica que la Gestión sea numerico */
                int.TryParse(tb_ges_tio.Text.Trim(), out int ges_tio);
                if (ges_tio == 0){
                    tb_ges_tio.Focus();
                    return "La Gestión DEBE ser Numerico";
                }

                /* Valida que la Gestión este registrada y habilitada */
                Tabla = new DataTable();
                Tabla = o_ads016.Fe_con_ges(int.Parse(tb_ges_tio.Text));
                if (Tabla.Rows.Count == 0){
                    tb_ges_tio.Focus();
                    return "La Gestión NO se encuentra registrado";
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
                if (tb_doc_fin.Text.Trim() == "") {
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
                if (tb_doc_fin.Text.Trim().CompareTo(tb_doc_ini.Text.Trim()) < 0) {
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
                    tb_doc_fin.Text = Tabla.Rows[0]["va_ide_doc"].ToString().Trim();
                    lb_ndo_fin.Text = Tabla.Rows[0]["va_nom_doc"].ToString().Trim();
                }
            }
        }        

        /// <summary>
        /// Buscar Documentos
        /// </summary>
        /// <param name="ini_fin">Inidicador de Campos</param>
        private void Fi_bus_doc(int ini_fin)
        {
            ads003_01 frm = new ads003_01();
            frm.vp_ide_mod = 0;
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

        // Evento KeyPress: Gestión
        private void tb_ges_tio_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        // Evento Click: Button Documento Inicial
        private void bt_doc_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_doc(1);
        }

        // Evento Click: Button Documento Final
        private void bt_doc_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_doc(2);
        }

        // Evento KeyDown: Documento Inicial
        private void tb_doc_ini_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_doc(1);
            }
        }

        // Evento KeyDown: Documento Final
        private void tb_doc_fin_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Usuario
                Fi_bus_doc(2);
            }
        }

        // Evento Leave: Documento Inicial
        private void tb_doc_ini_Leave(object sender, EventArgs e)
        {
            // Obtiene ID. Documento Inicial           
            Fi_obt_doc(1, tb_doc_ini.Text.Trim());
        }

        // Evento Leave: Documento Final
        private void tb_doc_fin_Leave(object sender, EventArgs e)
        {
            // Obtiene ID. Documento Final           
            Fi_obt_doc(2, tb_doc_ini.Text.Trim());
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string msg_val = Fi_val_dat();
            string doc_ini; // Documento Inicial
            string doc_fin; // Documento Final  
               int ges_tio; // Gestion

            if (msg_val != "OK"){
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene parametros de pantalla
            ges_tio = int.Parse(tb_ges_tio.Text.Trim());
            doc_ini = tb_doc_ini.Text.Trim();
            doc_fin = tb_doc_fin.Text.Trim();

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_ads005.Fe_inf_R01(ges_tio, doc_ini, doc_fin);

            // Genera el Informe
            ads005_R01w frm = new ads005_R01w{
                vp_ges_tio = ges_tio,
                vp_doc_ini = doc_ini,
                vp_doc_fin = doc_fin
            };
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
