using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;
using Microsoft.SqlServer.Types;

namespace CRS_PRE
{
    public partial class adp002_02 : Form
    {

        public dynamic frm_pad;
        public int frm_tip;
        //Instancias
        adp001 o_adp001 = new adp001();
        adp002 o_adp002 = new adp002();
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        adp014 o_adp014 = new adp014();
        adp015 o_adp015 = new adp015();
        cmr014 o_cmr014 = new cmr014();
        DataTable Tabla = new DataTable();
        General general = new General();
        string Titulo = "Nueva Persona";

        public adp002_02()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los campos en pantalla
            Fi_lim_cam();
        }

        /// <summary>
        /// Limpia los Campos en pantalla
        /// </summary>
        private void Fi_lim_cam() {
            tb_cod_gru.Text = string.Empty;
            tb_nro_per.Text = string.Empty;
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_nom_fac.Text = string.Empty;
            tb_ruc_nit.Text = string.Empty;
            tb_nom_bre.Text = string.Empty;
            tb_ape_pat.Text = string.Empty;
            tb_ape_mat.Text = string.Empty;
            tb_tip_doc.Text = string.Empty;
            tb_nro_doc.Text = string.Empty;
            tb_fec_nac.Text = string.Empty;
            tb_tel_per.Text = string.Empty;
            tb_tel_cel.Text = string.Empty;
            tb_tel_fij.Text = string.Empty;
            tb_ema_ail.Text = string.Empty;
            tb_dir_pri.Text = string.Empty;
            tb_dir_ent.Text = string.Empty;
            // Inicializa los datos en pantalla
            Fi_ini_dat();
        }

        /// <summary>
        /// Inicializa Datos en Pantalla
        /// </summary>
        private void Fi_ini_dat() {
            tb_cod_gru.Text = "0";
            tb_nro_per.Text = "0";
            tb_ruc_nit.Text = "0";
            tb_nro_doc.Text = "0";
            cb_ext_doc.Text = "SC";
            cb_tip_per.SelectedIndex = 0;
            cb_sex_per.SelectedIndex = 0;

            // Obtiene el 1er Grupo de Persona
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_lis_gru("1");
            if (Tabla.Rows.Count > 0){
                tb_cod_gru.Text = Tabla.Rows[0]["va_cod_gru"].ToString().Trim();
                lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
            }

            // Obtiene el nro que corresponde
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_obt_cod(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count > 0){
                tb_nro_per.Text = Tabla.Rows[0]["va_nro_per"].ToString().Trim();
            }

            // Obtiene el Tipo de Documento CI
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip("CI");
            if (Tabla.Rows.Count > 0){
                tb_tip_doc.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                if (Tabla.Rows[0]["va_ext_doc"].ToString().CompareTo("S") == 0){
                    cb_ext_doc.Visible = true;
                }else{
                    cb_ext_doc.Visible = false;
                }
            }

            // Si no existe el Tipo Documento CI, propone el primer tipo de documento
            if (tb_tip_doc.Text.CompareTo("") == 0){
                Tabla = new DataTable();
                Tabla = o_adp014.Fe_lis_tip("1");
                if (Tabla.Rows.Count > 0){
                    tb_tip_doc.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                    if (Tabla.Rows[0]["va_ext_doc"].ToString().CompareTo("S") == 0){
                        cb_ext_doc.Visible = true;
                    }else{
                        cb_ext_doc.Visible = false;
                    }
                }
            }

            Fi_obt_cod();
            Fi_des_atr();
            Fi_ven_cob();
            tb_raz_soc.Focus();
        }

        /// <summary>
        /// Metodo : Obtiene el Grupo de Persona
        /// </summary>
        /// <param name="cod_gru"></param>
        private void Fi_obt_gru(int cod_gru) {
            // Valida que el codigo del grupo persona sea DISTINTO a cero
            if (cod_gru == 0) {
                tb_cod_gru.Focus();
                MessageBox.Show( "El Nro. del Grupo de Persona DEBE ser distinto de Cero", Titulo);
                return;
            }

            // Obtiene datos del grupo de persona
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(cod_gru);
            if (Tabla.Rows.Count > 0){
                tb_cod_gru.Text = Tabla.Rows[0]["va_cod_gru"].ToString().Trim();
                lb_nom_gru.Text = Tabla.Rows[0]["va_nom_gru"].ToString().Trim();
            }else{
                tb_cod_gru.Focus();
                MessageBox.Show("El Grupo de Persona NO se encuentra registrado", Titulo);
                return;
            }

            // Obtiene el nro que corresponde
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_obt_cod(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count > 0)
            {
                tb_nro_per.Text = Tabla.Rows[0]["va_nro_per"].ToString().Trim();
            }

            Fi_obt_cod();
        }        


