using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


using CRS_NEG;
using CRS_PRE.INV;

namespace CRS_PRE
{
    public partial class cmr005_02 : Form
    {

        /* VARIABLES GLOBALES PUBLICAS */
        public dynamic frm_pad;
        public int frm_tip;
        
        /* INSTANCIAS  */
        cmr001 o_cmr001 = new cmr001();     // Lista de precio
        cmr002 o_cmr002 = new cmr002();     // Precios
        cmr004 o_cmr004 = new cmr004();     // Plantilla de ventas
        cmr005 o_cmr005 = new cmr005();     // Encabezado de Ventas
        cmr006 o_cmr006 = new cmr006();     // Detalle de la venta
        cmr007 o_cmr007 = new cmr007();     // Encabezado de Pedido
        adp002 o_adp002 = new adp002();     // Persona
        cmr015 o_cmr015 = new cmr015();     // Delivery
        cmr014 o_cmr014 = new cmr014();     // Vendedor

        inv002 o_inv002 = new inv002();     // Bodega
        inv004 o_inv004 = new inv004();     // Producto

        ads004 o_ads004 = new ads004();     // Talonario
        ads016 o_ads016 = new ads016();     // Periodo
        
        cl_glo_frm o_mg_glo_frm = new cl_glo_frm();     // CLASE DE METODOS GLOBALES


        /* TABLAS*/
        DataTable tabla = new DataTable();      // Tabla generica
        DataTable tab_prm = new DataTable();    // Tabla Parametros
        DataTable tab_pro = new DataTable();    // Tabla producto       
        DataTable tab_doc = new DataTable();    // Tabla Documento grabado

        DataTable tab_cmr004 = new DataTable(); // Tabla Plantilla de ventas
        public DataTable tab_adp002 = new DataTable();  // Tabla Persona
        DataTable tab_cmr001 = new DataTable(); // Tabla Lista de precio
        DataTable tab_cmr002 = new DataTable(); // Tabla Precios
        DataTable tab_cmr015 = new DataTable(); // tabla Delivery
        DataTable tab_cmr014 = new DataTable(); // Tabla Vendedor
        DataTable tab_inv002 = new DataTable(); // Tabla Bodega
        DataTable tab_dat = new DataTable();    // Tabla Datos para impresion

        //string va_ide_vta = "";

        // Variables para Documentos
        string ve_doc_vta = "";
        int ve_nro_tal = 0;

        //** Variable Venta para (M=Mostrador ; L=Llevar ; D=Delivery)
        string ve_vta_par = "M";
        string ve_mon_vta = "";        // Moneda de la venta
        //** Variable para parametros plantilla de venta
        bool ve_ban_plv = false;
        int ve_lis_ant = 0;        // Guarda lista de precio anterior
        int ve_lis_dec = 0;        // Nro decimales de la lista de precio
        decimal ve_pre_uni = 0;    // Precio unitario del item
        decimal ve_pre_lis = 0.0000m;   // Precio de lista del item
        decimal ve_pmx_inc = 0.00m;     // Porcentaje Maximo Incremento
        decimal ve_pmx_des = 0.00m;     // Porcentaje Maximo Descuento

        DateTime ve_cod_tmp = new DateTime();   // Codigo temporal del documento
        DateTime ve_lis_fec_ini;                // Fecha inicial de la lista de precio
        DateTime ve_lis_fec_fin;                // Fecha final de la lista de precio

        

        int ve_sel_pvt = 0;        // Seleccion de plantilla de Venta
                                   // 0 = No selecciono ; 1 = Si selecciono 
        int ve_bus_pro = 0;            // Busqueda rapida de producto por:
                                    /*  1: Codigo ; 2: Nombre ; 3 = Descripcion */

        public cmr005_02()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            // OBTIENE CODIGO TEMPORAL PARA EL DOCUMENTO
            ve_cod_tmp = o_mg_glo_frm.fg_fec_act();

            /* Inicializa operacion*/
            tb_nom_ope.Text = "NOTA DE VENTA";

            /* Inicializa datos */
            tb_cod_bod.Text = "0";
            tb_fec_vta.Value = DateTime.Today;
            cb_for_pag.SelectedIndex = 0;
            cb_mon_vta.SelectedIndex = 0;
            cb_vta_par.SelectedIndex = 0;
            gb_del_ive.Visible = false;

            tb_nro_ite.Text = "1";

            tb_can_tid.Text = "0";
            tb_pre_vta.Text = "0";
            tb_imp_tot.Text = "0";

            tb_tot_bru.Text = "0.00";

            tb_cod_plv.Focus();

            // Abre buscar planilla 
            Fi_abr_bus_plv();

            if (ve_sel_pvt == 0)
                cl_glo_frm.Cerrar(this);



            

        }

        private void Fi_tab_imp()
        {
            // Crea tabla para pasar datos para imprimir documento
            tab_dat = new DataTable();
            tab_dat.Columns.Add("va_ide_doc");
            tab_dat.Columns.Add("va_cod_doc");
            tab_dat.Columns.Add("va_ges_doc");
            tab_dat.Columns.Add("va_nro_tal");
            tab_dat.Columns.Add("va_ope_rac");
            tab_dat.Columns.Add("va_cod_plv");

        }

        /// <summary>
        ///  Prepara autocompletado del producto
        /// </summary>
        private void Fi_com_ple()
        {
            tb_des_pro.AutoCompleteCustomSource = Fi_car_pro();
            tb_des_pro.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb_des_pro.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        /// <summary>
        /// Carga productos al autocompletado
        /// </summary>
        AutoCompleteStringCollection Fi_car_pro()
        {
            // Define instancia autocompletado
            AutoCompleteStringCollection ac_pro_duc = new AutoCompleteStringCollection();

            if (tab_cmr004.Rows.Count == 0)
                return null;

            /* Obtiene parametro de busqueda rapida para productos*/
            ve_bus_pro = int.Parse(tab_cmr004.Rows[0]["va_bus_pro"].ToString());
            if (ve_bus_pro == 0)
                return null;

            // Obtiene lista de productos
            tabla = o_inv004.Fe_bus_car("", 1, "T");

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                switch (ve_bus_pro)
                {
                    case 1:
                        ac_pro_duc.Add(tabla.Rows[i]["va_cod_pro"].ToString() + "°" + tabla.Rows[i]["va_nom_pro"].ToString());
                        break;
                    case 2: // nombre
                        ac_pro_duc.Add(tabla.Rows[i]["va_nom_pro"].ToString() + "°" + tabla.Rows[i]["va_cod_pro"].ToString());
                        break;
                    case 3:
                        ac_pro_duc.Add(tabla.Rows[i]["va_des_pro"].ToString() + "°" + tabla.Rows[i]["va_cod_pro"].ToString());
                        break;
                }
            }
            return ac_pro_duc;
        }


        /// <summary>
        /// Funcion Interna: Valida datos
        /// </summary>
        /// <returns></returns>
        //protected string Fi_val_dat()
        //{
        //    string val_ret = "";

        //    // Valida Bodega
        //    if (tb_cod_bod.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Debe proporcionar una bodega valida", "Error", MessageBoxButtons.OK);
        //        tb_cod_bod.Focus();
        //    }

           

        //    int val = 0;
           

        //    /* Verifica si la bodega es numerica */
        //    if (int.TryParse(tb_cod_bod.Text, out val) == false)
        //    {
        //        val_ret = "Debe proporcionar una bodega valida";
        //        tb_cod_bod.Focus();
        //        return val_ret;
        //    }

        //    /* Verifica que la bodega exista */
        //    tab_inv002 = new DataTable();
        //    tab_inv002 = o_inv002.Fe_con_bod(val);
           
        //    if (tab_inv002.Rows.Count == 0)
        //    {
        //        val_ret = "Debe proporcionar una bodega valida";
        //        tb_cod_bod.Focus();
        //        return val_ret;
        //    }
        //    if (tab_inv002.Rows[0]["va_est_ado"].ToString() == "N")
        //    {
        //        val_ret = "La bodega se encuentra Deshabilitada";
        //        tb_cod_bod.Focus();
        //        return val_ret;
        //    }

        //    // Verifica que el usuario tenga permiso sobre la bodega
            

        //    // Valida Persona
        //    if (tb_cod_per.Text.Trim() == "")
        //    {
        //        val_ret = "Debe proporcionar una persona valida";
        //        tb_cod_per.Focus();
        //        return val_ret;
        //    }

        //    val = 0;
        //    int.TryParse(tb_cod_per.Text, out val);
        //    if (val == 0)
        //    {
        //        val_ret = "Debe proporcionar una persona valida";
        //        tb_cod_per.Focus();
        //        return val_ret;
        //    }

