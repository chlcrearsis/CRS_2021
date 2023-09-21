using CRS_DAT;
using System;
using System.Data;
using System.Text;

namespace CRS_NEG
{
    //######################################################################
    //##       Tabla: ads017                                              ##
    //##      Nombre: PIN Usuario                                         ##
    //## Descripcion: PIN Usuario                                         ##         
    //##       Autor: EJR - (04-08-2023)                                  ##
    //######################################################################
    public class ads017
    {        
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "Registra PIN de Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pin_usr">PIN Usuario</param>
        /// <param name="fec_exp">Fecha Expiración</param>
        /// <param name="usr_reg">ID. Usuario Registro</param>
        /// <param name="nom_equ">Nombre Equipo</param>
        public void Fe_nue_reg(string ide_usr, int pin_usr, string fec_exp, string usr_reg, string nom_equ)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads017 VALUES ('" + ide_usr + "', " + pin_usr + ", GETDATE(), '" + fec_exp + "', '" + usr_reg + "', '" + nom_equ + "')");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Modifica PIN de Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="pin_usr">PIN Usuario</param>
        /// <param name="fec_exp">Fecha Expiración</param>
        /// <param name="usr_reg">ID. Usuario Registro</param>
        /// <param name="nom_equ">Nombre Equipo</param>
        public void Fe_edi_tar(string ide_usr, int pin_usr, string fec_exp, string usr_reg, string nom_equ)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("UPDATE ads017 SET va_pin_usr =  " + pin_usr + ", va_fec_reg = GETDATE(), va_fec_exp = '" + fec_exp + "', va_usr_reg = '" + usr_reg + "', va_nom_equ = '" + nom_equ + "'");
                cadena.AppendLine("            WHERE va_ide_usr = '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Elimina PIN de Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        public void Fe_eli_min(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("DELETE ads017 WHERE va_ide_usr = '" + ide_usr + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion "Consulta PIN de Usuario"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <returns></returns>
        public DataTable Fe_con_pin(string ide_usr)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("SELECT ads017.va_ide_usr, ads007.va_nom_usr, ads017.va_pin_usr,");
                cadena.AppendLine("       ads017.va_fec_reg, ads017.va_fec_exp, ads017.va_usr_reg,");
                cadena.AppendLine("       ads017.va_nom_equ");
                cadena.AppendLine("  FROM ads017, ads007");
                cadena.AppendLine(" WHERE ads017.va_ide_usr = ads007.va_ide_usr");
                cadena.AppendLine("   AND ads017.va_ide_usr = '" + ide_usr + "'");

                return ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}