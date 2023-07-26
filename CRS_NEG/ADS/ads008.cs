using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_DAT;
using static CRS_NEG.ads007;

namespace CRS_NEG
{
    /// <summary>
    /// Clase PERMISO USUARIOS SOBRE EL SISTEMA
    /// </summary>
    public class ads008
    {
        //######################################################################
        //##       Tabla: ads008_01                                           ##
        //##      Nombre: Autorizaciones Usuarios                             ##
        //## Descripcion: Permiso Usuarios sobre el sistema                   ##         
        //##       Autor: JEJR - (05-01-2019)                                 ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar Autorizacion Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <param name="ide_int">Identificador Entero</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_usr, string ide_tab, string ide_uno = "",
                               string ide_dos = "", string ide_tre = "", int ide_int = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads008 VALUES ('" + ide_usr + "', '" + ide_tab + "', '" + ide_uno + "',");
                cadena.AppendLine("                           '" + ide_dos + "', '" + ide_tre + "',  " + ide_int + ")");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica Autorizacion Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <param name="ide_int">Identificador Entero</param>
        /// <returns></returns>
        public void Fe_edi_tar(string ide_usr, string ide_tab, string ide_uno,
                               string ide_dos, string ide_tre, int ide_int)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads008 SET va_ide_int =  " + ide_int + "");
                cadena.AppendLine("            WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("              AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("              AND va_ide_uno = '" + ide_uno + "'");
                cadena.AppendLine("              AND va_ide_dos = '" + ide_dos + "'");
                cadena.AppendLine("              AND va_ide_tre = '" + ide_tre + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina 1 Autorizacion Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads008 WHERE va_ide_usr = '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina 2 Autorizacion Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_usr, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads008 WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("                AND va_ide_tab = '" + ide_tab + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina 3 Autorizacion Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_usr, string ide_tab, string ide_uno)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads008 WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("                AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("                AND va_ide_uno = '" + ide_uno + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina 4 Autorizacion Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_usr, string ide_tab, string ide_uno,
                               string ide_dos)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads008 WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("                AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("                AND va_ide_uno = '" + ide_uno + "'");
                cadena.AppendLine("                AND va_ide_dos = '" + ide_dos + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina 5 Autorizacion Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <returns></returns>
        public void Fe_eli_min(string ide_usr, string ide_tab, string ide_uno,
                               string ide_dos, string ide_tre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads008 WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("                AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("                AND va_ide_uno = '" + ide_uno + "'");
                cadena.AppendLine("                AND va_ide_dos = '" + ide_dos + "'");
                cadena.AppendLine("                AND va_ide_tre = '" + ide_tre + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Aplicaciones Autorizadas al Usuario
        /// p/Menu Principal
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_apl_aut(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_01a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta 1 "Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(string ide_usr, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta 2 "Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(string ide_usr, string ide_tab, string ide_uno)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("   AND va_ide_uno = '" + ide_uno + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta 3 "Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(string ide_usr, string ide_tab, string ide_uno,
                                    string ide_dos)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("   AND va_ide_uno = '" + ide_uno + "'");
                cadena.AppendLine("   AND va_ide_dos = '" + ide_dos + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta 4 "Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(string ide_usr, string ide_tab, string ide_uno,
                                    string ide_dos, string ide_tre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("   AND va_ide_uno = '" + ide_uno + "'");
                cadena.AppendLine("   AND va_ide_dos = '" + ide_dos + "'");
                cadena.AppendLine("   AND va_ide_tre = '" + ide_tre + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Función 1 "Verifica Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <returns></returns>
        public bool Fe_aut_usr(string ide_usr, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");

                DataTable dt_tab_res = ob_con_ecA.fe_exe_sql(cadena.ToString());
                return dt_tab_res.Rows.Count != 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion 2 "Verifica Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <returns></returns>
        public bool Fe_aut_usr(string ide_usr, string ide_tab, string ide_uno)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("   AND va_ide_uno = '" + ide_uno + "'");

                DataTable dt_tab_res = ob_con_ecA.fe_exe_sql(cadena.ToString());
                return dt_tab_res.Rows.Count != 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion 3 "Verifica Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <returns></returns>
        public bool Fe_aut_usr(string ide_usr, string ide_tab, string ide_uno,
                               string ide_dos)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("   AND va_ide_uno = '" + ide_uno + "'");
                cadena.AppendLine("   AND va_ide_dos = '" + ide_dos + "'");

                DataTable dt_tab_res = ob_con_ecA.fe_exe_sql(cadena.ToString());
                return dt_tab_res.Rows.Count != 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Función 4 "Verifica Autorización Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <returns></returns>
        public bool Fe_aut_usr(string ide_usr, string ide_tab, string ide_uno,
                               string ide_dos, string ide_tre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads008");
                cadena.AppendLine(" WHERE va_ide_usr = '" + ide_usr + "'");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");
                cadena.AppendLine("   AND va_ide_uno = '" + ide_uno + "'");
                cadena.AppendLine("   AND va_ide_dos = '" + ide_dos + "'");
                cadena.AppendLine("   AND va_ide_tre = '" + ide_tre + "'");

                DataTable dt_tab_res = ob_con_ecA.fe_exe_sql(cadena.ToString());
                return dt_tab_res.Rows.Count != 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
           
    }
}