        //    tabla = new DataTable();
        //    tabla = o_adp002.Fe_con_per(val);
        //    if (tabla.Rows.Count == 0)
        //    {
        //        val_ret = "Debe proporcionar una persona valida";
        //        tb_cod_per.Focus();
        //        return val_ret;
        //    }
        //    if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
        //    {
        //        val_ret = "La persona se encuentra Deshabilitada";
        //        tb_cod_per.Focus();
        //        return val_ret;
        //    }

        //    // Valida que haya al menos un producto en la grilla
        //    if (dg_res_ult.Rows.Count == 0)
        //    {
        //        val_ret = "Debe de registrar al menos un producto para la Venta";
        //        tb_des_pro.Focus();
        //        return val_ret;
        //    }

        //    // Valida que cada item tenga cantidad y precio
        //    val_ret = Fi_val_itm();
        //    if(val_ret != "")
        //    {
        //        return val_ret;
        //    }


        //    return "";
        //}
        //private string Fi_val_itm()
        //{
        //    for (int i = 0; i < dg_res_ult.RowCount ; i++)
        //    {
        //        //Verifica la cantidad del item
        //        if(decimal.Parse( dg_res_ult.Rows[i].Cells["va_can_tid"].Value.ToString()) == 0m)
        //        {
        //            return "Item: " + (i +1) +
        //                " Debe proporcionar cantidad para el producto";
        //        }
        //        //Verifica preci
        //        if (decimal.Parse(dg_res_ult.Rows[i].Cells["va_pre_uni"].Value.ToString()) == 0m)
        //        {
        //            return "Item: " + (i + 1) +
        //                " Debe proporcionar el precio para el producto";
        //        }

        //    }

        //    return "";
        //}

