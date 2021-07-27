using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads005_03 : Form
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
        DataTable tab_ges = new DataTable();
        DateTime va_fec_ini_ges;
        DateTime va_fec_fin_ges;


        public ads005_03()
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


        protected string Fi_val_dat()
        {
            // Variable usada para verificar datos numericos
            int val = 0;

            //Verificar Documento
            if (tb_ide_doc.Text.Trim()=="")
            {
                tb_ide_doc.Focus();
                return "Debe proporcionar el Documento";
            }
 
            tabla = new DataTable();
            tabla = o_ads003.Fe_con_doc(tb_ide_doc.Text);
            if(tabla.Rows.Count==0)
            {
                tb_ide_doc.Focus();
                return "El Documento no se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_ide_doc.Focus();
                return "El Documento se encuentra Deshabilitado";
            }

            //Verificar Talonario
            if (tb_nro_tal.Text.Trim() == "")
            {
                tb_nro_tal.Focus();
                return "Debe proporcionar el nro de talonario";
            }

            val = 0;
            if (tb_nro_tal.Text.Trim() != "0")
            {
                int.TryParse(tb_nro_tal.Text.Trim(), out val);
                if (val == 0)
                {
                    tb_nro_tal.Focus();
                    return "El nro de talonario debe ser numerico";
                }
            }
            tabla = new DataTable();
            tabla = o_ads004.Fe_con_tal(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text));
            if(tabla.Rows.Count == 0)
            {
                tb_nro_tal.Focus();
                return "El Talonario no se encuentra registrado";
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_ide_doc.Focus();
                return "El Talonario se encuentra Deshabilitado";
            }

            // Verifica gestion
            if (cb_ges_tio.Text == "")
            {
                cb_ges_tio.Focus();
                return "Gestion no valida";
            }

            int.TryParse(tb_nro_ini.Text, out val);
            val = 0;
            if(tb_nro_ini.Text.Trim() != "0")
            { 
                int.TryParse(tb_nro_ini.Text.Trim(), out val);
                if (val == 0)
                {
                    tb_nro_ini.Focus();
                    return "El nro inicial debe ser numerico";
                }
            }

            int.TryParse(tb_nro_fin.Text, out val);
            val = 0;
            if (tb_nro_fin.Text.Trim() != "0")
            {
                int.TryParse(tb_nro_fin.Text.Trim(), out val);
                if (val == 0)
                {
                    tb_nro_fin.Focus();
                    return "El nro final debe ser numerico";
                }
            }

            if(int.Parse(tb_nro_ini.Text) > int.Parse(tb_nro_fin.Text))
            {
                tb_nro_fin.Focus();
                return "El nro final debe ser mayor al nro inicial";
            }


            int.TryParse(tb_con_tad.Text, out val);
            val = 0;
            if (tb_con_tad.Text.Trim() != "0")
            {
                int.TryParse(tb_con_tad.Text.Trim(), out val);
                if (val == 0)
                {
                    tb_con_tad.Focus();
                    return "El contador debe ser numerico";
                }
            }


            DateTime dval;
            DateTime.TryParse(tb_fec_ini.Text, out dval);
            if (dval == DateTime.Parse("01/01/0001"))
            {
                tb_fec_ini.Focus();
                return "Debe proporcionar una fecha inicial valida";
            }
            DateTime.TryParse(tb_fec_fin.Text, out dval);
            if (dval == DateTime.Parse("01/01/0001"))
            {
                tb_fec_fin.Focus();
                return "Debe proporcionar una fecha final valida";
            }

            if (DateTime.Parse(tb_fec_ini.Text) > DateTime.Parse(tb_fec_fin.Text))
            {
                tb_fec_fin.Focus();
                return "La fecha final debe ser mayor a la inicial";
            }

            // Verifica que las fechas esten dentro del rango de fechas de la gestion
            va_fec_ini_ges = DateTime.Parse(o_ads016.Fe_con_per(int.Parse(cb_ges_tio.Text),1).Rows[0]["va_fec_ini"].ToString());
            va_fec_fin_ges = DateTime.Parse(o_ads016.Fe_con_per(int.Parse(cb_ges_tio.Text), 12).Rows[0]["va_fec_fin"].ToString());

            if(DateTime.Parse(tb_fec_ini.Text) < va_fec_ini_ges)
            {
                tb_fec_ini.Focus();
                return "La fecha inicial no pertenece a la gestion";
            }
            if (DateTime.Parse(tb_fec_fin.Text) > va_fec_fin_ges)
            {
                tb_fec_fin.Focus();
                return "La fecha final no pertenece a la gestion";
            }

            //Verifica que la numeracion no haya sido registrada antes
            tabla = o_ads005.Fe_con_num(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text), int.Parse(cb_ges_tio.Text));
            if (tabla.Rows.Count == 0)
            {
                //if(! (tabla.Rows[0][0] is DBNull))
                    return "La numeracion para el talonario del documento, No se encuentra registrada";
            }
               

            return "";
        }

      
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de modificar la informacion?", "Modifica Numeracion", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
            {
                //Modifica numeracion
                o_ads005.Fe_edi_num(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text), int.Parse(cb_ges_tio.Text),DateTime.Parse(tb_fec_ini.Text), 
                    DateTime.Parse(tb_fec_fin.Text), int.Parse(tb_nro_ini.Text), int.Parse(tb_nro_fin.Text), int.Parse(tb_con_tad.Text));

                MessageBox.Show("Los datos se grabaron correctamente", "Modifica Numeracion", MessageBoxButtons.OK);
                
                frm_pad.Fe_act_frm(tb_ide_doc.Text, int.Parse(tb_nro_tal.Text),int.Parse(cb_ges_tio.Text) );
                cl_glo_frm.Cerrar(this);
            }
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
