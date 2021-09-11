using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS_PRE
{
    class cl_glo_bal
    {
        /// <summary>
        /// Verifica que el valor sea Numerico valido
        /// </summary>
        /// <param name="num">Valor a verificar</param>
        /// <returns></returns>
        public static bool IsNumeric(string num)
        {
            try
            {
                int x = Convert.ToInt32(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        /// <summary>
        /// Verifica que el valor sea DECIMAL valido
        /// </summary>
        /// <param name="num">Valor a verificar</param>
        /// <returns></returns>
        public static bool IsDecimal(string num)
        {
            try
            {
                decimal x = Convert.ToDecimal(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// No permite digitar otro caractero que no sea numeros en el key press del control
        /// </summary>
        /// <param name="e"> volor digitado</param>
        public static void NotNumeric( KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// No permite digitar otros caracteres que no sean Decimal en el key press del control
        /// </summary>
        /// <param name="e"> volor digitado</param>
        public static void NotDecimal(KeyPressEventArgs e, string val_tex)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.ToString() == ".")
            {
                
                if(val_tex.Contains(e.KeyChar.ToString()) == true && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                    return;
                }
                else
                    e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }





        #region -> CONVERTIR DE IMAGEN A BYTE Y VICEVERSA
        /// <summary>
        /// Convierte una imagen en byte
        /// </summary>
        /// <param name="imageIn">Imagen a converti</param>
        /// <returns></returns>
        public static byte[] fg_img_byt(Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        /// <summary>
        /// Recupera Array de byte de una imagen y la convierte en imagen
        /// </summary>
        /// <param name="byteArrayIn">Array de byte a convertir en image</param>
        /// <returns></returns>
        public static Image fg_byt_img(byte[] byteArrayIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        #endregion





        // ** CODIGO DE CONTROL 
        #region VÁLIDAS PARA OBTENER CCF

        static int contador = 0;

        static string formato(string valor)
        {
            string cod = "";

            if (valor.Length == 1)
            {
                cod = "0" + valor;
            }
            else
            {
                cod = valor;
            }

            return cod;
        }

        static string sub_string(string va_lor, int indice, int cuantos)
        {
            indice--;
            string res_ult = "";

            if (indice > va_lor.Length)
            {
                res_ult = "";
            }
            else if (cuantos > (va_lor.Length - indice))
            {
                cuantos = va_lor.Length - indice;
                res_ult = va_lor.Substring(indice, cuantos);
            }
            else
            {
                res_ult = va_lor.Substring(indice, cuantos);
            }

            return res_ult;
        }


        public static string FE_obt_ccf(string ar_num_aut, string ar_num_fac, string ar_nit_cli,
                          DateTime ar_fec_fac, decimal ar_mto_fac, string ar_lla_ve)
        {
            string va_num_fax, va_nit_clx, va_fec_fax, va_mto_fax;
            string va_num_aut, va_num_fac, va_nit_cli, va_fec_fac, va_mto_fac;
            string va_fec_tem;      //Fecha temporal para convertir en formato estring
            string va_sum_tot;      //Suma de todos los campos con los 2 digitos de verificacion
            string va_5dg_obt;      //5 digitos de verificacion obtenidos en vase a la sumatoria total
            string va_sum_vff;      //la suma total incluido 5 digitos de verificacion

            va_fec_tem = Convert.ToDateTime(ar_fec_fac).Year.ToString();
            va_fec_tem += formato(Convert.ToDateTime(ar_fec_fac).Month.ToString());
            va_fec_tem += formato(Convert.ToDateTime(ar_fec_fac).Day.ToString());


            //PASO #1
            //Obtener y concatenar consecutivamente 2 dígitos Verhoeff al final de los siguientes datos: Número Factura, NIT ' CI del
            //Cliente, Fecha de la Transacción y Monto de la Transacción. Posteriormente hallar la sumatoria de los datos obtenidos y
            //sobre este resultado generar consecutivamente 5 dígitos Verhoeff. Para efectos de Verhoeff, tomar en cuenta el 0(cero)
            //como cualquier otro número, aún cuando este se encuentre a la izquierda de la cifra. 


            //-- Obtiene los 2 dijitos verificadores NUMERO DE FACTURA
            va_num_fax = ar_num_fac + ObtenerVerhoeff(ar_num_fac);
            va_num_fax = va_num_fax + ObtenerVerhoeff(va_num_fax);

            //-- Obtiene los 2 dijitos verificadores NIT DEL CLIENTE
            va_nit_clx = ar_nit_cli + ObtenerVerhoeff(ar_nit_cli);
            va_nit_clx = va_nit_clx + ObtenerVerhoeff(va_nit_clx);

            //-- Obtiene los 2 dijitos verificadores FECHA DE LA FACTURA
            va_fec_fax = va_fec_tem + ObtenerVerhoeff(va_fec_tem);
            va_fec_fax = va_fec_fax + ObtenerVerhoeff(va_fec_fax);


            //redondeamos los decimales del MONTO. si el decimal es 5 redondeara al su inmediato superior 
            ar_mto_fac = Math.Round(ar_mto_fac, 0, MidpointRounding.AwayFromZero);

            //-- Obtiene los 2 digitos verificadores MONTO DE LA FACTURA
            va_mto_fax = ar_mto_fac.ToString() + ObtenerVerhoeff(ar_mto_fac.ToString());
            va_mto_fax = va_mto_fax + ObtenerVerhoeff(va_mto_fax);

            //--Realizar la sumatoria de los nuevos numero con sus respectivos 2 digitos adicionados
            va_sum_tot = Convert.ToString(Convert.ToInt64(va_num_fax) + Convert.ToInt64(va_nit_clx) + Convert.ToInt64(va_fec_fax) + Convert.ToInt64(va_mto_fax));
            va_sum_vff = va_sum_tot;

            //inicializa variable que contiene los 5 digitos en base a la sumatoria total
            va_5dg_obt = "";

            //Adiciona 5 dígitos de verificación a la suma total
            for (int i = 1; i <= 5; i++)
            {
                va_5dg_obt += ObtenerVerhoeff(va_sum_vff);//Almacéna solo los 5 digitos de verificacion obtenidos en base a la sumatoria total
                va_sum_vff += ObtenerVerhoeff(va_sum_vff);//Almacéna la sumatoria total concatenada con los 5 digitos de verificacion
            }
            //#####################################################################################################################


            //#####################################################################################################################
            //# PASO #2
            //Tomando cada uno de los 5 dígitos Verhoeff obtenidos, recuperar de la Llave de Dosificación 5 cadenas adyacentes, cada
            //una con un largo definido por el dígito Verhoeff correspondiente más 1. Concatenar la primera cadena obtenida al final del
            //dato relacionado al Número de Autorización; la segunda al Número de factura; la tercera al NIT ' CI del Cliente; la cuarta a
            //la Fecha de la Transacción y la quinta al Monto de la Transacción.

            //Obtiene 5 digitos Verhoeff
            string va_pri_dvi, va_seg_dvi, va_ter_dvi, va_cua_dvi, va_qui_dvi, va_lla_dos, va_con_ion;
            object va_cad_uno, va_cad_dos, va_cad_tre, va_cad_cua, va_cad_cin;
            int va_pos_sig;

            //obtiene primera cadena adyacente
            va_pri_dvi = Convert.ToString(Convert.ToInt32(sub_string(va_5dg_obt, 1, 1)) + 1);    // 1er. digito verhoeff + 1
            va_cad_uno = sub_string(ar_lla_ve, 1, Convert.ToInt32(va_pri_dvi));
            va_pos_sig = Convert.ToInt32(va_pri_dvi) + 1;

            //Obtiene segunda cadena adyacente
            va_seg_dvi = Convert.ToString(Convert.ToInt32(sub_string(va_5dg_obt, 2, 1)) + 1);    //2do. digito verhoeff + 1
            va_cad_dos = sub_string(ar_lla_ve, va_pos_sig, Convert.ToInt32(va_seg_dvi));
            va_pos_sig += Convert.ToInt32(va_seg_dvi);

            //Obtiene tercera cadena adyacente
            va_ter_dvi = Convert.ToString(Convert.ToInt32(sub_string(va_5dg_obt, 3, 1)) + 1);    //3er. digito verhoeff + 1
            va_cad_tre = sub_string(ar_lla_ve, va_pos_sig, Convert.ToInt32(va_ter_dvi));
            va_pos_sig += Convert.ToInt32(va_ter_dvi);

            //Obtiene cuarta cadena adyacente
            va_cua_dvi = Convert.ToString(Convert.ToInt32(sub_string(va_5dg_obt, 4, 1)) + 1);    //4to. digito verhoeff + 1
            va_cad_cua = sub_string(ar_lla_ve, va_pos_sig, Convert.ToInt32(va_cua_dvi));
            va_pos_sig += Convert.ToInt32(va_cua_dvi);

            //Obtiene quinta cadena adyacente
            va_qui_dvi = Convert.ToString(Convert.ToInt32(sub_string(va_5dg_obt, 5, 1)) + 1);    //5to. digito verhoeff + 1
            va_cad_cin = sub_string(ar_lla_ve, va_pos_sig, Convert.ToInt32(va_qui_dvi));
            va_pos_sig += Convert.ToInt32(va_qui_dvi);



            //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ CONCAENA $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
            //' Concatena la cadena 1 al numero de autorizacion
            va_num_aut = ar_num_aut + va_cad_uno;

            //' Concatena la cadena 2 al numero de factura
            va_num_fac = va_num_fax + va_cad_dos;

            //' Concatena la cadena 3 al numero de NIT ' CI
            va_nit_cli = va_nit_clx + va_cad_tre;

            //' Concatena la cadena 4 a la fecha de la factura
            va_fec_fac = va_fec_fax + va_cad_cua;

            //' Concatena la cadena 5 al monto de la factura
            va_mto_fac = va_mto_fax + va_cad_cin;



            //# PASO #3
            //llamo a la funcion AllegedRC4 con los parametros texto  key
            //Aplicar el AllegedRC4 a la cadena conformada por la concatenación de todos los datos anteriores, utilizando como llave la
            //concatenación de la Llave de Dosificación y los 5 dígitos Verhoeff generados previamente.
            //' concatena la llave mas los 5 digitos obtenidos

            //'concatena las 5 cadenas previas
            va_con_ion = va_num_aut + va_num_fac + va_nit_cli + va_fec_fac + va_mto_fac;



            va_lla_dos = ar_lla_ve + va_5dg_obt;
            //###################################################################


            string mensajeCifrado = AllegedRC4(va_con_ion, va_lla_dos);


            //# PASO #4
            //        Obtener la sumatoria total de los valores ASCII de todos los caracteres de la cadena resultante del paso anterior, además,
            //calcular 5 sumatorias parciales de los ASCII de ciertos caracteres de la misma cadena, de acuerdo al siguiente criterio: La
            //primera sumatoria parcial tomará las posiciones 1, 6, 11, 16, 21, etc.; la segunda 2, 7, 12, 17, 22, etc.; la tercera 3, 8, 13,

            //18, 23, etc.; la cuarta 4, 9, 14, 19, 24,etc. y la quinta 5, 10, 15, 20, 25, etc.
            int ST, SP1, SP2, SP3, SP4, SP5; //sumas para las scii
            int Suma, S1, S2, S3, S4, S5; //Variables para la sumaoria total
            int ST1, ST2, ST3, ST4, ST5; //Variables de cada digio VERHOEF (mas) 1


            // Obtiene la sumatoria total los valores ASCII de la cadena generada
            ST = 0;
            for (int va_ind_cad = 1; va_ind_cad <= mensajeCifrado.Length; va_ind_cad++)
            {
                ST = ST + (int)Convert.ToChar(sub_string(mensajeCifrado, va_ind_cad, 1));
            }

            //' Obtiene primera suma parcial
            SP1 = 0;
            for (int va_ind_cad = 1; va_ind_cad <= mensajeCifrado.Length; va_ind_cad += 5)
            {
                SP1 = SP1 + Convert.ToInt32(Convert.ToChar(sub_string(mensajeCifrado, va_ind_cad, 1)));
            }

            //' Obtiene segunda suma parcial
            SP2 = 0;
            for (int va_ind_cad = 2; va_ind_cad <= mensajeCifrado.Length; va_ind_cad += 5)
            {
                SP2 = SP2 + Convert.ToInt32(Convert.ToChar(sub_string(mensajeCifrado, va_ind_cad, 1)));
            }

            //' Obtiene tercera suma parcial
            SP3 = 0;
            for (int va_ind_cad = 3; va_ind_cad <= mensajeCifrado.Length; va_ind_cad += 5)
            {
                SP3 = SP3 + Convert.ToInt32(Convert.ToChar(sub_string(mensajeCifrado, va_ind_cad, 1)));
            }

            //' Obtiene cuarta suma parcial
            SP4 = 0;
            for (int va_ind_cad = 4; va_ind_cad <= mensajeCifrado.Length; va_ind_cad += 5)
            {
                SP4 = SP4 + Convert.ToInt32(Convert.ToChar(sub_string(mensajeCifrado, va_ind_cad, 1)));
            }

            //' Obtiene quinta suma parcial
            SP5 = 0;
            for (int va_ind_cad = 5; va_ind_cad <= mensajeCifrado.Length; va_ind_cad += 5)
            {
                SP5 = SP5 + Convert.ToInt32(Convert.ToChar(sub_string(mensajeCifrado, va_ind_cad, 1)));
            }



            //# PASO #5
            //##############################################################################################
            //Obtener las multiplicaciones entre la sumatoria total y cada una de las sumatorias parciales. Dividir cada uno de los
            //resultados obtenidos entre el dígito Verhoeff correspondiente más 1, el resultado deberá ser truncado. Finalmente obtener
            //la sumatoria de todos los resultados y aplicar Base64.
            //##############################################################################################
            S1 = ST * SP1;
            S2 = ST * SP2;
            S3 = ST * SP3;
            S4 = ST * SP4;
            S5 = ST * SP5;


            ST1 = 1 + Convert.ToInt32(sub_string(va_5dg_obt, 1, 1));
            ST2 = 1 + Convert.ToInt32(sub_string(va_5dg_obt, 2, 1));
            ST3 = 1 + Convert.ToInt32(sub_string(va_5dg_obt, 3, 1));
            ST4 = 1 + Convert.ToInt32(sub_string(va_5dg_obt, 4, 1));
            ST5 = 1 + Convert.ToInt32(sub_string(va_5dg_obt, 5, 1));

            int SV1, SV2, SV3, SV4, SV5;
            SV1 = (S1 / ST1);
            SV2 = (S2 / ST2);
            SV3 = (S3 / ST3);
            SV4 = (S4 / ST4);
            SV5 = (S5 / ST5);


            Suma = SV1 + SV2 + SV3 + SV4 + SV5;
            //Return MsgVox(suma)
            string palabra = base64(Suma);
            //# PASO #6
            //########################################################################################
            //        Aplicar el AllegedRC4 a la anterior expresión obtenida, utilizando como llave la concatenación de la Llave de
            //Dosificación y los 5 dígitos Verhoeff generados anteriormente.
            //#########################################################################################
            string cadena_cod_con;
            string va_cod_control = AllegedRC4(palabra, va_lla_dos);

            //quita el primer guion del mensajecifrado muestra el resultado del cr4
            cadena_cod_con = sub_string(va_cod_control, 2, va_cod_control.Length - 1);

            return cadena_cod_con;

        }


        static string base64(int numero)
        {
            string Diccionario;
            int Cociente;
            int Resto;
            string Palabra;

            Diccionario = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";
            Cociente = 1;
            Palabra = "";


            while (Cociente > 0)
            {
                Cociente = numero / 64;
                Resto = numero % 64;
                Palabra = Diccionario[Resto] + Palabra;
                numero = Cociente;
            }
            return Palabra;

        }


        static string AllegedRC4(string mensaje, string key)
        {
            int[] state = new int[257];
            int x, y;
            int Index1, Index2;
            int NMen, I;
            string mensajeSifrado = "";
            string mensajeSifrado1 = "";
            x = 0;
            y = 0;
            Index1 = 0;
            Index2 = 0;

            for (I = 0; I <= 255; I++)
            {
                state[I] = I;
            }

            for (I = 0; I <= 255; I++)
            {

                Index2 = (Convert.ToInt32(Convert.ToChar(sub_string(key, Index1 + 1, 1)) + state[I] + Index2)) % 256;

                object temp = state[Index2];
                state[Index2] = state[I];
                state[I] = Convert.ToInt32(temp);

                Index1 = (Index1 + 1) % key.Length;
            }

            for (I = 0; I < mensaje.Length; I++)
            {
                x = (x + 1) % 256;
                y = (state[x] + y) % 256;

                object temp = state[y];
                state[y] = state[x];
                state[x] = (int)temp;

                NMen = Convert.ToInt32(Convert.ToChar(sub_string(mensaje, I + 1, 1))) ^ state[(state[x] + state[y]) % 256];
                //mensajecifrado1 muestra el resultado del cr4 sin guion
                mensajeSifrado1 = mensajeSifrado1 + formato(String.Format("{0:X}", NMen));
                //mensajecifrado muestra el resultado del cr4 con guion
                mensajeSifrado = mensajeSifrado + "-" + formato(String.Format("{0:X}", NMen));
            }

            if (contador == 1)
            {
                contador = 0;
                return mensajeSifrado;
            }
            else
            {
                contador = 1;
                return mensajeSifrado1;
            }
        }


        static int ObtenerVerhoeff(string ar_ci_fra)
        {
            int[,] va_mat_mul = new int[11, 11];        //MATRIZ DE MULTIPLICACIONES
            int[,] va_mat_per = new int[9, 11];     //MATRIZ DE PERMUTACIONES
            int[] va_mat_inv = new int[11];     //MATRIZ DE INVERCION
            string[] va_num_inv = new string[256];      //MATRIZ QUE GUARDA EL NUMERO INVERTIDO(UN DIGITO EN CADA POSICION)

            int va_chk_chk;
            int va_tam_cad;     //TAMAÑO DE UNA CADENA


            //###############################################################################
            va_mat_mul[0, 0] = 0;
            va_mat_mul[0, 1] = 1;
            va_mat_mul[0, 2] = 2;
            va_mat_mul[0, 3] = 3;
            va_mat_mul[0, 4] = 4;
            va_mat_mul[0, 5] = 5;
            va_mat_mul[0, 6] = 6;
            va_mat_mul[0, 7] = 7;
            va_mat_mul[0, 8] = 8;
            va_mat_mul[0, 9] = 9;

            va_mat_mul[1, 0] = 1;
            va_mat_mul[1, 1] = 2;
            va_mat_mul[1, 2] = 3;
            va_mat_mul[1, 3] = 4;
            va_mat_mul[1, 4] = 0;
            va_mat_mul[1, 5] = 6;
            va_mat_mul[1, 6] = 7;
            va_mat_mul[1, 7] = 8;
            va_mat_mul[1, 8] = 9;
            va_mat_mul[1, 9] = 5;

            va_mat_mul[2, 0] = 2;
            va_mat_mul[2, 1] = 3;
            va_mat_mul[2, 2] = 4;
            va_mat_mul[2, 3] = 0;
            va_mat_mul[2, 4] = 1;
            va_mat_mul[2, 5] = 7;
            va_mat_mul[2, 6] = 8;
            va_mat_mul[2, 7] = 9;
            va_mat_mul[2, 8] = 5;
            va_mat_mul[2, 9] = 6;

            va_mat_mul[3, 0] = 3;
            va_mat_mul[3, 1] = 4;
            va_mat_mul[3, 2] = 0;
            va_mat_mul[3, 3] = 1;
            va_mat_mul[3, 4] = 2;
            va_mat_mul[3, 5] = 8;
            va_mat_mul[3, 6] = 9;
            va_mat_mul[3, 7] = 5;
            va_mat_mul[3, 8] = 6;
            va_mat_mul[3, 9] = 7;

            va_mat_mul[4, 0] = 4;
            va_mat_mul[4, 1] = 0;
            va_mat_mul[4, 2] = 1;
            va_mat_mul[4, 3] = 2;
            va_mat_mul[4, 4] = 3;
            va_mat_mul[4, 5] = 9;
            va_mat_mul[4, 6] = 5;
            va_mat_mul[4, 7] = 6;
            va_mat_mul[4, 8] = 7;
            va_mat_mul[4, 9] = 8;

            va_mat_mul[5, 0] = 5;
            va_mat_mul[5, 1] = 9;
            va_mat_mul[5, 2] = 8;
            va_mat_mul[5, 3] = 7;
            va_mat_mul[5, 4] = 6;
            va_mat_mul[5, 5] = 0;
            va_mat_mul[5, 6] = 4;
            va_mat_mul[5, 7] = 3;
            va_mat_mul[5, 8] = 2;
            va_mat_mul[5, 9] = 1;

            va_mat_mul[6, 0] = 6;
            va_mat_mul[6, 1] = 5;
            va_mat_mul[6, 2] = 9;
            va_mat_mul[6, 3] = 8;
            va_mat_mul[6, 4] = 7;
            va_mat_mul[6, 5] = 1;
            va_mat_mul[6, 6] = 0;
            va_mat_mul[6, 7] = 4;
            va_mat_mul[6, 8] = 3;
            va_mat_mul[6, 9] = 2;

            va_mat_mul[7, 0] = 7;
            va_mat_mul[7, 1] = 6;
            va_mat_mul[7, 2] = 5;
            va_mat_mul[7, 3] = 9;
            va_mat_mul[7, 4] = 8;
            va_mat_mul[7, 5] = 2;
            va_mat_mul[7, 6] = 1;
            va_mat_mul[7, 7] = 0;
            va_mat_mul[7, 8] = 4;
            va_mat_mul[7, 9] = 3;

            va_mat_mul[8, 0] = 8;
            va_mat_mul[8, 1] = 7;
            va_mat_mul[8, 2] = 6;
            va_mat_mul[8, 3] = 5;
            va_mat_mul[8, 4] = 9;
            va_mat_mul[8, 5] = 3;
            va_mat_mul[8, 6] = 2;
            va_mat_mul[8, 7] = 1;
            va_mat_mul[8, 8] = 0;
            va_mat_mul[8, 9] = 4;

            va_mat_mul[9, 0] = 9;
            va_mat_mul[9, 1] = 8;
            va_mat_mul[9, 2] = 7;
            va_mat_mul[9, 3] = 6;
            va_mat_mul[9, 4] = 5;
            va_mat_mul[9, 5] = 4;
            va_mat_mul[9, 6] = 3;
            va_mat_mul[9, 7] = 2;
            va_mat_mul[9, 8] = 1;
            va_mat_mul[9, 9] = 0;
            //#############################################################################################


            //#############################################################################################
            //      ************ Asigna Valores a la matriz PERMUTA **************************
            //      * de la posicion 0-7, la posicion 8 es igual 0, la 9= 1            *
            //      ********************************************************************
            va_mat_per[0, 0] = 0;
            va_mat_per[0, 1] = 1;
            va_mat_per[0, 2] = 2;
            va_mat_per[0, 3] = 3;
            va_mat_per[0, 4] = 4;
            va_mat_per[0, 5] = 5;
            va_mat_per[0, 6] = 6;
            va_mat_per[0, 7] = 7;
            va_mat_per[0, 8] = 8;
            va_mat_per[0, 9] = 9;

            va_mat_per[1, 0] = 1;
            va_mat_per[1, 1] = 5;
            va_mat_per[1, 2] = 7;
            va_mat_per[1, 3] = 6;
            va_mat_per[1, 4] = 2;
            va_mat_per[1, 5] = 8;
            va_mat_per[1, 6] = 3;
            va_mat_per[1, 7] = 0;
            va_mat_per[1, 8] = 9;
            va_mat_per[1, 9] = 4;

            va_mat_per[2, 0] = 5;
            va_mat_per[2, 1] = 8;
            va_mat_per[2, 2] = 0;
            va_mat_per[2, 3] = 3;
            va_mat_per[2, 4] = 7;
            va_mat_per[2, 5] = 9;
            va_mat_per[2, 6] = 6;
            va_mat_per[2, 7] = 1;
            va_mat_per[2, 8] = 4;
            va_mat_per[2, 9] = 2;

            va_mat_per[3, 0] = 8;
            va_mat_per[3, 1] = 9;
            va_mat_per[3, 2] = 1;
            va_mat_per[3, 3] = 6;
            va_mat_per[3, 4] = 0;
            va_mat_per[3, 5] = 4;
            va_mat_per[3, 6] = 3;
            va_mat_per[3, 7] = 5;
            va_mat_per[3, 8] = 2;
            va_mat_per[3, 9] = 7;


            va_mat_per[4, 0] = 9;
            va_mat_per[4, 1] = 4;
            va_mat_per[4, 2] = 5;
            va_mat_per[4, 3] = 3;
            va_mat_per[4, 4] = 1;
            va_mat_per[4, 5] = 2;
            va_mat_per[4, 6] = 6;
            va_mat_per[4, 7] = 8;
            va_mat_per[4, 8] = 7;
            va_mat_per[4, 9] = 0;

            va_mat_per[5, 0] = 4;
            va_mat_per[5, 1] = 2;
            va_mat_per[5, 2] = 8;
            va_mat_per[5, 3] = 6;
            va_mat_per[5, 4] = 5;
            va_mat_per[5, 5] = 7;
            va_mat_per[5, 6] = 3;
            va_mat_per[5, 7] = 9;
            va_mat_per[5, 8] = 0;
            va_mat_per[5, 9] = 1;

            va_mat_per[6, 0] = 2;
            va_mat_per[6, 1] = 7;
            va_mat_per[6, 2] = 9;
            va_mat_per[6, 3] = 3;
            va_mat_per[6, 4] = 8;
            va_mat_per[6, 5] = 0;
            va_mat_per[6, 6] = 6;
            va_mat_per[6, 7] = 4;
            va_mat_per[6, 8] = 1;
            va_mat_per[6, 9] = 5;

            va_mat_per[7, 0] = 7;
            va_mat_per[7, 1] = 0;
            va_mat_per[7, 2] = 4;
            va_mat_per[7, 3] = 6;
            va_mat_per[7, 4] = 9;
            va_mat_per[7, 5] = 1;
            va_mat_per[7, 6] = 3;
            va_mat_per[7, 7] = 2;
            va_mat_per[7, 8] = 5;
            va_mat_per[7, 9] = 8;
            //############################################################################


            //############################################################################
            //      ****************************************************************
            //      *   Arreglo de Inverso 
            //      ****************************************************************
            va_mat_inv[0] = 0;
            va_mat_inv[1] = 4;
            va_mat_inv[2] = 3;
            va_mat_inv[3] = 2;
            va_mat_inv[4] = 1;
            va_mat_inv[5] = 5;
            va_mat_inv[6] = 6;
            va_mat_inv[7] = 7;
            va_mat_inv[8] = 8;
            va_mat_inv[9] = 9;
            //###########################################################################


            va_chk_chk = 0;


            //##########################################################################
            //INVIERTE CIFRA; SI LA SIFRA ES 6583 RESULTARA 3856

            //ar_cif_fra = CInt(ar_cif_fra)

            //--Obtengo el tamaño de la cifra
            va_tam_cad = ar_ci_fra.Length;

            //--Recorre la cifra de atras hacia adelante y concatenandola
            for (int i = va_tam_cad; i >= 1; i--)
            {
                //--- la formula de (va_tam_cad - i) ara que posicion a guardar 
                if (va_tam_cad == 1)
                {
                    //--- si la cifra contiene solo 1 digito
                    va_num_inv[0] = ar_ci_fra;
                }
                else
                {
                    //--- se incremente de 0 hasta el tamaño de la cadena
                    va_num_inv[va_tam_cad - i] = sub_string(ar_ci_fra, i, 1);
                }
            }
            //###########################################################################


            //###########################################################################
            //Define el numero verificador
            for (int i = 0; i <= ((va_tam_cad) - 1); i++)
            {
                string A = va_num_inv[i].ToString();
                int AA = va_mat_per[((i + 1) % 8), Convert.ToInt32(va_num_inv[i])];

                va_chk_chk = va_mat_mul[va_chk_chk, va_mat_per[((i + 1) % 8), Convert.ToInt32(va_num_inv[i])]];
            }
            //###########################################################################


            return va_mat_inv[va_chk_chk];

        }

        #endregion

    }
}
