using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;
using CRS_PRE;

namespace CRS_PRE.INV
{
    public partial class inv007_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        inv007 o_inv007 = new inv007();
        inv002 o_inv002 = new inv002();
        inv004 o_inv004 = new inv004();

        ads004 o_ads004 = new ads004();
        ads007 o_ads007 = new ads007();
        ads016 o_ads016 = new ads016();
        adp002 o_adp002 = new adp002();
        ads022 o_ads022 = new ads022();     // Tipo de cambio
        cl_glo_frm o_mg_glo_frm = new cl_glo_frm();


        DataTable tabla = new DataTable();
        DataTable tab_prm = new DataTable();
        DataTable tab_pro = new DataTable();
        DataTable tab_cmp = new DataTable();

        DateTime va_cod_tmp = new DateTime();

        public inv007_02()
        {
            InitializeComponent();
        }

      
        private void frm_Load(object sender, EventArgs e)
        {
            // Obtiene fecha y hora actual para codigo de tabla temporal
            va_cod_tmp = o_mg_glo_frm.fg_fec_act();


            tb_cod_doc.Text = "CMP";
            tb_nro_tal.Text = "0";
            tb_cod_bod.Text = "0";
            tb_fec_cmp.Value = DateTime.Today;
            cb_mon_cmp.SelectedIndex = 0;
            cb_for_pag.SelectedIndex = 0;
            tb_nro_ite.Text = "1";

            tb_can_tid.Text = "0";
            tb_pre_cmp.Text = "0";
            tb_imp_tot.Text = "0";

            tb_tot_bru.Text = "0.00";
            tb_des_cue.Text = "0.00";
            tb_tot_net.Text = "0.00";


            tb_cod_per.Focus();



        }
        
        protected string Fi_val_dat()
        {
            string val_ret = "";

            // Vaida Talonario
            if (tb_nro_tal.Text.Trim() == "")
            {
                val_ret = "Debe proporcionar un Talonario valido";
                tb_nro_tal.Focus();
                return val_ret;
            }

            int val = 0;
            int.TryParse(tb_nro_tal.Text, out val);
            if (val == 0   )
            {
                try
                {
                    val = int.Parse(tb_nro_tal.Text);
                }
                catch (Exception )
                {
                    val_ret = "Debe proporcionar un Talonario valido";
                    tb_nro_tal.Focus();
                    return val_ret;
                }
            }

            tabla = o_ads004.Fe_con_tal(tb_cod_doc.Text,val);
            if (tabla.Rows.Count == 0)
            {
                val_ret = "Debe proporcionar un Talonario valido";
                tb_nro_tal.Focus();
                return val_ret;
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                val_ret = "El Talonario se encuentra Deshabilitado";
                tb_nro_tal.Focus();
                return val_ret;
            }



            // Valida Bodega
            if (tb_cod_bod.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar una bodega valida", "Error", MessageBoxButtons.OK);
                tb_cod_bod.Focus();
            }
            
            val = 0;
            int.TryParse(tb_cod_bod.Text, out val);
            if (val == 0)
            {
                try
                {
                    val = int.Parse(tb_cod_bod.Text);
                }
                catch (Exception)
                {
                    val_ret = "Debe proporcionar una bodega valida";
                    tb_cod_bod.Focus();
                    return val_ret;
                }
            }

            tabla = new DataTable();
            tabla = o_inv002.Fe_con_bod(val);
            if (tabla.Rows.Count == 0)
            {
                val_ret = "Debe proporcionar una bodega valida";
                tb_cod_bod.Focus();
                return val_ret;
            }
            if(tabla.Rows[0]["va_est_ado"].ToString()=="N")
            {
                val_ret = "La bodega se encuentra Deshabilitada";
                tb_cod_bod.Focus();
                return val_ret;
            }


            // Valida Persona
            if (tb_cod_per.Text.Trim() == "")
            {
                val_ret = "Debe proporcionar una persona valida";
                tb_cod_per.Focus();
                return val_ret;
            }

            val = 0;
            int.TryParse(tb_cod_per.Text, out val);
            if (val == 0)
            {
                val_ret = "Debe proporcionar una persona valida";
                tb_cod_per.Focus();
                return val_ret;
            }

            tabla = new DataTable();
            tabla = o_adp002.Fe_con_per(val);
            if (tabla.Rows.Count == 0)
            {
                val_ret = "Debe proporcionar una persona valida";
                tb_cod_per.Focus();
                return val_ret;
            }
            if (tabla.Rows[0]["va_est_ado"].ToString() == "N")
            {
                val_ret = "La persona se encuentra Deshabilitada";
                tb_cod_per.Focus();
                return val_ret;
            }

            // Valida que haya al menos un producto en la grilla
            if(dg_res_ult.Rows.Count==0)
            {
                val_ret = "Debe de registrar al menos un producto para la compra";
                tb_cod_pro.Focus();
                return val_ret;
            }

            return "";
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
            tb_pre_cmp.Text = "0.00";
            tb_imp_tot.Text = "0.00";
            tb_und_cmp.Text = "";
            lb_eqv_cmp.Text = "0";
            lb_fab_ric.Text = "";

            tb_obs_cmp.Text = "";
            tb_ref_cmp.Text = "";

            tb_cod_pro.Focus();
        }
        private void Fi_lim_gri()
        {
            dg_res_ult.Rows.Clear();

            tb_tot_bru.Text = "0.00";
            tb_des_cue.Text = "0.00";
            tb_tot_net.Text = "0.00";

            tb_nro_ite.Text = "1";
        }




