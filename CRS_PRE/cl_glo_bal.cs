using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_PRE
{
    class cl_glo_bal
    {
        //metodo para validar si los valores son numericos
        public static bool IsNumeric(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public DateTime Fe_fec_act()
        {
            DateTime ve_fec_act = new DateTime();





            return ve_fec_act ;
        }

        /// <summary>
        /// FUNCION GLOBAL: Obtiene la fecha actual del servidor///
        /// </summary>
        /// <returns></returns>
        //public DateTime fg_fec_act()
        //{
        //    return ob_con_ecA.fg_fec_act();
        //}

    }
}
