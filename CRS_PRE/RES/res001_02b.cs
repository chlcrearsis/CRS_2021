using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE.INV;

namespace CRS_PRE.CMR
{
    public partial class res001_02b : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        ads003 o_ads003 = new ads003();
        ads004 o_ads004 = new ads004();
        ads008 o_ads008 = new ads008();
        inv002 o_inv002 = new inv002();
        inv003 o_inv003 = new inv003();
        inv004 o_inv004 = new inv004();
        cmr001 o_cmr001 = new cmr001();
        cmr002 o_cmr002 = new cmr002();
        ctb007 o_ctb007 = new ctb007();
        res001 o_res001 = new res001();
        res002 o_res002 = new res002();
        c_res004 o_res004 = new c_res004();
        cmr013 o_cmr013 = new cmr013();
        cmr014 o_cmr014 = new cmr014();
        cmr015 o_cmr015 = new cmr015();
        adp002 o_adp002 = new adp002();


        cl_glo_frm o_mg_glo_frm = new cl_glo_frm();


        DataTable tabla = new DataTable();
        DataTable tab_ads004 = new DataTable();
        DataTable tab_ads008 = new DataTable();
        DataTable tab_inv002 = new DataTable();
        DataTable tab_inv004 = new DataTable();
        DataTable tab_cmr001 = new DataTable();
        DataTable tab_cmr002 = new DataTable();
        DataTable tab_ctb007 = new DataTable();
        DataTable tab_res004 = new DataTable();
        DataTable tab_cmr013 = new DataTable();
        DataTable tab_cmr014 = new DataTable();
        DataTable tab_cmr015 = new DataTable();
        DataTable tab_adp002 = new DataTable();
        DataTable tb_res001 = new DataTable();

        //** Variable Venta para (M=Mesa ; L=Llevar ; D=Delivery)
        string vta_par = "M";
        int tip_ope = 0;    // 1 = Factura ; 2 = Nota de venta ; 3 = Nota de consumo

        //** Variable para parametros plantilla de venta
        bool ban_plv = false;
        int lis_ant = 0;        // Guarda lista de precio anterior
        int sel_pvt = 0;        // 0 = No selecciono plantilla al abrir ; 1 = Si selecciono plantilla al abrir
        DateTime va_cod_tmp = new DateTime();


        // VARIABLES DE LA VENTA
        string doc_ope ="";
        int tal_ope = 0;
        int tip_tal = 0;
        int cod_per = 0;
        public int nit_per = 0;
        public string raz_soc = "";
        public decimal pre_tot = 0m;
        public decimal mto_can = 0m;
        public decimal cam_bio = 0m;
        public string obs_ope = "";

        int cod_caj = 0;
        int cod_lcr = 0;
        decimal tip_cam = 0m;
        string mon_ope = "";

        // VARIABLES DE LA DOSIFICACION
        
        int va_nro_aut = 0;
        int va_nro_fac = 0;
        string va_lla_ve = "";
        string va_cod_ctr = "";


        public int va_for_pag = 0; // 1 = contado ; 2 = credito

        public res001_02b()
        {
            InitializeComponent();
        }