        /// <summary>
        /// Obtiene el Código de la Persona
        /// </summary>
        private void Fi_obt_cod()
        {
            // Valida que el codigo del grupo sea distinto a CERO
            if (tb_cod_gru.Text.Trim() == "0" || tb_cod_gru.Text.Trim() == "00"){                
                tb_nro_per.Text = "0";
                tb_cod_per.Text = "0";
                lb_nom_gru.Text = "";
                return;
            }

            // Valida que el codigo del grupo sea numerico
            int cod_gru;
            int.TryParse(tb_cod_gru.Text, out cod_gru);
            if (cod_gru == 0)
            {
                tb_nro_per.Text = "0";
                tb_cod_per.Text = "0";
                lb_nom_gru.Text = "";
                return;
            }            

            // Valida que el grupo exista
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if (Tabla.Rows.Count == 0){
                tb_nro_per.Text = "0";
                tb_cod_per.Text = "0";
                lb_nom_gru.Text = "";
                return;
            }

            // Valida que el codigo de la persona sea numerico
            int nro_per;
            int.TryParse(tb_nro_per.Text, out nro_per);
            if (nro_per == 0){
                tb_nro_per.Text = "0";
                return;
            }

            // Obtiene el Código de la Persona            
            nro_per = int.Parse(tb_cod_gru.Text) * 10000;
            nro_per = nro_per + int.Parse(tb_nro_per.Text);

            // Despliega Código de la Persona
            tb_cod_per.Text = nro_per.ToString();
        }

        /// <summary>
        /// Metodo : Obtiene el Tipo de Documento
        /// </summary>
        /// <param name="tip_doc">ID. Tipo de Documento</param>
        private void Fi_obt_doc(string tip_doc)
        {
            // Valida que el tipo de documento sea DISTINTO a vacio
            if (tip_doc.CompareTo("") == 0)
            {
                tb_tip_doc.Focus();
                MessageBox.Show("El Tipo de Documento DEBE ser distinto de Vacío", Titulo);
                return;
            }

            // Obtiene datos del grupo de persona
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip(tip_doc);
            if (Tabla.Rows.Count > 0){
                tb_tip_doc.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                if (Tabla.Rows[0]["va_ext_doc"].ToString().CompareTo("S") == 0){
                    cb_ext_doc.Visible = true;
                }else{
                    cb_ext_doc.Visible = false;
                }
            }else{
                tb_tip_doc.Focus();
                MessageBox.Show("El Tipo de Documento NO se encuentra registrado", Titulo);
                return;
            }
        }

