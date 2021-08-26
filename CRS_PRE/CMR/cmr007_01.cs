using CRS_NEG;
using CRS_PRE.INV;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE.CMR
{
    public partial class cmr007_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;

        string est_bus = "T";

        //Form frm_mdi;
        public cmr007_01()
        {
            InitializeComponent();
        }

        // instancia
        ads016 o_ads016 = new ads016();
        cmr007 o_cmr007 = new cmr007();
        adp002 o_adp002 = new adp002();
        inv002 o_inv002 = new inv002();
        ads004 o_ads004 = new ads004();

        // Variables
        DataTable tab_ads004 = new DataTable();
        DataTable tabla = new DataTable();
        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_ide.Text = "";

            tb_cod_per.Text = "0";
            tb_cod_bod.Text = "0";
            lb_raz_soc.Text = "Todos";
            lb_nom_bod.Text = "Todos";

            cb_prm_bus.SelectedIndex = 0;
            cb_est_ado.SelectedIndex = 0;
            tb_fec_ini.Value = DateTime.Now;
            tb_fec_fin.Value = DateTime.Now;



            fi_bus_car();
        }


        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        private void fi_bus_car(  )
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            if (cb_est_ado.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_bus = "V";
            if (cb_est_ado.SelectedIndex == 2)
                est_bus = "N";

            string ar_tex_bus = tb_tex_bus.Text;
            int ar_prm_bus = cb_prm_bus.SelectedIndex;

            tabla = o_cmr007.Fe_bus_car( int.Parse(tb_cod_per.Text),tb_cod_bod.Text, tb_fec_ini.Value, tb_fec_fin.Value, ar_tex_bus, 1,est_bus);

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_fec_ped"].Value = DateTime.Parse( tabla.Rows[i]["va_fec_ped"].ToString()).ToString("dd/MM/yyyy");
                    dg_res_ult.Rows[i].Cells["va_ide_ped"].Value = tabla.Rows[i]["va_ide_ped"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nro_ped"].Value = tabla.Rows[i]["va_nro_ped"].ToString();
                    dg_res_ult.Rows[i].Cells["va_cod_per"].Value = tabla.Rows[i]["va_cod_per"].ToString();
                    dg_res_ult.Rows[i].Cells["va_raz_soc"].Value = tabla.Rows[i]["va_raz_soc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_tot_vtB"].Value = decimal.Parse(tabla.Rows[i]["va_tot_vtB"].ToString()).ToString("N2");
                    dg_res_ult.Rows[i].Cells["va_obs_ped"].Value = tabla.Rows[i]["va_obs_ped"].ToString();

                    if (tabla.Rows[i]["va_est_ado"].ToString() == "V")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Val.";
                    if (tabla.Rows[i]["va_est_ado"].ToString() == "N")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Anu.";

                    dg_res_ult.Rows[i].Cells["va_ges_ped"].Value = tabla.Rows[i]["va_ges_ped"].ToString();

                }

                // Formatea par mostrar en caja seleccionada arriba
                tb_sel_ide.Text = dg_res_ult.Rows[dg_res_ult.CurrentCell.RowIndex].Cells["va_ide_ped"].Value.ToString();
                tb_sel_ano.Text = dg_res_ult.Rows[dg_res_ult.CurrentCell.RowIndex].Cells["va_ges_ped"].Value.ToString();
            }

            tb_tex_bus.Focus();

        }
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if ( tb_sel_ide.Text.Trim()=="" || tb_sel_ano.Text =="")
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            tabla = new DataTable();
            tabla = o_cmr007.Fe_con_ped(tb_sel_ide.Text,int.Parse(tb_sel_ano.Text));

            if (tabla.Rows.Count == 0)
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }
            if (tabla.Rows[0].IsNull(0))
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }
            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_raz_soc"].ToString());
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el talonario Modificó
        /// </summary>
        private void fi_sel_fil( string ide_ped, int ges_tio)
        {
            fi_bus_car();

            if (ide_ped != null || ges_tio.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_ped"].Value.ToString().ToUpper() == ide_ped.ToString() &&
                            dg_res_ult.Rows[i].Cells["va_ges_ped"].Value.ToString().ToUpper() == ges_tio.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void fi_sub_baj_fil_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                try
                {
                    //al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();

                        }
                    }
                    //al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != 0)
                        {
                            //Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];

                            //Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }


        /// <summary>
        /// Método para obtener fila actual seleccionada
        /// </summary>
        public void fi_fil_act()
        {
            if (dg_res_ult.SelectedRows.Count != 0)
            {
                if (dg_res_ult.SelectedRows[0].Cells[0].Value == null)
                {
                    tb_sel_ide.Text = "";
                    tb_sel_ano.Text = "";
                    lb_des_bus.Text = "";
                }
                else
                {
                    tb_sel_ide.Text = dg_res_ult.Rows[dg_res_ult.CurrentCell.RowIndex].Cells["va_ide_ped"].Value.ToString();
                    tb_sel_ano.Text = dg_res_ult.Rows[dg_res_ult.CurrentCell.RowIndex].Cells["va_ges_ped"].Value.ToString();
                    
                }

            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi()
        {
            string res_fun = "";
            
            int val;
           
            int.TryParse(tb_sel_ano.Text, out val);
            if (val == 0)
                res_fun = "El pedido no se encuentra registrado";


            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ano.Focus();
                return false;
            }



            tab_dat = o_cmr007.Fe_con_ped(tb_sel_ide.Text,  int.Parse(tb_sel_ano.Text));
            if (tab_dat.Rows.Count == 0)
            {
                res_fun = "El pedido que desea editar, no se encuentra registrado";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ide.Focus();
                return false;
            }


            return true;
        }
      
        public bool fi_ver_con()
        {
            string res_fun = "";

            if (tb_sel_ide.Text.Trim() == "")
                res_fun = "El pedido, no se encuentra registrado";

            int val;
           
            int.TryParse(tb_sel_ano.Text, out val);
            if (val == 0)
                res_fun = "El pedido, no se encuentra registrado";

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Error pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ide.Focus();
                return false;
            }
            tab_dat = o_cmr007.Fe_con_exi_ped(tb_sel_ide.Text, int.Parse(tb_sel_ano.Text));
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("El pedido ya no se encuentra registrado en la base de datos.", "Consulta pedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ide.Focus();
                return false;
            }

            //tab_dat = new DataTable();
            //tab_dat = o_cmr007.Fe_cmr007_05a_p01(tb_sel_tal.Text, int.Parse(tb_sel_ano.Text));


            return true;
        }



        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_des_bus.Text != "** NO existe")
            {
                fi_sel_fil(tb_sel_ide.Text,int.Parse(tb_sel_ano.Text));
            }
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        private void Bt_bus_car_Click(object sender, EventArgs e)
        {
            fi_bus_car();
        }


        /// <summary>
        /// Funcion Externa que actualiza El pedidona con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string ide_doc, int nro_tal, int ges_tio)
        {
            fi_bus_car();

            if (ide_doc != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_doc.ToUpper() &&
                            dg_res_ult.Rows[i].Cells[2].Value.ToString() == nro_tal.ToString() &&
                            dg_res_ult.Rows[i].Cells[5].Value.ToString() == ges_tio.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;

                            return;
                        }
                    }

                    tb_tex_bus.Focus();
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }


        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi() == false)
                return;

            //cmr007_03 frm = new cmr007_03();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
        private void Mn_con_ped_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con() == false)
                return;


            // Determina formato segun documento
            Fi_for_mat();




        }

        private void Fi_for_mat()
        {
            // Obtiene Docuento y serie
            string doc_ped =  tb_sel_ide.Text.Substring(0,3);
            int nro_tal = int.Parse(tb_sel_ide.Text.Substring(3, 3));
            int nro_for = 0;


            // Obtiene formato de impresion del nro de talonario
            tab_ads004 = o_ads004.Fe_con_tal(doc_ped, nro_tal);
            if (tab_ads004.Rows.Count > 0)
            {
                nro_for = int.Parse(tab_ads004.Rows[0]["va_for_mat"].ToString());
            }


                switch (nro_for)
                {
                    case 0:
                        tab_dat = o_cmr007.Fe_con_ped(tb_sel_ide.Text, int.Parse(tb_sel_ano.Text));
                        break;
                    case 1:

                        break;
                    default:
                        tab_dat = o_cmr007.Fe_con_ped(tb_sel_ide.Text, int.Parse(tb_sel_ano.Text));
                        break;
                }
            cmr007_05w frm = new cmr007_05w();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tab_dat);


        }


        private void Mn_con_avi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con() == false)
                return;

            //cmr007_05bw frm = new cmr007_05bw();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, tab_dat);

        }


        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con() == false)
                return;

            //cmr007_06 frm = new cmr007_06();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Mn_lis_ped_Click(object sender, EventArgs e)
        {
            //cmr007_R01p frm = new cmr007_R01p();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
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
                // Abre El pedidona Busca Persona
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
                lb_raz_soc.Text = frm.lb_des_bus.Text;
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
                MessageBox.Show("Debe proporcionar un codigo de CLiente valido", "Error", MessageBoxButtons.OK);
                tb_cod_per.Focus();
            }
            int val = 0;
            if (tb_cod_per.Text.Trim() == "0" || tb_cod_per.Text.Trim() == "00")
            {
                lb_raz_soc.Text = "Todos";
            }
            else
            {
                int.TryParse(tb_cod_per.Text, out val);
                if (val == 0)
                {
                    MessageBox.Show("Debe proporcionar un codigo de cliente valido", "Error", MessageBoxButtons.OK);
                    tb_cod_per.Focus();
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
        }




        private void Bt_bus_bod_Click(object sender, EventArgs e)
        {
            Fi_abr_bus_bod();
        }
        private void Tb_cod_bod_KeyDown(object sender, KeyEventArgs e)
        {
            //al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre El pedidona Busca Persona
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
            if (tb_cod_bod.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar una bodega valida", "Error", MessageBoxButtons.OK);
                tb_cod_bod.Focus();
            }
            int val = 0;
            if (tb_cod_bod.Text.Trim() == "0" || tb_cod_bod.Text.Trim() == "00")
            {
                lb_nom_bod.Text = "Todos";
            }
            else
            {
                int.TryParse(tb_cod_bod.Text, out val);
                if (val == 0)
                {
                    MessageBox.Show("Debe proporcionar una bodega valida", "Error", MessageBoxButtons.OK);
                    tb_cod_bod.Focus();
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
        }
        /// <summary>
        /// Funcion Externa que actualiza El pedidona con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string ide_ped, int ges_tio)
        {
            fi_bus_car();

            if (ide_ped != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells["va_ide_ped"].Value.ToString().ToUpper() == ide_ped.ToUpper() &&
                            dg_res_ult.Rows[i].Cells["va_ges_ped"].Value.ToString() == ges_tio.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            return;
                        }
                    }
                    tb_tex_bus.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void mn_anu_ped_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_con() == false)
                return;

            //cmr007_04 frm = new cmr007_04();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
    }
}
