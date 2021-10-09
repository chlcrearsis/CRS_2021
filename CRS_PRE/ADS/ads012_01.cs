using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using CRS_NEG;

namespace CRS_PRE
{
    public partial class ads012_01 : Form
    {
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;
        public MenuStrip men_usr;        // Menú a gestionar
        public string cod_usr;


        //Instancias
        ads007 o_ads007 = new ads007();
        ads012 o_ads012 = new ads012();


        // Variables
        DataTable tab_ads012 = new DataTable();
        DataTable tab_ads007 = new DataTable();

        string va_cod_usr = "";



        public ads012_01()
        {
            InitializeComponent();
        }
      
        private void frm_Load(object sender, EventArgs e)
        {
            //va_cod_usr = cod_usr;
            //tb_ide_usr.Text = cod_usr;
            //lb_nom_apl.Text = frm_pad.Name; // ide_frm;
            
            //obtiene_menu()
        }

        private void Bt_can_cel_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }

        private void Bt_ace_pta_Click(object sender, EventArgs e)
        {
            try
            {
                graba_menu();

                MessageBox.Show("Operación completada exitosamente", "Personaliza menú usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cl_glo_frm.Cerrar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ch_che_tod_CheckedChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < dg_res_ult.RowCount ; i++)
            //{
            //    dg_res_ult.Rows[i].Cells["va_per_mis"].Value = ch_che_tod.Checked;

            //}
        }


        #region METODOS

        public void obtiene_menu(string cod_usr, string ide_frm, MenuStrip men_usr)
        {
           
            va_cod_usr = cod_usr;
            tb_ide_usr.Text = cod_usr;
            lb_nom_apl.Text = ide_frm;

            tab_ads007 = o_ads007.Fe_con_usu(tb_ide_usr.Text);
            tb_nom_usr.Text = tab_ads007.Rows[0]["va_nom_usr"].ToString();

            //// Recrea todas las opciones del menu en el arbol
            foreach (ToolStripMenuItem Raiz in men_usr.Items)
            {

                //Valida que no se quite el boton de atras
                if (Raiz.Text == "&Atras")
                {
                    break;
                }

                //adiciona la opcion del menu al arbol
                Tv_men_usr.Nodes.Add(Raiz.Name, Raiz.Text);

                //verifica que la opcion no este restringida
                tab_ads012 = o_ads012._05(cod_usr, ide_frm, Raiz.Name);

                //si existe = Restringido
                if (tab_ads012.Rows.Count != 0)
                {
                    Tv_men_usr.Nodes[Raiz.Name].Checked = false;
                }
                else
                {
                    //si no existe = Tiene permiso
                    Tv_men_usr.Nodes[Raiz.Name].Checked = true;
                }

                fu_bus_hi1(Raiz);
            }
        }

        private void fu_bus_hi1(ToolStripMenuItem itm_hi1)
        {
            foreach (ToolStripMenuItem hijo1 in itm_hi1.DropDownItems)
            {
                Tv_men_usr.Nodes[itm_hi1.Name].Nodes.Add(hijo1.Name, hijo1.Text);

                //verifica que la opcion no este restringida
                tab_ads012 = o_ads012._05(va_cod_usr, lb_nom_apl.Text, hijo1.Name);

                //si existe = permiso restringido
                if (tab_ads012.Rows.Count != 0)
                {
                    Tv_men_usr.Nodes[itm_hi1.Name].Nodes[hijo1.Name].Checked = false;

                }
                else
                {
                    //si no existe = Tiene permiso
                    Tv_men_usr.Nodes[itm_hi1.Name].Nodes[hijo1.Name].Checked = true;
                }

                if (hijo1.DropDownItems.Count > 0)
                {
                    fu_bus_hi2(itm_hi1, hijo1);
                }

            }
        }

        private void fu_bus_hi2(ToolStripMenuItem padre, ToolStripMenuItem itm_hi2)
        {

            foreach (ToolStripMenuItem hijo2 in itm_hi2.DropDownItems)
            {
                Tv_men_usr.Nodes[padre.Name].Nodes[itm_hi2.Name].Nodes.Add(hijo2.Name, hijo2.Text);

                //verifica que la opcion no este restringida
                tab_ads012 = o_ads012._05(va_cod_usr, lb_nom_apl.Text, hijo2.Name);

                //si existe = permiso restringido
                if (tab_ads012.Rows.Count != 0)
                {
                    Tv_men_usr.Nodes[padre.Name].Nodes[itm_hi2.Name].Nodes[hijo2.Name].Checked = false;
                }
                else
                {
                    //si no existe = Tiene permiso
                    Tv_men_usr.Nodes[padre.Name].Nodes[itm_hi2.Name].Nodes[hijo2.Name].Checked = true;
                }

            }
        }

        public void graba_menu()
        {

            foreach (TreeNode N_raiz in Tv_men_usr.Nodes)
            {
                //## PERMITIDO
                if (Tv_men_usr.Nodes[N_raiz.Name].Checked == true)
                {

                    //si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads012._06(va_cod_usr, lb_nom_apl.Text, N_raiz.Name);

                    //'habilita en el menu
                    //men_usr.Items(N_raiz.Name).Enabled = True

                    //## DENEGADO
                }
                else
                {

                    //si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)

                    //pregunta a la BD si existe
                    tab_ads012 = o_ads012._05(va_cod_usr, lb_nom_apl.Text, N_raiz.Name);

                    //si NO tiene registro, entonces lo quita de las restrinciones en la BD
                    if (tab_ads012.Rows.Count == 0)
                    {
                        o_ads012._02(va_cod_usr, lb_nom_apl.Text, N_raiz.Name);
                    }

                    //'deshabilita en el menu
                    //men_usr.Items(N_raiz.Name).Enabled = False

                }

                fu_gra_hi1(N_raiz);

            }

            if (frm_pad.IsMdiContainer == true)
            {
                frm_pad.fu_ver_mnu(va_cod_usr, frm_pad);
            }
            else
            {
                frm_pad.MdiParent.fu_ver_mnu(va_cod_usr, frm_pad);
            }
        }

        private void fu_gra_hi1(TreeNode itm_hi1)
        {
            foreach (TreeNode N_hijo1 in itm_hi1.Nodes)
            {
                //## PERMITIDO
                if (itm_hi1.Nodes[N_hijo1.Name].Checked == true)
                {

                    //si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads012._06(va_cod_usr, lb_nom_apl.Text, N_hijo1.Name);

                    //## DENEGADO
                }
                else
                {

                    //si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)

                    //pregunta a la BD si existe
                    tab_ads012 = o_ads012._05(va_cod_usr, lb_nom_apl.Text, N_hijo1.Name);

                    //si NO tiene registro, entonces lo quita de las restrinciones en la BD
                    if (tab_ads012.Rows.Count == 0)
                    {
                        o_ads012._02(va_cod_usr, lb_nom_apl.Text, N_hijo1.Name);
                    }


                }

                fu_gra_hi2(N_hijo1);
            }
        }

        private void fu_gra_hi2(TreeNode itm_hi2) //padre As TreeNode, itm_hi2 As TreeNode)
        {
            foreach (TreeNode N_hijo2 in itm_hi2.Nodes)
            {
                //## PERMITIDO
                if (itm_hi2.Nodes[N_hijo2.Name].Checked == true)
                {

                    //si esta tikeado, no deberia tener registro en la BD (permiso permitido)
                    o_ads012._06(va_cod_usr, lb_nom_apl.Text, N_hijo2.Name);

                    //## DENEGADO
                }
                else
                {

                    //si NO esta tikeado, Deberia tener registro en la BD (permiso denegado)

                    //pregunta a la BD si existe
                    tab_ads012 = o_ads012._05(va_cod_usr, lb_nom_apl.Text, N_hijo2.Name);

                    //si NO tiene registro, entonces lo quita de las restrinciones en la BD
                    if (tab_ads012.Rows.Count == 0)
                    {
                        o_ads012._02(va_cod_usr, lb_nom_apl.Text, N_hijo2.Name);
                    }

                    //'deshabilita en el menu
                    //men_usr.Items(N_hijo2.Name).Enabled = False

                }

                // fu_gra_hi2(N_hijo2)

            }

        }
        #endregion






    }
}
