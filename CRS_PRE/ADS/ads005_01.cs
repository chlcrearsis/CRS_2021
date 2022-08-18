using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    public partial class ads005_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable tab_dat;
        public dynamic frm_MDI;

        public ads005_01()
        {
            InitializeComponent();
        }

        // instancia
        ads016 o_ads016 = new ads016();
        ads005 o_ads005 = new ads005();
        ads001 o_ads001 = new ads001();

        // Variables
        DataTable tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_doc.Text = "";

            // obtiene lista de 
            cb_mod_ulo.DataSource = o_ads001.Fe_lis_mod("1");
            cb_mod_ulo.ValueMember = "va_ide_mod";
            cb_mod_ulo.DisplayMember = "va_nom_mod";

          
            // Obtener listado de gestion 
           
            cb_ges_tio.DataSource = o_ads016.Fe_obt_ges();
            cb_ges_tio.ValueMember = "va_ges_tio";
            cb_ges_tio.DisplayMember = "va_ges_tio";
            
            cb_prm_bus.SelectedIndex = 0;
            cb_ges_tio.SelectedIndex = 0;

            fi_bus_car();
        }

        public enum parametro
        {
            codigo = 1, nombre = 2
        }
        protected enum estado
        {
            Todos = 0, Habilitado = 1, Deshabilitado = 2
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

            tabla = o_ads005.Fe_bus_car(int.Parse(cb_mod_ulo.SelectedValue.ToString()),
                int.Parse(cb_ges_tio.Text), ar_tex_bus, ar_prm_bus);

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = tabla.Rows[i]["va_ide_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nro_tal"].Value = tabla.Rows[i]["va_nro_tal"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tal"].Value = tabla.Rows[i]["va_nom_tal"].ToString();
                    dg_res_ult.Rows[i].Cells["va_ges_tio"].Value = tabla.Rows[i]["va_ges_tio"].ToString();
                    dg_res_ult.Rows[i].Cells["va_con_tad"].Value = tabla.Rows[i]["va_con_tad"].ToString();
                }
                tb_sel_doc.Text = tabla.Rows[0]["va_ide_doc"].ToString();
                tb_sel_tal.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                tb_sel_ano.Text = tabla.Rows[0]["va_ges_tio"].ToString();
                lb_des_bus.Text = tabla.Rows[0]["va_nom_tal"].ToString();
            }

            tb_tex_bus.Focus();

        }
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_doc.Text.Trim() == "" || tb_sel_tal.Text.Trim()=="" || tb_sel_ano.Text =="")
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            tabla = new DataTable();
            tabla = o_ads005.Fe_con_num(tb_sel_doc.Text,int.Parse(tb_sel_tal.Text), int.Parse(cb_ges_tio.Text));

            
         
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
            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_tal"].ToString());
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el talonario Modificó
        /// </summary>
        private void fi_sel_fil(string ide_doc, int nro_tal, int ges_tio)
        {
            fi_bus_car();

            if (ide_doc != null  )
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_doc.ToUpper() && 
                            dg_res_ult.Rows[i].Cells[2].Value.ToString().ToUpper() == nro_tal.ToString() &&
                            dg_res_ult.Rows[i].Cells[5].Value.ToString().ToUpper() == nro_tal.ToString())
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
                    tb_sel_doc.Text = "";
                    tb_sel_tal.Text = "";
                    lb_des_bus.Text = "";
                }
                else
                {
                    tb_sel_doc.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                    tb_sel_tal.Text = dg_res_ult.SelectedRows[0].Cells[2].Value.ToString();
                    lb_des_bus.Text = dg_res_ult.SelectedRows[0].Cells[3].Value.ToString();
                }

            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi()
        {
            string res_fun = "";

            if (tb_sel_doc.Text.Trim() =="")
                res_fun = "La Numeración, no se encuentra registrado";
            
            int val;
            if(tb_sel_tal.Text !="0")
            {
                int.TryParse(tb_sel_tal.Text, out val);
                if(val==0)
                    res_fun = "La Numeración, no se encuentra registrado";

                int.TryParse(tb_sel_ano.Text, out val);
                if (val == 0)
                    res_fun = "La Numeración, no se encuentra registrado";
            }

            if (tb_sel_doc.Text.Trim() == "")
                res_fun = "La Numeración, no se encuentra registrado";

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_doc.Focus();
                return false;
            }



            tab_dat = o_ads005.Fe_con_num(tb_sel_doc.Text, int.Parse(tb_sel_tal.Text), int.Parse(cb_ges_tio.Text));
            if (tabla.Rows.Count == 0)
            {
                res_fun = "La Numeración que desea editar, no se encuentra registrado";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_doc.Focus();
                return false;
            }


            return true;
        }
      
        public bool fi_ver_con()
        {
            string res_fun = "";

            if (tb_sel_doc.Text.Trim() == "")
                res_fun = "La Numeración, no se encuentra registrado";

            int val;
            //int.TryParse(tb_sel_tal.Text, out val);
            //if (val == 0)
            //    res_fun = "La Numeración, no se encuentra registrado";

            if(cl_glo_bal.IsNumeric(tb_sel_tal.Text) == false)
                res_fun = "La Numeración, no es valida";


            int.TryParse(tb_sel_ano.Text, out val);
            if (val == 0)
                res_fun = "La Numeración, no se encuentra registrado";


            if (tb_sel_doc.Text.Trim() == "")
                res_fun = "La Numeración, no se encuentra registrado";

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Error numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_doc.Focus();
                return false;
            }



            if (tb_sel_doc.Text.Trim() == "")
                res_fun = "La Numeración, no se encuentra registrado";

            int.TryParse(tb_sel_tal.Text, out val);
            if (val == 0)
                res_fun = "La Numeración, no se encuentra registrado";

            int.TryParse(tb_sel_ano.Text, out val);
            if (val == 0)
                res_fun = "La Numeración, no se encuentra registrado";


            if (tb_sel_doc.Text.Trim() == "")
                res_fun = "La Numeración, no se encuentra registrado";

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Error numeración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_doc.Focus();
                return false;
            }


            tab_dat = o_ads005.Fe_con_num(tb_sel_doc.Text, int.Parse(tb_sel_tal.Text), int.Parse(cb_ges_tio.Text));
            if (tab_dat.Rows.Count == 0)
            {
                MessageBox.Show("La numeracion ya no se encuentra registrada en la base de datos.", "Consulta numeracion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_doc.Focus();
                return false;
            }

            return true;
        }



        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_des_bus.Text != "** NO existe")
            {
                fi_sel_fil(tb_sel_doc.Text,int.Parse(tb_sel_tal.Text), int.Parse(tb_sel_ano.Text));
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
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
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

        private void Mn_cre_num_Click(object sender, EventArgs e)
        {
            ads005_02 frm = new ads005_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
       
        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            if (fi_ver_edi() == false)
                return;

            ads005_03 frm = new ads005_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
       
      
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con() == false)
                return;

            ads005_05 frm = new ads005_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            if (fi_ver_con() == false)
                return;

            ads005_06 frm = new ads005_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, tab_dat);
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
    }
}
