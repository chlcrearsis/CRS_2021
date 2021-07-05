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
using CRS_PRE.CMR;
using CRS_NEG;
using CRS_NEG;
using CRS_PRE.ADS;
using CRS_PRE.INV;

namespace CRS_PRE.CMR
{
    public partial class cmr000_01 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //Instancias
        ads016 o_ads016 = new ads016();
        ads004 o_ads004 = new ads004();

        // Instancias Clases de: VENTAS
        res001 o_res001 = new res001();

        // Instancias Clases de: COMPRAS
        inv007 o_inv007 = new inv007();
        cmr004 o_cmr004 = new cmr004();
        c_res004 o_res004 = new c_res004();
        cmr005 o_cmr005 = new cmr005();

        //** Tablas
        DataTable tab_dat = new DataTable();
        DataTable tab_dat_avi = new DataTable();
        DataTable tab_ads004 = new DataTable();
        DataTable tab_pla_vta = new DataTable();
        DataTable dat_doc = new DataTable();            // Tabla para impresion o mostrar documento

        string ide_doc = "";
        string cod_doc = "";
        int ges_doc = 0;
        int nro_tal = 0;
        
        int cod_plv = 0;
        string imp_nom = "";
        int for_imp = 0;
        int nro_cop = 0;

        int ban_av1 = 0;
        int ban_av2 = 0;
        string imp_av1 = "";
        string imp_av2 = "";

       string ope_rac = "";

        public cmr000_01()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            try
            {
                //Recupera datos
                cod_doc = frm_dat.Rows[0]["va_cod_doc"].ToString();             // Documento (XXX)
                ges_doc = int.Parse(frm_dat.Rows[0]["va_ges_doc"].ToString());  // Gestion (0000)
                nro_tal = int.Parse(frm_dat.Rows[0]["va_nro_tal"].ToString());  // Nro de talonario (0)
                ide_doc = frm_dat.Rows[0]["va_ide_doc"].ToString();             // ID. Documento (xxx-000-000000)
                cod_plv = int.Parse(frm_dat.Rows[0]["va_cod_plv"].ToString());  // Codigo de plantilla de venta (0)

                // Obtiene formato de impresion y nro de copias
                tab_ads004 = o_ads004.Fe_con_tal(cod_doc,nro_tal);

                for_imp = int.Parse(tab_ads004.Rows[0]["va_for_mat"].ToString());   // Formato de impresion (0)
                nro_cop = int.Parse(tab_ads004.Rows[0]["va_nro_cop"].ToString());   // Nro de copias de impresion (0)

                ope_rac = frm_dat.Rows[0]["va_ope_rac"].ToString();

                lb_ide_doc.Text = ide_doc;
                lb_tit_ope.Text = ope_rac + ":";

                // Crea tabla para pasar datos p/impresion o mostrar documento
                dat_doc = new DataTable();
                dat_doc.Columns.Add("va_ide_doc");
                dat_doc.Columns.Add("va_ges_doc");

                dat_doc.Rows.Add();
                dat_doc.Rows[0]["va_ide_doc"] = ide_doc;
                dat_doc.Rows[0]["va_ges_doc"] = ges_doc;


                switch (ope_rac.ToUpper())
                {
                    case "VENTA" :
                        if (cod_doc.Substring(0,2) == "VR") // Restaurant
                        {
                            // Obtiene impresora
                            tab_pla_vta = o_res004.Fe_con_plv(cod_plv.ToString());
                            imp_nom = tab_pla_vta.Rows[0]["va_imp_ntv"].ToString();
                        }
                        if (cod_doc.Substring(0, 2) == "VT") // Comercial
                        {
                            // Obtiene impresora
                            tab_pla_vta = o_cmr004.Fe_con_plv(cod_plv.ToString());
                            imp_nom = tab_pla_vta.Rows[0]["va_imp_ntv"].ToString();
                                                      
                        }


                        break;
                    case "COMPRA":
                        //Fi_cmp_ver();
                       
                        break;

                    case "PEDIDO":
                        // Obtiene plantilla de venta
                        tab_pla_vta = o_cmr004.Fe_con_plv(cod_plv.ToString());
                        imp_nom = tab_pla_vta.Rows[0]["va_imp_ped"].ToString();
                        break;


                }

                // Obtiene impresora para el documento               
                lb_nom_imp.Text = imp_nom + " - [ " + nro_cop.ToString() + " Copia(s) ]";

                // Verifica bandera imprime aviso 1
                ban_av1 = int.Parse(tab_pla_vta.Rows[0]["va_ban_av1"].ToString());
                imp_av1 = tab_pla_vta.Rows[0]["va_imp_av1"].ToString();

                // Verifica bandera imprime aviso 2
                ban_av2 = int.Parse(tab_pla_vta.Rows[0]["va_ban_av2"].ToString());
                imp_av2 = tab_pla_vta.Rows[0]["va_imp_av2"].ToString();

                bt_imp_rim.Focus();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Boton busca impresoras
        private void bt_bus_imp_Click(object sender, EventArgs e)
        {
            ads000_12 frm = new ads000_12();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                imp_nom = frm.dg_res_ult.Rows[frm.dg_res_ult.CurrentCell.RowIndex].Cells[0].Value.ToString();
                lb_nom_imp.Text = imp_nom + " - [ " + nro_cop.ToString() + " Copia(s) ]";
            }
        }