        private void inv007_02_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Elimina temporal antes de cerrar la ventana
            o_inv007.fu_eli_tmp(Program.gl_ide_usr, va_cod_tmp);
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
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

                msg_res = MessageBox.Show("Esta seguro de registrar la Compra?", "Nueva Compra", MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {

                    // Obtiene Gestion
                    int ges_tio =  int.Parse(o_ads016.Fe_ges_fec(tb_fec_cmp.Text).Rows[0]["va_ges_tio"].ToString());
                    // GRABA COMPRA
                    tab_cmp = o_inv007.fu_gra_cmp(va_cod_tmp, tb_cod_doc.Text, int.Parse(tb_nro_tal.Text),
                                         ges_tio, int.Parse(tb_cod_bod.Text), tb_cod_per.Text,
                                         "B", tb_fec_cmp.Value, cb_for_pag.SelectedIndex, 0, 0,
                                         0, 0, 0, decimal.Parse(tb_tip_cam.Text),
                                         decimal.Parse(tb_des_cue.Text), tb_obs_cmp.Text, tb_ref_cmp.Text, Program.gl_ide_usr);


                    // Crea tabla para pasar datos
                    DataTable tab_dat = new DataTable();
                    tab_dat.Columns.Add("va_ide_doc");
                    tab_dat.Columns.Add("va_cod_doc");
                    tab_dat.Columns.Add("va_ges_doc");
                    tab_dat.Columns.Add("va_nro_tal");
                    tab_dat.Columns.Add("va_ope_rac");
                    tab_dat.Columns.Add("va_nro_fac");
                    tab_dat.Columns.Add("va_cod_plv");

                    tab_dat.Rows.Add();
                    tab_dat.Rows[0]["va_ide_doc"] = tab_cmp.Rows[0]["va_ide_cmp"].ToString();

                    tab_dat.Rows[0]["va_cod_doc"] = tab_cmp.Rows[0]["va_doc_doc"].ToString();
                    tab_dat.Rows[0]["va_ges_doc"] = tab_cmp.Rows[0]["va_ges_cmp"].ToString();
                    tab_dat.Rows[0]["va_nro_tal"] = tab_cmp.Rows[0]["va_nro_tal"].ToString();
                    tab_dat.Rows[0]["va_ope_rac"] = "COMPRA";
                    
                    //** No se usa pero requiere que se envie
                    tab_dat.Rows[0]["va_nro_fac"] = "0";                    
                    tab_dat.Rows[0]["va_cod_plv"] = 0;

                    //** Limpiar formulario de venta
                    Fi_lim_ite();
                    Fi_lim_gri();

                    //** Envia a imprimir documento
                    cmr000_01 frm = new cmr000_01();
                    cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, tab_dat);


                }

            }
            catch (Exception Ex)
            {
                  MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
                tb_fec_alm.Text = frm.fec_ctr.ToString("d");
            }
        }
        private void Tb_cod_bod_Validated(object sender, EventArgs e)
        {
            Fi_obt_bod();
        }
        private void Fi_obt_bod()
        {
          
            int val = 0;

            try
            {
                val = int.Parse(tb_cod_bod.Text);
            }
            catch (Exception)
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


        //** BUSCAR TALONARIO
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

            tab_prm.Rows[0]["va_ide_doc"] = tb_cod_doc.Text;
            tab_prm.Rows[0]["va_nom_doc"] = "Compra";

            ads004_01b frm = new ads004_01b();
            frm.vp_ide_doc = tb_cod_doc.Text;
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, tab_prm);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_nro_tal.Text = frm.vp_nro_tal;
                Fi_obt_tal();
            }
        }
        private void Tb_nro_tal_Validated(object sender, EventArgs e)
        {
            Fi_obt_tal();
        }

        /// <summary>
        /// Obtiene ide y nombre documento para colocar en los campos del formulario
        /// </summary>
        void Fi_obt_tal()
        {
            // Valida que  nro_tal sea numerico
            int val = 0;
            try
            {
                val = int.Parse(tb_nro_tal.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El numero de talonario no es correcto, verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtiene ide y nombre documento
            tabla = o_ads004.Fe_con_tal(tb_cod_doc.Text, int.Parse(tb_nro_tal.Text));
            if (tabla.Rows.Count == 0)
            {
               lb_nom_tal.Text ="";
            }
            else
            {
                tb_nro_tal.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                lb_nom_tal.Text = tabla.Rows[0]["va_nom_tal"].ToString();
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
                lb_raz_soc.Text = frm.lb_raz_soc.Text;
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
            int.TryParse(tb_cod_per.Text, out val);
            if (val == 0)
            {
                //MessageBox.Show("Debe proporcionar un codigo de proveedor valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
                lb_raz_soc.Text = "No Existe";
            }
            tabla = o_adp002.Fe_con_per(val);
            if (tabla.Rows.Count == 0)
            {
                lb_raz_soc.Text = "No Existe";
            }
            else
            {
                lb_raz_soc.Text = tabla.Rows[0]["va_raz_soc"].ToString();
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
            inv004_01 frm = new inv004_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                tb_cod_pro.Text = frm.tb_sel_ecc.Text;
                Fi_obt_pro();
            }
        }
        private void Tb_cod_pro_Validated(object sender, EventArgs e)
        {
            Fi_obt_pro();
        }
        private void Fi_obt_pro()
        {
            if (tb_cod_pro.Text.Trim() == "")
            {
                //MessageBox.Show("El producto no se encuentra registrado", "Error", MessageBoxButtons.OK);
                tb_des_pro.Text = "";
                tb_und_cmp.Text = "";
                lb_eqv_cmp.Text = "0";
                lb_fab_ric.Text = "";

                return;
            }
            
            tab_pro= o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tab_pro.Rows.Count == 0)
            {
                MessageBox.Show("El producto no se encuentra registrado", "Error", MessageBoxButtons.OK);
                tb_des_pro.Text = "";
                tb_und_cmp.Text ="";
                lb_eqv_cmp.Text = "0";
                lb_fab_ric.Text = "";

                tb_des_pro.ReadOnly = false;
            }
            else
            {
                tb_des_pro.Text = tab_pro.Rows[0]["va_nom_pro"].ToString();
                tb_und_cmp.Text = tab_pro.Rows[0]["va_und_cmp"].ToString();

                lb_eqv_cmp.Text = decimal.Round(decimal.Parse(tab_pro.Rows[0]["va_eqv_cmp"].ToString()),
                                                int.Parse(tab_pro.Rows[0]["va_nro_dec"].ToString())).ToString();

                lb_eqv_cmp.Text = lb_eqv_cmp.Text + " " + tab_pro.Rows[0]["va_cod_umd"].ToString();

                lb_fab_ric.Text = tab_pro.Rows[0]["va_fab_ric"].ToString();

                // Si la familia de producto es de servicio, permite editar la descripcion del producto
                if(tab_pro.Rows[0]["va_tip_fam"].ToString()=="S")
                    tb_des_pro.ReadOnly = false;
                if (tab_pro.Rows[0]["va_tip_fam"].ToString() == "D")
                    tb_des_pro.ReadOnly = true;


            }
        }
        /// <summary>
        /// Opcion de calculo 1=Calcula desde el precio unitario ; 2=Calcula desde el importe Total
        /// </summary>
        /// <param name="opc_cal"></param>
        private void Fi_cal_pre(int opc_cal)
        {
            // Calcula precio total de la compra
            decimal can_tid = 0m;
            decimal pre_cmp = 0m;
            decimal imp_tot = 0m;

            

            can_tid = decimal.Parse(tb_can_tid.Text);
            pre_cmp = decimal.Parse(tb_pre_cmp.Text);
            imp_tot= decimal.Parse(tb_imp_tot.Text);

            if(opc_cal ==1)
            {
                imp_tot = can_tid * pre_cmp;
                tb_imp_tot.Text = imp_tot.ToString();

                tb_imp_tot.Text = decimal.Round(decimal.Parse(tb_imp_tot.Text), 2).ToString();
                tb_imp_tot.Text = decimal.Parse(tb_imp_tot.Text).ToString("N2");

            }
            if(opc_cal==2)
            {
                if (decimal.Parse(tb_can_tid.Text) != 0m)
                {
                    pre_cmp = imp_tot / can_tid;
                    tb_pre_cmp.Text = pre_cmp.ToString();

                    tb_pre_cmp.Text = decimal.Round(decimal.Parse(tb_pre_cmp.Text), 4).ToString();
                    tb_pre_cmp.Text = decimal.Parse(tb_pre_cmp.Text).ToString("N4");
                }
            }
            
            

        }

        private void tb_tip_cam_Validated(object sender, EventArgs e)
         {
            // Valida que el dato proporcionado sea decimal

            decimal val = 0m;
            decimal.TryParse(tb_tip_cam.Text, out val);

            if (val == 0m)
            {
                if (tb_tip_cam.Text != "0")
                {
                    MessageBox.Show("Debe proporcionar el tipo de cambio Bs/Us", "Error", MessageBoxButtons.OK);
                   // tb_tip_cam.SelectAll();
                   // tb_tip_cam.Focus();
                    return;
                }
            }
            else
            {
                tb_tip_cam.Text = decimal.Parse(tb_tip_cam.Text).ToString("N2");
              
            }
        }



        private void tb_can_tid_Validated(object sender, EventArgs e)
        {
            // Valida que el dato proporcionado sea decimal
            
            decimal val = 0m;
            decimal.TryParse(tb_can_tid.Text,out val);
            int nro_dec = 0;

            if(val == 0m)
            {
                if (tb_can_tid.Text != "0")
                {
                    MessageBox.Show("Debe proporcionar la cantidad", "Error", MessageBoxButtons.OK);
                    tb_can_tid.SelectAll();
                    tb_can_tid.Focus();
                    return;
                }
            }else
            {
                // Formatea decimales y manda a calcular
                if (tab_pro.Rows.Count != 0)
                {
                    nro_dec = int.Parse(tab_pro.Rows[0]["va_nro_dec"].ToString());
                    tb_can_tid.Text = decimal.Round(decimal.Parse(tb_can_tid.Text), nro_dec).ToString();

                    switch (nro_dec)
                    {
                        case 0 :
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

                Fi_cal_pre(1);
            }
        }

        private void tb_pre_cmp_Validated(object sender, EventArgs e)
        {
            // Valida que el dato proporcionado sea decimal

            decimal val = 0m;
            decimal.TryParse(tb_pre_cmp.Text, out val);

            if (val == 0m)
            {
                if (decimal.Parse(tb_pre_cmp.Text) != 0m)
                {
                    MessageBox.Show("Debe proporcionar el precio de compra", "Error", MessageBoxButtons.OK);
                    tb_pre_cmp.Focus();
                }
            }
            else
            {
                // Formatea decimales y manda a calcular
                tb_pre_cmp.Text = decimal.Round(decimal.Parse(tb_pre_cmp.Text), 4).ToString();
                tb_pre_cmp.Text = decimal.Parse(tb_pre_cmp.Text).ToString("N4");
                Fi_cal_pre(1);
            }
        }

        private void tb_imp_tot_Validated(object sender, EventArgs e)
        {
            // Valida que el dato proporcionado sea decimal

            decimal val = 0m;
            decimal.TryParse(tb_imp_tot.Text, out val);

            if (val == 0m)
            {
                if (tb_imp_tot.Text != "0" && tb_imp_tot.Text != "0.0" && tb_imp_tot.Text != "0.00")
                {
                    MessageBox.Show("Debe proporcionar el importe total", "Error", MessageBoxButtons.OK);
                    tb_imp_tot.Focus();
                }
            }
            else
            {
                // Formatea decimales y manda a calcular
                tb_imp_tot.Text = decimal.Round(decimal.Parse(tb_imp_tot.Text), 2).ToString();
                tb_imp_tot.Text = decimal.Parse(tb_imp_tot.Text).ToString("N2");
                Fi_cal_pre(2);
            }
        }

        private void tb_fec_cmp_Validated(object sender, EventArgs e)
        {
            // Trae el tipo de cambio Bs/Us para la fecha
            tabla = o_ads022.Fe_con_tic(tb_fec_cmp.Text);

            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)              
                    tb_tip_cam.Text = decimal.Parse(tabla.Rows[0][1].ToString()).ToString("N2");                                    
                else
                    tb_tip_cam.Text = "0.00";
            }
            else
                tb_tip_cam.Text = "0.00";


        }

        private void tb_tip_cam_Enter(object sender, EventArgs e)
        {
            tb_tip_cam.SelectAll();
        }
        private void tb_can_tid_Enter(object sender, EventArgs e)
        {
            tb_can_tid.SelectAll();
        }


        private void tb_pre_cmp_Enter(object sender, EventArgs e)
        {
            tb_pre_cmp.SelectAll();
            
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
                tb_cod_pro.Focus();
                return 0;
            }

            tabla = o_inv004.Fe_con_pro(tb_cod_pro.Text);
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("El producto no se encuentra registrado", "Error", MessageBoxButtons.OK);
                tb_cod_pro.Focus();
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
            decimal.TryParse(tb_pre_cmp.Text, out val);
            if (val == 0m)
            {
                MessageBox.Show("Debe proporcionar el precio", "Error", MessageBoxButtons.OK);
                tb_can_tid.Focus();
                return 0;
            }

            // Verifica importe total
            val = 0m;
            decimal.TryParse(tb_imp_tot.Text, out val);
            if (val == 0m)
            {
                MessageBox.Show("Debe proporcionar el importe total", "Error", MessageBoxButtons.OK);
                tb_can_tid.Focus();
                return 0;
            }

            return 1;
        }


        private void Fi_cal_tot()
        {
            tb_tot_bru.Text = "0";
            int item = 0;
            for (item = 0; item <= dg_res_ult.RowCount - 1; item++)
            {
                tb_tot_bru.Text = (decimal.Parse(tb_tot_bru.Text) + decimal.Parse(dg_res_ult["va_imp_tot", item].Value.ToString())).ToString();
                // Redefine nro de item
                dg_res_ult.Rows[item].Cells["va_nro_ite"].Value = item + 1;
            }

            tb_tot_net.Text = (decimal.Parse(tb_tot_bru.Text) - decimal.Parse(tb_des_cue.Text)).ToString();

            tb_tot_bru.Text = decimal.Round(decimal.Parse(tb_tot_bru.Text), 2).ToString(); // <--- Redondea decimales
            tb_tot_net.Text = decimal.Round(decimal.Parse(tb_tot_net.Text), 2).ToString(); // <--- Redondea decimales
        }
        //** ADICIONA ITEM
        private void bt_adi_pro_Click(object sender, EventArgs e)
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
            dg_res_ult["va_und_cmp", fila].Value = tb_und_cmp.Text;
            dg_res_ult["va_can_cmp", fila].Value = decimal.Parse(tb_can_tid.Text);
            dg_res_ult["va_pre_cmp", fila].Value = decimal.Parse(tb_pre_cmp.Text);
            dg_res_ult["va_imp_tot", fila].Value = decimal.Parse(tb_imp_tot.Text);
            dg_res_ult["va_tip_fam", fila].Value = tab_pro.Rows[0]["va_tip_fam"].ToString();


            //******************************
            // GRABA EN TABLA TEMPORAL

            //Obtiene columnas encabezado
            DataTable tab_det_cmp = new DataTable();
            for (int i = 0; i <= dg_res_ult.Columns.Count - 1; i++)
            {
                tab_det_cmp.Columns.Add(dg_res_ult.Columns[i].Name);
            }

            //Obtiene ultimo item
            foreach (DataGridViewRow Row in dg_res_ult.Rows)
            {
                if (Row.Index == fila) // siempre obtiene la fila activa
                {
                    tab_det_cmp.Rows.Add();
                    foreach (DataGridViewTextBoxColumn Cell in dg_res_ult.Columns)
                    {
                        tab_det_cmp.Rows[0][Cell.Index] = Row.Cells[Cell.Index].Value;
                    }
                }
            }


            if (bt_adi_pro.Text == "&AGREGAR") //Graba temporal
                o_inv007.fu_gra_tmp(Program.gl_ide_usr, va_cod_tmp, tab_det_cmp);
            if (bt_adi_pro.Text == "&GUARDAR")//Edita temporal
            {
                o_inv007.fu_edi_tmp(Program.gl_ide_usr, va_cod_tmp, tab_det_cmp);
                
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

        private void bt_lim_pia_Click(object sender, EventArgs e)
        {
            Fi_lim_ite();

            bt_adi_pro.Text = "&AGREAR";
            bt_edi_tar.Enabled = true;
            bt_eli_min.Enabled = true;
        }

        private void tb_des_cue_Validated(object sender, EventArgs e)
        {
            // Verifica que el dato proporcionado sea numerico
            decimal val = 0m;
            if(tb_des_cue.Text != "0" && tb_des_cue.Text !="0.00")
            {
                decimal.TryParse(tb_des_cue.Text, out val);
                if (val == 0m)
                {
                    MessageBox.Show("Debe proporcionar un descuento valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tb_des_cue.Focus();
                }
                else {
                    //Formatea a 2 decimales el descuento
                    tb_des_cue.Text = decimal.Round(decimal.Parse(tb_des_cue.Text), 2).ToString();
                    tb_des_cue.Text = decimal.Parse(tb_des_cue.Text).ToString("N2");

                    Fi_cal_tot();
                }
            }
            else
            {
                Fi_cal_tot();
            }
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
                tb_des_pro.Text = dg_res_ult.Rows[nro_fil].Cells["va_des_pro"].Value.ToString();
                tb_can_tid.Text = dg_res_ult.Rows[nro_fil].Cells["va_can_cmp"].Value.ToString();
                tb_pre_cmp.Text = dg_res_ult.Rows[nro_fil].Cells["va_pre_cmp"].Value.ToString();
                tb_imp_tot.Text = dg_res_ult.Rows[nro_fil].Cells["va_imp_tot"].Value.ToString();

                bt_edi_tar.Enabled = false;
                bt_eli_min.Enabled = false;

                bt_adi_pro.Text = "&GUARDAR";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nueva Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    //fu_lim_dg();

                    Fi_cal_tot();

                    // ELIMINA ITEM DE TEMPORAL

                    o_inv007.fu_eli_tmp(Program.gl_ide_usr, va_cod_tmp);

                    //******************************
                    // GRABA EN TABLA TEMPORAL
                    if (dg_res_ult.Columns.Count > 0)
                    {
                        DataTable tab_det_cmp = new DataTable();
                        for (int i = 0; i <= dg_res_ult.Columns.Count - 1; i++)
                        {
                            tab_det_cmp.Columns.Add(dg_res_ult.Columns[i].Name);
                        }
                        foreach (DataGridViewRow Row in dg_res_ult.Rows)
                        {
                            tab_det_cmp.Rows.Add();
                            foreach (DataGridViewTextBoxColumn Cell in dg_res_ult.Columns)
                            {
                                tab_det_cmp.Rows[Row.Index][Cell.Index] = Row.Cells[Cell.Index].Value;
                            }
                        }
                        o_inv007.fu_gra_tmp(Program.gl_ide_usr, va_cod_tmp, tab_det_cmp);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nueva Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
