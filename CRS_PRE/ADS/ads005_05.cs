using System;
using System.Data;
using System.Windows.Forms;

using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads005_05 : Form
    {

        public dynamic frm_pad;
        public DataTable frm_dat;
        public int frm_tip;
        //Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ads005 o_ads005 = new ads005();
        ads001 o_ads001 = new ads001();
        ads016 o_ads016 = new ads016();

        DataTable tabla = new DataTable();
        DataTable tab_prm = new DataTable();


        public ads005_05()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            tb_ide_doc.Text = frm_dat.Rows[0]["va_ide_doc"].ToString();
            tb_nom_doc.Text = frm_dat.Rows[0]["va_nom_doc"].ToString();
            tb_nro_tal.Text = frm_dat.Rows[0]["va_nro_tal"].ToString();
            tb_nom_tal.Text = frm_dat.Rows[0]["va_nom_tal"].ToString();
            cb_ges_tio.Items.Add(1);
            cb_ges_tio.Items[0] = frm_dat.Rows[0]["va_ges_tio"].ToString();
            cb_ges_tio.SelectedIndex = 0;
            //cb_ges_tio.SelectedIndex.ToString();
            tb_nro_ini.Text = frm_dat.Rows[0]["va_nro_ini"].ToString();
            tb_nro_fin.Text = frm_dat.Rows[0]["va_nro_fin"].ToString();
            tb_con_tad.Text = frm_dat.Rows[0]["va_con_tad"].ToString();
            tb_fec_ini.Text = frm_dat.Rows[0]["va_fec_ini"].ToString();
            tb_fec_fin.Text = frm_dat.Rows[0]["va_fec_fin"].ToString();
        }
     
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }


        private void Bt_bus_doc_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_doc();
        }
        private void Tb_ide_doc_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Documento
                Fi_abr_bus_doc();
            }
        }

        void Fi_abr_bus_doc()
        {
            ads003_01 frm = new ads003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK )
            {
                tb_ide_doc.Text = frm.tb_sel_bus.Text;
                Fi_obt_doc();
            }
        }


        private void Bt_bus_tal_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_tal();
        }
        private void Tb_nro_tal_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Talonario
                Fi_abr_bus_tal();
            }
        }
        void Fi_abr_bus_tal()
        {
            // Construye tabla parametros
            tab_prm = new DataTable();
            tab_prm.Columns.Add("va_ide_doc");
            tab_prm.Columns.Add("va_nom_doc");

            tab_prm.Rows.Add();

            tab_prm.Rows[0]["va_ide_doc"] = tb_ide_doc.Text;
            tab_prm.Rows[0]["va_nom_doc"] = tb_nom_doc.Text;

            ads004_01b frm = new ads004_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, tab_prm);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_nro_tal.Text = frm.tb_sel_tal.Text;
                Fi_obt_tal();
            }
        }

        private void Tb_ide_doc_Validated(object sender, EventArgs e)
        {
            Fi_obt_doc();
        }
        private void Tb_nro_tal_Validated(object sender, EventArgs e)
        {
            Fi_obt_tal();
            
        }


        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_doc()
        {
            // Obtiene ide y nombre documento
            tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if (tabla.Rows.Count == 0)
            {
                tb_nom_doc.Clear();
            }
            else
            {
                tb_ide_doc.Text = tabla.Rows[0]["va_ide_doc"].ToString();
                tb_nom_doc.Text = tabla.Rows[0]["va_nom_doc"].ToString();
            }
        }


        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_tal()
        {
            // Obtiene ide y nombre documento
            tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text,int.Parse(tb_nro_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_nom_tal.Clear();
            }
            else
            {
                tb_nro_tal.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                tb_nom_tal.Text = tabla.Rows[0]["va_nom_tal"].ToString();
            }
        }
    }
}