        // Boton cancelar caja de impresion
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        // Boton imprimir documento
        private void bt_imp_rim_Click(object sender, EventArgs e)
        {
            switch (ope_rac.ToUpper())
            {
                case "VENTA":
                    Fi_vta_imp();
                    break;
                case "COMPRA":
                    Fi_cmp_imp();
                    break;
            }
        }
        // Boton previsualizar documento
        private void bt_ver_doc_Click(object sender, EventArgs e)
        {
            switch (ope_rac.ToUpper())
            {
                case "VENTA":
                    Fi_vta_ver();
                    break;
                case "COMPRA":
                    Fi_cmp_ver();
                    break;
            }
        }

        private void Fi_vta_ver()
        {
            Form frm = new Form();

            if (cod_doc == "VRS") // Nota de Venta Restaurant
            {
                //tab_dat = o_res001.Fe_con_vta(ide_doc, ges_doc); // Obtiene datos
                frm = new res001_05w(); // Instancia ventana
            }
            if (cod_doc == "VRF") // Factura Restaurant
            {

            }

            if (cod_doc == "VTS") // Nota de Venta
            {
                /* ABRE FORMULARIO CONSULTA */
                frm = new cmr005_05w();
                cl_glo_frm.abrir(this.frm_pad, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, dat_doc);
            }
            if (cod_doc == "VTF") // Factura
            {

            }

            Close();
        }


        private void Fi_cmp_ver()
        {
            Form frm = new Form();

            if (cod_doc == "CMP") // Compra
            {
                // Obtiene datos
                tab_dat = o_inv007.Fe_inv007_05a_p01(ide_doc, ges_doc);

                // Instancia ventana
                frm = new inv007_05();
            }
            

            cl_glo_frm.abrir(this.frm_pad, frm , cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tab_dat);
            Close();
        }


        private void Fi_vta_imp()
        {
            dynamic frm_imp = null;
            dynamic frm_imp_avi = null;

            if (cod_doc == "VRS") // Nota de Venta Restaurant
            {
                // Obtiene datos
                tab_dat_avi = o_res001.Fe_con_avi(ide_doc, ges_doc);
                frm_imp_avi = new res001_05bw();
                switch (for_imp)
                {
                    case 0: // Formato generico
                        tab_dat = o_res001.Fe_con_vta(ide_doc, ges_doc);
                        frm_imp = new res001_05w();
                        break;

                   default : // Cuando no pilla el formato, imprime el por defecto
                        tab_dat = o_res001.Fe_con_vta(ide_doc, ges_doc);
                        frm_imp = new res001_05w();
                        break;
                }
            }
            if (cod_doc == "VRF") // Factura Restaurant
            {}

            if (cod_doc == "VTS") // Nota de Venta
            {
                // Obtiene datos
                //tab_dat_avi = o_cmr005.Fe_con_vta(ide_doc, ges_doc);
                frm_imp_avi = new cmr005_05w();
                
            }
            if (cod_doc == "VTF") // Factura
            {

            }


            frm_imp = new cmr005_05w();
            frm_imp.frm_dat = dat_doc;
            frm_imp.Fe_pob_rep();
            frm_imp.Fe_imp_doc(cod_doc, nro_tal, imp_nom, nro_cop);

            if (ban_av1 == 1)
            {
                frm_imp_avi.frm_dat = dat_doc;
                frm_imp_avi.Fe_pob_rep();
                frm_imp_avi.Fe_imp_doc(cod_doc, nro_tal, imp_av1, 0);
            }
            if (ban_av2 == 1)
            {
                frm_imp_avi.frm_dat = dat_doc;
                frm_imp_avi.Fe_pob_rep();
                frm_imp_avi.Fe_imp_doc(cod_doc, nro_tal, imp_av2, 0);
            }

        }


        private void Fi_cmp_imp()
        {
            dynamic frm_imp = null;

            if (cod_doc == "CMP") // Nota de Venta Restaurant
            {
                tab_dat = o_res001.Fe_con_vta(ide_doc, ges_doc);

                //inv007_05w frm = new inv007_05w();
                //frm_imp = frm;

            }
           

            frm_imp.frm_dat = tab_dat;
            frm_imp.Fe_pob_rep();
            frm_imp.Fe_imp_doc(cod_doc, nro_tal);
        }

    }
}
