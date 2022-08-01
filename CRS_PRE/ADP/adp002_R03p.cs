using CRS_NEG;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRS_PRE
{
    /**********************************************************************/
    /*      Módulo: ADP - Persona                                         */
    /*  Aplicación: adp002 - Registro Persona                             */
    /*      Opción: Informe R03 - Parametros                              */
    /*       Autor: JEJR - Crearsis             Fecha: 28-07-2022         */
    /**********************************************************************/
    public partial class adp002_R03p : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        // Instancia
        adp001 o_adp001 = new adp001();
        adp002 o_adp002 = new adp002();
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        DataTable Tabla = new DataTable();        

        public adp002_R03p()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {     
            // Desplega Información inicial            
            cb_est_ado.SelectedIndex = 0;
            rb_ord_cod.Checked = true;
            rb_ord_nom.Checked = false;

            // Obtiene Datos del Grupo Inicial y Grupo Final
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_lis_gru("1");
            if (Tabla.Rows.Count > 0)
            {
                tb_gru_ini.Text = Tabla.Rows[0]["va_cod_gru"].ToString();
                lb_dgr_ini.Text = Tabla.Rows[0]["va_nom_gru"].ToString();
                tb_gru_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_cod_gru"].ToString();
                lb_dgr_fin.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_gru"].ToString();
            }
            else
            {
                tb_gru_ini.Text = "0";
                lb_dgr_ini.Text = "...";
                tb_gru_fin.Text = "999";
                lb_dgr_fin.Text = "...";
            }

            // Obtiene el Primer Tipo de Atributo
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_lis_tip("1");
            if (Tabla.Rows.Count > 0)
            {
                tb_ide_ti1.Text = Tabla.Rows[0]["va_ide_tip"].ToString();
                lb_des_ti1.Text = Tabla.Rows[0]["va_nom_tip"].ToString();
                tb_ide_ti2.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_tip"].ToString();
                lb_des_ti2.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_tip"].ToString();
            }
            else
            {
                tb_ide_ti1.Text = "0";
                lb_des_ti1.Text = "...";
                tb_ide_ti2.Text = "0";
                lb_des_ti2.Text = "...";
            }

            // Obtiene Datos del Atributo 1 Inicial y Atributo 1 Final
            if (lb_des_ti1.Text != "...")
            {
                Tabla = new DataTable();
                Tabla = o_adp004.Fe_lis_tip(int.Parse(tb_ide_ti1.Text), "1");
                if (Tabla.Rows.Count > 0)
                {
                    tb_atr_in1.Text = Tabla.Rows[0]["va_ide_atr"].ToString();
                    lb_nat_in1.Text = Tabla.Rows[0]["va_nom_atr"].ToString();
                    tb_atr_fi1.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_atr"].ToString();
                    lb_nat_fi1.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_atr"].ToString();
                }
                else
                {
                    tb_atr_in1.Text = "0";
                    lb_nat_in1.Text = "...";
                    tb_atr_fi1.Text = "999";
                    lb_nat_fi1.Text = "...";
                }
            }

            // Obtiene Datos del Atributo 2 Inicial y Atributo 1 Final
            if (lb_des_ti2.Text != "...")
            {
                Tabla = new DataTable();
                Tabla = o_adp004.Fe_lis_tip(int.Parse(tb_ide_ti2.Text), "1");
                if (Tabla.Rows.Count > 0)
                {
                    tb_atr_in2.Text = Tabla.Rows[0]["va_ide_atr"].ToString();
                    lb_nat_in2.Text = Tabla.Rows[0]["va_nom_atr"].ToString();
                    tb_atr_fi2.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_atr"].ToString();
                    lb_nat_fi2.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_atr"].ToString();
                }
                else
                {
                    tb_atr_in2.Text = "0";
                    lb_nat_in2.Text = "...";
                    tb_atr_fi2.Text = "999";
                    lb_nat_fi2.Text = "...";
                }
            }
        }

        /// <summary>
        /// Metodo : Obtiene el Grupo de Persona
        /// </summary>
        /// <param name="cod_gru">Código Grupo</param>
        /// <param name="ini_fin">Indicador (1=Inicial; 2=Final)</param>
        private void Fi_obt_gru(int cod_gru, int ini_fin)
        {
            // Valida que el codigo del grupo persona sea DISTINTO a cero
            if (cod_gru == 0){
                if (ini_fin == 1) { 
                    tb_gru_ini.Focus();
                    lb_dgr_ini.Text = "...";
                    MessageBox.Show("El Nro. del Grupo Inicial DEBE ser distinto de Cero", Text);
                    return;
                }
                if (ini_fin == 2){
                    tb_gru_fin.Focus();
                    lb_dgr_fin.Text = "...";
                    MessageBox.Show("El Nro. del Grupo Final DEBE ser distinto de Cero", Text);
                    return;
                }
            }

            // Obtiene datos del grupo de persona
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(cod_gru);
            if (Tabla.Rows.Count > 0){
                if (ini_fin == 1){
                    tb_gru_ini.Text = Tabla.Rows[0]["va_cod_gru"].ToString().Trim();
                    lb_dgr_ini.Text = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
                }
                if (ini_fin == 2){
                    tb_gru_fin.Text = Tabla.Rows[0]["va_cod_gru"].ToString().Trim();
                    lb_dgr_fin.Text = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
                }
            }else{
                if (ini_fin == 1){
                    tb_gru_ini.Focus();
                    lb_dgr_ini.Text = "...";
                    MessageBox.Show("El Grupo Inicial NO se encuentra registrado", Text);
                    return;
                }
                if (ini_fin == 2){
                    tb_gru_fin.Focus();
                    lb_dgr_fin.Text = "...";
                    MessageBox.Show("El Grupo Final NO se encuentra registrado", Text);
                    return;
                }
            }            
        }

        /// <summary>
        /// Metodo : Obtiene el Tipo de Atributo
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="ind_tip">Indicador (1=Criterio 1; 2=Criterio 2)</param>
        private void Fi_obt_tip(int ide_tip, int ind_tip)
        {
            // Valida que el ID. Tipo de Atributo sea DISTINTO a cero
            if (ide_tip == 0)
            {
                if (ind_tip == 1)
                {
                    tb_ide_ti1.Focus();
                    lb_des_ti1.Text = "...";
                    MessageBox.Show("El ID. Tipo de Atributo DEBE ser distinto de Cero del Criterio 1", Text);
                    return;
                }
                if (ind_tip == 2)
                {
                    tb_ide_ti2.Focus();
                    lb_des_ti2.Text = "...";
                    MessageBox.Show("El ID. Tipo de Atributo DEBE ser distinto de Cero del Criterio 2", Text);
                    return;
                }
            }

            // Obtiene datos del grupo de persona
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_con_tip(ide_tip);
            if (Tabla.Rows.Count > 0)
            {
                if (ind_tip == 1)
                {
                    tb_ide_ti1.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                    lb_des_ti1.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
                }
                if (ind_tip == 2)
                {
                    tb_ide_ti2.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                    lb_des_ti2.Text = Tabla.Rows[0]["va_nom_tip"].ToString().Trim();
                }

                // Obtiene datos del atributos de persona
                Tabla = new DataTable();
                Tabla = o_adp004.Fe_lis_tip(ide_tip, "1");
                if (Tabla.Rows.Count > 0)
                {
                    if (ind_tip == 1)
                    {
                        tb_atr_in1.Text = Tabla.Rows[0]["va_ide_atr"].ToString().Trim();
                        lb_nat_in1.Text = Tabla.Rows[0]["va_nom_atr"].ToString().Trim();
                        tb_atr_fi1.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_atr"].ToString().Trim();
                        lb_nat_fi1.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_atr"].ToString().Trim();
                    }
                    if (ind_tip == 2)
                    {
                        tb_atr_in2.Text = Tabla.Rows[0]["va_ide_atr"].ToString().Trim();
                        lb_nat_in2.Text = Tabla.Rows[0]["va_nom_atr"].ToString().Trim();
                        tb_atr_fi2.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_ide_atr"].ToString().Trim();
                        lb_nat_fi2.Text = Tabla.Rows[Tabla.Rows.Count - 1]["va_nom_atr"].ToString().Trim();
                    }
                }
            }
            else
            {
                if (ind_tip == 1)
                {
                    tb_ide_ti1.Focus();
                    lb_des_ti1.Text = "...";
                    tb_atr_in1.Text = "0";
                    lb_nat_in1.Text = "...";
                    tb_atr_fi1.Text = "0";
                    lb_nat_fi1.Text = "...";
                    MessageBox.Show("El Tipo de Atributo 1 NO se encuentra registrado", Text);
                    return;
                }
                if (ind_tip == 2)
                {
                    tb_ide_ti2.Focus();
                    lb_des_ti2.Text = "...";
                    tb_atr_in2.Text = "0";
                    lb_nat_in2.Text = "...";
                    tb_atr_fi2.Text = "0";
                    lb_nat_fi2.Text = "...";
                    MessageBox.Show("El Tipo de Atributo 2 NO se encuentra registrado", Text);
                    return;
                }
            }
        }

        /// <summary>
        /// Metodo : Obtiene el Atributo de Persona
        /// </summary>
        /// <param name="ide_tip">ID. Tipo de Atributo</param>
        /// <param name="ide_atr">ID. Atributo Inicial</param>
        /// <param name="ini_fin">Indicador (1=Inicial; 2=Final)</param>
        private void Fi_obt_atr(int ide_tip, int ide_atr, int ini_fin)
        {
            // Valida que el tipo de atributo sea DISTINTO a cero
            if (ide_tip == 0)
            {
                tb_gru_ini.Focus();
                lb_dgr_ini.Text = "...";
                MessageBox.Show("El ID. Tipo de Atributo DEBE ser distinto de Cero", Text);
                return;
            }

            // Valida que el ID. Atributo sea DISTINTO a cero
            if (ide_atr == 0)
            {
                if (ini_fin == 1)
                {
                    tb_atr_in1.Focus();
                    lb_nat_in1.Text = "...";
                    MessageBox.Show("El ID. Atributo Inicial DEBE ser distinto de Cero del Criterio 1", Text);
                    return;
                }
                if (ini_fin == 2)
                {
                    tb_atr_fi1.Focus();
                    lb_nat_fi1.Text = "...";
                    MessageBox.Show("El ID. Atributo Final DEBE ser distinto de Cero  del Criterio 1", Text);
                    return;
                }
                if (ini_fin == 3)
                {
                    tb_atr_in2.Focus();
                    lb_nat_in2.Text = "...";
                    MessageBox.Show("El ID. Atributo Inicial DEBE ser distinto de Cero  del Criterio 2", Text);
                    return;
                }
                if (ini_fin == 4)
                {
                    tb_atr_fi2.Focus();
                    lb_nat_fi2.Text = "...";
                    MessageBox.Show("El ID. Atributo Final DEBE ser distinto de Cero  del Criterio 2", Text);
                    return;
                }
            }

            // Obtiene datos del atributos de persona
            Tabla = new DataTable();
            Tabla = o_adp004.Fe_con_atr(ide_tip, ide_atr);
            if (Tabla.Rows.Count > 0)
            {
                if (ini_fin == 1)
                {
                    tb_atr_in1.Text = Tabla.Rows[0]["va_ide_atr"].ToString().Trim();
                    lb_nat_in1.Text = Tabla.Rows[0]["va_nom_atr"].ToString().Trim();
                }
                if (ini_fin == 2)
                {
                    tb_atr_fi1.Text = Tabla.Rows[0]["va_ide_atr"].ToString().Trim();
                    lb_nat_fi1.Text = Tabla.Rows[0]["va_nom_atr"].ToString().Trim();
                }
                if (ini_fin == 3)
                {
                    tb_atr_in2.Text = Tabla.Rows[0]["va_ide_atr"].ToString().Trim();
                    lb_nat_in2.Text = Tabla.Rows[0]["va_nom_atr"].ToString().Trim();
                }
                if (ini_fin == 4)
                {
                    tb_atr_fi2.Text = Tabla.Rows[0]["va_ide_atr"].ToString().Trim();
                    lb_nat_fi2.Text = Tabla.Rows[0]["va_nom_atr"].ToString().Trim();
                }
            }
            else
            {
                if (ini_fin == 1)
                {
                    tb_atr_in1.Focus();
                    lb_nat_in1.Text = "...";
                    MessageBox.Show("El Atributo Inicial NO se encuentra registrado del Criterio 1", Text);
                    return;
                }
                if (ini_fin == 2)
                {
                    tb_atr_fi1.Focus();
                    lb_nat_fi1.Text = "...";
                    MessageBox.Show("El Atributo Final NO se encuentra registrado  del Criterio 1", Text);
                    return;
                }
                if (ini_fin == 3)
                {
                    tb_atr_in2.Focus();
                    lb_nat_in2.Text = "...";
                    MessageBox.Show("El Atributo Inicial NO se encuentra registrado del Criterio 2", Text);
                    return;
                }
                if (ini_fin == 4)
                {
                    tb_atr_fi2.Focus();
                    lb_nat_fi2.Text = "...";
                    MessageBox.Show("El Atributo Final NO se encuentra registrado  del Criterio 2", Text);
                    return;
                }
            }
        }

        /// <summary>
        /// Metodo : Buscar Grupo de Persona
        /// </summary>
        /// <param name="ini_fin">Indicador (1=Inicial; 2=Final)</param>
        private void Fi_bus_gru(int ini_fin)
        {
            adp001_01 frm = new adp001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                Fi_obt_gru(int.Parse(frm.tb_cod_gru.Text), ini_fin);
            }
        }

        /// <summary>
        /// Metodo : Buscar Tipo de Atributo
        /// <param name="ind_tip">Indicador (1=Criterio 1; 2=Criterio 2)</param>
        /// </summary>
        private void Fi_bus_tip(int ind_tip)
        {
            adp003_01 frm = new adp003_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                Fi_obt_tip(int.Parse(frm.tb_ide_tip.Text), ind_tip);
            }
        }

        /// <summary>
        /// Metodo : Buscar Atributo de Persona
        /// </summary>
        /// <param name="ind_cri">Indicador (1=Criterio 1 Inicial; 2=Criterio 1 Final; 3=Criterio 2 Inicial; 4=Criterio 2 Final)</param>
        private void Fi_bus_atr(int ind_cri)
        {
            adp004_07 frm = new adp004_07();
            // Obtiene el Tipo del atributo Indicador
            if (ind_cri == 1 || ind_cri == 2)
                frm.vp_ide_tip = int.Parse(tb_ide_ti1.Text);
            if (ind_cri == 3 || ind_cri == 4)
                frm.vp_ide_tip = int.Parse(tb_ide_ti2.Text);

            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK)
            {
                Fi_obt_atr(frm.vp_ide_tip, int.Parse(frm.tb_ide_atr.Text.Trim()), ind_cri);
            }
        }

        protected string Fi_val_dat()
        {
            try
            {
                if (tb_gru_ini.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Grupo Inicial está vacio";

                if (tb_gru_fin.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Grupo Final está vacio";

                if (!cl_glo_bal.IsNumeric(tb_gru_ini.Text))
                    return "El Campo del Grupo Inicial NO tiene un formato válido";

                if (!cl_glo_bal.IsNumeric(tb_gru_fin.Text))
                    return "El Campo del Grupo Final NO tiene un formato válido";

                if (int.Parse(tb_gru_ini.Text.Trim()) > int.Parse(tb_gru_fin.Text.Trim()))
                    return "El Grupo Final DEBE ser MAYOR al Grupo Inicial";

                if (tb_ide_ti1.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Criterio 1 está vacio";

                if (tb_atr_in1.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Atributo Inicial del Criterio 1 está vacio";

                if (tb_atr_fi1.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Atributo Final del Criterio 1 está vacio";

                if (!cl_glo_bal.IsNumeric(tb_atr_in1.Text))
                    return "El Campo del Atributo Inicial del Criterio 1 NO tiene un formato válido";

                if (!cl_glo_bal.IsNumeric(tb_atr_fi1.Text))
                    return "El Campo del Atributo Final del Criterio 1 NO tiene un formato válido";

                if (int.Parse(tb_atr_in1.Text.Trim()) > int.Parse(tb_atr_fi1.Text.Trim()))
                    return "El Atributo Final DEBE ser MAYOR al Atributo Inicial del Criterio 1";

                if (tb_ide_ti2.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Criterio 2 está vacio";

                if (tb_atr_in2.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Atributo Inicial del Criterio 2 está vacio";

                if (tb_atr_fi2.Text.Trim().CompareTo("") == 0)
                    return "El Campo del Atributo Final del Criterio 2 está vacio";

                if (!cl_glo_bal.IsNumeric(tb_atr_in2.Text))
                    return "El Campo del Atributo Inicial del Criterio 2 NO tiene un formato válido";

                if (!cl_glo_bal.IsNumeric(tb_atr_fi2.Text))
                    return "El Campo del Atributo Final del Criterio 2 NO tiene un formato válido";

                if (int.Parse(tb_atr_in2.Text.Trim()) > int.Parse(tb_atr_fi2.Text.Trim()))
                    return "El Atributo Final DEBE ser MAYOR al Atributo Inicial del Criterio 2";

                return "OK";
            }
            catch (Exception) {
                return "Los datos proporcionados NO pasaron el proceso de validación.";
            }            
        }

        private void bt_gru_ini_Click(object sender, EventArgs e)
        {
            Fi_bus_gru(1);
        }

        private void bt_gru_fin_Click(object sender, EventArgs e)
        {
            Fi_bus_gru(2);
        }

        private void bt_tip_at1_Click(object sender, EventArgs e)
        {
            Fi_bus_tip(1);
        }

        private void bt_atr_in1_Click(object sender, EventArgs e)
        {
            Fi_bus_atr(1);
        }

        private void bt_atr_fi1_Click(object sender, EventArgs e)
        {
            Fi_bus_atr(2);
        }

        private void bt_tip_at2_Click(object sender, EventArgs e)
        {
            Fi_bus_tip(2);
        }

        private void bt_atr_in2_Click(object sender, EventArgs e)
        {
            Fi_bus_atr(3);
        }

        private void bt_atr_fi2_Click(object sender, EventArgs e)
        {
            Fi_bus_atr(4);
        }

        private void tb_gru_ini_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Grupo Persona
                Fi_bus_gru(1);
            }
        }

        private void tb_gru_fin_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Grupo Persona
                Fi_bus_gru(2);
            }
        }

        private void tb_ide_ti1_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Tipo de Atributo 1
                Fi_bus_tip(1);
            }
        }

        private void tb_atr_in1_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Atributo de Persona
                Fi_bus_atr(1);
            }
        }

        private void tb_atr_fi1_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Atributo de Persona
                Fi_bus_atr(2);
            }
        }

        private void tb_ide_ti2_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Tipo de Atributo 2
                Fi_bus_tip(2);
            }
        }

        private void tb_atr_in2_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Atributo de Persona
                Fi_bus_atr(3);
            }
        }

        private void tb_atr_fi2_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up)
            {
                // Abre la ventana Busca Atributo de Persona
                Fi_bus_atr(4);
            }
        }

        private void tb_gru_ini_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_gru_fin_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_ide_ti1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_atr_in1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_atr_fi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_ide_ti2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_atr_in2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_atr_fi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_gru_ini_Validated(object sender, EventArgs e)
        {            
            try
            {
                Fi_obt_gru(int.Parse(tb_gru_ini.Text), 1);
            }
            catch (Exception ex)
            {
                lb_dgr_ini.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        private void tb_gru_fin_Validated(object sender, EventArgs e)
        {            
            try
            {
                Fi_obt_gru(int.Parse(tb_gru_fin.Text), 2);
            }
            catch (Exception ex)
            {
                lb_dgr_fin.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        private void tb_ide_ti1_Validated(object sender, EventArgs e)
        {            
            try
            {
                Fi_obt_tip(int.Parse(tb_ide_ti1.Text), 1);
            }
            catch (Exception ex)
            {
                lb_des_ti1.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        private void tb_atr_in1_Validated(object sender, EventArgs e)
        {           
            try
            {
                Fi_obt_atr(int.Parse(tb_ide_ti1.Text), int.Parse(tb_atr_in1.Text), 1);
            }
            catch (Exception ex)
            {
                lb_nat_in1.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        private void tb_atr_fi1_Validated(object sender, EventArgs e)
        {           
            try
            {
                Fi_obt_atr(int.Parse(tb_ide_ti1.Text), int.Parse(tb_atr_fi1.Text), 2);
            }
            catch (Exception ex)
            {
                lb_nat_fi1.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        private void tb_ide_ti2_Validated(object sender, EventArgs e)
        {
            try
            {
                Fi_obt_tip(int.Parse(tb_ide_ti2.Text), 2);
            }
            catch (Exception ex)
            {
                lb_des_ti2.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        private void tb_atr_in2_Validated(object sender, EventArgs e)
        {
            try
            {
                Fi_obt_atr(int.Parse(tb_ide_ti2.Text), int.Parse(tb_atr_in2.Text), 3);
            }
            catch (Exception ex)
            {
                lb_nat_in2.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        private void tb_atr_fi2_Validated(object sender, EventArgs e)
        {
            try
            {
                Fi_obt_atr(int.Parse(tb_ide_ti2.Text), int.Parse(tb_atr_fi2.Text), 4);
            }
            catch (Exception ex)
            {
                lb_nat_in2.Text = "...";
                MessageBox.Show("Error : " + ex.Message, Text);
            }
        }

        // Evento Click: Button Aceptar
        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            // funcion para validar datos
            string est_ado = "";
            string ord_dat = "";
            string msg_val = Fi_val_dat();
            if (msg_val != "OK"){
                MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                return;
            }

            // Obtiene filtros del reporte
            int gru_ini = int.Parse(tb_gru_ini.Text.Trim());
            int gru_fin = int.Parse(tb_gru_fin.Text.Trim());
            int ide_ti1 = int.Parse(tb_ide_ti1.Text.Trim());
            int atr_in1 = int.Parse(tb_atr_in1.Text.Trim());
            int atr_fi1 = int.Parse(tb_atr_fi1.Text.Trim());
            int ide_ti2 = int.Parse(tb_ide_ti2.Text.Trim());
            int atr_in2 = int.Parse(tb_atr_in2.Text.Trim());
            int atr_fi2 = int.Parse(tb_atr_fi2.Text.Trim());

            // Obtiene el estado del reporte
            if (cb_est_ado.SelectedIndex == 0)
                est_ado = "T";
            if (cb_est_ado.SelectedIndex == 1)
                est_ado = "H";
            if (cb_est_ado.SelectedIndex == 2)
                est_ado = "N";

            // Obtiene el criterio de ordenamiento
            if (rb_ord_cod.Checked)
                ord_dat = "C";
            if (rb_ord_nom.Checked)
                ord_dat = "N";

            // Obtiene Datos
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_inf_R03(gru_ini, gru_fin, ide_ti1, atr_in1, atr_fi1, ide_ti2, atr_in2, atr_fi2, est_ado, ord_dat);

            // Genera el Informe
            adp002_R03w frm = new adp002_R03w();
            frm.vp_gru_ini = gru_ini.ToString();
            frm.vp_gru_fin = gru_fin.ToString();
            frm.vp_tip_at1 = ide_ti1.ToString();
            frm.vp_atr_in1 = atr_in1.ToString();
            frm.vp_atr_fi1 = atr_fi1.ToString();
            frm.vp_tip_at2 = ide_ti2.ToString();
            frm.vp_atr_in2 = atr_in2.ToString();
            frm.vp_atr_fi2 = atr_fi2.ToString();
            frm.vp_est_ado = est_ado;
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.no, Tabla);
        }

        // Evento Click: Button Cancelar
        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            // Cierra Formulario
            cl_glo_frm.Cerrar(this);
        }        
    }
}
