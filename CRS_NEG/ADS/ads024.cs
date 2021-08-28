using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
namespace CRS_NEG
{
    public class ads024
    {
        //######################################################################
        //##       Tabla: ads024_01                                           ##
        //##      Nombre: Bitacora de Inicio de Sesion                        ##
        //## Descripcion: Registro de Inicio del Usuario                      ##         
        //##       Autor: JEJR - (27-02-2021)                                  ##
        //######################################################################

        conexion_a ob_con_ecA = new conexion_a();
        string cadena = "";

        /// <summary>
        /// Registra Bitacora de Inicio de Sesion
        /// </summary>
        /// <param name="ag_ide_uni">Identificador Unico</param>
        /// /// <param name="ag_ide_usr">ID. Usuario</param>
        /// <param name="ag_fec_reg">Fecha de Registro</param>
        /// <param name="ag_nom_maq">Nombre de la Maquina</param>
        /// <param name="ag_fec_ini">Fecha y Hora Inicio</param>
        /// <param name="ag_fec_ini">Fecha y Hora Final</param>
        /// <returns></returns>
        public DataTable Fe_ini_ses(string ag_ide_uni, string ag_ide_usr, string ag_nom_maq)
        {
            cadena = "EXECUTE ads024_01a_p01 '" + ag_ide_uni + "', '" + ag_ide_usr + "', '" + ag_nom_maq + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }

        public DataTable Fe_fin_ses(string ag_ide_uni)
        {
            cadena = " EXECUTE ads024_02a_p01 '" + ag_ide_uni + "'";
            return ob_con_ecA.fe_exe_sql(cadena);
        }


    }
}
