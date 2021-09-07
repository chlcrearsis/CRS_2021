using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    /// Clase: Funciones generales consultas BD.
    /// </summary>
    public class General
    {
        conexion_a ob_con_ecA = new conexion_a();

        /// <summary>
        /// FUNCION GLOBAL: Obtiene la fecha actual del servidor///
        /// </summary>
        /// <returns></returns>
        public DateTime Fe_fec_act()
        {
            string StrSql = " select CURRENT_TIMESTAMP";
            DateTime fe_cha = Convert.ToDateTime(ob_con_ecA.fe_exe_sql(StrSql).Rows[0][0].ToString());
            return fe_cha;
        }

        /// <summary>
        /// Genera un Codigo Unico de 32 dígitos
        /// </summary>
        /// <returns></returns>
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// Funcion que me general la clave para activar el sistema
        /// </summary>
        public string Fu_obt_pin() {
            // Obtiene la fecha del servidor
            string fec_act = Fe_fec_act().ToString();
            // Obtiene el dia - mes - año de la fecha actual
            string dia_act = fec_act.Substring(0, 2);
            string mes_act = fec_act.Substring(3, 2);
            string año_act = fec_act.Substring(6, 4);
            // Concatena en año - mes - dia actual
            string num_cal = año_act + mes_act + dia_act;
            // Convierte la variable en Base64String
            byte[] str_byt = Encoding.UTF7.GetBytes(num_cal);
            string str_b64 = Convert.ToBase64String(str_byt);
            // Obtiene los 7 primeros digitos
            string car_ter1 = str_b64.Substring(0, 1);
            string car_ter2 = str_b64.Substring(1, 1);
            string car_ter3 = str_b64.Substring(2, 1);
            string car_ter4 = str_b64.Substring(3, 1);
            string car_ter5 = str_b64.Substring(4, 1);
            string car_ter6 = str_b64.Substring(5, 1);
            string car_ter7 = str_b64.Substring(6, 1);
            // Obtiene el Codigo PIN
            string cod_pin = "c";
            cod_pin += Fi_num_car(car_ter1);
            cod_pin += Fi_car_num(car_ter2);
            cod_pin += Fi_car_num(car_ter3);
            cod_pin += Fi_car_num(car_ter4);
            cod_pin += Fi_car_num(car_ter5);
            cod_pin += Fi_car_num(car_ter6);
            cod_pin += Fi_car_num(car_ter7);

            return cod_pin;
        }

        /// <summary>
        /// Funcion que ma castea el Caracter en Número
        /// </summary>
        /// <param name="car_str">Caracter a Castear</param>
        /// <returns>Numero (0-9)</returns>
        private int Fi_car_num(string car_str) {
            int num_str = 0;
            switch (car_str) { 
                case "a":
                    num_str = 0;
                    break;
                case "A":
                    num_str = 1;
                    break;
                case "b":
                    num_str = 2;
                    break;
                case "B":
                    num_str = 3;
                    break;
                case "c":
                    num_str = 4;
                    break;
                case "C":
                    num_str = 5;
                    break;
                case "d":
                    num_str = 6;
                    break;
                case "D":
                    num_str = 7;
                    break;
                case "e":
                    num_str = 8;
                    break;
                case "E":
                    num_str = 9;
                    break;
                case "f":
                    num_str = 0;
                    break;
                case "F":
                    num_str = 1;
                    break;
                case "g":
                    num_str = 2;
                    break;
                case "G":
                    num_str = 3;
                    break;
                case "h":
                    num_str = 4;
                    break;
                case "H":
                    num_str = 5;
                    break;
                case "i":
                    num_str = 6;
                    break;
                case "I":
                    num_str = 7;
                    break;
                case "j":
                    num_str = 8;
                    break;
                case "J":
                    num_str = 9;
                    break;
                case "k":
                    num_str = 0;
                    break;
                case "K":
                    num_str = 1;
                    break;
                case "l":
                    num_str = 2;
                    break;
                case "L":
                    num_str = 3;
                    break;
                case "m":
                    num_str = 4;
                    break;
                case "M":
                    num_str = 5;
                    break;
                case "n":
                    num_str = 6;
                    break;
                case "N":
                    num_str = 7;
                    break;
                case "o":
                    num_str = 8;
                    break;
                case "O":
                    num_str = 9;
                    break;
                case "p":
                    num_str = 0;
                    break;
                case "P":
                    num_str = 1;
                    break;
                case "q":
                    num_str = 2;
                    break;
                case "Q":
                    num_str = 3;
                    break;
                case "r":
                    num_str = 4;
                    break;
                case "R":
                    num_str = 5;
                    break;
                case "s":
                    num_str = 6;
                    break;
                case "S":
                    num_str = 7;
                    break;
                case "t":
                    num_str = 8;
                    break;
                case "T":
                    num_str = 9;
                    break;
                case "u":
                    num_str = 0;
                    break;
                case "U":
                    num_str = 1;
                    break;
                case "v":
                    num_str = 2;
                    break;
                case "V":
                    num_str = 3;
                    break;
                case "w":
                    num_str = 4;
                    break;
                case "W":
                    num_str = 5;
                    break;
                case "x":
                    num_str = 6;
                    break;
                case "X":
                    num_str = 7;
                    break;
                case "y":
                    num_str = 8;
                    break;
                case "Y":
                    num_str = 9;
                    break;
                case "z":
                    num_str = 0;
                    break;
                case "Z":
                    num_str = 1;
                    break;
                default:
                    num_str = 0;
                    break;
            }
            return num_str;
        }

        /// <summary>
        /// Función que castea el Número a Caracter
        /// </summary>
        /// <param name="num_str">Numero a Castear (String)</param>
        /// <returns>Caracter [b-c-d-f-g-h-j-k-l-m-x]</returns>
        public string Fi_num_car(string num_str) {
            string car_str = string.Empty;
            switch (num_str) {
                case "0":
                    car_str = "b";
                    break;
                case "1":
                    car_str = "c";
                    break;
                case "2":
                    car_str = "d";
                    break;
                case "3":
                    car_str = "f";
                    break;
                case "4":
                    car_str = "g";
                    break;
                case "5":
                    car_str = "h";
                    break;
                case "6":
                    car_str = "j";
                    break;
                case "7":
                    car_str = "k";
                    break;
                case "8":
                    car_str = "l";
                    break;
                case "9":
                    car_str = "m";
                    break;
                default:
                    car_str = "x";
                    break;
            }
            return car_str;
        }

    }
}
