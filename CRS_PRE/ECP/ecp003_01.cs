using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    public partial class ecp003_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //public DataTable tab_dat;
        public dynamic frm_MDI;

        public ecp003_01()
        {
            InitializeComponent();
        }

        // instancia

        adp002 o_adp002 = new adp002();
        ecp003 o_ecp003 = new ecp003();

        int ve_lib_per = 0; //** Libreta de la persona

        // Variables
        DataTable tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_ecc.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            Fi_obt_per();
            cb_est_ado.SelectedIndex = 0;
            //fi_bus_car();
        }
        private void Fi_obt_per()
        {
            if (tb_sel_ecc.Text.Trim() == "")
            {
                MessageBox.Show("Debe proporcionar un codigo de persona valido", "Error", MessageBoxButtons.OK);
                //tb_cod_per.Focus();
            }

            if (!cl_glo_bal.IsNumeric(tb_sel_ecc.Text.Trim()))
            {
                tb_raz_soc.Text = "No Existe";
                tb_nom_per.Text = "";
            }
            tabla = o_adp002.Fe_con_per(int.Parse(tb_sel_ecc.Text));
            if (tabla.Rows.Count == 0)
            {
                tb_raz_soc.Text = "No Existe";
            }
            else
            {
                tb_raz_soc.Text = tabla.Rows[0]["va_raz_soc"].ToString();
                tb_nom_per.Text = tabla.Rows[0]["va_ape_pat"].ToString() + " " + tabla.Rows[0]["va_ape_mat"].ToString() + ", " + tabla.Rows[0]["va_nom_bre"].ToString();

            }
        }


        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        private void fi_bus_car(  )
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();
            //string ar_tex_bus = tb_tex_bus.Text;
            string ar_est_ado = "T";

            if (cb_est_ado.SelectedIndex == 0)
                ar_est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                ar_est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                ar_est_ado = "N";

            tabla = o_ecp003.Fe_lis_tar(int.Parse(tb_sel_ecc.Text), ar_est_ado);

             

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_lib"].Value = tabla.Rows[i]["va_cod_lib"].ToString();
                    dg_res_ult.Rows[i].Cells["va_des_lib"].Value = tabla.Rows[i]["va_des_lib"].ToString();
                    dg_res_ult.Rows[i].Cells["va_mto_lim"].Value = tabla.Rows[i]["va_mto_lim"].ToString();
                    dg_res_ult.Rows[i].Cells["va_sal_act"].Value = tabla.Rows[i]["va_sal_act"].ToString();
                    dg_res_ult.Rows[i].Cells["va_fec_exp"].Value = tabla.Rows[i]["va_fec_exp"].ToString();

                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "1")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Cta. x Cob.";
                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "2")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Cta. x Pag.";
                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "3")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Caja General";
                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "4")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Caja Recaudación";
                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "5")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Banco";

                    if (tabla.Rows[i]["va_mon_lib"].ToString() == "B")
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Value = "Bs.";
                    else
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Value = "Us.";


                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                
                }
                ve_lib_per = int.Parse(tabla.Rows[0]["va_cod_lib"].ToString());
                tb_sel_ecc.Text = frm_dat.Rows[0]["va_cod_per"].ToString();

            }

        }
      
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el talonario Modificó
        /// </summary>
        private void fi_sel_fil(long nro_dos)
        {
            fi_bus_car();

            if (nro_dos != 0  )
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == nro_dos.ToString() )
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
                    tb_sel_ecc.Text = ""; //** Persona
                    
                }
                else
                {
                    ve_lib_per = int.Parse(tabla.Rows[0]["va_cod_lib"].ToString());
                    //tb_sel_ecc.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
                }
            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat()
        {
            string res_fun = "";

            if(cl_glo_bal.IsDecimal(tb_sel_ecc.Text) ==false)
                res_fun = "la suscripción no es valido.";

            frm_dat = o_ecp003.Fe_con_sus(ve_lib_per, int.Parse(tb_sel_ecc.Text));
            if (frm_dat.Rows.Count == 0)
            {
                res_fun = "la suscripción no se encuentra registrado";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "suscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ecc.Focus();
                return false;
            }


            return true;
        }
     
    
        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            if(cl_glo_bal.IsDecimal(tb_sel_ecc.Text) ==true)
            fi_sel_fil(long.Parse(tb_sel_ecc.Text));
          
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e)
        {
            fi_fil_act();
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fi_fil_act();
        }

        private void cb_est_ado_SelectedIndexChanged(object sender, EventArgs e)
        {
            fi_bus_car();
        }

        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(long cod_lib)
        {
            fi_bus_car();

            if (cod_lib != 0)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == cod_lib.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;

                            return;
                        }
                    }
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
            if (fi_ver_dat() == false)
                return;

            ecp003_03 frm = new ecp003_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, frm_dat);
        }
       
      
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat() == false)
                return;

            //ecp003_05 frm = new ecp003_05();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat() == false)
                return;

            ecp001_04 frm = new ecp001_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, frm_dat);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat() == false)
                return;

            ecp001_06 frm = new ecp001_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, frm_dat);
        }
     
        private void mn_nue_ins_Click(object sender, EventArgs e)
        {            
            ecp003_02 frm = new ecp003_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, frm_dat);
        }
        private void mn_atr_ass_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }


        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            if (gb_ctr_btn.Enabled == true)
            {
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gb_ctr_btn.Enabled == true)
            {
                this.DialogResult = DialogResult.OK;
                cl_glo_frm.Cerrar(this);
            }
        }

      
    }
}
