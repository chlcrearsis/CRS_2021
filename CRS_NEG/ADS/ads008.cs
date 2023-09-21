using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads008_01                                           ##
    //##      Nombre: Autorizaciones Usuarios                             ##
    //## Descripcion: Permiso Usuarios sobre el sistema                   ##         
    //##       Autor: JEJR - (05-01-2019)                                 ##
    //######################################################################
    public class ads008
    {        
        conexion_a ob_con_ecA = new conexion_a();
        General general = new General();
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
                cadena.AppendLine("INSERT INTO ads008 VALUES ('" + ide_usr + "', '" + ide_tab + "', '" + ide_uno + "', '" + ide_dos + "',");
                cadena.AppendLine("                           '" + ide_tre + "',  " + ide_int + ",  SYSTEM_USER, GETDATE())");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("SELECT va_ide_usr, va_ide_tab, va_ide_uno, va_ide_dos,");
                cadena.AppendLine("       va_ide_tre, va_ide_int, va_usr_reg, va_fch_reg");
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
                cadena.AppendLine("EXECUTE ads008_01b_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Aplicacion"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_usr_apl(string ide_usr)
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
        /// Consulta "Permiso Usuario sobre Plantilla de Venta"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_usr_pdv(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_03a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Lista de Precio"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_usr_lis(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_04a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Grupo de Persona"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_usr_gdp(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_06a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Vendedor"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_usr_ven(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_07a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Cobrador"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_usr_cob(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_08a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Grupo de Bodega"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_usr_gdb(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_09a_p01 '" + ide_usr + "'");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Talonario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="ide_mod">ID. Módulo</param>
        /// <returns></returns>
        public DataTable Fe_usr_tal(string ide_usr, int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_02a_p01 '" + ide_usr + "', " + ide_mod + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Usuario sobre Bodega"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="grp_bod">ID. Grupo Bodega</param>
        /// <returns></returns>
        public DataTable Fe_usr_bod(string ide_usr, int grp_bod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads008_05a_p01 '" + ide_usr + "', " + grp_bod + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