        private int Fi_val_ped()
        {
            String ve_msg_err = "";

            /* Procedimiento que verifica datos antes de grabar pedido */
            ve_msg_err = o_cmr007.Fi_ver_dat(ve_cod_tmp, int.Parse(tb_cod_plv.Text),
                                             int.Parse(tb_cod_bod.Text), int.Parse(tb_cod_per.Text),
                                             tb_fec_vta.Value, cb_for_pag.SelectedIndex,
                                             int.Parse(tb_cod_lis.Text));

            if (ve_msg_err != "")
            {
                MessageBox.Show(ve_msg_err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }

            return 1;
        }

        private int Fi_val_vta()
        {
            String ve_msg_err = "";
            int ve_tip_vta = 0;
            if(tb_nom_ope.Text == "FACTURA")
            {
                ve_tip_vta = 1;
            }
            if (tb_nom_ope.Text == "NOTA DE VENTA")
            {
                ve_tip_vta = 2;
            }

            /* Procedimiento que verifica datos antes de grabar pedido */
            ve_msg_err = o_cmr005.Fi_ver_dat(ve_cod_tmp, ve_tip_vta, int.Parse(tb_cod_plv.Text),
                                             int.Parse(tb_cod_bod.Text), int.Parse(tb_cod_per.Text),
                                             tb_fec_vta.Value, cb_for_pag.SelectedIndex,
                                             int.Parse(tb_cod_lis.Text));
            // Si hay error
            if (ve_msg_err != "")
            {
                MessageBox.Show(ve_msg_err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }

            return 1;
        }


        private void Fi_lim_ite()
        {

            if (dg_res_ult.Rows.Count != 0)
                tb_nro_ite.Text = (dg_res_ult.Rows.Count + 1).ToString();
            else
                tb_nro_ite.Text = "1";

            tb_cod_pro.Text = "";
            tb_des_pro.Text = "";
            tb_can_tid.Text = "0.00";
            tb_pre_vta.Text = "0.00";
            tb_por_des.Text = "0.00";
            tb_imp_tot.Text = "0.00";
            tb_und_vta.Text = "";
            lb_eqv_vta.Text = "0";
            lb_fab_ric.Text = "";

            tb_des_pro.ReadOnly = false;
            tb_des_pro.Focus();
        }
        private void Fi_lim_gri()
        {
            dg_res_ult.Rows.Clear();

            tb_tot_bru.Text = "0.00";

        }


        private void cmr005_02_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Elimina temporal antes de cerrar la ventana
            o_cmr006.fu_eli_tmp(Program.gl_ide_usr, ve_cod_tmp);
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {               
                // DETERMINA QUE DOCUMENTO SE VA A CREAR
                switch (tb_nom_ope.Text)
                {
                    case "PROFORMA":
                        if (Fi_gra_prf() == 0)
                            return;
                        break;
                    case "PEDIDO":
                        /* Valida datos del pedido*/
                        if (Fi_val_ped() == 0)
                        {
                            return;
                        }
                        /* Graba Pedido*/
                        if (Fi_gra_ped() == 0)
                            return;
                        break;
                    case "NOTA DE VENTA":
                        /* Valida datos de la venta*/
                        if (Fi_val_vta() == 0)
                        {
                            return;
                        }
                        if (Fi_gra_ntv() == 0)
                            return;

                        break;
                    case "FACTURA":
                        
                        /* Valida datos de la venta*/
                        if (Fi_val_vta() == 0)
                        {
                            return;
                        }
                        if (Fi_gra_ntv() == 0)
                            return;

                        break;
         
                    default:
                        break;
                }

                //** Envia a imprimir documento
                cmr000_01 frm_cmr001 = new cmr000_01();
                cl_glo_frm.abrir(this, frm_cmr001, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, tab_dat);



                //** Limpiar formulario de venta
                Fi_lim_gri();
                Fi_lim_ite();

                
                

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int Fi_gra_prf()
        {

            ////Abre ventana para completar la operacion
            //cmr005_02d frm_cmr005 = new cmr005_02d();
            //cl_glo_frm.abrir(this, frm_cmr005, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            //if (frm_cmr005.DialogResult == DialogResult.Cancel)
            //    return 0;

            //// Obtiene Gestion
            ////int ges_tio = int.Parse(o_ads016.Fe_obt_ges(tb_fec_vta.Value).Rows[0]["va_ges_tio"].ToString());
            //// GRABA Venta
            //tab_doc = o_cmr005.Fe_crea( DateTime.Parse(ve_cod_tmp.ToString()),
            //    int.Parse(tb_cod_plv.Text), 2, ve_doc_vta, ve_nro_tal, int.Parse(tb_cod_bod.Text), tb_cod_per.Text,
            //    frm_cmr005.tb_nit_vta.Text, frm_cmr005.tb_raz_soc.Text, ve_mon_vta, tb_fec_vta.Value, cb_for_pag.SelectedIndex,
            //    int.Parse(tb_cod_ven.Text), int.Parse(tb_cod_lis.Text), 0, 0, 1, decimal.Parse(frm_cmr005.tb_des_cue.Text),
            //    frm_cmr005.tb_obs_vta.Text, ve_vta_par,0, "", decimal.Parse(frm_cmr005.tb_mto_pag.Text),
            //    decimal.Parse(frm_cmr005.tb_cam_bio.Text), 0);

            return 1;
        }


        private int Fi_gra_ped()
        {

            //Abre ventana para completar la operacion
            cmr007_02d frm = new cmr007_02d();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.Cancel)
                return 0;

            
            // GRABA PEDIDO
            tab_doc = o_cmr007.Fe_nue_reg(Program.gl_ide_usr, DateTime.Parse(ve_cod_tmp.ToString()),
                int.Parse(tb_cod_plv.Text), int.Parse(tb_cod_bod.Text), tb_cod_per.Text,
                frm.tb_nit_vta.Text, frm.tb_raz_soc.Text, ve_mon_vta, tb_fec_vta.Value, cb_for_pag.SelectedIndex,
                int.Parse(tb_cod_ven.Text), int.Parse(tb_cod_lis.Text), 0, 0, decimal.Parse(frm.tb_des_cue.Text),
                frm.tb_obs_vta.Text, ve_vta_par, int.Parse(tb_cod_ven.Text), "");

            // Inicializa tabla para pasar datos
            Fi_tab_imp();

            tab_dat.Rows.Add();
            tab_dat.Rows[0]["va_ide_doc"] = tab_doc.Rows[0]["va_ide_ped"].ToString();

            tab_dat.Rows[0]["va_cod_doc"] = tab_doc.Rows[0]["va_doc_ped"].ToString();
            tab_dat.Rows[0]["va_ges_doc"] = tab_doc.Rows[0]["va_ges_ped"].ToString();
            tab_dat.Rows[0]["va_nro_tal"] = tab_doc.Rows[0]["va_nro_tal"].ToString();

            tab_dat.Rows[0]["va_ope_rac"] = tb_nom_ope.Text;
            tab_dat.Rows[0]["va_cod_plv"] = tb_cod_plv.Text;


            return 1;
        }

        private int Fi_gra_ntv()
        {

            /* Abre ventana para completar la operacion */
            cmr005_02d frm_cmr005 = new cmr005_02d();
            cl_glo_frm.abrir(this, frm_cmr005, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm_cmr005.DialogResult == DialogResult.Cancel)
                return 0;

             // GRABA Venta
            tab_doc = o_cmr005.Fe_nue_reg( DateTime.Parse(ve_cod_tmp.ToString()),
                int.Parse(tb_cod_plv.Text), 2, int.Parse(tb_cod_bod.Text), tb_cod_per.Text,
                frm_cmr005.tb_nit_vta.Text, frm_cmr005.tb_raz_soc.Text, ve_mon_vta, tb_fec_vta.Value, cb_for_pag.SelectedIndex,
                int.Parse(tb_cod_ven.Text), int.Parse(tb_cod_lis.Text), 0, 0, 1, decimal.Parse(frm_cmr005.tb_des_cue.Text),
                frm_cmr005.tb_obs_vta.Text, ve_vta_par, int.Parse(tb_cod_ven.Text), "", decimal.Parse(frm_cmr005.tb_mto_pag.Text),
                decimal.Parse(frm_cmr005.tb_cam_bio.Text), 0);

            // Inicializa tabla para pasar datos
            Fi_tab_imp();

            tab_dat.Rows.Add();
            tab_dat.Rows[0]["va_ide_doc"] = tab_doc.Rows[0]["va_ide_vta"].ToString();

            tab_dat.Rows[0]["va_cod_doc"] = tab_doc.Rows[0]["va_doc_vta"].ToString();
            tab_dat.Rows[0]["va_ges_doc"] = tab_doc.Rows[0]["va_ges_vta"].ToString();
            tab_dat.Rows[0]["va_nro_tal"] = tab_doc.Rows[0]["va_nro_tal"].ToString();

            tab_dat.Rows[0]["va_ope_rac"] = "VENTA";

            tab_dat.Rows[0]["va_cod_plv"] = tb_cod_plv.Text;

            return 1;
        }






        //** BUSCAR BODEGA
        private void Bt_bus_bod_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_bod();
        }
        private void Tb_cod_bod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_bod();
            }
        }
        void Fi_abr_bus_bod()
        {
            inv002_01 frm = new inv002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_bod.Text = frm.tb_sel_bus.Text;
                lb_nom_bod.Text = frm.lb_des_bus.Text;
            }
        }
        private void Tb_cod_bod_Validated(object sender, EventArgs e)
        {
            Fi_obt_bod();
        }
        private void Fi_obt_bod()
        {

            int val = 0;
                        
            if(int.TryParse(tb_cod_bod.Text, out val) == false)
            {
                MessageBox.Show("Debe proporcionar una bodega valida", "Error", MessageBoxButtons.OK);
                tb_cod_bod.Focus();
                return;
            }


            tabla = o_inv002.Fe_con_bod(val);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_bod.Text = "No Existe";
            }
            else
            {
                lb_nom_bod.Text = tabla.Rows[0]["va_nom_bod"].ToString();
            }
        }
 
        //** BUSCAR PERSONA
        private void Bt_bus_per_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_per();
        }
        private void Tb_cod_per_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_per();
            }
        }
        void Fi_abr_bus_per()
        {
            adp002_01 frm = new adp002_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_per.Text = frm.tb_cod_per.Text;

                Fi_obt_per();
            }
            
        }
        private void Tb_cod_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_per();

        }
        private void Fi_obt_per()
        {
            if (tb_cod_per.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar un codigo de proveedor valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
            }
            int val = 0;
            if( int.TryParse(tb_cod_per.Text, out val) == false)          
            {
                //MessageBox.Show("Debe proporcionar un codigo de proveedor valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
                lb_raz_soc.Text = "No Existe";
            }

            tab_adp002 = o_adp002.Fe_con_per(val);
            if (tab_adp002.Rows.Count == 0)
            {
                lb_raz_soc.Text = "No Existe";
            }
            else
            {
                lb_raz_soc.Text = tab_adp002.Rows[0]["va_raz_soc"].ToString();

                if (tab_cmr004.Rows[0]["va_cam_ven"].ToString() == "2") // Asignado al cliente
                {
                    // Obtiene el vendedor asignado al cliente
                    Fi_ven_asi();
                }

            }
        }


        //** BUSCAR PRODUCTO
        private void Bt_bus_pro_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_pro();
        }
        private void Tb_cod_pro_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_pro();
            }
        }
        void Fi_abr_bus_pro()
        {
            if (tb_cod_plv.Text == "")
                return;

            inv004_01b frm = new inv004_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_pro.Text = frm.tb_sel_ecc.Text;
                Fi_obt_pro();
            }
        }
        private void Tb_cod_pro_Validated(object sender, EventArgs e)
        {
            if (tb_cod_pro.Text.Trim() == "")
                Fi_obt_pro();
        }
        private void Fi_obt_pro()
        {
            if (tb_cod_plv.Text == "")
                return;

            if (tb_cod_pro.Text.Trim() == "")
            {
                //MessageBox.Show("El producto no se encuentra registrado", "Error", MessageBoxButtons.OK);
                tb_des_pro.Text = "";
                tb_und_vta.Text = "";
                lb_eqv_vta.Text = "0";
                lb_fab_ric.Text = "";

                return;
            }

            // Obtiene datos del producto
            tab_pro = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tab_pro.Rows.Count == 0)
            {
                MessageBox.Show("El producto no se encuentra registrado", "Error", MessageBoxButtons.OK);
                tb_des_pro.Text = "";
                tb_und_vta.Text = "";
                lb_eqv_vta.Text = "0";
                lb_fab_ric.Text = "";

                tb_des_pro.ReadOnly = false;
            }
            else
            {
                tb_des_pro.Text = tab_pro.Rows[0]["va_nom_pro"].ToString();
                tb_und_vta.Text = tab_pro.Rows[0]["va_und_vta"].ToString();

                lb_eqv_vta.Text = decimal.Round(decimal.Parse(tab_pro.Rows[0]["va_eqv_vta"].ToString()),
                                                int.Parse(tab_pro.Rows[0]["va_nro_dec"].ToString())).ToString();

                lb_eqv_vta.Text = lb_eqv_vta.Text + " " + tab_pro.Rows[0]["va_cod_umd"].ToString();

                lb_fab_ric.Text = tab_pro.Rows[0]["va_fab_ric"].ToString();

                //Si la familia de producto es de servicio, permite editar la descripcion del producto
                if (tab_pro.Rows[0]["va_tip_fam"].ToString() == "S")
                    tb_des_pro.ReadOnly = false;
                if (tab_pro.Rows[0]["va_tip_fam"].ToString() == "D")
                    tb_des_pro.ReadOnly = true;


                // Obtiene precio del producto
                decimal pre_uni = 0m;
                tab_cmr002 = new DataTable();
                tab_cmr002 = o_cmr002.Fe_con_pre(int.Parse(tb_cod_lis.Text), tb_cod_pro.Text);
                if (tab_cmr002.Rows.Count > 0)
                {
                    pre_uni = decimal.Parse(tab_cmr002.Rows[0]["va_pre_cio"].ToString());
                    ve_pre_lis = pre_uni;
                    ve_pmx_des = decimal.Parse(tab_cmr002.Rows[0]["va_pmx_des"].ToString());
                    ve_pmx_inc = decimal.Parse(tab_cmr002.Rows[0]["va_pmx_inc"].ToString());
                }

                if (pre_uni == 0)
                {
                    MessageBox.Show("El producto no tiene precio definido en la lista de precio selecionada", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtiene precio den decimales formateado 
                if (ve_lis_dec == 0)
                {
                    pre_uni = decimal.Round(pre_uni, 0);
                    tb_pre_vta.Text = string.Format("{00:N0}", pre_uni);
                }
                if (ve_lis_dec == 1)
                {
                    pre_uni = decimal.Round(pre_uni, 1);
                    tb_pre_vta.Text = string.Format("{00:N1}", pre_uni);
                }
                if (ve_lis_dec == 2)
                {
                    pre_uni = decimal.Round(pre_uni, 2);
                    tb_pre_vta.Text = string.Format("{00:N2}", pre_uni);
                }
                if (ve_lis_dec == 3)
                {
                    pre_uni = decimal.Round(pre_uni, 3);
                    tb_pre_vta.Text = string.Format("{00:N3}", pre_uni);
                }
                if (ve_lis_dec == 4)
                {
                    pre_uni = decimal.Round(pre_uni, 4);
                    tb_pre_vta.Text = string.Format("{00:N4}", pre_uni);
                }
                if (ve_lis_dec == 5)
                {
                    pre_uni = decimal.Round(pre_uni, 5);
                    tb_pre_vta.Text = string.Format("{00:N5}", pre_uni);
                }
                tb_por_des.Text = "0.00";
            }
        }
        /// <summary>
        /// Opcion de calculo 1=Calcula desde el precio unitario ; 2=Calcula desde el importe Total
        /// </summary>
        /// <param name="opc_cal"></param>
        private void Fi_cal_pre()
        {
            // Calcula precio total de la Venta
            decimal can_tid = 0m;
            decimal pre_vta = 0m;
            decimal imp_tot = 0m;



            can_tid = decimal.Parse(tb_can_tid.Text);
            pre_vta = decimal.Parse(tb_pre_vta.Text);
            imp_tot = decimal.Parse(tb_imp_tot.Text);


            imp_tot = can_tid * pre_vta;
            tb_imp_tot.Text = imp_tot.ToString();

            tb_imp_tot.Text = decimal.Round(decimal.Parse(tb_imp_tot.Text), 2).ToString();
            tb_imp_tot.Text = decimal.Parse(tb_imp_tot.Text).ToString("N2");


        }


        private void tb_can_tid_Validated(object sender, EventArgs e)
        {
            // Valida que el dato proporcionado sea decimal

            decimal val = 0m;
            int nro_dec = 0;
            if( decimal.TryParse(tb_can_tid.Text, out val) == false)
            {
                return;
            }
            else
            {
                // Formatea decimales y manda a calcular
                if (tab_pro.Rows.Count != 0)
                {
                    nro_dec = int.Parse(tab_pro.Rows[0]["va_nro_dec"].ToString());
                    tb_can_tid.Text = decimal.Round(decimal.Parse(tb_can_tid.Text), nro_dec).ToString();

                    switch (nro_dec)
                    {
                        case 0:
                            tb_can_tid.Text = decimal.Parse(tb_can_tid.Text).ToString("N0");
                            break;
                        case 1:
                            tb_can_tid.Text = decimal.Parse(tb_can_tid.Text).ToString("N1");
                            break;
                        case 2:
                            tb_can_tid.Text = decimal.Parse(tb_can_tid.Text).ToString("N2");
                            break;
                        case 3:
                            tb_can_tid.Text = decimal.Parse(tb_can_tid.Text).ToString("N3");
                            break;
                        case 4:
                            tb_can_tid.Text = decimal.Parse(tb_can_tid.Text).ToString("N4");
                            break;
                    }
                }

                Fi_cal_pre();
            }


        }

        private void tb_pre_vta_Validated(object sender, EventArgs e)
        {
            // Valida que el dato proporcionado sea decimal

            decimal val = 0m;
            if (decimal.TryParse(tb_pre_vta.Text, out val)== false)
            {
                //if (decimal.Parse(tb_pre_vta.Text) != 0m)
                //{
                    MessageBox.Show("Debe proporcionar el precio de Venta", "Error", MessageBoxButtons.OK);
                    tb_pre_vta.Focus();
                //}
            }
            else
            {
                ve_pre_uni = 0;
                ve_pre_uni = decimal.Parse(tb_pre_vta.Text);

                // Obtiene precio den decimales formateado 
                if (ve_lis_dec == 0)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 0);
                    tb_pre_vta.Text = string.Format("{00:N0}", ve_pre_uni);
                }
                if (ve_lis_dec == 1)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 1);
                    tb_pre_vta.Text = string.Format("{00:N1}", ve_pre_uni);
                }
                if (ve_lis_dec == 2)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 2);
                    tb_pre_vta.Text = string.Format("{00:N2}", ve_pre_uni);
                }
                if (ve_lis_dec == 3)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 3);
                    tb_pre_vta.Text = string.Format("{00:N3}", ve_pre_uni);
                }
                if (ve_lis_dec == 4)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 4);
                    tb_pre_vta.Text = string.Format("{00:N4}", ve_pre_uni);
                }
                if (ve_lis_dec == 5)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 5);
                    tb_pre_vta.Text = string.Format("{00:N5}", ve_pre_uni);
                }

                // Calcula precio
                Fi_cal_pre();

                // Calcula descuento
                Fi_cal_des();
            }
        }

        /// <summary>
        /// Calcula descuento directo al precio unitario
        /// </summary>
        private void Fi_cal_des()
        {
            decimal por_des = 0.00m;

            if (ve_pre_uni <= ve_pre_lis)
            {
                // calcula porcentaje de descuento
                por_des = (ve_pre_uni * 100);
                por_des = (por_des / ve_pre_lis);
                por_des = 100 - por_des;

                por_des = decimal.Round(por_des, 2);

                por_des = decimal.Parse(string.Format("{00:N2}", por_des));

                tb_por_des.Text = por_des.ToString();
            }
            else
            {
                tb_por_des.Text = por_des.ToString();
            }


        }

        /// <summary>
        /// Calula precio unitario segun porcentaje descontado
        /// </summary>
        private void Fi_cal_por()
        {
            try
            {
                decimal por_des = 0.00m;

                por_des = decimal.Parse(tb_por_des.Text);

                if (por_des == 0m && ve_pre_uni > ve_pre_lis)
                    return;


                // Redonde y formatea porcentaje de descuento a 2 decimales
                por_des = decimal.Round(por_des, 2);
                por_des = decimal.Parse(string.Format("{00:N2}", por_des));
                tb_por_des.Text = por_des.ToString();

                // calcula porcentaje de descuento
                ve_pre_uni = (por_des * ve_pre_lis);
                ve_pre_uni = (ve_pre_uni / 100);
                ve_pre_uni = ve_pre_lis - ve_pre_uni;

                // Obtiene precio den decimales formateado 
                if (ve_lis_dec == 0)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 0);
                    ve_pre_uni = decimal.Parse(string.Format("{00:N0}", ve_pre_uni));
                }
                if (ve_lis_dec == 1)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 1);
                    ve_pre_uni = decimal.Parse(string.Format("{00:N1}", ve_pre_uni));
                }
                if (ve_lis_dec == 2)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 2);
                    ve_pre_uni = decimal.Parse(string.Format("{00:N2}", ve_pre_uni));
                }
                if (ve_lis_dec == 3)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 3);
                    ve_pre_uni = decimal.Parse(string.Format("{00:N3}", ve_pre_uni));
                }
                if (ve_lis_dec == 4)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 4);
                    ve_pre_uni = decimal.Parse(string.Format("{00:N4}", ve_pre_uni));
                }
                if (ve_lis_dec == 5)
                {
                    ve_pre_uni = decimal.Round(ve_pre_uni, 5);
                    ve_pre_uni = decimal.Parse(string.Format("{00:N5}", ve_pre_uni));
                }

                tb_pre_vta.Text = ve_pre_uni.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_por_des.Focus();
            }
        }



        private void tb_can_tid_Enter(object sender, EventArgs e)
        {
            tb_can_tid.SelectAll();
        }

        private void tb_pre_vta_Enter(object sender, EventArgs e)
        {
            tb_pre_vta.SelectAll();

        }
        private void tb_imp_tot_Enter(object sender, EventArgs e)
        {
            tb_imp_tot.SelectAll();
        }

        /// <summary>
        /// Verifica item antes de adicionar
        /// </summary>
        /// <returns>Retorna 0 en caso de no pasar la verificacion y 1 si todo esta ok</returns>
        private int Fi_ver_ite()
        {
            // Valida el producto
            if (tb_cod_pro.Text.Trim() == "")
            {
                MessageBox.Show("Debe de proporcionar un producto", "Error", MessageBoxButtons.OK);
                tb_des_pro.Focus();
                return 0;
            }

            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("El producto no se encuentra registrado", "Error", MessageBoxButtons.OK);
                tb_des_pro.Focus();
                return 0;
            }

            // Verifica descripcion de producto
            if (tb_des_pro.Text.Trim() == "")
            {
                MessageBox.Show("Proporcione la descripcion del producto", "Error", MessageBoxButtons.OK);
                tb_des_pro.Focus();
                return 0;
            }

            // Verifica cantidad
            decimal val = 0m;
            decimal.TryParse(tb_can_tid.Text, out val);
            if (val == 0m)
            {
                MessageBox.Show("Debe proporcionar la cantidad", "Error", MessageBoxButtons.OK);
                tb_can_tid.Focus();
                return 0;
            }

            // Verifica precio
            val = 0m;
            decimal.TryParse(tb_pre_vta.Text, out val);
            if (val == 0m)
            {
                MessageBox.Show("Debe proporcionar el precio", "Error", MessageBoxButtons.OK);
                tb_pre_vta.Focus();
                return 0;
            }

            //Verifica que el producto tenga precio
            if (tab_cmr002.Rows.Count == 0)
            {
                MessageBox.Show("El producto no tiene precio", "Error", MessageBoxButtons.OK);
                tb_pre_vta.Focus();
                return 0;
            }
            // Verifica que el precio unitario no exeda los porcentaje de descuento de la lista del producto
            //if(pre_uni < pre_lis)
            //{
            //Verifica si sobrepasa el %maximo de descuento permitido
            if (decimal.Parse(tb_por_des.Text) > ve_pmx_des)
            {
                MessageBox.Show("El porcentaje de descuento maximo para el producto excede el permitido (" + ve_pmx_des + ")", "Error", MessageBoxButtons.OK);
                tb_por_des.Focus();
                return 0;
            }

            //}

            return 1;
        }


        /// <summary>
        /// Calcula el total bruto de un Item y Calcula total general
        /// </summary>
        /// <param name="nro_itm"> Nro item a calcular el bruto</param>
        void Fi_cal_bru(int nro_itm)
        {
            decimal can_uni = 0;
            decimal pre_uni = 0;
            decimal pre_bru = 0;

            can_uni = decimal.Parse(dg_res_ult.Rows[nro_itm].Cells["va_can_tid"].Value.ToString());
            pre_uni = decimal.Parse(dg_res_ult.Rows[nro_itm].Cells["va_pre_uni"].Value.ToString());

            // Obtiene precio den decimales formateado 
            if (ve_lis_dec == 0)
            {
                pre_uni = decimal.Round(pre_uni, 0);
            }
            if (ve_lis_dec == 1)
            {
                pre_uni = decimal.Round(pre_uni, 1);
            }
            if (ve_lis_dec == 2)
            {
                pre_uni = decimal.Round(pre_uni, 2);
            }
            if (ve_lis_dec == 3)
            {
                pre_uni = decimal.Round(pre_uni, 3);
            }
            if (ve_lis_dec == 4)
            {
                pre_uni = decimal.Round(pre_uni, 4);
            }
            if (ve_lis_dec == 5)
            {
                pre_uni = decimal.Round(pre_uni, 5);
            }



            pre_bru = pre_uni * can_uni;
            pre_bru = decimal.Round(pre_bru, 2);
            dg_res_ult.Rows[nro_itm].Cells["va_pre_tot"].Value = pre_bru;

            Fi_cal_tot();
        }

        private void Fi_cal_tot()
        {
            tb_tot_bru.Text = "0";
            int item = 0;
            for (item = 0; item <= dg_res_ult.RowCount - 1; item++)
            {
                tb_tot_bru.Text = (decimal.Parse(tb_tot_bru.Text) + decimal.Parse(dg_res_ult["va_pre_tot", item].Value.ToString())).ToString();
                // Redefine nro de item
                dg_res_ult.Rows[item].Cells["va_nro_ite"].Value = item + 1;
            }

            tb_tot_bru.Text = decimal.Round(decimal.Parse(tb_tot_bru.Text), 2).ToString(); // <--- Redondea decimales
        }
        //** ADICIONA ITEM
        private void bt_adi_pro_Click(object sender, EventArgs e)
        {
            try
            {


                if (Fi_ver_ite() == 0)
                    return;

                int nro_itm = int.Parse(tb_nro_ite.Text);
                int fila = nro_itm - 1;
                if (bt_adi_pro.Text == "&AGREGAR") //Graba temporal
                    dg_res_ult.Rows.Add();



                dg_res_ult["va_nro_ite", fila].Value = nro_itm;
                dg_res_ult["va_cod_pro", fila].Value = tb_cod_pro.Text;
                dg_res_ult["va_des_pro", fila].Value = tb_des_pro.Text;
                dg_res_ult["va_nom_pro", fila].Value = tab_pro.Rows[0]["va_nom_pro"].ToString();
                dg_res_ult["va_und_vta", fila].Value = tb_und_vta.Text;
                dg_res_ult["va_can_tid", fila].Value = tb_can_tid.Text;
                dg_res_ult["va_pre_uni", fila].Value = tb_pre_vta.Text;
                dg_res_ult["va_pre_lis", fila].Value = ve_pre_lis;
                dg_res_ult["va_pre_tot", fila].Value = tb_imp_tot.Text;

                if (decimal.Parse(tb_por_des.Text) > 0m)
                    dg_res_ult["va_des_cue", fila].Value = ve_pre_lis - ve_pre_uni;
                else
                    dg_res_ult["va_des_cue", fila].Value = 0;

                dg_res_ult["va_por_des", fila].Value = tb_por_des.Text;
                dg_res_ult["va_tip_fam", fila].Value = tab_pro.Rows[0]["va_tip_fam"].ToString();


                //******************************
                // GRABA EN TABLA TEMPORAL

                //Obtiene columnas encabezado
                DataTable tab_det_vta = new DataTable();
                for (int i = 0; i <= dg_res_ult.Columns.Count - 1; i++)
                {
                    tab_det_vta.Columns.Add(dg_res_ult.Columns[i].Name);
                }

                //Obtiene ultima item
                foreach (DataGridViewRow Row in dg_res_ult.Rows)
                {
                    if (Row.Index == fila) // siempre obtiene la fila activa
                    {
                        tab_det_vta.Rows.Add();
                        foreach (DataGridViewTextBoxColumn Cell in dg_res_ult.Columns)
                        {
                            tab_det_vta.Rows[0][Cell.Index] = Row.Cells[Cell.Index].Value;
                        }
                    }
                }


                if (bt_adi_pro.Text == "&AGREGAR") //Graba temporal
                    o_cmr006.fu_gra_tmp(Program.gl_ide_usr, ve_cod_tmp, tab_det_vta);
                if (bt_adi_pro.Text == "&GUARDAR")//Edita temporal
                {
                    o_cmr006.fu_edi_tmp(Program.gl_ide_usr, ve_cod_tmp, tab_det_vta);

                    bt_adi_pro.Text = "&AGREGAR";
                    bt_edi_tar.Enabled = true;
                    bt_eli_min.Enabled = true;

                }

                //******************************
                //*****Limpia campos************
                Fi_lim_ite();

                //******************************
                //*****Calcula totales************
                Fi_cal_tot();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_lim_pia_Click(object sender, EventArgs e)
        {
            Fi_lim_ite();

            bt_adi_pro.Text = "&AGREGAR";
            bt_edi_tar.Enabled = true;
            bt_eli_min.Enabled = true;

            // OBTIENE CODIGO TEMPORAL PARA EL DOCUMENTO
            ve_cod_tmp = o_mg_glo_frm.fg_fec_act();
        }

        private void bt_edi_tar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_res_ult.Rows.Count == 0)
                    return;

                int nro_fil = 0;
                nro_fil = dg_res_ult.CurrentCell.RowIndex;
                tb_nro_ite.Text = (nro_fil + 1).ToString();
                tb_cod_pro.Text = dg_res_ult.Rows[nro_fil].Cells["va_cod_pro"].Value.ToString();

                Fi_obt_pro();
                tb_por_des.Text = dg_res_ult.Rows[nro_fil].Cells["va_por_des"].Value.ToString();
                tb_can_tid.Text = dg_res_ult.Rows[nro_fil].Cells["va_can_tid"].Value.ToString();
                tb_pre_vta.Text = dg_res_ult.Rows[nro_fil].Cells["va_pre_uni"].Value.ToString();
                tb_imp_tot.Text = dg_res_ult.Rows[nro_fil].Cells["va_pre_tot"].Value.ToString();
                tb_des_pro.Text = dg_res_ult.Rows[nro_fil].Cells["va_des_pro"].Value.ToString();

                bt_edi_tar.Enabled = false;
                bt_eli_min.Enabled = false;

                bt_adi_pro.Text = "&GUARDAR";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nueva Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_eli_min_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res_msg = new DialogResult();
                if (dg_res_ult.Rows.Count <= 0)
                    return;

                int nro_fil = 0;
                nro_fil = dg_res_ult.CurrentCell.RowIndex;

                res_msg = MessageBox.Show("Esta seguro de eliminar el item: " + (nro_fil + 1) + " ?", "Elimina item", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);

                if (res_msg == DialogResult.OK)
                {
                    dg_res_ult.Rows.RemoveAt(nro_fil);

                    bt_edi_tar.Enabled = true;
                    bt_eli_min.Enabled = true;

                    Fi_lim_ite();

                    Fi_cal_tot();

                    // ELIMINA ITEM DE TEMPORAL

                    o_cmr006.fu_eli_tmp(Program.gl_ide_usr, ve_cod_tmp);

                    //******************************
                    // GRABA EN TABLA TEMPORAL
                    if (dg_res_ult.Columns.Count > 0)
                    {
                        DataTable tab_det_vta = new DataTable();
                        for (int i = 0; i <= dg_res_ult.Columns.Count - 1; i++)
                        {
                            tab_det_vta.Columns.Add(dg_res_ult.Columns[i].Name);
                        }
                        foreach (DataGridViewRow Row in dg_res_ult.Rows)
                        {
                            tab_det_vta.Rows.Add();
                            foreach (DataGridViewTextBoxColumn Cell in dg_res_ult.Columns)
                            {
                                tab_det_vta.Rows[Row.Index][Cell.Index] = Row.Cells[Cell.Index].Value;
                            }
                        }
                        if (tab_det_vta.Rows.Count != 0)
                            o_cmr006.fu_gra_tmp(Program.gl_ide_usr, ve_cod_tmp, tab_det_vta);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nueva Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bt_bus_plv_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_plv();
        }
        private void Tb_cod_plv_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Persona
                Fi_abr_bus_plv();
            }
        }
        void Fi_abr_bus_plv()
        {
            cmr004_01b frm = new cmr004_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                ve_sel_pvt = 1;    // Si selecciono plantilla al abrir la promera vez
                tb_cod_plv.Text = frm.tb_sel_bus.Text;
                lb_nom_plv.Text = frm.lb_des_bus.Text;
            }
            Fi_obt_plv();
        }
        private void Tb_cod_plv_Validated(object sender, EventArgs e)
        {
            Fi_obt_plv();
        }

        /// <summary>
        /// obtiene Plantilla de ventas y sus datos
        /// </summary>
        private void Fi_obt_plv()
        {

            if(cl_glo_bal.IsNumeric(tb_cod_plv.Text)== false)
            {
                MessageBox.Show("Debe proporcionar una plantilla valida", "Error", MessageBoxButtons.OK);
            }

            // Obtiene plantilla de venta
            tab_cmr004 = o_cmr004.Fe_con_plv(tb_cod_plv.Text);
            if (tab_cmr004.Rows.Count == 0)
            {
                lb_nom_plv.Text = "No Existe";
                ve_ban_plv = false;
            }
            else
            {
                // Pregunta por el estado de la plantilla
                if (tab_cmr004.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    MessageBox.Show("La Plantilla de venta se encuentra Deshabilitada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lb_nom_plv.Text = tab_cmr004.Rows[0]["va_nom_plv"].ToString();
                    ve_ban_plv = false;
                }
                else
                {
                    lb_nom_plv.Text = tab_cmr004.Rows[0]["va_nom_plv"].ToString();
                    ve_ban_plv = true;
                }

            }

            Fi_par_plv();
            // Coloca el cursor en el producto
            tb_des_pro.Focus();
        }

        /// <summary>
        /// Obtiene parametros de la plantilla
        /// </summary>
        private void Fi_par_plv()
        {
            if (ve_ban_plv == true)
            {
                // Habilita group box de parametros
                gb_par_ame.Enabled = true;

                // Obtiene Cliente
                tb_cod_per.Text = tab_cmr004.Rows[0]["va_cod_cli"].ToString();

                // Obtiene Persona
                tab_adp002 = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
                if (tab_adp002.Rows.Count == 0)
                    lb_raz_soc.Text = "** No Existe";
                else
                    lb_raz_soc.Text = tab_adp002.Rows[0]["va_raz_soc"].ToString();


                // Obtiene bodega
                tb_cod_bod.Text = tab_cmr004.Rows[0]["va_cod_bod"].ToString();
                // Obtiene nombre de bodega
                tab_inv002 = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));

                if (tab_inv002.Rows.Count > 0)
                    lb_nom_bod.Text = tab_inv002.Rows[0]["va_nom_bod"].ToString();

                // Verifica si permite cambiar bodega
                if (tab_cmr004.Rows[0]["va_cam_bod"].ToString() == "0") // No cambia
                {
                    tb_cod_bod.Enabled = false;
                    bt_bus_bod.Enabled = false;
                }
                if (tab_cmr004.Rows[0]["va_cam_bod"].ToString() == "1") // Si cambia
                {
                    tb_cod_bod.Enabled = true;
                    bt_bus_bod.Enabled = true;
                }

                // Obtiene Lista de precio
                tb_cod_lis.Text = tab_cmr004.Rows[0]["va_cod_lis"].ToString();
                // Obtiene nombre de lista
                tab_cmr001 = o_cmr001.Fe_con_lis(int.Parse(tb_cod_lis.Text));

                if (tab_cmr001.Rows.Count > 0)
                {
                    lb_nom_lis.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
                    ve_lis_dec = int.Parse(tab_cmr001.Rows[0]["va_nro_dec"].ToString());
                }

                // Verifica si permite cambiar Lista de precio
                if (tab_cmr004.Rows[0]["va_cam_lis"].ToString() == "0") // No cambia
                {
                    tb_cod_lis.Enabled = false;
                    bt_bus_lis.Enabled = false;
                }
                if (tab_cmr004.Rows[0]["va_cam_lis"].ToString() == "1") // Si cambia
                {
                    tb_cod_lis.Enabled = true;
                    bt_bus_lis.Enabled = true;
                }

                if (tab_cmr004.Rows[0]["va_cam_lis"].ToString() == "2") // Obtiene lista de precio asignada al cliente
                {
                    tb_cod_lis.Enabled = false;
                    bt_bus_lis.Enabled = false;

                    // Obtiene lista de precio del cliente

                }

                // Obtiene moneda
                if (tab_cmr004.Rows[0]["va_mon_vta"].ToString() == "B")
                {
                    cb_mon_vta.SelectedIndex = 0;
                    ve_mon_vta = "B";
                }
                if (tab_cmr004.Rows[0]["va_mon_vta"].ToString() == "U")
                {
                    cb_mon_vta.SelectedIndex = 1;
                    ve_mon_vta = "U";
                }

                // Verifica si puede cambiar la moneda
                if (tab_cmr004.Rows[0]["va_cam_mon"].ToString() == "0") // No Cambia
                    cb_mon_vta.Enabled = false;
                if (tab_cmr004.Rows[0]["va_cam_mon"].ToString() == "1") // Si Cambia
                    cb_mon_vta.Enabled = true;

                // Si la moneda del doc depende de la lista de precio - Obtiene moneda de la lista
                if (tab_cmr004.Rows[0]["va_cam_mon"].ToString() == "2") // Moneda Segun lista de precio
                {
                    if (tab_cmr001.Rows[0]["va_mon_lis"].ToString() == "B")
                    {
                        cb_mon_vta.SelectedIndex = 0;
                        ve_mon_vta = "B";
                    }
                    if (tab_cmr001.Rows[0]["va_mon_lis"].ToString() == "U")
                    {
                        cb_mon_vta.SelectedIndex = 1;
                        ve_mon_vta = "U";
                    }
                    cb_mon_vta.Enabled = false;
                }

                // Obtiene forma de pago
                cb_for_pag.SelectedIndex = int.Parse(tab_cmr004.Rows[0]["va_for_pgo"].ToString());

                // Verifica si puede cambiar forma de pago
                if (tab_cmr004.Rows[0]["va_cam_fpg"].ToString() == "0") // No Cambia
                    cb_for_pag.Enabled = false;
                if (tab_cmr004.Rows[0]["va_cam_fpg"].ToString() == "1") // Si Cambia
                    cb_for_pag.Enabled = true;


                // Obtiene Vendedor
                tb_cod_ven.Text = tab_cmr004.Rows[0]["va_cod_ven"].ToString();
                // Obtiene nombre de Vendedor
                tab_cmr014 = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text),1);

                if (tab_cmr001.Rows.Count > 0)
                    lb_nom_ven.Text = tab_cmr014.Rows[0]["va_nom_bre"].ToString();

                // Verifica si permite cambiar vendedor
                if (tab_cmr004.Rows[0]["va_cam_ven"].ToString() == "0") // No cambia
                {
                    tb_cod_ven.Enabled = false;
                    bt_bus_ven.Enabled = false;
                }
                if (tab_cmr004.Rows[0]["va_cam_ven"].ToString() == "1") // Si cambia
                {
                    tb_cod_ven.Enabled = true;
                    bt_bus_ven.Enabled = true;
                }
                if (tab_cmr004.Rows[0]["va_cam_ven"].ToString() == "2") // Asignado al cliente
                {
                    tb_cod_ven.Enabled = false;
                    bt_bus_ven.Enabled = false;

                    // Obtiene el vendedor asignado al cliente
                    Fi_ven_asi();

                }

                // Obtiene Delivery
                tab_cmr015 = o_cmr015.Fe_con_del(int.Parse(tab_cmr004.Rows[0]["va_cod_del"].ToString()));
                if (tab_cmr015.Rows.Count > 0)
                {
                    tb_cod_del.Text = tab_cmr004.Rows[0]["va_cod_del"].ToString();
                    lb_nom_del.Text = tab_cmr015.Rows[0]["va_nom_del"].ToString();
                }
                // Verifica si permite cambiar Delivery
                if (tab_cmr004.Rows[0]["va_cam_del"].ToString() == "0") // No cambia
                {
                    bt_bus_del.Enabled = false;
                }
                if (tab_cmr004.Rows[0]["va_cam_del"].ToString() == "1") // Si cambia
                {
                    bt_bus_del.Enabled = true;
                }

                // Obtiene documento y talonario de venta 
                ve_doc_vta = tab_cmr004.Rows[0]["va_doc_ntv"].ToString();
                ve_nro_tal = int.Parse(tab_cmr004.Rows[0]["va_tal_ntv"].ToString());
            }
            if (ve_ban_plv == false)
            {
                // Deshabilita group box de parametros
                gb_par_ame.Enabled = false;

                // Limpi los campos
                tb_cod_bod.Text = "0";
                lb_nom_bod.Text = "";

                tb_cod_lis.Text = "0";
                lb_nom_lis.Text = "";

                tb_cod_ven.Text = "0";
                lb_nom_ven.Text = "";
            }

            //Prepara autocompletado de codigo producto
            Fi_com_ple();

        }


        /// <summary>
        /// Obtiene vendedor asignado al cliente
        /// </summary>
        private void Fi_ven_asi()
        {
            int cod_ven = int.Parse(tab_adp002.Rows[0]["va_cod_ven"].ToString());

            tb_cod_ven.Text = cod_ven.ToString();
            Fi_obt_ven();
        }


        // BUSCAR BODEGA
        //private void Bt_bus_bod_Click(object sender, EventArgs e)
        //{
        //    Fi_abr_bus_bod();
        //}
        //private void Tb_cod_bod_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //al presionar tecla para ARRIBA
        //    if (e.KeyData == Keys.Up)
        //    {
        //        // Abre la ventana Busca Bodega
        //        Fi_abr_bus_bod();
        //    }
        //}
        //void Fi_abr_bus_bod()
        //{
        //    inv002_01 frm = new inv002_01();
        //    cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

        //    if (frm.DialogResult == DialogResult.OK)
        //    {
        //        tb_cod_bod.Text = frm.tb_sel_bus.Text;
        //        lb_nom_bod.Text = frm.lb_des_bus.Text;
        //    }
        //}
        //private void Tb_cod_bod_Validated(object sender, EventArgs e)
        //{
        //    Fi_obt_bod();
        //}
        //private void Fi_obt_bod()
        //{
        //    int val = 0;
        //    try
        //    {
        //        val = int.Parse(tb_cod_bod.Text);
        //    }
        //    catch (Exception)
        //    {
        //        lb_nom_bod.Text = "";
        //        return;
        //    }

        //    tabla = o_inv002.Fe_con_bod(val);
        //    if (tabla.Rows.Count == 0)
        //    {
        //        lb_nom_bod.Text = "";
        //    }
        //    else
        //    {
        //        lb_nom_bod.Text = tabla.Rows[0]["va_nom_bod"].ToString();
        //    }

        //}

        //******* LISTA DE PRECIO *******\\
        private void Bt_bus_lis_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_lis();
        }
        private void Tb_cod_lis_KeyDown(object sender, KeyEventArgs e)
        {

        }
        void Fi_abr_bus_lis()
        {
            // Obtiene Lista de precio anterior
            try
            {
                ve_lis_ant = int.Parse(tb_cod_lis.Text);
            }
            catch (Exception)
            {
                //lis_ant = 0;
            }

            cmr001_01b frm = new cmr001_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_lis.Text = frm.tb_sel_bus.Text;
                Fi_obt_lis();
            }
        }

        private void tb_cod_lis_Validating(object sender, CancelEventArgs e)
        {
            Fi_obt_lis();
        }
        private void tb_cod_lis_Enter(object sender, EventArgs e)
        {
            // Obtiene Lista de precio anterior
            try
            {
                ve_lis_ant = int.Parse(tb_cod_lis.Text);
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Obtiene ide y nombre de Lista de precio
        /// </summary>
        void Fi_obt_lis()
        {
            try
            {
                int val = 0;
                try
                {
                    val = int.Parse(tb_cod_lis.Text);
                }
                catch (Exception)
                {
                    if (dg_res_ult.Rows.Count != 0)
                    {
                        DialogResult res = MessageBox.Show("Lista de precio no valida, desean mantener la lista de precios anterior ? " +
                            "de lo contrario se borraran sus items", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tb_cod_lis.Text = ve_lis_ant.ToString();
                        }
                        else
                        {
                            lb_nom_lis.Text = "";
                            dg_res_ult.Rows.Clear();
                            o_cmr006.fu_eli_tmp(Program.gl_ide_usr, ve_cod_tmp);
                            Fi_cal_tot();
                            return;
                        }
                    }
                }




                if (ve_lis_ant == int.Parse(tb_cod_lis.Text))
                    return;

                // Obtiene ide y nombre Lista de precio
                tab_cmr001 = o_cmr001.Fe_con_lis(int.Parse(tb_cod_lis.Text));
                if (tab_cmr001.Rows.Count == 0) // si la la lista de precios NO existe
                {

                    if (dg_res_ult.Rows.Count != 0)
                    {
                        DialogResult res = MessageBox.Show("Lista de precio no valida, desean mantener la lista de precios anterior ? " +
                            "de lo contrario se borraran sus items", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            tb_cod_lis.Text = ve_lis_ant.ToString();
                        }
                        else
                        {
                            lb_nom_lis.Text = "";
                            dg_res_ult.Rows.Clear();
                            o_cmr006.fu_eli_tmp(Program.gl_ide_usr, ve_cod_tmp);
                            Fi_cal_tot();
                            return;
                        }
                    }
                }
                else // Si existe la lista de precios
                {
                    //Verifica que la fecha del documento esté dentro del rango de fechas de la lista de precios
                    ve_lis_fec_ini = DateTime.Parse(tab_cmr001.Rows[0]["va_fec_ini"].ToString());
                    ve_lis_fec_fin = DateTime.Parse(tab_cmr001.Rows[0]["va_fec_fin"].ToString());

                    if (tb_fec_vta.Value < ve_lis_fec_ini)
                    {
                        MessageBox.Show("La lista de precio aun no esta disponible para ser utilizada a la fecha", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_cod_lis.Text = ve_lis_ant.ToString();
                        return;
                    }
                    if (tb_fec_vta.Value > ve_lis_fec_fin)
                    {
                        MessageBox.Show("La lista de precio ya no esta disponible para ser utilizada a la fecha", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_cod_lis.Text = ve_lis_ant.ToString();
                        return;
                    }

                    if (dg_res_ult.Rows.Count != 0) // Si tiene datos en la grilla
                    {
                        DialogResult res = MessageBox.Show("Se recalcularán los precios, desea continuar ?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (res == DialogResult.Yes) // Acepta recalcular
                        {
                            tb_cod_lis.Text = tab_cmr001.Rows[0]["va_cod_lis"].ToString();
                            lb_nom_lis.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
                            ve_lis_dec = int.Parse(tab_cmr001.Rows[0]["va_nro_dec"].ToString());

                            // Recalcula precios
                            Fi_rec_alc();
                        }
                        else // Se niega a recalcular - vuelve a la lista de precios anteior
                        {
                            tb_cod_lis.Text = ve_lis_ant.ToString();
                        }

                    }
                    else // En caso que NO tenga datos en la grilla
                    {
                        tb_cod_lis.Text = tab_cmr001.Rows[0]["va_cod_lis"].ToString();
                        lb_nom_lis.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
                        ve_lis_dec = int.Parse(tab_cmr001.Rows[0]["va_nro_dec"].ToString());

                    }

                    // Si la moneda del doc depende de la lista de precio - Obtiene moneda de la lista
                    if (tab_cmr004.Rows[0]["va_cam_mon"].ToString() == "2") // Moneda Segun lista de precio
                    {
                        if (tab_cmr001.Rows[0]["va_mon_lis"].ToString() == "B")
                        {
                            cb_mon_vta.SelectedIndex = 0;
                            ve_mon_vta = "B";
                        }
                        if (tab_cmr001.Rows[0]["va_mon_lis"].ToString() == "U")
                        {
                            cb_mon_vta.SelectedIndex = 1;
                            ve_mon_vta = "U";
                        }
                    }


                    // formatea precio que tiene en la caja antes de adicionar 
                    decimal pre_uni = decimal.Parse(tb_pre_vta.Text);

                    // Expande decimales a 4 para poder redondear y formatear
                    //pre_uni = pre_uni + 0.0000m;

                    // Obtiene precio den decimales formateado 
                    if (ve_lis_dec == 0)
                    {
                        pre_uni = decimal.Round(pre_uni, 0);
                        pre_uni = decimal.Parse(string.Format("{00:N0}", pre_uni));
                    }
                    if (ve_lis_dec == 1)
                    {
                        pre_uni = decimal.Round(pre_uni, 1);
                        pre_uni = decimal.Parse(string.Format("{00:N1}", pre_uni));
                    }
                    if (ve_lis_dec == 2)
                    {
                        pre_uni = decimal.Round(pre_uni, 2);
                        pre_uni = decimal.Parse(string.Format("{00:N2}", pre_uni));
                    }
                    if (ve_lis_dec == 3)
                    {
                        pre_uni = decimal.Round(pre_uni, 3);
                        pre_uni = decimal.Parse(string.Format("{00:N3}", pre_uni));
                    }
                    if (ve_lis_dec == 4)
                    {
                        pre_uni = decimal.Round(pre_uni, 4);
                        pre_uni = decimal.Parse(string.Format("{00:N4}", pre_uni));
                    }
                    if (ve_lis_dec == 5)
                    {
                        pre_uni = decimal.Round(pre_uni, 5);
                        pre_uni = decimal.Parse(string.Format("{00:N5}", pre_uni));
                    }

                    tb_pre_vta.Text = pre_uni.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fi_rec_alc()
        {
            for (int i = 0; i < dg_res_ult.Rows.Count; i++)
            {
                ve_pre_uni = 0m;
                ve_pre_lis = 0m;

                //** Obtiene precio del producto
                tab_cmr002 = new DataTable();
                tab_cmr002 = o_cmr002.Fe_con_pre(int.Parse(tb_cod_lis.Text), dg_res_ult.Rows[i].Cells["va_cod_pro"].Value.ToString());
                if (tab_cmr002.Rows.Count > 0)
                {
                    ve_pre_uni = decimal.Parse(tab_cmr002.Rows[0]["va_pre_cio"].ToString());
                    ve_pre_lis = ve_pre_uni;
                    ve_pmx_des = decimal.Parse(tab_cmr002.Rows[0]["va_pmx_des"].ToString());
                    ve_pmx_inc = decimal.Parse(tab_cmr002.Rows[0]["va_pmx_inc"].ToString());
                }

                if (ve_pre_uni == 0)
                {
                    MessageBox.Show("El producto del item Nª (" + (i + 1) + ") no tiene precio definido en la lista de precio selecionada", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //** Actualiza el precio del producto
                dg_res_ult.Rows[i].Cells["va_pre_uni"].Value = ve_pre_uni;
                dg_res_ult.Rows[i].Cells["va_des_cue"].Value = 0;
                dg_res_ult.Rows[i].Cells["va_por_des"].Value = 0;
                //** Calcula Total item
                Fi_cal_bru(i);

                //** Actualiza el item en la tabla temporal (cmr006_temp)
                //******************************
                // ACTUALIZA EN TABLA TEMPORAL
                DataTable tab_det_vta = new DataTable();
                tab_det_vta.Rows.Add();
                for (int x = 0; x <= dg_res_ult.Columns.Count - 1; x++)
                {
                    tab_det_vta.Columns.Add(dg_res_ult.Columns[x].Name);
                    if (x == 0)
                        tab_det_vta.Rows[0][x] = i + 1;
                    else
                        tab_det_vta.Rows[0][x] = dg_res_ult.Rows[i].Cells[x].Value;
                }

                o_cmr006.fu_edi_tmp(Program.gl_ide_usr, ve_cod_tmp, tab_det_vta);

            }
        }



        //******* VENDEDOR *******\\
        private void Bt_bus_ven_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_ven();
        }
        private void Tb_cod_ven_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_ven();
            }
        }
        void Fi_abr_bus_ven()
        {
            cmr014_01 frm = new cmr014_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_ven.Text = frm.tb_sel_bus.Text;
                Fi_obt_ven();
            }
        }
        private void Tb_cod_ven_Validated(object sender, EventArgs e)
        {
            Fi_obt_ven();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_ven()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_ven.Text);
            }
            catch (Exception)
            {
                lb_nom_ven.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text),1);
            if (tabla.Rows.Count == 0)
            {
                lb_nom_ven.Text = "";
            }
            else
            {
                tb_cod_ven.Text = tabla.Rows[0]["va_cod_ide"].ToString();
                lb_nom_ven.Text = tabla.Rows[0]["va_nom_bre"].ToString();
            }
        }


        //******* DELIVERY *******\\
        private void Bt_bus_del_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_del();
        }
        private void Tb_cod_del_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca bodega
                Fi_abr_bus_del();
            }
        }
        void Fi_abr_bus_del()
        {
            //cmr015_01b frm = new cmr015_01b();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    tb_cod_del.Text = frm.tb_sel_bus.Text;
            //    Fi_obt_del();
            //}
        }
        private void Tb_cod_del_Validated(object sender, EventArgs e)
        {
            Fi_obt_del();
        }
        /// <summary>
        /// Obtiene ide y nombre bodega para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_del()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_del.Text);
            }
            catch (Exception)
            {
                lb_nom_del.Text = "";
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_cmr015.Fe_con_del(int.Parse(tb_cod_del.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_nom_del.Text = "";
            }
            else
            {
                tb_cod_del.Text = tabla.Rows[0]["va_cod_del"].ToString();
                lb_nom_del.Text = tabla.Rows[0]["va_nom_del"].ToString();
            }
        }

        private void cb_vta_par_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_vta_par.SelectedIndex == 0)
            {
                ve_vta_par = "M";
                gb_del_ive.Visible = false;
            }
            if (cb_vta_par.SelectedIndex == 1)
            {
                ve_vta_par = "L";
                gb_del_ive.Visible = false;
            }
            if (cb_vta_par.SelectedIndex == 2)
            {
                ve_vta_par = "D";
                gb_del_ive.Visible = true;
            }
        }

        private void tb_por_des_Validated(object sender, EventArgs e)
        {
            Fi_cal_por();
            Fi_cal_pre();
        }

        private void cb_mon_vta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cb_mon_vta.SelectedIndex == 1)
                ve_mon_vta = "B";
            if (cb_mon_vta.SelectedIndex == 2)
                ve_mon_vta = "U";

        }

        private void tb_cod_pro_TextChanged(object sender, EventArgs e)
        {
            Fi_obt_pro();
        }

        private void tb_des_pro_TextChanged(object sender, EventArgs e)
        {

            string[] aux_tex;

            if (tb_des_pro.Text == "")
                return;
            if (tab_cmr004.Rows.Count == 0)
                return;

            aux_tex = tb_des_pro.Text.Split('°');
            int bus_pro = int.Parse(tab_cmr004.Rows[0]["va_bus_pro"].ToString());

            if (aux_tex.Length > 1)
            {
                switch (bus_pro)
                {
                    case 1: // codigo
                        tb_cod_pro.Text = aux_tex[0];
                        tb_des_pro.Text = aux_tex[1];
                        break;
                    case 2: // nombre
                        tb_cod_pro.Text = aux_tex[1];
                        tb_des_pro.Text = aux_tex[0];
                        break;
                    case 3: // descripcion
                        tb_cod_pro.Text = aux_tex[1];
                        tb_des_pro.Text = aux_tex[0];
                        break;

                }
            }
        }

        private void tb_des_pro_DoubleClick(object sender, EventArgs e)
        {
            if (tb_cod_pro.Text.Trim() != "")
            {
                //Si la familia de producto es de servicio, permite editar la descripcion del producto
                if (tab_pro.Rows[0]["va_tip_fam"].ToString() == "S")
                {
                    cmr005_02c form = new cmr005_02c();
                    DataTable tab_pro = new DataTable();
                    tab_pro.Columns.Add("va_cod_pro");
                    tab_pro.Columns.Add("va_nom_pro");
                    tab_pro.Columns.Add("va_des_cri");

                    tab_pro.Rows.Add();
                    tab_pro.Rows[0]["va_cod_pro"] = tb_cod_pro.Text;
                    tab_pro.Rows[0]["va_nom_pro"] = tab_pro.Rows[0]["va_nom_pro"].ToString();
                    tab_pro.Rows[0]["va_des_cri"] = tb_des_pro.Text;

                    cl_glo_frm.abrir(this, form, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, tab_pro);

                    if (form.DialogResult == DialogResult.OK)
                    {
                        tb_des_pro.Text = form.tb_des_cri.Text;
                    }
                }
            }
        }

        private void m_not_vta_Click(object sender, EventArgs e)
        {
            tb_nom_ope.Text = "NOTA DE VENTA";
        }

        private void m_fac_tur_Click(object sender, EventArgs e)
        {
            tb_nom_ope.Text = "FACTURA";
        }

        private void mn_pro_for_Click(object sender, EventArgs e)
        {
            tb_nom_ope.Text = "PROFORMA";
        }

        private void mn_ped_ido_Click(object sender, EventArgs e)
        {
            tb_nom_ope.Text = "PEDIDO";
        }

        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
    }
}
