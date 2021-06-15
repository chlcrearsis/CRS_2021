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

    }
}
