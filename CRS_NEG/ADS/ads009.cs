using System;
using System.Data;
using System.Text;
using CRS_DAT;
namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads008_01                                           ##
    //##      Nombre: Autorizaciones Tipo de Usuarios                     ##
    //## Descripcion: Permiso Usuarios sobre el sistema                   ##         
    //##       Autor: JEJR - (29-08-2023)                                 ##
    //######################################################################
    public class ads009
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registrar Autorizacion Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <param name="ide_int">Identificador Entero</param>
        /// <returns></returns>
        public void Fe_nue_reg(int ide_tus, string ide_tab, string ide_uno = "", 
                               string ide_dos = "", string ide_tre = "", int ide_int = 0)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads009 VALUES (" + ide_tus + ", '" + ide_tab + "', '" + ide_uno + "', '" + ide_dos + "',");
                cadena.AppendLine("                          '" + ide_tre + "', " + ide_int + ",  SYSTEM_USER, GETDATE())");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina 1 Autorizacion Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads009 WHERE va_ide_tus = " + ide_tus + "");
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
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_tus, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads009 WHERE va_ide_tus =  " + ide_tus + "");
                cadena.AppendLine("                AND va_ide_tab = '" + ide_tab + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina 3 Autorizacion Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_tus, string ide_tab, string ide_uno)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads009 WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Funcion "Elimina 4 Autorizacion Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_tus, string ide_tab, string ide_uno, string ide_dos)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads009 WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Funcion "Elimina 5 Autorizacion Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <returns></returns>
        public void Fe_eli_min(int ide_tus, string ide_tab, string ide_uno, string ide_dos, string ide_tre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads009 WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Consulta 1 "Autorización Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(int ide_tus, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
                cadena.AppendLine("   AND va_ide_tab = '" + ide_tab + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta 2 "Autorización Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(int ide_tus, string ide_tab, string ide_uno)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
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
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(int ide_tus, string ide_tab, string ide_uno, string ide_dos)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Consulta 4 "Autorización Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <returns></returns>
        public DataTable Fe_con_aut(int ide_tus, string ide_tab, string ide_uno, string ide_dos, string ide_tre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Función 1 "Verifica Autorización Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <returns></returns>
        public bool Fe_aut_tus(int ide_tus, string ide_tab)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
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
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <returns></returns>
        public bool Fe_aut_tus(int ide_tus, string ide_tab, string ide_uno)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Funcion 3 "Verifica Autorización Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <returns></returns>
        public bool Fe_aut_tus(int ide_tus, string ide_tab, string ide_uno, string ide_dos)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Función 4 "Verifica Autorización Tipo de Usuario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <param name="ide_tab">ID. Tabla</param>
        /// <param name="ide_uno">Identificador 1</param>
        /// <param name="ide_dos">Identificador 2</param>
        /// <param name="ide_tre">Identificador 3</param>
        /// <returns></returns>
        public bool Fe_aut_tus(int ide_tus, string ide_tab, string ide_uno,
                               string ide_dos, string ide_tre)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT va_ide_tus, va_ide_tab, va_ide_uno,");
                cadena.AppendLine("       va_ide_dos, va_ide_tre, va_ide_int");
                cadena.AppendLine("  FROM ads009");
                cadena.AppendLine(" WHERE va_ide_tus =  " + ide_tus + "");
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
        /// Consulta "Permiso Tipo de Usuario sobre Aplicacion"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_apl(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_01a_p01 " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Plantilla de Venta"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_pdv(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_03a_p01 " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Plantilla de Venta"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_lis(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_04a_p01 " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Grupo de Persona"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_gdp(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_06a_p01 " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Vendedor"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_ven(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_07a_p01 " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Cobrador"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_cob(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_08a_p01 " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Grupo de Bodega"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo de Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_gdb(int ide_tus)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_09a_p01 " + ide_tus + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Talonario"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_tal(int ide_tus, int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_02a_p01 " + ide_tus + ", " + ide_mod + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta "Permiso Tipo de Usuario sobre Bodega"
        /// </summary>
        /// <param name="ide_tus">ID. Tipo Usuario</param>
        /// <returns></returns>
        public DataTable Fe_tus_bod(int ide_tus, int ide_mod)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("EXECUTE ads009_05a_p01 " + ide_tus + ", " + ide_mod + "");
                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
