using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;


namespace CRS_PRE
{
    public partial class adp006_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable Tabla;
        public dynamic frm_MDI;

        string est_bus = "T";

        //Form frm_mdi;
        public adp006_01()
        {
            InitializeComponent();
        }

        // instancia        
        adp007 o_adp007 = new adp007();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            //tb_ide_rut.Text = "";
           
           // cb_prm_bus.SelectedIndex = 0;
            //cb_est_bus.SelectedIndex = 0;

           // fi_bus_car("", cb_prm_bus.SelectedIndex, est_bus);
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
        /// <param name="tex_bus">Texto a buscar</param>
        /// <param name="prm_bus">Parámetros a buscar</param>
        /// <param name="est_bus">Estado a buscar</param>
        private void fi_bus_car(string tex_bus = "", int prm_bus = 0, string est_bus = "T")
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            /*if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            Tabla = o_adp007.Fe_bus_car(tex_bus, prm_bus, est_bus);

            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_rut"].Value = Tabla.Rows[i]["va_ide_rut"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_rut"].Value = Tabla.Rows[i]["va_nom_rut"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_cor"].Value = Tabla.Rows[i]["va_nom_cor"].ToString();

                    if (Tabla.Rows[i]["va_est_ado"].ToString() == "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_ide_rut.Text = Tabla.Rows[0]["va_ide_rut"].ToString();
                lb_nom_rut.Text = Tabla.Rows[0]["va_nom_rut"].ToString();
            }*/

        }

        /// <summary>
        /// Consulta Registro Seleccionado
        /// </summary>
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
           /* if (tb_ide_rut.Text.Trim() == ""){
                lb_nom_rut.Text = "** NO existe";
                return;
            }

            Tabla = o_adp007.Fe_con_rut(int.Parse(tb_ide_rut.Text));
            if (Tabla.Rows.Count == 0){
                lb_nom_rut.Text = "** NO existe";
                return;
            }

            lb_nom_rut.Text = Convert.ToString(Tabla.Rows[0]["va_nom_rut"].ToString());*/
        }

        /// <summary>
        /// Función : Selecciona la fila en el Datagrid
        /// </summary>
        private void fi_sel_fil(string ide_rut)
        {
           /* if (cb_est_bus.SelectedIndex == 0)
                est_bus = "T";
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = "H";
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = "N";

            fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

            if (ide_rut != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_rut.ToUpper())
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
            }*/
        }

        private void fi_sub_baj_fil_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_res_ult.Rows.Count != 0)
            {
                try
                {
                    // Al presionar tecla para ABAJO
                    if (e.KeyData == Keys.Down)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != dg_res_ult.Rows.Count - 1)
                        {
                            // Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index + 1];

                            // Llama a función que actualiza datos en Textbox de Selección
                            fi_fil_act();

                        }
                    }
                    // Al presionar tecla para ARRIBA
                    else if (e.KeyData == Keys.Up)
                    {
                        dg_res_ult.Show();

                        if (dg_res_ult.SelectedRows[0].Index != 0){
                            // Establece el foco en el Datagrid
                            dg_res_ult.CurrentCell = dg_res_ult[0, dg_res_ult.SelectedRows[0].Index - 1];

                            // Llama a función que actualiza datos en Textbox de Selección
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
            //if (dg_res_ult.SelectedRows.Count != 0)
            //{
            //    if (dg_res_ult.SelectedRows[0].Cells[0].Value == null){
            //        tb_ide_rut.Text = "";
            //        lb_nom_rut.Text = "";
            //    }else{
            //        tb_ide_rut.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString().Trim();
            //        lb_nom_rut.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString().Trim();
            //    }
            //}
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi(string sel_ecc)
        { 
            string res_fun = "";
            
            //if(sel_ecc.Trim() == ""){
            //    res_fun = "La Ruta que desea editar, no se encuentra registrado";
            //    MessageBox.Show(res_fun, "Edita Definición de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tb_ide_rut.Focus();
            //    return false;
            //}


            //Tabla = o_adp007.Fe_con_rut(int.Parse(sel_ecc));
            //if (Tabla.Rows.Count == 0)
            //{
            //    res_fun = "La Ruta que desea editar, no se encuentra registrado";
            //    MessageBox.Show(res_fun, "Edita Definición de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tb_ide_rut.Focus();
            //    return false;
            //}

            return true;
        }
        public bool fi_ver_hds(string sel_ecc)
        {
            string res_fun = "";

            //if (sel_ecc.Trim() == ""){
            //    res_fun = "La Ruta que desea editar, no se encuentra registrado";
            //    MessageBox.Show(res_fun, "Edita Definición de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tb_ide_rut.Focus();
            //    return false;
            //}


            //Tabla = o_adp007.Fe_con_rut(int.Parse(sel_ecc));
            //if (Tabla.Rows.Count == 0){
            //    res_fun = "La Ruta que desea editar, no se encuentra registrado";
            //    MessageBox.Show(res_fun, "Edita Definición de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tb_ide_rut.Focus();
            //    return false;
            //}

            return true;
        }
        public bool fi_ver_con(string sel_ecc)
        {
            string res_fun = "";

            //if (sel_ecc.Trim() == ""){
            //    res_fun = "La Ruta que desea editar, no se encuentra registrado";
            //    MessageBox.Show(res_fun, "Edita Definición de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tb_ide_rut.Focus();
            //    return false;
            //}

            //Tabla = o_adp007.Fe_con_rut(int.Parse(sel_ecc));
            //if (Tabla.Rows.Count == 0){
            //    res_fun = "La Ruta que desea editar, no se encuentra registrado";
            //    MessageBox.Show(res_fun, "Edita Definición de Ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    tb_ide_rut.Focus();
            //    return false;
            //}

            return true;
        }

        #endregion

        private void tb_ide_rut_Validated(object sender, EventArgs e){
            //fi_con_sel();
            //if (lb_nom_rut.Text != "** NO existe")
            //{
            //    fi_sel_fil(tb_ide_rut.Text);
            //}
        }

        private void dg_res_ult_SelectionChanged(object sender, EventArgs e){
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


        private void bt_bus_car_Click(object sender, EventArgs e)
        {
            //if (cb_est_bus.SelectedIndex == 0)
            //    est_bus = "T";
            //if (cb_est_bus.SelectedIndex == 1)
            //    est_bus = "H";
            //if (cb_est_bus.SelectedIndex == 2)
            //    est_bus = "N";

            //fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

        }


        /// <summary>
        /// Funcion Externa : Actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(int ide_gru)
        {
         //if (cb_est_bus.SelectedIndex == 0)
         //       est_bus = "T";
         //   if (cb_est_bus.SelectedIndex == 1)
         //       est_bus = "H";
         //   if (cb_est_bus.SelectedIndex == 2)
         //       est_bus = "N";

         //   fi_bus_car(tb_tex_bus.Text, cb_prm_bus.SelectedIndex, est_bus);

         //   if (ide_gru.ToString() != null)
         //   {
         //       try
         //       {
         //           for (int i = 0; i < dg_res_ult.Rows.Count; i++)
         //           {
         //               if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_gru.ToString())
         //               {
         //                   dg_res_ult.Rows[i].Selected = true;
         //                   dg_res_ult.FirstDisplayedScrollingRowIndex = i;

         //                   return;
         //               }
         //           }
         //       }

         //       catch (Exception ex)
         //       {

         //           MessageBox.Show(ex.Message, "Error");
         //       }
         //   }
        }

        private void Mn_nue_reg_Click(object sender, EventArgs e)
        {
            adp007_02 frm = new adp007_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para editar
            //if (fi_ver_edi(tb_ide_rut.Text) == false)
            //    return;

            adp007_03 frm = new adp007_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
       
        private void Mn_hab_des_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para habilitar/deshabilitar
            //if (fi_ver_hds(tb_ide_rut.Text) == false)
            //    return;

            adp007_04 frm = new adp007_04();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            //if (fi_ver_con(tb_ide_rut.Text) == false)
            //    return;

            adp007_05 frm = new adp007_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            // Verifica concurrencia de datos para consultar
            //if (fi_ver_con(tb_ide_rut.Text) == false)
            //    return;

            adp007_06 frm = new adp007_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }

        private void Mn_rep_tip_Click(object sender, EventArgs e)
        {
            adp007_R01p frm = new adp007_R01p();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }

        private void Mn_cer_rar_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }               

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            cl_glo_frm.Cerrar(this);
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cl_glo_frm.Cerrar(this);
        }
    }
}
