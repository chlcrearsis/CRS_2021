using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    public partial class ecp002_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;

        public ecp002_01()
        {
            InitializeComponent();
        }

        // instancia
        
        ecp002 o_ecp002 = new ecp002();


        // Variables
        DataTable tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            
            tb_sel_ecc.Text = "";
           
            cb_prm_bus.SelectedIndex = 0;
            cb_est_ado.SelectedIndex = 0;
            cb_tip_lib.SelectedIndex = 0;

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
            string ar_tex_bus = tb_tex_bus.Text;
            string ar_est_ado = "T";
            int ar_tip_lib = 0;

            if (cb_est_ado.SelectedIndex == 0)
                ar_est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                ar_est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                ar_est_ado = "N";

            ar_tip_lib = cb_tip_lib.SelectedIndex ;
           

            tabla = o_ecp002.Fe_bus_car(ar_tex_bus,cb_prm_bus.SelectedIndex + 1, ar_est_ado, ar_tip_lib);

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_cod_lib"].Value = tabla.Rows[i]["va_cod_lib"].ToString();
                    dg_res_ult.Rows[i].Cells["va_des_lib"].Value = tabla.Rows[i]["va_des_lib"].ToString();

                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "1")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Cta. x Cob.";
                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "2")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Cta. x Pag.";
                    if (tabla.Rows[i]["va_tip_lib"].ToString() == "3")
                        dg_res_ult.Rows[i].Cells["va_tip_lib"].Value = "Tesoreria";


                    if (tabla.Rows[i]["va_mon_lib"].ToString() == "B")
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Value = "Boliviano";
                    else
                        dg_res_ult.Rows[i].Cells["va_mon_lib"].Value = "Dólares";


                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                
                }
                tb_sel_ecc.Text = tabla.Rows[0]["va_cod_lib"].ToString();
                lb_des_plg.Text = tabla.Rows[0]["va_des_lib"].ToString();

            }

            tb_tex_bus.Focus();

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
                    tb_sel_ecc.Text = "";
                else
                    tb_sel_ecc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_dat()
        {
            string res_fun = "";

            if(cl_glo_bal.IsDecimal(tb_sel_ecc.Text) ==false)
                res_fun = "El plan de pago no es valido.";
            
            tab_dat = o_ecp002.Fe_con_lib( int.Parse(tb_sel_ecc.Text));
            if (tabla.Rows.Count == 0)
            {
                res_fun = "El plan de pago no se encuentra registrado";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "plan de pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Bt_bus_car_Click(object sender, EventArgs e)
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
            if (fi_ver_dat() == false)
                return;

            ecp001_03 frm = new ecp001_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
      
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat() == false)
                return;

            ecp001_05 frm = new ecp001_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat() == false)
                return;

            ecp001_04 frm = new ecp001_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_dat() == false)
                return;

            ecp001_06 frm = new ecp001_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void mn_cre_ar_Click(object sender, EventArgs e)
        {
            ecp002_02 frm = new ecp002_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
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
