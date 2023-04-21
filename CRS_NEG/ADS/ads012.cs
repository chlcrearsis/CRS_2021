using CRS_DAT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_NEG
{
    public class ads012
    {
        //######################################################################
        //##       Tabla: ads012                                              ##
        //##      Nombre: GLOBALES                                            ##
        //## Descripcion:                                                     ##         
        //##       Autor: CHL  - (01-04-2020)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();

        public string va_ser_bda;//= ob_con_ecA.va_ins_bda;

        public string va_ins_bda;// = ob_con_ecA.va_ins_bda;
        public string va_nom_bda;//= ob_con_ecA.va_nom_bda;
        public string va_ide_usr;//= ob_con_ecA.va_ide_usr;
        public string va_pas_usr;//= ob_con_ecA.va_pas_usr;

        string cadena = "";



        public ads012()
        {
            va_ser_bda = ob_con_ecA.va_ser_bda;
            va_ins_bda = ob_con_ecA.va_ins_bda;
            va_nom_bda = ob_con_ecA.va_nom_bda;
            va_ide_usr = ob_con_ecA.va_ide_usr;
            va_pas_usr = ob_con_ecA.va_pas_usr;
        }

        /// <summary>
        /// Funcion "BUSCAR RESTRICCIONES DEL MENU P/USUARIO"
        /// </summary>
        /// <param name="ide_usr">Codigo de usuario</param>
        /// <returns></returns>
        public DataTable _01(string ide_usr)
        {
            try
            {
                cadena = "";
                cadena += " SELECT * FROM ads012   ";
                cadena += " WHERE va_ide_usr ='" + ide_usr + "' ";

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion "Registrar RESTRICCION DEL MENU P/USUARIO"
        /// </summary>
        /// <param name="ide_usr">Codigo de usuario</param>
        /// <param name="cod_win">Codigo de la aplicacion</param>
        /// <param name="ide_mnu"></param>
        /// <returns></returns>
        public void _02(string ide_usr, string cod_win, string ide_mnu)
        {
            try
            {
                cadena = "";
                cadena += " INSERT INTO ads012 VALUES ";
                cadena += " ('" + ide_usr + "','" + cod_win + "','" + ide_mnu + "' )";

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Funcion consultar "MENUS AUTORIZADOS/RESTRINGIDOS P/USUARIO"
        /// </summary>
        /// <param name="ide_usr">Codigo de usuario</param>
        /// <param name="cod_win">codigo de la aplicacion</param>
        /// <param name="ide_mnu"></param>
        /// <returns></returns>
        public DataTable _05(string ide_usr, string cod_win, string ide_mnu)
        {
            try
            {
                cadena = "";
                cadena += " SELECT * FROM ads012   ";
                cadena += " WHERE va_ide_usr ='" + ide_usr + "' AND va_nom_frm ='" + cod_win + "' ";
                cadena += " AND va_ide_men ='" + ide_mnu + "'";

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  Funcion "Elimina OPCION DEL MENU P/USUARIO (otorga permiso)"
        /// </summary>
        /// <param name="ide_usr">Codigo de usuario</param>
        /// <param name="cod_win">Codigo de la aplicacion</param>
        /// <param name="ide_mnu"></param>
        /// <returns></returns>
        public void _06(string ide_usr, string cod_win, string ide_mnu)
        {
            try
            {
                cadena = "";
                cadena += " DELETE ads012 ";
                cadena += " WHERE va_ide_usr ='" + ide_usr + "' AND va_ide_apl ='" + cod_win + "' ";
                cadena += " AND va_ide_mnu ='" + ide_mnu + "'";

                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
