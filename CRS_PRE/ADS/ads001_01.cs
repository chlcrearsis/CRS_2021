﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG.ADS;

namespace CRS_PRE.ADS
{
    public partial class ads001_01 : Form
    {

        #region "Mover y cerrar pantalla"

        private int va_coo_pox = 0;
        private int va_coo_poy = 0;
        private bool va_est_ven = false;

        private ToolTip va_tool_tip = new ToolTip();

        private void pn_tit_ulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (va_est_ven)
            {
                this.Left = this.Left + (e.X - va_coo_pox);
                this.Top = this.Top + (e.Y - va_coo_poy);
            }
        }
        private void pn_tit_ulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = true;
                va_coo_pox = e.X;
                va_coo_poy = e.Y;
            }
            Cursor = Cursors.SizeAll;
            cl_glo_frm.Activar(this);
        }
        private void pn_tit_ulo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                va_est_ven = false;
            }
            Cursor = Cursors.Default;
        }


        private void pn_tit_ulo_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pn_tit_ulo_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Activar(this);
        }


        private void pb_min_pan_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pb_min_pan_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pb_cer_pan_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }
        private void mn_cer_rar_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        public dynamic frm_pad;
        public int frm_tip;

        // instancia
        c_ads007 o_ads007 = new c_ads007();

        // Variables
        DataTable tabla = new DataTable();

        public ads001_01()
        {
            InitializeComponent();
        }


        private void ads001_01_Load(object sender, EventArgs e)
        {
            fi_ini_frm();
        }



        #region  [Funciones Internas]
        private void fi_ini_frm()
        {
            tb_sel_bus.Text = "";
            cb_prm_bus.SelectedIndex = 0;
            cb_est_bus.SelectedIndex = 0;
            
            fi_bus_car("", parametro.codigo, estado.Todos);

        }
        protected enum parametro 
        {
            codigo=1, nombre=2
        }
        protected enum estado
        {
            Todos = 0, Habilitado= 1, Deshabilitado=2
        }

        /// <summary>
        /// Funcion interna buscar
        /// </summary>
        /// <param name="ar_tex_bus">Texto a buscar</param>
        /// <param name="ar_prm_bus">Parametro a buscar</param>
        /// <param name="ar_est_bus">Estado a buscar</param>
        private void fi_bus_car(string ar_tex_bus="", parametro ar_prm_bus=0, estado ar_est_bus=0)
        {
            //Limpia Grilla
            dg_res_ult.Rows.Clear();

            tabla = o_ads007.Fe_bus_usu(ar_tex_bus, (int)ar_prm_bus, (int) ar_est_bus);
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count ; i++)
                {
                    dg_res_ult.Rows.Add();
                    dg_res_ult.Rows[i].Cells["va_ide_usr"].Value = tabla.Rows[i]["va_ide_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_nom_usr"].Value = tabla.Rows[i]["va_nom_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_tel_usr"].Value = tabla.Rows[i]["va_tel_usr"].ToString();
                    dg_res_ult.Rows[i].Cells["va_car_usr"].Value = tabla.Rows[i]["va_car_usr"].ToString();
                    if(tabla.Rows[i]["va_est_ado"].ToString()== "H")
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Habilitado";
                    else
                        dg_res_ult.Rows[i].Cells["va_est_ado"].Value = "Deshabilitado";
                }
                tb_sel_bus.Text = tabla.Rows[0]["va_ide_usr"].ToString();
                lb_des_bus.Text = tabla.Rows[0]["va_nom_usr"].ToString();
            }
            
        }
        private void fi_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            if (tb_sel_bus.Text.Trim() == "")
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            tabla = o_ads007.Fe_con_usu(tb_sel_bus.Text);
            if (tabla.Rows.Count == 0)
            {
                lb_des_bus.Text = "** NO existe";
                return;
            }

            lb_des_bus.Text = Convert.ToString(tabla.Rows[0]["va_nom_usr"].ToString());
        }
        /// <summary>
        /// - > Función que selecciona la fila en el Datagrid que el Usuario Modificó
        /// </summary>
        private void fi_sel_fil(string cod_usr)
        {
            parametro prm_bus = new parametro();
            estado  est_bus = new estado();

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = estado.Todos;
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = estado.Habilitado;
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = estado.Deshabilitado;

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);

            if (cod_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_usr.ToUpper())
                        {
                            dg_res_ult.Rows[i].Selected = true;
                            dg_res_ult.FirstDisplayedScrollingRowIndex =  i;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK);
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
                if(dg_res_ult.SelectedRows[0].Cells[0].Value == null)
                {
                    tb_sel_bus.Text = "";
                    lb_des_bus.Text = "";
                }
                else
                {
                    tb_sel_bus.Text = dg_res_ult.SelectedRows[0].Cells[0].Value.ToString();
                    lb_des_bus.Text = dg_res_ult.SelectedRows[0].Cells[1].Value.ToString();
                }
                
            }
        }



        #endregion

        private void Tb_sel_bus_Validated(object sender, EventArgs e)
        {
            fi_con_sel();
            if (lb_des_bus.Text != "** NO existe")
            {
                fi_sel_fil(tb_sel_bus.Text);
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
            parametro prm_bus = new parametro();
            estado est_bus = new estado();

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = estado.Todos;
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = estado.Habilitado;
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = estado.Deshabilitado;

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);

        }


        /// <summary>
        /// Funcion Externa que actualiza la ventana con los datos que tenga, despues de realizar alguna operacion.
        /// </summary>
        public void Fe_act_frm(string cod_usr)
        {
            parametro prm_bus = new parametro();
            estado est_bus = new estado();

            if (cb_prm_bus.SelectedIndex == 0)
                prm_bus = parametro.codigo;
            if (cb_prm_bus.SelectedIndex == 1)
                prm_bus = parametro.nombre;

            if (cb_est_bus.SelectedIndex == 0)
                est_bus = estado.Todos;
            if (cb_est_bus.SelectedIndex == 1)
                est_bus = estado.Habilitado;
            if (cb_est_bus.SelectedIndex == 2)
                est_bus = estado.Deshabilitado;

            fi_bus_car(tb_tex_bus.Text, prm_bus, est_bus);


            if (cod_usr != null)
            {
                try
                {
                    for (int i = 0; i < dg_res_ult.Rows.Count; i++)
                    {
                        if (dg_res_ult.Rows[i].Cells[0].Value.ToString().ToUpper() == cod_usr.ToUpper())
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

        private void M_ads001_01_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            MessageBox.Show(e.ClickedItem.Text, "Menu", MessageBoxButtons.OK);
            switch (e.ClickedItem.Name)
            {
                case "mn_cre_ar":
                    ads007_02 frm = new ads007_02();
                    cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.bloq);
                    break;
                case "mn_edi_tar":

                    break;


                case "mn_cer_rar":
                    cl_glo_frm.Cerrar(this);
                    break;

                default:
                    break;
            }

        }
    }
}
