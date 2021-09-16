using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    public partial class ctb007_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;

        public ctb007_01()
        {
            InitializeComponent();
        }

        // instancia
        ads016 o_ads016 = new ads016();
        ctb007 o_ctb007 = new ctb007();
        

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
            int ar_prm_bus = cb_prm_bus.SelectedIndex;

            tabla = o_ctb007.Fe_bus_car(ar_tex_bus, ar_prm_bus, tb_fec_ini.Value, tb_fec_fin.Value,"H");

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_nro_dos"].Value = tabla.Rows[i]["va_nro_aut"].ToString();
                    dg_res_ult.Rows[i].Cells["va_cod_suc"].Value = tabla.Rows[i]["va_cod_suc"].ToString();
                    // dg_res_ult.Rows[i].Cells["va_nom_suc"].Value = tabla.Rows[i]["va_nom_suc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_tip_fac"].Value = tabla.Rows[i]["va_tip_fac"].ToString();
                    dg_res_ult.Rows[i].Cells["va_con_tad"].Value = tabla.Rows[i]["va_con_tad"].ToString();
                }
                tb_sel_ecc.Text = tabla.Rows[0]["va_nro_aut"].ToString();
            }

            tb_tex_bus.Focus();

        }
      
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el talonario Modificó
        /// </summary>
        private void fi_sel_fil(int nro_dos)
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

            if(cl_glo_bal.IsNumeric(tb_sel_ecc.Text) ==false)
                res_fun = "El numero de autorizacion de la dosificación no es valido.";
            
            tab_dat = o_ctb007._05(int.Parse(tb_sel_ecc.Text));
            if (tabla.Rows.Count == 0)
            {
                res_fun = "El numero de autorización no se encuentra registrado";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Dosificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_ecc.Focus();
                return false;
            }


            return true;
        }
     
        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            if(cl_glo_bal.IsNumeric(tb_sel_ecc.Text) ==true)
            fi_sel_fil(int.Parse(tb_sel_ecc.Text));
          
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
        public void Fe_act_frm(int ide_doc)
        {
            fi_bus_car();

            if (ide_doc != 0)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_doc.ToString())
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

            //ctb007_03 frm = new ctb007_03();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
      
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat() == false)
                return;

            //ctb007_05 frm = new ctb007_05();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_dat() == false)
                return;

            //ctb007_06 frm = new ctb007_06();
            //cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }

        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Mn_list_tal_Click(object sender, EventArgs e)
        {
            ads004_R01p frm = new ads004_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void mn_cre_ar_Click(object sender, EventArgs e)
        {
            ctb007_02 frm = new ctb007_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
    }
}
