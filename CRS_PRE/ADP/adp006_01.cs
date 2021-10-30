using CRS_NEG;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace CRS_PRE
{
    public partial class adp006_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public dynamic frm_MDI;


        public adp006_01()
        {
            InitializeComponent();
        }

        // instancia
        adp006 o_adp006 = new adp006();

        DataTable Tabla = new DataTable();

        private void frm_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }

        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_cod_per.Text = string.Empty;
            tb_raz_soc.Text = string.Empty;
            tb_tip_doc.Text = string.Empty;
            tb_nro_doc.Text = string.Empty;
            tb_ext_doc.Text = string.Empty;

            // Desplega Datos del Cliente
            tb_cod_per.Text = frm_dat.Rows[0]["va_cod_per"].ToString();
            tb_raz_soc.Text = frm_dat.Rows[0]["va_raz_soc"].ToString();
            tb_tip_doc.Text = frm_dat.Rows[0]["va_tip_doc"].ToString();
            tb_nro_doc.Text = frm_dat.Rows[0]["va_nro_doc"].ToString();
            tb_ext_doc.Text = frm_dat.Rows[0]["va_ext_doc"].ToString();

            fi_bus_car();
        } 

        /// <summary>
        /// Funcion Lista Imagenes Persona
        /// </summary>
        private void fi_bus_car()
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            //
            Tabla = new DataTable();
            Tabla = o_adp006.Fe_lis_ima(int.Parse(tb_cod_per.Text));
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_tip"].Value = Tabla.Rows[i]["va_ide_tip"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_tip"].Value = Tabla.Rows[i]["va_nom_tip"].ToString();
                    dg_res_ult.Rows[i].Cells["va_ext_arc"].Value = Tabla.Rows[i]["va_ext_arc"].ToString();
                    dg_res_ult.Rows[i].Cells["va_tam_arc"].Value = Tabla.Rows[i]["va_tam_arc"].ToString();

                    if (Tabla.Rows[i]["va_ima_per"].ToString() == "S") { 
                        dg_res_ult.Rows[i].Cells["va_ide_tip"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_nom_tip"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_ext_arc"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                        dg_res_ult.Rows[i].Cells["va_tam_arc"].Style.ForeColor = Color.FromArgb(0, 0, 192);
                    }else{
                        dg_res_ult.Rows[i].Cells["va_ide_tip"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_nom_tip"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_ext_arc"].Style.ForeColor = Color.Black;
                        dg_res_ult.Rows[i].Cells["va_tam_arc"].Style.ForeColor = Color.Black;
                    }
                }
                
                fi_con_sel(dg_res_ult.Rows[0].Cells["va_ide_tip"].Value.ToString());
            }
        }

        /// <summary>
        /// Consulta Registro Seleccionado
        /// </summary>
        private void fi_con_sel(string ide_tip)
        {
            // Elimina la Imagen de la Persona
            pb_ima_per.Image = null;
            // Despliega la Imagen del Registro Seleccionado
            Tabla = new DataTable();
            Tabla = o_adp006.Fe_con_ima(int.Parse(tb_cod_per.Text), ide_tip);
            if (Tabla.Rows.Count > 0)
            {
                byte[] byt_ima = new byte[0];
                byt_ima = (byte[])Tabla.Rows[0]["va_img_arc"];
                MemoryStream men_str = new MemoryStream(byt_ima);
                pb_ima_per.Image = Image.FromStream(men_str);
            }
        }

        /// <summary>
        /// Función : Selecciona la fila en el Datagrid
        /// </summary>
        private void fi_sel_fil(string ide_tip)
        {            
            fi_bus_car();

            if (ide_tip != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == ide_tip.ToUpper())
                        {
                            // Despliega la Imagen del Registro Seleccionado
                            fi_con_sel(ide_tip);
                            return;
                        }
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_reg(string sel_ecc)
        {
            string res_fun;
            if (sel_ecc.Trim() == ""){
                res_fun = "El Tipo de Imagen, NO se encuentra registrado";
                MessageBox.Show(res_fun, "Consulta Imagen Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Tabla = new DataTable();
            Tabla = o_adp006.Fe_con_reg(int.Parse(tb_cod_per.Text), sel_ecc);
            if (Tabla.Rows.Count == 0){
                res_fun = "Error al obtener los datos para registrar la Imagen de la Persona";
                MessageBox.Show(res_fun, "Consulta Imagen Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Método para verificar concurrencia de datos para editar
        /// </summary>
        public bool fi_ver_edi(string sel_ecc)
        {
            string res_fun;
            if (sel_ecc.Trim() == ""){
                res_fun = "El Tipo de Imagen, NO se encuentra registrado";
                MessageBox.Show(res_fun, "Consulta Imagen Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Tabla = new DataTable();
            Tabla = o_adp006.Fe_con_ima(int.Parse(tb_cod_per.Text), sel_ecc);
            if (Tabla.Rows.Count == 0){
                res_fun = "La Persona NO tiene definida la imagen (" + sel_ecc + ")";
                MessageBox.Show(res_fun, "Consulta Imagen Persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
       

        #endregion                   


        /// <summary>
        /// Funcion Externa : Actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string ide_tip)
        {           
            fi_bus_car();

            if (ide_tip.ToString() != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString() == ide_tip.ToString())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex = i;
                            // Despliega la Imagen del Registro Seleccionado
                            Tabla = new DataTable();
                            Tabla = o_adp006.Fe_con_ima(int.Parse(tb_cod_per.Text), dg_res_ult.Rows[i].Cells[0].Value.ToString());
                            if (Tabla.Rows.Count > 0) {
                                Byte[] byt_ima = new Byte[0];
                                byt_ima = (byte[])Tabla.Rows[0]["va_img_arc"];
                                MemoryStream men_str = new MemoryStream(byt_ima);
                                pb_ima_per.Image = Image.FromStream(men_str);
                            }                            
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

        private void Mn_nue_reg_Click(object sender, EventArgs e)
        {
            //Verifica concurrencia de datos para registrar            
            string ide_tip = dg_res_ult.Rows[dg_res_ult.CurrentRow.Index].Cells["va_ide_tip"].Value.ToString();
            if (fi_ver_reg(ide_tip) == false)
                return;

            adp006_02 frm = new adp006_02();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }

        private void Mn_mod_ifi_Click(object sender, EventArgs e)
        {
            //Verifica concurrencia de datos para editar            
            string ide_tip = dg_res_ult.Rows[dg_res_ult.CurrentRow.Index].Cells["va_ide_tip"].Value.ToString();
            if (fi_ver_reg(ide_tip) == false)
                return;

            adp006_03 frm = new adp006_03();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
             
        private void Mn_con_sul_Click(object sender, EventArgs e)
        {
            //Verifica concurrencia de datos para editar            
            string ide_tip = dg_res_ult.Rows[dg_res_ult.CurrentRow.Index].Cells["va_ide_tip"].Value.ToString();
            if (fi_ver_reg(ide_tip) == false)
                return;

            adp006_05 frm = new adp006_05();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
        }
        private void Mn_eli_min_Click(object sender, EventArgs e)
        {
            //Verifica concurrencia de datos para eliminar            
            string ide_tip = dg_res_ult.Rows[dg_res_ult.CurrentRow.Index].Cells["va_ide_tip"].Value.ToString();
            if (fi_ver_reg(ide_tip) == false)
                return;

            adp006_06 frm = new adp006_06();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si, Tabla);
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

        private void dg_res_ult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg_res_ult.Rows.Count > 0) {
                fi_con_sel(dg_res_ult.Rows[e.RowIndex].Cells["va_ide_tip"].Value.ToString());
            }
        }

        private void dg_res_ult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg_res_ult.Rows.Count > 0)
            {
                fi_con_sel(dg_res_ult.Rows[e.RowIndex].Cells["va_ide_tip"].Value.ToString());
            }
        }
    }
}
