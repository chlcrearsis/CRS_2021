using System;
using System.Data;
using System.Windows.Forms;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class adp002_03 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        //Instancias
        adp001 o_adp001 = new adp001();
        adp002 o_adp002 = new adp002();
        adp003 o_adp003 = new adp003();
        adp004 o_adp004 = new adp004();
        adp005 o_adp005 = new adp005();
        adp014 o_adp014 = new adp014();
        adp015 o_adp015 = new adp015();
        DataTable Tabla = new DataTable();
        General general = new General();
        string Titulo = "Edita Persona";
        private int vp_cod_ven = 0;
        private int vp_cod_cob = 0;


        public adp002_03()
        {
            InitializeComponent();
        }


        private void frm_Load(object sender, EventArgs e)
        {
            // Limpia los datos en Pantalla
            Fi_lim_cam();

            // Despliega Datos en Pantalla
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString().Trim();
            tb_cod_gru.Text = frm_dat.Rows[0]["va_cod_gru"].ToString().Trim();
            lb_nom_gru.Text = frm_dat.Rows[0]["va_nom_gru"].ToString().Trim();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString().Trim();
            tb_nom_fac.Text = frm_dat.Rows[0]["va_nom_fac"].ToString().Trim();
            tb_ruc_nit.Text = frm_dat.Rows[0]["va_ruc_nit"].ToString().Trim();
            tb_nom_bre.Text = frm_dat.Rows[0]["va_nom_bre"].ToString().Trim();
            tb_ape_pat.Text = frm_dat.Rows[0]["va_ape_pat"].ToString().Trim();
            tb_ape_mat.Text = frm_dat.Rows[0]["va_ape_mat"].ToString().Trim();
            tb_tip_doc.Text = frm_dat.Rows[0]["va_tip_doc"].ToString().Trim();
            tb_nro_doc.Text = frm_dat.Rows[0]["va_nro_doc"].ToString().Trim();
            tb_nro_doc.Text = frm_dat.Rows[0]["va_nro_doc"].ToString().Trim();
            cb_ext_doc.Text = frm_dat.Rows[0]["va_ext_doc"].ToString().Trim();
            tb_tel_per.Text = frm_dat.Rows[0]["va_tel_per"].ToString().Trim();
            tb_tel_cel.Text = frm_dat.Rows[0]["va_cel_ula"].ToString().Trim();
            tb_tel_fij.Text = frm_dat.Rows[0]["va_tel_fij"].ToString().Trim();
            tb_ema_ail.Text = frm_dat.Rows[0]["va_ema_ail"].ToString().Trim();
            tb_dir_pri.Text = frm_dat.Rows[0]["va_dir_pri"].ToString().Trim();
            tb_dir_ent.Text = frm_dat.Rows[0]["va_dir_ent"].ToString().Trim();

            if (frm_dat.Rows[0]["va_tip_per"].ToString() == "P")
                tb_tip_per.Text = "Particular";
            if (frm_dat.Rows[0]["va_tip_per"].ToString() == "E")
                tb_tip_per.Text = "Empresa";

            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "H")
                tb_est_ado.Text = "Habilitado";
            if (frm_dat.Rows[0]["va_est_ado"].ToString() == "N")
                tb_est_ado.Text = "Deshabilitado";

            if (frm_dat.Rows[0]["va_fec_nac"].ToString() != "")                
                tb_fec_nac.Text = frm_dat.Rows[0]["va_fec_nac"].ToString().Substring(0, 10);

            if (frm_dat.Rows[0]["va_sex_per"].ToString() == "H")
                cb_sex_per.Text = "Hombre";
            if (frm_dat.Rows[0]["va_sex_per"].ToString() == "M")
                cb_sex_per.Text = "Hombre";

            vp_cod_ven = int.Parse(frm_dat.Rows[0]["va_cod_ven"].ToString());
            vp_cod_cob = int.Parse(frm_dat.Rows[0]["va_cod_cob"].ToString());

            // Habilita o Deshabilita la extension del documento dependiendo de su definición
            if (tb_tip_doc.Text.CompareTo("") == 0){
                Tabla = new DataTable();
                Tabla = o_adp014.Fe_con_tip(tb_tip_doc.Text);
                if (Tabla.Rows.Count > 0){
                    tb_tip_doc.Text = Tabla.Rows[0]["va_ide_tip"].ToString().Trim();
                    if (Tabla.Rows[0]["va_ext_doc"].ToString().CompareTo("S") == 0){
                        cb_ext_doc.Visible = true;
                    }else{
                        cb_ext_doc.Visible = false;
                    }
                }
            }

            Fi_des_atr();
            Fi_ven_cob();
            tb_raz_soc.Focus();
        }

        /// <summary>
        /// Limpia los Campos en pantalla
        /// </summary>
        private void Fi_lim_cam()
        {
            tb_cod_per.Text = string.Empty;
            tb_cod_gru.Text = string.Empty;
            tb_tip_per.Text = string.Empty;
            tb_est_ado.Text = string.Empty;
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
        }

        /// <summary>
        /// Metodo : Obtiene el Tipo de Documento
        /// </summary>
        /// <param name="tip_doc">ID. Tipo de Documento</param>
        private void Fi_obt_doc(string tip_doc)
        {
            // Valida que el tipo de documento sea DISTINTO a vacio
            if (tip_doc.CompareTo("") == 0){
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
            string ide_atr;
            DataTable TablaA;

            dg_atr_per.Rows.Clear();

            // Obtiene definiciones de Tipo Atributos
            Tabla = new DataTable();
            Tabla = o_adp005.Fe_lis_per(int.Parse(tb_cod_per.Text));

            //Recorre del primer elemento hasta el ultimo elemento
            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                // Obtiene Datos del Tipo Atributo
                ide_tip = Tabla.Rows[i]["va_ide_tip"].ToString().Trim();
                nom_tip = Tabla.Rows[i]["va_nom_tip"].ToString().Trim();
                ide_atr = Tabla.Rows[i]["va_ide_atr"].ToString().Trim();

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
                dg_atr_per.Rows[i].Cells[2].Value = int.Parse(ide_atr);
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
                }else{
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
        private void Fi_ven_cob()
        {
            /* Obtiene Lista de Vendedores */
            Tabla = new DataTable();
            Tabla.Columns.Add("va_ide_ven");
            Tabla.Columns.Add("va_nom_ven");
            Tabla.Rows.Add();
            Tabla.Rows[0][0] = 1;
            Tabla.Rows[0][1] = "José Miguel Peralta";
            Tabla.Rows.Add();
            Tabla.Rows[1][0] = 2;
            Tabla.Rows[1][1] = "Ricardo Flores Yucra";
            Tabla.Rows.Add();
            Tabla.Rows[2][0] = 3;
            Tabla.Rows[2][1] = "Nohemi Gutierrez Llanque";
            Tabla.Rows.Add();
            Tabla.Rows[3][0] = 4;
            Tabla.Rows[3][1] = "Carlos Eduardo Fernandez";
            Tabla.Rows.Add();
            Tabla.Rows[4][0] = 5;
            Tabla.Rows[4][1] = "Luis Miguel Santelices";
            Tabla.Rows.Add();
            Tabla.Rows[5][0] = 6;
            Tabla.Rows[5][1] = "Lidia Patzi Flores";
            Tabla.Rows.Add();
            Tabla.Rows[6][0] = 7;
            Tabla.Rows[6][1] = "Juanito Choque Mamani";

            // Carga la lista de Vendedor
            cb_nom_ven.DataSource = Tabla;
            cb_nom_ven.DisplayMember = "va_nom_ven";
            cb_nom_ven.ValueMember = "va_ide_ven";
            cb_nom_ven.SelectedValue = vp_cod_ven;

            /* Obtiene Lista de Cobradores */
            Tabla = new DataTable();
            Tabla.Columns.Add("va_ide_cob");
            Tabla.Columns.Add("va_nom_cob");
            Tabla.Rows.Add();
            Tabla.Rows[0][0] = 1;
            Tabla.Rows[0][1] = "Juanito Choque Mamani";
            Tabla.Rows.Add();
            Tabla.Rows[1][0] = 2;
            Tabla.Rows[1][1] = "Lidia Patzi Flores";
            Tabla.Rows.Add();
            Tabla.Rows[2][0] = 3;
            Tabla.Rows[2][1] = "Luis Miguel Santelices";
            Tabla.Rows.Add();
            Tabla.Rows[3][0] = 4;
            Tabla.Rows[3][1] = "Carlos Eduardo Fernandez";
            Tabla.Rows.Add();
            Tabla.Rows[4][0] = 5;
            Tabla.Rows[4][1] = "Nohemi Gutierrez Llanque";
            Tabla.Rows.Add();
            Tabla.Rows[5][0] = 6;
            Tabla.Rows[5][1] = "Ricardo Flores Yucra";
            Tabla.Rows.Add();
            Tabla.Rows[6][0] = 7;
            Tabla.Rows[6][1] = "José Miguel Peralta";

            // Carga la lista de Cobrador
            cb_nom_cob.DataSource = Tabla;
            cb_nom_cob.DisplayMember = "va_nom_cob";
            cb_nom_cob.ValueMember = "va_ide_cob";
            cb_nom_cob.SelectedValue = vp_cod_cob;
        }

        /// <summary>
        /// Metodo : Valida datos proporcionados por el usuario
        /// </summary>
        /// <returns></returns>
        protected string Fi_val_dat()
        {          
            // Verificar que la persona ha editar exista y este habilitada
            Tabla = new DataTable();
            Tabla = o_adp002.Fe_con_per(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count == 0){
                tb_cod_gru.Focus();
                return "La Persona NO se encuentra registrado en la Base de Datos";
            }
            if (Tabla.Rows[0]["va_est_ado"].ToString() == "N"){
                tb_cod_gru.Focus();
                return "La Persona se encuentra Deshabilitado";
            }            

            // Verifica RUC/NIT
            long val_num;
            try{
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
                if (cl_glo_bal.IsDateTime(tb_fec_nac.Text) == false){
                    tb_fec_nac.Focus();
                    return "La Fecha de Nacimiento de la Persona DEBE ser una fecha válida";
                }
            }

            // Valida que el tipo de documento no sea vacio o este registrado
            Tabla = new DataTable();
            Tabla = o_adp014.Fe_con_tip(tb_tip_doc.Text.Trim());
            if (Tabla.Rows.Count == 0){
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
            if (tb_ruc_nit.Text.Trim().CompareTo("0") == 0 && tb_ruc_nit.Text.Trim().CompareTo("") != 0)
            {
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
            if (tb_nro_doc.Text.Trim().CompareTo("0") == 0 && tb_tip_doc.Text.Trim().CompareTo("") != 0){
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

        private void bt_bus_tip_Click(object sender, EventArgs e)
        {
            Fi_bus_doc();
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
            if (tb_fec_nac.Text.CompareTo("  /  /") != 0)
            {
                if (cl_glo_bal.IsDateTime(tb_fec_nac.Text) == false)
                {
                    tb_fec_nac.Focus();
                    MessageBox.Show("La Fecha Digitada NO corresponde a una Fecha Válida", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            string msg_val = "";
            DialogResult msg_res;

            // funcion para validar datos
            msg_val = Fi_val_dat();
            if (msg_val != "")
            {
                MessageBox.Show(msg_val, Titulo, MessageBoxButtons.OK);
                return;
            }
            msg_res = MessageBox.Show("Esta seguro de editar la informacion?", "Edita Persona", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (msg_res == DialogResult.OK)
            {
                //Edita persona
                /*o_adp002.Fe_edi_per(int.Parse(tb_cod_per.Text),tb_raz_soc.Text, tb_nom_com.Text,decimal.Parse(tb_nit_per.Text), int.Parse(tb_car_net.Text),
                                    tb_dir_per.Text,tb_tel_per.Text,tb_cel_per.Text,tb_ema_per.Text, int.Parse(tb_cod_ven.Text));
                */MessageBox.Show("Los datos se grabaron correctamente", "Edita Persona", MessageBoxButtons.OK,MessageBoxIcon.Information);

                frm_pad.Fe_act_frm(int.Parse(tb_cod_per.Text));
                cl_glo_frm.Cerrar(this);
            }

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
                    MessageBox.Show(msg_val, Titulo, MessageBoxButtons.OK);
                    return;
                }

                msg_res = MessageBox.Show("Esta seguro de editar la informacion?", Titulo, MessageBoxButtons.OKCancel);
                if (msg_res == DialogResult.OK)
                {
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
                    int cod_ven = int.Parse(cb_nom_ven.SelectedValue.ToString());
                    int cod_cob = int.Parse(cb_nom_cob.SelectedValue.ToString());

                    if (tb_fec_nac.Text.CompareTo("  /  /") == 0)
                        fec_nac = "NULL";
                    else
                        fec_nac = "'" + fec_nac + "'";

                    if (cb_ext_doc.Enabled == false)
                        ext_doc = "";


                    // Registrar Persona
                    o_adp002.Fe_edi_per(cod_per, nom_bre, ape_pat, ape_mat, raz_soc, nom_fac,
                                        ruc_nit, sex_per, fec_nac, tip_doc, nro_doc, ext_doc,
                                        tel_per, cel_ula, tel_fij, dir_pri, dir_ent, ema_ail,
                                        cod_ven, cod_cob, tip_atr, ide_atr);
                    MessageBox.Show("Los datos se grabaron correctamente", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_pad.Fe_act_frm(int.Parse(tb_cod_per.Text));
                    cl_glo_frm.Cerrar(this);
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
