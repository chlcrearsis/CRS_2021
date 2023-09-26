using System;
using System.Text;
using CRS_DAT;

namespace CRS_NEG
{
    /// <summary>
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    ///  Clase BITACORA P/OPERACIONES
    ///  ◘◘◘◘◘◘◘◘◘◘◘◘◘◘
    /// </summary>
    public class ads025
    {
        //######################################################################
        //##       Tabla: ads025                                              ##
        //##      Nombre: BITACORA P/OPERACIONES                              ##
        //## Descripcion: Informe Bitacora p/Operaciones                      ##         
        //##       Autor: JEJR  - (23-09-2021)                                ##
        //######################################################################
        conexion_a ob_con_ecA = new conexion_a();
        StringBuilder cadena;

        /// <summary>
        /// Funcion "REGISTRA BITACORA P/OPERACIONES"
        /// </summary>
        /// <param name="ide_usr">ID. Usuario</param>
        /// <param name="fch_reg">Fecha y Hora de Registro</param>
        /// <param name="nom_apl">Nombre de Aplicación</param>
        /// <param name="tip_ope">Tipo de Operación (N=Nuevo; E=Edita; H=Habilita; D=Deshabilita; A=Anula; C=Concluye; P=Aprueba; R=Rechaza)</param>
        /// <param name="nom_maq">Nombre de Equipo</param>
        /// <param name="obs_reg">Observación</param>
        /// <returns></returns>
        public void Fe_nue_reg(string ide_usr, string fch_reg, string nom_apl, 
                               string tip_ope, string nom_maq, string obs_reg)
        {
            try
            {
                cadena = new StringBuilder();
                cadena.AppendLine("INSERT INTO ads025 VALUES ('" + ide_usr + "', '" + fch_reg + "', '" + nom_apl + "',");
                cadena.AppendLine("                           '" + tip_ope + "', '" + nom_maq + "', '" + obs_reg + "'");
                ob_con_ecA.fe_exe_sql(cadena.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
