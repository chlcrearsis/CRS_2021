using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CRS_NEG;
using CRS_PRE.CMR;
using CRS_NEG.INV;
using CRS_NEG.CMR;
using CRS_PRE.ADS;
using CRS_PRE.INV;


namespace CRS_PRE.ADS
{
    public partial class ads022_01 : Form
    {
       


        #region VARIABLES
        public dynamic frm_pad;
        public int frm_tip;
        public DataTable frm_dat;

        //DataTable tabla;
        DataTable vg_str_ucc;
        DataTable tab_ads022;

        int tip_frm = 0;
        int ban_aux = 0;

        #endregion

        #region INSTANCIAS
        

        ads022 o_ads022 = new ads022();
        //_01_mg_glo_bal o_mg_glo_bal = new _01_mg_glo_bal();

        CRS_NEG.General o_mg_glo_bal = new CRS_NEG.General();
        //cl_glo_bal o_mg_glo_bal = new cl_glo_bal();

        #endregion

        #region METODOS
        /// <summary>
        /// -> Metodo que inicializa el formulario
        /// </summary>

        public void fu_ini_frm(int va_tip_frm = 0)
        {
            //** Obtiene el mes y el año actual del servidor
            cb_prm_bus.SelectedIndex = o_mg_glo_bal.Fe_fec_act().Month - 1;
            
            tb_val_año.Minimum = o_mg_glo_bal.Fe_fec_act().Year - 5;
            tb_val_año.Maximum = o_mg_glo_bal.Fe_fec_act().Year + 5;
            tb_val_año.Value = o_mg_glo_bal.Fe_fec_act().Year;

            fu_bus_car(o_mg_glo_bal.Fe_fec_act().Month.ToString(), o_mg_glo_bal.Fe_fec_act().Year);

            tip_frm = va_tip_frm;

            if (tip_frm == 0)
            {
                //gb_ctr_frm.Enabled = false;
            }
            else
            {
                //gb_ctr_frm.Enabled = true;
            }

        }
        /// <summary>
        /// Metodo Weekday
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static int Weekday(DateTime dt, DayOfWeek startOfWeek)
        {
            return (dt.DayOfWeek - startOfWeek + 7) % 7;
        }
        /// <summary>
        /// -> Metodo buscar
        /// </summary>
        /// <param name="val_mes ">Mes a buscar</param>
        public void fu_bus_car(string val_mes, int val_año)
        {
            try
            {
                DateTime fec_ini;
                //** Fecha Inicial
                DateTime fec_fin;
                //** Fecha Final
                int nro_dms = 0;
                //** Numero de dias del mes
                int str_dia = 0;
                //** Nombre del dia

                fl_cal_end_2.Controls.Clear();

                fec_ini = Convert.ToDateTime("01/" + val_mes.ToString() + "/" + val_año.ToString());
                fec_fin = fec_ini;
                fec_fin = fec_ini.AddMonths(1);
                fec_fin = fec_fin.AddDays(-1);

                nro_dms = (fec_fin - fec_ini).Days;
                nro_dms = nro_dms + 1;


                switch (fec_ini.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        str_dia = 1;
                        break;
                    case DayOfWeek.Monday:
                        str_dia = 2;
                        break;
                    case DayOfWeek.Tuesday:
                        str_dia = 3;
                        break;
                    case DayOfWeek.Wednesday:
                        str_dia = 4;
                        break;
                    case DayOfWeek.Thursday:
                        str_dia = 5;
                        break;
                    case DayOfWeek.Friday:
                        str_dia = 6;
                        break;
                    case DayOfWeek.Saturday:
                        str_dia = 7;
                        break;
                }

                //--** Bucle para dias iniciales deshabilitados 
                for (int j = 0; j <= str_dia - 2; j++)
                {
                    Button bot_val = new Button();
                    System.Windows.Forms.Padding val_pad = new System.Windows.Forms.Padding();
                    val_pad.All = 0;
                    var _with1 = bot_val;
                    // .Location = New Point(64, 40)
                    _with1.Size = new Size(72, 70);
                    _with1.Margin = val_pad;
                    _with1.TabIndex = 0;
                    _with1.Text = "T.C" + (Char)13 + "0.00" + (Char)13 + (Char)13 + "---------";
                    _with1.Name = j.ToString();
                    _with1.FlatStyle = FlatStyle.Popup;
                    _with1.Enabled = false;
                    if (j == 0)
                    {
                        _with1.BackColor = Color.Wheat;
                    }
                    fl_cal_end_2.Controls.Add(bot_val);

                    //Button bt_lin_pro = new Button();
                    //bt_lin_pro.Name = j.ToString();
                    //bt_lin_pro.Text = "T.C" + (Char)13 + "0.00" + (Char)13 + (Char)13 + "---------";
                    //bt_lin_pro.Width = 126;
                    //bt_lin_pro.Height = 49;
                    ////bt_lin_pro.Click += new EventHandler(Fi_sel_lin_CLick);
                    ////bt_lin_pro.BackColor = col_lin[i];
                    //bt_lin_pro.ForeColor = Color.White;
                    //bt_lin_pro.Font = new System.Drawing.Font(bt_lin_pro.Font, FontStyle.Bold);

                    //fl_cal_end_2.Controls.Add(bt_lin_pro);

                }

                // ***********************************************************
                //return;
                // ***********************************************************


                //** Obtiene T.C de todo el mes
                tab_ads022 = o_ads022.Fe_fil_tic(int.Parse(val_mes), val_año);

                for (int i = 1; i <= nro_dms; i++)
                {
                    Button bot_val = new Button();
                    DateTime fec_aux;
                    System.Windows.Forms.Padding val_pad = new System.Windows.Forms.Padding();
                    val_pad.All = 0;
                    fec_aux = Convert.ToDateTime(i + "/" + val_mes + "/" + val_año).Date;


                    int ban_dat = 0;

                    for (int j = 0; j <= tab_ads022.Rows.Count - 1; j++)
                    {
                        if (Convert.ToDateTime(tab_ads022.Rows[j]["va_fec_bus"].ToString()) == fec_aux)
                        {
                            var _with2 = bot_val;
                            _with2.Size = new Size(72, 70);
                            _with2.Margin = val_pad;
                            _with2.TabIndex = i;
                            _with2.Text = "T.C" + (Char)13 +
                              tab_ads022.Rows[j]["va_val_bus"].ToString().Trim() + (Char)13 + (Char)13 +
                              Convert.ToDateTime(tab_ads022.Rows[j]["va_fec_bus"]).ToShortDateString();
                            _with2.Name = fec_aux.ToString();
                            _with2.BackColor = Color.Azure;
                            _with2.ForeColor = Color.DarkBlue;
                            _with2.Cursor = Cursors.Hand;

                            //--** Los dias domingos son mintados casi rojos
                            //string dia = "";
                            //dia = Weekday(Weekday(fec_aux, DayOfWeek.Sunday), false, DayOfWeek.Sunday);

                            int nro_dia = Weekday(fec_aux, DayOfWeek.Sunday);

                            if (fec_aux.DayOfWeek == DayOfWeek.Sunday)
                            {
                                _with2.BackColor = Color.Wheat;
                                //.FlatAppearance.BorderColor = Color.Blue
                                //.FlatAppearance.BorderSize = 1
                            }

                            decimal valor = Convert.ToDecimal(tab_ads022.Rows[j]["va_val_bus"].ToString());
                            if (valor == 0)
                            {
                                _with2.FlatStyle = FlatStyle.System;
                            }

                            bot_val.Click += mt_bot_tcd;
                            ban_dat = 1;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                    if (ban_dat == 0)
                    {
                        var _with3 = bot_val;
                        _with3.Size = new Size(72, 70);
                        _with3.Margin = val_pad;
                        _with3.TabIndex = i;
                        _with3.Text = "T.C" + (Char)13 + "0.00" + (Char)13 + (Char)13 + fec_aux.ToShortDateString();
                        _with3.Name = fec_aux.ToString();
                        _with3.Cursor = Cursors.Hand;

                        //--** Los dias domingos son mintados casi rojos
                        if (fec_aux.DayOfWeek == DayOfWeek.Sunday)
                        {
                            _with3.BackColor = Color.Wheat;
                        }
                        else
                        {
                            _with3.FlatStyle = FlatStyle.System;
                        }
                        bot_val.Click += mt_bot_tcd;
                    }
                    //If tab_adm014.Rows.Count Then
                    //    With bot_val
                    //        .Size = New Size(72, 70)
                    //        .Margin = val_pad
                    //        .TabIndex = i
                    //        .Text = "T.C" & Chr(13) & _
                    //           Trim(tab_adm014.Rows(0).Item("va_val_buf")) & Chr(13) & Chr(13) & _
                    //            Trim(tab_adm014.Rows(0).Item("va_fec_buf"))
                    //        .Name = fec_aux
                    //        .BackColor = Color.Azure
                    //        .ForeColor = Color.DarkBlue
                    //        .Cursor = Cursors.Hand
                    //        '.FlatStyle = FlatStyle.System
                    //        '--** Los dias domingos son mintados casi rojos
                    //        Dim dia As String
                    //        dia = WeekdayName(Weekday(fec_aux, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.Sunday)

                    //        Dim nro_dia As Integer
                    //        nro_dia = Weekday(fec_aux, FirstDayOfWeek.Sunday)

                    //        If Weekday(fec_aux, FirstDayOfWeek.Sunday) = 1 Then
                    //            .BackColor = Color.Wheat
                    //            .FlatAppearance.BorderColor = Color.Blue
                    //            .FlatAppearance.BorderSize = 1
                    //        End If


                    //        AddHandler bot_val.Click, AddressOf mt_bot_tcd
                    //    End With

                    //Else
                    //    With bot_val
                    //        .Size = New Size(72, 70)
                    //        .Margin = val_pad
                    //        .TabIndex = i
                    //        .Text = "T.C" & Chr(13) & _
                    //            "0.00" & Chr(13) & Chr(13) & _
                    //            fec_aux
                    //        .Name = fec_aux
                    //        .Cursor = Cursors.Hand

                    //        Dim dia As String
                    //        dia = WeekdayName(Weekday(fec_aux, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.Sunday)

                    //        Dim nro_dia As Integer
                    //        nro_dia = Weekday(fec_aux, FirstDayOfWeek.Sunday)


                    //        '--** Los dias domingos son mintados casi rojos
                    //        If Weekday(fec_aux, FirstDayOfWeek.Sunday) = 1 Then
                    //            .BackColor = Color.Wheat
                    //        Else
                    //            .FlatStyle = FlatStyle.System
                    //        End If
                    //        AddHandler bot_val.Click, AddressOf mt_bot_tcd
                    //    End With

                    //End If

                    fl_cal_end_2.Controls.Add(bot_val);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Metodo activado con el click en el boton de la fecha T.C.
        /// </summary>
        public void mt_bot_tcd(object sender, EventArgs e)
        {
            vg_str_ucc = new DataTable();

            Button bot_fec = (Button)sender;
            DateTime vv_fec_tcd = Convert.ToDateTime(bot_fec.Name);

            vg_str_ucc.Columns.Add("va_fec_tcm");
            vg_str_ucc.Columns.Add("va_val_tcm");

            vg_str_ucc.Rows.Add();
            vg_str_ucc.Rows[0]["va_fec_tcm"] = vv_fec_tcd.ToShortDateString();
            vg_str_ucc.Rows[0]["va_val_tcm"] = 0.0;

            //--** Si es abierta desde el ABM abre la ventana nuevo con el click
            if (tip_frm == 0)
            {
                ads022_02 frm = new ads022_02();
                cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si ,vg_str_ucc);
                
            }
        }
        /// <summary>
        /// -> Consulta seleccion en pantalla
        /// </summary>
        public void fu_con_sel()
        {
            //Verifica que los datos en pantallas sean correctos
            //If Trim(tb_sel_ecc.Text).Length = 0 Then
            //    lb_sel_ecc.Text = "** NO existe"
            //    Exit Sub
            //End If

            //If IsNumeric(tb_sel_ecc.Text) = False Then
            //    lb_sel_ecc.Text = "** NO existe"
            //    Exit Sub
            //End If


            //tabla = o_adm014._05(tb_sel_ecc.Text)
            //If tabla.Rows.Count = 0 Then
            //    lb_sel_ecc.Text = "** NO existe"
            //    Exit Sub
            //End If

            //tb_sel_ecc.Text = tabla.Rows(0).Item("va_cod_rgn")
            //lb_sel_ecc.Text = tabla.Rows(0).Item("va_nom_rgn")

        }
        /// <summary>
        ///-> Metodo para capturar la fila seleccionada
        /// </summary>
        public void fu_fil_act()
        {
            //Dim fila As Integer = dg_res_ult.CurrentCellAddress.Y

            //tb_sel_ecc.Text = dg_res_ult.Rows(fila).Cells("va_cod_rgn").Value
            //lb_sel_ecc.Text = dg_res_ult.Rows(fila).Cells("va_nom_rgn").Value

        }
        /// <summary>
        /// -> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos)
        /// </summary>
        public string fu_ver_dat()
        {
            //'Si aun existe
            //tab_adm014 = o_adm014._05(tb_sel_ecc.Text)
            //If tab_adm014.Rows.Count = 0 Then
            //    Return "La Regional no se encuentra registrada"
            //End If

            return null;
        }

        /// <summary>
        ///-> Verifica datos Antes de mostrar en otra pantalla   (Consistencia de datos y Estado Habilitada)
        /// </summary>
        public string fu_ver_dat2()
        {
            //'Si aun existe
            //tab_adm014 = o_adm014._05(tb_sel_ecc.Text)
            //If tab_adm014.Rows.Count = 0 Then
            //    Return "La Regional no se encuentra registrada"
            //End If

            return null;
        }
        #endregion

        #region EVENTOS

        public ads022_01()
        {
            InitializeComponent();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            fu_ini_frm();
            //LabelX1.ForeColor = Color.Red;

            ban_aux = 1;
        }

        private void bt_can_cel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cb_prm_bus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ban_aux == 1)
            {
                fu_bus_car((cb_prm_bus.SelectedIndex + 1).ToString(), Convert.ToInt32(tb_val_año.Value));
            }
        }

        private void tb_val_año_ValueChanged(object sender, EventArgs e)
        {
            if (ban_aux == 1)
            {
                fu_bus_car((cb_prm_bus.SelectedIndex + 1).ToString(), Convert.ToInt32(tb_val_año.Value));
            }
        }

        private void m_adm022_02b_Click(object sender, EventArgs e)
        {
            ads022_02b frm = new ads022_02b();
            cl_glo_frm.abrir(this, frm, cl_glo_frm.ventana.nada, cl_glo_frm.ctr_btn.si);
        }
        private void m_atr_ass_Click(object sender, EventArgs e)
        {
            cl_glo_frm.Cerrar(this);
        }


        #endregion


    }
}