        /// <summary>
        /// Desplega Atributos de Persona
        /// </summary>
        private void Fi_des_atr()
        {
            string ide_tip;
            string nom_tip;
            DataTable TablaA;

            dg_atr_per.Rows.Clear();

            // Obtiene definiciones de Tipo Atributos
            Tabla = new DataTable();
            Tabla = o_adp003.Fe_lis_tip("H");

            //Recorre del primer elemento hasta el ultimo elemento
            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                // Obtiene Datos del Tipo Atributo
                ide_tip = Tabla.Rows[i]["va_ide_tip"].ToString();
                nom_tip = Tabla.Rows[i]["va_nom_tip"].ToString();

                // Adiciona un nueva fila
                dg_atr_per.Rows.Add();

                // Carga el tipo atributo en el datagrib
                dg_atr_per.Rows[i].Cells["va_ide_tip"].Value = ide_tip;
                dg_atr_per.Rows[i].Cells["va_nom_tip"].Value = nom_tip;

                // Obtiene datos definiciones de atributos
                TablaA = o_adp004.Fe_lis_tip(int.Parse(ide_tip), "1");

                // Carga los atributos a la tabla temporal
                if (TablaA.Rows.Count > 0){
                    for (int j = 0; j < TablaA.Rows.Count - 1; j++){
                        TablaA.Rows[j]["va_nom_atr"] = TablaA.Rows[j]["va_nom_atr"].ToString().Trim();
                    }
                }                

                // Declara el ComboBoxCell del atributos de persona
                DataGridViewComboBoxCell dg_com_box = new DataGridViewComboBoxCell();
                // Origen de datos
                dg_com_box.DataSource = TablaA;
                // Nombre del campo cuyo valor se devolverá cuando se seleccione un elemento.
                dg_com_box.ValueMember = "va_ide_atr";
                // Nombre del campo cuyos datos se mostraran en la columna
                dg_com_box.DisplayMember = "va_nom_atr";
                // Carga las lista de atributos al combo
                dg_atr_per.Rows[i].Cells[2] = dg_com_box;
                // Selecciona el primer elemento por defecto
                dg_atr_per.Rows[i].Cells[2].Value = int.Parse(TablaA.Rows[0]["va_ide_atr"].ToString());
            }
        }

        /// <summary>
        /// Obtiene la lista del ID. Tipo de Atributo
        /// </summary>
        /// <returns></returns>
        private string Fi_obt_tip() 
        {
            string ide_tip = "";
            for (int i = 0; i < dg_atr_per.Rows.Count; i++){
                if (ide_tip.CompareTo("") == 0){
                    ide_tip = dg_atr_per.Rows[i].Cells["va_ide_tip"].Value.ToString();
                }else {
                    ide_tip += "-" + dg_atr_per.Rows[i].Cells["va_ide_tip"].Value.ToString();
                }
            }
            return ide_tip;
        }

        /// <summary>
        /// Obtiene la lista del ID. Atributo
        /// </summary>
        /// <returns></returns>
        private string Fi_obt_atr()
        {
            string ide_atr = "";
            for (int i = 0; i < dg_atr_per.Rows.Count; i++){
                if (ide_atr.CompareTo("") == 0){
                    ide_atr = dg_atr_per.Rows[i].Cells["va_nom_atr"].Value.ToString();
                }else{
                    ide_atr += "-" + dg_atr_per.Rows[i].Cells["va_nom_atr"].Value.ToString();
                }
            }
            return ide_atr;
        }

        /// <summary>
        /// Desplega Lista de Vendedores y Cobradores
        /// </summary>
        private void Fi_ven_cob() {
            /* Obtiene Lista de Vendedores */
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_lis_tip(1, "H");

            // Carga la lista de Vendedor
            cb_nom_ven.DataSource = Tabla;
            cb_nom_ven.DisplayMember = "va_nom_bre";
            cb_nom_ven.ValueMember = "va_cod_ide";
            cb_nom_ven.SelectedValue = int.Parse(Tabla.Rows[0]["va_cod_ide"].ToString());

            /* Obtiene Lista de Cobradores */
            Tabla = new DataTable();
            Tabla = o_cmr014.Fe_lis_tip(2, "H");           

            // Carga la lista de Cobrador
            cb_nom_cob.DataSource = Tabla;
            cb_nom_cob.DisplayMember = "va_nom_bre";
            cb_nom_cob.ValueMember = "va_cod_ide";
            cb_nom_cob.SelectedValue = int.Parse(Tabla.Rows[1]["va_cod_ide"].ToString());
        }

        /// <summary>
        /// Metodo : Valida datos proporcionados por el usuario
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {
            // Variable usada para verificar datos numericos
            if (tb_cod_gru.Text.Trim() == "0"){
                tb_cod_gru.Focus();
                return "El Nro. del Grupo de Persona DEBE ser distinto de Cero (0)";
            }
            int val;
            int.TryParse(tb_cod_gru.Text.Trim(), out val);
            if (val == 0){
                tb_cod_gru.Focus();
                return "El Código del Grupo de Persona DEBE ser Númerico";
            }
            
            // Verificar Grupo de Persona
            Tabla = new DataTable();
            Tabla = o_adp001.Fe_con_gru(int.Parse(tb_cod_gru.Text));
            if(Tabla.Rows.Count == 0){
                tb_cod_gru.Focus();
                return "El Grupo de Persona NO se encuentra registrado";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N"){
                tb_cod_gru.Focus();
                return "El Grupo de Persona se encuentra Deshabilitado";
            }

            // Verifica que se haya proporcionado el código de Persona
            if (tb_cod_per.Text.Trim() == "0"){
                tb_nro_per.Focus();
                return "DEBE proporcionar el codigo de Persona";
            }

            // Verifica si ya existe otra persona con el mismo codigo
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count > 0){
                tb_nro_per.Focus();
                return "Ya existe otra persona con el mismo código creada en la base de datos";
            }

            // Verifica RUC/NIT
            long val_num;
            try
            {
                val_num = long.Parse(tb_ruc_nit.Text);
            }catch (Exception){
                tb_ruc_nit.Focus();
                return "El RUC/NIT de la Persona DEBE ser un valor numérico";
            }

            // Verifica Nro. Documento
            try{
                val_num = long.Parse(tb_nro_doc.Text);
            }catch (Exception){
                tb_nro_doc.Focus();
                return "El Nro. Documento de la Persona DEBE ser un valor numérico";
            }

            // Verifica que la fecha sea una fecha valida
            if (tb_fec_nac.Text.CompareTo("  /  /") != 0){
                if (cl_glo_bal.IsDateTime(tb_fec_nac.Text) == false) {
                    tb_fec_nac.Focus();
                    return "La Fecha de Nacimiento de la Persona DEBE ser una fecha válida";
                }
            }            

            // Valida que el tipo de documento no sea vacio o este registrado
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip(tb_tip_doc.Text.Trim());
            if (Tabla.Rows.Count == 0) {
                tb_tip_doc.Focus();
                return "El Tipo de Documento NO DEBE estar vacio o el valor que tiene no se encuentra registrado";
            }


            //***************************************************************
            //***                 CAMPOS OBLIGATORIO                      ***
            //***************************************************************
            // Razón Social
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_raz_soc");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_raz_soc.Text.Trim().CompareTo("") == 0){
                tb_raz_soc.Focus();
                return "El campo Razón Social es obligatorio NO DEBE estar vacio";
            }
            // Nombre a Facturar
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_nom_fac");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_nom_fac.Text.Trim().CompareTo("") == 0){
                tb_nom_fac.Focus();
                return "El campo Nombre a Facturar es obligatorio NO DEBE estar vacio";
            }
            // RUC/NIT
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_ruc_nit");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_ruc_nit.Text.Trim().CompareTo("0") == 0){
                tb_ruc_nit.Focus();
                return "El campo RUC/NIT es obligatorio NO DEBE ser CERO";
            }
            // Nombre
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_nom_bre");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_nom_bre.Text.Trim().CompareTo("") == 0){
                tb_nom_bre.Focus();
                return "El campo Nombre es obligatorio NO DEBE estar vacio";
            }
            // Apellido Paterno
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_ape_pat");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_ape_pat.Text.Trim().CompareTo("") == 0){
                tb_ape_pat.Focus();
                return "El campo Apellido Paterno es obligatorio NO DEBE estar vacio";
            }
            // Apellido Materno
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_ape_mat");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_ape_mat.Text.Trim().CompareTo("") == 0){
                tb_ape_mat.Focus();
                return "El campo Apellido Materno es obligatorio NO DEBE estar vacio";
            }
            // Nro. Documento
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_nro_doc");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_nro_doc.Text.Trim().CompareTo("0") == 0){
                tb_nro_doc.Focus();
                return "El campo Nro. Documento es obligatorio NO DEBE estar vacio";
            }
            // Fecha de Nacimiento
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_fec_nac");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_fec_nac.Text.CompareTo("  /  /") == 0){
                tb_fec_nac.Focus();
                return "El campo Fecha de Nacimiento es obligatorio NO DEBE estar vacio";
            }            
            // Telefono Personal
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_tel_per");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_tel_per.Text.Trim().CompareTo("") == 0){
                tb_tel_per.Focus();
                return "El campo Teléfono Personal es obligatorio NO DEBE estar vacio";
            }
            // Telefono Celular
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_cel_ula");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_tel_cel.Text.Trim().CompareTo("") == 0){
                tb_tel_cel.Focus();
                return "El campo Teléfono Celular es obligatorio NO DEBE estar vacio";
            }
            // Teléfono Fijo
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_tel_fij");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_tel_fij.Text.Trim().CompareTo("") == 0){
                tb_tel_fij.Focus();
                return "El campo Teléfono Fijo es obligatorio NO DEBE estar vacio";
            }
            // Email
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_ema_ail");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_ema_ail.Text.Trim().CompareTo("") == 0){
                tb_ema_ail.Focus();
                return "El campo Email es obligatorio NO DEBE estar vacio";
            }
            // Dirección
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_dir_pri");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_dir_pri.Text.Trim().CompareTo("") == 0){
                tb_dir_pri.Focus();
                return "El campo Dirección es obligatorio NO DEBE estar vacio";
            }
            // Dirección de Entrega
            Tabla = new DataTable();
            Tabla = o_adp015.Fe_con_val("va_dir_ent");
            if (Tabla.Rows[0]["va_dat_req"].ToString().CompareTo("S") == 0 &&
                tb_dir_ent.Text.Trim().CompareTo("") == 0){
                tb_dir_ent.Focus();
                return "El campo Dirección de Entrega es obligatorio NO DEBE estar vacio";
            }

            // Verifica que no haya otra persona con esa razon social
            if (tb_raz_soc.Text.Trim().CompareTo("") != 0){
                Tabla = new DataTable();
                Tabla = o_adp002.Fe_con_raz(tb_raz_soc.Text.Trim(), int.Parse(tb_cod_per.Text));
                if (Tabla.Rows.Count > 0){
                    DialogResult res;
                    res = MessageBox.Show("Ya existe otra persona creada con la misma Razón Social, desea registrar de todos modos ?", Titulo, MessageBoxButtons.YesNo);
                    if (res == DialogResult.No){
                        tb_raz_soc.Focus();
                        return "Revise la Razón Social por favor";
                    }
                }
            }

            // Verifica que no haya otra persona con ese RUC/NIT
            if (tb_ruc_nit.Text.Trim().CompareTo("0") != 0 && tb_ruc_nit.Text.Trim().CompareTo("") != 0){
                Tabla = new DataTable();
                Tabla = o_adp002.Fe_con_nit(long.Parse(tb_ruc_nit.Text), int.Parse(tb_cod_per.Text));
                if (Tabla.Rows.Count > 0){
                    DialogResult res;
                    res = MessageBox.Show("Ya existe otra persona creada con el mismo RUC/NIT, desea registrar de todos modos ?", Titulo, MessageBoxButtons.YesNo);
                    if (res == DialogResult.No){
                        tb_ruc_nit.Focus();
                        return "Revise el RUC/NIT por favor";
                    }
                }
            }            

            // Verifica que no haya otra persona con ese mismo Nro. de Documento
            if (tb_nro_doc.Text.Trim().CompareTo("0") != 0 && tb_tip_doc.Text.Trim().CompareTo("") != 0){
                Tabla = new DataTable();
                Tabla = o_adp002.Fe_con_doc(tb_tip_doc.Text.Trim(), long.Parse(tb_nro_doc.Text), int.Parse(tb_cod_per.Text));
                if (Tabla.Rows.Count > 0){
                    DialogResult res;
                    res = MessageBox.Show("Ya existe otra persona creada con el mismo Nro. Documento, desea registrar de todos modos ?", Titulo, MessageBoxButtons.YesNo);
                    if (res == DialogResult.No){
                        tb_nro_doc.Focus();
                        return "Revise el Nro. de Documento por favor";
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Metodo : Buscar Grupo de Persona
        /// </summary>
        private void Fi_bus_gru(){
            adp001_01 frm = new adp001_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                Fi_obt_gru(int.Parse(frm.tb_sel_bus.Text));
            }
        }

        /// <summary>
        /// Metodo : Buscar Tipo Documento
        /// </summary>
        private void Fi_bus_doc()
        {
            adp014_01 frm = new adp014_01();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.modal, cl_glo_frm.ctr_btn.si);

            if (frm.DialogResult == DialogResult.OK){
                Fi_obt_doc(frm.tb_ide_tip.Text);
            }
        }

        private void tb_cod_gru_KeyDown(object sender, KeyEventArgs e)
        {
            // al presionar tecla para ARRIBA
            if (e.KeyData == Keys.Up){
                // Abre la ventana Busca Grupo Persona
                Fi_bus_gru();
            }
        }

        private void tb_cod_gru_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void bt_bus_gru_Click(object sender, EventArgs e)
        {
            Fi_bus_gru();
        }

        private void bt_bus_tip_Click(object sender, EventArgs e)
        {
            Fi_bus_doc();
        }

        private void Tb_cod_gru_Validated(object sender, EventArgs e)
        {
            Fi_obt_gru(int.Parse(tb_cod_gru.Text));
        }

        private void tb_nro_per_Validated(object sender, EventArgs e)
        {
            Fi_obt_cod();
        }

        private void tb_nro_per_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_ruc_nit_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_nro_doc_KeyPress(object sender, KeyPressEventArgs e)
        {
            cl_glo_bal.NotNumeric(e);
        }

        private void tb_fec_nac_Validated(object sender, EventArgs e)
        {
            // Verifica que la fecha sea una fecha valida
            if (tb_fec_nac.Text.CompareTo("  /  /") != 0){
                if (cl_glo_bal.IsDateTime(tb_fec_nac.Text) == false){
                    tb_fec_nac.Focus();
                    MessageBox.Show("La Fecha Digitada NO corresponde a una Fecha Válida", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tb_raz_soc_Validated(object sender, EventArgs e)
        {
            tb_nom_fac.Text = tb_raz_soc.Text;
        }                                         

        private void bt_ace_pta_Click(object sender, EventArgs e)
        {
            DialogResult msg_res;

            try
            {
                // funcion para validar datos
                string msg_val = Fi_val_dat();
                if (msg_val != "")
                {
                    MessageBox.Show(msg_val, "Error", MessageBoxButtons.OK);
                    return;
                }

                msg_res = MessageBox.Show("Esta seguro de registrar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
                    SqlGeography ubi_gps = SqlGeography.Null;
                    string tip_per = cb_tip_per.Text.Substring(0, 1);
                    string nom_bre = tb_nom_bre.Text.Trim();
                    string ape_pat = tb_ape_pat.Text.Trim();
                    string ape_mat = tb_ape_mat.Text.Trim();
                    string raz_soc = tb_raz_soc.Text.Trim();
                    string nom_fac = tb_nom_fac.Text.Trim();
                    string sex_per = cb_sex_per.Text.Substring(0, 1);
                    string fec_nac = tb_fec_nac.Text.Trim();
                    string tip_doc = tb_tip_doc.Text.Trim();
                    string ext_doc = cb_ext_doc.Text.Trim();
                    string tel_per = tb_tel_per.Text.Trim();
                    string cel_ula = tb_tel_cel.Text.Trim();
                    string tel_fij = tb_tel_fij.Text.Trim();
                    string dir_pri = tb_dir_pri.Text.Trim();
                    string dir_ent = tb_dir_ent.Text.Trim();
                    string ema_ail = tb_ema_ail.Text.Trim();
                    string tip_atr = Fi_obt_tip();
                    string ide_atr = Fi_obt_atr();
                      long ruc_nit = long.Parse(tb_ruc_nit.Text);
                      long nro_doc = long.Parse(tb_nro_doc.Text);
                       int cod_per = int.Parse(tb_cod_per.Text);
                       int cod_gru = int.Parse(tb_cod_gru.Text);
                       int cod_ven = int.Parse(cb_nom_ven.SelectedValue.ToString());
                       int cod_cob = int.Parse(cb_nom_cob.SelectedValue.ToString());

                    if (tb_fec_nac.Text.CompareTo("  /  /") == 0)
                        fec_nac = "NULL";
                    else
                        fec_nac = "'" + fec_nac + "'";

                    if (cb_ext_doc.Enabled == false)
                        ext_doc = "";


                    // Registrar Persona
                    o_adp002.Fe_nue_per(cod_per, cod_gru, tip_per, nom_bre, ape_pat, ape_mat, raz_soc,
                                        nom_fac, ruc_nit, sex_per, fec_nac, tip_doc, nro_doc, ext_doc,
                                        tel_per, cel_ula, tel_fij, dir_pri, dir_ent, ema_ail, ubi_gps,
                                        cod_ven, cod_cob, tip_atr, ide_atr);

                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK);
                    frm_pad.Fe_act_frm(int.Parse(tb_cod_per.Text));
                    Fi_lim_cam();
                }
            }catch (Exception ex){
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }        
    }
}