        private void frm_Load(object sender, EventArgs e)
        {
            //tb_pre_tot.Text = string.Format("{00:N2}", 0);
            pre_tot = decimal.Parse(string.Format("{00:N2}", 0));

            tb_fec_vta.Value = DateTime.Today;
            tb_cod_per.Focus();

            //** Cargar vector de colores
            Color[] col_lin = new Color[15];
            col_lin[0] = Color.Green; // 
            col_lin[1] = Color.FromArgb(128, 128, 255);
            col_lin[2] = Color.FromArgb(128, 64, 0);
            col_lin[3] = Color.Olive;
            col_lin[4] = Color.Gray;
            col_lin[5] = Color.Teal;
            col_lin[6] = Color.Purple;
            col_lin[7] = Color.Green; // 
            col_lin[8] = Color.FromArgb(128, 128, 255);
            col_lin[9] = Color.FromArgb(128, 64, 0);
            col_lin[10] = Color.Olive;
            col_lin[11] = Color.Gray;
            col_lin[12] = Color.Teal;
            col_lin[13] = Color.Purple;

            //** Color de botones(Mesa, Llevar, Delivery)
            bt_par_mes.BackColor = Color.FromArgb(32, 43, 76);
            bt_par_lle.BackColor = Color.Gray;
            bt_par_del.BackColor = Color.Gray;

            lb_cod_del.Text = "0";
            lb_nom_del.Text = "";

            //** Cargar las Familias de producto de Restaurant en los Botones
            tabla = o_inv003.Fe_bus_car_2("", 1, "H");
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    Button bt_lin_pro = new Button();
                    bt_lin_pro.Name = tabla.Rows[i]["va_cod_fam"].ToString();
                    bt_lin_pro.Text = tabla.Rows[i]["va_nom_fam"].ToString();
                    bt_lin_pro.Width = 126;
                    bt_lin_pro.Height = 49;
                    bt_lin_pro.Click += new EventHandler(Fi_sel_lin_CLick);
                    bt_lin_pro.BackColor = col_lin[i];
                    bt_lin_pro.ForeColor = Color.White;
                    bt_lin_pro.Font = new System.Drawing.Font(bt_lin_pro.Font, FontStyle.Bold);

                    fp_lin_pro.Controls.Add(bt_lin_pro);
                }
            }

            // Obtiene fecha y hora actual para codigo de tabla temporal
            va_cod_tmp = o_mg_glo_frm.fg_fec_act();

            // Abre buscar plantilla de venta Restaurant
            Fi_abr_bus_plv();
            if (sel_pvt == 0)
            {
                cl_glo_frm.Cerrar(this);
                return;
            }

            // Inicializa operacion
            tb_tip_ope.Text = "NOTA DE VENTA";
            tip_ope = 2;

            // Inicializa forma de pago
            va_for_pag = 1;
        }

        private void Fi_sel_lin_CLick(object sender, EventArgs e)
        {
            Button bt_lin_pro = (Button)sender;

            tb_nom_lin.Text = "(" + bt_lin_pro.Name + ") - " + bt_lin_pro.Text;

            //** Obtiene productos de la linea
            fp_pro_duc.Controls.Clear();
            tab_inv004 = o_inv004.Fe_con_pro_fam(bt_lin_pro.Name);
            if (tab_inv004.Rows.Count > 0)
            {
                for (int i = 0; i < tab_inv004.Rows.Count; i++)
                {
                    Button bt_pro_duc = new Button();
                    bt_pro_duc.Name = tab_inv004.Rows[i]["va_cod_pro"].ToString();
                    bt_pro_duc.Text = tab_inv004.Rows[i]["va_nom_pro"].ToString();
                    bt_pro_duc.Width = 108;
                    bt_pro_duc.Height = 97;
                    bt_pro_duc.Click += new EventHandler(Fi_sel_pro_CLick);
                    bt_pro_duc.ForeColor = Color.Black;
                    bt_pro_duc.Font = new System.Drawing.Font(bt_pro_duc.Font, FontStyle.Bold);

                    fp_pro_duc.Controls.Add(bt_pro_duc);
                }
            }
        }

        private void Fi_sel_pro_CLick(object sender, EventArgs e)
        {
            try
            { 
                Button bt_pro_sel = (Button)sender;
                int nro_itm = 0;
                int can_uni = 1;
                decimal pre_uni = 0;

                // Verifica que el usuario tenga permiso sobre la lista de precios
                if (o_ads008.Fe_ads008_02(Program.gl_usr_usr, "cmr001", tb_cod_lis.Text)== false)
                {
                    MessageBox.Show("La lista de precio no esta permitida para el usuario", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                //** Obtiene precio del producto
                tab_cmr002 = o_cmr002.Fe_con_pre(int.Parse(tb_cod_lis.Text), bt_pro_sel.Name);
                if (tab_cmr002.Rows.Count > 0)
                {
                    pre_uni = decimal.Parse(tab_cmr002.Rows[0]["va_pre_cio"].ToString());
                }

                if (pre_uni == 0)
                {
                    MessageBox.Show("El producto no tiene precio", "Venta", MessageBoxButtons.OK);
                    return;
                }

                //** Adicionar el producto seleccionado a la grilla
                dg_det_pro.Rows.Add();
                nro_itm = dg_det_pro.Rows.Count-1;
                dg_det_pro.Rows[nro_itm].Cells["va_nro_itm"].Value = nro_itm + 1;
                dg_det_pro.Rows[nro_itm ].Cells["va_cod_pro"].Value = bt_pro_sel.Name;
                dg_det_pro.Rows[nro_itm ].Cells["va_nom_pro"].Value = bt_pro_sel.Text;
                dg_det_pro.Rows[nro_itm ].Cells["va_can_uni"].Value = can_uni;

                dg_det_pro.Rows[nro_itm ].Cells["va_pre_uni"].Value = pre_uni;

                //** Calcula Total item
                Fi_cal_bru(nro_itm);

                //** Graba el item en la tabla temporal (res002_temp)
                //******************************
                // GRABA EN TABLA TEMPORAL
                DataTable tab_det_vta = new DataTable();
                tab_det_vta.Rows.Add();
                for (int i = 0; i <= dg_det_pro.Columns.Count - 1; i++)
                {
                    tab_det_vta.Columns.Add(dg_det_pro.Columns[i].Name);
                    if (i == 0)
                        tab_det_vta.Rows[0][i] = nro_itm + 1;
                    else
                        tab_det_vta.Rows[0][i] = dg_det_pro.Rows[nro_itm].Cells[i].Value;
                }

                    o_res002.fu_gra_tmp(Program.gl_usr_usr, va_cod_tmp, tab_det_vta, "UND", can_uni, pre_uni, (pre_uni * can_uni), pre_uni, 0, 0);
           

                //** Seleccionar la ultima fila de la grilla
                dg_det_pro.Rows[nro_itm ].Selected = true;
                dg_det_pro.FirstDisplayedScrollingRowIndex = (nro_itm );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

    }

        /// <summary>
        /// Calcula el total bruto de un Item y Calcula total general
        /// </summary>
        /// <param name="nro_itm"> Nro item a calcular el bruto</param>
        void Fi_cal_bru( int nro_itm)
        {
            int can_uni = 0;
            decimal pre_uni = 0;
            decimal pre_bru = 0;

            can_uni = int.Parse(dg_det_pro.Rows[nro_itm ].Cells["va_can_uni"].Value.ToString());
            pre_uni = decimal.Parse(dg_det_pro.Rows[nro_itm ].Cells["va_pre_uni"].Value.ToString());
            pre_bru = pre_uni * can_uni;

            dg_det_pro.Rows[nro_itm ].Cells["va_tot_bru"].Value = pre_bru;

            Fi_cal_tot();
        }

        void Fi_cal_tot()
        {
            decimal pre_cal = 0;
            for (int i = 0; i < dg_det_pro.Rows.Count; i++)
            {
                decimal tot_bru = 0;
               
                tot_bru = decimal.Parse(dg_det_pro.Rows[i].Cells["va_tot_bru"].Value.ToString());

                pre_cal = pre_cal + tot_bru;

            }

            //tb_pre_tot.Text = string.Format("{0:N2}", pre_tot);
            pre_tot = decimal.Parse( string.Format("{0:N2}", pre_cal));
        }


        protected string Fi_val_dat()
        {
            // VERIFICA PLANTILLA DE VENTA *****************
            if(cl_glo_bal.IsNumeric(tb_cod_plv.Text) == false)
            {
                tb_cod_plv.Focus();
                return "Debe proporcionar una plantilla de venta valida";
            }

            tab_res004 = o_res004.Fe_con_plv(tb_cod_plv.Text);
            if(tab_res004.Rows.Count == 0)
            {
                tb_cod_plv.Focus();
                return "La plantilla no se encuentra registrada";
            }
            if (tab_res004.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_plv.Focus();
                return "La plantilla se encuentra Deshabilitada";
            }

            // VERIFICA BODEGA *************************           
            if (cl_glo_bal.IsNumeric(tb_cod_bod.Text) == false)
            {
                tb_cod_bod.Focus();
                return "Debe proporcionar una Bodega valida";
            }

            tab_inv002 = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
            if (tab_inv002.Rows.Count == 0)
            {
                tb_cod_bod.Focus();
                return "La Bodega no se encuentra registrada";
            }
            if (tab_inv002.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_bod.Focus();
                return "La Bodega se encuentra Deshabilitada";
            }

            // VERIFICA LISTA DE PRECIO *******************        
            if (cl_glo_bal.IsNumeric(tb_cod_lis.Text) == false)
            {
                tb_cod_lis.Focus();
                return "Debe proporcionar una Lista de precio valida";
            }

            tab_cmr001 = o_cmr001.Fe_con_lis(int.Parse(tb_cod_lis.Text));
            if (tab_cmr001.Rows.Count == 0)
            {
                tb_cod_lis.Focus();
                return "La Lista de precio no se encuentra registrada";
            }

            // verifica permiso de usuario sobre lista de precio
            if(o_ads008.Fe_ads008_02(Program.gl_usr_usr,"cmr001",tb_cod_lis.Text) == false)
            {
                tb_cod_lis.Focus();
                return "La Lista de precio no se encuentra registrada";
            }

            if (tab_cmr001.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_lis.Focus();
                return "La Lista de precio se encuentra Deshabilitada";
            }

            // VERIFICA VENDEDOR **********************
            if (cl_glo_bal.IsNumeric(tb_cod_ven.Text) == false)
            {
                tb_cod_ven.Focus();
                return "Debe proporcionar un vendedor valido";
            }
            tab_cmr014 = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text));
           
            if (tab_cmr014.Rows.Count == 0)
            {
                tb_cod_ven.Focus();
                return "El vendedor no se encuentra registrado";
            }
            if (tab_cmr014.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_ven.Focus();
                return "El vendedor se encuentra Deshabilitado";
            }

            // VERIFICA DELIVERY **********************
            if(vta_par == "D") // en caso de selleccionar entrega con Delivery, verificara que haya seleccionado un delivery
            {
                if (cl_glo_bal.IsNumeric(lb_cod_del.Text) == false)
                {
                    lb_cod_del.Focus();
                    return "Debe proporcionar un Delivery valido";
                }

                if (lb_cod_del.Text == "0")
                    return "Debe de seleccionar el delivery";

                tab_cmr015 = o_cmr015.Fe_con_del(int.Parse(lb_cod_del.Text));

                if (tab_cmr015.Rows.Count == 0)
                {
                    return "El Delivery no se encuentra registrado";
                }
                if (tab_cmr015.Rows[0]["va_est_ado"].ToString() == "N")
                {
                    return "El Delivery se encuentra Deshabilitado";
                }

            }

            // VERIFICA QUE CLIENTE EXISTA *******************
            if (cl_glo_bal.IsNumeric(tb_cod_per.Text) == false)
            {
                tb_cod_per.Focus();
                return "Debe proporcionar un Cliente valido";
            }
            tab_adp002 = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (tab_adp002.Rows.Count == 0)
            {
                tb_cod_per.Focus();
                return "El Cliente no se encuentra registrado";
            }
            if (tab_adp002.Rows[0]["va_est_ado"].ToString() == "N")
            {
                tb_cod_per.Focus();
                return "El Cliente se encuentra Deshabilitado";
            }

            // Verifica que haya al menos 1 producto
            if(dg_det_pro.Rows.Count==0)
            {
                return "Debe de seleccionar al menos 1 producto";
            }

            // Verifica que no haya items con precio cero (0)
            for (int i = 0; i < dg_det_pro.Rows.Count; i++)
            {
                if( decimal.Parse(dg_det_pro.Rows[i].Cells["va_pre_uni"].Value.ToString()) == 0m)
                    return "El producto del item Nª ("+ (i+1) +") no tiene precio definido, revise por favor";
            }


            return "";
        }

        private void Fi_lim_pia()
        {
            dg_det_pro.Rows.Clear();
            Fi_obt_per();
            pre_tot = 0m; // decimal.Parse(string.Format("{0:N2}", pre_tot));
            mto_can = 0m;
            cam_bio = 0m;
            obs_ope = "";

            // Obtiene fecha y hora actual para codigo de tabla temporal
            va_cod_tmp = o_mg_glo_frm.fg_fec_act();
            raz_soc = "";
        }
        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_bus_del_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_del();
        }
        void Fi_abr_bus_del()
        {
            cmr015_01b frm = new cmr015_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                lb_cod_del.Text = frm.tb_sel_bus.Text;
                lb_nom_del.Text = frm.lb_des_bus.Text;
                
            }
        }

        private void bt_eli_itm_Click(object sender, EventArgs e)
        {
            DialogResult res;
            int nro_fil = 0;
            DataGridViewSelectedRowCollection fil_sel;
            if (dg_det_pro.Rows.Count > 0)
            { 
                fil_sel=dg_det_pro.SelectedRows;
                nro_fil = fil_sel[0].Index;

                res = MessageBox.Show("Esta seguro de eliminar el item seleccionado ?", "Venta",MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    dg_det_pro.Rows.RemoveAt(nro_fil);
                    //** Elimina item de la temporal
                    o_res002.fu_eli_tmp(Program.gl_usr_usr, va_cod_tmp, nro_fil + 1);

                    //** Calcula total general
                    Fi_cal_tot();

                    int nro_ant = 0;
                    //**Actualiza items en la temporal
                    for (int i = 0; i < dg_det_pro.RowCount; i++)
                    {
                        nro_ant = int.Parse(dg_det_pro.Rows[i].Cells["va_nro_itm"].Value.ToString());
                        o_res002.fu_edi_itm_tmp(Program.gl_usr_usr, va_cod_tmp, nro_ant, i + 1);
                    }

                    if((nro_fil) == dg_det_pro.RowCount && nro_fil != 0)
                    {
                        //** Seleccionar la ultima fila de la grilla
                        dg_det_pro.Rows[nro_fil - 1].Selected = true;
                        dg_det_pro.FirstDisplayedScrollingRowIndex = (nro_fil - 1);

                    }
                }
            }

            

        }

        private void bt_sum_can_Click(object sender, EventArgs e)
        {
            int nro_fil = 0;
            int can_uni = 0;
            DataGridViewSelectedRowCollection fil_sel;
            if (dg_det_pro.Rows.Count > 0)
            {
                //** Obtiene item seleccionado
                fil_sel = dg_det_pro.SelectedRows;
                nro_fil = fil_sel[0].Index;

                can_uni = int.Parse(dg_det_pro.Rows[nro_fil].Cells["va_can_uni"].Value.ToString());
                can_uni = can_uni + 1;
                dg_det_pro.Rows[nro_fil].Cells["va_can_uni"].Value = can_uni ;

                Fi_cal_bru(nro_fil);
                Fi_cal_tot();


                // Graba en tabla temporal el cambio de cantidad y peso
                DataTable tab_det_vta = new DataTable();
                tab_det_vta.Rows.Add();
                for (int i = 0; i <= dg_det_pro.Columns.Count - 1; i++)
                {
                    tab_det_vta.Columns.Add(dg_det_pro.Columns[i].Name);
                    if (i == 0)
                        tab_det_vta.Rows[0][i] = nro_fil + 1;
                    else
                        tab_det_vta.Rows[0][i] = dg_det_pro.Rows[nro_fil].Cells[i].Value;
                }

                o_res002.fu_edi_tmp(Program.gl_usr_usr, va_cod_tmp, tab_det_vta);

            }
        }

        private void bt_res_can_Click(object sender, EventArgs e)
        {
            int nro_fil = 0;
            int can_uni = 0;
            DataGridViewSelectedRowCollection fil_sel;
            if (dg_det_pro.Rows.Count > 0)
            {
                //** Obtiene item seleccionado
                fil_sel = dg_det_pro.SelectedRows;
                nro_fil = fil_sel[0].Index;

                can_uni = int.Parse(dg_det_pro.Rows[nro_fil].Cells["va_can_uni"].Value.ToString());
                if (can_uni != 1)  // Solo resta hasta llegar a cantidad 0
                { 
                    dg_det_pro.Rows[nro_fil].Cells["va_can_uni"].Value = can_uni - 1;
                    Fi_cal_bru(nro_fil);
                  
                }

                // Graba en tabla temporal el cambio de cantidad y peso
                DataTable tab_det_vta = new DataTable();
                tab_det_vta.Rows.Add();
                for (int i = 0; i <= dg_det_pro.Columns.Count - 1; i++)
                {
                    tab_det_vta.Columns.Add(dg_det_pro.Columns[i].Name);
                    if (i == 0)
                        tab_det_vta.Rows[0][i] = nro_fil + 1;
                    else
                        tab_det_vta.Rows[0][i] = dg_det_pro.Rows[nro_fil].Cells[i].Value;
                }

                o_res002.fu_edi_tmp(Program.gl_usr_usr, va_cod_tmp, tab_det_vta);
            }
        }

       
        private void bt_gra_bar_Click(object sender, EventArgs e)
        {
            // valida datos en pantalla
            string ret_val = "";
            ret_val = Fi_val_dat();
            if (ret_val != "")
            {
                MessageBox.Show(ret_val, "Error Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //** Inicializa variables
            doc_ope = tab_res004.Rows[0]["va_doc_ntv"].ToString();
            tal_ope = int.Parse(tab_res004.Rows[0]["va_tal_ntv"].ToString());
            cod_per = int.Parse(tb_cod_per.Text);
            cod_caj = 0;
            cod_lcr = 0;
            tip_cam = 1m;
            mon_ope = tab_res004.Rows[0]["va_mon_vta"].ToString();


            // Instacia de formulario para completar la operacion
            dynamic frm_com_ope ;
            frm_com_ope = new res001_02e();
            // Abre completa operacion
            switch (tip_ope)
            {
                case 1: // Factura **********************

                    // OBTIENE NIT DE LA PERSONA
                    // ** Obtiene el ultimo nit al que se facturo a la persona
                    tab_cmr013 = o_cmr013.Fe_ult_nit(cod_per);
                    if (tab_cmr013.Rows.Count > 0)
                    { 
                        nit_per = int.Parse(tab_cmr013.Rows[0]["va_nit_per"].ToString());
                        raz_soc = tab_cmr013.Rows[0]["va_raz_soc"].ToString();
                    }
                    else
                    {
                        // ** Obtiene nit del ABM de la persona
                        nit_per = int.Parse(tab_adp002.Rows[0]["va_nit_per"].ToString());
                        raz_soc = tab_adp002.Rows[0]["va_raz_soc"].ToString();
                    }


                    frm_com_ope = new res001_02e();
                    cl_glo_frm.abrir(this, frm_com_ope, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);


                    // **  Recupera datos del Completa venta con Factura
                    obs_ope = frm_com_ope.tb_obs_vta.Text;

                    if (cl_glo_bal.IsNumeric(frm_com_ope.tb_nit_per.Text) == false)
                        nit_per = 0;
                    else
                        nit_per = int.Parse(frm_com_ope.tb_nit_per.Text);

                    raz_soc = frm_com_ope.tb_raz_soc.Text;
                    mto_can = decimal.Parse(frm_com_ope.tb_mto_can.Text);
                    cam_bio = decimal.Parse(frm_com_ope.tb_cam_bio.Text);

                    // Obtiene talonario de la plantilla para obtener dosificacion
                    doc_ope = tab_res004.Rows[0]["va_doc_fac"].ToString();
                    tal_ope = int.Parse(tab_res004.Rows[0]["va_tal_fac"].ToString());

                    // Obtiene dosificacion del talonario
                    tab_ads004 = o_ads004.Fe_con_tal(doc_ope, tal_ope);
                    va_nro_aut = int.Parse(tab_ads004.Rows[0]["va_nro_aut"].ToString());
                    tip_tal = int.Parse(tab_ads004.Rows[0]["va_tip_tal"].ToString());

                    // Obtiene datos de la dosificacion
                    tab_ctb007 = o_ctb007._05(va_nro_aut);
                    if (tab_ctb007.Rows.Count == 0)
                    {
                        MessageBox.Show("La dosificacion no se encuentra registrada","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }
                    va_nro_fac = int.Parse(tab_ctb007.Rows[0]["va_con_tad"].ToString());
                    va_lla_ve = tab_ctb007.Rows[0]["va_nro_aut"].ToString();
                    
                    break;

                case 2: // Nota de Venta ****************
                    frm_com_ope = new res001_02d();
                    cl_glo_frm.abrir(this, frm_com_ope, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

                    obs_ope = frm_com_ope.tb_obs_vta.Text;
                    raz_soc = frm_com_ope.tb_raz_soc.Text;
                    mto_can = decimal.Parse(frm_com_ope.tb_mto_can.Text);
                    cam_bio = decimal.Parse(frm_com_ope.tb_cam_bio.Text);

                    break;
            }



            
            
            
            if((frm_com_ope.DialogResult == DialogResult.OK))
            {
                try { //** Graba venta

                    switch (tip_ope)
                    {
                        case 1: // GRABA FACTURA

                            if (tip_tal == 0) // Tito talonario manual
                                va_nro_fac = 0;
                            else
                                va_nro_fac = va_nro_fac + 1;

                            //Obtiene codigo de control
                            va_cod_ctr = cl_glo_bal.FE_obt_ccf(va_nro_aut.ToString(),va_nro_fac.ToString(), nit_per.ToString(), tb_fec_vta.Value , pre_tot,va_lla_ve);

                            tb_res001 = o_res001.Fe_crea(Program.gl_usr_usr, va_cod_tmp, int.Parse(tb_cod_plv.Text), tip_ope, va_nro_fac, // <- Nro de factura
                                 int.Parse(tb_cod_bod.Text), cod_per.ToString(), nit_per.ToString(),
                                 raz_soc, mon_ope, tb_fec_vta.Value, va_for_pag, int.Parse(tb_cod_ven.Text),
                                 int.Parse(tb_cod_lis.Text), cod_caj, cod_lcr, tip_cam, 0, obs_ope,
                                 vta_par, int.Parse(lb_cod_del.Text), "", pre_tot, cam_bio,
                                 va_nro_aut, va_cod_ctr); // <- Nro de autorizacion y codigo de control

                            
                            // Actualiza codigo de control   

                            break;
                        case 2: // GRABA NOTA DE VENTA
                            tb_res001 = o_res001.Fe_crea(Program.gl_usr_usr, va_cod_tmp, int.Parse(tb_cod_plv.Text), tip_ope, 0, // <- Nro de factura
                                 int.Parse(tb_cod_bod.Text), cod_per.ToString(), nit_per.ToString(),
                                 raz_soc, mon_ope, tb_fec_vta.Value, va_for_pag, int.Parse(tb_cod_ven.Text),
                                 int.Parse(tb_cod_lis.Text), cod_caj, cod_lcr, tip_cam, 0, obs_ope,
                                 vta_par, int.Parse(lb_cod_del.Text), "", pre_tot, cam_bio,
                                 0, ""); // <- Nro de autorizacion y codigo de control
                            break;
                    }


                    // Crea tabla para pasar datos
                    DataTable tab_dat = new DataTable();
                    tab_dat.Columns.Add("va_ide_doc");
                    tab_dat.Columns.Add("va_cod_doc");
                    tab_dat.Columns.Add("va_ges_doc");
                    tab_dat.Columns.Add("va_nro_tal");
                    tab_dat.Columns.Add("va_ope_rac");
                    tab_dat.Columns.Add("va_cod_plv");

                    tab_dat.Rows.Add();
                    tab_dat.Rows[0]["va_ide_doc"] = tb_res001.Rows[0]["va_ide_vta"].ToString();
                    tab_dat.Rows[0]["va_cod_doc"] = tb_res001.Rows[0]["va_doc_vta"].ToString();
                    tab_dat.Rows[0]["va_ges_doc"] = tb_res001.Rows[0]["va_ges_vta"].ToString();
                    tab_dat.Rows[0]["va_nro_tal"] = tb_res001.Rows[0]["va_nro_tal"].ToString();
                    tab_dat.Rows[0]["va_cod_plv"] = tb_res001.Rows[0]["va_cod_plv"].ToString();

                    tab_dat.Rows[0]["va_ope_rac"] = "VENTA";

                    //** Limpiar formulario de venta
                    Fi_lim_pia();

                     //** Envia a imprimir documento
                    cmr000_01 frm = new cmr000_01();
                    cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si, tab_dat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void bt_par_mes_Click(object sender, EventArgs e)
        {
            bt_par_lle.BackColor = Color.Gray;
            bt_par_del.BackColor = Color.Gray;

            bt_par_mes.BackColor = Color.FromArgb(32, 43, 76);
            vta_par = "M";

            lb_cod_del.Text = "0";
            lb_nom_del.Text = "";
        }

        private void bt_par_lle_Click(object sender, EventArgs e)
        {
            bt_par_mes.BackColor = Color.Gray;
            bt_par_del.BackColor = Color.Gray;
            
            bt_par_lle.BackColor = Color.FromArgb(32, 43, 76);
            vta_par = "L";

            lb_cod_del.Text = "0";
            lb_nom_del.Text = "";
        }

        private void bt_par_del_Click(object sender, EventArgs e)
        {
            if (vta_par != "D")
            {

                bt_par_lle.BackColor = Color.Gray;
                bt_par_mes.BackColor = Color.Gray;

                bt_par_del.BackColor = Color.FromArgb(32, 43, 76);
                vta_par = "D";

                // Verifica si permite cambiar Delivery
                if (tab_res004.Rows.Count != 0)
                {
                    // Obtiene Delivery
                    lb_cod_del.Text = tab_res004.Rows[0]["va_cod_del"].ToString();
                    // Obtiene nombre de Delivery
                    tab_cmr015 = o_cmr015.Fe_con_del(int.Parse(lb_cod_del.Text));

                    if (tab_cmr015.Rows.Count > 0)
                        lb_nom_del.Text = tab_cmr015.Rows[0]["va_nom_del"].ToString();

                   
                    if (tab_res004.Rows[0]["va_cam_del"].ToString() == "1") // No cambia
                    {
                        Fi_abr_bus_del();
                    }
                }

                
            }

           


        }

        private void bt_not_itm_Click(object sender, EventArgs e)
        {
            if (dg_det_pro.RowCount == 0)
                return;


            res001_02c frm = new res001_02c();
            int fil_sel = dg_det_pro.SelectedRows[0].Index ;

            frm.nro_itm = int.Parse(dg_det_pro.Rows[fil_sel].Cells["va_nro_itm"].Value.ToString());
            if (dg_det_pro.Rows[fil_sel].Cells["va_not_itm"].Value is null)
                frm.not_itm = "";
            else
                frm.not_itm = dg_det_pro.Rows[fil_sel].Cells["va_not_itm"].Value.ToString();

            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.bloq,cl_glo_frm.ctr_btn.si);
        }

        public void Fe_obt_not(int nro_itm, string not_itm)
        {
            dg_det_pro.Rows[nro_itm - 1].Cells["va_not_itm"].Value = not_itm;


            //** Graba el item en la tabla temporal (res002_temp)
            //******************************
            // GRABA EN TABLA TEMPORAL
            DataTable tab_det_vta = new DataTable();
            tab_det_vta.Rows.Add();
            for (int i = 0; i <= dg_det_pro.Columns.Count - 1; i++)
            {
                tab_det_vta.Columns.Add(dg_det_pro.Columns[i].Name);
                tab_det_vta.Rows[0][i] = dg_det_pro.Rows[nro_itm - 1].Cells[i].Value;
            }

            o_res002.fu_edi_tmp(Program.gl_usr_usr, va_cod_tmp,tab_det_vta);

        }

        private void res001_02b_FormClosing(object sender, FormClosingEventArgs e)
        {
            o_res002.fu_eli_tmp(Program.gl_usr_usr, va_cod_tmp);
        }


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
                tb_cod_per.Text = frm.tb_sel_bus.Text;
                Fi_obt_per();
                //tb_raz_soc.Text = frm.lb_des_bus.Text;
            }
        }
        private void Tb_cod_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_per();
        }
        private void Fi_obt_per()
        {
            int val = 0;
            try
            {
                val = int.Parse(tb_cod_per.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Debe proporcionar un codigo de cliente valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
            }


            tabla = o_adp002.Fe_con_per(val);
            if (tabla.Rows.Count == 0)
            {
                tb_raz_soc.Text = "No Existe";
            }
            else
            {
                tb_raz_soc.Text = tabla.Rows[0]["va_raz_soc"].ToString();
                nit_per = int.Parse( tabla.Rows[0]["va_nit_per"].ToString());
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
        /// <summary>
        /// Buscador plantilla de venta, devuelve en la variable sel_pvt el codigo de la plantilla seleccionada
        /// </summary>
        void Fi_abr_bus_plv()
        {
            res004_01b frm = new res004_01b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                sel_pvt = 1;        // indica que si selecciono plantilla al abrir
                tb_cod_plv.Text = frm.tb_sel_bus.Text;
                lb_nom_plv.Text = frm.lb_des_bus.Text;
            }
            Fi_obt_plv();
        }
        private void Tb_cod_plv_Validated(object sender, EventArgs e)
        {
            Fi_obt_plv();
        }
        private void Fi_obt_plv()
        {
// int val = 0;
           

            if (cl_glo_bal.IsNumeric(tb_cod_plv.Text) == false)
            {
                MessageBox.Show("Debe proporcionar una plantilla valida", "Error", MessageBoxButtons.OK);
            }
           
            tab_res004 = o_res004.Fe_con_plv(tb_cod_plv.Text);
            if (tab_res004.Rows.Count == 0)
            {
                lb_nom_plv.Text = "No Existe";
                ban_plv = false;
            }
            else
            {
                // Pregunta si el usuario tiene permiso sobre la plantilla
                if (o_ads008.Fe_aut_usr( "res004", tb_cod_plv.Text) == false)
                {
                    MessageBox.Show("La plantilla de venta no esta permitida para el usuario ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ban_plv = false;
                }
                else 
                { 
                    // Pregunta por el estado de la plantilla
                    if (tab_res004.Rows[0]["va_est_ado"].ToString() == "N")
                    {
                        MessageBox.Show("La Plantilla de venta se encuentra Deshabilitada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lb_nom_plv.Text = tab_res004.Rows[0]["va_nom_plv"].ToString();
                        ban_plv = false;
                    }
                    else
                    {
                        lb_nom_plv.Text = tab_res004.Rows[0]["va_nom_plv"].ToString();
                        ban_plv = true;
                       
                    }
                }
            }

            Fi_par_plv();
        }


        /// <summary>
        /// Obtiene parametros configurados en la plantilla de venta
        /// </summary>
        private void Fi_par_plv()
        {
            if(ban_plv == true)
            {
                // Habilita group box de parametros
                gb_par_ame.Enabled = true;

                // Obtiene Cliente
                tb_cod_per.Text = tab_res004.Rows[0]["va_cod_cli"].ToString();

                tab_adp002 = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
                if (tab_adp002.Rows.Count == 0)
                    tb_raz_soc.Text = "** No Existe";
                else
                    tb_raz_soc.Text = tab_adp002.Rows[0]["va_raz_soc"].ToString();

                
                // Obtiene bodega
                tb_cod_bod.Text = tab_res004.Rows[0]["va_cod_bod"].ToString();
                
                //Verifica si el usuario tiene permiso sobre la bodega
                if (1==2) //( o_ads008.Fe_ads008_02(Program.gl_usr_usr, "inv002", tb_cod_bod.Text) == false)
                {
                    MessageBox.Show("La bodega no esta permitida para el usuario","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    lb_nom_bod.Text = "Bodega NO permitida";
                }
                else
                {
                    // Obtiene nombre de bodega
                    tab_inv002 = o_inv002.Fe_con_bod(int.Parse(tb_cod_bod.Text));
                    if (tab_inv002.Rows.Count > 0)
                        lb_nom_bod.Text = tab_inv002.Rows[0]["va_nom_bod"].ToString();
                }

                // Verifica si permite cambiar bodega
                if (tab_res004.Rows[0]["va_cam_bod"].ToString() == "0") // No cambia
                {
                    tb_cod_bod.Enabled = false;
                    bt_bus_bod.Enabled = false;
                }
                if (tab_res004.Rows[0]["va_cam_bod"].ToString() == "1") // Si cambia
                {
                    tb_cod_bod.Enabled = true;
                    bt_bus_bod.Enabled = true;
                }

                // Obtiene Lista de precio
                tb_cod_lis.Text = tab_res004.Rows[0]["va_cod_lis"].ToString();

                //Verifica si el usuario tiene permiso sobre la bodega
                if (o_ads008.Fe_ads008_02(Program.gl_usr_usr, "cmr001", tb_cod_lis.Text) == false)
                {
                    MessageBox.Show("La Lista de precio no esta permitida para el usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lb_nom_lis.Text = "NO permitida";
                }
                else
                {
                    // Obtiene nombre de lista
                    tab_cmr001 = o_cmr001.Fe_con_lis(int.Parse(tb_cod_lis.Text));
                    if (tab_cmr001.Rows.Count > 0)
                        lb_nom_lis.Text = tab_cmr001.Rows[0]["va_nom_lis"].ToString();
                }

                // Verifica si permite cambiar Lista de precio
                if (tab_res004.Rows[0]["va_cam_lis"].ToString() == "0") // No cambia
                {
                    tb_cod_lis.Enabled = false;
                    bt_bus_lis.Enabled = false;
                }
                if (tab_res004.Rows[0]["va_cam_lis"].ToString() == "1") // Si cambia
                {
                    tb_cod_lis.Enabled = true;
                    bt_bus_lis.Enabled = true;
                }

                if (tab_res004.Rows[0]["va_cam_lis"].ToString() == "2") // Obtiene lista de precio asignada al cliente
                {
                    tb_cod_lis.Enabled = false;
                    bt_bus_lis.Enabled = false;
                    
                    // Obtiene lista de precio del cliente

                }

                // Obtiene Vendedor
                tb_cod_ven.Text = tab_res004.Rows[0]["va_cod_ven"].ToString();
                // Obtiene nombre de Vendedor
                tab_cmr014 = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text));

                if (tab_cmr001.Rows.Count > 0)
                    lb_nom_ven.Text = tab_cmr014.Rows[0]["va_nom_ven"].ToString();
 
                // Verifica si permite cambiar vendedor
                if (tab_res004.Rows[0]["va_cam_ven"].ToString() == "0") // No cambia
                {
                    tb_cod_ven.Enabled = false;
                    bt_bus_ven.Enabled = false;
                }
                if (tab_res004.Rows[0]["va_cam_ven"].ToString() == "1") // Si cambia
                {
                    tb_cod_ven.Enabled = true;
                    bt_bus_ven.Enabled = true;
                }
                if (tab_res004.Rows[0]["va_cam_ven"].ToString() == "2") // Asignado al cliente
                {
                    tb_cod_ven.Enabled = false ;
                    bt_bus_ven.Enabled = false ;
                }

                // Obtiene Delivery
                tab_cmr015 = o_cmr015.Fe_con_del(int.Parse(tab_res004.Rows[0]["va_cod_del"].ToString()));
                if (tab_cmr015.Rows.Count > 0 && vta_par == "D")
                {
                    lb_cod_del.Text = tab_res004.Rows[0]["va_cod_del"].ToString();
                    lb_nom_del.Text = tab_cmr015.Rows[0]["va_nom_del"].ToString();
                }
                // Verifica si permite cambiar Delivery
                if (tab_res004.Rows[0]["va_cam_del"].ToString() == "0") // No cambia
                {
                    bt_bus_del.Enabled = false;
                }
                if (tab_res004.Rows[0]["va_cam_del"].ToString() == "1") // Si cambia
                {
                    bt_bus_del.Enabled = true;
                }
               



            }
            if (ban_plv == false)
            {
                // Deshabilita group box de parametros
                gb_par_ame.Enabled = false;
                bt_bus_plv.Enabled = true;
                // Limpi los campos
                tb_cod_bod.Text = "0";
                lb_nom_bod.Text = "";

                tb_cod_lis.Text = "0";
                lb_nom_lis.Text = "";

                tb_cod_ven.Text = "0";
                lb_nom_ven.Text = "";

            }

        }

            // BUSCAR BODEGA
            private void Bt_bus_bod_Click(object sender, EventArgs e)
            {
                Fi_abr_bus_bod();
            }
            private void Tb_cod_bod_KeyDown(object sender, KeyEventArgs e)
            {
                //al presionar tecla para ARRIBA
                if (e.KeyData == Keys.Up)
                {
                    // Abre la ventana Busca Bodega
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
                try
                {
                    val = int.Parse(tb_cod_bod.Text);
                }
                catch (Exception)
                {
                    lb_nom_bod.Text = "";
                    return;
                }
            
                tabla = o_inv002.Fe_con_bod(val);
                if (tabla.Rows.Count == 0)
                {
                    lb_nom_bod.Text = "";
                }
                else
                {
                    lb_nom_bod.Text = tabla.Rows[0]["va_nom_bod"].ToString();
                }
           
            }

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
                    lis_ant = int.Parse(tb_cod_lis.Text);
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
                    lis_ant = int.Parse(tb_cod_lis.Text);
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
            //int val = 0;

            if(cl_glo_bal.IsNumeric(tb_cod_lis.Text)==false)
            {
                if (dg_det_pro.Rows.Count != 0)
                {
                    DialogResult res = MessageBox.Show("Lista de precio no valida, desean mantener la lista de precios anterior ? " +
                        "de lo contrario se borraran sus items", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        tb_cod_lis.Text = lis_ant.ToString();
                    }
                    else
                    {
                        lb_nom_lis.Text = "";
                        dg_det_pro.Rows.Clear();
                        o_res002.fu_eli_tmp(Program.gl_usr_usr, va_cod_tmp);
                        Fi_cal_tot();
                        return;
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("Lista de precio no valida, se mantendra la lista de precios anterior.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tb_cod_lis.Text = lis_ant.ToString();
                    return;
                }
            }

                
            if (lis_ant == int.Parse(tb_cod_lis.Text))
                return;


            

            // Obtiene Id y nombre de Lista de precio
            tabla = o_cmr001.Fe_con_lis(int.Parse(tb_cod_lis.Text));
            if (tabla.Rows.Count == 0)
            { 
                DialogResult res = MessageBox.Show("Lista de precio no existe, se mantendra la lista de precios anterior.", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_cod_lis.Text = lis_ant.ToString();
                return;
            }
            else
            {
                // Verifica que el usuario tenga permisos sobre la plantilla de venta
                if(o_ads008.Fe_ads008_02(Program.gl_usr_usr,"cmr001",tb_cod_lis.Text) == false)
                {
                    MessageBox.Show("La lista de precios no esta permitida para el usuario, se mantendra la lista de precios anterior", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    tb_cod_lis.Text = lis_ant.ToString();
                    return;
                }

                // Si todo esta correcto, pregunta si desea continuar
                if (dg_det_pro.Rows.Count != 0)
                {
                    DialogResult res = MessageBox.Show("Se recalcularan los precios, desea continuar ?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        tb_cod_lis.Text = tabla.Rows[0]["va_cod_lis"].ToString();
                        lb_nom_lis.Text = tabla.Rows[0]["va_nom_lis"].ToString();
                        
                        // Recalcula precios
                        Fi_rec_alc();
                        return;
                    }
                    else
                    {
                        tb_cod_lis.Text = lis_ant.ToString();
                        return;
                    }
                }
                else
                {
                    lb_nom_lis.Text = tabla.Rows[0]["va_nom_lis"].ToString();
                    
                    lis_ant = int.Parse(tb_cod_lis.Text);
                    return;
                }


            }
        }

            private void Fi_rec_alc()
            {
                for (int i = 0; i < dg_det_pro.Rows.Count; i++)
                {
                    decimal pre_uni = 0m;
                    //** Obtiene precio del producto
                    tab_cmr002 = new DataTable();
                    tab_cmr002 = o_cmr002.Fe_con_pre(int.Parse(tb_cod_lis.Text), dg_det_pro.Rows[i].Cells["va_cod_pro"].Value.ToString());
                    if (tab_cmr002.Rows.Count > 0)
                    {
                        pre_uni = decimal.Parse(tab_cmr002.Rows[0]["va_pre_cio"].ToString());
                    }

                    if (pre_uni == 0)
                    {
                        MessageBox.Show("El producto del item Nª ("+ (i+1) +") no tiene precio definido en la lista de precio selecionada", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //** Actualiza el precio del producto
                    dg_det_pro.Rows[i].Cells["va_pre_uni"].Value = pre_uni;

                    //** Calcula Total item
                    Fi_cal_bru(i);

                    //** Actualiza el item en la tabla temporal (res002_temp)
                    //******************************
                    // ACTUALIZA EN TABLA TEMPORAL
                    DataTable tab_det_vta = new DataTable();
                    tab_det_vta.Rows.Add();
                    for (int x = 0; x <= dg_det_pro.Columns.Count - 1; x++)
                    {
                        tab_det_vta.Columns.Add(dg_det_pro.Columns[x].Name);
                        if (x == 0)
                            tab_det_vta.Rows[0][x] = i + 1;
                        else
                            tab_det_vta.Rows[0][x] = dg_det_pro.Rows[i].Cells[x].Value;
                    }

                    o_res002.fu_edi_tmp(Program.gl_usr_usr, va_cod_tmp, tab_det_vta);


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

            // Obtiene ide y nombre Vendedor
            tabla = o_cmr014.Fe_con_ven(int.Parse(tb_cod_ven.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_nom_ven.Text = "";
            }
            else
            {
                tb_cod_ven.Text = tabla.Rows[0]["va_cod_ven"].ToString();
                lb_nom_ven.Text = tabla.Rows[0]["va_nom_ven"].ToString();
            }
        }

        private void tb_cod_bod_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_cod_lis_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_cod_ven_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void mn_not_vta_Click(object sender, EventArgs e)
        {
            tb_tip_ope.Text = "NOTA DE VENTA";
            tip_ope = 2;
        }

        private void mn_not_com_Click(object sender, EventArgs e)
        {
            tb_tip_ope.Text = "NOTA DE CONSUMO";
            tip_ope = 3;
        }

        private void mn_fac_tur_Click(object sender, EventArgs e)
        {
            tb_tip_ope.Text = "FACTURA";
            tip_ope = 1;
        }

        
        private void bt_con_tad_Click(object sender, EventArgs e)
        {
            Fi_con_cre(1);
        }

        private void bt_cre_dit_Click(object sender, EventArgs e)
        {
            Fi_con_cre(2);
        }
        private void Fi_con_cre(int va_con_cre)
        {
            if (va_con_cre == 1)
            {
                if (va_for_pag == 2)
                {
                    Fi_con_cre(2);
                    return;
                }
                // Con la seleccion
                va_for_pag = 2;


                //cambia tamaño
                bt_cre_dit.Size = new Size(70, 21);

                //cambia texto
                bt_cre_dit.Text = "CREDITO";
                //bt_cre_dit.Location
                bt_cre_dit.Location = new Point(270, 28);
                bt_cre_dit.SendToBack();

                // Con el no seleccionado
                bt_con_tad.Size = new Size(18, 23);
                bt_con_tad.Text = "|";
                bt_con_tad.Location = new Point(254, 27);
                bt_con_tad.BringToFront();
            }

            if (va_con_cre == 2)
            {// Con la seleccion

                if (va_for_pag == 1)
                {
                    Fi_con_cre(1);
                    return;
                }
                va_for_pag = 1;
                bt_con_tad.Size = new Size(70, 21);
                bt_con_tad.Text = "CONTADO";
                bt_con_tad.Location = new Point(254, 28);
                bt_con_tad.SendToBack();

                // Con el no seleccionado
                bt_cre_dit.Size = new Size(18, 23);
                bt_cre_dit.Text = "|";
                bt_cre_dit.Location = new Point(320, 27);
                bt_cre_dit.BringToFront();
            }
        }
    }
}
