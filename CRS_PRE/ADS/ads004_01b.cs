using CRS_NEG.ADS;
using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE.ADS
{
    public partial class ads004_01b : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        
        public DataTable frm_dat;
        public dynamic frm_MDI;

        string est_bus = "H";
         
        public ads004_01b()
        {
            InitializeComponent();
        }

        // instancia
        c_ads004 o_ads004 = new c_ads004();
        c_ads001 o_ads001 = new c_ads001();

        // Variables
        DataTable tabla = new DataTable();
        string va_ide_doc_parm = "";
        string va_nom_doc_parm = "";
        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            // Coloca el nombre del documento a buscar en el titulo del frm
            if (frm_dat.Rows.Count > 0)
            {
                va_ide_doc_parm = frm_dat.Rows[0][0].ToString();
                va_nom_doc_parm = frm_dat.Rows[0][1].ToString();
            }

            this.Text = "Busca Talonario del Documento : " + va_ide_doc_parm.ToUpper() + " -> " + va_nom_doc_parm.ToUpper();


            tb_sel_doc.Text = "";
            cb_prm_bus.SelectedIndex = 0;
            cb_prm_bus.Enabled = false;
            fi_bus_car("");

            tb_tex_bus.Focus();
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
        private void fi_bus_car(string ar_tex_bus = "" )
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            tabla = o_ads004.Fe_bus_car_permiso(ar_tex_bus, va_ide_doc_parm);

            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_doc"].Value = tabla.Rows[i]["va_ide_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_doc"].Value = tabla.Rows[i]["va_nom_doc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nro_tal"].Value = tabla.Rows[i]["va_nro_tal"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tal"].Value = tabla.Rows[i]["va_nom_tal"].ToString();
                    if (tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_sel_doc.Text = tabla.Rows[0]["va_ide_doc"].ToString();
                tb_sel_tal.Text = tabla.Rows[0]["va_nro_tal"].ToString();
                lb_des_bus.Text = tabla.Rows[0]["va_nom_tal"].ToString();
            }

            tb_tex_bus.Focus();

        }
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_doc.Text.Trim() == "" || tb_sel_tal.Text.Trim()=="")
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }
        
            tabla = o_ads004.Fe_con_tal(tb_sel_doc.Text,int.Parse(tb_sel_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_tal"].ToString());
        }


        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el talonario Modificó
        /// </summary>
        private void fi_sel_fil(string ide_doc, int nro_tal)
        {
            est_bus = "H";
            fi_bus_car(tb_tex_bus.Text );

            if (ide_doc != null  )
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_doc.ToUpper() && dg_res_ult.Rows[i].Cells[2].Value.ToString().ToUpper() == nro_tal.ToString())
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
            tabla = o_ads004.Fe_con_tal(tb_sel_doc.Text, int.Parse(tb_sel_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                res_fun = "El talonario que desea editar, no se encuentra registrado";
            }

            if (res_fun != "")
            {
                MessageBox.Show(res_fun, "Edita talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_doc.Focus();
                return false;
            }


            return true;
        }
        public bool fi_ver_hds()
        {
            tabla = o_ads004.Fe_con_tal(tb_sel_doc.Text, int.Parse(tb_sel_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("EL talonario no se encuentra registrado en la base de datos.", "Habilita/Deshabilita talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_sel_doc.Focus();
                return false;
            }

            return true;
        }
        public bool fi_ver_con()
        {
            tabla = o_ads004.Fe_con_tal(tb_sel_doc.Text, int.Parse(tb_sel_tal.Text));
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("EL talonario ya no se encuentra registrado en la base de datos.", "Consulta talonario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                fi_sel_fil(tb_sel_doc.Text,int.Parse(tb_sel_tal.Text));
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
        private void dg_res_ult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_bus_car_Click(object sender, EventArgs e)
        {
            fi_bus_car(tb_tex_bus.Text);
            
        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string ide_doc, int nro_tal)
        {
            fi_bus_car(tb_tex_bus.Text);

            if (ide_doc != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_doc.ToUpper() &&
                            dg_res_ult.Rows[i].Cells[2].Value.ToString() == nro_tal.ToString())
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

        private void Mn_cre_tal_Click(object sender, EventArgs e)
        {
            ads004_02 frm = new ads004_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void Mn_cre_tal_num_Click(object sender, EventArgs e)
        {
            ads004_02b frm = new ads004_02b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
      

        private void Mn_cer_rar_Click_1(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }
    }
}
